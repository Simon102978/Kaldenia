using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBAxeWeapon : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(ExecutionersAxe), 30, 20, 0xF45, 0));
                Add(new GenericBuyInfo(typeof(BattleAxe), 26, 20, 0xF47, 0));
                Add(new GenericBuyInfo(typeof(TwoHandedAxe), 32, 20, 0x1443, 0));
                Add(new GenericBuyInfo(typeof(Axe), 40, 20, 0xF49, 0));
                Add(new GenericBuyInfo(typeof(DoubleAxe), 52, 20, 0xF4B, 0));
                Add(new GenericBuyInfo(typeof(Pickaxe), 22, 20, 0xE86, 0));
                Add(new GenericBuyInfo(typeof(LargeBattleAxe), 33, 20, 0x13FB, 0));
                Add(new GenericBuyInfo(typeof(WarAxe), 29, 20, 0x13B0, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(BattleAxe), 3);
                Add(typeof(DoubleAxe), 6);
                Add(typeof(ExecutionersAxe), 5);
                Add(typeof(LargeBattleAxe), 6);
                Add(typeof(Pickaxe), 1);
                Add(typeof(TwoHandedAxe), 6);
                Add(typeof(WarAxe), 4);
                Add(typeof(Axe), 2);
            }
        }
    }
}
