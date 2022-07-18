#region References
using Server.Items;
using System;
#endregion

namespace Server.Engines.Craft
{

	#region Mondain's Legacy
	public enum SmithRecipes
	{
		// magical
		TrueSpellblade = 300,
		IcySpellblade = 301,
		FierySpellblade = 302,
		SpellbladeOfDefense = 303,
		TrueAssassinSpike = 304,
		ChargedAssassinSpike = 305,
		MagekillerAssassinSpike = 306,
		WoundingAssassinSpike = 307,
		TrueLeafblade = 308,
		Luckblade = 309,
		MagekillerLeafblade = 310,
		LeafbladeOfEase = 311,
		KnightsWarCleaver = 312,
		ButchersWarCleaver = 313,
		SerratedWarCleaver = 314,
		TrueWarCleaver = 315,
		AdventurersMachete = 316,
		OrcishMachete = 317,
		MacheteOfDefense = 318,
		DiseasedMachete = 319,
		Runesabre = 320,
		MagesRuneBlade = 321,
		RuneBladeOfKnowledge = 322,
		CorruptedRuneBlade = 323,
		TrueRadiantScimitar = 324,
		DarkglowScimitar = 325,
		IcyScimitar = 326,
		TwinklingScimitar = 327,
		GuardianAxe = 328,
		SingingAxe = 329,
		ThunderingAxe = 330,
		HeavyOrnateAxe = 331,
		RubyMace = 332, //good
		EmeraldMace = 333, //good
		SapphireMace = 334, //good
		SilverEtchedMace = 335, //good
		BoneMachete = 336,

		// arties
		RuneCarvingKnife = 350,
		ColdForgedBlade = 351,
		OverseerSunderedBlade = 352,
		LuminousRuneBlade = 353,
		ShardTrasher = 354, //good

		// doom
		BritchesOfWarding = 355,
		GlovesOfFeudalGrip = 356,
	}
	#endregion

	public class DefBlacksmithy : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Blacksmith;

		//    public override int GumpTitleNumber => 1044002;

		public override string GumpTitleString => "Forge";



		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem => m_CraftSystem ?? (m_CraftSystem = new DefBlacksmithy());

		public override CraftECA ECA => CraftECA.Chance3Max;

		public override double GetChanceAtMin(CraftItem item)
		{
			if (item.NameNumber == 1157349 || item.NameNumber == 1157345) // Gloves Of FeudalGrip and Britches Of Warding
				return 0.05; // 5%

			return 0.0; // 0%
		}

		private DefBlacksmithy()
			: base(1, 1, 1.25) // base( 1, 2, 1.7 )
		{
			/*
            base( MinCraftEffect, MaxCraftEffect, Delay )
            MinCraftEffect    : The minimum number of time the mobile will play the craft effect
            MaxCraftEffect    : The maximum number of time the mobile will play the craft effect
            Delay            : The delay between each craft effect
            Example: (3, 6, 1.7) would make the mobile do the PlayCraftEffect override
            function between 3 and 6 time, with a 1.7 second delay each time.
            */
		}

		private static readonly Type typeofAnvil = typeof(AnvilAttribute);
		private static readonly Type typeofForge = typeof(ForgeAttribute);

		public static void CheckAnvilAndForge(Mobile from, int range, out bool anvil, out bool forge)
		{
			anvil = false;
			forge = false;

			Map map = from.Map;

			if (map == null)
			{
				return;
			}

			IPooledEnumerable eable = map.GetItemsInRange(from.Location, range);

			foreach (Item item in eable)
			{
				Type type = item.GetType();

				bool isAnvil = (type.IsDefined(typeofAnvil, false) || item.ItemID == 4015 || item.ItemID == 4016 ||
								item.ItemID == 0x2DD5 || item.ItemID == 0x2DD6 || (item.ItemID >= 0xA102 && item.ItemID <= 0xA10D));
				bool isForge = (type.IsDefined(typeofForge, false) || item.ItemID == 4017 ||
								(item.ItemID >= 6522 && item.ItemID <= 6569) || item.ItemID == 0x2DD8) ||
								item.ItemID == 0xA531 || item.ItemID == 0xA535;

				if (!isAnvil && !isForge)
				{
					continue;
				}

				if ((from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS(item))
				{
					continue;
				}

				anvil = anvil || isAnvil;
				forge = forge || isForge;

				if (anvil && forge)
				{
					break;
				}
			}

			eable.Free();

			for (int x = -range; (!anvil || !forge) && x <= range; ++x)
			{
				for (int y = -range; (!anvil || !forge) && y <= range; ++y)
				{
					StaticTile[] tiles = map.Tiles.GetStaticTiles(from.X + x, from.Y + y, true);

					for (int i = 0; (!anvil || !forge) && i < tiles.Length; ++i)
					{
						int id = tiles[i].ID;

						bool isAnvil = (id == 4015 || id == 4016 || id == 0x2DD5 || id == 0x2DD6);
						bool isForge = (id == 4017 || (id >= 6522 && id <= 6569) || id == 0x2DD8);

						if (!isAnvil && !isForge)
						{
							continue;
						}

						if ((from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z ||
							!from.InLOS(new Point3D(from.X + x, from.Y + y, tiles[i].Z + (tiles[i].Height / 2) + 1)))
						{
							continue;
						}

						anvil = anvil || isAnvil;
						forge = forge || isForge;
					}
				}
			}
		}

		public override int CanCraft(Mobile from, ITool tool, Type itemType)
		{
			int num = 0;

			if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
			{
				return 1044038; // You have worn out your tool!
			}

			if (tool is Item && !BaseTool.CheckTool((Item)tool, from))
			{
				return 1048146; // If you have a tool equipped, you must use that tool.
			}

			else if (!tool.CheckAccessible(from, ref num))
			{
				return num; // The tool must be on your person to use.
			}

			if (tool is AddonToolComponent && from.InRange(((AddonToolComponent)tool).GetWorldLocation(), 2))
			{
				return 0;
			}

			bool anvil, forge;
			CheckAnvilAndForge(from, 2, out anvil, out forge);

			if (anvil && forge)
			{
				return 0;
			}

			return 1044267; // You must be near an anvil and a forge to smith items.
		}

		public override void PlayCraftEffect(Mobile from)
		{
			// no animation, instant sound
			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//    from.Animate( 9, 5, 1, true, false, 0 );
			//new InternalTimer( from ).Start();
			from.PlaySound(0x2A);
		}

		// Delay to synchronize the sound with the hit on the anvil
		private class InternalTimer : Timer
		{
			private readonly Mobile m_From;

			public InternalTimer(Mobile from)
				: base(TimeSpan.FromSeconds(0.7))
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound(0x2A);
			}
		}

		public override int PlayEndingEffect(
			Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
			{
				from.SendLocalizedMessage(1044038); // You have worn out your tool
			}

			if (failed)
			{
				if (lostMaterial)
				{
					return 1044043; // You failed to create the item, and some of your materials are lost.
				}

				return 1044157; // You failed to create the item, but no materials were lost.
			}

			if (quality == 0)
			{
				return 502785; // You were barely able to make this item.  It's quality is below average.
			}

			if (makersMark && quality == 2)
			{
				return 1044156; // You create an exceptional quality item and affix your maker's mark.
			}

			if (quality == 2)
			{
				return 1044155; // You create an exceptional quality item.
			}

			return 1044154; // You create the item.
		}

		public override void InitCraftList()
		{
			/*
            Synthax for a SIMPLE craft item
            AddCraft( ObjectType, Group, MinSkill, MaxSkill, ResourceType, Amount, Message )
            ObjectType        : The type of the object you want to add to the build list.
            Group            : The group in wich the object will be showed in the craft menu.
            MinSkill        : The minimum of skill value
            MaxSkill        : The maximum of skill value
            ResourceType    : The type of the resource the mobile need to create the item
            Amount            : The amount of the ResourceType it need to create the item
            Message            : String or Int for Localized.  The message that will be sent to the mobile, if the specified resource is missing.
            Synthax for a COMPLEXE craft item.  A complexe item is an item that need either more than
            only one skill, or more than only one resource.
            Coming soon....
            */

			int index;
			#region "Anneaux"
			AddCraft(typeof(RingmailGloves), "Anneaux", "Gants d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RingmailLegs), "Anneaux", "Jambes d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(RingmailArms), "Anneaux", "Brassard d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(RingmailChest), "Anneaux", "Torse d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronMaille2), "Anneaux", "Torse d’anneaux fins", 30.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(JambiereMaille2), "Anneaux", "Jambière d’anneaux fins", 30.0, 70.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(BrassardMaille), "Anneaux", "Brassard d’anneaux fins", 30.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			#endregion

			#region "Mailles"
			AddCraft(typeof(ChainCoif), "Mailles", "Coiffe de mailles", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(CasqueKorain), "Mailles", "Casque Korain", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ChainLegs), "Mailles", "Jambes de mailles", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(ChainChest), "Mailles", "Tunique de maille", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);


			AddCraft(typeof(CasqueMaille), "Mailles", "Coiffe de mailles matelassée", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(GantsMaille), "Mailles", "Gants de mailles matelassées", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(JambiereMaille), "Mailles", "Jambière de mailles matelassée", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronMaille), "Mailles", "Tunique de mailles matelassée", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region "Harnois"
			AddCraft(typeof(PlateArms), "Harnois", "Brassards de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlateGloves), "Harnois", "Gants de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(PlateGorget), "Harnois", "Gorgerin de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(PlateLegs), "Harnois", "Jambières de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(PlateChest), "Harnois", "Torse de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(FemalePlateChest), "Harnois", "Torse de plaque femme", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(BrassardChaos), "Harnois", "Brassard du Chaos", 60.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronChaos), "Harnois", "Plastron du Chaos", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(BrassardDecoratif), "Harnois", "Brassard Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(JambiereDecoratif), "Harnois", "Jambière Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(PlastronDecoratif), "Harnois", "Plastron Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(BottesElfique), "Harnois", "Bottes Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(GantsElfique), "Harnois", "Gants Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GorgetElfique), "Harnois", "Gorget Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(PlastronElfique), "Harnois", "Plastron Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlastronPlaque), "Harnois", "Harnois", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlastronPlaqueDoree), "Harnois", "Plastron de plaque Dorée", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(DragonBardingDeed), "Harnois", "Dragon Barding Deed", 70.0, 122.5, typeof(IronIngot), 1044036, 750, 1044037);
			
			#endregion

			#region "Casques"
			AddCraft(typeof(Bascinet), "Casques", "Bascinet", 30.0, 70.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CloseHelm), "Casques", "Casque fermé", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(Helmet), "Casques", "Casque", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(NorseHelm), "Casques", "Haume Nordique", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(PlateHelm), "Casques", "Casque de Plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueChaos), "Casques", "Casque du Chaos", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueDecoratif), "Casques", "Casque Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueElfique), "Casques", "Casque Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			#endregion

			#region "Boucliers"
			AddCraft(typeof(Buckler), "Boucliers", "Bouclier", 10.0, 50.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(MetalShield), "Boucliers", "Rampart", 15.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			index = AddCraft(typeof(SmallPlateShield), "Boucliers", "Targe", 15.0, 55.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(WoodenKiteShield), "Boucliers", "La pointe", 20.0, 60.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(MediumPlateShield), "Boucliers", "Rondache", 20.0, 60.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(BronzeShield), "Boucliers", "Rondache résonnante", 25.0, 65.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(EcuBois), "Boucliers", "Écu de bois", 25.0, 65.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(BouclierRond2), "Boucliers", "Bouclier Rond", 25.0, 65.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Targe3), "Boucliers", "Targe renforcé", 25.0, 65.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(Rondache), "Boucliers", "Rondache renforcée", 30.0, 70.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(MetalKiteShield), "Boucliers", "Le blason", 30.0, 70.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(BouclierRond), "Boucliers", "Bouclier Rond Renforcé", 30.0, 70.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(ChaosShield), "Boucliers", "Targe décoré", 30.0, 70.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(HeaterShield), "Boucliers", "Muraille", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Pavois), "Boucliers", "Pavois", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Targe), "Boucliers", "Targe Bicolore", 40.0, 80.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(OrderShield), "Boucliers", "Égide", 40.0, 80.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(EcuLong), "Boucliers", "Écu Long", 50.0, 90.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Pavois2), "Boucliers", "Pavois Décoratif", 50.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Targe2), "Boucliers", "Rondache Colimaçon", 50.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			#endregion

			#region "Armes de poings"
			AddCraft(typeof(DoubleLames), "Armes de poings", "Double Lames de poing", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(Sai), "Armes de poings", "Sai", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Kama), "Armes de poings", "Kama", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Tekagi), "Armes de poings", "Griffes", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region "Dagues"
			AddCraft(typeof(Dagger), "Dagues", "Dague", 00.0, 40.0, typeof(IronIngot), 1044036, 3, 1044037);
			AddCraft(typeof(ElvenSpellblade), "Dagues", "Égorgeuse", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(AssassinSpike), "Dagues", "Épineuse", 40.0, 80.0, typeof(IronIngot), 1044036, 9, 1044037);
			AddCraft(typeof(Leafblade), "Dagues", "Coupe-gorge", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);

			AddCraft(typeof(SkinningKnife), "Dagues", 1023781, 25.0, 75.0, typeof(IronIngot), 1044036, 2, 1044037);
			AddCraft(typeof(Cleaver), "Dagues", 1097478, 20.0, 70.0, typeof(IronIngot), 1044036, 3, 1044037);
			AddCraft(typeof(ButcherKnife), "Dagues", 1097486, 25.0, 75.0, typeof(IronIngot), 1044036, 2, 1044037);
			#endregion

			#region "Épées"
			AddCraft(typeof(BoneHarvester), "Épées", "Serpe", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Broadsword), "Épées", "Épée courte", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Cutlass), "Épées", "Sabre Kroise", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Katana), "Épées", "Katana", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Longsword), "Épées", "Épée longue", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Scimitar), "Épées", "Cimeterre", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(VikingSword), "Épées", "Épée Kaloise", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeCourte), "Épées", "Épée Koraine", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(SabreLuxe), "Épées", "Sabre Kershe", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(EpeeBatardeLuxe), "Épées", "Épée bâtarde de luxe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeDoubleTranchant), "Épées", "Épée à Double Tranchants", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeLongue), "Épées", "Épée Longue", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeBatarde), "Épées", "Épée bâtarde", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(EpeeDeuxMains), "Épées", "Épée Deux Mains", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Runire), "Épées", "Runire", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(NoDachi), "Épées", "Éclat solaire", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Wakizashi), "Épées", "Surineur", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(RadiantScimitar), "Épées", "Cimeterre infini", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(RuneBlade), "Épées", "Lame vorpal", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(ElvenMachete), "Épées", "Machette runique", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleEpee), "Épées", "Double épée", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(WakizashiLong), "Épées", "Wakizashi Long", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Runire), "Épées", "Runire", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Daisho), "Épées", "Les jumelles", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			#endregion

			#region "Haches"
			AddCraft(typeof(Axe), "Haches", "Hache simple", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(BattleAxe), "Haches", "Hache de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleAxe), "Haches", "Hache double", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ExecutionersAxe), "Haches", "Hachette", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(LargeBattleAxe), "Haches", "Hache de bataille", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(TwoHandedAxe), "Haches", "Hache à deux mains", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(WarAxe), "Haches", "Tranchar", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(GrandeHache), "Haches", "Éventreuse", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(GrandeHacheDouble), "Haches", "Francisque", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(HacheDouble), "Haches", "Trombe", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(HAchePique), "Haches", "Barbelé", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(HacheDoublePiques), "Haches", "Exécutrice", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleAxe), "Haches", "Naga", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(HacheDoubleNaine), "Haches", "Gardienne", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(OrnateAxe), "Haches", "Hache ornée", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(DualShortAxes), "Haches", "Double hache courte", 40.0, 80.0, typeof(IronIngot), 1044036, 24, 1044037);
			AddCraft(typeof(DoubleHachette), "Haches", "Double Hachette", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);

			//        index = AddCraft(typeof(BattleAxe), "Haches", "Battle Axe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			//    index = AddCraft(typeof(Axe), "Haches", "Axe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);

			#endregion

			#region Hallebarde
			AddCraft(typeof(Bardiche), "Hallebardes", "Bardiche", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Hellebarde), "Hallebardes", "Hellebarde", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(BladedStaff), "Hallebardes", "BladedStaff", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(DoubleBladedStaff), "Hallebardes", "DoubleBladedStaff", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Halberd), "Hallebardes", "Hallebarde", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region "Lancer"
			AddCraft(typeof(Shuriken), "Lancer", "Shuriken", 40.0, 80.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(Boomerang), "Lancer", "Boomerang", 40.0, 80.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(Cyclone), "Lancer", "Cyclone", 40.0, 80.0, typeof(IronIngot), 1044036, 9, 1044037);
			AddCraft(typeof(SoulGlaive), "Lancer", "Étoile", 40.0, 80.0, typeof(IronIngot), 1044036, 9, 1044037);

			#region "Lances"
			AddCraft(typeof(Lance), "Lances", "Lance", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(Pike), "Lances", "Pique", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ShortSpear), "Lances", "Lance courte", 40.0, 80.0, typeof(IronIngot), 1044036, 6, 1044037);
			AddCraft(typeof(Scythe), "Lances", "Scythe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Spear), "Lances", "Lance de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Epieu), "Lances", "Épieu", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GrandeFourche), "Lances", "Fourche", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(JavelotLuxe), "Lances", "Javelot de Luxe", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Trident), "Lances", "Trident", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(WarFork), "Lances", "Fourche de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region "Masses et marteaux"
			AddCraft(typeof(HammerPick),"Masses et marteaux", "Marteau à pointes", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Mace), "Masses et marteaux", "Masse", 40.0, 80.0, typeof(IronIngot), 1044036, 6, 1044037);
			AddCraft(typeof(Maul), "Masses et marteaux", "Maul", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Scepter), "Masses et marteaux", "Sceptre", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(WarMace), "Masses et marteaux", "Masse de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(GrandeMasse), "Masses et marteaux", "Grande Masse", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MarteauPointes), "Masses et marteaux", "Étoile du matin", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Marteau), "Masses et marteaux", "Marteau", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MassueClous), "Masses et marteaux", "Massue à Clous", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MassuePointes), "Masses et marteaux", "Massue à Pointes", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Massue), "Masses et marteaux", "Massue", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MorgensternBoules), "Masses et marteaux", "Morgenstern à Boules", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MorgensternPointes), "Masses et marteaux", "Morgenstern à Pointes", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(WarHammer), "Masses et marteaux", "War Hammer", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Tessen), "Masses et marteaux", "Tessen", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			AddCraft(typeof(DiamondMace), "Masses et marteaux", "Masse diamant", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(WarHammer), "Masses et marteaux", "Dispenseur", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Maul), "Masses et marteaux", "Ogrillonne", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Tessen), "Masses et marteaux", "Caduçé", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			AddCraft(typeof(DiscMace), "Masses et marteaux", "Massu cranelée", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region "Rapières et Estoc"
			AddCraft(typeof(Rapiere), "Rapières et Estoc", "Rapière", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RapiereLuxe), "Rapières et Estoc", "Rapière de Luxe", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RapiereDecoree), "Rapières et Estoc", "Rapière Décorée", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Astoria), "Rapières et Estoc", "Astoria", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Kryss), "Rapières et Estoc", "Kryss", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(WarCleaver), "Rapières et Estoc", "Éclat lunaire", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Lajatang), "Rapières et Estoc", "Croissants de lune", 80.0, 130.0, typeof(IronIngot), 1044036, 25, 1044037);
			#endregion

			#region "Canons"
			AddCraft(typeof(Cannonball), "Canons", "Boulet de Canon", 10.0, 60.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(Grapeshot), "Canons", "Boulet Avancé", 15.0, 70.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(Cloth), 1044286, 2, 1044287);
			AddCraft(typeof(LightShipCannonDeed), "Canons", "Canon Léger", 65.0, 120.0, typeof(IronIngot), 1044036, 500, 1044037);
			AddCraft(typeof(HeavyShipCannonDeed), "Canons", "Canon Lourd", 70.0, 120.0, typeof(IronIngot), 1044036, 800, 1044037);
			#endregion

			// Set the overridable material
			SetSubRes(typeof(IronIngot), 1044022);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(IronIngot), 1044022, 00.0, 1044036, 1044269);
			AddSubRes(typeof(DullCopperIngot), 1044023, 50.0, 1044036, 1044269);
			AddSubRes(typeof(ShadowIronIngot), 1044024, 55.0, 1044036, 1044269);
			AddSubRes(typeof(CopperIngot), 1044025, 60.0, 1044036, 1044269);
			AddSubRes(typeof(BronzeIngot), 1044026, 65.0, 1044036, 1044269);
			AddSubRes(typeof(GoldIngot), 1044027, 70.0, 1044036, 1044269);
			AddSubRes(typeof(AgapiteIngot), 1044028, 75.0, 1044036, 1044269);
			AddSubRes(typeof(VeriteIngot), 1044029, 80.0, 1044036, 1044269);
			AddSubRes(typeof(ValoriteIngot), 1044030, 90.0, 1044036, 1044269);

			/*          SetSubRes2(typeof(RedScales), 1060875);

					  AddSubRes2(typeof(RedScales), 1060875, 0.0, 1053137, 1044268);
					  AddSubRes2(typeof(YellowScales), 1060876, 0.0, 1053137, 1044268);
					  AddSubRes2(typeof(BlackScales), 1060877, 0.0, 1053137, 1044268);
					  AddSubRes2(typeof(GreenScales), 1060878, 0.0, 1053137, 1044268);
					  AddSubRes2(typeof(WhiteScales), 1060879, 0.0, 1053137, 1044268);
					  AddSubRes2(typeof(BlueScales), 1060880, 0.0, 1053137, 1044268);
			*/
			Resmelt = true;
			Repair = true;
			MarkOption = true;
			CanEnhance = true;
			CanAlter = true;
		}
	}

	public class ForgeAttribute : Attribute
	{ }

	public class AnvilAttribute : Attribute
	{ }
}


#endregion