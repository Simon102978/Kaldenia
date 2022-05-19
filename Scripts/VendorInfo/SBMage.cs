using Server.Items;
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBMage : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(NewSpellbook), 250, 10, 0xEFA, 0));

                

                Add(new GenericBuyInfo(typeof(ScribesPen), 8, 10, 0xFBF, 0));

                Add(new GenericBuyInfo(typeof(BlankScroll), 5, 20, 0x0E34, 0));

                Add(new GenericBuyInfo(typeof(RecallRune), 15, 10, 0x1F14, 0));

               

                Add(new GenericBuyInfo(typeof(BlackPearl), 5, 999, 0xF7A, 0));
                Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 999, 0xF7B, 0));
                Add(new GenericBuyInfo(typeof(Garlic), 5, 999, 0xF84, 0));
                Add(new GenericBuyInfo(typeof(Ginseng), 5, 999, 0xF85, 0));
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 5, 999, 0xF86, 0));
                Add(new GenericBuyInfo(typeof(Nightshade), 5, 999, 0xF88, 0));
                Add(new GenericBuyInfo(typeof(SpidersSilk), 5, 999, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 5, 999, 0xF8C, 0));

                Add(new GenericBuyInfo(typeof(BatWing), 5, 999, 0xF78, 0));
                Add(new GenericBuyInfo(typeof(DaemonBlood), 5, 999, 0xF7D, 0));
                Add(new GenericBuyInfo(typeof(PigIron), 5, 999, 0xF8A, 0));
                Add(new GenericBuyInfo(typeof(NoxCrystal), 5, 999, 0xF8E, 0));
                Add(new GenericBuyInfo(typeof(GraveDust), 5, 999, 0xF8F, 0));

                }
            }
        }
}





            
        
    

