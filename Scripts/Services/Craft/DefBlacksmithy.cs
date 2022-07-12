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

			#region Anneaux
			AddCraft(typeof(RingmailGloves), 1111704, "Gants d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RingmailLegs), 1111704, "Jambes d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(RingmailArms), 1111704, "Brassard d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(RingmailChest), 1111704, "Torse d’anneaux", 30.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronMaille2), 1111704, "Torse d’anneaux fins", 30.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(JambiereMaille2), 1111704, "Jambière d’anneaux fins", 30.0, 70.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(BrassardMaille), 1111704, "Brassard d’anneaux fins", 30.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			#endregion

			#region Mailles
			AddCraft(typeof(ChainCoif), 1111704, "Coiffe de mailles", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(ChainLegs), 1111704, "Jambes de mailles", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(ChainChest), 1111704, "Tunique de maille", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);

			AddCraft(typeof(CasqueMaille), 1111704, "Coiffe de mailles matelassée", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(GantsMaille), 1111704, "Gants de mailles matelassées", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(JambiereMaille), 1111704, "Jambière de mailles matelassée", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronMaille), 1111704, "Tunique de mailles matelassée", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region Harnois
			AddCraft(typeof(PlateArms), 1111704, "Brassards de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlateGloves), 1111704, "Gants de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(PlateGorget), 1111704, "Gorgerin de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(PlateLegs), 1111704, "Jambières de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(PlateChest), 1111704, "Torse de plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(FemalePlateChest), 1111704, "Torse de plaque femme", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(BrassardChaos), 1111704, "Brassard du Chaos", 60.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronChaos), 1111704, "Plastron du Chaos", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(BrassardDecoratif), 1111704, "Brassard Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(JambiereDecoratif), 1111704, "Jambière Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(PlastronDecoratif), 1111704, "Plastron Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(BottesElfique), 1111704, "Bottes Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(GantsElfique), 1111704, "Gants Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GorgetElfique), 1111704, "Gorget Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(PlastronElfique), 1111704, "Plastron Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlastronPlaque), 1111704, "Harnois", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlastronPlaqueDoree), 1111704, "Plastron de plaque Dorée", 60.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(DragonBardingDeed), 1111704, "Dragon Barding Deed", 70.0, 122.5, typeof(IronIngot), 1044036, 750, 1044037);
			
			#endregion

			#region Helmets
			AddCraft(typeof(Bascinet), 1011079, "Bascinet", 30.0, 70.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CloseHelm), 1011079, "Casque fermé", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(Helmet), 1011079, "Casque", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(NorseHelm), 1011079, "Haume Nordique", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(PlateHelm), 1011079, "Casque de Plaque", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueChaos), 1011079, "Casque du Chaos", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueDecoratif), 1011079, "Casque Décoratif", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueElfique), 1011079, "Casque Elfique", 60.0, 90.0, typeof(IronIngot), 1044036, 15, 1044037);
			#endregion

			#region Shields
			index = AddCraft(typeof(Buckler), 1011080, "Bouclier", 10.0, 50.0, typeof(IronIngot), 1044036, 10, 1044037);
			index = AddCraft(typeof(MetalShield), 1011080, "Rampart", 15.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			index = AddCraft(typeof(SmallPlateShield), 1011080, "Targe", 15.0, 55.0, typeof(IronIngot), 1044036, 12, 1044037);
			index = AddCraft(typeof(WoodenKiteShield), 1011080, "La pointe", 20.0, 60.0, typeof(IronIngot), 1044036, 8, 1044037);
			index = AddCraft(typeof(MediumPlateShield), 1011080, "Rondache", 20.0, 60.0, typeof(IronIngot), 1044036, 14, 1044037);
			index = AddCraft(typeof(BronzeShield), 1011080, "Rondache résonnante", 25.0, 65.0, typeof(IronIngot), 1044036, 12, 1044037);
			index = AddCraft(typeof(EcuBois), 1011080, "Écu de bois", 25.0, 65.0, typeof(IronIngot), 1044036, 8, 1044037);
			index = AddCraft(typeof(BouclierRond2), 1011080, "Bouclier Rond", 25.0, 65.0, typeof(IronIngot), 1044036, 10, 1044037);
			index = AddCraft(typeof(Targe3), 1011080, "Targe renforcé", 25.0, 65.0, typeof(IronIngot), 1044036, 25, 1044037);
			index = AddCraft(typeof(Rondache), 1011080, "Rondache renforcée", 30.0, 70.0, typeof(IronIngot), 1044036, 12, 1044037);
			index = AddCraft(typeof(MetalKiteShield), 1011080, "Le blason", 30.0, 70.0, typeof(IronIngot), 1044036, 16, 1044037);
			index = AddCraft(typeof(BouclierRond), 1011080, "Bouclier Rond Renforcé", 30.0, 70.0, typeof(IronIngot), 1044036, 10, 1044037);
			index = AddCraft(typeof(ChaosShield), 1011080, "Targe décoré", 30.0, 70.0, typeof(IronIngot), 1044036, 25, 1044037);
			index = AddCraft(typeof(HeaterShield), 1011080, "Muraille", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			index = AddCraft(typeof(Pavois), 1011080, "Pavois", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			index = AddCraft(typeof(Targe), 1011080, "Targe Bicolore", 40.0, 80.0, typeof(IronIngot), 1044036, 25, 1044037);
			index = AddCraft(typeof(OrderShield), 1011080, "Égide", 40.0, 80.0, typeof(IronIngot), 1044036, 25, 1044037);
			index = AddCraft(typeof(EcuLong), 1011080, "Écu Long", 50.0, 90.0, typeof(IronIngot), 1044036, 16, 1044037);
			index = AddCraft(typeof(Pavois2), 1011080, "Pavois Décoratif", 50.0, 90.0, typeof(IronIngot), 1044036, 18, 1044037);
			index = AddCraft(typeof(Targe2), 1011080, "Rondache Colimaçon", 50.0, 90.0, typeof(IronIngot), 1044036, 25, 1044037);
			#endregion


			#region Armes de poings
			AddCraft(typeof(DoubleLames), 1011081, "Double Lames de poing", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(Sai), 1011081, "Sai", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Kama), 1011081, "Kama", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Tekagi), 1011081, "Griffes", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region Dagues
			AddCraft(typeof(Dagger), 1011081, "Dague", 00.0, 40.0, typeof(IronIngot), 1044036, 3, 1044037);
			AddCraft(typeof(ElvenSpellblade), 1011081, "Égorgeuse", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(AssassinSpike), 1011081, "Épineuse", 40.0, 80.0, typeof(IronIngot), 1044036, 9, 1044037);
			AddCraft(typeof(Leafblade), 1011081, "Coupe-gorge", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region Épées
			AddCraft(typeof(BoneHarvester), 1011081, "Serpe", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Broadsword), 1011081, "Épée courte", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Cutlass), 1011081, "Sabre Kroise", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Katana), 1011081, "Katana", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Longsword), 1011081, "Épée longue", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Scimitar), 1011081, "Cimeterre", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(VikingSword), 1011081, "Épée Kaloise", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeCourte), 1011081, "Épée Koraine", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(SabreLuxe), 1011081, "Sabre Kershe", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(EpeeBatardeLuxe), 1011081, "Épée bâtarde de luxe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeDoubleTranchant), 1011081, "Épée à Double Tranchants", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeLongue), 1011081, "Épée Longue", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeBatarde), 1011081, "Épée bâtarde", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(EpeeDeuxMains), 1011081, "Épée Deux Mains", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Runire), 1011081, "Runire", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(NoDachi), 1011081, "Éclat solaire", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Wakizashi), 1011081, "Surineur", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(RadiantScimitar), 1011081, "Cimeterre infini", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(RuneBlade), 1011081, "Lame vorpal", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(ElvenMachete), 1011081, "Machette runique", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleEpee), 1011081, "Double épée", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(WakizashiLong), 1011081, "Wakizashi Long", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Runire), 1011081, "Runire", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Daisho), 1011081, "Les jumelles", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);
			#endregion

			#region Haches
			AddCraft(typeof(Axe), 1011082, "Hache simple", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(BattleAxe), 1011082, "Hache de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleAxe), 1011082, "Hache double", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ExecutionersAxe), 1011082, "Hachette", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(LargeBattleAxe), 1011082, "Hache de bataille", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(TwoHandedAxe), 1011082, "Hache à deux mains", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(WarAxe), 1011082, "Tranchar", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(GrandeHache), 1011082, "Éventreuse", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(GrandeHacheDouble), 1011082, "Francisque", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(HacheDouble), 1011082, "Trombe", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(HAchePique), 1011082, "Barbelé", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(HacheDoublePiques), 1011082, "Exécutrice", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleAxe), 1011082, "Naga", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(HacheDoubleNaine), 1011082, "Gardienne", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(OrnateAxe), 1011082, "Hache ornée", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(DualShortAxes), 1011082, "Double hache courte", 40.0, 80.0, typeof(IronIngot), 1044036, 24, 1044037);
			AddCraft(typeof(DoubleHachette), 1011081, "Double Hachette", 40.0, 80.0, typeof(IronIngot), 1044036, 15, 1044037);

			//        index = AddCraft(typeof(BattleAxe), 1011082, "Battle Axe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			//    index = AddCraft(typeof(Axe), 1011082, "Axe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);

			#endregion

			#region Hallebarde
			AddCraft(typeof(Bardiche), 1011083, "Bardiche", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Hellebarde), 1011083, "Hellebarde", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(BladedStaff), 1011083, "BladedStaff", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(DoubleBladedStaff), 1011083, "DoubleBladedStaff", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Halberd), 1011083, "Halberd", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region Lancer
			AddCraft(typeof(Shuriken), 1079508, "Shuriken", 40.0, 80.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(Boomerang), 1079508, "Boomerang", 40.0, 80.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(Cyclone), 1079508, "Cyclone", 40.0, 80.0, typeof(IronIngot), 1044036, 9, 1044037);
			AddCraft(typeof(SoulGlaive), 1079508, "Étoile", 40.0, 80.0, typeof(IronIngot), 1044036, 9, 1044037);

			#region Lances
			AddCraft(typeof(Lance), 1011083, "Lance", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(Pike), 1011083, "Pique", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ShortSpear), 1011083, "Lance courte", 40.0, 80.0, typeof(IronIngot), 1044036, 6, 1044037);
			AddCraft(typeof(Scythe), 1011083, "Scythe", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Spear), 1011083, "Lance de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Epieu), 1011083, "Épieu", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GrandeFourche), 1011083, "Fourche", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(JavelotLuxe), 1011083, "Javelot de Luxe", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Trident), 1011083, "Trident", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(WarFork), 1011083, "Fourche de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region Masses et marteaux
			AddCraft(typeof(HammerPick), 1011084, "Marteau à pointes", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Mace), 1011084, "Masse", 40.0, 80.0, typeof(IronIngot), 1044036, 6, 1044037);
			AddCraft(typeof(Maul), 1011084, "Maul", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Scepter), 1011084, "Sceptre", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(WarMace), 1011084, "Masse de guerre", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(GrandeMasse), 1011084, "Grande Masse", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MarteauPointes), 1011084, "Étoile du matin", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Marteau), 1011084, "Marteau", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MassueClous), 1011084, "Massue à Clous", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MassuePointes), 1011084, "Massue à Pointes", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Massue), 1011084, "Massue", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MorgensternBoules), 1011084, "Morgenstern à Boules", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MorgensternPointes), 1011084, "Morgenstern à Pointes", 40.0, 80.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(WarHammer), 1011084, "War Hammer", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Tessen), 1011084, "Tessen", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			AddCraft(typeof(DiamondMace), 1011084, "Masse diamant", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(WarHammer), 1011084, "Dispenseur", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Maul), 1011084, "Ogrillonne", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Tessen), 1011084, "Caduçé", 40.0, 80.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			AddCraft(typeof(DiscMace), 1011084, "Massu cranelée", 40.0, 80.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region Rapières et Estoc
			AddCraft(typeof(Rapiere), 1011081, "Rapière", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RapiereLuxe), 1011081, "Rapière de Luxe", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RapiereDecoree), 1011081, "Rapière Décorée", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Astoria), 1011081, "Astoria", 40.0, 80.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Kryss), 1011081, "Kryss", 40.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(WarCleaver), 1011081, "Éclat lunaire", 40.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Lajatang), 1011081, "Croissants de lune", 80.0, 130.0, typeof(IronIngot), 1044036, 25, 1044037);
			#endregion

			#region Canons
			AddCraft(typeof(Cannonball), 1116354, "Boulet de Canon", 10.0, 60.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(Grapeshot), 1116354, "Boulet Avancé", 15.0, 70.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(Cloth), 1044286, 2, 1044287);
			AddCraft(typeof(LightShipCannonDeed), 1116354, "Canon Léger", 65.0, 120.0, typeof(IronIngot), 1044036, 500, 1044037);
			AddCraft(typeof(HeavyShipCannonDeed), 1116354, "Canon Lourd", 70.0, 120.0, typeof(IronIngot), 1044036, 800, 1044037);
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