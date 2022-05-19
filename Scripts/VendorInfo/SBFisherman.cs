using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBFisherman : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                

                Add(new GenericBuyInfo(typeof(FishingPole), 15, 20, 0xDC0, 0));
				Add(new GenericBuyInfo("empty lobster trap", typeof(LobsterTrap), 100, 500, 17615, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(RawFishSteak), 1);
                Add(typeof(Fish), 1);
                Add(typeof(SmallFish), 1);
                Add(typeof(FishingPole), 7);
				Add(typeof(LobsterTrap), 10);
				Add(typeof(AppleCrab), 1);
				Add(typeof(BlueCrab), 1);
				Add(typeof(DungeonessCrab), 1);
				Add(typeof(KingCrab), 1);
				Add(typeof(RockCrab), 1);
				Add(typeof(SnowCrab), 1);
				Add(typeof(StoneCrab), 1);
				Add(typeof(SpiderCrab), 1);
				Add(typeof(TunnelCrab), 100);
				Add(typeof(VoidCrab), 100);

				Add(typeof(CrustyLobster), 1);
				Add(typeof(FredLobster), 1);
				Add(typeof(HummerLobster), 1);
				Add(typeof(RockLobster), 1);
				Add(typeof(ShovelNoseLobster), 1);
				Add(typeof(SpineyLobster), 1);
				Add(typeof(BlueLobster), 25);
				Add(typeof(BloodLobster), 250);
				Add(typeof(DreadLobster), 250);
				Add(typeof(VoidLobster), 250);

				Add(typeof(StoneCrabMeat), 10);
				Add(typeof(SpiderCrabMeat), 10);
				Add(typeof(BlueLobsterMeat), 10);
			}
        }
    }
}
