using System;
using Server.Items;

namespace Server.Engines.Craft
{
    #region Recipes
    public enum WitchRecipes
    {
    }
    #endregion
    public class DefWitchcraft : CraftSystem
	{
        public void SetNeedCauldron(int index, bool needCauldron)
        {
            CraftItem craftItem = CraftItems.GetAt(index);
            craftItem.NeedCauldron = needCauldron;
        }
        public override SkillName MainSkill
		{
			get	{ return SkillName.Cooking;	}
		}

/*		public override int GumpTitleNumber
		{
			get { return 0; } // Use String
		}
*/
		public override string GumpTitleString
		{
			get { return "Recettes Enchantées"; } 
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefWitchcraft();

				return m_CraftSystem;
			}
		}

        public override CraftECA ECA
        {
            get
            {
                return CraftECA.ChanceMinusSixtyToFourtyFive;
            }
        }

        public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefWitchcraft() : base( 1, 1, 1.25 )// base( 1, 1, 1.5 )
		{
		}

        public override int CanCraft(Mobile from, ITool tool, Type itemType)
        {
            if (tool == null || ((Item)tool).Deleted || tool.UsesRemaining < 0)
            {
                return 1044038; // You have worn out your tool!
            }

            if (!BaseTool.CheckTool((BaseTool)tool, from))
            {
                return 1048146; // If you have a tool equipped, you must use that tool.
            }

            if (!BaseTool.CheckAccessible((BaseTool)tool, from))
            {
                return 1044263; // The tool must be on your person to use.
            }
            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x5AB);
        }

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
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


// format of AddCraft: AddCraft( typeof( ThingToMake ), Category (text or ##),
//			ThingToMake (text or ##), minskill, maxskill, typeof( FirstThingToConsume),
//			FirstThingToConsume (text or ##), Qty,
//			ErrorMessageForNotHavingFirstThingToConsume (text or ##) );
// format of AddRes:   AddRes( index, typeof( SecondThingToConsume ),
//			SecondThingToConsume (text or ##), Qty,
//			ErrorMessageForNotHavingSecondThingToConsume (text or ##) );

// index = AddCraft( typeof( Make ), Category, Make, minskill, maxskill, typeof( Consume1 ), Consume1, qty, Error );
// AddRes( index, typeof( Consume2 ), Consume2, qty, Error );

		public override void InitCraftList()
		{
			int index = -1;
/*
			index = AddCraft( typeof( GloriousBeefRibs ), "Magic Foods", "Glorious Beef Ribs", 0.0, 100.0, typeof( RawRibs ), "Raw Ribs", 1, "You don't have enough ribs." );
			AddSkill( index, SkillName.Alchemy, 25.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( Mooncake ), "Magic Foods", "Mooncake", 0.0, 100.0, typeof( CakeMix ), "Cake Mix", 1, "You don't have enough cake mix." );
			AddSkill( index, SkillName.Alchemy, 25.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( PerfectSalad ), "Magic Foods", "Perfect Salad", 0.0, 100.0, typeof( Lettuce ), "Lettuce", 3, "You don't have enough lettuce." );
			AddSkill( index, SkillName.Alchemy, 25.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( MeditationSteak ), "Magic Foods", "Meditation Steak", 0.0, 100.0, typeof( FishSteak ), "Fish Steak", 1, "You don't have enough fish steak." );
			AddSkill( index, SkillName.Alchemy, 25.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( MuffinsOfHealth ), "Magic Foods", "Muffins of Health", 0.0, 100.0, typeof( Muffins ), "Muffins", 3, "You don't have enough muffins." );
			AddSkill( index, SkillName.Alchemy, 25.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( ElixirOfStrength ), "Elixirs", "Elixir of Strength", 0.0, 100.0, typeof( BlackPearl ), "Black Pearl", 25, "You don't have enough black pearl." );
			AddSkill( index, SkillName.Alchemy, 40.0, 100.0 );
            SetNeedCauldron(index, true);

            index = AddCraft(typeof(ElixirOfSpeed), "Elixirs", "Elixir of Speed", 0.0, 100.0, typeof(SpidersSilk), "Spiders Silk", 5, "You don't have enough spider silk.");
            AddSkill(index, SkillName.Alchemy, 25.0, 100.0);
            SetNeedCauldron(index, true);

            index = AddCraft( typeof( ElixirOfDexterity ), "Elixirs", "Elixir of Dexterity", 0.0, 100.0, typeof( Bloodmoss ), "Bloodmoss", 25, "You don't have enough bloodmoss." );
			AddSkill( index, SkillName.Alchemy, 40.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( ElixirOfIntelligence ), "Elixirs", "Elixir of Intelligence", 0.0, 100.0, typeof( MandrakeRoot ), "Mandrake", 25, "You don't have enough mandrake." );
			AddSkill( index, SkillName.Alchemy, 40.0, 100.0 );
            SetNeedCauldron(index, true);
*/
	//		index = AddCraft( typeof( BowyerBerry ), "Mets Magiques", "Baie de l'Archer ( Archery )", 0.0, 100.0, typeof( Orange ), "Orange", 1, "You don't have an orange." );
		//	AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
        //    SetNeedCauldron(index, true);

			index = AddCraft( typeof( HealerPear ), "Mets Magiques", "Poire du Soigneur ( Healing )", 0.0, 100.0, typeof( Pear ), "Pear", 1, "You don't have a pear." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( HunterApple ), "Mets Magiques", "Pomme du Chasseur ( Cartography )", 0.0, 100.0, typeof( Apple ), "Apple", 1, "You don't have an apple." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

		//	index = AddCraft( typeof( KnightMango ), "Mets Magiques", "Knight's Mango", 0.0, 100.0, typeof( Mango ), "Mango", 1, "You don't have a mango." );
		//	AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
        //    SetNeedCauldron(index, true);

			index = AddCraft( typeof( LumberjackCoconut ), "Mets Magiques", "Noix de Coco du Bucheron ( Lumberjacking )", 0.0, 100.0, typeof( Coconut ), "Coconut", 1, "You don't have a coconut." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( MacerPear ), "Mets Magiques", "Poire du Massier ( Macefighting )", 0.0, 100.0, typeof( Pear ), "Pear", 1, "You don't have a pear." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( MageMango ), "Mets Magiques", "Mangue du Mage ( Magery )", 0.0, 100.0, typeof( Mango ), "Mango", 1, "You don't have a mango." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( MinerPear ), "Mets Magiques", "Lime du mineur ( Mining )", 0.0, 100.0, typeof(Lime), "Lime", 1, "You don't have a pear." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

	//		index = AddCraft( typeof( NecroLime ), "Mets Magiques", "Necromancer's Lime", 0.0, 100.0, typeof( Lime ), "Lime", 1, "You don't have a lime." );
	//		AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
     //       SetNeedCauldron(index, true);

			index = AddCraft( typeof( PirateGrapes ), "Mets Magiques", "Raisin du Pirate ", 0.0, 100.0, typeof( Grapes ), "Grapes", 1, "You don't have any grapes." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
            SetNeedCauldron(index, true);

			index = AddCraft( typeof( RangerGrapes ), "Mets Magiques", "Raisin Du Rôdeur", 0.0, 100.0, typeof( Grapes ), "Grapes", 1, "You don't have any grapes." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( RogueLemon ), "Mets Magiques", "Citron du Roublard", 0.0, 100.0, typeof( Lemon ), "Lemon", 1, "You don't have a lemon." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( SageMelon ), "Mets Magiques", "Melon du Sage", 0.0, 100.0, typeof( Watermelon ), "Watermelon", 1, "You don't have a watermelon." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( ScribeLemon ), "Mets Magiques", "Citron de l'Écrivain", 0.0, 100.0, typeof( Lemon ), "Lemon", 1, "You don't have a lemon." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( ShepherdLime ), "Mets Magiques", "Lime du Berger", 0.0, 100.0, typeof( Lime ), "Lime", 1, "You don't have a lime." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( SmithMelon ), "Mets Magiques", "Melon du Forgeron", 0.0, 100.0, typeof( HoneydewMelon ), "Honeydew Melon", 1, "You don't have a honeydew melon." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( TacticBerry ), "Mets Magiques", "Baie du Tacticien", 0.0, 100.0, typeof( Apple ), "Apple", 1, "You don't have an apple." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( TailorPeach ), "Mets Magiques", "Pêche du Couturier", 0.0, 100.0, typeof( Peach ), "Peach", 1, "You don't have a peach." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( ThiefOrange ), "Mets Magiques", "Orange du Voleur", 0.0, 100.0, typeof( Orange ), "Orange", 1, "You don't have an orange." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( TinkerApple ), "Mets Magiques", "Pomme du Bricoleur", 0.0, 100.0, typeof( Apple ), "Apple", 1, "You don't have an apple." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( WarriorPeach ), "Mets Magiques", "Pêche du Guerrier", 0.0, 100.0, typeof( Peach ), "Peach", 1, "You don't have a peach." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);

			index = AddCraft( typeof( WoodworkerApple ), "Mets Magiques", "Pomme du Charpentier", 0.0, 100.0, typeof( Apple ), "Apple", 1, "You don't have an apple." );
			AddSkill( index, SkillName.Cooking, 30.0, 100.0 );
			SetNeedCauldron(index, true);
		}
	}
}
