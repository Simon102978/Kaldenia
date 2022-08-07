using System;
using Server;
using Server.Items;

namespace Server.Engines.Craft
{
    #region Recipes
    public enum BrewingkegRecipes
    {
    }
    #endregion
    public class DefBrewing : CraftSystem
	{
        public void SetNeedDistillery(int index, bool needDistillery)
        {
            CraftItem craftItem = CraftItems.GetAt(index);
            craftItem.NeedDistillery = needDistillery;
        }
        public override SkillName MainSkill { get { return SkillName.Alchemy; } }

	//	public override int GumpTitleNumber { get { return 0; } }

		public override string GumpTitleString { get { return "Brewing Menu"; } }

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem { get { if ( m_CraftSystem == null ) m_CraftSystem = new DefBrewing(); return m_CraftSystem; } }

		public override double GetChanceAtMin( CraftItem item ) { return 0.5; }

		private DefBrewing() : base( 1, 1, 1.25 ) { }

        public override int CanCraft(Mobile from, ITool tool, Type itemType)
        {
			if (((Item)tool).Deleted || tool.UsesRemaining < 0 ) return 1044038;
			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x5B0 );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken ) from.SendLocalizedMessage( 1044038 );

			if ( failed )
			{
				if ( lostMaterial ) return 1044043;
				else return 1044157;
			}
			else
			{
				if ( quality == 0 ) return 502785;
				else if ( makersMark && quality == 2 ) return 1044156;
				else if ( quality == 2 ) return 1044155;
				else return 1044154;
			}
		}

		public override void InitCraftList()
		{
			int index = -1;
			string skillNotice = "You have no idea how to brew with this type of hops.";

			index = AddCraft( typeof( MeadKeg ), "Alchoholic Beverages", "Keg of Mead", 80.0, 105.6, typeof( BitterHops ), "Bitter Hops", 50, "You need more Hops" );
			AddRes( index, typeof( Keg ), "Keg", 1, "You need a keg" );
			AddRes( index, typeof( BaseBeverage ), "Water", 20, "You need more water" );
			AddRes( index, typeof( Malt ), "Malt", 3, "You need more malt" );
			AddRes( index, typeof( BrewersYeast ), "Brewers Yeast", 3, "You need more Brewers Yeast" );
            SetNeedDistillery(index, true);

			index = AddCraft( typeof( AleKeg ), "Alchoholic Beverages", "Keg of Ale", 80.0, 105.6, typeof( BitterHops ), "Bitter Hops", 50, "You need more Hops" );
			AddRes( index, typeof( Keg ), "Keg", 1, "You need a keg" );
			AddRes( index, typeof( BaseBeverage ), "Water", 20, "You need more water" );
			AddRes( index, typeof( Barley ), "Barley", 3, "You need more Barley" );
			AddRes( index, typeof( BrewersYeast ), "Brewers Yeast", 3, "You need more Brewers Yeast" );
            SetNeedDistillery(index, true);

			index = AddCraft( typeof( CiderKeg ), "Non Alchoholic Beverages", "Keg of Cider", 80.0, 105.6, typeof( Keg ), "Keg", 1, "You need a keg" );
			AddRes( index, typeof( Apple ), "Apples", 100, "You need more apples" );
			AddRes( index, typeof( BaseBeverage ), "Water", 20, "You need more water" );
			AddRes( index, typeof( BagOfSugar ), "Bag of Sugar", 1, "You need more sugar" );
            SetNeedSteamPoweredBeverageMaker(index, true);

			index = AddCraft( typeof( CoffeeKeg ), "Non Alchoholic Beverages", "Keg of Coffee", 80.0, 105.6, typeof( Keg ), "Keg", 1, "You need a keg" );
			AddRes( index, typeof( BagOfCoffee ), "Bag of Coffee", 5, "You need more coffee" );
			AddRes( index, typeof( BaseBeverage ), "Water", 20, "You need more water" );
            SetNeedSteamPoweredBeverageMaker(index, true);

			index = AddCraft( typeof( TeaKeg ), "Non Alchoholic Beverages", "Keg of Tea", 80.0, 105.6, typeof( Keg ), "Keg", 1, "You need a keg" );
			AddRes( index, typeof( TeaLeaves ), "Tea Leaves", 20, "You need more Tea Leaves" );
			AddRes( index, typeof( BaseBeverage ), "Water", 20, "You need more water" );
            SetNeedSteamPoweredBeverageMaker(index, true);

			index = AddCraft( typeof( CocoaKeg ), "Non Alchoholic Beverages", "Keg of Cocoa", 80.0, 105.6, typeof( Keg ), "Keg", 1, "You need a keg" );
			AddRes( index, typeof( BagOfCocoa ), "Bag of Cocoa", 5, "You need more Cocoa" );
			AddRes( index, typeof( BaseBeverage ), "Water", 20, "You need more water" );
			AddRes( index, typeof( BagOfSugar ), "Bag of Sugar", 1, "You need more sugar" );
            SetNeedSteamPoweredBeverageMaker(index, true);

			SetSubRes( typeof( BitterHops ),	"Bitter Hops" );

			AddSubRes( typeof( BitterHops ),	"Bitter Hops", 30.0, skillNotice);
			AddSubRes( typeof( SnowHops ),	"Snow Hops", 50.0, skillNotice);
			AddSubRes( typeof( ElvenHops ),	"Elven Hops", 70.0, skillNotice);
			AddSubRes( typeof( SweetHops ),	"Sweet Hops", 90.0, skillNotice);

			MarkOption = true;
			Repair = false;
		}
	}
}
