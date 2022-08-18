using Server.Items;

using System;
using System.Linq;

namespace Server.Engines.Craft
{
	#region Mondain's Legacy
	public enum CarpRecipes
	{
		// stuff
		WarriorStatueSouth = 100,
		WarriorStatueEast = 101,
		SquirrelStatueSouth = 102,
		SquirrelStatueEast = 103,
		AcidProofRope = 104,
		OrnateElvenChair = 105,
		ArcaneBookshelfSouth = 106,
		ArcaneBookshelfEast = 107,
		OrnateElvenChestSouth = 108,
		ElvenDresserSouth = 109,
		ElvenDresserEast = 110,
		FancyElvenArmoire = 111,
		ArcanistsWildStaff = 112,
		AncientWildStaff = 113,
		ThornedWildStaff = 114,
		HardenedWildStaff = 115,
		TallElvenBedSouth = 116,
		TallElvenBedEast = 117,
		StoneAnvilSouth = 118,
		StoneAnvilEast = 119,
		OrnateElvenChestEast = 120,

		// arties
		PhantomStaff = 150,
		IronwoodCrown = 151,
		BrambleCoat = 152,

		SmallElegantAquarium = 153,
		WallMountedAquarium = 154,
		LargeElegantAquarium = 155,

		KotlBlackRod = 170,
		KotlAutomaton = 171,
	}
	#endregion

	public class DefCarpentry : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Carpentry;

		//    public override int GumpTitleNumber => 1044004;

		public override string GumpTitleString => "Menuiserie";


		public override CraftECA ECA => CraftECA.ChanceMinusSixtyToFourtyFive;

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefCarpentry();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.5; // 50%
		}

		private DefCarpentry()
			: base(1, 1, 1.25)// base( 1, 1, 3.0 )
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

		private readonly Type[] _RetainsColor = new[]
		{
			typeof(BasePlayerBB)
		};

		public override bool RetainsColorFrom(CraftItem item, Type type)
		{
			var itemType = item.ItemType;

			if (_RetainsColor.Any(t => t == itemType || itemType.IsSubclassOf(t)))
			{
				return true;
			}

			return base.RetainsColorFrom(item, type);
		}

		public override void PlayCraftEffect(Mobile from)
		{
			from.PlaySound(0x23D);
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

			// Divers
			index = AddCraft(typeof(BacVide), "Divers", "Bac Vide", 00.0, 25.0, typeof(Board), 1044041, 3, 1044351);
			index = AddCraft(typeof(BarrelStaves), "Divers", "Douves de baril", 00.0, 25.0, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(BarrelLid), "Divers", "Couvercle de baril", 11.0, 36.0, typeof(Board), 1044041, 4, 1044351);
			index = AddCraft(typeof(Keg), "Divers", "Tonnelet", 57.8, 82.8, typeof(BarrelStaves), "Douves de baril", 3, 1044253);
			AddRes(index, typeof(BarrelHoops), "Cerceaux de baril", 1, 1044253);
			AddRes(index, typeof(BarrelLid), "Couvercle de baril", 1, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(LiquorBarrel), "Divers", "Baril d'alcool", 60.0, 90.0, typeof(Board), 1044041, 50, 1044351);
			index = AddCraft(typeof(Watertub), "Divers", "Baril d'eau", 86.8, 111.8, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(ShortMusicStandLeft), "Divers", "Petit lutrin (G)", 78.9, 103.9, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(ShortMusicStandRight), "Divers", "Petit lutrin (D)", 78.9, 103.9, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(TallMusicStandLeft), "Divers", "Grand lutrin (G)", 81.5, 106.5, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(TallMusicStandRight), "Divers", "Grand lutrin (D)", 81.5, 106.5, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(ElvenPodium), "Divers", "Lutrin simple", 80.0, 105.0, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(EasleSouth), "Divers", "Chevalet (S)", 86.8, 111.8, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(EasleEast), "Divers", "Chevalet (E)", 86.8, 111.8, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(EasleNorth), "Divers", "Chevalet (N)", 86.8, 111.8, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(PlayerBBEast), "Divers", "Tableau d'affichage (E)", 85.0, 110.0, typeof(Board), 1044041, 50, 1044351);
			index = AddCraft(typeof(PlayerBBSouth), "Divers", "Tableau d'affichage (S)", 85.0, 110.0, typeof(Board), 1044041, 50, 1044351);
			index = AddCraft(typeof(TrainingDummyEastDeed), "Divers", "Mannequin d'entrainement (E)", 68.4, 93.4, typeof(Board), 1044041, 55, 1044351);
			AddSkill(index, SkillName.Tailoring, 50.0, 55.0);
			AddRes(index, typeof(Cloth), 1044286, 60, 1044287);
			index = AddCraft(typeof(TrainingDummySouthDeed), "Divers", "Mannequin d'entrainement (S)", 68.4, 93.4, typeof(Board), 1044041, 55, 1044351);
			AddSkill(index, SkillName.Tailoring, 50.0, 55.0);
			AddRes(index, typeof(Cloth), 1044286, 60, 1044287);
			index = AddCraft(typeof(PickpocketDipEastDeed), "Divers", "Mannequin de vol à la tir (E)", 73.6, 98.6, typeof(Board), 1044041, 65, 1044351);
			AddSkill(index, SkillName.Tailoring, 50.0, 55.0);
			AddRes(index, typeof(Cloth), 1044286, 60, 1044287);
			index = AddCraft(typeof(PickpocketDipSouthDeed), "Divers", "Mannequin de vol à la tir (S)", 73.6, 98.6, typeof(Board), 1044041, 65, 1044351);
			AddSkill(index, SkillName.Tailoring, 50.0, 55.0);
			AddRes(index, typeof(Cloth), 1044286, 60, 1044287);
			index = AddCraft(typeof(FishingPole), "Divers", "Canne à pêche", 68.4, 93.4, typeof(Board), 1044041, 5, 1044351); //This is in the categor of Other during AoS
			AddSkill(index, SkillName.Tailoring, 40.0, 45.0);
			AddRes(index, typeof(Cloth), 1044286, 5, 1044287);
			index = AddCraft(typeof(PipeCourbee), "Divers", "Pipe Courbée", 46.6, 66.6, typeof(Board), "Planches", 4, "Vous n'avez pas assez de planche.");
			index = AddCraft(typeof(PipeCourte), "Divers", "Pipe Courte ", 80.5, 100.5, typeof(Board), "Planches", 4, "Vous n'avez pas assez de planche.");
			index = AddCraft(typeof(PipeLongue), "Divers", "Pipe Longue", 70.5, 90.5, typeof(Board), "Planches", 6, "Vous n'avez pas assez de planche.");
			index = AddCraft(typeof(MatchLight), "Divers", "Allumettes", 0.0, 30.0, typeof(Kindling), "Petit Bois", 2, "Vous n'avez pas assez de petit bois.");
			index = AddCraft(typeof(Lutrin), "Divers", "Un Lutrin", 70.5, 90.5, typeof(Board), "Planches", 15, "Vous n'avez pas assez de planche.");

			// Armes et bouclier
			index = AddCraft(typeof(ShepherdsCrook), "Armes et bouclier", "Bâton de berger", 78.9, 103.9, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(QuarterStaff), "Armes et bouclier", "Bâton", 73.6, 98.6, typeof(Board), 1044041, 6, 1044351);
			index = AddCraft(typeof(GnarledStaff), "Armes et bouclier", "Bâton noueux", 78.9, 103.9, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Bokuto), "Armes et bouclier", "Bokuto", 70.0, 95.0, typeof(Board), 1044041, 6, 1044351);
			index = AddCraft(typeof(Fukiya), "Armes et bouclier", "Bâton de frappe", 60.0, 85.0, typeof(Board), 1044041, 6, 1044351);
			index = AddCraft(typeof(Tetsubo), "Armes et bouclier", "Longue massue", 80.0, 105.0, typeof(Board), 1044041, 10, 1044351);
			index = AddCraft(typeof(WildStaff), "Armes et bouclier", "Bâton sauvage", 63.8, 113.8, typeof(Board), 1044041, 16, 1044351);
			index = AddCraft(typeof(SerpentStoneStaff), "Armes et bouclier", "Bâton de pierre serpent", 63.8, 113.8, typeof(Board), 1044041, 16, 1044351);
			AddRes(index, typeof(EcruCitrine), 1026252, 1, 1053098);
			index = AddCraft(typeof(Club), "Armes et bouclier", "Massue", 65.0, 90.0, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(BlackStaff), "Armes et bouclier", "Bâton noir", 81.5, 106.5, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(BatonNature), "Armes et bouclier", "Bâton de la Nature", 81.5, 106.5, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(BatonDragonique), "Armes et bouclier", "Bâton Dragonique", 81.5, 106.5, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(BatonErmite), "Armes et bouclier", "Bâton de l'Ermite", 78.9, 103.9, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Eterfer), "Armes et bouclier", "Eterfer", 73.6, 98.6, typeof(Board), 1044041, 6, 1044351);
			index = AddCraft(typeof(CanneSapphire), "Armes et bouclier", "Canne Sapphire", 73.6, 98.6, typeof(Board), 1044041, 6, 1044351);
			index = AddCraft(typeof(Crochire), "Armes et bouclier", "Crochire", 78.9, 103.9, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(BatonVagabond), "Armes et bouclier", "Bâton de vagabond", 78.9, 103.9, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(WoodenShield), "Autres", "Bouclier en bois", 52.6, 77.6, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(Parchemin), "Autres", "Un parchemin", 52.6, 77.6, typeof(Board), 1044041, 2, 1044351);

			// Instruments
			index = AddCraft(typeof(LapHarp), "Instruments", "Petite harpe", 63.1, 88.1, typeof(Board), 1044041, 20, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			index = AddCraft(typeof(RuneLute), "Instruments", "Luth fin", 55.0, 70.0, typeof(Board), 1044041, 6, 1044351);
			AddRes(index, typeof(Cloth), "Cloth", 6, "You do not have enough cloth to make that.");
			index = AddCraft(typeof(Harp), "Instruments", "Harpe", 78.9, 103.9, typeof(Board), 1044041, 35, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Cloth), 1044286, 15, 1044287);
			index = AddCraft(typeof(Drums), "Instruments", "Tambour", 57.8, 82.8, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(Guitare), "Instruments", "Guitare", 57.8, 82.8, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(HarpeLongue), "Instruments", "Une harpe Longue", 57.8, 82.8, typeof(Board), 1044041, 20, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			index = AddCraft(typeof(Lute), "Instruments", "Luth", 68.4, 93.4, typeof(Board), 1044041, 25, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			index = AddCraft(typeof(Tambourine), "Instruments", "Tambourine", 57.8, 82.8, typeof(Board), 1044041, 15, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			index = AddCraft(typeof(TambourineTassel), "Instruments", "Tambourine décorée", 57.8, 82.8, typeof(Board), 1044041, 15, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Cloth), 1044286, 15, 1044287);
			index = AddCraft(typeof(BambooFlute), "Instruments", "Flûte de bambou", 80.0, 105.0, typeof(Board), 1044041, 15, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			index = AddCraft(typeof(AudChar), "Instruments", "Aude-Char", 78.9, 103.9, typeof(Board), 1044041, 35, 1044351);
			// AddSkill(index, SkillName.Musicianship, 45.0, 50.0);
			AddRes(index, typeof(Granite), 1044514, 3, 1044513);

			// Caisses et coffres
			index = AddCraft(typeof(WoodenBox), "Caisses et coffres", "Boîte en bois", 21.0, 46.0, typeof(Board), 1044041, 10, 1044351);
			index = AddCraft(typeof(SmallCrate), "Caisses et coffres", "Petite caisse", 10.0, 35.0, typeof(Board), 1044041, 8, 1044351);
			index = AddCraft(typeof(MediumCrate), "Caisses et coffres", "Moyenne caisse", 31.0, 56.0, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(LargeCrate), "Caisses et coffres", "Grande caisse", 47.3, 72.3, typeof(Board), 1044041, 18, 1044351);
			index = AddCraft(typeof(WoodenChest), "Caisses et coffres", "Coffre en bois", 73.6, 98.6, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(PlainWoodenChest), "Caisses et coffres", "Grand coffre simple", 90.0, 115.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(OrnateWoodenChest), "Caisses et coffres", "Grand coffre orné", 90.0, 115.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(GildedWoodenChest), "Caisses et coffres", "Grand coffre renforcé", 90.0, 115.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(WoodenFootLocker), "Caisses et coffres", "Coffre à chaussures", 90.0, 115.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(FinishedWoodenChest), "Caisses et coffres", "Grand coffre", 90.0, 115.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(MaritimeChest), "Caisses et coffres", "Cargo Maritime", 80.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(BarrildeVin), "Caisses et coffres", "Barril de Vin", 80.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(OrnateElvenChestSouthDeed), "Caisses et coffres", 1072862, 94.7, 119.7, typeof(Board), 1044041, 40, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(OrnateElvenChestEastDeed), "Caisses et coffres", 1073383, 94.7, 119.7, typeof(Board), 1044041, 40, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(RarewoodChest), "Caisses et coffres", 1073402, 80.0, 105.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(DecorativeBox), "Caisses et coffres", 1073403, 80.0, 105.0, typeof(Board), 1044041, 25, 1044351);
			index = AddCraft(typeof(Chest), "Caisses et coffres", 1095293, 80.0, 105.0, typeof(Board), 1044041, 30, 1044351);

			// Chaises
			index = AddCraft(typeof(FootStool), "Chaises", "Petit tabouret", 11.0, 36.0, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(Stool), "Chaises", "Tabouret", 11.0, 36.0, typeof(Board), 1044041, 9, 1044351);
			index = AddCraft(typeof(TabouretFeutre), "Chaises", "Tabouret Feutré", 11.0, 36.0, typeof(Board), 1044041, 9, 1044351);

			index = AddCraft(typeof(BambooChair), "Chaises", "Chaise rustique", 21.0, 46.0, typeof(Board), 1044041, 13, 1044351);
			index = AddCraft(typeof(WoodenChair), "Chaises", "Chaise simple", 21.0, 46.0, typeof(Board), 1044041, 13, 1044351);
			index = AddCraft(typeof(FancyWoodenChairCushion), "Chaises", "Chaise travaillée", 42.1, 67.1, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(WoodenChairCushion), "Chaises", "Chaise avec coussin", 42.1, 67.1, typeof(Board), 1044041, 13, 1044351);
			index = AddCraft(typeof(WoodenBench), "Chaises", "Banc en bois", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(WoodenThrone), "Chaises", "Trône simple", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);

			index = AddCraft(typeof(ChaiseLuxe), "Chaises", "Chaise de Luxe", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(BancGris), "Chaises", "Banc Gris", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(BancFer), "Chaises", "Banc Fer", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(ChaiseRembourer), "Chaises", "Chaise Rembourée", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(ChaiseVerte), "Chaises", "Chaise Verte", 52.6, 77.6, typeof(Board), 1044041, 17, 1044351);

			index = AddCraft(typeof(Throne), "Chaises", "Trône massif", 73.6, 98.6, typeof(Board), 1044041, 19, 1044351);
			index = AddCraft(typeof(OrnateElvenChair), "Chaises", "Chaise sculptée", 80.0, 105.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(BigElvenChair), "Chaises", "Chaise ornée", 85.0, 110.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(ElvenReadingChair), "Chaises", "Chaise carrée", 80.0, 105.0, typeof(Board), 1044041, 30, 1044351);
			index = AddCraft(typeof(ElvenLoveseatSouthDeed), "Chaises", "Chaise élégante (S)", 80.0, 105.0, typeof(Board), 1044041, 50, 1044351);
			SetDisplayID(index, 0x2DDF);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenLoveseatEastDeed), "Chaises", "Chaise élégante (E)", 80.0, 105.0, typeof(Board), 1044041, 50, 1044351);
			SetDisplayID(index, 0x2DE0);
			ForceNonExceptional(index);
			index = AddCraft(typeof(RusticBenchSouthDeed), "Chaises", "Banc rustique (S)", 94.7, 119.8, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(RusticBenchEastDeed), "Chaises", "Banc rustique (E)", 94.7, 119.8, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(BancMachineCoudre), "Chaises", "Banc simple", 90.0, 115.0, typeof(Board), 1044041, 8, 1044351);

			// Tables
			index = AddCraft(typeof(Nightstand), "Tables", "Petite table", 42.1, 67.1, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(WritingTable), "Tables", "Bureau d'éctriture", 63.1, 88.1, typeof(Board), 1044041, 17, 1044351);
			index = AddCraft(typeof(LargeTable), "Tables", "Table large", 84.2, 109.2, typeof(Board), 1044041, 27, 1044351);
			index = AddCraft(typeof(YewWoodTable), "Tables", "Table arrondie", 63.1, 88.1, typeof(Board), 1044041, 23, 1044351);
			index = AddCraft(typeof(TableNappe), "Tables", "Table avec Nappe (Flip)", 73.1, 98.1, typeof(Board), 1044041, 23, 1044351);
			index = AddCraft(typeof(TableNappe2), "Tables", "Table avec Nappe Érable (Flip)", 73.1, 98.1, typeof(Board), 1044041, 23, 1044351);
			index = AddCraft(typeof(ComptoirNappe), "Tables", "Comptoir avec Nappe (Flip)", 83.1, 108.1, typeof(Board), 1044041, 23, 1044351);
			index = AddCraft(typeof(ElegantLowTable), "Tables", "Table basse élégante", 80.0, 105.0, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(PlainLowTable), "Tables", "Table basse simple", 80.0, 105.0, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(ShortCabinet), "Tables", "Table basse étroite", 90.0, 115.0, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(OrnateElvenTableSouthDeed), "Tables", "Table décorée (S)", 85.0, 110.0, typeof(Board), 1044041, 60, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(OrnateElvenTableEastDeed), "Tables", "Table décorée (E)", 85.0, 110.0, typeof(Board), 1044041, 60, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(FancyElvenTableSouthDeed), "Tables", "Table élégante (S)", 80.0, 105.0, typeof(Board), 1044041, 50, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(FancyElvenTableEastDeed), "Tables", "Table élégante (E)", 80.0, 105.0, typeof(Board), 1044041, 50, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(BarComptoir), "Tables", "Bar", 80.0, 105.0, typeof(Board), 1044041, 30, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(Comptoir), "Tables", "Comptoir", 80.0, 105.0, typeof(Board), 1044041, 20, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(LongTableSouthDeed), "Tables", "Longue table (S)", 90.0, 115.0, typeof(Board), 1044041, 80, 1044351);
			index = AddCraft(typeof(LongTableEastDeed), "Tables", "Longue table (E)", 90.0, 115.0, typeof(Board), 1044041, 80, 1044351);
			index = AddCraft(typeof(AlchemistTableSouthDeed), "Tables", "Comptoir alchimique (S)", 85.0, 110.0, typeof(Board), 1044041, 70, 1044351);
			SetDisplayID(index, 0x2DD4);
			ForceNonExceptional(index);
			index = AddCraft(typeof(AlchemistTableEastDeed), "Tables", "Comptoir alchimique (E)", 85.0, 110.0, typeof(Board), 1044041, 70, 1044351);
			SetDisplayID(index, 0x2DD3);
			ForceNonExceptional(index);
			index = AddCraft(typeof(TinkerTable), "Tables", "Table de bricoleur", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			AddRes(index, typeof(IronIngot), 1044036, 15, 1044037);
			index = AddCraft(typeof(RepairTable), "Tables", "Table de Travail", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			AddRes(index, typeof(IronIngot), 1044036, 15, 1044037);
			index = AddCraft(typeof(Tableronde1), "Tables", "Table ronde1", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(TableRonde2), "Tables", "Table ronde2", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(TableRonde3), "Tables", "Table ronde3", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(TableGrise), "Tables", "Table Grise", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);

			index = AddCraft(typeof(TableApothicaire), "Tables", "Table de l'Apothicaire", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(RangementAlchimie), "Tables", "Rangement alchimique", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(ItemAlchimie), "Tables", "Nécessaire d'Alchimie", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(TableBrasseur), "Tables", "Table Festive", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);

			// Armoires
			index = AddCraft(typeof(EmptyBookcase), "Armoires", "Bibliothèque vide", 31.5, 56.5, typeof(Board), 1044041, 25, 1044351);
			index = AddCraft(typeof(FullBookcase), "Armoires", "Bibliothèque", 31.5, 56.5, typeof(Board), 1044041, 25, 1044351);
			index = AddCraft(typeof(BibliothequeLuxe), "Armoires", "Bibliothèque vitrée", 31.5, 56.5, typeof(Board), 1044041, 25, 1044351);
			index = AddCraft(typeof(BibliothequeLuxe2), "Armoires", "Bibliothèque de luxe avec livres", 31.5, 56.5, typeof(Board), 1044041, 25, 1044351);
			index = AddCraft(typeof(FancyArmoire), "Armoires", "Armoire travaillée", 84.2, 109.2, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(Armoire), "Armoires", "Armoire", 84.2, 109.2, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(TallCabinet), "Armoires", "Grande commode", 90.0, 115.0, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(RedArmoire), "Armoires", "Petite armoire", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(ElegantArmoire), "Armoires", "Table de chevet", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(MapleArmoire), "Armoires", "Petite armoire décorée", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(CherryArmoire), "Armoires", "Petite armoire élégante", 90.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(ArcaneBookShelfDeedSouth), "Armoires", "Étagère arcanique (S)", 94.7, 119.7, typeof(Board), 1044041, 80, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ArcaneBookShelfDeedEast), "Armoires", "Étagère arcanique (E)", 94.7, 119.7, typeof(Board), 1044041, 80, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(AcademicBookCase), "Armoires", "Bibliothèque académique", 60.0, 85.0, typeof(Board), 1044041, 25, 1044351);
			AddRes(index, typeof(AcademicBooksArtifact), 1071202, 1, 1044253);
			index = AddCraft(typeof(ElvenWashBasinSouthWithDrawerDeed), "Armoires", "Commode avec vanité (S)", 70.0, 95.0, typeof(Board), 1044041, 40, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenWashBasinEastWithDrawerDeed), "Armoires", "Commode avec vanité (E)", 70.0, 95.0, typeof(Board), 1044041, 40, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenDresserDeedSouth), "Armoires", "Armoire travaillée (S)", 75.0, 100.0, typeof(Board), 1044041, 45, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenDresserDeedEast), "Armoires", "Armoire travaillée (E)", 75.0, 100.0, typeof(Board), 1044041, 45, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(FancyElvenArmoire), "Armoires", "Grande armoire travaillée", 80.0, 105.0, typeof(Board), 1044041, 60, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(SimpleElvenArmoire), "Armoires", "Grande armoire élégante", 80.0, 105.0, typeof(Board), 1044041, 60, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(Drawer), "Armoires", "Commode", 70.0, 95.0, typeof(Board), 1044041, 30, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(FancyDrawer), "Armoires", "Commode huppée", 80.0, 105.0, typeof(Board), 1044041, 30, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(TerMurDresserEastDeed), "Armoires", "Armoire élégante (E)", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(TerMurDresserSouthDeed), "Armoires", "Armoire élégante (S)", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(NormDresser), "Armoires", "Coiffeuse", 70.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(CommodeFoncee), "Armoires", "Commode Foncée", 70.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(CommodeHaute), "Armoires", "Commode Haute", 70.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(GardeRobeFermer), "Armoires", "Garde Robe Fermée", 70.0, 115.0, typeof(Board), 1044041, 40, 1044351);
			index = AddCraft(typeof(GardeRobeOuvert), "Armoires", "Garde Robe Ouverte", 70.0, 115.0, typeof(Board), 1044041, 40, 1044351);

			// Lits
			index = AddCraft(typeof(SmallBedSouthDeed), "Lits", "Petit lit (S)", 94.7, 119.8, typeof(Board), 1044041, 100, 1044351);
			AddSkill(index, SkillName.Tailoring, 75.0, 80.0);
			AddRes(index, typeof(Cloth), 1044286, 100, 1044287);
			index = AddCraft(typeof(SmallBedEastDeed), "Lits", "Petit lit (E)", 94.7, 119.8, typeof(Board), 1044041, 100, 1044351);
			AddSkill(index, SkillName.Tailoring, 75.0, 80.0);
			AddRes(index, typeof(Cloth), 1044286, 100, 1044287);
			index = AddCraft(typeof(LargeBedSouthDeed), "Lits", "Grand lit (S)", 94.7, 119.8, typeof(Board), 1044041, 150, 1044351);
			AddSkill(index, SkillName.Tailoring, 75.0, 80.0);
			AddRes(index, typeof(Cloth), 1044286, 150, 1044287);
			index = AddCraft(typeof(LargeBedEastDeed), "Lits", "Grand lit (E)", 94.7, 119.8, typeof(Board), 1044041, 150, 1044351);
			AddSkill(index, SkillName.Tailoring, 75.0, 80.0);
			AddRes(index, typeof(Cloth), 1044286, 150, 1044287);
			index = AddCraft(typeof(TallElvenBedSouthDeed), "Lits", "Grand lit orné (S)", 94.7, 119.7, typeof(Board), 1044041, 200, 1044351);
			AddRes(index, typeof(Cloth), 1044286, 100, 1044287);
			ForceNonExceptional(index);
			index = AddCraft(typeof(TallElvenBedEastDeed), "Lits", "Grand lit orné (E)", 94.7, 119.7, typeof(Board), 1044041, 200, 1044351);
			AddRes(index, typeof(Cloth), 1044286, 100, 1044287);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenBedSouthDeed), "Lits", "Lit orné (S)", 94.7, 119.7, typeof(Board), 1044041, 100, 1044351);
			AddRes(index, typeof(Cloth), 1044286, 100, 1044287);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenBedEastDeed), "Lits", "Lit orné (E)", 94.7, 119.7, typeof(Board), 1044041, 100, 1044351);
			AddRes(index, typeof(Cloth), 1044286, 100, 1044287);
			ForceNonExceptional(index);

			// Décoration
			index = AddCraft(typeof(RedHangingLantern), "Décorations", "Lanterne rouge suspendue", 65.0, 90.0, typeof(Board), 1044041, 5, 1044351);
			AddRes(index, typeof(BlankScroll), 1044377, 10, 1044378);
			index = AddCraft(typeof(WhiteHangingLantern), "Décorations", "Lanterne blanche suspendue", 65.0, 90.0, typeof(Board), 1044041, 5, 1044351);
			AddRes(index, typeof(BlankScroll), 1044377, 10, 1044378);
			index = AddCraft(typeof(ShojiScreen), "Décorations", "Paravent léger", 80.0, 105.0, typeof(Board), 1044041, 75, 1044351);
			AddSkill(index, SkillName.Tailoring, 50.0, 55.0);
			AddRes(index, typeof(Cloth), 1044286, 60, 1044287);
			index = index = AddCraft(typeof(BambooScreen), "Décorations", "Paravent simple", 80.0, 105.0, typeof(Board), 1044041, 75, 1044351);
			AddSkill(index, SkillName.Tailoring, 50.0, 55.0);
			AddRes(index, typeof(Cloth), 1044286, 60, 1044287);
			index = AddCraft(typeof(Paravent), "Décorations", "Paravent de bois", 80.0, 105.0, typeof(Board), 1044041, 50, 1044351);
			index = AddCraft(typeof(Incubator), "Décorations", "Présentoir", 90.0, 115.0, typeof(Board), 1044041, 100, 1044351);
			index = AddCraft(typeof(ChickenCoop), "Décorations", "Poulailler", 90.0, 115.0, typeof(Board), 1044041, 150, 1044351);
			index = AddCraft(typeof(ParrotPerchAddonDeed), "Décorations", "Perche perroquet", 50.0, 85.0, typeof(Board), 1044041, 100, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ArcaneCircleDeed), "Décorations", "Cercle arcanique", 94.7, 119.7, typeof(Board), 1044041, 100, 1044351);
			AddRes(index, typeof(Diamond), 1026255, 2, 1053098);
			AddRes(index, typeof(Emerald), 1026251, 2, 1053098);
			AddRes(index, typeof(Ruby), 1026254, 2, 1053098);
			ForceNonExceptional(index);
			index = AddCraft(typeof(PentagramDeed), "Décorations", "Pantagramme", 100.0, 125.0, typeof(Board), 1044041, 100, 1044351);
			AddRes(index, typeof(IronIngot), 1044036, 40, 1044037);
			index = AddCraft(typeof(DartBoardSouthDeed), "Décorations", "Jeu de dard (S)", 15.7, 40.7, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(DartBoardEastDeed), "Décorations", "Jeu de dard (E)", 15.7, 40.7, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(BallotBoxDeed), "Décorations", "Urne sculptée", 47.3, 72.3, typeof(Board), 1044041, 5, 1044351);
			index = AddCraft(typeof(VanityDeed), "Décorations", "Vanité", 60.3, 95.0, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(AbbatoirDeed), "Décorations", "Abattoir", 100.0, 125.0, typeof(Board), 1044041, 100, 1044351);
			AddRes(index, typeof(IronIngot), 1044036, 40, 1044037);
			index = AddCraft(typeof(FeedingThrough), "Décorations", "Mangeoir", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(Puit), "Décorations", "Puit", 90.0, 115.0, typeof(Board), 1044041, 60, 1044351);
			index = AddCraft(typeof(PoteauChaine), "Décorations", "Poteau avec Chaine", 90.0, 115.0, typeof(Board), 1044041, 10, 1044351);
			AddRes(index, typeof(IronIngot), "Lingot de fer", 3, "Vous n'avez pas suffisament de lingot de fer");
			index = AddCraft(typeof(RackaVin), "Décorations", "Cellier", 90.0, 115.0, typeof(Board), 1044041, 20, 1044351);
			AddRes(index, typeof(BottleOfWine), "Bouteille de vin", 15, "Vous n'avez pas suffisament de bouteille de vin.");
			index = AddCraft(typeof(PresentoireVide), "Décorations", "Presentoir Vide", 90.0, 115.0, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(PresentoirePlein1), "Décorations", "Presentoir Plein 1", 90.0, 115.0, typeof(Board), 1044041, 20, 1044351);
			index = AddCraft(typeof(PresentoirePlein2), "Décorations", "Presentoir Plein 2", 90.0, 115.0, typeof(Board), 1044041, 20, 1044351);

			// Statues et trophés
			index = AddCraft(typeof(ArcanistStatueSouthDeed), "Statues et trophés", "L'Arcaniste (S)", 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ArcanistStatueEastDeed), "Statues et trophés", "L'Arcaniste (E)", 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(WarriorStatueSouthDeed), "Statues et trophés", "Le Guerrier (S)", 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(WarriorStatueEastDeed), "Statues et trophés", "Le Guerrier (E)", 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(SquirrelStatueSouthDeed), "Statues et trophés", "L'Écureuil (S)", 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(SquirrelStatueEastDeed), "Statues et trophés", "L'Écureuil (E)", 0.0, 35.0, typeof(Board), 1044041, 250, 1044351);
			ForceNonExceptional(index);
			index = AddCraft(typeof(GiantReplicaAcorn), "Statues et trophés", "Gland géant sculpté", 80.0, 105.0, typeof(Board), 1044041, 35, 1044351);
			index = AddCraft(typeof(MountedDreadHorn), "Statues et trophés", "Tête de licorne sculptée", 90.0, 115.0, typeof(Board), 1044041, 50, 1044351);
			ForceNonExceptional(index);

			// Grands outils
			index = AddCraft(typeof(MachineCoudre), "Grands outils", "Machine à Coudre", 90.0, 115.0, typeof(Board), 1044041, 30, 1044351);
			AddRes(index, typeof(IronIngot), 1044036, 15, 1044037);
			index = AddCraft(typeof(SpinningwheelEastDeed), "Grands outils", "Rouet (E)", 73.6, 98.6, typeof(Board), 1044041, 75, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 70.0);
			AddRes(index, typeof(Cloth), 1044286, 25, 1044287);
			index = AddCraft(typeof(SpinningwheelSouthDeed), "Grands outils", "Rouet (S)", 73.6, 98.6, typeof(Board), 1044041, 75, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 70.0);
			AddRes(index, typeof(Cloth), 1044286, 25, 1044287);
			index = AddCraft(typeof(ElvenSpinningwheelEastDeed), "Grands outils", "Rouet élégant (E)", 75.0, 100.0, typeof(Board), 1044041, 60, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 85.0);
			AddRes(index, typeof(Cloth), 1044286, 40, 1044287);
			ForceNonExceptional(index);
			index = AddCraft(typeof(ElvenSpinningwheelSouthDeed), "Grands outils", "Rouet élégant (S)", 75.0, 100.0, typeof(Board), 1044041, 60, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 85.0);
			AddRes(index, typeof(Cloth), 1044286, 40, 1044287);
			index = AddCraft(typeof(LoomEastDeed), "Grands outils", "Métier à tisser (E)", 84.2, 109.2, typeof(Board), 1044041, 85, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 70.0);
			AddRes(index, typeof(Cloth), 1044286, 25, 1044287);
			index = AddCraft(typeof(LoomSouthDeed), "Grands outils", "Métier à tisser (S)", 84.2, 109.2, typeof(Board), 1044041, 85, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 70.0);
			AddRes(index, typeof(Cloth), 1044286, 25, 1044287);
			index = AddCraft(typeof(DressformFront), "Grands outils", "Mannequin face", 63.1, 88.1, typeof(Board), 1044041, 25, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 70.0);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			index = AddCraft(typeof(DressformSide), "Grands outils", "Mannequin côté", 63.1, 88.1, typeof(Board), 1044041, 25, 1044351);
			AddSkill(index, SkillName.Tailoring, 65.0, 70.0);
			AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
			index = AddCraft(typeof(FlourMillEastDeed), "Grands outils", "Moulin à farine (E)", 94.7, 119.7, typeof(Board), 1044041, 100, 1044351);
			AddSkill(index, SkillName.Tinkering, 50.0, 55.0);
			AddRes(index, typeof(IronIngot), 1044036, 50, 1044037);
			index = AddCraft(typeof(FlourMillSouthDeed), "Grands outils", "Moulin à farine (S)", 94.7, 119.7, typeof(Board), 1044041, 100, 1044351);
			AddSkill(index, SkillName.Tinkering, 50.0, 55.0);
			AddRes(index, typeof(IronIngot), 1044036, 50, 1044037);
			index = AddCraft(typeof(WaterTroughEastDeed), "Grands outils", "Abreuvoir (E)", 94.7, 119.7, typeof(Board), 1044041, 150, 1044351);
			index = AddCraft(typeof(WaterTroughSouthDeed), "Grands outils", "Abreuvoir (S)", 94.7, 119.7, typeof(Board), 1044041, 150, 1044351);


			MarkOption = true;
			Repair = true;
			CanEnhance = true;
			CanAlter = true;

			SetSubRes(typeof(Board), 1072643);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(Board), 1072643, 0.0, 1044041, 1072653);
			AddSubRes(typeof(OakBoard), 1072644, 65.0, 1044041, 1072653);
			AddSubRes(typeof(AshBoard), 1072645, 75.0, 1044041, 1072653);
			AddSubRes(typeof(YewBoard), 1072646, 85.0, 1044041, 1072653);
			AddSubRes(typeof(HeartwoodBoard), 1072647, 95.0, 1044041, 1072653);
			AddSubRes(typeof(BloodwoodBoard), 1072648, 95.0, 1044041, 1072653);
			AddSubRes(typeof(FrostwoodBoard), 1072649, 95.0, 1044041, 1072653);
		}
	}
}
