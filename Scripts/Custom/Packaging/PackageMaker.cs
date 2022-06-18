using System.Collections.Generic;
using Server.ContextMenus;
using Server.Custom.Gumps;

namespace Server.Mobiles
{
    public class PackageMaker : BaseVendor
    {
		[CommandProperty(AccessLevel.GameMaster)]
		public int SlavePrice { get; set; } = 1000;
		
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public PackageMaker() : base("Package Maker")
        {
        }

        public PackageMaker(Serial serial)
            : base(serial)
        {
        }

        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {

        }

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			for(int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i] is VendorBuyEntry)
					list.RemoveAt(i);
				else if (list[i] is VendorSellEntry)
						list.RemoveAt(i);
			}

			var pm = from as PlayerMobile;

			if (pm != null)
				list.Add(new PackageMakerBuyMenu(pm, this));
		}

		public class PackageMakerBuyMenu : ContextMenuEntry
		{
			private readonly PlayerMobile _From;
			private readonly PackageMaker _Vendor;

			public PackageMakerBuyMenu(PlayerMobile from, PackageMaker vendor) : base(6103, 8)
			{
				_From = from;
				_Vendor = vendor;
			}

			public override void OnClick()
			{
				_From.SendGump(new PackageMakerGump(_From, _Vendor));
			}
		}

		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version

			writer.Write(SlavePrice);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			switch(version)
			{
				case 0: SlavePrice = reader.ReadInt(); break;
			}
		}
    }
}
