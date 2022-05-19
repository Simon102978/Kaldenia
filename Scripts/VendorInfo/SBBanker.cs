using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBBanker : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo("1041243", typeof(ContractOfEmployment), 2000, 20, 0x14F0, 0));
                Add(new GenericBuyInfo("1062332", typeof(VendorRentalContract), 1500, 20, 0x14F0, 0x672));
				
			}
        }

        public class InternalSellInfo : GenericSellInfo
        {
        }
    }
}
