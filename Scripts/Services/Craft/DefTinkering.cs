using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using System;
using Server.Services.BasketWeaving.Baskets;

namespace Server.Engines.Craft
{
	public enum TinkerRecipes
	{
		InvisibilityPotion = 400,
		DarkglowPotion = 401,
		ParasiticPotion = 402,

		EssenceOfBattle = 450,
		PendantOfTheMagi = 451,
		ResilientBracer = 452,
		ScrappersCompendium = 453,
		HoveringWisp = 454, // Removed at OSI Publish 103

		KotlPowerCore = 455,

		// doom
		BraceletOfPrimalConsumption = 456,
		DrSpectorLenses = 457,
		KotlAutomatonHead = 458,

		WeatheredBronzeArcherSculpture = 459,
		WeatheredBronzeFairySculpture = 460,
		WeatheredBronzeGlobeSculpture = 461,
		WeatheredBronzeManOnABench = 462,

		KrampusMinionEarrings = 463,
		EnchantedPicnicBasket = 464,

		Telescope = 465,

		BarbedWhip = 466,
		SpikedWhip = 467,
		BladedWhip = 468,
	}

	public class DefTinkering : CraftSystem
	{
		#region Mondain's Legacy
		public override CraftECA ECA => CraftECA.ChanceMinusSixtyToFourtyFive;
		#endregion

		public override SkillName MainSkill => SkillName.Tinkering;

		//   public override int GumpTitleNumber => 1044007;

		public override string GumpTitleString => "Bricolage";

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefTinkering();

				return m_CraftSystem;
			}
		}

		private DefTinkering()
			: base(1, 1, 1.25)// base( 1, 1, 3.0 )
		{
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			if (item.NameNumber == 1044258 || item.NameNumber == 1046445) // potion keg 
				return 0.5; // 50%

			return 0.0; // 0%
		}

		public override int CanCraft(Mobile from, ITool tool, Type itemType)
		{
			int num = 0;

			if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
				return 1044038; // You have worn out your tool!
			else if (!tool.CheckAccessible(from, ref num))
				return num; // The tool must be on your person to use.
			else if (itemType == typeof(ModifiedClockworkAssembly) && !(from is PlayerMobile && ((PlayerMobile)from).MechanicalLife))
				return 1113034; // You haven't read the Mechanical Life Manual. Talking to Sutek might help!

			return 0;
		}

		private static readonly Type[] m_TinkerColorables = new Type[]
		{
			typeof(ForkLeft), typeof(ForkRight),
			typeof(SpoonLeft), typeof(SpoonRight),
			typeof(KnifeLeft), typeof(KnifeRight),
			typeof(Plate),
			typeof(Goblet), typeof(PewterMug),
			typeof(KeyRing),
			typeof(Candelabra), typeof(Scales),
			typeof(Key), typeof(Globe),
			typeof(Spyglass), typeof(Lantern),
			typeof(HeatingStand), typeof(BroadcastCrystal), typeof(TerMurStyleCandelabra),
			typeof(GorgonLense), typeof(MedusaLightScales), typeof(MedusaDarkScales), typeof(RedScales),
			typeof(BlueScales), typeof(BlackScales), typeof(GreenScales), typeof(YellowScales), typeof(WhiteScales),
			typeof(PlantPigment), typeof(Kindling), typeof(DryReeds), typeof(PlantClippings),

			typeof(KotlAutomatonHead)
		};

		public override bool RetainsColorFrom(CraftItem item, Type type)
		{
			if (type == typeof(CrystalDust))
				return false;

			bool contains = false;
			type = item.ItemType;

			for (int i = 0; !contains && i < m_TinkerColorables.Length; ++i)
				contains = (m_TinkerColorables[i] == type);

			if (!contains && !type.IsSubclassOf(typeof(BaseIngot)))
				return false;

			return contains;
		}

		public override void PlayCraftEffect(Mobile from)
		{
			from.PlaySound(0x23B);
		}

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendMessage("Vous avez brisé votre outil."); ; // You have worn out your tool

			if (failed)
			{
				if (lostMaterial)
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if (quality == 0)
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if (makersMark && quality == 2)
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if (quality == 2)
					return 1044155; // You create an exceptional quality item.
				else
					return 1044154; // You create the item.
			}
		}

		public void AddJewelrySet(GemType gemType, Type itemType)
		{
			int offset = (int)gemType - 1;

			int index = index = AddCraft(typeof(GoldRing), "Bijoux", 1044176 + offset, 40.0, 90.0, typeof(GoldIngot), 1044036, 2, 1044037);
			AddRes(index, itemType, 1044231 + offset, 1, 1044240);
			index = index = AddCraft(typeof(SilverBeadNecklace), "Bijoux", 1044185 + offset, 40.0, 90.0, typeof(IronIngot), 1044036, 2, 1044037);
			AddRes(index, itemType, 1044231 + offset, 1, 1044240);
			index = index = AddCraft(typeof(GoldNecklace), "Bijoux", 1044194 + offset, 40.0, 90.0, typeof(GoldIngot), 1044036, 2, 1044037);
			AddRes(index, itemType, 1044231 + offset, 1, 1044240);
			index = index = AddCraft(typeof(GoldEarrings), "Bijoux", 1044203 + offset, 40.0, 90.0, typeof(GoldIngot), 1044036, 2, 1044037);
			AddRes(index, itemType, 1044231 + offset, 1, 1044240);
			index = index = AddCraft(typeof(GoldBeadNecklace), "Bijoux", 1044212 + offset, 40.0, 90.0, typeof(GoldIngot), 1044036, 2, 1044037);
			AddRes(index, itemType, 1044231 + offset, 1, 1044240);
			index = index = AddCraft(typeof(GoldBracelet), "Bijoux", 1044221 + offset, 40.0, 90.0, typeof(GoldIngot), 1044036, 2, 1044037);
			AddRes(index, itemType, 1044231 + offset, 1, 1044240);



		}

		public override void InitCraftList()
		{
			int index = -1;

			#region Outils
			index = AddCraft(typeof(Scissors), "Outils", "Ciseaux", 5.0, 55.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(SewingKit), "Outils", "Kit de couture", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(BoneSewingKit), "Outils", "Kit de couture (Os)", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Pitchfork), "Outils", "Fourche", 40.0, 90.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Hatchet), "Outils", "Hachette", 30.0, 80.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Shovel), "Outils", "Pelle", 40.0, 90.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Pickaxe), "Outils", "Pioche", 40.0, 90.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(TinkerTools), "Outils", "Trousse de Bricolage", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Tongs), "Outils", "Pince", 35.0, 85.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(SmithyHammer), "Outils", "Marteau de forgeron", 40.0, 90.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(SledgeHammerWeapon), "Outils", "Maillet de forgeron", 40.0, 90.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Saw), "Outils", "Scie", 30.0, 80.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Hammer), "Outils", "Marteau", 30.0, 80.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(DovetailSaw), "Outils", "Scie dentelée", 30.0, 80.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(JointingPlane), "Outils", "Rabot joint", 0.0, 50.0, typeof(Board), 1044041, 4, 1044351);
			index = AddCraft(typeof(MouldingPlane), "Outils", "Rabot moulage", 0.0, 50.0, typeof(Board), 1044041, 4, 1044351);
			index = AddCraft(typeof(SmoothingPlane), "Outils", "Rabot lissage", 0.0, 50.0, typeof(Board), 1044041, 4, 1044351);
			index = AddCraft(typeof(Scorp), "Outils", "Scorp", 30.0, 80.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(DrawKnife), "Outils", "Couteau à bois", 30.0, 80.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(RollingPin), "Outils", "Rouleau à pâte", 0.0, 50.0, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(Skillet), "Outils", "Poêlon", 30.0, 80.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(FlourSifter), "Outils", "Tamis à farine", 50.0, 100.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Froe), "Outils", "Froe", 30.0, 80.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(MortarPestle), "Outils", "Mortier et pilon", 20.0, 70.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(WaxCraftingPot), "Outils", "Fabrication Cire", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(FletcherTools), "Outils", "Outil facteur d'arc", 35.0, 85.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(MapmakersPen), "Outils", "Plume cartographe", 25.0, 75.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(ScribesPen), "Outils", "Plume scribe", 25.0, 75.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(Inshave), "Outils", "Outil facteur d'arc", 30.0, 80.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Lockpick), "Outils", "Crochets", 45.0, 95.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(Blowpipe), "Outils", "Pipe à Verre", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(MalletAndChisel), "Outils", "Maillet", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Pinceaux), "Outils", "Pinceaux", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(BarberScissors), "Outils", "Ciseaux de Barbier", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Ecraseur), "Outils", "Écraseur pour Coquillages", 10.0, 70.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(FoodPlate), "Outils", "Plat de Nourriture", 10.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(BeerBreweringTools), "Outils", "Outil fabrication de bière", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(BrewersTools), "Outils", "Outil Brasseur", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(BreweryLabelMaker), "Outils", "Marqueur de bière", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(FarmLabelMaker), "Outils", "Farm Label Maker", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(GrapevinePlacementTool), "Outils", "Outil placement de vignes", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(GrinderExp), "Outils", "Broyeur à café", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(JuicersTools), "Outils", "Fabrication de Jus", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(VinyardLabelMaker), "Outils", "Marqueur de vin", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(WinecraftersTools), "Outils", "Outil fabrication de vin", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(WitchsBookofFoodCrafts), "Outils", "Livre de recette enchantées", 30.0, 70.0, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(TaxidermyKit), "Outils", "Outil de Taxidermie", 80.0, 110.0, typeof(IronIngot), 1044036, 5, 1044037);
			#endregion

			#region Jewelry
			//   index = AddCraft(typeof(GoldRing), "Bijoux", "Anneau", 65.0, 100.0, typeof(GoldIngot), 1044036, 3, 1044037);
			//   index = AddCraft(typeof(GoldBracelet), "Bijoux", "Bracelet", 55.0, 100.0, typeof(GoldIngot), 1044036, 3, 1044037);
			//  index = AddCraft(typeof(Necklace), "Bijoux", "Collier à perles", 60.0, 100.0, typeof(IronIngot), 1044036, 3, 1044037);
			//            index = AddCraft(typeof(Bracelet), "Bijoux", "Bracelet simple", 55.0, 100.0, typeof(IronIngot), 1044036, 3, 1044037);
			//          index = AddCraft(typeof(Ring), "Bijoux", "Anneau simple", 65.0, 100.0, typeof(IronIngot), 1044036, 3, 1044037);
			//        index = AddCraft(typeof(Earrings), "Bijoux", "Boucles d'oreille", 55.0, 100.0, typeof(IronIngot), 1044036, 3, 1044037);

			AddJewelrySet(GemType.StarSapphire, typeof(StarSapphire));
			AddJewelrySet(GemType.Emerald, typeof(Emerald));
			AddJewelrySet(GemType.Sapphire, typeof(Sapphire));
			AddJewelrySet(GemType.Ruby, typeof(Ruby));
			AddJewelrySet(GemType.Citrine, typeof(Citrine));
			AddJewelrySet(GemType.Amethyst, typeof(Amethyst));
			AddJewelrySet(GemType.Tourmaline, typeof(Tourmaline));
			AddJewelrySet(GemType.Amber, typeof(Amber));
			AddJewelrySet(GemType.Diamond, typeof(Diamond));

			/*         index = index = AddCraft(typeof(KrampusMinionEarrings), "Bijoux", 1125645, 100.0, 500.0, typeof(IronIngot), 1044036, 3, 1044037);
					 AddRecipe(index, (int)TinkerRecipes.KrampusMinionEarrings);
			*/
			index = AddCraft(typeof(Collier), "Bijoux", "Collier massif doré", 49.2, 69.2, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier2), "Bijoux", "Collier croix Ânkh", 49.8, 69.8, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier3), "Bijoux", "Collier bolo doré", 74.6, 94.6, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier4), "Bijoux", "Grande chaîne dorée", 60.1, 80.1, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier5), "Bijoux", "Collier croix Ânkh doré", 63.4, 83.4, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier6), "Bijoux", "Petit collier Usekh", 81.2, 101.2, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier7), "Bijoux", "Petit collier doré", 90.2, 110.2, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier8), "Bijoux", "Collier de feuilles dorées", 68.8, 88.8, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier9), "Bijoux", "Collier de perle", 74.6, 94.6, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier10), "Bijoux", "Collier simple avec pendentif", 96.8, 116.8, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier11), "Bijoux", "Collier simple", 71.7, 91.7, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier12), "Bijoux", "Grand collier doré avec pendentif", 65.6, 85.6, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Couronne2), "Bijoux", "Petite couronne", 87.2, 107.2, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Couronne3), "Bijoux", "Diadème", 74.5, 94.5, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Couronne4), "Bijoux", "Grande couronne", 96.0, 116.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Lunettes), "Bijoux", "Lunette dorée", 86.9, 106.9, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Tiare), "Bijoux", "Tiare", 50.9, 70.9, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Ceinture10), "Bijoux", "Ceinture de feuilles dorées", 72.5, 92.5, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(DiademeFeuilleOr), "Bijoux", "Collier doré avec pendentif", 85.0, 105.5, typeof(GoldIngot), "lingots d'or", 3, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(EpauletteDoree), "Bijoux", "Grand collier Usekh", 85.0, 105.5, typeof(GoldIngot), "lingots d'or", 5, "Vous n'avez pas assez de lingots.");
			//index = AddCraft(typeof(MenotteDoree), "Bijoux", "Menotte dorée", 85.0, 105.5, typeof(GoldIngot), "lingots d'or", 3, "Vous n'avez pas assez de lingots.");
			#endregion

			#region Canons
			index = AddCraft(typeof(Ramrod), "Canons", "Baguette", 0.0, 50.0, typeof(Board), 1044041, 5, 1044253);
			index = AddCraft(typeof(FuseCord), "Canons", "Mèche", 0.0, 50.0, typeof(Cloth), 1044455, 1, 1044253);
			index = AddCraft(typeof(PowderCharge), "Canons", "Charge de poudre", 0.0, 50.0, typeof(Cloth), 1044455, 1, 1044253);
			AddRes(index, typeof(BlackPowder), 1095826, 1, 1044253);
			SetUseAllRes(index, true);
			index = AddCraft(typeof(Swab), "Canons", "Écouvillon", 0.0, 50.0, typeof(Cloth), 1044286, 1, 1044253);
			AddRes(index, typeof(Board), 1044041, 4, 1044253);
			#endregion

			#region Paniers et boîtes
			index = AddCraft(typeof(RoundBasket), "Paniers et boîtes", "Panier rond", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(RoundBasketHandles), "Paniers et boîtes", "Panier rond avec poignées", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(SmallBushel), "Paniers et boîtes", "Petit panier rond avec poignées", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(PicnicBasket2), "Paniers et boîtes", "Panier à pique-nique", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(WinnowingBasket), "Paniers et boîtes", "Panier à vanner", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(SquareBasket), "Paniers et boîtes", "Panier carré", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(BasketCraftable), "Paniers et boîtes", "Panier tressé", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(TallRoundBasket), "Paniers et boîtes", "Panier haut tressé", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 4, 1044351);
			index = AddCraft(typeof(SmallSquareBasket), "Paniers et boîtes", "Petit panier carré", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(TallBasket), "Paniers et boîtes", "Grand panier tressé", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 4, 1044351);
			index = AddCraft(typeof(SmallRoundBasket), "Paniers et boîtes", "Panier tressé rond", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxAngel), "Paniers et boîtes", "Boite Cadeau, Ange", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxCube), "Paniers et boîtes", "Boite Cadeau, Carré", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxCylinder), "Paniers et boîtes", "Boite Cadeau, Cylindre", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxOctogon), "Paniers et boîtes", "Boite Cadeau, Octogone", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxRectangle), "Paniers et boîtes", "Boite Cadeau, Rectangle", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(RedVelvetGiftBox), "Paniers et boîtes", "Boite Cadeau, Petite rouge", 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);

			/*        index = index = AddCraft(typeof(EnchantedPicnicBasket), 1044042, 1158333, 75.0, 100.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
					AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
					AddRecipe(index, (int)TinkerRecipes.EnchantedPicnicBasket);
					SetRequireResTarget(index);
					SetRequiresBasketWeaving(index);
			*/
			#endregion

			//	index = AddCraft(typeof(RollingPinExp), "Outils", "Rouleau à pâte avancé", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);
			//	index = AddCraft(typeof(SkilletExp), "Outils", "Poelon Avancé", 30.0, 70.0, typeof(IronIngot), 1044036, 2, 1044037);

			//TODO: focus of theurgy - 20th Anniversary Event 


			#region Appat
			index = index = AddCraft(typeof(BaitAutumnDragonfish), "Appats", "AutumnDragonfish", 10.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitBlueLobster), "Appats", "BlueLobster", 10.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitBullFish), "Appats", "BullFish", 10.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitCrystalFish), "Appats", "CrystalFish", 10.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitFairySalmon), "Appats", "FairySalmon", 10.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitFireFish), "Appats", "FireFish", 10.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitGiantKoi), "Appats", "GiantKoi", 20.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitGreatBarracuda), "Appats", "GreatBarracuda", 20.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitHolyMackerel), "Appats", "HolyMackerel", 20.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitLavaFish), "Appats", "LavaFish", 20.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 2, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitReaperFish), "Appats", "ReaperFish", 30.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 3, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitSpiderCrab), "Appats", "SpiderCrab", 30.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 3, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitStoneCrab), "Appats", "StoneCrab", 30.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 3, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitSummerDragonfish), "Appats", "SummerDragonfish", 30.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 3, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitUnicornFish), "Appats", "UnicornFish", 30.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 3, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitYellowtailBarracuda), "Appats", "YellowtailBarracuda", 30.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 3, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitAbyssalDragonfish), "Appats", "AbyssalDragonfish", 40.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 4, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitBlackMarlin), "Appats", "BlackMarlin", 40.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 4, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitBloodLobster), "Appats", "BloodLobster", 40.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 4, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitBlueMarlin), "Appats", "BlueMarlin", 40.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 4, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitDreadLobster), "Appats", "DreadLobster", 40.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 4, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitDungeonPike), "Appats", "DungeonPike", 50.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 5, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitGiantSamuraiFish), "Appats", "GiantSamuraiFish", 50.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 5, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitGoldenTuna), "Appats", "GoldenTuna", 50.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 5, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitKingfish), "Appats", "Kingfish", 50.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 5, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitLanternFish), "Appats", "LanternFish", 50.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 5, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitRainbowFish), "Appats", "RainbowFish", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitSeekerFish), "Appats", "SeekerFish", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitSpringDragonfish), "Appats", "SpringDragonfish", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitStoneFish), "Appats", "StoneFish", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitTunnelCrab), "Appats", "TunnelCrab", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitVoidCrab), "Appats", "VoidCrab", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitVoidLobster), "Appats", "VoidLobster", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitWinterDragonfish), "Appats", "WinterDragonfish", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			index = index = AddCraft(typeof(BaitZombieFish), "Appats", "ZombieFish", 60.0, 70.0, typeof(RawFishSteak), "Filet de Poisson Cru", 6, "Vous n'avez pas suffisament de poisson cru");
			#endregion

			#region Pièces d'assemblages
			index = AddCraft(typeof(Gears), "Pièces d'assemblages", "Engrenages", 5.0, 55.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(ClockFrame), "Pièces d'assemblages", "Cadre d'horloge", 0.0, 50.0, typeof(Board), 1044041, 6, 1044351);
			index = AddCraft(typeof(ClockParts), "Pièces d'assemblages", "Pièces d'horloge", 25.0, 75.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(BarrelTap), "Pièces d'assemblages", "Robinet de baril", 35.0, 85.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Springs), "Pièces d'assemblages", "Ressorts", 5.0, 55.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(SextantParts), "Pièces d'assemblages", "Pièce de sextant", 30.0, 80.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(BarrelHoops), "Pièces d'assemblages", "Anneaux de baril", -15.0, 35.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Hinge), "Pièces d'assemblages", "Charnière", 5.0, 55.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(BolaBall), "Pièces d'assemblages", "Balle de Bola", 45.0, 95.0, typeof(IronIngot), 1044036, 10, 1044037);
			index = AddCraft(typeof(Axle), "Pièces d'assemblages", "Essieu", -25.0, 25.0, typeof(Board), 1044041, 2, 1044351);
			index = AddCraft(typeof(JeweledFiligree), "Pièces d'assemblages", "Engrenages", 70.0, 110.0, typeof(IronIngot), 1044036, 2, 1044037);
			AddRes(index, typeof(StarSapphire), 1044231, 1, 1044253);
			AddRes(index, typeof(Ruby), 1044234, 1, 1044253);
			#endregion

			#region Assemblages
			index = AddCraft(typeof(AxleGears), "Assemblages", "Engrenage d'essieu", 0.0, 0.0, typeof(Axle), "Essieu", 1, 1044253);
			AddRes(index, typeof(Gears), 1044254, 1, 1044253);
			index = AddCraft(typeof(ClockParts), "Assemblages", "Pièces d'horloge", 0.0, 0.0, typeof(AxleGears), "Engrenage d'essieu", 1, 1044253);
			AddRes(index, typeof(Springs), "Ressorts", 1, 1044253);
			index = AddCraft(typeof(SextantParts), "Assemblages", "Pièces de sextant", 0.0, 0.0, typeof(AxleGears), "Engrenage d'essieu", 1, 1044253);
			AddRes(index, typeof(Hinge), "Charnière", 1, 1044253);
			index = AddCraft(typeof(ClockRight), "Assemblages", "Horloge (D)", 30.0, 60.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 1, 1044253);
			index = AddCraft(typeof(ClockLeft), "Assemblages", "Horloge (G)", 30.0, 60.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 1, 1044253);
			index = AddCraft(typeof(SmallGrandfatherClock), "Assemblages", "Petite Horloge Grand Père", 50.0, 90.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 2, 1044253);
			AddRes(index, typeof(Board), 1044041, 8, 1044351);
			index = AddCraft(typeof(LargeGrandfatherClock), "Assemblages", "Horloge Grand Père", 50.0, 90.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 2, 1044253);
			AddRes(index, typeof(Board), 1044041, 8, 1044351);
			index = AddCraft(typeof(WhiteGrandfatherClock), "Assemblages", "Horloge Grand Père Blanche", 50.0, 90.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 2, 1044253);
			AddRes(index, typeof(Board), 1044041, 8, 1044351);
			index = AddCraft(typeof(Sextant), "Assemblages", "Sextant", 0.0, 0.0, typeof(SextantParts), "Pièces de sextant", 1, 1044253);
			index = AddCraft(typeof(Bola), "Assemblages", "Bola", 60.0, 80.0, typeof(BolaBall), "Balle de bola", 4, 1042613);
			AddRes(index, typeof(Leather), 1044462, 3, 1044463);
			index = AddCraft(typeof(PotionKeg), "Assemblages", "Tonnelet de potion", 75.0, 100.0, typeof(Keg), "Tonnelet", 1, 1044253);
			AddRes(index, typeof(Bottle), 1044250, 10, 1044253);
			AddRes(index, typeof(BarrelLid), "Couvercle de baril", 1, 1044253);
			AddRes(index, typeof(BarrelTap), "Robinet de baril", 1, 1044253);
			index = AddCraft(typeof(HitchingRope), "Assemblages", "Corde d'attelage", 60.0, 120.0, typeof(Rope), "Corde", 1, 1044253);
			index = AddCraft(typeof(HitchingPost), "Assemblages", "Poteau d'attelage", 90.0, 160.0, typeof(IronIngot), 1044036, 50, 1044253);
			AddRes(index, typeof(HitchingRope), "Corde d'attelage", 2, 1044253);
			index = AddCraft(typeof(DistillerySouthAddonDeed), "Assemblages", "Distillerie (S)", 90.0, 100.0, typeof(MetalKeg), "Tonnelet de métal", 2, 1044253);
			AddRes(index, typeof(HeatingStand), "Support chauffant", 4, 1044253);
			AddRes(index, typeof(CopperWire), "Fil de cuivre", 1, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(DistilleryEastAddonDeed), "Assemblages", "Distillerie (E)", 90.0, 100.0, typeof(MetalKeg), "Tonnelet de métal", 2, 1044253);
			AddRes(index, typeof(HeatingStand), "Support chauffant", 4, 1044253);
			AddRes(index, typeof(CopperWire), "Fil de cuivre", 1, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(AdvancedTrainingDummySouthDeed), "Assemblages", "Mannequin d'entrainement avancé (S)", 90.0, 110.0, typeof(TrainingDummySouthDeed), 1044336, 1, 1044253);
			AddRes(index, typeof(PlateChest), 1025141, 1, 1044253);
			AddRes(index, typeof(CloseHelm), 1025128, 1, 1044253);
			AddRes(index, typeof(Broadsword), 1015055, 1, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(AdvancedTrainingDummyEastDeed), "Assemblages", "Mannequin d'entrainement avancé (E)", 90.0, 110.0, typeof(TrainingDummyEastDeed), 1044335, 1, 1044253);
			AddRes(index, typeof(PlateChest), 1025141, 1, 1044253);
			AddRes(index, typeof(CloseHelm), 1025128, 1, 1044253);
			AddRes(index, typeof(Broadsword), 1015055, 1, 1044253);
			ForceNonExceptional(index);


			/*          index = index = AddCraft(typeof(KotlAutomatonHead), 1044051, 1156998, 100.0, 580.0, typeof(IronIngot), 1044036, 300, 1044037);
		SetMinSkillOffset(index, 25.0);
		AddRes(index, typeof(AutomatonActuator), 1156997, 1, 1156999);
		AddRes(index, typeof(StasisChamberPowerCore), 1156623, 1, 1157000);
		AddRes(index, typeof(InoperativeAutomatonHead), 1157002, 1, 1157001);
		AddRecipe(index, (int)TinkerRecipes.KotlAutomatonHead);

		index = index = AddCraft(typeof(PersonalTelescope), 1044051, 1125284, 95.0, 196.0, typeof(IronIngot), 1044036, 25, 1044037);
		AddRes(index, typeof(WorkableGlass), 1154170, 1, 1154171);
		AddRes(index, typeof(SextantParts), 1044175, 1, 1044253);
		AddRecipe(index, (int)TinkerRecipes.Telescope);

		index = index = AddCraft(typeof(OracleOfTheSea), 1044051, 1150184, 100.0, 120, typeof(IronIngot), 1044036, 3, 1044037);
		AddRes(index, typeof(WorkableGlass), 1154170, 2, 1154171);
		AddRes(index, typeof(OceanSapphire), 1159162, 3, 1044253);
		SetItemHue(index, 1265);
		ForceNonExceptional(index);
		index = AddCraft(typeof(ArcanicRuneStone), 1044051, 1113352, 90.0, 140.0, typeof(CrystalShards), 1073161, 1, 1044253);
		AddRes(index, typeof(PowerCrystal), 1112811, 5, 502910);
		AddSkill(index, SkillName.Magery, 80.0, 85.0);
		ForceNonExceptional(index);

		index = index = AddCraft(typeof(VoidOrb), 1044051, 1113354, 90.0, 104.3, typeof(DarkSapphire), 1032690, 1, 1044253);
		AddSkill(index, SkillName.Magery, 80.0, 100.0);
		AddRes(index, typeof(BlackPearl), 1015001, 50, 1044253);
		ForceNonExceptional(index);
            index = index = AddCraft(typeof(ModifiedClockworkAssembly), 1044051, 1113031, 65.0, 115.0, typeof(ClockworkAssembly), 1073426, 1, 502910);
            AddRes(index, typeof(PowerCrystal), 1112811, 1, 502910);
            AddRes(index, typeof(VoidEssence), 1112327, 1, 502910);
            ForceNonExceptional(index);

            index = index = AddCraft(typeof(ModifiedClockworkAssembly), 1044051, 1113032, 65.0, 115.0, typeof(ClockworkAssembly), 1073426, 1, 502910);
            AddRes(index, typeof(PowerCrystal), 1112811, 1, 502910);
            AddRes(index, typeof(VoidEssence), 1112327, 2, 502910);
            ForceNonExceptional(index);

            index = index = AddCraft(typeof(ModifiedClockworkAssembly), 1044051, 1113033, 65.0, 115.0, typeof(ClockworkAssembly), 1073426, 1, 502910);
            AddRes(index, typeof(PowerCrystal), 1112811, 1, 502910);
            AddRes(index, typeof(VoidEssence), 1112327, 3, 502910);
            ForceNonExceptional(index);
			  */
			#endregion

			#region Ustensiles
			index = AddCraft(typeof(SpoonLeft), "Ustensiles", "Cuillière (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(SpoonRight), "Ustensiles", "Cuillière (D)", 0.0, 50.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(Plate), "Ustensiles", "Assiette", 0.0, 50.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(ForkLeft), "Ustensiles", "Fourchette (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(ForkRight), "Ustensiles", "Fourchette (D)", 0.0, 50.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(KnifeLeft), "Ustensiles", "Couteau (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(KnifeRight), "Ustensiles", "Couteau (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 1, 1044037);
			index = AddCraft(typeof(Goblet), "Ustensiles", "Gobelet", 10.0, 60.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(PewterMug), "Ustensiles", "Tasse", 10.0, 60.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Tray), "Ustensiles", "Plateau", 25.0, 75.0, typeof(Board), 1044041, 2, 1044351);
			index = AddCraft(typeof(Silverware), "Ustensiles", "Coutellerie", 25.0, 75.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(FoodPlate), "Ustensiles", "Assiette de Nourriture", 25.0, 75.0, typeof(IronIngot), 1044036, 3, 1044037);
			//index = AddCraft(typeof(Bock), "Ustensiles", "Bock de Bière", 25.0, 75.0, typeof(IronIngot), 1044036, 3, 1044037);
			//index = AddCraft(typeof(CoupeMain), "Ustensiles", "Une Coupe", 25.0, 75.0, typeof(IronIngot), 1044036, 3, 1044037);
			//index = AddCraft(typeof(PoissonMain), "Ustensiles", "Poisson", 25.0, 75.0, typeof(FishSteak), 1044036, 5, 1044037);
			//	index = AddCraft(typeof(CorneBoire), "Ustensiles", "Corne à boire", 25.0, 75.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Eventail), "Ustensiles", "Eventail", 25.0, 75.0, typeof(Board), 1044041, 2, 1044351);
			index = AddCraft(typeof(HagCauldron), "Ustensiles", "Chaudron", 50.0, 100.0, typeof(IronIngot), 1044036, 10, 1044253);
			#endregion
			#region Luminaires et décorations
			index = AddCraft(typeof(Torch), "Luminaires et décorations", "Torche", 0.0, 50.0, typeof(Board), 1044041, 2, 1044253);
			index = AddCraft(typeof(CandleLarge), "Luminaires et décorations", "Chandelier Simple", 45.0, 105.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Candelabra), "Luminaires et décorations", "Chandelier", 55.0, 105.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(CandelabraStand), "Luminaires et décorations", "Grand Chandelier", 65.0, 105.0, typeof(IronIngot), 1044036, 8, 1044037);
			index = AddCraft(typeof(WallSconce), "Luminaires et décorations", "Chandelle Murale", 35.0, 105.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(WallTorch), "Luminaires et décorations", "Torche murale", 35.0, 105.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lantern), "Luminaires et décorations", "Lanterne", 30.0, 80.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(HeatingStand), "Luminaires et décorations", "Support chauffant", 60.0, 110.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(ShojiLantern), "Luminaires et décorations", "Lanterne sophistiquée", 65.0, 115.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddRes(index, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(RewardBrazier), "Luminaires et décorations", "Brasero court", 25.0, 100.0, typeof(IronIngot), 1044036, 25, 1044253);
			index = AddCraft(typeof(Brazier), "Luminaires et décorations", "Brasero", 45.0, 100.0, typeof(IronIngot), 1044036, 25, 1044253);
			index = AddCraft(typeof(BrazierTall), "Luminaires et décorations", "Brasero Long", 65.0, 100.0, typeof(IronIngot), 1044036, 25, 1044253);
			index = AddCraft(typeof(DragonBrazier), "Luminaires et décorations", "Brasero Cage", 85.0, 100.0, typeof(IronIngot), 1044036, 25, 1044253);
			index = AddCraft(typeof(TerMurStyleCandelabra), "Luminaires et décorations", "Chandelier élégant", 55.0, 105.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(PaperLantern), "Luminaires et décorations", "Lanterne en papier", 65.0, 115.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddRes(index, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(RoundPaperLantern), "Luminaires et décorations", "Lanterne en papier ronde", 65.0, 115.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddRes(index, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(WindChimes), "Luminaires et décorations", "Carillons éoliens", 80.0, 130.0, typeof(IronIngot), 1044036, 15, 1044037);
			index = AddCraft(typeof(FancyWindChimes), "Luminaires et décorations", "Carillons", 80.0, 130.0, typeof(IronIngot), 1044036, 15, 1044037);
			index = AddCraft(typeof(MiniCherryTree1), "Luminaires et décorations", "Arbre en Pot", 65.0, 115.0, typeof(FertileDirt), "Terre", 10, "Vous n'avez pas suffisament de terre");
			index = AddCraft(typeof(Orchid1), "Luminaires et décorations", "Orchidée", 65.0, 115.0, typeof(FertileDirt), "Terre", 10, "Vous n'avez pas suffisament de terre");
			index = AddCraft(typeof(Orchid2), "Luminaires et décorations", "Orchidée", 65.0, 115.0, typeof(FertileDirt), "Terre", 10, "Vous n'avez pas suffisament de terre");
			//	index = AddCraft(typeof(BouquetFleurBlanche), "Luminaires et décorations", "Bouquet de Fleurs Blanches", 65.0, 115.0, typeof(FertileDirt), "Terre", 5, "Vous n'avez pas suffisament de terre");
			//	AddRes(index, typeof(WhiteRose2), "Rose Blanche", 5, "Besoin de Rose Blanche");
			//	index = AddCraft(typeof(BouquetFleurRouge), "Luminaires et décorations", "Bouquet de Fleurs Rouges", 65.0, 115.0, typeof(FertileDirt), "Terre", 5, "Vous n'avez pas suffisament de terre");
			//	AddRes(index, typeof(RedRose), "Rose Rouge", 5, "Besoin de Rose Rouge");
			//index = AddCraft(typeof(BouquetFleur), "Luminaires et décorations", "Bouquet de Fleurs Rouges", 65.0, 115.0, typeof(FertileDirt), "Terre", 5, "Vous n'avez pas suffisament de terre");
			//	AddRes(index, typeof(RedRose), "Rose Rouge", 5, "Besoin de Rose Rouge");
			//	AddRes(index, typeof(WhiteRose2), "Rose Blanche", 5, "Besoin de Rose Blanche");
			#region Divers
			index = AddCraft(typeof(KeyRing), "Divers", "Anneau à clés", 10.0, 60.0, typeof(IronIngot), 1044036, 2, 1044037);
			index = AddCraft(typeof(Key), "Divers", "Clé", 20.0, 70.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(DyeTub), "Divers", "Bac de Teinture", 35.0, 65.0, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(RecallRune), "Divers", "Rune Vierge", 35.0, 65.0, typeof(Board), 1044041, 1, 1044351);
			index = AddCraft(typeof(Scales), "Divers", "Balance", 60.0, 110.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Globe), "Divers", "Globe terrestre", 55.0, 105.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Spyglass), "Divers", "Longue vue", 60.0, 110.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Fouet4), "Divers", "Fouet 4 mètres", 50.0, 70.0, typeof(Leather), 1044462, 3, 1044463);
			index = AddCraft(typeof(Fouet6), "Divers", "Fouet 6 mètres", 65.0, 85.0, typeof(Leather), 1044462, 4, 1044463);
			index = AddCraft(typeof(Fouet8), "Divers", "Fouet 8 mètres", 85.0, 105.0, typeof(Leather), 1044462, 5, 1044463);
			index = AddCraft(typeof(ToileVierge), "Divers", "Toile Vierge", 30.0, 50.0, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(CopperWire), "Divers", "Fil de fer", 30.0, 60.0, typeof(IronIngot), "Lingot de fer", 2, 1044037);
			index = AddCraft(typeof(CopperWire), "Divers", "Fil de cuivre", 30.0, 60.0, typeof(CopperIngot), "Lingot de cuivre", 2, 1044037);
			index = AddCraft(typeof(SilverWire), "Divers", "Fil d'argent", 50.0, 90.0, typeof(IronIngot), "Lingot de fer", 2, 1044037);
			index = AddCraft(typeof(GoldWire), "Divers", "Fil d'or", 70.0, 110.0, typeof(GoldIngot), "Lingot d'or", 2, 1044037);
			index = AddCraft(typeof(MetalKeg), "Divers", "Tonnelet en métal", 85.0, 100.0, typeof(IronIngot), 1044036, 25, 1044253);
			index = AddCraft(typeof(Lunettes1), "Divers", "Lunettes", 50.0, 90.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lunettes2), "Divers", "Lunettes", 50.0, 90.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lunettes3), "Divers", "Lunettes", 50.0, 90.0, typeof(IronIngot), 1044036, 3, 1044037);

			/*         index = index = AddCraft(typeof(BroadcastCrystal), 1044050, 1153097, 80.0, 130.0, typeof(IronIngot), 1044036, 20, 1044037);
					 AddRes(index, typeof(Emerald), 1062601, 10, 1044240);
					 AddRes(index, typeof(Ruby), 1062603, 10, 1044240);
					 AddRes(index, typeof(CopperWire), 1026265, 1, 1150700);
			*/
			/*        index = index = AddCraft(typeof(GorgonLense), 1044050, 1112625, 90.0, 120.0, typeof(MedusaDarkScales), 1112626, 2, 1053097);
					AddRes(index, typeof(CrystalDust), 1112328, 3, 1044253);
					ForceNonExceptional(index);
					SetItemHue(index, 1266);

					index = index = AddCraft(typeof(ScaleCollar), 1044050, 1112480, 50.0, 100.0, typeof(RedScales), 1112626, 4, 1053097);
					AddRes(index, typeof(Scourge), 1032677, 1, 1044253);

					index = index = AddCraft(typeof(DragonLamp), 1044050, 1098404, 75.0, 125.0, typeof(IronIngot), 1044036, 8, 1044253);
					AddRes(index, typeof(Candelabra), 1011213, 1, 1154172);
					AddRes(index, typeof(WorkableGlass), 1154170, 1, 1154171);

					index = index = AddCraft(typeof(StainedGlassLamp), 1044050, 1098408, 75.0, 125.0, typeof(IronIngot), 1044036, 8, 1044253);
					AddRes(index, typeof(Candelabra), 1011213, 1, 1154172);
					AddRes(index, typeof(WorkableGlass), 1154170, 1, 1154171);

					index = index = AddCraft(typeof(TallDoubleLamp), 1044050, 1098414, 75.0, 125.0, typeof(IronIngot), 1044036, 8, 1044253);
					AddRes(index, typeof(Candelabra), 1011213, 1, 1154172);
					AddRes(index, typeof(WorkableGlass), 1154170, 1, 1154171);

					index = index = AddCraft(typeof(CraftableHouseItem), 1044050, 1155851, 40.0, 90.0, typeof(IronIngot), 1044036, 8, 1044253);
					SetData(index, CraftableItemType.CurledMetalSignHanger);
					SetDisplayID(index, 2971);

					index = index = AddCraft(typeof(CraftableHouseItem), 1044050, 1155852, 40.0, 90.0, typeof(IronIngot), 1044036, 8, 1044253);
					SetData(index, CraftableItemType.FlourishedMetalSignHanger);
					SetDisplayID(index, 2973);

					index = index = AddCraft(typeof(CraftableHouseItem), 1044050, 1155853, 40.0, 90.0, typeof(IronIngot), 1044036, 8, 1044253);
					SetData(index, CraftableItemType.InwardCurledMetalSignHanger);
					SetDisplayID(index, 2975);

					index = index = AddCraft(typeof(CraftableHouseItem), 1044050, 1155854, 40.0, 90.0, typeof(IronIngot), 1044036, 8, 1044253);
					SetData(index, CraftableItemType.EndCurledMetalSignHanger);
					SetDisplayID(index, 2977);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156080, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.LeftMetalDoor_S_In);
					SetDisplayID(index, 1653);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156081, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.RightMetalDoor_S_In);
					SetDisplayID(index, 1659);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156082, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.LeftMetalDoor_E_Out);
					SetDisplayID(index, 1660);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156083, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.RightMetalDoor_E_Out);
					SetDisplayID(index, 1663);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(WallSafeDeed), 1044050, 1155860, 0.0, 0.0, typeof(IronIngot), 1044036, 20, 1044253);
					ForceNonExceptional(index);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156352, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.LeftMetalDoor_E_In);
					SetDisplayID(index, 1660);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156353, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.RightMetalDoor_E_In);
					SetDisplayID(index, 1663);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156350, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.LeftMetalDoor_S_Out);
					SetDisplayID(index, 1653);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

					index = index = AddCraft(typeof(CraftableMetalHouseDoor), 1044050, 1156351, 85.0, 135.0, typeof(IronIngot), 1044036, 50, 1044253);
					SetData(index, DoorType.RightMetalDoor_S_Out);
					SetDisplayID(index, 1659);
					AddCreateItem(index, CraftableMetalHouseDoor.Create);

			 /*       index = index = AddCraft(typeof(KotlPowerCore), 1044050, 1124179, 85.0, 135.0, typeof(WorkableGlass), 1154170, 5, 1154171);
					AddRes(index, typeof(CopperWire), 1026265, 5, 1150700);
					AddRes(index, typeof(IronIngot), 1044036, 100, 1044253);
					AddRes(index, typeof(MoonstoneCrystalShard), 1124142, 5, 1156701);
					AddRecipe(index, (int)TinkerRecipes.KotlPowerCore);

					index = index = AddCraft(typeof(WeatheredBronzeGlobeSculptureDeed), 1044050, 1156881, 85.0, 135.0, typeof(BronzeIngot), 1038039, 200, 1044253);
					AddRecipe(index, (int)TinkerRecipes.WeatheredBronzeGlobeSculpture);

					index = index = AddCraft(typeof(WeatheredBronzeManOnABenchDeed), 1044050, 1156882, 85.0, 135.0, typeof(IronIngot), 1038039, 200, 1044253);
					AddRecipe(index, (int)TinkerRecipes.WeatheredBronzeManOnABench);

					index = index = AddCraft(typeof(WeatheredBronzeFairySculptureDeed), 1044050, 1156883, 85.0, 135.0, typeof(IronIngot), 1038039, 200, 1044253);
					AddRecipe(index, (int)TinkerRecipes.WeatheredBronzeFairySculpture);

					index = index = AddCraft(typeof(WeatheredBronzeArcherDeed), 1044050, 1156884, 85.0, 135.0, typeof(IronIngot), 1038039, 200, 1044253);
					AddRecipe(index, (int)TinkerRecipes.WeatheredBronzeArcherSculpture);

					index = index = AddCraft(typeof(BarbedWhip), 1044050, 1159281, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
					AddRes(index, typeof(Leather), 1044462, 10, 1044463);
					AddRecipe(index, (int)TinkerRecipes.BarbedWhip);

					index = index = AddCraft(typeof(SpikedWhip), 1044050, 1159282, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
					AddRes(index, typeof(Leather), 1044462, 10, 1044463);
					AddRecipe(index, (int)TinkerRecipes.SpikedWhip);

					index = index = AddCraft(typeof(BladedWhip), 1044050, 1159283, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
					AddRes(index, typeof(Leather), 1044462, 10, 1044463);
					AddRecipe(index, (int)TinkerRecipes.BladedWhip);
		*/
			#endregion

			#region Traps
			// Dart Trap
			index = index = AddCraft(typeof(DartTrapCraft), 1044052, 1024396, 30.0, 80.0, typeof(IronIngot), 1044036, 1, 1044037);
			AddRes(index, typeof(Bolt), 1044570, 1, 1044253);

			// Poison Trap
			index = index = AddCraft(typeof(PoisonTrapCraft), 1044052, 1044593, 30.0, 80.0, typeof(IronIngot), 1044036, 1, 1044037);
			AddRes(index, typeof(BasePoisonPotion), 1044571, 1, 1044253);

			// Explosion Trap
			index = index = AddCraft(typeof(ExplosionTrapCraft), 1044052, 1044597, 55.0, 105.0, typeof(IronIngot), 1044036, 1, 1044037);
			AddRes(index, typeof(BaseExplosionPotion), 1044569, 1, 1044253);
			#endregion

			/*      #region Magic Jewlery
				  index = index = AddCraft(typeof(BrilliantAmberBracelet), 1073107, 1073453, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Amber), 1062607, 20, 1044240);
				  AddRes(index, typeof(BrilliantAmber), 1032697, 10, 1044240);

				  index = index = AddCraft(typeof(FireRubyBracelet), 1073107, 1073454, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Ruby), 1062603, 20, 1044240);
				  AddRes(index, typeof(FireRuby), 1032695, 10, 1044240);

				  index = index = AddCraft(typeof(DarkSapphireBracelet), 1073107, 1073455, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Sapphire), 1062602, 20, 1044240);
				  AddRes(index, typeof(DarkSapphire), 1032690, 10, 1044240);

				  index = index = AddCraft(typeof(WhitePearlBracelet), 1073107, 1073456, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Tourmaline), 1062606, 20, 1044240);
				  AddRes(index, typeof(WhitePearl), 1032694, 10, 1044240);

				  index = index = AddCraft(typeof(EcruCitrineRing), 1073107, 1073457, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Citrine), 1062604, 20, 1044240);
				  AddRes(index, typeof(EcruCitrine), 1032693, 10, 1044240);

				  index = index = AddCraft(typeof(BlueDiamondRing), 1073107, 1073458, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Diamond), 1062608, 20, 1044240);
				  AddRes(index, typeof(BlueDiamond), 1032696, 10, 1044240);

				  index = index = AddCraft(typeof(PerfectEmeraldRing), 1073107, 1073459, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Emerald), 1062601, 20, 1044240);
				  AddRes(index, typeof(PerfectEmerald), 1032692, 10, 1044240);

				  index = index = AddCraft(typeof(TurqouiseRing), 1073107, 1073460, 75.0, 125.0, typeof(IronIngot), 1044036, 5, 1044037);
				  AddRes(index, typeof(Amethyst), 1062605, 20, 1044240);
				  AddRes(index, typeof(Turquoise), 1032691, 10, 1044240);

				  index = index = AddCraft(typeof(ResilientBracer), 1073107, 1072933, 100.0, 125.0, typeof(IronIngot), 1044036, 2, 1044037);
				  SetMinSkillOffset(index, 25.0);
				  AddRes(index, typeof(CapturedEssence), 1032686, 1, 1044253);
				  AddRes(index, typeof(BlueDiamond), 1032696, 10, 1044253);
				  AddRes(index, typeof(Diamond), 1062608, 50, 1044253);
				  AddRecipe(index, (int)TinkerRecipes.ResilientBracer);
				  ForceNonExceptional(index);

				  index = index = AddCraft(typeof(EssenceOfBattle), 1073107, 1072935, 100.0, 125.0, typeof(IronIngot), 1044036, 2, 1044037);
				  SetMinSkillOffset(index, 25.0);
				  AddRes(index, typeof(CapturedEssence), 1032686, 1, 1044253);
				  AddRes(index, typeof(FireRuby), 1032695, 10, 1044253);
				  AddRes(index, typeof(Ruby), 1062603, 50, 1044253);
				  AddRecipe(index, (int)TinkerRecipes.EssenceOfBattle);
				  ForceNonExceptional(index);


				  index = index = AddCraft(typeof(PendantOfTheMagi), 1073107, 1072937, 100.0, 125.0, typeof(IronIngot), 1044036, 2, 1044037);
				  SetMinSkillOffset(index, 25.0);
				  AddRes(index, typeof(EyeOfTheTravesty), 1032685, 1, 1044253);
				  AddRes(index, typeof(WhitePearl), 1032694, 5, 1044253);
				  AddRes(index, typeof(StarSapphire), 1062600, 50, 1044253);
				  AddRecipe(index, (int)TinkerRecipes.PendantOfTheMagi);
				  ForceNonExceptional(index);

				  index = index = AddCraft(typeof(DrSpectorsLenses), 1073107, 1156991, 100.0, 580.0, typeof(IronIngot), 1044036, 20, 1044037);
				  SetMinSkillOffset(index, 25.0);
				  AddRes(index, typeof(BlackrockMoonstone), 1156993, 1, 1156992);
				  AddRes(index, typeof(HatOfTheMagi), 1061597, 1, 1044253);
				  AddRecipe(index, (int)TinkerRecipes.DrSpectorLenses);
				  ForceNonExceptional(index);

				  index = index = AddCraft(typeof(BraceletOfPrimalConsumption), 1073107, 1157350, 100.0, 580.0, typeof(IronIngot), 1044036, 3, 1044037);
				  SetMinSkillOffset(index, 25.0);
				  AddRes(index, typeof(RingOfTheElements), 1061104, 1, 1044253);
				  AddRes(index, typeof(BloodOfTheDarkFather), 1157343, 5, 1044253);
				  AddRes(index, typeof(WhitePearl), 1032694, 4, 1044240);
				  AddRecipe(index, (int)TinkerRecipes.BraceletOfPrimalConsumption);
				  ForceNonExceptional(index);
				  #endregion
	  */
			// Set the overridable material
			SetSubRes(typeof(IronIngot), 1044022);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(IronIngot), 1044022, 00.0, 1044036, 1044269);
			AddSubRes(typeof(DullCopperIngot), 1044023, 65.0, 1044036, 1044269);
			AddSubRes(typeof(ShadowIronIngot), 1044024, 70.0, 1044036, 1044269);
			AddSubRes(typeof(CopperIngot), 1044025, 75.0, 1044036, 1044269);
			AddSubRes(typeof(BronzeIngot), 1044026, 80.0, 1044036, 1044269);
			AddSubRes(typeof(GoldIngot), 1044027, 85.0, 1044036, 1044269);
			AddSubRes(typeof(AgapiteIngot), 1044028, 90.0, 1044036, 1044269);
			AddSubRes(typeof(VeriteIngot), 1044029, 95.0, 1044036, 1044269);
			AddSubRes(typeof(ValoriteIngot), 1044030, 99.0, 1044036, 1044269);

			SetSubRes2(typeof(Board), 1072643);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes2(typeof(Board), 1072643, 0.0, 1044041, 1072653);
			AddSubRes2(typeof(OakBoard), 1072644, 65.0, 1044041, 1072653);
			AddSubRes2(typeof(AshBoard), 1072645, 75.0, 1044041, 1072653);
			AddSubRes2(typeof(YewBoard), 1072646, 85.0, 1044041, 1072653);
			AddSubRes2(typeof(HeartwoodBoard), 1072647, 95.0, 1044041, 1072653);
			AddSubRes2(typeof(BloodwoodBoard), 1072648, 95.0, 1044041, 1072653);
			AddSubRes2(typeof(FrostwoodBoard), 1072649, 95.0, 1044041, 1072653);

			MarkOption = true;
			Repair = true;
			CanEnhance = true;
			CanAlter = true;
		}
	}

	public abstract class TrapCraft : CustomCraft
	{
		private LockableContainer m_Container;

		public LockableContainer Container => m_Container;

		public abstract TrapType TrapType { get; }

		public TrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}

		private int Verify(LockableContainer container)
		{
			if (container == null || container.KeyValue == 0)
				return 1005638; // You can only trap lockable chests.
			if (From.Map != container.Map || !From.InRange(container.GetWorldLocation(), 2))
				return 500446; // That is too far away.
			if (!container.Movable)
				return 502944; // You cannot trap this item because it is locked down.
			if (!container.IsAccessibleTo(From))
				return 502946; // That belongs to someone else.
			if (container.Locked)
				return 502943; // You can only trap an unlocked object.
			if (container.TrapType != TrapType.None)
				return 502945; // You can only place one trap on an object at a time.

			return 0;
		}

		private bool Acquire(object target, out int message)
		{
			LockableContainer container = target as LockableContainer;

			message = Verify(container);

			if (message > 0)
			{
				return false;
			}
			else
			{
				m_Container = container;
				return true;
			}
		}

		public override void EndCraftAction()
		{
			From.SendLocalizedMessage(502921); // What would you like to set a trap on?
			From.Target = new ContainerTarget(this);
		}

		private class ContainerTarget : Target
		{
			private readonly TrapCraft m_TrapCraft;

			public ContainerTarget(TrapCraft trapCraft)
				: base(-1, false, TargetFlags.None)
			{
				m_TrapCraft = trapCraft;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				int message;

				if (m_TrapCraft.Acquire(targeted, out message))
					m_TrapCraft.CraftItem.CompleteCraft(m_TrapCraft.Quality, false, m_TrapCraft.From, m_TrapCraft.CraftSystem, m_TrapCraft.TypeRes, m_TrapCraft.Tool, m_TrapCraft);
				else
					Failure(message);
			}

			protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
			{
				if (cancelType == TargetCancelType.Canceled)
					Failure(0);
			}

			private void Failure(int message)
			{
				Mobile from = m_TrapCraft.From;
				ITool tool = m_TrapCraft.Tool;

				if (Siege.SiegeShard)
				{
					AOS.Damage(from, Utility.RandomMinMax(80, 120), 50, 50, 0, 0, 0);
					message = 502902; // You fail to set the trap, and inadvertantly hurt yourself in the process.
				}

				if (tool != null && !tool.Deleted && tool.UsesRemaining > 0)
					from.SendGump(new CraftGump(from, m_TrapCraft.CraftSystem, tool, message));
				else if (message > 0)
					from.SendLocalizedMessage(message);
			}
		}

		public override Item CompleteCraft(out int message)
		{
			message = Verify(Container);

			if (message == 0)
			{
				int trapLevel = (int)(From.Skills.Tinkering.Value / 10);

				Container.TrapType = TrapType;
				Container.TrapPower = trapLevel * 9;
				Container.TrapLevel = trapLevel;
				Container.TrapOnLockpick = true;

				message = 1005639; // Trap is disabled until you lock the chest.
			}

			return null;
		}
	}

	[CraftItemID(0x1BFC)]
	public class DartTrapCraft : TrapCraft
	{
		public override TrapType TrapType => TrapType.DartTrap;

		public DartTrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}
	}

	[CraftItemID(0x113E)]
	public class PoisonTrapCraft : TrapCraft
	{
		public override TrapType TrapType => TrapType.PoisonTrap;

		public PoisonTrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}
	}

	[CraftItemID(0x370C)]
	public class ExplosionTrapCraft : TrapCraft
	{
		public override TrapType TrapType => TrapType.ExplosionTrap;

		public ExplosionTrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}
	}
}
#endregion