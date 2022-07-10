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
				Add(new GenericBuyInfo(typeof(Bait), 3, 100, 0xDCF, 0));
				Add(new GenericBuyInfo("Cage � Homards Vide", typeof(LobsterTrap), 10, 50, 17615, 0));
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
				Add(typeof(KingCrab), 9);
				Add(typeof(RockCrab), 10);
				Add(typeof(SnowCrab), 10);
				Add(typeof(StoneCrab), 10);
				Add(typeof(SpiderCrab), 10);
				Add(typeof(TunnelCrab), 10);
				Add(typeof(VoidCrab), 10);

				Add(typeof(Lobster), 3);
				Add(typeof(CrustyLobster), 3);
				Add(typeof(FredLobster), 5);
				Add(typeof(HummerLobster), 7);
				Add(typeof(RockLobster), 8);
				Add(typeof(ShovelNoseLobster), 9);
				Add(typeof(SpineyLobster), 10);
				Add(typeof(BlueLobster), 10);
				Add(typeof(BloodLobster), 10);
				Add(typeof(DreadLobster), 10);
				Add(typeof(VoidLobster), 10);

				Add(typeof(StoneCrabMeat), 5);
				Add(typeof(SpiderCrabMeat), 5);
				Add(typeof(BlueLobsterMeat), 5);

				/// Ajouts poissons sp�ciaux ///
				
				Add(typeof(AutumnDragonfish), 5);
				Add(typeof(BullFish), 3);
				Add(typeof(CrystalFish), 3);
				Add(typeof(FairySalmon), 3);
				Add(typeof(FireFish), 3);
				Add(typeof(GiantKoi), 4);
				Add(typeof(GreatBarracuda), 4);
				Add(typeof(HolyMackerel), 4);
				Add(typeof(LavaFish), 4);
				Add(typeof(ReaperFish), 4);
				Add(typeof(SummerDragonfish), 5);
				Add(typeof(UnicornFish), 5);
				Add(typeof(YellowtailBarracuda), 5);
				Add(typeof(AbyssalDragonfish), 6);
				Add(typeof(BlackMarlin), 6);
				Add(typeof(BlueMarlin), 6);
				Add(typeof(DungeonPike), 6);
				Add(typeof(GiantSamuraiFish), 6);
				Add(typeof(GoldenTuna), 6);
				Add(typeof(Kingfish), 6);
				Add(typeof(LanternFish), 6);
				Add(typeof(RainbowFish), 6);
				Add(typeof(SeekerFish), 6);
				Add(typeof(SpringDragonfish), 6);
				Add(typeof(StoneFish), 6);
				Add(typeof(WinterDragonfish), 6);
				Add(typeof(ZombieFish), 6);
			
			}
		}
	}
}
