using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBDocksAlchemist : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo("1116302", typeof(Saltpeter), 167, 20, 16954, 1150));

                Add(new GenericBuyInfo(typeof(RefreshPotion), 15, 10, 0xF0B, 0));
                Add(new GenericBuyInfo(typeof(AgilityPotion), 15, 10, 0xF08, 0));
                Add(new GenericBuyInfo(typeof(NightSightPotion), 15, 10, 0xF06, 0));
                Add(new GenericBuyInfo(typeof(LesserHealPotion), 15, 10, 0xF0C, 0));
                Add(new GenericBuyInfo(typeof(StrengthPotion), 15, 10, 0xF09, 0));
                Add(new GenericBuyInfo(typeof(LesserPoisonPotion), 15, 10, 0xF0A, 0));
                Add(new GenericBuyInfo(typeof(LesserCurePotion), 15, 10, 0xF07, 0));
                Add(new GenericBuyInfo(typeof(LesserExplosionPotion), 21, 10, 0xF0D, 0));
                Add(new GenericBuyInfo(typeof(MortarPestle), 8, 10, 0xE9B, 0));

                Add(new GenericBuyInfo(typeof(BlackPearl), 5, 20, 0xF7A, 0));
                Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 20, 0xF7B, 0));
                Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
                Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 3, 20, 0xF86, 0));
                Add(new GenericBuyInfo(typeof(Nightshade), 3, 20, 0xF88, 0));
                Add(new GenericBuyInfo(typeof(SpidersSilk), 3, 20, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 3, 20, 0xF8C, 0));

                Add(new GenericBuyInfo(typeof(Bottle), 5, 100, 0xF0E, 0));
                Add(new GenericBuyInfo(typeof(HeatingStand), 2, 100, 0x1849, 0));

                Add(new GenericBuyInfo("1041060", typeof(HairDye), 37, 10, 0xEFF, 0));

                Add(new GenericBuyInfo(typeof(HeatingStand), 2, 100, 0x1849, 0)); // This is on OSI :-P
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Saltpeter), 1);

                Add(typeof(BlackPearl), 1);
                Add(typeof(Bloodmoss), 1);
                Add(typeof(MandrakeRoot), 1);
                Add(typeof(Garlic), 1);
                Add(typeof(Ginseng), 1);
                Add(typeof(Nightshade), 1);
                Add(typeof(SpidersSilk), 1);
                Add(typeof(SulfurousAsh), 1);
                Add(typeof(Bottle), 1);
                Add(typeof(MortarPestle), 1);
                Add(typeof(HairDye), 1);

                Add(typeof(NightSightPotion), 1);
                Add(typeof(AgilityPotion), 1);
                Add(typeof(StrengthPotion), 1);
                Add(typeof(RefreshPotion), 1);
                Add(typeof(LesserCurePotion), 1);
                Add(typeof(LesserHealPotion), 1);
                Add(typeof(LesserPoisonPotion), 1);
                Add(typeof(LesserExplosionPotion), 1);
            }
        }
    }
}
