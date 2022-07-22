using Server.Items;
using System;

namespace Server.Engines.Craft
{
	#region Recipes
	public enum CookRecipes
	{
		// magical
		RotWormStew = 500,
		GingerbreadCookie = 599,

		DarkChocolateNutcracker = 600,
		MilkChocolateNutcracker = 601,
		WhiteChocolateNutcracker = 602,

		ThreeTieredCake = 603,
		BlackrockStew = 604,
		Hamburger = 605,
		HotDog = 606,
		Sausage = 607,

		GrilledSerpentSteak = 608,
		BBQDinoRibs = 609,
		WakuChicken = 610
	}
	#endregion

	public class DefCooking : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Cooking;

		//    public override int GumpTitleNumber => 1044003;

		public override string GumpTitleString => "Cuisine";


		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefCooking();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA => CraftECA.ChanceMinusSixtyToFourtyFive;

		public override double GetChanceAtMin(CraftItem item)
		{
			if (item.ItemType == typeof(GrapesOfWrath) ||
				item.ItemType == typeof(EnchantedApple))
			{
				return .5;
			}

			return 0.0; // 0%
		}

		private DefCooking()
			: base(1, 1, 1.25)// base( 1, 1, 1.5 )
		{
		}

		public override int CanCraft(Mobile from, ITool tool, Type itemType)
		{
			int num = 0;

			if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
				return 1044038; // You have worn out your tool!
			else if (!tool.CheckAccessible(from, ref num))
				return num; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect(Mobile from)
		{
		}

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendLocalizedMessage(1044038); // You have worn out your tool

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

		public override void InitCraftList()
		{
			int index = -1;

			#region Ingr�dients secs
			index = AddCraft(typeof(SackFlour), "Ingr�dients secs", "Sac de farine", 0.0, 50.0, typeof(WheatSheaf), 1044489, 2, 1044490);
			SetNeedMill(index, true);
			#endregion
			#region Ingr�dients humides
			index = AddCraft(typeof(CocoaButter), "Ingr�dients humides", "Beurre de cacao", 0.0, 50.0, typeof(CocoaPulp), 1080530, 1, 1044253);
			SetItemHue(index, 0x457);
			SetNeedOven(index, true);
			index = AddCraft(typeof(CocoaLiquor), "Ingr�dients humides", "Liqueur de cacao", 0.0, 50.0, typeof(CocoaPulp), 1080530, 1, 1044253);
			AddRes(index, typeof(EmptyPewterBowl), 1025629, 1, 1044253);
			SetItemHue(index, 0x46A);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Batter), "Ingr�dients humides", "Batter", 20.0, 60.0, typeof(Dough), 1044469, 1, 1044253);
			AddRes(index, typeof(Eggs), "Oeufs", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Butter), "Ingr�dients humides", "Beurre", 20.0, 60.0, typeof(Cream), "Cream", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.Butter);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Cream), "Ingr�dients humides", "Cr�me", 20.0, 60.0, typeof(BaseBeverage), "Lait", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.Cream);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(CookingOil), "Ingr�dients humides", "Huile de cuisson", 25.0, 60.0, typeof(Peanut), "Peanut", 10, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.CookingOil);
			SetNeedHeat(index, true);
			#endregion
			#region Sauces
			index = AddCraft(typeof(TomatoSauce), "Sauces", "Sauce tomate", 20.0, 60.0, typeof(Tomato), "Tomate", 3, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.TomatoSauce);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(WasabiClumps), "Sauces", "Motte de wasabi", 40.0, 60.0, typeof(BaseBeverage), 1046458, 1, 1044253);
			AddRes(index, typeof(WoodenBowlOfPeas), 1025633, 3, 1044253);
			index = AddCraft(typeof(Vinegar), "Sauces", "Vinaigre", 40.0, 60.0, typeof(Apple), "apples", 5, 1044253);
			AddRes(index, typeof(BottleOfWine), "Vin", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.Vinegar);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BarbecueSauce), "Sauces", "Sauce BBQ", 40.0, 60.0, typeof(Tomato), "Tomato", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.BarbecueSauce);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(CheeseSauce), "Sauces", "Sauce au fromage", 40.0, 60.0, typeof(Butter), "Butter", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), "Lait", 1, 1044253);
			AddRes(index, typeof(CheeseWheel), "Meule de fromage", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.CheeseSauce);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(EnchiladaSauce), "Sauces", "Sauce Enchiladas", 40.0, 70.0, typeof(Tomato), "Tomato", 1, 1044253);
			AddRes(index, typeof(ChiliPepper), "Piment chili", 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.EnchiladaSauce);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Gravy), "Sauces", "Demi-glace", 40.0, 70.0, typeof(Dough), 1044469, 2, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.Gravy);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(HotSauce), "Sauces", "Sauce piquante", 40.0, 70.0, typeof(Tomato), "Tomato", 2, 1044253);
			AddRes(index, typeof(ChiliPepper), "Piment chili", 3, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.HotSauce);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(SoySauce), "Sauces", "Sauce soya", 40.0, 70.0, typeof(BagOfSoy), "Bag of Soy", 1, 1044253);
			AddRes(index, typeof(BagOfSugar), "Sac de sucre", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.SoySauce);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Teriyaki), "Sauces", "Teriyaki", 40.0, 70.0, typeof(SoySauce), "Soy Sauce", 1, 1044253);
			AddRes(index, typeof(BottleOfWine), "Bouteille de vin", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.Teriyaki);
			SetNeedHeat(index, true);
			#endregion
			
			#region Cerf
			index = AddCraft(typeof(VenisonSteak), "Viandes", "Steak de cerf", 25.0, 70.0, typeof(RawVenisonSteak), "Steak de cerf cru", 1, "You need more Raw Venison Steak");
			////AddRecipe(index, (int)CookRecipesExp.VenisonSteak);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(VenisonJerky), "Viandes", "Jerky de cerf", 25.0, 70.0, typeof(RawVenisonSlice), "Tranche de cerf crue", 1, "You need more Raw Venison Slice");
			////AddRecipe(index, (int)CookRecipesExp.VenisonJerky);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(VenisonRoast), "Viandes", "R�tis de cerf", 25.0, 70.0, typeof(RawVenisonRoast), "R�tis de cerf cru", 1, "You need more Raw Venison Roast");
			////AddRecipe(index, (int)CookRecipesExp.VenisonRoast);
			SetNeedHeat(index, true);
			#endregion

			#region Boeuf
			index = AddCraft(typeof(BeefPorterhouse), "Viandes", "Boeuf Porterhouse", 25.0, 80.0, typeof(RawBeefPorterhouse), "Boeuf Porterhouse cru", 1, "You need more Raw Beef Porterhouse");
			////AddRecipe(index, (int)CookRecipesExp.BeefPorterhouse);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefPrimeRib), "Viandes", "C�tes de boeuf de choix", 25.0, 80.0, typeof(RawBeefPrimeRib), "C�tes de boeuf de choix crues", 1, "You need more Raw Beef Prime Rib");
			////AddRecipe(index, (int)CookRecipesExp.BeefPrimeRib);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefRibeye), "Viandes", "Faux-filet de boeuf", 25.0, 80.0, typeof(RawBeefRibeye), "Faux-filet de boeuf cru", 1, "You need more Raw Beef Ribeye");
			////AddRecipe(index, (int)CookRecipesExp.BeefRibeye);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefRibs), "Viandes", "C�tes de boeuf", 25.0, 70.0, typeof(RawBeefRibs), "C�tes de boeuf crues", 1, "You need more Raw Beef Ribs");
			////AddRecipe(index, (int)CookRecipesExp.BeefRibs);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefRoast), "Viandes", "R�tis de boeuf", 25.0, 70.0, typeof(RawBeefRoast), "R�tis de boeuf cru", 1, "You need more Raw Beef Roast");
			////AddRecipe(index, (int)CookRecipesExp.BeefRoast);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefSirloin), "Viandes", "Surlonge de boeuf", 25.0, 70.0, typeof(RawBeefSirloin), "Surlonge de boeuf crue", 1, "You need more Raw Beef Sirloin");
			////AddRecipe(index, (int)CookRecipesExp.BeefSirloin);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefJerky), "Viandes", "Jerky de boeuf", 25.0, 60.0, typeof(RawBeefSlice), "Tranche de boeuf crue", 1, "You need more Raw Beef Slices");
			////AddRecipe(index, (int)CookRecipesExp.BeefJerky);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefTBone), "Viandes", "T-Bone de boeuf", 25.0, 70.0, typeof(RawBeefTBone), "T-Bone de boeuf cru", 1, "You need more Raw Beef T-Bone");
			////AddRecipe(index, (int)CookRecipesExp.BeefTBone);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BeefTenderloin), "Viandes", "Filet de boeuf", 25.0, 70.0, typeof(RawBeefTenderloin), "Filet de boeuf cru", 1, "You need more Raw Raw Beef Tenderloin");
			////AddRecipe(index, (int)CookRecipesExp.BeefTenderloin);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(GroundBeef), "Viandes", "Boeuf hach�", 25.0, 60.0, typeof(BeefHock), "Jarret de boeuf", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.GroundBeef);
			#endregion

			#region Ch�vre
			index = AddCraft(typeof(GoatSteak), "Viandes", "Steak de ch�vre", 25.0, 70.0, typeof(RawGoatSteak), "Steak de ch�vre cru", 1, "You need more Raw Goat Steak");
			////AddRecipe(index, (int)CookRecipesExp.GoatSteak);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(GoatRoast), "Viandes", "R�ti de ch�vre", 25.0, 70.0, typeof(RawGoatRoast), "R�ti de ch�vre cru", 1, "You need more Raw Goat Roast");
			////AddRecipe(index, (int)CookRecipesExp.GoatRoast);
			SetNeedHeat(index, true);
			#endregion

			#region Porc
			index = AddCraft(typeof(RawGroundPork), "Viandes", "Porc hach�", 25.0, 60.0, typeof(PorkHock), "Jarret de porc", 1, "You need more Pork Hock");
			////AddRecipe(index, (int)CookRecipesExp.RawGroundPork);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Bacon), "Viandes", "Bacon", 25.0, 70.0, typeof(RawBacon), "Bacon cru", 1, "You need more Raw Bacon");
			////AddRecipe(index, (int)CookRecipesExp.Bacon);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BaconSlab), "Viandes", "Tranche de bacon", 25.0, 70.0, typeof(RawBaconSlab), "Tranche de bacon cru", 1, "You need more Raw Bacon Slab");
			////AddRecipe(index, (int)CookRecipesExp.BaconSlab);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Ham), "Viandes", "Jambon", 25.0, 70.0, typeof(RawHam), "Jambon cru", 1, "You need more Raw Ham");
			////AddRecipe(index, (int)CookRecipesExp.Ham);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(HamSlices), "Viandes", "Tranche de jambon", 25.0, 70.0, typeof(RawHamSlices), "Tranche de jambon crue", 1, "You need more Raw Ham Slices");
			////AddRecipe(index, (int)CookRecipesExp.HamSlices);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(PigHead), "Viandes", "T�te de porc", 25.0, 70.0, typeof(RawPigHead), "T�te de porc cru", 1, "You need more Raw Pig Head");
			////AddRecipe(index, (int)CookRecipesExp.PigHead);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(PorkRoast), "Viandes", "C�telettes de porc", 25.0, 70.0, typeof(RawPorkRoast), "C�telettes de porc cru", 1, "You need more Raw Pork Roast");
			////AddRecipe(index, (int)CookRecipesExp.PorkRoast);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(PorkSpareRibs), "Viandes", "C�tes lev�es de porc", 25.0, 70.0, typeof(RawSpareRibs), "C�tes lev�es de porc cru", 1, "You need more Raw Spare Ribs");
			////AddRecipe(index, (int)CookRecipesExp.PorkSpareRibs);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Trotters), "Viandes", "Pattes de porc", 25.0, 70.0, typeof(RawTrotters), "Pattes de porc crues", 1, "You need more Raw Trotters");
			////AddRecipe(index, (int)CookRecipesExp.Trotters);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(Sausage), "Viandes", "Saucisse", 25.0, 70.0, typeof(RawPorkSlice), "Tranche de porc cru", 1, "You need more Raw Pork Slice");
			////AddRecipe(index, (int)CookRecipesExp.Sausage);
			SetNeedHeat(index, true);
			#endregion

			#region Mouton
			index = AddCraft(typeof(MuttonSteak), "Viandes", "Steak de mouton", 25.0, 70.0, typeof(RawMuttonSteak), "Steak de mouton cru", 1, "You need more Raw Mutton Steak");
			////AddRecipe(index, (int)CookRecipesExp.MuttonSteak);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(MuttonRoast), "Viandes", "R�ti de mouton", 25.0, 70.0, typeof(RawMuttonRoast), "R�ti de mouton cru", 1, "You need more Raw Mutton Roast");
			////AddRecipe(index, (int)CookRecipesExp.MuttonRoast);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(LambLeg), "Viandes", "Gigot de mouton", 25.0, 70.0, typeof(RawLambLeg), "Gigot de mouton cru", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.LambLeg);
			SetNeedHeat(index, true);
			SetUseAllRes(index, true);
			#endregion

			#region Poulet
			index = AddCraft(typeof(RoastChicken), "Viandes", "R�ti de poulet", 25.0, 70.0, typeof(RawChickenExp), "Poulet cru", 1, "You need more Raw Chicken");
			////AddRecipe(index, (int)CookRecipesExp.RoastChicken);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(ChickenLeg), "Viandes", "Cuisse de poulet", 25.0, 70.0, typeof(RawChickenLeg), "Cuisse de poulet cru", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.ChickenLeg);
			SetNeedHeat(index, true);
			SetUseAllRes(index, true);
			#endregion

			#region Dinde
			index = AddCraft(typeof(RoastTurkey), "Viandes", "R�ti de dinde", 25.0, 70.0, typeof(RawTurkey), "Dinde cru", 1, "You need more Raw Turkey");
			////AddRecipe(index, (int)CookRecipesExp.RoastTurkey);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(TurkeyLeg), "Viandes", "Cuisse de dinde", 25.0, 70.0, typeof(RawTurkeyLeg), "Cuisse de dinde cru", 1, "You need more Raw Turkey Leg");
			////AddRecipe(index, (int)CookRecipesExp.TurkeyLeg);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(TurkeyPlatter), "Viandes", "Assiette de dinde", 25.0, 70.0, typeof(RawTurkey), "Poulet cru", 1, "You need more Raw Turkey");
			AddRes(index, typeof(FoodPlate), "Plate", 1, "You need a plate!");
			////AddRecipe(index, (int)CookRecipesExp.TurkeyPlatter);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(SlicedTurkey), "Viandes", "Dinde tranch�e", 25.0, 70.0, typeof(TurkeyHock), "Jarret de dinde", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.SlicedTurkey);
			#endregion

			#region Canard
			index = AddCraft(typeof(RoastDuck), "Viandes", "R�ti de canard", 25.0, 70.0, typeof(RawChickenExp), "Poulet cru", 1, "You need more Raw Chicken");
			////AddRecipe(index, (int)CookRecipesExp.RoastDuck);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(DuckLeg), "Viandes", "Cuisse de canard", 25.0, 70.0, typeof(RawDuckLeg), "Cuisse de canard cru", 1, "You need more Raw Duck Legs");
			////AddRecipe(index, (int)CookRecipesExp.DuckLeg);
			SetNeedHeat(index, true);
			#endregion

			#region Volaille
			index = AddCraft(typeof(CookedBird), "Viandes", "Volaille cuite", 25.0, 70.0, typeof(RawBird), "Volaille cru", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.CookedBird);
			SetNeedHeat(index, true);
			SetUseAllRes(index, true);
			#endregion

			#region Viande g�n�rique
			index = AddCraft(typeof(Ribs), "Viandes", "C�tes lev�es", 25.0, 70.0, typeof(RawRibs), "C�tes lev�es crues", 1, 1044253);
			////AddRecipe(index, (int)CookRecipesExp.Ribs);
			SetNeedHeat(index, true);
			SetUseAllRes(index, true);
			index = AddCraft(typeof(CookedSteak), "Viandes", "Steak", 25.0, 70.0, typeof(RawSteakExp), "Steak cru", 1, "You need more Raw Steak");
			////AddRecipe(index, (int)CookRecipesExp.CookedSteak);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(FishSteak), "Viandes", "Poisson cuit", 25.0, 70.0, typeof(RawFishSteak), 1044476, 1, 1044253);
			SetNeedHeat(index, true);
			SetUseAllRes(index, true);
			ForceNonExceptional(index);
			#endregion
			#region Poissons
			index = AddCraft(typeof(HalibutFishSteak), "Poissons et fruits de mer", "Filet d�Halibut", 50.0, 70.0, typeof(RawHalibutSteak), "Filet d�Halibut cru", 1, "you need more Raw Halibut Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(FlukeFishSteak), "Poissons et fruits de mer", "Filet de Fluke", 50.0, 70.0, typeof(RawFlukeSteak), "Filet de Fluke cru", 1, "you need more Raw Fluke Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(MahiFishSteak), "Poissons et fruits de mer", "Filet de Mahi", 50.0, 70.0, typeof(RawMahiSteak), "Filet de Mahi cru", 1, "you need more Raw Mahi Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(SalmonFishSteak), "Poissons et fruits de mer", "Filet de Saumon", 50.0, 70.0, typeof(RawSalmonSteak), "Filet de Saumon cru", 1, "you need more Raw Salmon Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(RedSnapperFishSteak), "Poissons et fruits de mer", "Filet de Red Snapper", 50.0, 70.0, typeof(RawRedSnapperSteak), "Filet de Red Snapper cru", 1, "you need more Raw Red Snapper Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(ParrotFishSteak), "Poissons et fruits de mer", "Filet de Parrot", 50.0, 70.0, typeof(RawParrotFishSteak), "Filet de Parrot cru", 1, "you need more Raw Parrot Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(TroutFishSteak), "Poissons et fruits de mer", "Filet de Trout", 50.0, 70.0, typeof(RawTroutSteak), "Filet de Trout cru", 1, "you need more Raw Trout Fish Steaks");
			SetNeedHeat(index, true);
			index = AddCraft(typeof(CookedShrimp), "Poissons et fruits de mer", "Crevette cuite", 50.0, 70.0, typeof(RawShrimp), "Crevette crue", 1, "you need more Raw Shrimp");
			SetNeedHeat(index, true);
			#endregion
			#region Pr�parations repas
			index = AddCraft(typeof(Dough), "Pr�parations repas", "P�te", 20.0, 50.0, typeof(SackFlourOpen), 1044468, 1, 1151092);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			index = AddCraft(typeof(UnbakedQuiche), "Pr�parations repas", "Quiche crue", 20.0, 50.0, typeof(Dough), 1044469, 1, 1044253);
			AddRes(index, typeof(Eggs), 1044477, 1, 1044253);

			// TODO: This must also support chicken and lamb legs
			index = AddCraft(typeof(UnbakedMeatPie), "Pr�parations repas", "P�t� � la viande cru", 20.0, 50.0, typeof(Dough), 1044469, 1, 1044253);
			AddRes(index, typeof(RawRibs), 1044482, 1, 1044253);
			index = AddCraft(typeof(UncookedSausagePizza), "Pr�parations repas", "Pizza saucisse crue", 20.0, 50.0, typeof(Dough), 1044469, 1, 1044253);
			AddRes(index, typeof(Sausage), 1044483, 1, 1044253);
			index = AddCraft(typeof(UncookedCheesePizza), "Pr�parations repas", "Pizza fromage crue", 20.0, 50.0, typeof(Dough), 1044469, 1, 1044253);
			AddRes(index, typeof(CheeseWheel), 1044486, 1, 1044253);
			#endregion
			#region Pr�parations desserts
			index = AddCraft(typeof(SweetDough), "Pr�parations desserts", "P�te sucr�e", 40.0, 75.0, typeof(Dough), "P�te", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			index = AddCraft(typeof(CakeMix), "Pr�parations desserts", "M�lange � g�teau", 40.0, 75.0, typeof(SackFlourOpen), "Sac de farine ouvert", 1, 1151092);
			AddRes(index, typeof(SweetDough), "P�te sucr�e", 1, 1044253);
			index = AddCraft(typeof(CookieMix), , "M�lange � biscuit", 40.0, 75.0, typeof(JarHoney), "Miel", 1, 1044253);
			AddRes(index, typeof(SweetDough), "P�te sucr�e", 1, 1044253);
			index = AddCraft(typeof(SweetCocoaButter), "Pr�parations desserts", "Beurre de cacao sucr�", 40.0, 75.0, typeof(SackOfSugar), "Sac de sucre", 1, 1044253);
			AddRes(index, typeof(CocoaButter), "Beurre de cacao", 1, 1044253);
			SetItemHue(index, 0x457);
			SetNeedOven(index, true);
			index = AddCraft(typeof(UnbakedFruitPie), "Pr�parations desserts", "Tarte aux fruits crue", 40.0, 75.0, typeof(Dough), "P�te", 1, 1044253);
			AddRes(index, typeof(Pear), "Poire", 1, 1044253);
			index = AddCraft(typeof(UnbakedPeachCobbler), "Pr�parations desserts", "Tarte aux p�ches crue", 40.0, 75.0, typeof(Dough), "P�te", 1, 1044253);
			AddRes(index, typeof(Peach), "P�che", 1, 1044253);
			index = AddCraft(typeof(UnbakedApplePie), "Pr�parations desserts", "Tarte aux pommes crue", 40.0, 75.0, typeof(Dough), "P�te", 1, 1044253);
			AddRes(index, typeof(Apple), "Pomme", 1, 1044253);
			index = AddCraft(typeof(UnbakedPumpkinPie), "Pr�parations desserts", "Tarte � la citrouille crue", 40.0, 75.0, typeof(Dough), "P�te", 1, 1044253);
			AddRes(index, typeof(Pumpkin), "Citrouille", 1, 1044253);
			#endregion
			#region Aliments bouillis
			index = AddCraft(typeof(ChickenNoodleSoup), "Aliments bouillis", "Soupe poulet et nouille", 30.0, 65.0, typeof(RoastChicken), 1153506, 1, 1044253);
			AddRes(index, typeof(PastaNoodles), "Pasta Noodles", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);

			SetNeedCauldron(index, true);
			index = AddCraft(typeof(TomatoRice), "Aliments bouillis", "Riz aux tomates", 30.0, 65.0, typeof(Tomato), "Tomato", 3, 1044253);
			AddRes(index, typeof(BowlRice), "Bol de riz", 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);

			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlOfStew), "Aliments bouillis", "Rago�t de boeuf", 30.0, 65.0, typeof(GroundBeef), "Ground Beef", 1, 1044253);
			AddRes(index, typeof(Gravy), "Gravy", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "Bol de l�gumes cuits", 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);

			SetNeedCauldron(index, true);
			index = AddCraft(typeof(TomatoSoup), "Aliments bouillis", "Soupe aux tomates", 30.0, 65.0, typeof(Tomato), "Tomato", 5, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbs", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);

			SetNeedCauldron(index, true);


			index = AddCraft(typeof(BowlBeets), "Aliments bouillis", "Bol de betterave", 30.0, 65.0, typeof(Beet), "Beet", 4, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlBeets);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlBroccoli), "Aliments bouillis", "Bol de brocolis", 30.0, 65.0, typeof(Broccoli), "Broccoli", 4, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlBroccoli);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlCauliflower), "Aliments bouillis", "Bol de chou-fleur", 30.0, 65.0, typeof(Cauliflower), "Cauliflower", 4, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlCauliflower);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlGreenBeans), "Aliments bouillis", "Bol de pois verts", 30.0, 65.0, typeof(GreenBean), "Green Beans", 20, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			AddRes(index, typeof(Bacon), "Bacon", 3, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlGreenBeans);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlRice), "Aliments bouillis", "Bol de riz", 30.0, 65.0, typeof(BagOfRicemeal), "Bag of Rice", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlRice);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlSpinach), "Aliments bouillis", "Bol d��pinard", 30.0, 65.0, typeof(Spinach), "Spinach", 8, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			AddRes(index, typeof(Vinegar), "Vinegar", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlSpinach);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlTurnips), "Aliments bouillis", "Bol de radis", 30.0, 65.0, typeof(Turnip), "Turnip", 4, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlTurnips);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlMashedPotatos), "Aliments bouillis", "Bol de patates pil�es", 30.0, 65.0, typeof(Potato), "Potato", 5, 1044253);
			AddRes(index, typeof(Butter), "Butter", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), "Milk", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlMashedPotatos);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(BowlCookedVeggies), "Aliments bouillis", "Bol de l�gume cuits", 30.0, 65.0, typeof(MixedVegetables), "Mixed Vegetables", 1, 1044253);
			AddRes(index, typeof(SoySauce), "Soy Sauce", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlCookedVeggies);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(WoodenBowlCabbage), "Aliments bouillis", "Bol de choux", 30.0, 65.0, typeof(Cabbage), "Cabbage", 2, 1044253);
			AddRes(index, typeof(Vinegar), "Vinegar", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.WoodenBowlCabbage);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(WoodenBowlCarrot), "Aliments bouillis", "Bol de carottes", 30.0, 65.0, typeof(Carrot), "Carrot", 12, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.WoodenBowlCarrot);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(WoodenBowlCorn), "Aliments bouillis", "Bol de ma�s", 30.0, 65.0, typeof(Corn), "Corn", 3, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.WoodenBowlCorn);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(WoodenBowlLettuce), "Aliments bouillis", "Bol de laitue", 30.0, 65.0, typeof(Lettuce), "Lettuce", 2, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.WoodenBowlLettuce);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(WoodenBowlPea), "Aliments bouillis", "Bol de pois", 30.0, 65.0, typeof(Peas), "Peas", 20, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.WoodenBowlPea);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(PewterBowlOfPotatos), "Aliments bouillis", "Bol de patate", 30.0, 65.0, typeof(Potato), "Potato", 5, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.PewterBowlOfPotatos);
			SetNeedCauldron(index, true);
			index = AddCraft(typeof(CornOnCob), "Aliments bouillis", "�pis de ma�s", 30.0, 65.0, typeof(Corn), "Corn", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.CornOnCob);
			SetNeedCauldron(index, true);
			#endregion
			#region Pl�ts pr�par�s
			index = AddCraft(typeof(Quiche), "Pl�ts pr�par�s", "Quiche", 60.0, 90.0, typeof(UnbakedQuiche), 1044518, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(MeatPie), "Pl�ts pr�par�s", "P�t� � la viande", 60.0, 90.0, typeof(UnbakedMeatPie), 1044519, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(SausagePizza), "Pl�ts pr�par�s", "Pizza saucisse", 50.0, 80.0, typeof(UncookedSausagePizza), 1044520, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(CheesePizza), "Pl�ts pr�par�s", "Pizza fromage", 50.0, 80.0, typeof(UncookedCheesePizza), 1044521, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Hotwings), "Pl�ts pr�par�s", "Ailes de poulet", 50.0, 80.0, typeof(RawChickenLeg), "Cuisse de poulet cru", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			AddRes(index, typeof(HotSauce), "Sauce piquante", 1, 1044253);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(PotatoFries), "Pl�ts pr�par�s", "Patate frite", 50.0, 80.0, typeof(Potato), "Potato", 3, 1044253);
			AddRes(index, typeof(Onion), "Oignon", 1, 1044253);
			AddRes(index, typeof(Butter), "Beurre", 1, 1044253);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(FriedEggs), "Pl�ts pr�par�s", "Oeuf frit", 50.0, 80.0, typeof(Eggs), 1044477, 1, 1044253);
			SetNeedHeat(index, true);
			SetUseAllRes(index, true);
			ForceNonExceptional(index);
			index = AddCraft(typeof(Hamburger), "Pl�ts pr�par�s", "Hamburger", 50.0, 80.0, typeof(BreadLoaf), 1024155, 1, 1044253);
			AddRes(index, typeof(RawRibs), "C�tes crues", 1, 1044253);
			AddRes(index, typeof(Lettuce), "Laitue", 1, 1044253);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(HotDog), "Pl�ts pr�par�s", "Hotdog", 50.0, 80.0, typeof(BreadLoaf), 1024155, 1, 1044253);
			AddRes(index, typeof(Sausage), "Saucisse", 1, 1044253);
			SetNeedHeat(index, true);
			index = AddCraft(typeof(BroccoliCheese), "Pl�ts pr�par�s", "Brocoli fromage", 50.0, 80.0, typeof(Broccoli), "Brocoli", 5, 1044253);
			AddRes(index, typeof(CheeseSauce), "Sauce au fromage", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(BroccoliCaulCheese), "Pl�ts pr�par�s", "�pis de ma�s", 50.0, 80.0, typeof(Broccoli), "Brocoli", 5, 1044253);
			AddRes(index, typeof(Cauliflower), "Chou-fleur", 2, 1044253);
			AddRes(index, typeof(CheeseSauce), "Sauce au fromage", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(CauliflowerCheese), "Pl�ts pr�par�s", "Chou-fleur fromage", 50.0, 80.0, typeof(Cauliflower), "Chou-fleur", 5, 1044253);
			AddRes(index, typeof(CheeseSauce), "Sauce au fromage", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Meatballs), "Pl�ts pr�par�s", "Boulettes de viande", 50.0, 80.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(BreadLoaf), "Pain", 1, 1044253);
			AddRes(index, typeof(Eggs), "Oeuf", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Meatloaf), "Pl�ts pr�par�s", "Pain de viande", 60.0, 90.0, typeof(GroundBeef), "Boeuf hach�", 2, 1044253);
			AddRes(index, typeof(Eggs), "Oeuf", 2, 1044253);
			AddRes(index, typeof(Onion), "Oignon", 2, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(ShepherdsPie), "Pl�ts pr�par�s", "P�t� kuya", 60.0, 90.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(BowlMashedPotatos), "Bol de patate pil�e", 1, 1044253);
			AddRes(index, typeof(Corn), "Ma�s", 2, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.ShepherdsPie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(TurkeyPie), "Pl�ts pr�par�s", "P�t� � la dinde", 60.0, 90.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(SlicedTurkey), "Tranche de dinde", 2, 1044253);
			AddRes(index, typeof(MixedVegetables), "M�lange de l�gume", 1, 1044253);
			AddRes(index, typeof(Gravy), "Demi-glace", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.TurkeyPie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(ChickenPie), "Pl�ts pr�par�s", "P�t� au poulet", 60.0, 90.0, typeof(RawChickenExp), "Poulet cru", 1, 1044253);
			AddRes(index, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(MixedVegetables), "M�lange de l�gumes", 1, 1044253);
			AddRes(index, typeof(Gravy), "Demi-glace", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.ChickenPie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(BeefPie), "Pl�ts pr�par�s", "P�t� au boeuf", 60.0, 90.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(MixedVegetables), "M�lange de l�gumes", 1, 1044253);
			AddRes(index, typeof(Gravy), "Demi-glace", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BeefPie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(ChickenParmesian), "Pl�ts pr�par�s", "Poulet parmigiana", 80.0, 99.0, typeof(RawBird), "Volaille crue", 1, 1044253);
			AddRes(index, typeof(TomatoSauce), "Sauce tomate", 1, 1044253);
			AddRes(index, typeof(CheeseWheel), "Meule de fromage", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(CheeseEnchilada), "Pl�ts pr�par�s", "Enchilada au fromage", 80.0, 99.0, typeof(CheeseWheel), "Meule de fromage", 1, 1044253);
			AddRes(index, typeof(Tortilla), "Tortilla", 1, 1044253);
			AddRes(index, typeof(EnchiladaSauce), "Sauce enchilada", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(ChickenEnchilada), "Pl�ts pr�par�s", "Enchilada au poulet", 80.0, 99.0, typeof(RawBird), "Volaille crue", 1, 1044253);
			AddRes(index, typeof(Tortilla), "Tortilla", 1, 1044253);
			AddRes(index, typeof(EnchiladaSauce), "Sauce enchilada", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(Lasagna), "Pl�ts pr�par�s", "Lasagne", 80.0, 99.0, typeof(PastaNoodles), "P�tes alimentaire", 3, 1044253);
			AddRes(index, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(CheeseWheel), "Meule de fromage", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(LemonChicken), "Pl�ts pr�par�s", "Poulet au citron", 80.0, 99.0, typeof(RawBird), "Volaille crue", 1, 1044253);
			AddRes(index, typeof(Lemon), "Citron", 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(OrangeChicken), "Pl�ts pr�par�s", "Poulet � l�orange", 80.0, 99.0, typeof(RawBird), "Volaille crue", 1, 1044253);
			AddRes(index, typeof(Orange), "Orange", 1, 1044253);
			AddRes(index, typeof(BasketOfHerbsFarm), "Herbes", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(VealParmesian), "Pl�ts pr�par�s", "Veau parmigiana", 80.0, 99.0, typeof(RawLambLeg), "Cuisse d�agneau crue", 2, 1044253);
			AddRes(index, typeof(TomatoSauce), "Sauce tomate", 1, 1044253);
			AddRes(index, typeof(CheeseWheel), "Meule de fromage", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(BeefBBQRibs), "Pl�ts pr�par�s", "C�tes lev�es BBQ", 80.0, 99.0, typeof(RawRibs), "C�t�s lev�es crues", 1, 1044253);
			AddRes(index, typeof(BarbecueSauce), "Sauce BBQ", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(BeefBroccoli), "Pl�ts pr�par�s", "Boeuf au brocoli", 80.0, 99.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(Broccoli), "Brocoli", 4, 1044253);
			AddRes(index, typeof(SoySauce), "Sauce soya", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(ChoChoBeef), "Pl�ts pr�par�s", "Boeuf Cho Cho", 80.0, 99.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(Teriyaki), "Sauce Teriyaki", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(BeefSnowpeas), "Pl�ts pr�par�s", "Boeuf et pois mange-tout", 80.0, 99.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(SnowPeas), "Pois mange-tout", 4, 1044253);
			AddRes(index, typeof(SoySauce), "Sauce soya", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(BeefLoMein), "Pl�ts pr�par�s", "Boeuf Lo Mein", 80.0, 99.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "M�lange de l�gumes cuits", 1, 1044253);
			AddRes(index, typeof(PastaNoodles), "P�tes alimentaire", 2, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(BeefStirfry), "Pl�ts pr�par�s", "Saut� de boeuf", 80.0, 99.0, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "M�lange de l�gume cuits", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(ChickenStirfry), "Pl�ts pr�par�s", "Saut� de poulet", 80.0, 99.0, typeof(RawBird), "Volaille cru", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "M�lange de l�gumes cuits", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(MooShuPork), "Pl�ts pr�par�s", "Porc Moo Shu", 80.0, 99.0, typeof(GroundPork), "Pors hach�", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "M�lange de l�gumes cuits", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(MoPoTofu), "Pl�ts pr�par�s", "Tofu Mo Po", 80.0, 99.0, typeof(Tofu), "Tofu", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "M�lange de l�gumes cuits", 1, 1044253);
			AddRes(index, typeof(ChiliPepper), "Piment chili", 3, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(PorkStirfry), "Pl�ts pr�par�s", "Saut� de porc", 80.0, 99.0, typeof(GroundPork), "Porc hach�", 1, 1044253);
			AddRes(index, typeof(BowlCookedVeggies), "M�lange de l�gumes cuits", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(SweetSourChicken), "Pl�ts pr�par�s", "Poulet aigre-doux", 80.0, 99.0, typeof(RawBird), "Volaille crue", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			AddRes(index, typeof(SoySauce), "Sauce soya", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(SweetSourPork), "Pl�ts pr�par�s", "Porc aigre-doux", 80.0, 99.0, typeof(GroundPork), "Porc hach�", 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			AddRes(index, typeof(SoySauce), "Sauce soya", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(BaconAndEgg), "Pl�ts pr�par�s", "Oeuf bacon", 80.0, 99.0, typeof(Eggs), "Oeuf", 2, 1044253);
			AddRes(index, typeof(RawBacon), "Bacon cru", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(Spaghetti), "Pl�ts pr�par�s", "Spaghetti", 80.0, 99.0, typeof(PastaNoodles), "P�te alimentaire", 3, 1044253);
			AddRes(index, typeof(TomatoSauce), "Sauce tomate", 1, 1044253);
			AddRes(index, typeof(GroundBeef), "Boeuf hach�", 1, 1044253);
			AddRes(index, typeof(FoodPlate), "Assiette", 1, "You need a plate!");
			SetNeedOven(index, true);
			index = AddCraft(typeof(MacaroniCheese), "Pl�ts pr�par�s", "Macaroni au fromage", 80.0, 99.0, typeof(PastaNoodles), "P�te alimentaire", 3, 1044253);
			AddRes(index, typeof(CheeseSauce), "Sauce au fromage", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(SushiRolls), "Pl�ts pr�par�s", "Sushi", 80.0, 99.0, typeof(BaseBeverage), 1046458, 1, 1044253);
			AddRes(index, typeof(RawFishSteak), "Poisson cru", 10, 1044253);
			index = AddCraft(typeof(SushiPlatter), "Pl�ts pr�par�s", "Plateau de sushi", 80.0, 99.0, typeof(BaseBeverage), 1046458, 1, 1044253);
			index = AddCraft(typeof(MisoSoup), "Pl�ts pr�par�s", "Soupe Miso", 80.0, 99.0, typeof(RawFishSteak), "Poisson cru", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(WhiteMisoSoup), "Pl�ts pr�par�s", "Soupe Miso blanche", 80.0, 99.0, typeof(RawFishSteak), "Poisson cru", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(RedMisoSoup), "Pl�ts pr�par�s", "Soupe Miso rouge", 80.0, 99.0, typeof(RawFishSteak), "Poisson cru", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(AwaseMisoSoup), "Pl�ts pr�par�s", "Soupe Miso combin�e", 80.0, 99.0, typeof(RawFishSteak), "Poisson cru", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			SetNeedOven(index, true);
			AddRes(index, typeof(RawFishSteak), "Poisson cru", 10, 1044253);
			#endregion
			#region P�tisseries et boulangerie
			index = AddCraft(typeof(BreadLoaf), "P�tisserie et boulangerie", "Miche de pain", 70.0, 90.0, typeof(Dough), "P�te", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(BowlOatmeal), "P�tisserie et boulangerie", "Bol de gruau", 70.0, 90.0, typeof(BagOfOats), "Sac d�avoine", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BowlOatmeal);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Popcorn), "P�tisserie et boulangerie", "Pop Corn", 70.0, 90.0, typeof(Corn), "Ma�s", 2, 1044253);
			AddRes(index, typeof(CookingOil), "Huile de cuisson", 1, 1044253);
			AddRes(index, typeof(Butter), "Beurre", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.Popcorn);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Cookies), "P�tisserie et boulangerie", "Biscuit", 80.0, 99.0, typeof(CookieMix), "M�lange � biscuit", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Cake), "P�tisserie et boulangerie", "G�teau", 80.0, 99.0, typeof(CakeMix), "M�lange � g�teau", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Muffins), "P�tisserie et boulangerie", "Muffins", 80.0, 99.0, typeof(SweetDough), "P�te sucr�e", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(FruitPie), "P�tisserie et boulangerie", "Tarte aux fruits", 80.0, 99.0, typeof(UnbakedFruitPie), "Tarte aux fruits crue", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(PeachCobbler), "P�tisserie et boulangerie", "Tarte aux p�ches", 80.0, 99.0, typeof(UnbakedPeachCobbler), "Tarte aux p�ches crue", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(ApplePie), "P�tisserie et boulangerie", "Tarte aux pommes", 80.0, 99.0, typeof(UnbakedApplePie), "Tarte aux pommes crue", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(PumpkinPie), "P�tisserie et boulangerie", "Tarte � la citrouille", 80.0, 99.0, typeof(UnbakedPumpkinPie), "Tarte � la citrouille crue", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(BlueberryPie), "P�tisserie et boulangerie", "Tarte aux bleuets", 80.0, 99.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(Blueberry), "Blueberry", 8, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BlueberryPie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(CherryPie), "P�tisserie et boulangerie", "Tarte aux cerises", 80.0, 99.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(Cherry), "Cherry", 8, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.CherryPie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(KeyLimePie), "P�tisserie et boulangerie", "Tarte � la lime", 80.0, 99.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(Lime), "Lime", 12, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.KeyLimePie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(LemonMerenguePie), "P�tisserie et boulangerie", "Tarte meringue aux citrons", 80.0, 99.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(Lemon), "Lemon", 12, 1044253);
			AddRes(index, typeof(Cream), "Cr�me", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.LemonMerenguePie);
			SetNeedOven(index, true);
			index = AddCraft(typeof(BlackberryCobbler), "P�tisserie et boulangerie", "Tarte aux baies", 80.0, 99.0, typeof(PieMix), "M�lange � tarte", 1, 1044253);
			AddRes(index, typeof(Blackberry), "Baies", 10, 1044253);
			AddRes(index, typeof(JarHoney), "Miel", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.BlackberryCobbler);
			SetNeedOven(index, true);

			index = AddCraft(typeof(GingerBreadCookie), "P�tisserie et boulangerie", "Biscuit en pain d��pice", 80.0, 99.0, typeof(CookieMix), "M�lange � biscuit", 1, 1044253);
			AddRes(index, typeof(FreshGinger), "Gingembre frais", 1, 1044253);
			SetNeedOven(index, true);
			index = AddCraft(typeof(Brownies), "P�tisserie et boulangerie", "Brownies", 80.0, 99.0, typeof(ChocolateMix), "Chocolat", 1, 1044253);
			AddRes(index, typeof(Eggs), "Oeuf", 2, 1044253);
			AddRes(index, typeof(CookingOil), "Huile de cuisson", 1, 1044253);
			//AddRecipe(index, (int)CookRecipesExp.Brownies);
			SetNeedOven(index, true);
			index = AddCraft(typeof(DarkChocolate), "P�tisserie et boulangerie", "Chocolat noir", 80.0, 99.0, typeof(SackOfSugar), "Sac de sucre", 1, 1044253);
			AddRes(index, typeof(CocoaButter), "Beurre de cacao", 1, 1044253);
			AddRes(index, typeof(CocoaLiquor), "Liqueur de cacao", 1, 1044253);
			SetItemHue(index, 0x465);
			index = AddCraft(typeof(MilkChocolate), "P�tisserie et boulangerie", "Chocolat au lait", 80.0, 99.0, typeof(SackOfSugar), "Sac de sucre", 1, 1044253);
			AddRes(index, typeof(CocoaButter), "Beurre de cacao", 1, 1044253);
			AddRes(index, typeof(CocoaLiquor), "Liqueur de cacao", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1022544, 1, 1044253);
			SetBeverageType(index, BeverageType.Milk);
			SetItemHue(index, 0x461);
			index = AddCraft(typeof(WhiteChocolate), "P�tisserie et boulangerie", "Chocolat blanc", 80.0, 99.0, typeof(SackOfSugar), "Sac de sucre", 1, 1044253);
			AddRes(index, typeof(CocoaButter), "Beurre de cacao", 1, 1044253);
			AddRes(index, typeof(Vanilla), "Vanille", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1022544, 1, 1044253);
			SetBeverageType(index, BeverageType.Milk);
			SetItemHue(index, 0x47E);
			#endregion 
			#region Teinture
			index = AddCraft(typeof(TribalPaint), "Teinture", "Peinture tribale", 80.0, 99.0, typeof(SackFlourOpen), "Sac de farine", 1, 1151092);
			AddRes(index, typeof(TribalBerry), "Baies tribales", 1, 1044253);
			index = AddCraft(typeof(EggBomb), "Teinture", "Bombe � oeuf", 80.0, 99.0, typeof(Eggs), "Oeufs", 1, 1044253);
			index = AddCraft(typeof(ColorFixative), "Teinture", "Fixateur de couleur", 75.0, 100.0, typeof(BaseBeverage), 1022503, 1, 1044253);
			AddRes(index, typeof(SilverSerpentVenom), "Venin de serpent argent�", 1, 1044253);
			SetBeverageType(index, BeverageType.Wine);
			AddRes(index, typeof(SackFlourOpen), "Sac de farine", 3, 1151092);
			index = AddCraft(typeof(PlantPigment), "Teinture", "Pigment de plante", 80.0, 99.0, typeof(PlantClippings), "Plante coup�e", 1, 1044253);
			AddRes(index, typeof(Bottle), "Bouteille", 1, 1044253);
			SetRequireResTarget(index);
			index = AddCraft(typeof(NaturalDye), "Teinture", "Teinture naturelle", 65.0, 115.0, typeof(PlantPigment), "Pigment de plante", 1, 1044253);
			AddRes(index, typeof(ColorFixative), "Fixateur de couleur", 1, 1044253);
			SetRequireResTarget(index);
			index = AddCraft(typeof(WoodPulp), "Teinture", "Pulpe de bois", 60.0, 100.0, typeof(BarkFragment), "Morceau d��corce", 1, 1044253);
			AddRes(index, typeof(BaseBeverage), 1046458, 1, 1044253);
			index = AddCraft(typeof(Charcoal), "Teinture", "Charbon", 0.0, 50.0, typeof(Board), "Planche", 1, 1044351);
			SetUseAllRes(index, true);
			SetNeedHeat(index, true);
			#endregion
			

		}
	}
}






