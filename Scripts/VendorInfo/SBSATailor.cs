using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBSATailor : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Cotton), 102, 20, 0xDF9, 0, true));
                Add(new GenericBuyInfo(typeof(Wool), 62, 20, 0xDF8, 0, true));
                Add(new GenericBuyInfo(typeof(Flax), 102, 20, 0x1A9C, 0, true));
                Add(new GenericBuyInfo(typeof(SpoolOfThread), 18, 20, 0xFA0, 0, true));
                Add(new GenericBuyInfo(typeof(SewingKit), 3, 20, 0xF9D, 0));
                Add(new GenericBuyInfo(typeof(Scissors), 11, 20, 0xF9F, 0));
                Add(new GenericBuyInfo(typeof(DyeTub), 8, 20, 0xFAB, 0));
                Add(new GenericBuyInfo(typeof(Dyes), 8, 20, 0xFA9, 0));

                Add(new GenericBuyInfo(typeof(Robe), 32, 20, 0x4000, 0));
                Add(new GenericBuyInfo(typeof(FancyRobe), 46, 20, 0x4002, 0));

            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
          //      Add(typeof(Cotton), 51);
            //    Add(typeof(Wool), 31);
              //  Add(typeof(Flax), 51);
                Add(typeof(SpoolOfThread), 9);
                Add(typeof(SewingKit), 1);
                Add(typeof(Scissors), 6);
                Add(typeof(DyeTub), 4);
                Add(typeof(Dyes), 4);

                Add(typeof(Robe), 16);
                Add(typeof(FancyRobe), 23);

            }
        }
    }
}
