using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.Gumps
{
	public class SlaveVendorBuyGump : Gump
	{
		public class SlaveEntry
		{
			private readonly Type m_Type;
			private readonly string m_Name;
			private readonly int m_ItemID;
			private readonly int m_offsetX;
			private readonly int m_offsetY;

			public Type Type => m_Type;
			public string Name => m_Name;
			public int ItemID => m_ItemID;
			public int OffsetX => m_offsetX;
			public int OffsetY => m_offsetY;

			public SlaveEntry(
				Type type,
				string name,
				int itemID,
				int offsetX,
				int offsetY )
			{
				m_Type = type;
				m_Name = name;
				m_ItemID = itemID;
				m_offsetX = offsetX;
				m_offsetY = offsetY;
			}
		}

		private static readonly SlaveEntry[] m_Entries = new[]
		{
			new SlaveEntry(typeof(HireMaleSlave), "Esclave mâle", 0x2106, -20, -25),
			new SlaveEntry(typeof(HireFemaleSlave), "Esclave femelle", 0x2107, -20, -25),
		};

		public static SlaveEntry[] Entries => m_Entries;

		private readonly PlayerMobile m_Buyer;
		private readonly SlaveVendor m_Vendor;

		public SlaveVendorBuyGump(PlayerMobile buyer, SlaveVendor vendor) : base(50, 50)
		{
			m_Buyer = buyer;
			m_Vendor = vendor;

			AddPage(0);

			AddBackground(0, 0, 520, 204, 0x13BE);
			AddImageTiled(10, 10, 500, 20, 0xA40);
			AddImageTiled(10, 40, 500, 124, 0xA40);
			AddImageTiled(10, 174, 500, 20, 0xA40);
			AddAlphaRegion(10, 10, 500, 184);

			AddHtml(14, 12, 500, 20, Color("<CENTER>Menu de sélection des esclaves</CENTER>", 0xFFFFFF), false, false);

			AddButton(10, 174, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0);
			AddHtml(45, 176, 450, 20, Color("Annuler", 0xFFFFFF), false, false);

			int current = 0;

			for (int i = 0; i < Entries.Length; ++i)
			{
				bool enabled = true;

				int page = current / 2 + 1;
				int pos = current % 2;

				if (pos == 0)
				{
					if (page > 1)
					{
						AddButton(400, 374, 0xFA5, 0xFA7, 0, GumpButtonType.Page, page);
						AddHtmlLocalized(440, 376, 60, 20, 1043353, 0x7FFF, false, false); // Next
					}

					AddPage(page);

					if (page > 1)
					{
						AddButton(300, 374, 0xFAE, 0xFB0, 0, GumpButtonType.Page, 1);
						AddHtmlLocalized(340, 376, 60, 20, 1011393, 0x7FFF, false, false); // Back
					}
				}

				if (enabled)
				{
					int x = (pos % 2 == 0) ? 14 : 264;
					int y = (pos / 2) * 64 + 44;

					Rectangle2D b = ItemBounds.Table[Entries[i].ItemID];

					AddImageTiledButton(
						x,
						y,
						0x918,
						0x919,
						i + 1,
						GumpButtonType.Reply,
						0,
						Entries[i].ItemID,
						0,
						40 - b.Width / 2 - b.X + Entries[i].OffsetX,
						30 - b.Height / 2 - b.Y + Entries[i].OffsetY,
						0);
					AddHtml(x + 84, y, 250, 60, Color(string.Format(Entries[i].Name), 0xFFFFFF), false, false);
					AddHtml(x + 84, y + 20, 250, 60, Color(string.Format($"{m_Vendor.SlavePrice} po"), 0xFFFFFF), false, false);

					current++;
				}
			}
		}

		private string Color(string str, int color)
		{
			return string.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, str);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			int entryID = info.ButtonID - 1;

			if (entryID < 0 || entryID >= m_Entries.Length)
			{
				return;
			}

			SlaveEntry entry = Entries[entryID];

			if (!ConsumeFromBank.GoldConsumption(m_Buyer, m_Vendor.SlavePrice))
			{
				m_Buyer.SendMessage("Vous n'avez pas suffisamment de pièces d'or dans votre banque pour acheter ceci.");
				return;
			}

			m_Buyer.SendMessage($"{m_Vendor.SlavePrice} pièces d'or ont été débité de votre banque.");

			var slave = (BaseHire)Activator.CreateInstance(entry.Type);
			slave.MoveToWorld(m_Buyer.Location, m_Buyer.Map);
			slave.Controlled = true;
			slave.ControlMaster = m_Buyer;
			slave.ControlOrder = OrderType.Come;
		}
	}
}
