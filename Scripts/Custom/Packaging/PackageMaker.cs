using System.Collections.Generic;
using Server.ContextMenus;
using Server.Custom.Gumps;
using System;
using Server.Items;
using Server.Custom.Packaging.Packages;

namespace Server.Mobiles
{
    public class PackageMaker : BaseVendor
    {
		private Type m_Currency = typeof(Marchandise);

		[CommandProperty(AccessLevel.Seer)]
		public Type Currency { get { return m_Currency; } set { m_Currency = value; } }

		private double m_Conversion = 1;

		[CommandProperty(AccessLevel.Seer)]
		public double Conversion { get { return m_Conversion; } set { m_Conversion = value; } }

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

            writer.Write(1); // version

			writer.Write(m_Currency.ToString());
			writer.Write(m_Conversion);

		
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			switch(version)
			{
				case 1:
				{
						m_Currency = ScriptCompiler.FindTypeByFullName(reader.ReadString());
						m_Conversion = reader.ReadDouble();
						break;
				}
			}
		}
    }
}
