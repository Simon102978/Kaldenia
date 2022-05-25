using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBMessager : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Missive), 10, 20, 0x14EE, 0));
                Add(new GenericBuyInfo(typeof(CarnetAdresse),50, 10, 0xFF2, 1633));
				Add(new GenericBuyInfo(typeof(ScribesPen), 8, 20, 0xFBF, 0));

			}
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {

            }
        }
    }
}
