using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBBeerBrewer : SBInfo
	{
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBeerBrewer()
		{
		}

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
			Add( new GenericBuyInfo( typeof( BeerBreweringTools ), 3000, 90, 0xE7F, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
        Add( typeof( LongNeckBottleOfBudLight ), 2 );
        Add( typeof( LongNeckBottleOfBudWiser ), 2 );
        Add( typeof( LongNeckBottleOfCoolersLite ), 2 );
        Add( typeof( LongNeckBottleOfCorna ), 4 );
        Add( typeof( LongNeckBottleOfCornaLite ), 4 );
        Add( typeof( LongNeckBottleOfMillerLite ), 2 );
        Add( typeof( LongNeckBottleOfMGD ), 2 );
        Add( typeof( LongNeckBottleOfWildturkey ), 5 );
        Add( typeof( BeerKeg ), 10 );
        Add( typeof( PonyKeg ), 10 );
     
			}
		}
	}
}
