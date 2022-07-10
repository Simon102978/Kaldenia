using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBTailor : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(SewingKit), 5, 20, 0xF9D, 0));
                Add(new GenericBuyInfo(typeof(Scissors), 10, 20, 0xF9F, 0));
                Add(new GenericBuyInfo(typeof(DyeTub), 8, 50, 0xFAB, 0));
                Add(new GenericBuyInfo(typeof(Dyes), 8, 50, 0xFA9, 0));
	

				Add(new GenericBuyInfo(typeof(Shirt), 12, 20, 0x1517, 0));
				Add(new GenericBuyInfo(typeof(Camisole), 12, 20, 0xA2DA, 0));
				Add(new GenericBuyInfo(typeof(ShortPants), 7, 20, 0x152E, 0));
				Add(new GenericBuyInfo(typeof(Pantalon7), 7, 20, 0xA336, 0));
				Add(new GenericBuyInfo(typeof(FancyShirt), 21, 20, 0x1EFD, 0));
				Add(new GenericBuyInfo(typeof(Tabar), 21, 20, 0xA308, 0));
				Add(new GenericBuyInfo(typeof(LongPants), 10, 20, 0xA2F1, 0));
				Add(new GenericBuyInfo(typeof(Pantalon5), 10, 20, 0xA334, 0));
				Add(new GenericBuyInfo(typeof(FancyDress), 26, 20, 0x1EFF, 0));
				Add(new GenericBuyInfo(typeof(Robe9), 26, 20, 0x1EFF, 0));
				Add(new GenericBuyInfo(typeof(PlainDress), 13, 20, 0x1F01, 0));
				Add(new GenericBuyInfo(typeof(RobeCourte), 13, 20, 0xA2E2, 0));
				Add(new GenericBuyInfo(typeof(Kilt), 11, 20, 0x1537, 0));
                Add(new GenericBuyInfo(typeof(Kilt), 11, 20, 0x1537, 0));
				Add(new GenericBuyInfo(typeof(HalfApron), 10, 20, 0x153b, 0));
                Add(new GenericBuyInfo(typeof(Robe), 18, 20, 0x1F03, 0));
                Add(new GenericBuyInfo(typeof(Cloak), 8, 20, 0x1515, 0));
                Add(new GenericBuyInfo(typeof(Cloak), 8, 20, 0x1515, 0));
                Add(new GenericBuyInfo(typeof(Doublet), 13, 20, 0x1F7B, 0));
                Add(new GenericBuyInfo(typeof(Tunic), 18, 20, 0x1FA1, 0));
               

               
                Add(new GenericBuyInfo(typeof(FloppyHat), 7, 20, 0x1713, 0));
				Add(new GenericBuyInfo(typeof(WideBrimHat), 8, 20, 0x1714, 0));
				Add(new GenericBuyInfo(typeof(Cap), 10, 20, 0x1715, 0));
				Add(new GenericBuyInfo(typeof(TallStrawHat), 8, 20, 0x1716, 0));
				Add(new GenericBuyInfo(typeof(StrawHat), 7, 20, 0x1717, 0));
				Add(new GenericBuyInfo(typeof(WizardsHat), 11, 20, 0x1718, 0));
				Add(new GenericBuyInfo(typeof(LeatherCap), 10, 20, 0x1DB9, 0));
				Add(new GenericBuyInfo(typeof(FeatheredHat), 10, 20, 0x171A, 0));
				Add(new GenericBuyInfo(typeof(TricorneHat), 8, 20, 0x171B, 0));
				Add(new GenericBuyInfo(typeof(Bandana), 6, 20, 0x1540, 0));
				Add(new GenericBuyInfo(typeof(SkullCap), 7, 20, 0x1544, 0));

				Add(new GenericBuyInfo(typeof(BoltOfCloth), 100, 20, 0xf95, Utility.RandomDyedHue(), true));

                Add(new GenericBuyInfo(typeof(Cloth), 2, 20, 0x1766, 0, true));
                Add(new GenericBuyInfo(typeof(UncutCloth), 2, 20, 0x1767, 0, true));

               
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Scissors), 1);
                Add(typeof(SewingKit), 1);
                Add(typeof(Dyes), 1);
                Add(typeof(DyeTub), 1);

             //   Add(typeof(BoltOfCloth), 5);
            //    Add(typeof(Cloth), 1);
            //    Add(typeof(UncutCloth), 1);

                Add(typeof(FancyShirt), 1);
                Add(typeof(Shirt), 1);

                Add(typeof(ShortPants), 3);
                Add(typeof(LongPants), 4);

                Add(typeof(Cloak), 4);
                Add(typeof(FancyDress), 2);
                Add(typeof(Robe), 2);
                Add(typeof(PlainDress), 1);

                Add(typeof(Skirt), 1);
                Add(typeof(Kilt), 1);

                Add(typeof(Doublet), 5);
                Add(typeof(Tunic), 5);
                Add(typeof(JesterSuit), 5);

                Add(typeof(FullApron), 5);
                Add(typeof(HalfApron), 5);

                Add(typeof(JesterHat), 5);
                Add(typeof(FloppyHat), 3);
                Add(typeof(WideBrimHat), 4);
                Add(typeof(Cap), 5);
                Add(typeof(SkullCap), 3);
                Add(typeof(Bandana), 3);
                Add(typeof(TallStrawHat), 4);
                Add(typeof(StrawHat), 4);
                Add(typeof(WizardsHat), 5);
                Add(typeof(Bonnet), 4);
                Add(typeof(FeatheredHat), 5);
                Add(typeof(TricorneHat), 4);

                Add(typeof(SpoolOfThread), 1);

                Add(typeof(Flax), 1);
                Add(typeof(Cotton), 1);
                Add(typeof(Wool), 1);
            }
        }
    }
}
