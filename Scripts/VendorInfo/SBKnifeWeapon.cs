using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBKnifeWeapon : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(ButcherKnife), 14, 20, 0x13F6, 0));
                Add(new GenericBuyInfo(typeof(Dagger), 21, 20, 0xF52, 0));
                Add(new GenericBuyInfo(typeof(Cleaver), 15, 20, 0xEC3, 0));
                Add(new GenericBuyInfo(typeof(SkinningKnife), 14, 20, 0xEC4, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(ButcherKnife), 2);
                Add(typeof(Cleaver), 2);
                Add(typeof(Dagger), 1);
                Add(typeof(SkinningKnife), 1);
            }
        }
    }
}
