using Server.Items;
using System;
using System.Collections.Generic;

namespace Server.Engines.Craft
{
    public enum TailorRecipe
    {
        ElvenQuiver = 501,
        QuiverOfFire = 502,
        QuiverOfIce = 503,
        QuiverOfBlight = 504,
        QuiverOfLightning = 505,

        SongWovenMantle = 550,
        SpellWovenBritches = 551,
        StitchersMittens = 552,

        JesterShoes = 560,
        ChefsToque = 561,
        GuildedKilt = 562,
        CheckeredKilt = 563,
        FancyKilt = 564,
        FloweredDress = 565,
        EveningGown = 566,

        TigerPeltChest = 570,
        TigerPeltCollar = 571,
        TigerPeltHelm = 572,
        TigerPeltLegs = 573,
        TigerPeltShorts = 574,
        TigerPeltBustier = 575,
        TigerPeltLongSkirt = 576,
        TigerPeltSkirt = 577,

        DragonTurtleHideArms = 580,
        DragonTurtleHideChest = 581,
        DragonTurtleHideHelm = 582,
        DragonTurtleHideLegs = 583,
        DragonTurtleHideBustier = 584,

        // doom
        CuffsOfTheArchmage = 585,

        KrampusMinionHat = 586,
        KrampusMinionBoots = 587,
        KrampusMinionTalons = 588,

        MaceBelt = 1100,
        SwordBelt = 1101,
        DaggerBelt = 1102,
        ElegantCollar = 1103,
        CrimsonMaceBelt = 1104,
        CrimsonSwordBelt = 1105,
        CrimsonDaggerBelt = 1106,
        ElegantCollarOfFortune = 1107,
        AssassinsCowl = 1108,
        MagesHood = 1109,
        CowlOfTheMaceAndShield = 1110,
        MagesHoodOfScholarlyInsight = 1111,

    }

    public class DefTailoring : CraftSystem
    {
        #region Statics
        private static readonly Type[] m_TailorColorables = new Type[]
   		{
            typeof(GozaMatEastDeed), typeof(GozaMatSouthDeed),
            typeof(SquareGozaMatEastDeed), typeof(SquareGozaMatSouthDeed),
            typeof(BrocadeGozaMatEastDeed), typeof(BrocadeGozaMatSouthDeed),
            typeof(BrocadeSquareGozaMatEastDeed), typeof(BrocadeSquareGozaMatSouthDeed),
            typeof(SquareGozaMatDeed)
   		};

        private static readonly Type[] m_TailorClothNonColorables = new Type[]
        {
            typeof(DeerMask), typeof(BearMask), typeof(OrcMask), typeof(TribalMask), typeof(HornedTribalMask), typeof(CuffsOfTheArchmage)
        };

        // singleton instance
        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefTailoring();

                return m_CraftSystem;
            }
        }
        #endregion

        #region Constructor
        private DefTailoring()
            : base(1, 1, 1.25)// base( 1, 1, 4.5 )
        {
        }

        #endregion

        #region Overrides
        public override SkillName MainSkill => SkillName.Tailoring;

		//    public override int GumpTitleNumber => 1044005;

		public override string GumpTitleString => "Couture";
		public override CraftECA ECA => CraftECA.ChanceMinusSixtyToFourtyFive;

        public override double GetChanceAtMin(CraftItem item)
        {
            if (item.NameNumber == 1157348 || item.NameNumber == 1159225 || item.NameNumber == 1159213 || item.NameNumber == 1159212 ||
                item.NameNumber == 1159211 || item.NameNumber == 1159228 || item.NameNumber == 1159229)
                return 0.05; // 5%

            return 0.5; // 50%
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

        public override bool RetainsColorFrom(CraftItem item, Type type)
        {
            if (type != typeof(Cloth) && type != typeof(UncutCloth) && type != typeof(AbyssalCloth))
                return false;

            type = item.ItemType;

            bool contains = false;

            for (int i = 0; !contains && i < m_TailorColorables.Length; ++i)
                contains = (m_TailorColorables[i] == type);

            return contains;
        }

        public override bool RetainsColorFromException(CraftItem item, Type type)
        {
            if (item == null || type == null)
                return false;

            if (type != typeof(Cloth) && type != typeof(UncutCloth) && type != typeof(AbyssalCloth))
                return false;

            bool contains = false;

            for (int i = 0; !contains && i < m_TailorClothNonColorables.Length; ++i)
                contains = (m_TailorClothNonColorables[i] == item.ItemType);

            return contains;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x248);
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


			index = AddCraft(typeof(Jupe), "Pantalons",  "Jupe", 61.4, 81.4, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe2), "Pantalons",  "Jupe2", 83.8, 103.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe3), "Pantalons",  "Jupe3", 73.1, 93.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe4), "Pantalons",  "Jupe4", 79.6, 99.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe5), "Pantalons",  "Jupe5", 51.8, 71.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe6), "Pantalons",  "Jupe6", 77.0, 97.0, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeVoiles), "Pantalons",  "Jupe � Voiles", 87.8, 107.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeVoiles2), "Pantalons",  "Jupe � Voiles2", 57.2,77.2, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte), "Pantalons",  "Jupe Courte", 93.6,113.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte2), "Pantalons",  "Jupe Courte2", 79.3,99.3, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe7), "Pantalons",  "Jupe7", 64.2,84.2, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte3), "Pantalons",  "Jupe Courte3", 49.9,69.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte4), "Pantalons",  "Jupe Courte4", 63.5,83.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte5), "Pantalons",  "Jupe Courte5", 74.2,94.2, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte6), "Pantalons",  "Jupe Courte6", 88.8,108.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeCourte7), "Pantalons",  "Jupe Courte7", 46.7,66.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeLacee), "Pantalons",  "Jupe Lac�e", 51.9,71.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeLacee2), "Pantalons",  "Jupe Lac�e2", 72.1,92.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(JupeLacee3), "Pantalons",  "Jupe Lac�e3", 62.1,82.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Kilt3), "Pantalons",  "Kilt3", 53.0,73.0, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Kilt2), "Pantalons",  "Kilt2", 75.0,95.0, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pareo), "Pantalons",  "Par�o", 52.3,72.3, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(PareoCourt), "Pantalons",  "Par�o Court", 92.6,112.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail), "Hauts",  "Chandail", 77.9,97.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Camisole), "Hauts",  "Camisole", 77.5,97.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail2), "Hauts",  "Chandail2", 84.5,104.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique), "Hauts",  "Tunique", 67.0,87.0, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise), "Hauts",  "Chemise", 52.1,72.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe2), "Robes",  "Robe2", 63.7,83.7, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique2), "Hauts",  "Tunique2", 73.8,93.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Uniforme), "Hauts",  "Uniforme", 56.6,76.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe19), "Robes",  "Robe19", 61.2,81.2, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeCourte), "Robes",  "Robe Courte", 82.1,102.1, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe3), "Robes",  "Robe3", 94.7,114.7, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe4), "Robes",  "Robe4", 79.1,99.1, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe11), "Pantalons",  "Jupe11", 47.8,67.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeProvocante), "Robes",  "Robe Provocante", 73.9,93.9, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Bustier), "Hauts",  "Bustier", 49.9,69.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Bustier2), "Hauts",  "Bustier2", 88.6,108.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Bustier3), "Hauts",  "Bustier3", 81.4,101.4, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe8), "Pantalons",  "Jupe8", 52.1,72.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe9), "Pantalons",  "Jupe9", 56.7,76.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Jupe10), "Pantalons",  "Jupe10", 83.1,103.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe5), "Robes",  "Robe5", 81.7,101.7, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe6), "Robes",  "Robe6", 58.1,78.1, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe7), "Robes",  "Robe7", 97.3,117.3, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe8), "Robes",  "Robe8", 91.1,111.1, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe9), "Robes",  "Robe9", 70.0,90.0, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe10), "Robes",  "Robe10", 97.3,117.3, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe11), "Robes",  "Robe11", 60.0,80.0, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe12), "Robes",  "Robe12", 94.1,114.1, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe13), "Robes",  "Robe13", 65.0,85.0, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe14), "Robes",  "Robe14", 52.3,72.3, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe15), "Robes",  "Robe15", 55.4,75.4, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe16), "Robes",  "Robe16", 84.6,104.6, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeProvocante2), "Robes",  "RobeProvocante2", 55.6,75.6, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeProvocante3), "Robes",  "RobeProvocante3", 66.6,86.6, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeProvocante4), "Robes",  "RobeProvocante4", 84.3,104.3, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeProvocante5), "Robes",  "RobeProvocante5", 51.6,71.6, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(RobeProvocante6), "Robes",  "RobeProvocante6", 76.0,96.0, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe17), "Robes",  "Robe17", 60.0,80.0, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Robe18), "Robes",  "Robe18", 78.8,98.8, typeof(Cloth),"Tissus", 16, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge), "Toges", "Toges", 46.4,66.4, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge2), "Toges",  "Toge2", 71.7,91.7, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge3), "Toges",  "Toge3", 46.4,66.4, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge4), "Toges",  "Toge4", 70.6,90.6, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge5), "Toges",  "Toge5", 66.1,86.1, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge6), "Toges",  "Toge6", 78.7,98.7, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge7), "Toges",  "Toge7", 86.3,106.3, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toge8), "Toges",  "Toge8", 50.9,70.9, typeof(Cloth),"Tissus", 18, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar), "Hauts", "Tabar", 72.3,92.3, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar1), "Hauts",  "Tabar1", 67.0,87.0, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar2), "Hauts",  "Tabar2", 84.2,104.2, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar3), "Hauts",  "Tabar3", 47.0,67.0, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar4), "Hauts",  "Tabar4", 93.3,113.3, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar5), "Hauts",  "Tabar5", 56.9,76.9, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar6), "Hauts",  "Tabar6", 61.6,81.6, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar7), "Hauts",  "Tabar7", 66.4,86.4, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar8), "Hauts",  "Tabar8", 58.8,78.8, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar9), "Hauts",  "Tabar9", 50.5,70.5, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar10), "Hauts",  "Tabar10", 69.4,89.4, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tabar11), "Hauts",  "Tabar11", 61.3,81.3, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail3), "Hauts",  "Chandail3", 90.4,110.4, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail4), "Hauts",  "Chandail4", 81.7,101.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail5), "Hauts",  "Chandail5", 81.7,101.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail6), "Hauts",  "Chandail6", 78.7,98.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail7), "Hauts",  "Chandail7", 73.0,93.0, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail8), "Hauts",  "Chandail8", 96.6,116.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail9), "Hauts",  "Chandail9", 85.2,105.2, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chandail10), "Hauts",  "Chandail10", 63.7,83.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise2), "Hauts",  "Chemise2", 53.2,73.2, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise3), "Hauts",  "Chemise3", 88.1,108.1, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise4), "Hauts",  "Chemise4", 97.9,117.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise5), "Hauts",  "Chemise5", 91.8,111.8, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise6), "Hauts",  "Chemise6", 65.4,85.4, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Chemise7), "Hauts",  "Chemise7", 97.2,117.2, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Doublet), "Hauts",  "Doublet", 58.3,78.3, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Doublet2), "Hauts",  "Doublet2", 84.7,104.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Doublet3), "Hauts",  "Doublet3", 93.9,113.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Doublet4), "Hauts",  "Doublet4", 69.9,89.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Doublet5), "Hauts",  "Doublet5", 70.7,90.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Doublet6), "Hauts",  "Doublet6", 56.5,76.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique3), "Hauts",  "Tunique3", 51.5,71.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique4), "Hauts",  "Tunique4", 77.6,97.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique5), "Hauts",  "Tunique5", 74.9,94.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique6), "Hauts",  "Tunique6", 69.9,89.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique7), "Hauts",  "Tunique7", 76.3,96.3, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique8), "Hauts",  "Tunique8", 88.5,108.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique9), "Hauts",  "Tunique9", 92.5,112.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Tunique10), "Hauts",  "Tunique10", 65.7,85.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon1), "Pantalons",  "Pantalon1", 90.8,110.8, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon2), "Pantalons",  "Pantalon2", 58.0,78.0, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon3), "Pantalons",  "Pantalon3", 92.6,112.6, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon4), "Pantalons",  "Pantalon4", 51.8,71.8, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon5), "Pantalons",  "Pantalon5", 60.5,80.5, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon6), "Pantalons",  "Pantalon6", 62.1,82.1, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon7), "Pantalons",  "Pantalon7", 45.4,65.4, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon8), "Pantalons",  "Pantalon8", 46.2,66.2, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon9), "Pantalons",  "Pantalon9", 75.7,95.7, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon10), "Pantalons",  "Pantalon10", 63.6,83.6, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon11), "Pantalons",  "Pantalon11", 72.9,92.9, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Pantalon12), "Pantalons",  "Pantalon12", 53.3,73.3, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Salopette), "Pantalons",  "Salopette", 81.3,101.3, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Manteau), "Hauts",  "Manteau", 66.5,86.5, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Manteau2), "Hauts",  "Manteau2", 71.0,91.0, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Veste), "Hauts",  "Veste", 62.7,82.7, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Veste2), "Hauts",  "Veste2", 82.6,102.6, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Veste3), "Hauts",  "Veste3", 48.9,68.9, typeof(Cloth),"Tissus", 8, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Carquois), "Carquois",  "Carquois", 60.6,80.6, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau), "Divers",  "fourreau", 80.7,100.7, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau2), "Divers",  "fourreau2", 98.1,118.1, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau3), "Divers",  "fourreau3", 66.9,86.9, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Foulard), "Divers",  "Foulard", 65.5,85.5, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Foulard2), "Divers",  "Foulard2", 57.2,77.2, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			//index = AddCraft(typeof(Foulard3), "Divers",  "Foulard3", 75.5,95.5, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Foulard4), "Divers",  "Foulard4", 56.8,76.8, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cocarde), "Divers",  "Cocarde", 59.0,79.0, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Capuche), "Chapeaux",  "Capuche", 55.3,75.3, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Capuche2), "Chapeaux",  "Capuche2", 97.0,117.0, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(TeteCoyote), "Chapeaux",  "Tete de Coyote", 85.5,105.5, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(TeteTaureau), "Chapeaux",  "Tete de Taureau", 89.3,109.3, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Toque), "Chapeaux",  "Toque", 89.4,109.4, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Turban), "Chapeaux",  "Turban", 90.7,110.7, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(VoileTete), "Chapeaux",  "Voile de T�te", 84.0,104.0, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(VoileTeteLong), "Chapeaux",  "Voile de t�te long", 94.8,114.8, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(BourseCeinture), "Divers",  "Bourse de Ceinture", 53.4,73.4, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture), "Ceintures",  "Ceinture", 52.4,72.4, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture2), "Ceintures",  "Ceinture2", 63.8,83.8, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture3), "Ceintures",  "Ceinture3", 87.4,107.4, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture4), "Ceintures",  "Ceinture4", 53.7,73.7, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture5), "Ceintures",  "Ceinture5", 90.9,110.9, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture6), "Ceintures",  "Ceinture6", 94.8,114.8, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture7), "Ceintures",  "Ceinture7", 56.4,76.4, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture8), "Ceintures",  "Ceinture8", 59.6,79.6, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Ceinture9), "Ceintures",  "Ceinture9", 80.5,100.5, typeof(Cloth),"Tissus", 10, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Bottes), "Bottes",  "Bottes", 45.7,65.7, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes2), "Bottes",  "Bottes2", 71.8,91.8, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes3), "Bottes",  "Bottes3", 75.7,95.7, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes4), "Bottes",  "Bottes4", 57.6,77.6, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes5), "Bottes",  "Bottes5", 52.0,72.0, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes6), "Bottes",  "Bottes6", 85.6,105.6, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes7), "Bottes",  "Bottes7", 74.1,94.1, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes8), "Bottes",  "Bottes8", 69.6,89.6, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes9), "Bottes",  "Bottes9", 86.9,106.9, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes10), "Bottes",  "Bottes10", 62.8,82.8, typeof(Leather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Cape), "Capes", "Cape0",  51.9,71.9, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape2), "Capes", "Cape1",  59.7,79.7, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape3), "Capes", "Cape2",    98.5,118.5, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape4), "Capes", "Cape3",    85.7,105.7, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape5), "Capes", "Cape4",    77.4,97.4, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape6), "Capes", "Cape5",    65.6,85.6, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape7), "Capes", "Cape6",    56.5,76.5, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape8), "Capes", "Cape7",    92.0,112.0, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape9), "Capes", "Cape8",    72.6,92.6, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape10), "Capes", "Cape9",   49.1,69.1, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(Cape11), "Capes", "Cape10",   83.2,103.2, typeof(Cloth),"Tissus", 12, "Vous n'avez pas assez de tissus.");

			index = AddCraft(typeof(ChapeauPirate), "Chapeaux",  "Chapeau de Pirate", 53.3,73.3, typeof(Cloth),"Tissus", 6, "Vous n'avez pas assez de tissus.");
























            #region Materials
            index = AddCraft(typeof(CutUpCloth), "Divers", 1044458, 0.0, 0.0, typeof(BoltOfCloth), 1044453, 1, 1044253);
            AddCraftAction(index, CutUpCloth);

            index = AddCraft(typeof(CombineCloth), "Divers", 1044459, 0.0, 0.0, typeof(Cloth), "Tissus", 1, 1044253);
            AddCraftAction(index, CombineCloth);

            

            #endregion

            #region Hats
            AddCraft(typeof(SkullCap), "Chapeaux", 1025444, 0.0, 25.0, typeof(Cloth), "Tissus", 2, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Bandana), "Chapeaux", 1025440, 0.0, 25.0, typeof(Cloth), "Tissus", 2, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(FloppyHat), "Chapeaux", 1025907, 6.2, 31.2, typeof(Cloth), "Tissus", 11, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Cap), "Chapeaux", 1025909, 6.2, 31.2, typeof(Cloth), "Tissus", 11, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(WideBrimHat), "Chapeaux", 1025908, 6.2, 31.2, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(StrawHat), "Chapeaux", 1025911, 6.2, 31.2, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(TallStrawHat), "Chapeaux", 1025910, 6.7, 31.7, typeof(Cloth), "Tissus", 13, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(WizardsHat), "Chapeaux", 1025912, 7.2, 32.2, typeof(Cloth), "Tissus", 15, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Bonnet), "Chapeaux", 1025913, 6.2, 31.2, typeof(Cloth), "Tissus", 11, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(FeatheredHat), "Chapeaux", 1025914, 6.2, 31.2, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(TricorneHat), "Chapeaux", 1025915, 6.2, 31.2, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(JesterHat), "Chapeaux", 1025916, 7.2, 32.2, typeof(Cloth), "Tissus", 15, "Vous n'avez pas assez de tissus.");

      

            AddCraft(typeof(ClothNinjaHood), "Chapeaux", 1030202, 80.0, 105.0, typeof(Cloth), "Tissus", 13, "Vous n'avez pas assez de tissus.");

            AddCraft(typeof(Kasa), "Chapeaux", 1030211, 60.0, 85.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            AddCraft(typeof(OrcMask), "Chapeaux", 1025147, 75.0, 100.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(BearMask), "Chapeaux", 1025445, 77.5, 102.5, typeof(Cloth), "Tissus", 15, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(DeerMask), "Chapeaux", 1025447, 77.5, 102.5, typeof(Cloth), "Tissus", 15, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(TribalMask), "Chapeaux", 1025449, 82.5, 107.5, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(HornedTribalMask), "Chapeaux", "Masque tribal Orn�e", 82.5, 107.5, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            #endregion

            #region Shirts/Pants
          //  AddCraft(typeof(Doublet), "Hauts", 1028059, 0, 25.0, typeof(Cloth), "Tissus", 8, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Shirt), "Hauts", 1025399, 20.7, 45.7, typeof(Cloth), "Tissus", 8, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(FancyShirt), "Hauts", 1027933, 24.8, 49.8, typeof(Cloth), "Tissus", 8, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Tunic), "Hauts", 1028097, 00.0, 25.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Surcoat), "Hauts", 1028189, 8.2, 33.2, typeof(Cloth), "Tissus", 14, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(PlainDress), "Robes", 1027937, 12.4, 37.4, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(FancyDress), "Robes", 1027935, 33.1, 58.1, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Cloak), "Capes", 1025397, 41.4, 66.4, typeof(Cloth), "Tissus", 14, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Robe), "Toges", 1027939, 53.9, 78.9, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(JesterSuit), "Hauts", 1028095, 8.2, 33.2, typeof(Cloth), "Tissus", 24, "Vous n'avez pas assez de tissus.");

			//   AddCraft(typeof(FurCape), "Hauts", 1028969, 35.0, 60.0, typeof(Cloth), "Tissus", 13, "Vous n'avez pas assez de tissus.");  - Stock de Gargouille
			//    AddCraft(typeof(GildedDress), "Hauts", 1028973, 37.5, 62.5, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus."); - Stock de Gargouille
			//    AddCraft(typeof(FormalShirt), "Hauts", 1028975, 26.0, 51.0, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus."); - Stock de Gargouille

			index = AddCraft(typeof(ClothNinjaJacket), "Hauts", 1030207, 75.0, 100.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(Kamishimo), "Hauts", 1030212, 75.0, 100.0, typeof(Cloth), "Tissus", 15, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(HakamaShita), "Hauts", 1030215, 40.0, 65.0, typeof(Cloth), "Tissus", 14, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(MaleKimono), "Hauts", 1030189, 50.0, 75.0, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(FemaleKimono), "Hauts", 1030190, 50.0, 75.0, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(JinBaori), "Hauts", 1030220, 30.0, 55.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            AddCraft(typeof(ShortPants), "Pantalons", 1025422, 24.8, 49.8, typeof(Cloth), "Tissus", 6, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(LongPants), "Pantalons", 1025433, 24.8, 49.8, typeof(Cloth), "Tissus", 8, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Kilt), "Pantalons", 1025431, 20.7, 45.7, typeof(Cloth), "Tissus", 8, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Skirt), "Pantalons", 1025398, 29.0, 54.0, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");

       //     AddCraft(typeof(FurSarong), "Hauts", 1028971, 35.0, 60.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(Hakama), "Hauts", 1030213, 50.0, 75.0, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(TattsukeHakama), "Pantalons", "Pantalon ample", 50.0, 75.0, typeof(Cloth), "Tissus", 16, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(ElvenShirt), "Hauts", 1032661, 80.0, 105.0, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(ElvenDarkShirt), "Hauts", "Gilet Elfique sombre", 80.0, 105.0, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(ElvenPants), "Pantalons", 1032665, 80.0, 105.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(MaleElvenRobe), "Robes", 1032659, 80.0, 105.0, typeof(Cloth), "Tissus", 30, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(FemaleElvenRobe), "Robes", 1032660, 80.0, 105.0, typeof(Cloth), "Tissus", 30, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(WoodlandBelt), "Hauts", 1032639, 80.0, 105.0, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");

            #endregion

            #region Misc
            AddCraft(typeof(BodySash), "Divers", 1025441, 4.1, 29.1, typeof(Cloth), "Tissus", 4, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(HalfApron), "Divers", 1025435, 20.7, 45.7, typeof(Cloth), "Tissus", 6, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(FullApron), "Divers", 1025437, 29.0, 54.0, typeof(Cloth), "Tissus", 10, "Vous n'avez pas assez de tissus.");

    //        AddCraft(typeof(Obi), "Divers", 1030219, 20.0, 45.0, typeof(Cloth), "Tissus", 6, "Vous n'avez pas assez de tissus.");

            index = AddCraft(typeof(ElvenQuiver), "Carquois", 1032657, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
          

            index = AddCraft(typeof(QuiverOfFire), "Carquois", 1073109, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            


            index = AddCraft(typeof(QuiverOfIce), "Carquois", 1073110, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
           

            index = AddCraft(typeof(QuiverOfBlight), "Carquois", 1073111, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            

            index = AddCraft(typeof(QuiverOfLightning), "Carquois", 1073112, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            


            AddCraft(typeof(GargoyleHalfApron), "Divers", 1099568, 20.7, 45.7, typeof(Cloth), "Tissus", 6, "Vous n'avez pas assez de tissus.");
            AddCraft(typeof(Sash), "Divers", 1115388, 4.1, 29.1, typeof(Cloth), "Tissus", 4, "Vous n'avez pas assez de tissus.");

			index = AddCraft(typeof(OilCloth), "Divers", 1041498, 74.6, 99.6, typeof(Cloth), "Tissus", 1, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(GozaMatEastDeed), "Tapis / Coussins", 1030404, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(GozaMatSouthDeed), "Tapis / Coussins", 1030405, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(SquareGozaMatDeed), "Tapis / Coussins", 1113621, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(SquareGozaMatEastDeed), "Tapis / Coussins", 1030407, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(SquareGozaMatSouthDeed), "Tapis / Coussins", 1030406, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(BrocadeGozaMatEastDeed), "Tapis / Coussins", 1030408, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(BrocadeGozaMatSouthDeed), "Tapis / Coussins", 1030409, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(BrocadeSquareGozaMatEastDeed), "Tapis / Coussins", 1030411, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(BrocadeSquareGozaMatSouthDeed), "Tapis / Coussins", 1030410, 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(LargeDiamondPillow), "Tapis / Coussins", "Coussin Diamant", 55.0, 80.0, typeof(Cloth), "Tissus", 25, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(SmallDiamondPillow), "Tapis / Coussins", "Petit Coussin Diamant", 35.0, 60.0, typeof(Cloth), "Tissus", 15, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(LargeSquarePillow), "Tapis / Coussins", "Coussin Carr�", 55.0, 80.0, typeof(Cloth), "Tissus", 20, "Vous n'avez pas assez de tissus.");
			index = AddCraft(typeof(ThrowPillow), "Tapis / Coussins", "Coussin Motifs", 55.0, 80.0, typeof(Cloth), "Tissus", 20, "Vous n'avez pas assez de tissus.");
			


			#endregion

			#region Footwear

			index = AddCraft(typeof(ElvenBoots), "Bottes", 1072902, 80.0, 105.0, typeof(Leather), 1044462, 15, 1044463);

      //      AddCraft(typeof(FurBoots), "Bottes", "Bottes de cuir", 50.0, 75.0, typeof(Cloth), "Tissus", 12, "Vous n'avez pas assez de tissus.");

            AddCraft(typeof(NinjaTabi), "Bottes", 1030210, 70.0, 95.0, typeof(Leather), 1044462, 15, 1044463);

			AddCraft(typeof(SamuraiTabi), "Bottes", 1030209, 20.0, 45.0, typeof(Leather), 1044462, 15, 1044463);

			AddCraft(typeof(Sandals), "Bottes", 1025901, 12.4, 37.4, typeof(Leather), 1044462, 15, 1044463);
			AddCraft(typeof(Shoes), "Bottes", 1025904, 16.5, 41.5, typeof(Leather), 1044462, 15, 1044463);
			AddCraft(typeof(Boots), "Bottes", 1025899, 33.1, 58.1, typeof(Leather), 1044462, 15, 1044463);
			AddCraft(typeof(ThighBoots), "Bottes", 1025906, 41.4, 66.4, typeof(Leather), 1044462, 15, 1044463);

			AddCraft(typeof(LeatherTalons), "Bottes", 1095728, 40.4, 65.4, typeof(Leather), 1044462, 15, 1044463);

			
			#endregion

			#region Leather Armor

			

			AddCraft(typeof(LeatherGorget), "Armures de Cuir", 1025063, 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
            AddCraft(typeof(LeatherCap), "Armures de Cuir", 1027609, 6.2, 31.2, typeof(Leather), 1044462, 2, 1044463);
            AddCraft(typeof(LeatherGloves), "Armures de Cuir", 1025062, 51.8, 76.8, typeof(Leather), 1044462, 3, 1044463);
            AddCraft(typeof(LeatherArms), "Armures de Cuir", 1025061, 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
            AddCraft(typeof(LeatherLegs), "Armures de Cuir", 1025067, 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
            AddCraft(typeof(LeatherChest), "Armures de Cuir", 1025068, 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);




			AddCraft(typeof(BrassardCuirSombre), "Armures de Cuir", "Brassard de Cuir Sombre", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(JambiereCuirSombre), "Armures de Cuir", "Jambiere de Cuir Sombre", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(PlastronCuirSombre), "Armures de Cuir", "Plastron de Cuir Sombre", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(BottesBarbare), "Armures de Cuir", "Bottes Barbare", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(BrassardBarbare), "Armures de Cuir", "Brassard Barbare", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(BrassardBarbare2), "Armures de Cuir", "Brassard Barbare2", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(CasqueBarbare), "Armures de Cuir", "Casque Barbare", 6.2, 31.2, typeof(Leather), 1044462, 2, 1044463);
			AddCraft(typeof(EpauliereBarbare), "Armures de Cuir", "�pauli�re Barbare", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(GantsBarbare), "Armures de Cuir", "Gants Barbare", 51.8, 76.8, typeof(Leather), 1044462, 3, 1044463);
			AddCraft(typeof(GorgetBarbare), "Armures de Cuir", "Gorget Barbare", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(JambiereBarbare), "Armures de Cuir", "Jambiere Barbare", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(JambiereBarbare2), "Armures de Cuir", "Jambi�re Barbare2", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(JambiereBarbare3), "Armures de Cuir", "Jambi�re Barbare3", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(PlastronBarbare), "Armures de Cuir", "Plastron Barbare", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare2), "Armures de Cuir", "Plastron Barbare2", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare3), "Armures de Cuir", "Plastron Barbare3", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare4), "Armures de Cuir", "Plastron Barbare4", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare5), "Armures de Cuir", "Plastron Barbare5", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare6), "Armures de Cuir", "Plastron Barbare5", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare7), "Armures de Cuir", "Plastron Barbare7", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);

















			index = AddCraft(typeof(LeatherJingasa), "Armures de Cuir", 1030177, 45.0, 70.0, typeof(Leather), 1044462, 4, 1044463);

            index = AddCraft(typeof(LeatherMempo), "Armures de Cuir", 1030181, 80.0, 105.0, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(LeatherDo), "Armures de Cuir", 1030182, 75.0, 100.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherHiroSode), "Armures de Cuir", 1030185, 55.0, 80.0, typeof(Leather), 1044462, 5, 1044463);

            index = AddCraft(typeof(LeatherSuneate), "Armures de Cuir", 1030193, 68.0, 93.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherHaidate), "Armures de Cuir", 1030197, 68.0, 93.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherNinjaPants), "Armures de Cuir", 1030204, 80.0, 105.0, typeof(Leather), 1044462, 13, 1044463);

            index = AddCraft(typeof(LeatherNinjaJacket), "Armures de Cuir", 1030206, 85.0, 110.0, typeof(Leather), 1044462, 13, 1044463);

            index = AddCraft(typeof(LeatherNinjaBelt), "Armures de Cuir", 1030203, 50.0, 75.0, typeof(Leather), 1044462, 5, 1044463);

            index = AddCraft(typeof(LeatherNinjaMitts), "Armures de Cuir", 1030205, 65.0, 90.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherNinjaHood), "Armures de Cuir", 1030201, 90.0, 115.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(LeafChest), "Armures de Cuir", 1032667, 75.0, 100.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(LeafArms), "Armures de Cuir", 1032670, 60.0, 85.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeafGloves), "Armures de Cuir", 1032668, 60.0, 85.0, typeof(Leather), 1044462, 10, 1044463);

            index = AddCraft(typeof(LeafLegs), "Armures de Cuir", 1032671, 75.0, 100.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(LeafGorget), "Armures de Cuir", 1032669, 65.0, 90.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeafTonlet), "Armures de Cuir", 1032672, 70.0, 95.0, typeof(Leather), 1044462, 12, 1044463);

    
            #endregion

            #region Cloth Armor
         
       
            #endregion

            #region Studded Armor
            AddCraft(typeof(StuddedGorget), "Armures Clout�e", 1025078, 78.8, 103.8, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(StuddedGloves), "Armures Clout�e", 1025077, 82.9, 107.9, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(StuddedArms), "Armures Clout�e", 1025076, 87.1, 112.1, typeof(Leather), 1044462, 10, 1044463);
            AddCraft(typeof(StuddedLegs), "Armures Clout�e", 1025082, 91.2, 116.2, typeof(Leather), 1044462, 12, 1044463);
            AddCraft(typeof(StuddedChest), "Armures Clout�e", 1025083, 94.0, 119.0, typeof(Leather), 1044462, 14, 1044463);




			AddCraft(typeof(BrassardCloute), "Armures Clout�e", "Brassard Clout�", 58.0, 83.0, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(JupeCloute), "Armures Clout�e", "Jupe Clout�", 58.0, 83.0, typeof(Leather), 1044462, 12, 1044463);

			AddCraft(typeof(PlastronCloute), "Armures Clout�e", "Plastron Clout�", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute2), "Armures Clout�e", "Plastron Clout�2", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute3), "Armures Clout�e", "Plastron Clout�3", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute4), "Armures Clout�e", "Plastron Clout�4", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);


			index = AddCraft(typeof(StuddedMempo), "Armures Clout�e", 1030216, 80.0, 105.0, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(StuddedDo), "Armures Clout�e", 1030183, 95.0, 120.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(StuddedHiroSode), "Armures Clout�e", 1030186, 85.0, 110.0, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(StuddedSuneate), "Armures Clout�e", 1030194, 92.0, 117.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(StuddedHaidate), "Armures Clout�e", 1030198, 92.0, 117.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(HideChest), "Armures Clout�e", 1032651, 85.0, 110.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(HidePauldrons), "Armures Clout�e", 1032654, 75.0, 100.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(HideGloves), "Armures Clout�e", 1032652, 75.0, 100.0, typeof(Leather), 1044462, 10, 1044463);

            index = AddCraft(typeof(HidePants), "Armures Clout�e", 1032655, 92.0, 117.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(HideGorget), "Armures Clout�e", 1032653, 90.0, 115.0, typeof(Leather), 1044462, 12, 1044463);

            #endregion

            #region Female Armor
            AddCraft(typeof(LeatherShorts), "Armures pour Femme", 1027168, 62.2, 87.2, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(LeatherSkirt), "Armures pour Femme", 1027176, 58.0, 83.0, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(LeatherBustierArms), "Armures pour Femme", 1027178, 58.0, 83.0, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(StuddedBustierArms), "Armures pour Femme", 1027180, 82.9, 107.9, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(FemaleLeatherChest), "Armures pour Femme", 1027174, 62.2, 87.2, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(FemaleStuddedChest), "Armures pour Femme", 1027170, 87.1, 112.1, typeof(Leather), 1044462, 10, 1044463);

  
            #endregion

            #region Bone Armor
/*
            index = AddCraft(typeof(CuffsOfTheArchmage), 1049149, 1157348, 120.0, 120.1, typeof(Cloth), "Tissus", 8, "Vous n'avez pas assez de tissus.");
            AddRes(index, typeof(MidnightBracers), 1061093, 1, 1044253);
            AddRes(index, typeof(BloodOfTheDarkFather), 1157343, 5, 1044253);
            AddRes(index, typeof(DarkSapphire), 1032690, 4, 1044253);
            ForceNonExceptional(index);
            AddRecipe(index, (int)TailorRecipe.CuffsOfTheArchmage);*/
            #endregion

            // Set the overridable material
            SetSubRes(typeof(Leather), 1049150);

            // Add every material you want the player to be able to choose from
            // This will override the overridable material
            AddSubRes(typeof(Leather), "Cuir", 0.0, 1049312);
			AddSubRes(typeof(LupusLeather), "Lupus", 65.0, 1049312);
			AddSubRes(typeof(ReptilienLeather), "Reptilien", 70.0, 1049312);
			AddSubRes(typeof(GeantLeather), "Geant", 75.0, 1049312);
			AddSubRes(typeof(OphidienLeather), "Ophidien", 80.0, 1049312);
			AddSubRes(typeof(ArachnideLeather), "Arachnide", 85.0, 1049312);
			AddSubRes(typeof(DragoniqueLeather), "Dragonique", 90.0, 1049312);
			AddSubRes(typeof(DemoniaqueLeather), "Demoniaque", 95.0, 1049312);
			AddSubRes(typeof(AncienLeather), "Ancien", 99.0, 1049312);

            MarkOption = true;
            Repair = true;
            CanEnhance = true;
            CanAlter = true;
        } 
        #endregion

        private void CutUpCloth(Mobile m, CraftItem craftItem, ITool tool)
        {
            PlayCraftEffect(m);

            Timer.DelayCall(TimeSpan.FromSeconds(Delay), () =>
                {
                    if (m.Backpack == null)
                    {
                        m.SendGump(new CraftGump(m, this, tool, null));
                    }

                    Dictionary<int, int> bolts = new Dictionary<int, int>();
                    List<Item> toConsume = new List<Item>();
                    object num = null;
                    Container pack = m.Backpack;

                    foreach (Item item in pack.Items)
                    {
                        if (item.GetType() == typeof(BoltOfCloth))
                        {
                            if (!bolts.ContainsKey(item.Hue))
                            {
                                toConsume.Add(item);
                                bolts[item.Hue] = item.Amount;
                            }
                            else
                            {
                                toConsume.Add(item);
                                bolts[item.Hue] += item.Amount;
                            }
                        }
                    }

                    if (bolts.Count == 0)
                    {
                        num = 1044253; // You don't have the components needed to make that.
                    }
                    else
                    {
                        foreach (Item item in toConsume)
                        {
                            item.Delete();
                        }

                        foreach (KeyValuePair<int, int> kvp in bolts)
                        {
                            UncutCloth cloth = new UncutCloth(kvp.Value * 50)
                            {
                                Hue = kvp.Key
                            };

                            DropItem(m, cloth, tool);
                        }
                    }

                    if (tool != null)
                    {
                        tool.UsesRemaining--;

                        if (tool.UsesRemaining <= 0 && !tool.Deleted)
                        {
                            tool.Delete();
                            m.SendLocalizedMessage(1044038);
                        }
                        else
                        {
                            m.SendGump(new CraftGump(m, this, tool, num));
                        }
                    }

                    ColUtility.Free(toConsume);
                    bolts.Clear();
                });
        }

        private void CombineCloth(Mobile m, CraftItem craftItem, ITool tool)
        {
            PlayCraftEffect(m);

            Timer.DelayCall(TimeSpan.FromSeconds(Delay), () =>
                {
                    if (m.Backpack == null)
                    {
                        m.SendGump(new CraftGump(m, this, tool, null));
                    }

                    Container pack = m.Backpack;

                    Dictionary<int, int> cloth = new Dictionary<int, int>();
                    List<Item> toConsume = new List<Item>();
                    object num = null;

                    foreach (Item item in pack.Items)
                    {
                        Type t = item.GetType();

                        if (t == typeof(UncutCloth) || t == typeof(Cloth) || t == typeof(CutUpCloth))
                        {
                            if (!cloth.ContainsKey(item.Hue))
                            {
                                toConsume.Add(item);
                                cloth[item.Hue] = item.Amount;
                            }
                            else
                            {
                                toConsume.Add(item);
                                cloth[item.Hue] += item.Amount;
                            }
                        }
                    }

                    if (cloth.Count == 0)
                    {
                        num = 1044253; // You don't have the components needed to make that.
                    }
                    else
                    {
                        foreach (Item item in toConsume)
                        {
                            item.Delete();
                        }

                        foreach (KeyValuePair<int, int> kvp in cloth)
                        {
                            UncutCloth c = new UncutCloth(kvp.Value)
                            {
                                Hue = kvp.Key
                            };

                            DropItem(m, c, tool);
                        }
                    }

                    if (tool != null)
                    {
                        tool.UsesRemaining--;

                        if (tool.UsesRemaining <= 0 && !tool.Deleted)
                        {
                            tool.Delete();
                            m.SendLocalizedMessage(1044038);
                        }
                        else
                        {
                            m.SendGump(new CraftGump(m, this, tool, num));
                        }
                    }

                    ColUtility.Free(toConsume);
                    cloth.Clear();
                });
        }

        private void DropItem(Mobile from, Item item, ITool tool)
        {
            if (tool is Item && ((Item)tool).Parent is Container)
            {
                Container cntnr = (Container)((Item)tool).Parent;

                if (!cntnr.TryDropItem(from, item, false))
                {
                    if (cntnr != from.Backpack)
                        from.AddToBackpack(item);
                    else
                        item.MoveToWorld(from.Location, from.Map);
                }
            }
            else
            {
                from.AddToBackpack(item);
            }
        }
    }
}
