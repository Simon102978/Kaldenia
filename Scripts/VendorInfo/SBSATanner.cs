using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBSATanner : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Bag), 6, 20, 0xE76, 0));
                Add(new GenericBuyInfo(typeof(Pouch), 6, 20, 0xE79, 0));
                Add(new GenericBuyInfo(typeof(Backpack), 15, 20, 0x9B2, 0));
                Add(new GenericBuyInfo(typeof(Leather), 6, 20, 0x1081, 0, true));
                Add(new GenericBuyInfo(typeof(Dagger), 20, 20, 0x902, 0));
                Add(new GenericBuyInfo(typeof(TaxidermyKit), 100000, 20, 0x1EBA, 0));


                Add(new GenericBuyInfo(typeof(LeatherArms), 80, 20, 0x302, 0));
                Add(new GenericBuyInfo(typeof(FemaleLeatherChest), 77, 20, 0x303, 0));
                Add(new GenericBuyInfo(typeof(LeatherChest), 77, 20, 0x304, 0));

                Add(new GenericBuyInfo(typeof(LeatherLegs), 67, 20, 0x305, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Bag), 3);
                Add(typeof(Pouch), 3);
                Add(typeof(Backpack), 7);
                Add(typeof(Leather), 5);
                Add(typeof(Dagger), 10);


                Add(typeof(LeatherArms), 41);
                Add(typeof(FemaleLeatherChest), 44);
                Add(typeof(LeatherChest), 38);

                Add(typeof(LeatherLegs), 34);
            }
        }
    }
}
