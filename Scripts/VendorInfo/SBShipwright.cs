using Server.Items;
using Server.Multis;
using Server.Regions;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBShipwright : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo;
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBShipwright(Mobile m)
        {
            if (m != null)
            {
                m_BuyInfo = new InternalBuyInfo(m);
            }
        }

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo(Mobile m)
            {
				//     Add(new GenericBuyInfo("1041205", typeof(SmallBoatDeed), 10177, 20, 0x14F2, 0));
				//     Add(new GenericBuyInfo("1041206", typeof(SmallDragonBoatDeed), 10177, 20, 0x14F2, 0));
				//     Add(new GenericBuyInfo("1041207", typeof(MediumBoatDeed), 11552, 20, 0x14F2, 0));
				//     Add(new GenericBuyInfo("1041208", typeof(MediumDragonBoatDeed), 11552, 20, 0x14F2, 0));
				//     Add(new GenericBuyInfo("1041209", typeof(LargeBoatDeed), 12927, 20, 0x14F2, 0));
				//     Add(new GenericBuyInfo("1041210", typeof(LargeDragonBoatDeed), 12927, 20, 0x14F2, 0));

				Add(new GenericBuyInfo("Grand Bateau", typeof(BritannianShipDeed), 200000, 3, 0x14F2, 0));
				Add(new GenericBuyInfo("Moyen Bateau", typeof(TokunoGalleonDeed), 150000, 3, 0x14F2, 0));
				Add(new GenericBuyInfo("Petit Bateau", typeof(GalleonDeed), 100000, 3, 0x14F2, 0));
				//     Add(new GenericBuyInfo("1116491", typeof(RowBoatDeed), 6252, 20, 0x14F2, 0));


				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 276, new object[] { 276 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 396, new object[] { 396 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 516, new object[] { 516 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 1900, new object[] { 1900 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 251, new object[] { 251 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 246, new object[] { 246 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 2213, new object[] { 2213 }));
				Add(new GenericBuyInfo("Boat Paint", typeof(BoatPaint), 6256, 20, 4011, 36, new object[] { 36 }));
				Add(new GenericBuyInfo("Boat Paint Remover", typeof(BoatPaintRemover), 6256, 20, 4011, 0));


				Add(new GenericBuyInfo(typeof(Spyglass), 3, 20, 0x14F5, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                //You technically CAN sell them back, *BUT* the vendors do not carry enough money to buy with
                Add(typeof(Spyglass), 1);
				Add(typeof(LobsterTrap), 10);
			}
        }
    }
}
