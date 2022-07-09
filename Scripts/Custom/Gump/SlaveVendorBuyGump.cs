using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Accounting;
using System.Linq;
using Server.Spells;


namespace Server.Gumps
{
    public class SlaveVendorBuyGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		private SlaveVendor m_Vendor;

		public SlaveVendorBuyGump(CustomPlayerMobile from,  SlaveVendor vendor, int page = 0)
            : base("Vendeur d'esclave", 560, 622, false)
        {

			m_From = from;
			m_Page = page;

			int x = XBase;
			int y = YBase;

	
			
			int esclave = 0;
			m_Vendor = vendor;


			//			AddBackground(_x, _y, m_Largeur + 80, m_Hauteur + 80, 9260);

			for (int i = page * 4 ; i < vendor.Inventory.Count && esclave < 4; i++)
			{
				int line = 0;
				int yloc = y + 151 * esclave + 50;
				SlaveEntry entry = vendor.Inventory[i];
				AddSection(x, yloc - 50, 590, 150, entry.Name);
				AddHtmlTexteColored(x + 15, yloc + line++ * 25, 200, $"Race: {entry.Race.Name}", "#FFFFFF");
				AddHtmlTexteColored(x + 15, yloc + line++ * 25, 200, $"Sexe: {(entry.Female ? "Femme" : "Homme")}", "#FFFFFF");
				AddHtmlTexteColored(x + 15, yloc + line++ * 25, 200, $"Type: {entry.TypeEsclave}", "#FFFFFF");


				line = 0;
				AddHtmlTexteColored(x + 205, yloc + line++ * 25, 200, $"Apparence: {entry.GetApparence()}", "#FFFFFF");
				AddHtmlTexteColored(x + 205, yloc + line++ * 25, 200, $"Grandeur: {entry.GetGrandeur()}", "#FFFFFF");
				AddHtmlTexteColored(x + 205, yloc + line++ * 25, 200, $"Grosseur: {entry.GetGrosseur()}", "#FFFFFF");

				line = 0;

				AddHtmlTexteColored(x + 465, yloc + line++ * 25, 200, $"Prix: {entry.Price}", "#FFFFFF");

				AddButtonHtlml(x + 465, yloc + line++ * 25, 1000 + i, "Acheter", "#FFFFFF");
			//	AddButtonHtlml(x + 465, yloc + line++ * 25, 2000 + i, "Visualisation", "#FFFFFF");


				esclave++;
			}

			if (esclave < 4)
			{
				for (int i = esclave; i < 4; i++)
				{
					

					

					AddBackground(x, y + 151 * i, 590, 150, 9270);

					


				}

			}


			AddBackground(x, y + 604, 590, 60, 9270);



			if (page != 0)
			{
				AddButton(x + 5, y + 610, 1, 4506);
			}
			if (vendor.Inventory.Count > (page + 1) * 4)
			{
				AddButton(x + 535, y + 610, 2, 4502);
			}



		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {

			if (info.ButtonID == 1 )			
				sender.Mobile.SendGump(new SlaveVendorBuyGump(m_From, m_Vendor, m_Page - 1));			
			else if (info.ButtonID == 2 )
				sender.Mobile.SendGump(new SlaveVendorBuyGump(m_From, m_Vendor, m_Page + 1));
			else if (info.ButtonID >= 1000 && info.ButtonID < 2000)
			{
				if (!BaseVendor.ConsumeGold(m_From.Backpack, m_Vendor.Inventory[info.ButtonID - 1000].Price))
				{
					m_From.SendMessage("Vous n'avez pas l'or nécessaire pour acheter cette esclave.");
				}
				else
				{

					BaseHire esclave = m_Vendor.Inventory[info.ButtonID - 1000].GenerateSlave();

					Point3D p = new Point3D(m_Vendor.Location);

					if (SpellHelper.FindValidSpawnLocation(m_Vendor.Map, ref p, true))
					{
						esclave.MoveToWorld(p, m_Vendor.Map);

						if (m_From.Followers + 2 > m_From.FollowersMax)
						{
							m_Vendor.SayTo(m_From, "Vous avez trop de familiers pour l'instant.", 0x3B2); // I see you already have an escort.
							m_From.AddToBackpack(new Gold(m_Vendor.Inventory[info.ButtonID - 1000].Price));
							esclave.Delete();

						}
						else if (esclave.AddHire(m_From))
						{
							m_Vendor.RemoveSlave(info.ButtonID - 1000);

							esclave.Say("Je vous suis maitre.");
						}
						else
						{
							m_From.AddToBackpack(new Gold(m_Vendor.Inventory[info.ButtonID - 1000].Price));
							esclave.Delete();
						}
					}
				}		
			}
		}
	}
}
