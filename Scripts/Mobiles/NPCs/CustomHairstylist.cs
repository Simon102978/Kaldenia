#region References
using Server.Gumps;
using Server.Items;
using Server.Network;
using System;
using System.Collections.Generic;
#endregion

namespace Server.Mobiles
{
    public class CustomHairstylist : BaseVendor
    {
        public static readonly object From = new object();
        public static readonly object Vendor = new object();
        public static readonly object Price = new object();

        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public CustomHairstylist()
            : base("the hairstylist")
        { }

        public CustomHairstylist(Serial serial)
            : base(serial)
        { }

        public override bool ClickTitle => false;
        public override bool IsActiveBuyer => false;
        public override bool IsActiveSeller => true;
        public override VendorShoeType ShoeType => Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals;
        protected override List<SBInfo> SBInfos => m_SBInfos;

        public override bool OnBuyItems(Mobile buyer, List<BuyItemResponse> list)
        {
            return false;
        }

        public override void VendorBuy(Mobile from)
        {
			if (from is CustomPlayerMobile)
			{
				from.SendGump(new CustomCoiffureGump((CustomPlayerMobile)from, 0));
			}

               

        }

        public override int GetHairHue()
        {
            return Utility.RandomBrightHue();
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem(new Robe(Utility.RandomPinkHue()));
        }

        public override bool CheckVendorAccess(Mobile from)
        {


            return base.CheckVendorAccess(from);
        }

        public override void InitSBInfo()
        { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }


}
