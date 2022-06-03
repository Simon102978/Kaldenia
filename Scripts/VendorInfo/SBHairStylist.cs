using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBHairStylist : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
               
                Add(new GenericBuyInfo("1041060", typeof(HairDye), 60, 20, 0xEFF, 0));

				Add(new GenericBuyInfo("Long", typeof(LongHair), 25, Utility.RandomMinMax(35, 45), 0x203C, 0));
				Add(new GenericBuyInfo("Short", typeof(ShortHair), 25, Utility.RandomMinMax(35, 45), 0x203B, 0));
				Add(new GenericBuyInfo("Mohawk", typeof(Mohawk), 25, Utility.RandomMinMax(35, 45), 0x2044, 0));
				Add(new GenericBuyInfo("Pageboy Hair", typeof(PageboyHair), 25, Utility.RandomMinMax(35, 45), 0x2045, 0));
				Add(new GenericBuyInfo("Buns Hair", typeof(BunsHair), 25, Utility.RandomMinMax(35, 45), 0x2046, 0));
				Add(new GenericBuyInfo("Pony Tail", typeof(PonyTail), 25, Utility.RandomMinMax(35, 45), 0x203D, 0));
				Add(new GenericBuyInfo("Afro", typeof(Afro), 25, Utility.RandomMinMax(35, 45), 0x2047, 0));
				Add(new GenericBuyInfo("Receeding Hair", typeof(ReceedingHair), 25, Utility.RandomMinMax(35, 45), 0x2048, 0));
				Add(new GenericBuyInfo("Two Pig Tails", typeof(TwoPigTails), 25, Utility.RandomMinMax(35, 45), 0x2049, 0));
				Add(new GenericBuyInfo("Krisna Hair", typeof(KrisnaHair), 25, Utility.RandomMinMax(35, 45), 0x204A, 0));
				Add(new GenericBuyInfo("Cheveuxcourt1", typeof(Cheveuxcourt1), 25, Utility.RandomMinMax(35, 45), 0xA385, 0));
				Add(new GenericBuyInfo("Cheveuxcourt2", typeof(Cheveuxcourt2), 25, Utility.RandomMinMax(35, 45), 0xA386, 0));
				Add(new GenericBuyInfo("Cheveuxcourt3", typeof(Cheveuxcourt3), 25, Utility.RandomMinMax(35, 45), 0xA387, 0));
				Add(new GenericBuyInfo("Cheveuxcourt4", typeof(Cheveuxcourt4), 25, Utility.RandomMinMax(35, 45), 0xA388, 0));
				Add(new GenericBuyInfo("Cheveuxcourt6", typeof(Cheveuxcourt6), 25, Utility.RandomMinMax(35, 45), 0xA38A, 0));
				Add(new GenericBuyInfo("Cheveuxcourt9", typeof(Cheveuxcourt9), 25, Utility.RandomMinMax(35, 45), 0xA38D, 0));
				Add(new GenericBuyInfo("Mohawk1", typeof(Mohawk1), 25, Utility.RandomMinMax(35, 45), 0xA38E, 0));
				Add(new GenericBuyInfo("ponytail1", typeof(ponytail1), 25, Utility.RandomMinMax(35, 45), 0xA390, 0));
				Add(new GenericBuyInfo("CheveuxLong6", typeof(CheveuxLong6), 25, Utility.RandomMinMax(35, 45), 0xA398, 0));
				Add(new GenericBuyInfo("CheveuxEpaules3", typeof(CheveuxEpaules3), 25, Utility.RandomMinMax(35, 45), 0xA39C, 0));
				Add(new GenericBuyInfo("ponytail5", typeof(ponytail5), 25, Utility.RandomMinMax(35, 45), 0xA3A0, 0));
				Add(new GenericBuyInfo("CheveuxEpaules4", typeof(CheveuxEpaules4), 25, Utility.RandomMinMax(35, 45), 0xA3A1, 0));
				Add(new GenericBuyInfo("CheveuxLong10", typeof(CheveuxLong10), 25, Utility.RandomMinMax(35, 45), 0xA3A4, 0));
				Add(new GenericBuyInfo("CheveuxLong11", typeof(CheveuxLong11), 25, Utility.RandomMinMax(35, 45), 0xA3A5, 0));
				Add(new GenericBuyInfo("Goatee", typeof(Goatee), 25, Utility.RandomMinMax(35, 45), 0x2040, 0));
				Add(new GenericBuyInfo("Long Beard", typeof(LongBeard), 25, Utility.RandomMinMax(35, 45), 0x203E, 0));
				Add(new GenericBuyInfo("ShortBeard", typeof(ShortBeard), 25, Utility.RandomMinMax(35, 45), 0x203f, 0));
				Add(new GenericBuyInfo("Mustache", typeof(Mustache), 25, Utility.RandomMinMax(35, 45), 0x2041, 0));
				Add(new GenericBuyInfo("Medium Short Beard", typeof(MediumShortBeard), 25, Utility.RandomMinMax(35, 45), 0x204B, 0));
				Add(new GenericBuyInfo("Medium Long Beard", typeof(MediumLongBeard), 25, Utility.RandomMinMax(35, 45), 0x204C, 0));
				Add(new GenericBuyInfo("Vandyke", typeof(Vandyke), 25, Utility.RandomMinMax(35, 45), 0x204D, 0));
				Add(new GenericBuyInfo("Sourcils1", typeof(Sourcils1), 25, Utility.RandomMinMax(35, 45), 0xA3A7, 0));
				Add(new GenericBuyInfo("Sourcils2", typeof(Sourcils2), 25, Utility.RandomMinMax(35, 45), 0xA3A8, 0));
				Add(new GenericBuyInfo("Barbe6", typeof(Barbe6), 25, Utility.RandomMinMax(35, 45), 0xA3B9, 0));
				Add(new GenericBuyInfo("Barbe7", typeof(Barbe7), 25, Utility.RandomMinMax(35, 45), 0xA3BA, 0));
				Add(new GenericBuyInfo("LongueBarbe6", typeof(LongueBarbe6), 25, Utility.RandomMinMax(35, 45), 0xA3BB, 0));
				Add(new GenericBuyInfo("Barbe8", typeof(Barbe8), 25, Utility.RandomMinMax(35, 45), 0xA3BC, 0));
				Add(new GenericBuyInfo("LongueBarbe7", typeof(LongueBarbe7), 25, Utility.RandomMinMax(35, 45), 0xA3BD, 0));

			}
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(HairDye), 30);
                Add(typeof(SpecialBeardDye), 250000);
                Add(typeof(SpecialHairDye), 250000);
            }
        }
    }
}
