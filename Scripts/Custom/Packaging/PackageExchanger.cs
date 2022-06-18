using System.Collections.Generic;
using Server.ContextMenus;
using Server.Custom.Gumps;
using Server.Targeting;
using Server.Custom.Packaging.Packages;

namespace Server.Mobiles
{
    public class PackageExchanger : BaseVendor
    {
	/*	[CommandProperty(AccessLevel.GameMaster)]
		public int SlavePrice { get; set; } = 1000;*/
		
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public PackageExchanger() : base("Package Exchanger")
        {
        }

        public PackageExchanger(Serial serial)
            : base(serial)
        {
        }

        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {

        }

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			//	base.GetContextMenuEntries(from, list);

			/*	for(int i = list.Count - 1; i >= 0; i--)
				{
					if (list[i] is VendorBuyEntry)
						list.RemoveAt(i);
					else if (list[i] is VendorSellEntry)
							list.RemoveAt(i);
				}*/

			if (CanPaperdollBeOpenedBy(from))
			{
				list.Add(new PaperdollEntry(this));
			}

			var pm = from as PlayerMobile;

			if (pm != null)
				list.Add(new VendorSellEntry(pm, this));
		}


		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (dropped is CustomPackaging)
			{
				CustomPackaging cp = (CustomPackaging)dropped;

				cp.Finaliser(from);

				return true;
			}
			
			return base.OnDragDrop(from, dropped);
		}

		public class VendorSellEntry : ContextMenuEntry
		{
			private readonly BaseVendor m_Vendor;
			private Mobile m_From;

			public VendorSellEntry(Mobile from, BaseVendor vendor)
				: base(6104, 8)
			{
				m_From = from;
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				m_From.Target = new InternalTarget(m_From, m_Vendor);
				m_From.SendMessage("Veuillez selectionner le paquet.");
			}
			private class InternalTarget : Target
			{
				public Mobile From { get; set; }
				public BaseVendor Vendor { get; set; }

				public InternalTarget(Mobile from, BaseVendor vendor)
					: base(1, false, TargetFlags.None)
				{
					From = from;
					Vendor = vendor;
				}

				protected override void OnTarget(Mobile from, object targeted)
				{
					if (targeted is CustomPackaging)
					{
						CustomPackaging cp = (CustomPackaging)targeted;

						cp.Finaliser(from);
					}
					else
					{
						from.SendMessage("Ceci n'est pas un paquet recevable.");
						from.Target = new InternalTarget(from, Vendor);
					}
				}
			}




		}


		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version

	//		writer.Write(SlavePrice);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

		/*	switch(version)
			{
				case 0: SlavePrice = reader.ReadInt(); break;
			}*/
		}
    }
}
