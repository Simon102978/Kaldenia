using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBSAWeapons : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(DualShortAxes), 83, 20, 0x8FD, 0));
                Add(new GenericBuyInfo(typeof(BloodBlade), 47, 20, 0x8FE, 0));
                Add(new GenericBuyInfo(typeof(Boomerang), 28, 20, 0x8FF, 0));
                Add(new GenericBuyInfo(typeof(Cyclone), 47, 20, 0x901, 0));
                Add(new GenericBuyInfo(typeof(Dagger), 20, 20, 0x902, 0));
                Add(new GenericBuyInfo(typeof(DiscMace), 62, 20, 0x903, 0));
                Add(new GenericBuyInfo(typeof(GlassStaff), 11, 20, 0x905, 0));
                Add(new GenericBuyInfo(typeof(SerpentStoneStaff), 30, 20, 0x906, 0));
                Add(new GenericBuyInfo(typeof(Shortblade), 57, 20, 0x907, 0));
                Add(new GenericBuyInfo(typeof(SoulGlaive), 68, 20, 0x090A, 0));
                Add(new GenericBuyInfo(typeof(Cleaver), 8, 20, 0x48AE, 0));
                Add(new GenericBuyInfo(typeof(BattleAxe), 22, 20, 0x48B0, 0));
                Add(new GenericBuyInfo(typeof(Axe), 23, 20, 0x48B2, 0));
                Add(new GenericBuyInfo(typeof(Bardiche), 47, 20, 0x48B4, 0));
                Add(new GenericBuyInfo(typeof(ButcherKnife), 8, 20, 0x48B6, 0));
                Add(new GenericBuyInfo(typeof(GnarledStaff), 11, 20, 0x48B8, 0));
                Add(new GenericBuyInfo(typeof(Katana), 17, 20, 0x48BA, 0));
                Add(new GenericBuyInfo(typeof(Kryss), 15, 20, 0x48BC, 0));
                Add(new GenericBuyInfo(typeof(WarFork), 15, 20, 0x48BE, 0));
                Add(new GenericBuyInfo(typeof(WarHammer), 16, 20, 0x48C0, 0));
                Add(new GenericBuyInfo(typeof(Maul), 13, 20, 0x48C2, 0));
                Add(new GenericBuyInfo(typeof(Scythe), 31, 20, 0x48C4, 0));
                Add(new GenericBuyInfo(typeof(BoneHarvester), 30, 20, 0x48C6, 0));
                Add(new GenericBuyInfo(typeof(Pike), 31, 20, 0x48C8, 0));
                Add(new GenericBuyInfo(typeof(Lance), 40, 20, 0x48CA, 0));
                Add(new GenericBuyInfo(typeof(Tessen), 23, 20, 0x48CC, 0));
                Add(new GenericBuyInfo(typeof(Tekagi), 18, 20, 0x48CE, 0));
                Add(new GenericBuyInfo(typeof(Daisho), 23, 20, 0x48D0, 0));
                Add(new GenericBuyInfo(typeof(GlassSword), 28, 20, 0x90C, 0));

            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(DualShortAxes), 41);
                Add(typeof(BloodBlade), 23);
                Add(typeof(Boomerang), 14);
                Add(typeof(Cyclone), 23);
                Add(typeof(Dagger), 10);
                Add(typeof(DiscMace), 31);
                Add(typeof(GlassStaff), 5);
                Add(typeof(SerpentStoneStaff), 15);
                Add(typeof(Shortblade), 28);
                Add(typeof(SoulGlaive), 34);
            
                Add(typeof(Cleaver), 4);
                Add(typeof(BattleAxe), 11);
                Add(typeof(Axe), 11);
                Add(typeof(Bardiche), 23);
                Add(typeof(ButcherKnife), 4);
                Add(typeof(GnarledStaff), 5);
                Add(typeof(Katana), 8);
                Add(typeof(Kryss), 7);
                Add(typeof(WarFork), 7);
                Add(typeof(WarHammer), 8);
                Add(typeof(Maul), 6);
                Add(typeof(Scythe), 15);
                Add(typeof(BoneHarvester), 15);
                Add(typeof(Pike), 15);
                Add(typeof(Lance), 20);
                Add(typeof(Tessen), 11);
                Add(typeof(Tekagi), 9);
                Add(typeof(Daisho), 11);
                Add(typeof(GlassSword), 14);
            }
        }
    }
}
