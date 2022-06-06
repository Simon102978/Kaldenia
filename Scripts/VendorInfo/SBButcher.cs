using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBButcher : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Bacon), 7, 20, 0x979, 0, true));
                Add(new GenericBuyInfo(typeof(Ham), 26, 20, 0x9C9, 0, true));
                Add(new GenericBuyInfo(typeof(Sausage), 18, 20, 0x9C0, 0, true));
                Add(new GenericBuyInfo(typeof(RawChickenLeg), 6, 20, 0x1607, 0, true));
                Add(new GenericBuyInfo(typeof(RawBird), 9, 20, 0x9B9, 0, true));
                Add(new GenericBuyInfo(typeof(RawLambLeg), 9, 20, 0x1609, 0, true));
                Add(new GenericBuyInfo(typeof(RawRibs), 16, 20, 0x9F1, 0, true));
                Add(new GenericBuyInfo(typeof(ButcherKnife), 13, 20, 0x13F6, 0));
                Add(new GenericBuyInfo(typeof(Cleaver), 13, 20, 0xEC3, 0));
                Add(new GenericBuyInfo(typeof(SkinningKnife), 13, 20, 0xEC4, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(RawRibs), 2);
                Add(typeof(RawLambLeg), 2);
                Add(typeof(RawChickenLeg), 2);
                Add(typeof(RawBird), 2);
                Add(typeof(Bacon), 2);
                Add(typeof(Sausage), 2);
                Add(typeof(Ham), 2);
                Add(typeof(ButcherKnife), 1);
                Add(typeof(Cleaver), 1);
                Add(typeof(SkinningKnife), 1);
            }
        }
    }
}
