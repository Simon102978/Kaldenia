using System;
using Server.Custom.Packaging.Packages;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.Gumps
{
	public class PackageExchangerGump : Gump
	{
		public class PackageEntry
		{
			private readonly Type m_Type;
			private readonly string m_Name;
			private readonly int m_ItemID;
			private readonly int m_Price;
			private readonly int m_offsetX;
			private readonly int m_offsetY;

			public Type Type => m_Type;
			public string Name => m_Name;
			public int ItemID => m_ItemID;
			public int Price => m_Price;
			public int OffsetX => m_offsetX;
			public int OffsetY => m_offsetY;

			public PackageEntry(
				Type type,
				string name,
				int itemID,
				int price,
				int offsetX,
				int offsetY)
			{
				m_Type = type;
				m_Name = name;
				m_ItemID = itemID;
				m_Price = price;
				m_offsetX = offsetX;
				m_offsetY = offsetY;
			}
		}

		private static readonly PackageEntry[] m_Entries = new[]
		{
			new PackageEntry(typeof(SmallPackage), "Petite caisse", 0x0E7E, 500, 0, 0),
			new PackageEntry(typeof(MediumPackage), "Moyenne caisse", 0x0E3E, 1000, 0, 0),
			new PackageEntry(typeof(LargePackage), "Grosse caisse", 0x0E3C, 2000, 0, 0),
		};

		public static PackageEntry[] Entries => m_Entries;

		private readonly PlayerMobile m_Buyer;
		private readonly PackageExchanger m_Exchanger;

		public PackageExchangerGump(PlayerMobile buyer, PackageExchanger exchanger) : base(50, 50)
		{
			m_Buyer = buyer;
			m_Exchanger = exchanger;

			AddPage(0);

			AddBackground(0, 0, 520, 304, 0x13BE);
			AddImageTiled(10, 10, 500, 20, 0xA40);
			AddImageTiled(10, 40, 500, 224, 0xA40);
			AddImageTiled(10, 274, 500, 20, 0xA40);
			AddAlphaRegion(10, 10, 500, 284);

			AddHtml(14, 12, 500, 20, Color("<CENTER>Menu de sélection des caisses</CENTER>", 0xFFFFFF), false, false);

			AddButton(10, 274, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0);
			AddHtml(45, 276, 450, 20, Color("Annuler", 0xFFFFFF), false, false);

			int current = 0;

			for (int i = 0; i < Entries.Length; ++i)
			{
				bool enabled = true;

				int page = current / 4 + 1;
				int pos = current % 4;

				if (pos == 0)
				{
					if (page > 1)
					{
						AddButton(400, 274, 0xFA5, 0xFA7, 0, GumpButtonType.Page, page);
						AddHtmlLocalized(440, 276, 60, 20, 1043353, 0x7FFF, false, false); // Next
					}

					AddPage(page);

					if (page > 1)
					{
						AddButton(300, 274, 0xFAE, 0xFB0, 0, GumpButtonType.Page, 1);
						AddHtmlLocalized(340, 276, 60, 20, 1011393, 0x7FFF, false, false); // Back
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
					AddHtml(x + 84, y + 20, 250, 60, Color(string.Format($"{Entries[i].Price} po"), 0xFFFFFF), false, false);

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
				return;

			PackageEntry entry = Entries[entryID];

			var boxes = m_Buyer.Backpack.FindItemsByType(entry.Type);

			if (boxes == null || boxes.Length <= 0)
			{
				m_Buyer.SendMessage($"Vous n'avez pas ce type de boite ({entry.Name}) dans votre sac.");
				return;
			}

			boxes[0].Delete();
			m_Buyer.SendMessage($"{entry.Price} pièces d'or ont été placées dans votre sac.");
			m_Buyer.PlaceInBackpack(new Gold(entry.Price));
		}
	}
}
