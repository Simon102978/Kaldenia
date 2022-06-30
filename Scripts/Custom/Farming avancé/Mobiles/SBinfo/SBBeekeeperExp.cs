using System;
using System.Collections.Generic;
using Server.Items;
using Server.Engines.Apiculture;

namespace Server.Mobiles
{
	public class SBBeekeeperExp : SBInfo
	{
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBeekeeperExp()
		{
		}

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return this.m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
                Add(new GenericBuyInfo(typeof(apiBeeHiveDeed), 2000, 10, 2330, 0));
                Add(new GenericBuyInfo(typeof(HiveTool), 100, 20, 2549, 0));
                Add(new GenericBuyInfo(typeof(apiWaxProcessingPot), 400, 20, 2532, 0));
				Add(new GenericBuyInfo(typeof(JarHoney), 3, 20, 0x9EC, 0));
				Add(new GenericBuyInfo(typeof(Beeswax), 2, 20, 0x1422, 0));

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
                Add(typeof(apiBeeHiveDeed), 100);
                Add(typeof(HiveTool), 50);
                Add(typeof(apiWaxProcessingPot), 12);
				Add(typeof(JarHoney), 1);
				Add(typeof(Beeswax), 1);

			}
		}
	}
}
