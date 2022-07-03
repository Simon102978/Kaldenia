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
				Add(new GenericBuyInfo("empty lobster trap", typeof(LobsterTrap), 25, 50, 17615, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(RawFishSteak), 2);
                Add(typeof(Fish), 3);
                Add(typeof(SmallFish), 1);
                Add(typeof(FishingPole), 7);
				Add(typeof(LobsterTrap), 10);
				Add(typeof(Crab), 3);
				Add(typeof(AppleCrab), 3);
				Add(typeof(BlueCrab), 5);
				Add(typeof(DungeonessCrab), 7);
				Add(typeof(KingCrab), 10);
				Add(typeof(RockCrab), 15);
				Add(typeof(SnowCrab), 20);
				Add(typeof(StoneCrab), 25);
				Add(typeof(SpiderCrab), 25);
				Add(typeof(TunnelCrab), 25);
				Add(typeof(VoidCrab), 25);

				Add(typeof(Lobster), 3);
				Add(typeof(CrustyLobster), 3);
				Add(typeof(FredLobster), 5);
				Add(typeof(HummerLobster), 7);
				Add(typeof(RockLobster), 10);
				Add(typeof(ShovelNoseLobster), 15);
				Add(typeof(SpineyLobster), 20);
				Add(typeof(BlueLobster), 25);
				Add(typeof(BloodLobster), 25);
				Add(typeof(DreadLobster), 25);
				Add(typeof(VoidLobster), 25);

				Add(typeof(StoneCrabMeat), 5);
				Add(typeof(SpiderCrabMeat), 5);
				Add(typeof(BlueLobsterMeat), 5);
			}
        }
    }
}
