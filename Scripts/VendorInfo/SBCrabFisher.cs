using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBCrabFisher : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo("empty lobster trap", typeof(LobsterTrap), 137, 500, 17615, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(LobsterTrap), 1);
                Add(typeof(AppleCrab), 1);
                Add(typeof(BlueCrab), 1);
                Add(typeof(DungeonessCrab), 1);
                Add(typeof(KingCrab), 1);
                Add(typeof(RockCrab), 1);
                Add(typeof(SnowCrab), 1);
                Add(typeof(StoneCrab), 25);
                Add(typeof(SpiderCrab), 25);
                Add(typeof(TunnelCrab), 25);
                Add(typeof(VoidCrab), 25);

                Add(typeof(CrustyLobster), 1);
                Add(typeof(FredLobster), 1);
                Add(typeof(HummerLobster), 1);
                Add(typeof(RockLobster), 1);
                Add(typeof(ShovelNoseLobster), 1);
                Add(typeof(SpineyLobster), 1);
                Add(typeof(BlueLobster), 25);
                Add(typeof(BloodLobster), 25);
                Add(typeof(DreadLobster), 25);
                Add(typeof(VoidLobster), 25);

                Add(typeof(StoneCrabMeat), 1);
                Add(typeof(SpiderCrabMeat), 1);
                Add(typeof(BlueLobsterMeat), 1);
            }
        }
    }
}
