using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Gumps;

namespace Server.Mobiles
{
    public class SlaveVendor : BaseVendor
    {

		private List<SlaveEntry> m_Inventory = new List<SlaveEntry>();

		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

		public List<SlaveEntry> Inventory => m_Inventory;

        [Constructable]
        public SlaveVendor()
            : base("Vendeur d'esclaves")
        {
        }
		public override StatutSocialEnum MinBuyClasse => StatutSocialEnum.Civenien;
		public SlaveVendor(Serial serial)
            : base(serial)
        {
        }

		public override void Restock()
		{
			LastRestock = DateTime.UtcNow;

			Inventory.Clear();

			for (int i = 0; i < 10; i++)
			{
				Inventory.Add(new SlaveEntry());
			}
		}

		public void RemoveSlave(int slave)
		{
			List<SlaveEntry> NewInventory = new List<SlaveEntry>();

			int i = 0;

			foreach (SlaveEntry item in Inventory)
			{
				if (i != slave)
				{
					NewInventory.Add(item);
				}
				i++;
			}
			m_Inventory = NewInventory;
		}


		protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {
			for (int i = 0; i < 10; i++)
			{
				Inventory.Add(new SlaveEntry());
			}
        }

		public override void VendorBuy(Mobile from)
		{
			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cm = (CustomPlayerMobile)from;

					if (cm.StatutSocial < MinBuyClasse && !ContreBandier)
					{
						Say("Seul les " + MinBuyClasse + "s et les classes supérieurs peuvent acheter ici");
						return;
					}
					else
					{
						from.SendGump(new SlaveVendorBuyGump((CustomPlayerMobile)from, this));
					}			
			}
		}
	
		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version	
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			switch(version)
			{
				case 1:break;
				case 0: reader.ReadInt(); break;
			}
		}
    }
}
