using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBJewel : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(GoldRing), 27, 20, 0x108A, 0));
                Add(new GenericBuyInfo(typeof(Necklace), 26, 20, 0x1085, 0));
                Add(new GenericBuyInfo(typeof(GoldNecklace), 27, 20, 0x1088, 0));
                Add(new GenericBuyInfo(typeof(GoldBeadNecklace), 27, 20, 0x1089, 0));
                Add(new GenericBuyInfo(typeof(Beads), 27, 20, 0x108B, 0, true));
                Add(new GenericBuyInfo(typeof(GoldBracelet), 27, 20, 0x1086, 0));
                Add(new GenericBuyInfo(typeof(GoldEarrings), 27, 20, 0x1087, 0));             
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Amber), 10);
                Add(typeof(Amethyst), 75);
                Add(typeof(Citrine), 5);
                Add(typeof(Diamond), 250);
                Add(typeof(Emerald), 200);
                Add(typeof(Ruby), 50);
                Add(typeof(Sapphire), 100);
                Add(typeof(StarSapphire), 150);
                Add(typeof(Tourmaline), 25);
                Add(typeof(GoldRing), 13);
                Add(typeof(SilverRing), 10);
                Add(typeof(Necklace), 13);
                Add(typeof(GoldNecklace), 13);
                Add(typeof(GoldBeadNecklace), 13);
                Add(typeof(SilverNecklace), 10);
                Add(typeof(SilverBeadNecklace), 10);
                Add(typeof(Beads), 13);
                Add(typeof(GoldBracelet), 13);
                Add(typeof(SilverBracelet), 10);
                Add(typeof(GoldEarrings), 13);
                Add(typeof(SilverEarrings), 10);
            }
        }
    }
}
