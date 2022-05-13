using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBSAArmor : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
 
                Add(new GenericBuyInfo(typeof(PlateArms), 328, 20, 0x308, 0));
                Add(new GenericBuyInfo(typeof(FemalePlateChest), 481, 20, 0x309, 0));
                Add(new GenericBuyInfo(typeof(PlateChest), 462, 20, 0x30A, 0));

                Add(new GenericBuyInfo(typeof(PlateLegs), 355, 20, 0x30E, 0));

                Add(new GenericBuyInfo(typeof(PlateArms), 121, 20, 0x284, 0));
			}
		}

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {

                Add(typeof(PlateArms), 164);
                Add(typeof(FemalePlateChest), 240);
                Add(typeof(PlateChest), 231);

                Add(typeof(PlateLegs), 177);


            }
        }
    }
}
