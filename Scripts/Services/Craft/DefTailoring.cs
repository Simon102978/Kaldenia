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


			index = AddCraft(typeof(Jupe), "Pantalon",  "Pantalon", 61.4, 81.4, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe2), "Pantalon",  "Jupe2", 83.8, 103.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe3), "Pantalon",  "Jupe3", 73.1, 93.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe4), "Pantalon",  "Jupe4", 79.6, 99.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe5), "Pantalon",  "Jupe5", 51.8, 71.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe6), "Pantalon",  "Jupe6", 77.0, 97.0, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeVoiles), "Pantalon",  "Jupe à Voiles", 87.8, 107.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeVoiles2), "Pantalon",  "Jupe à Voiles2", 57.2,77.2, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte), "Pantalon",  "Jupe Courte", 93.6,113.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte2), "Pantalon",  "Jupe Courte2", 79.3,99.3, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe7), "Pantalon",  "Jupe7", 64.2,84.2, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte3), "Pantalon",  "Jupe Courte3", 49.9,69.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte4), "Pantalon",  "Jupe Courte4", 63.5,83.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte5), "Pantalon",  "Jupe Courte5", 74.2,94.2, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte6), "Pantalon",  "Jupe Courte6", 88.8,108.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeCourte7), "Pantalon",  "Jupe Courte7", 46.7,66.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeLacee), "Pantalon",  "Jupe Lacée", 51.9,71.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeLacee2), "Pantalon",  "Jupe Lacée2", 72.1,92.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(JupeLacee3), "Pantalon",  "Jupe Lacée3", 62.1,82.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Kilt3), "Pantalon",  "Kilt3", 53.0,73.0, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Kilt2), "Pantalon",  "Kilt2", 75.0,95.0, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pareo), "Pantalon",  "Paréo", 52.3,72.3, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(PareoCourt), "Pantalon",  "Paréo Court", 92.6,112.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail), "Haut",  "Chandail", 77.9,97.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Camisole), "Haut",  "Camisole", 77.5,97.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail2), "Haut",  "Chandail2", 84.5,104.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique), "Haut",  "Tunique", 67.0,87.0, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise), "Haut",  "Chemise", 52.1,72.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe2), "Robe",  "Robe2", 63.7,83.7, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique2), "Haut",  "Tunique2", 73.8,93.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Uniforme), "Haut",  "Uniforme", 56.6,76.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe19), "Robe",  "Robe19", 61.2,81.2, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeCourte), "Robe",  "Robe Courte", 82.1,102.1, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe3), "Robe",  "Robe3", 94.7,114.7, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe4), "Robe",  "Robe4", 79.1,99.1, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe11), "Pantalon",  "Jupe11", 47.8,67.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeProvocante), "Robe",  "Robe Provocante", 73.9,93.9, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bustier), "Haut",  "Bustier", 49.9,69.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bustier2), "Haut",  "Bustier2", 88.6,108.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bustier3), "Haut",  "Bustier3", 81.4,101.4, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe8), "Pantalon",  "Jupe8", 52.1,72.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe9), "Pantalon",  "Jupe9", 56.7,76.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Jupe10), "Pantalon",  "Jupe10", 83.1,103.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe5), "Robe",  "Robe5", 81.7,101.7, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe6), "Robe",  "Robe6", 58.1,78.1, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe7), "Robe",  "Robe7", 97.3,117.3, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe8), "Robe",  "Robe8", 91.1,111.1, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe9), "Robe",  "Robe9", 70.0,90.0, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe10), "Robe",  "Robe10", 97.3,117.3, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe11), "Robe",  "Robe11", 60.0,80.0, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe12), "Robe",  "Robe12", 94.1,114.1, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe13), "Robe",  "Robe13", 65.0,85.0, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe14), "Robe",  "Robe14", 52.3,72.3, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe15), "Robe",  "Robe15", 55.4,75.4, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe16), "Robe",  "Robe16", 84.6,104.6, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeProvocante2), "Robe",  "RobeProvocante2", 55.6,75.6, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeProvocante3), "Robe",  "RobeProvocante3", 66.6,86.6, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeProvocante4), "Robe",  "RobeProvocante4", 84.3,104.3, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeProvocante5), "Robe",  "RobeProvocante5", 51.6,71.6, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(RobeProvocante6), "Robe",  "RobeProvocante6", 76.0,96.0, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe17), "Robe",  "Robe17", 60.0,80.0, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Robe18), "Robe",  "Robe18", 78.8,98.8, typeof(Cloth),"Tissues", 16, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge), "Robe", "Toge", 46.4,66.4, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge2), "Robe",  "Toge2", 71.7,91.7, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge3), "Robe",  "Toge3", 46.4,66.4, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge4), "Robe",  "Toge4", 70.6,90.6, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge5), "Robe",  "Toge5", 66.1,86.1, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge6), "Robe",  "Toge6", 78.7,98.7, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge7), "Robe",  "Toge7", 86.3,106.3, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toge8), "Robe",  "Toge8", 50.9,70.9, typeof(Cloth),"Tissues", 18, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar), "Haut", "Tabar", 72.3,92.3, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar1), "Haut",  "Tabar1", 67.0,87.0, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar2), "Haut",  "Tabar2", 84.2,104.2, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar3), "Haut",  "Tabar3", 47.0,67.0, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar4), "Haut",  "Tabar4", 93.3,113.3, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar5), "Haut",  "Tabar5", 56.9,76.9, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar6), "Haut",  "Tabar6", 61.6,81.6, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar7), "Haut",  "Tabar7", 66.4,86.4, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar8), "Haut",  "Tabar8", 58.8,78.8, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar9), "Haut",  "Tabar9", 50.5,70.5, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar10), "Haut",  "Tabar10", 69.4,89.4, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tabar11), "Haut",  "Tabar11", 61.3,81.3, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail3), "Haut",  "Chandail3", 90.4,110.4, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail4), "Haut",  "Chandail4", 81.7,101.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail5), "Haut",  "Chandail5", 81.7,101.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail6), "Haut",  "Chandail6", 78.7,98.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail7), "Haut",  "Chandail7", 73.0,93.0, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail8), "Haut",  "Chandail8", 96.6,116.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail9), "Haut",  "Chandail9", 85.2,105.2, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chandail10), "Haut",  "Chandail10", 63.7,83.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise2), "Haut",  "Chemise2", 53.2,73.2, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise3), "Haut",  "Chemise3", 88.1,108.1, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise4), "Haut",  "Chemise4", 97.9,117.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise5), "Haut",  "Chemise5", 91.8,111.8, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise6), "Haut",  "Chemise6", 65.4,85.4, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Chemise7), "Haut",  "Chemise7", 97.2,117.2, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Doublet), "Haut",  "Doublet", 58.3,78.3, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Doublet2), "Haut",  "Doublet2", 84.7,104.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Doublet3), "Haut",  "Doublet3", 93.9,113.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Doublet4), "Haut",  "Doublet4", 69.9,89.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Doublet5), "Haut",  "Doublet5", 70.7,90.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Doublet6), "Haut",  "Doublet6", 56.5,76.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique3), "Haut",  "Tunique3", 51.5,71.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique4), "Haut",  "Tunique4", 77.6,97.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique5), "Haut",  "Tunique5", 74.9,94.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique6), "Haut",  "Tunique6", 69.9,89.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique7), "Haut",  "Tunique7", 76.3,96.3, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique8), "Haut",  "Tunique8", 88.5,108.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique9), "Haut",  "Tunique9", 92.5,112.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Tunique10), "Haut",  "Tunique10", 65.7,85.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon1), "Pantalon",  "Pantalon1", 90.8,110.8, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon2), "Pantalon",  "Pantalon2", 58.0,78.0, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon3), "Pantalon",  "Pantalon3", 92.6,112.6, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon4), "Pantalon",  "Pantalon4", 51.8,71.8, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon5), "Pantalon",  "Pantalon5", 60.5,80.5, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon6), "Pantalon",  "Pantalon6", 62.1,82.1, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon7), "Pantalon",  "Pantalon7", 45.4,65.4, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon8), "Pantalon",  "Pantalon8", 46.2,66.2, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon9), "Pantalon",  "Pantalon9", 75.7,95.7, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon10), "Pantalon",  "Pantalon10", 63.6,83.6, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon11), "Pantalon",  "Pantalon11", 72.9,92.9, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Pantalon12), "Pantalon",  "Pantalon12", 53.3,73.3, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Salopette), "Pantalon",  "Salopette", 81.3,101.3, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Manteau), "Haut",  "Manteau", 66.5,86.5, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Manteau2), "Haut",  "Manteau2", 71.0,91.0, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Veste), "Haut",  "Veste", 62.7,82.7, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Veste2), "Haut",  "Veste2", 82.6,102.6, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Veste3), "Haut",  "Veste3", 48.9,68.9, typeof(Cloth),"Tissues", 8, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Carquois), 1015283,  "Carquois", 60.6,80.6, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau), 1015283,  "fourreau", 80.7,100.7, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau2), 1015283,  "fourreau2", 98.1,118.1, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau3), 1015283,  "fourreau3", 66.9,86.9, typeof(Leather),"cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Foulard), 1015283,  "Foulard", 65.5,85.5, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Foulard2), 1015283,  "Foulard2", 57.2,77.2, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Foulard3), 1015283,  "Foulard3", 75.5,95.5, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Foulard4), 1015283,  "Foulard4", 56.8,76.8, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cocarde), 1015283,  "Cocarde", 59.0,79.0, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Capuche), 1011375,  "Capuche", 55.3,75.3, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Capuche2), 1011375,  "Capuche2", 97.0,117.0, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(TeteCoyote), 1011375,  "Tete de Coyote", 85.5,105.5, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(TeteTaureau), 1011375,  "Tete de Taureau", 89.3,109.3, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Toque), 1011375,  "Toque", 89.4,109.4, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Turban), 1011375,  "Turban", 90.7,110.7, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(VoileTete), 1011375,  "Voile de Tête", 84.0,104.0, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(VoileTeteLong), 1011375,  "Voile de tête long", 94.8,114.8, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(BourseCeinture), 1015283,  "Bourse de Ceinture", 53.4,73.4, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture), 1015283,  "Ceinture", 52.4,72.4, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture2), 1015283,  "Ceinture2", 63.8,83.8, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture3), 1015283,  "Ceinture3", 87.4,107.4, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture4), 1015283,  "Ceinture4", 53.7,73.7, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture5), 1015283,  "Ceinture5", 90.9,110.9, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture6), 1015283,  "Ceinture6", 94.8,114.8, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture7), 1015283,  "Ceinture7", 56.4,76.4, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture8), 1015283,  "Ceinture8", 59.6,79.6, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture9), 1015283,  "Ceinture9", 80.5,100.5, typeof(Cloth),"Tissues", 10, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes), 1015288,  1015288, 45.7,65.7, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes2), 1015288,  "Bottes2", 71.8,91.8, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes3), 1015288,  "Bottes3", 75.7,95.7, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes4), 1015288,  "Bottes4", 57.6,77.6, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes5), 1015288,  "Bottes5", 52.0,72.0, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes6), 1015288,  "Bottes6", 85.6,105.6, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes7), 1015288,  "Bottes7", 74.1,94.1, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes8), 1015288,  "Bottes8", 69.6,89.6, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes9), 1015288,  "Bottes9", 86.9,106.9, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Bottes10), 1015288,  "Bottes10", 62.8,82.8, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape), 1015283, "Cape", 51.9,71.9, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape2), 1015283,  "Cape2", 59.7,79.7, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape3), 1015283,  "Cape3", 98.5,118.5, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape4), 1015283,  "Cape4", 85.7,105.7, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape5), 1015283,  "Cape5", 77.4,97.4, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape6), 1015283,  "Cape6", 65.6,85.6, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape7), 1015283,  "Cape7", 56.5,76.5, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape8), 1015283,  "Cape8", 92.0,112.0, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape9), 1015283,  "Cape9", 72.6,92.6, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape10), 1015283,  "Cape10", 49.1,69.1, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Cape11), 1015283,  "Cape11", 83.2,103.2, typeof(Cloth),"Tissues", 12, "Vous n'avez pas assez de tissue.");

			index = AddCraft(typeof(ChapeauPirate), 1011375,  "Chapeau de Pirate", 53.3,73.3, typeof(Cloth),"Tissues", 6, "Vous n'avez pas assez de tissue.");
			index = AddCraft(typeof(Ceinture10), 1015283,  "Ceinture10", 72.5,92.5, typeof(Cloth), "Tissues", 5, "Vous n'avez pas assez de tissue.");























            #region Materials
            index = AddCraft(typeof(CutUpCloth), 1015283, 1044458, 0.0, 0.0, typeof(BoltOfCloth), 1044453, 1, 1044253);
            AddCraftAction(index, CutUpCloth);

            index = AddCraft(typeof(CombineCloth), 1015283, 1044459, 0.0, 0.0, typeof(Cloth), 1044455, 1, 1044253);
            AddCraftAction(index, CombineCloth);

    /*        index = AddCraft(typeof(PowderCharge), 1015283, 1116160, 0.0, 50.0, typeof(Cloth), 1044455, 1, 1044253);
            AddRes(index, typeof(BlackPowder), 1095826, 4, 1044253);
            SetUseAllRes(index, true);

            index = AddCraft(typeof(AbyssalCloth), 1015283, 1113350, 110.0, 160.0, typeof(Cloth), 1044455, 50, 1044253);
            AddRes(index, typeof(CrystallineBlackrock), 1077568, 1, 1044253);
            SetItemHue(index, 2075);*/
            #endregion

            #region Hats
            AddCraft(typeof(SkullCap), 1011375, 1025444, 0.0, 25.0, typeof(Cloth), 1044455, 2, 1044287);
            AddCraft(typeof(Bandana), 1011375, 1025440, 0.0, 25.0, typeof(Cloth), 1044455, 2, 1044287);
            AddCraft(typeof(FloppyHat), 1011375, 1025907, 6.2, 31.2, typeof(Cloth), 1044455, 11, 1044287);
            AddCraft(typeof(Cap), 1011375, 1025909, 6.2, 31.2, typeof(Cloth), 1044455, 11, 1044287);
            AddCraft(typeof(WideBrimHat), 1011375, 1025908, 6.2, 31.2, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(StrawHat), 1011375, 1025911, 6.2, 31.2, typeof(Cloth), 1044455, 10, 1044287);
            AddCraft(typeof(TallStrawHat), 1011375, 1025910, 6.7, 31.7, typeof(Cloth), 1044455, 13, 1044287);
            AddCraft(typeof(WizardsHat), 1011375, 1025912, 7.2, 32.2, typeof(Cloth), 1044455, 15, 1044287);
            AddCraft(typeof(Bonnet), 1011375, 1025913, 6.2, 31.2, typeof(Cloth), 1044455, 11, 1044287);
            AddCraft(typeof(FeatheredHat), 1011375, 1025914, 6.2, 31.2, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(TricorneHat), 1011375, 1025915, 6.2, 31.2, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(JesterHat), 1011375, 1025916, 7.2, 32.2, typeof(Cloth), 1044455, 15, 1044287);

            AddCraft(typeof(FlowerGarland), 1011375, 1028965, 10.0, 35.0, typeof(Cloth), 1044455, 5, 1044287);

            AddCraft(typeof(ClothNinjaHood), 1011375, 1030202, 80.0, 105.0, typeof(Cloth), 1044455, 13, 1044287);

            AddCraft(typeof(Kasa), 1011375, 1030211, 60.0, 85.0, typeof(Cloth), 1044455, 12, 1044287);

            AddCraft(typeof(OrcMask), 1011375, 1025147, 75.0, 100.0, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(BearMask), 1011375, 1025445, 77.5, 102.5, typeof(Cloth), 1044455, 15, 1044287);
            AddCraft(typeof(DeerMask), 1011375, 1025447, 77.5, 102.5, typeof(Cloth), 1044455, 15, 1044287);
            AddCraft(typeof(TribalMask), 1011375, 1025449, 82.5, 107.5, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(HornedTribalMask), 1011375, 1025451, 82.5, 107.5, typeof(Cloth), 1044455, 12, 1044287);

   /*         index = AddCraft(typeof(ChefsToque), 1011375, 1109618, 6.2, 21.2, typeof(Cloth), 1044455, 11, 1044287);
            AddRecipe(index, (int)TailorRecipe.ChefsToque);

            index = AddCraft(typeof(KrampusMinionHat), 1011375, 1125639, 100.0, 500.0, typeof(Cloth), 1044455, 8, 1044287);
            AddRecipe(index, (int)TailorRecipe.KrampusMinionHat);

            index = AddCraft(typeof(AssassinsCowl), 1011375, 1126024, 90.0, 110.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(VileTentacles), 1113333, 5, 1044253);
            AddRecipe(index, (int)TailorRecipe.AssassinsCowl);

            index = AddCraft(typeof(MagesHood), 1011375, 1159227, 90.0, 110.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(VoidCore), 1113334, 5, 1044253);
            AddRecipe(index, (int)TailorRecipe.MagesHood);

            index = AddCraft(typeof(CowlOfTheMaceAndShield), 1011375, 1159228, 120.0, 215.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(MaceAndShieldGlasses), 1073381, 1, 1044253);
            AddRes(index, typeof(VileTentacles), 1113333, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.CowlOfTheMaceAndShield);
            ForceExceptional(index);

            index = AddCraft(typeof(MagesHoodOfScholarlyInsight), 1011375, 1159229, 120.0, 215.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(TheScholarsHalo), 1157354, 1, 1044253);
            AddRes(index, typeof(VoidCore), 1113334, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.MagesHoodOfScholarlyInsight);
            ForceExceptional(index);
   */
            #endregion

            #region Shirts/Pants
            AddCraft(typeof(Doublet), "Haut", 1028059, 0, 25.0, typeof(Cloth), 1044455, 8, 1044287);
            AddCraft(typeof(Shirt), "Haut", 1025399, 20.7, 45.7, typeof(Cloth), 1044455, 8, 1044287);
            AddCraft(typeof(FancyShirt), "Haut", 1027933, 24.8, 49.8, typeof(Cloth), 1044455, 8, 1044287);
            AddCraft(typeof(Tunic), "Haut", 1028097, 00.0, 25.0, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(Surcoat), "Haut", 1028189, 8.2, 33.2, typeof(Cloth), 1044455, 14, 1044287);
            AddCraft(typeof(PlainDress), "Haut", 1027937, 12.4, 37.4, typeof(Cloth), 1044455, 10, 1044287);
            AddCraft(typeof(FancyDress), "Haut", 1027935, 33.1, 58.1, typeof(Cloth), 1044455, 12, 1044287);
            AddCraft(typeof(Cloak), "Haut", 1025397, 41.4, 66.4, typeof(Cloth), 1044455, 14, 1044287);
            AddCraft(typeof(Robe), "Haut", 1027939, 53.9, 78.9, typeof(Cloth), 1044455, 16, 1044287);
            AddCraft(typeof(JesterSuit), "Haut", 1028095, 8.2, 33.2, typeof(Cloth), 1044455, 24, 1044287);

            AddCraft(typeof(FurCape), "Haut", 1028969, 35.0, 60.0, typeof(Cloth), 1044455, 13, 1044287);
            AddCraft(typeof(GildedDress), "Haut", 1028973, 37.5, 62.5, typeof(Cloth), 1044455, 16, 1044287);
            AddCraft(typeof(FormalShirt), "Haut", 1028975, 26.0, 51.0, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(ClothNinjaJacket), "Haut", 1030207, 75.0, 100.0, typeof(Cloth), 1044455, 12, 1044287);

            index = AddCraft(typeof(Kamishimo), "Haut", 1030212, 75.0, 100.0, typeof(Cloth), 1044455, 15, 1044287);

            index = AddCraft(typeof(HakamaShita), "Haut", 1030215, 40.0, 65.0, typeof(Cloth), 1044455, 14, 1044287);

            index = AddCraft(typeof(MaleKimono), "Haut", 1030189, 50.0, 75.0, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(FemaleKimono), "Haut", 1030190, 50.0, 75.0, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(JinBaori), "Haut", 1030220, 30.0, 55.0, typeof(Cloth), 1044455, 12, 1044287);

            AddCraft(typeof(ShortPants), "Haut", 1025422, 24.8, 49.8, typeof(Cloth), 1044455, 6, 1044287);
            AddCraft(typeof(LongPants), "Haut", 1025433, 24.8, 49.8, typeof(Cloth), 1044455, 8, 1044287);
            AddCraft(typeof(Kilt), "Haut", 1025431, 20.7, 45.7, typeof(Cloth), 1044455, 8, 1044287);
            AddCraft(typeof(Skirt), "Haut", 1025398, 29.0, 54.0, typeof(Cloth), 1044455, 10, 1044287);

            AddCraft(typeof(FurSarong), "Haut", 1028971, 35.0, 60.0, typeof(Cloth), 1044455, 12, 1044287);

            index = AddCraft(typeof(Hakama), "Haut", 1030213, 50.0, 75.0, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(TattsukeHakama), "Haut", 1030214, 50.0, 75.0, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(ElvenShirt), "Haut", 1032661, 80.0, 105.0, typeof(Cloth), 1044455, 10, 1044287);

            index = AddCraft(typeof(ElvenDarkShirt), "Haut", 1032662, 80.0, 105.0, typeof(Cloth), 1044455, 10, 1044287);

            index = AddCraft(typeof(ElvenPants), "Haut", 1032665, 80.0, 105.0, typeof(Cloth), 1044455, 12, 1044287);

            index = AddCraft(typeof(MaleElvenRobe), "Haut", 1032659, 80.0, 105.0, typeof(Cloth), 1044455, 30, 1044287);

            index = AddCraft(typeof(FemaleElvenRobe), "Haut", 1032660, 80.0, 105.0, typeof(Cloth), 1044455, 30, 1044287);

            index = AddCraft(typeof(WoodlandBelt), "Haut", 1032639, 80.0, 105.0, typeof(Cloth), 1044455, 10, 1044287);

 /*           index = AddCraft(typeof(Robe), "Haut", 1095256, 53.9, 78.9, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(FancyRobe), "Haut", 1095258, 53.9, 78.9, typeof(Cloth), 1044455, 16, 1044287);

            index = AddCraft(typeof(RobeofRite), "Haut", 1153510, 101.5, 120.0, typeof(Leather), 1044462, 6, 1044253);
            AddRes(index, typeof(FireRuby), 1032695, 1, 1044253);
            AddRes(index, typeof(GoldDust), 1098337, 5, 1044253);
            AddRes(index, typeof(AbyssalCloth), 1113350, 6, 1044253);
            ForceNonExceptional(index);
 */
    /*        index = AddCraft(typeof(GuildedKilt), "Haut", "Kilt", 82.8, 97.8, typeof(Cloth), 1044455, 8, 1044287);
            AddRecipe(index, (int)TailorRecipe.GuildedKilt);

            index = AddCraft(typeof(CheckeredKilt), "Haut", 1109620, 41.4, 56.4, typeof(Cloth), 1044455, 8, 1044287);
            AddRecipe(index, (int)TailorRecipe.CheckeredKilt);

            index = AddCraft(typeof(FancyKilt), "Haut", 1109621, 20.7, 25.7, typeof(Cloth), 1044455, 8, 1044287);
            AddRecipe(index, (int)TailorRecipe.FancyKilt);

            index = AddCraft(typeof(FloweredDress), "Haut", 1109622, 75.0, 90.0, typeof(Cloth), 1044455, 18, 1044287);
            AddRecipe(index, (int)TailorRecipe.FloweredDress);

            index = AddCraft(typeof(EveningGown), "Haut", 1109625, 75, 90.0, typeof(Cloth), 1044455, 18, 1044287);
            AddRecipe(index, (int)TailorRecipe.EveningGown);
	*/
            #endregion

            #region Misc
            AddCraft(typeof(BodySash), 1015283, 1025441, 4.1, 29.1, typeof(Cloth), 1044455, 4, 1044287);
            AddCraft(typeof(HalfApron), 1015283, 1025435, 20.7, 45.7, typeof(Cloth), 1044455, 6, 1044287);
            AddCraft(typeof(FullApron), 1015283, 1025437, 29.0, 54.0, typeof(Cloth), 1044455, 10, 1044287);

            AddCraft(typeof(Obi), 1015283, 1030219, 20.0, 45.0, typeof(Cloth), 1044455, 6, 1044287);

            index = AddCraft(typeof(ElvenQuiver), 1015283, 1032657, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            AddRecipe(index, (int)TailorRecipe.ElvenQuiver);

            index = AddCraft(typeof(QuiverOfFire), 1015283, 1073109, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            AddRes(index, typeof(FireRuby), 1032695, 15, 1042081);
            AddRecipe(index, (int)TailorRecipe.QuiverOfFire);

            index = AddCraft(typeof(QuiverOfIce), 1015283, 1073110, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            AddRes(index, typeof(WhitePearl), 1032694, 15, 1042081);
            AddRecipe(index, (int)TailorRecipe.QuiverOfIce);

            index = AddCraft(typeof(QuiverOfBlight), 1015283, 1073111, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            AddRes(index, typeof(Blight), 1032675, 10, 1042081);
            AddRecipe(index, (int)TailorRecipe.QuiverOfBlight);

            index = AddCraft(typeof(QuiverOfLightning), 1015283, 1073112, 65.0, 115.0, typeof(Leather), 1044462, 28, 1044463);
            AddRes(index, typeof(Corruption), 1032676, 10, 1042081);
            AddRecipe(index, (int)TailorRecipe.QuiverOfLightning);

            index = AddCraft(typeof(LeatherContainerEngraver), 1015283, 1072152, 75.0, 100.0, typeof(Bone), 1049064, 1, 1049063);
            AddRes(index, typeof(Leather), 1044462, 6, 1044463);
            AddRes(index, typeof(SpoolOfThread), 1073462, 2, 1073463);
            AddRes(index, typeof(Dyes), 1024009, 1, 1044253);

            AddCraft(typeof(GargoyleHalfApron), 1015283, 1099568, 20.7, 45.7, typeof(Cloth), 1044455, 6, 1044287);
            AddCraft(typeof(Sash), 1015283, 1115388, 4.1, 29.1, typeof(Cloth), 1044455, 4, 1044287);

            AddCraft(typeof(OilCloth), 1015283, 1041498, 74.6, 99.6, typeof(Cloth), 1044455, 1, 1044287);
            AddCraft(typeof(GozaMatEastDeed), 1015283, 1030404, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(GozaMatSouthDeed), 1015283, 1030405, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(SquareGozaMatEastDeed), 1015283, 1030407, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(SquareGozaMatSouthDeed), 1015283, 1030406, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(BrocadeGozaMatEastDeed), 1015283, 1030408, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(BrocadeGozaMatSouthDeed), 1015283, 1030409, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(BrocadeSquareGozaMatEastDeed), 1015283, 1030411, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(BrocadeSquareGozaMatSouthDeed), 1015283, 1030410, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);
            AddCraft(typeof(SquareGozaMatDeed), 1015283, 1113621, 55.0, 80.0, typeof(Cloth), 1044455, 25, 1044287);

 /*           index = AddCraft(typeof(MaceBelt), 1015283, 1126020, 90.0, 110.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(Lodestone), 1113332, 5, 1044253);
            AddRecipe(index, (int)TailorRecipe.MaceBelt);

            index = AddCraft(typeof(SwordBelt), 1015283, 1126021, 90.0, 110.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(Lodestone), 1113332, 5, 1044253);
            AddRecipe(index, (int)TailorRecipe.SwordBelt);

            index = AddCraft(typeof(DaggerBelt), 1015283, 1159210, 90.0, 110.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(Lodestone), 1113332, 5, 1044253);
            AddRecipe(index, (int)TailorRecipe.DaggerBelt);

            index = AddCraft(typeof(ElegantCollar), 1015283, 1159224, 90.0, 110.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(FeyWings), 1113332, 5, 1044253);
            AddRecipe(index, (int)TailorRecipe.ElegantCollar);

            index = AddCraft(typeof(CrimsonMaceBelt), 1015283, 1159211, 120.0, 215.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(CrimsonCincture), 1075043, 1, 1044253);
            AddRes(index, typeof(Lodestone), 1113348, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.CrimsonMaceBelt);
            ForceExceptional(index);

            index = AddCraft(typeof(CrimsonSwordBelt), 1015283, 1159212, 120.0, 215.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(CrimsonCincture), 1075043, 1, 1044253);
            AddRes(index, typeof(Lodestone), 1113348, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.CrimsonSwordBelt);
            ForceExceptional(index);

            index = AddCraft(typeof(CrimsonDaggerBelt), 1015283, 1159213, 120.0, 215.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(CrimsonCincture), 1075043, 1, 1044253);
            AddRes(index, typeof(Lodestone), 1113348, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.CrimsonDaggerBelt);
            ForceExceptional(index);

            index = AddCraft(typeof(ElegantCollarOfFortune), 1015283, 1159225, 120.0, 215.0, typeof(Cloth), 1044455, 5, 1044287);
            AddRes(index, typeof(Leather), 1044462, 5, 1044463);
            AddRes(index, typeof(LeurociansMempoOfFortune), 1071460, 1, 1044253);
            AddRes(index, typeof(FeyWings), 1113332, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.ElegantCollarOfFortune);
            ForceExceptional(index);
 */
            #endregion

            #region Footwear

            index = AddCraft(typeof(ElvenBoots), 1015288, 1072902, 80.0, 105.0, typeof(Leather), 1044462, 15, 1044463);

            AddCraft(typeof(FurBoots), 1015288, 1028967, 50.0, 75.0, typeof(Cloth), 1044455, 12, 1044287);

            AddCraft(typeof(NinjaTabi), 1015288, 1030210, 70.0, 95.0, typeof(Cloth), 1044455, 10, 1044287);

            AddCraft(typeof(SamuraiTabi), 1015288, 1030209, 20.0, 45.0, typeof(Cloth), 1044455, 6, 1044287);

            AddCraft(typeof(Sandals), 1015288, 1025901, 12.4, 37.4, typeof(Leather), 1044462, 4, 1044463);
            AddCraft(typeof(Shoes), 1015288, 1025904, 16.5, 41.5, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(Boots), 1015288, 1025899, 33.1, 58.1, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(ThighBoots), 1015288, 1025906, 41.4, 66.4, typeof(Leather), 1044462, 10, 1044463);

            AddCraft(typeof(LeatherTalons), 1015288, 1095728, 40.4, 65.4, typeof(Leather), 1044462, 6, 1044453);

 /*           index = AddCraft(typeof(JesterShoes), 1015288, 1109617, 20.0, 35.0, typeof(Cloth), 1044455, 6, 1044287);
            AddRecipe(index, (int)TailorRecipe.JesterShoes);

            index = AddCraft(typeof(KrampusMinionBoots), 1015288, 1125637, 100.0, 500.0, typeof(Leather), 1044462, 6, 1044463);
            AddRes(index, typeof(Cloth), 1044455, 4, 1044287);
            AddRecipe(index, (int)TailorRecipe.KrampusMinionBoots);

            index = AddCraft(typeof(KrampusMinionTalons), 1015288, 1125644, 100.0, 500.0, typeof(Leather), 1044462, 6, 1044463);
            AddRes(index, typeof(Cloth), 1044455, 4, 1044287);
            AddRecipe(index, (int)TailorRecipe.KrampusMinionTalons);
 */
            #endregion

            #region Leather Armor

       /*     index = AddCraft(typeof(SpellWovenBritches), 1015293, 1072929, 92.5, 117.5, typeof(Leather), 1044462, 15, 1044463);
            AddRes(index, typeof(EyeOfTheTravesty), 1032685, 1, 1044253);
            AddRes(index, typeof(Putrefaction), 1032678, 10, 1044253);
            AddRes(index, typeof(Scourge), 1032677, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.SpellWovenBritches);
            ForceNonExceptional(index);

            index = AddCraft(typeof(SongWovenMantle), 1015293, 1072931, 92.5, 117.5, typeof(Leather), 1044462, 15, 1044463);
            AddRes(index, typeof(EyeOfTheTravesty), 1032685, 1, 1044253);
            AddRes(index, typeof(Blight), 1032675, 10, 1044253);
            AddRes(index, typeof(Muculent), 1032680, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.SongWovenMantle);
            ForceNonExceptional(index);

            index = AddCraft(typeof(StitchersMittens), 1015293, 1072932, 92.5, 117.5, typeof(Leather), 1044462, 15, 1044463);
            AddRes(index, typeof(CapturedEssence), 1032686, 1, 1044253);
            AddRes(index, typeof(Corruption), 1032676, 10, 1044253);
            AddRes(index, typeof(Taint), 1032679, 10, 1044253);
            AddRecipe(index, (int)TailorRecipe.StitchersMittens);
            ForceNonExceptional(index);*/

            AddCraft(typeof(LeatherGorget), 1015293, 1025063, 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
            AddCraft(typeof(LeatherCap), 1015293, 1027609, 6.2, 31.2, typeof(Leather), 1044462, 2, 1044463);
            AddCraft(typeof(LeatherGloves), 1015293, 1025062, 51.8, 76.8, typeof(Leather), 1044462, 3, 1044463);
            AddCraft(typeof(LeatherArms), 1015293, 1025061, 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
            AddCraft(typeof(LeatherLegs), 1015293, 1025067, 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
            AddCraft(typeof(LeatherChest), 1015293, 1025068, 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);




			AddCraft(typeof(BrassardCuirSombre), 1015293, "Brassard de Cuir Sombre", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(JambiereCuirSombre), 1015293, "Jambiere de Cuir Sombre", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(PlastronCuirSombre), 1015293, "Plastron de Cuir Sombre", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(BottesBarbare), 1015293, "Bottes Barbare", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(BrassardBarbare), 1015293, "Brassard Barbare", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(BrassardBarbare2), 1015293, "Brassard Barbare2", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(CasqueBarbare), 1015293, "Casque Barbare", 6.2, 31.2, typeof(Leather), 1044462, 2, 1044463);
			AddCraft(typeof(EpauliereBarbare), 1015293, "Épaulière Barbare", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(GantsBarbare), 1015293, "Gants Barbare", 51.8, 76.8, typeof(Leather), 1044462, 3, 1044463);
			AddCraft(typeof(GorgetBarbare), 1015293, "Gorget Barbare", 53.9, 78.9, typeof(Leather), 1044462, 4, 1044463);
			AddCraft(typeof(JambiereBarbare), 1015293, "Jambiere Barbare", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(JambiereBarbare2), 1015293, "Jambière Barbare2", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(JambiereBarbare3), 1015293, "Jambière Barbare3", 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(PlastronBarbare), 1015293, "Plastron Barbare", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare2), 1015293, "Plastron Barbare2", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare3), 1015293, "Plastron Barbare3", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare4), 1015293, "Plastron Barbare4", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare5), 1015293, "Plastron Barbare5", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare6), 1015293, "Plastron Barbare5", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);
			AddCraft(typeof(PlastronBarbare7), 1015293, "Plastron Barbare7", 70.5, 95.5, typeof(Leather), 1044462, 12, 1044463);

















			index = AddCraft(typeof(LeatherJingasa), 1015293, 1030177, 45.0, 70.0, typeof(Leather), 1044462, 4, 1044463);

            index = AddCraft(typeof(LeatherMempo), 1015293, 1030181, 80.0, 105.0, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(LeatherDo), 1015293, 1030182, 75.0, 100.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherHiroSode), 1015293, 1030185, 55.0, 80.0, typeof(Leather), 1044462, 5, 1044463);

            index = AddCraft(typeof(LeatherSuneate), 1015293, 1030193, 68.0, 93.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherHaidate), 1015293, 1030197, 68.0, 93.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherNinjaPants), 1015293, 1030204, 80.0, 105.0, typeof(Leather), 1044462, 13, 1044463);

            index = AddCraft(typeof(LeatherNinjaJacket), 1015293, 1030206, 85.0, 110.0, typeof(Leather), 1044462, 13, 1044463);

            index = AddCraft(typeof(LeatherNinjaBelt), 1015293, 1030203, 50.0, 75.0, typeof(Leather), 1044462, 5, 1044463);

            index = AddCraft(typeof(LeatherNinjaMitts), 1015293, 1030205, 65.0, 90.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeatherNinjaHood), 1015293, 1030201, 90.0, 115.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(LeafChest), 1015293, 1032667, 75.0, 100.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(LeafArms), 1015293, 1032670, 60.0, 85.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeafGloves), 1015293, 1032668, 60.0, 85.0, typeof(Leather), 1044462, 10, 1044463);

            index = AddCraft(typeof(LeafLegs), 1015293, 1032671, 75.0, 100.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(LeafGorget), 1015293, 1032669, 65.0, 90.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(LeafTonlet), 1015293, 1032672, 70.0, 95.0, typeof(Leather), 1044462, 12, 1044463);

    /*        index = AddCraft(typeof(LeatherArms), 1015293, 1095327, 53.9, 78.9, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(LeatherChest), 1015293, 1095329, 70.5, 95.5, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(LeatherLegs), 1015293, 1095333, 66.3, 91.3, typeof(Leather), 1044462, 10, 1044463);

            index = AddCraft(typeof(Cyclone), 1015293, 1096662, 65.0, 90.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(TigerPeltChest), 1015293, 1109626, 90.0, 115.0, typeof(Leather), 1044462, 8, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 4, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltChest);

            index = AddCraft(typeof(TigerPeltLegs), 1015293, 1109628, 90.0, 115.0, typeof(Leather), 1044462, 8, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 4, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltLegs);

            index = AddCraft(typeof(TigerPeltShorts), 1015293, 1109629, 90.0, 115.0, typeof(Leather), 1044462, 4, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 2, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltShorts);

            index = AddCraft(typeof(TigerPeltHelm), 1015293, 1109632, 90.0, 115.0, typeof(Leather), 1044462, 2, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 1, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltHelm);

            index = AddCraft(typeof(TigerPeltCollar), 1015293, 1109633, 90.0, 115.0, typeof(Leather), 1044462, 2, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 1, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltCollar);

            index = AddCraft(typeof(DragonTurtleHideChest), 1015293, 1109634, 101.5, 116.5, typeof(Leather), 1044462, 8, 1044463);
            AddRes(index, typeof(DragonTurtleScute), 1123910, 2, 1044253);
            AddRecipe(index, (int)TailorRecipe.DragonTurtleHideChest);

            index = AddCraft(typeof(DragonTurtleHideLegs), 1015293, 1109636, 101.5, 116.5, typeof(Leather), 1044462, 8, 1044463);
            AddRes(index, typeof(DragonTurtleScute), 1123910, 4, 1044253);
            AddRecipe(index, (int)TailorRecipe.DragonTurtleHideLegs);

            index = AddCraft(typeof(DragonTurtleHideHelm), 1015293, 1109637, 101.5, 116.5, typeof(Leather), 1044462, 2, 1044463);
            AddRes(index, typeof(DragonTurtleScute), 1123910, 1, 1044253);
            AddRecipe(index, (int)TailorRecipe.DragonTurtleHideHelm);

            index = AddCraft(typeof(DragonTurtleHideArms), 1015293, 1109638, 101.5, 116.5, typeof(Leather), 1044462, 4, 1044463);
            AddRes(index, typeof(DragonTurtleScute), 1123910, 2, 1044253);
            AddRecipe(index, (int)TailorRecipe.DragonTurtleHideArms);
	*/
            #endregion

            #region Cloth Armor
         
       
            #endregion

            #region Studded Armor
            AddCraft(typeof(StuddedGorget), 1015300, 1025078, 78.8, 103.8, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(StuddedGloves), 1015300, 1025077, 82.9, 107.9, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(StuddedArms), 1015300, 1025076, 87.1, 112.1, typeof(Leather), 1044462, 10, 1044463);
            AddCraft(typeof(StuddedLegs), 1015300, 1025082, 91.2, 116.2, typeof(Leather), 1044462, 12, 1044463);
            AddCraft(typeof(StuddedChest), 1015300, 1025083, 94.0, 119.0, typeof(Leather), 1044462, 14, 1044463);




			AddCraft(typeof(BrassardCloute), 1015300, "Brassard Clouté", 58.0, 83.0, typeof(Leather), 1044462, 10, 1044463);
			AddCraft(typeof(JupeCloute), 1015300, "Jupe Clouté", 58.0, 83.0, typeof(Leather), 1044462, 12, 1044463);

			AddCraft(typeof(PlastronCloute), 1015300, "Plastron Clouté", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute2), 1015300, "Plastron Clouté2", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute3), 1015300, "Plastron Clouté3", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute4), 1015300, "Plastron Clouté4", 58.0, 83.0, typeof(Leather), 1044462, 14, 1044463);


			index = AddCraft(typeof(StuddedMempo), 1015300, 1030216, 80.0, 105.0, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(StuddedDo), 1015300, 1030183, 95.0, 120.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(StuddedHiroSode), 1015300, 1030186, 85.0, 110.0, typeof(Leather), 1044462, 8, 1044463);

            index = AddCraft(typeof(StuddedSuneate), 1015300, 1030194, 92.0, 117.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(StuddedHaidate), 1015300, 1030198, 92.0, 117.0, typeof(Leather), 1044462, 14, 1044463);

            index = AddCraft(typeof(HideChest), 1015300, 1032651, 85.0, 110.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(HidePauldrons), 1015300, 1032654, 75.0, 100.0, typeof(Leather), 1044462, 12, 1044463);

            index = AddCraft(typeof(HideGloves), 1015300, 1032652, 75.0, 100.0, typeof(Leather), 1044462, 10, 1044463);

            index = AddCraft(typeof(HidePants), 1015300, 1032655, 92.0, 117.0, typeof(Leather), 1044462, 15, 1044463);

            index = AddCraft(typeof(HideGorget), 1015300, 1032653, 90.0, 115.0, typeof(Leather), 1044462, 12, 1044463);

            #endregion

            #region Female Armor
            AddCraft(typeof(LeatherShorts), 1015306, 1027168, 62.2, 87.2, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(LeatherSkirt), 1015306, 1027176, 58.0, 83.0, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(LeatherBustierArms), 1015306, 1027178, 58.0, 83.0, typeof(Leather), 1044462, 6, 1044463);
            AddCraft(typeof(StuddedBustierArms), 1015306, 1027180, 82.9, 107.9, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(FemaleLeatherChest), 1015306, 1027174, 62.2, 87.2, typeof(Leather), 1044462, 8, 1044463);
            AddCraft(typeof(FemaleStuddedChest), 1015306, 1027170, 87.1, 112.1, typeof(Leather), 1044462, 10, 1044463);

   /*         index = AddCraft(typeof(TigerPeltBustier), 1015306, 1109627, 90.0, 115.0, typeof(Leather), 1044462, 6, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 3, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltBustier);

            index = AddCraft(typeof(TigerPeltLongSkirt), 1015306, 1109630, 90.0, 115.0, typeof(Leather), 1044462, 4, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 2, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltLongSkirt);

            index = AddCraft(typeof(TigerPeltSkirt), 1015306, 1109631, 90.0, 115.0, typeof(Leather), 1044462, 4, 1044463);
            AddRes(index, typeof(TigerPelt), 1123908, 2, 1044253);
            AddRecipe(index, (int)TailorRecipe.TigerPeltSkirt);

            index = AddCraft(typeof(DragonTurtleHideBustier), 1015306, 1109635, 101.5, 116.5, typeof(Leather), 1044462, 6, 1044463);
            AddRes(index, typeof(DragonTurtleScute), 1123910, 3, 1044253);
            AddRecipe(index, (int)TailorRecipe.DragonTurtleHideBustier);
   */
            #endregion

            #region Bone Armor
/*
            index = AddCraft(typeof(CuffsOfTheArchmage), 1049149, 1157348, 120.0, 120.1, typeof(Cloth), 1044455, 8, 1044287);
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
