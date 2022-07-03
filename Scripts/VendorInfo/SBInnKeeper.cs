using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBInnKeeper : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Ale, 7, 20, 0x99F, 0));
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Wine, 7, 20, 0x9C7, 0));
                Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Liquor, 7, 20, 0x99B, 0));                                                         
                
                Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Water, 11, 20, 0x1F9D, 0));

				Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Milk, 5, 20, 0x1F8C, 0));
				Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Ale, 7, 20, 0x9EF, 0));
				Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Cider, 7, 20, 0x9EF, 0));
				Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Liquor, 7, 20, 0x1F88, 0));
				Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Wine, 7, 20, 0x1F90, 0));
				Add(new BeverageBuyInfo(typeof(GlassMug), BeverageType.Water, 7, 20, 0x1F94, 0));

				Add(new GenericBuyInfo(typeof(BreadLoaf), 6, 10, 0x103B, 0, true));                                                 
                                            
                Add(new GenericBuyInfo(typeof(Backpack), 15, 20, 0x9B2, 0));
                Add(new GenericBuyInfo("1016450", typeof(Chessboard), 2, 20, 0xFA6, 0));
                Add(new GenericBuyInfo("1016449", typeof(CheckerBoard), 2, 20, 0xFA6, 0));
                Add(new GenericBuyInfo(typeof(Backgammon), 2, 20, 0xE1C, 0));
                Add(new GenericBuyInfo(typeof(Dices), 2, 20, 0xFA7, 0));
               
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(BeverageBottle), 1);
                Add(typeof(Jug), 1);
                Add(typeof(Pitcher), 1);
                Add(typeof(GlassMug), 1);
                Add(typeof(BreadLoaf), 1);
                Add(typeof(CheeseWheel), 1);
                Add(typeof(Ribs), 1);
                Add(typeof(Peach), 1);
                Add(typeof(Pear), 1);
                Add(typeof(Grapes), 1);
                Add(typeof(Apple), 1);
                Add(typeof(Banana), 1);
                Add(typeof(Torch), 3);
                Add(typeof(Candle), 3);
                Add(typeof(Chessboard), 1);
                Add(typeof(CheckerBoard), 1);
                Add(typeof(Backgammon), 1);
                Add(typeof(Dices), 1);
                Add(typeof(ContractOfEmployment), 626);
                Add(typeof(Beeswax), 1);
                Add(typeof(WoodenBowlOfCarrots), 1);
                Add(typeof(WoodenBowlOfCorn), 1);
                Add(typeof(WoodenBowlOfLettuce), 1);
                Add(typeof(WoodenBowlOfPeas), 1);
                Add(typeof(EmptyPewterBowl), 1);
                Add(typeof(PewterBowlOfCorn), 1);
                Add(typeof(PewterBowlOfLettuce), 1);
                Add(typeof(PewterBowlOfPeas), 1);
                Add(typeof(PewterBowlOfPotatos), 1);
                Add(typeof(WoodenBowlOfStew), 1);
                Add(typeof(WoodenBowlOfTomatoSoup), 1);
            }
        }
    }
}
