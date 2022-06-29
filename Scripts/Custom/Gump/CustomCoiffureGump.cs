using System;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Misc;


namespace Server.Gumps
{


	public class CustomCoiffureConfirmationGump : Gump
	{
		CustomPlayerMobile m_from;
		Coiffure m_coif;



		public CustomCoiffureConfirmationGump(CustomPlayerMobile from,  Coiffure coiffure)
		   : base(25, 25)
		{
			m_from = from;
			m_coif = coiffure;


		int movex = 150;
		int movey = 150;
		AddBackground(36+movex, 25+movey, 369, 170, 9270);
		AddBackground(54+movex, 43+movey, 334, 28, 3000);
			 
			AddLabel(77+movex, 47+movey, 0, "Cela vous coutera " + coiffure.Price + " pi%%%#$%?%$#@!ces d'or.");
			AddItem(195+movex,80+movey, coiffure.ItemId);
			//AddLabel(250+movex, 90+movey, 2101, coifrelate[i]);
			AddLabel(135+movex, 137+movey, 2101, "Non");
			AddLabel(245+movex, 137+movey, 2101, "Oui");
			AddButton(160+movex,137+movey, 4014, 4016, 0, GumpButtonType.Reply, 0);
			AddButton(270+movex,137+movey, 4014, 4016, 1, GumpButtonType.Reply, 0);
		}



		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 0)
			{
			
			}
			else
			{

				if (!BaseVendor.ConsumeGold(m_from.Backpack,m_coif.Price))
				{
					m_from.SendMessage("Vous n'avez pas l'or nécessaire pour acheter cette coupe");
				}
				else
				{

					m_from.PlaySound(0x32);

					if (m_coif.Barbe)
					{
						m_from.FacialHairItemID = m_coif.ItemId;
					}
					else
					{
						m_from.HairItemID = m_coif.ItemId;
					}

					m_from.PlaySound(0x248);
				}




			
			

				
			}
		}
	}


	public class CustomCoiffureGump : BaseProjectMGump
    {
    
        public CustomPlayerMobile m_From;
        public int m_Page;
		public bool m_Barbe = false;

        public CustomCoiffureGump(CustomPlayerMobile from, int page, bool barbe = false)
            : base(!barbe ? "Choix de cheveux" : "Choix de Barbe", 560, 622, false)
        {
            m_From = from;
			m_Page = page;
			m_Barbe = barbe;


			int x = XBase - 2;
			int y = YBase;
			int line = 0;
			int scale = 25;


			Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

			int n = 0;
			int column = 0;
			
			while (n < Coiffure.coiffure.Count)
			{
				Coiffure co = Coiffure.coiffure[n];

				bool skip = false;

				if (!co.Sellable)
				{

				}
				else if (co.Barbe && m_Barbe)
				{
					skip = true;
				}
				else if (!co.Barbe && !m_Barbe)
				{
					skip = true;
				}

				if (skip)
				{
					AddBackground(x + column * 86, y + line * 86, 85, 85, 9270);

					AddItem(x + 25 + column * 86, y + 25 + line * 86, Coiffure.coiffure[n].ItemId);
					AddButton(x + 30 + column * 86, y + 60 + line * 86, Coiffure.coiffure[n].Id + 1000, 2117, 2118);

					column++;

					if (column == 7)
					{
						column = 0;
						line++;
					}
				}			
				n++;
			}


			while (column != 7 && line != 7)
			{
				AddBackground(x + column * 86, y + line * 86, 85, 85, 9270);

				column++;

				if (column == 7)
				{
					column = 0;
					line++;
				}
			}


			AddBackground(x, y + 602 , 602, 60, 9270);


			if (from.Race.Barbe && (!from.Female || from.Race.FemmeBarbe))
			{
				AddButtonHtlml(x + 275, y + 623, 2, barbe ? "<h3><basefont color=#ffffff>Cheveux</basefont></h3>" : "<h3><basefont color=#ffffff>Barbes</basefont></h3>");

			}


		}
			
        public override void OnResponse(NetState sender, RelayInfo info)
        {		
            int buttonID = info.ButtonID;

		

			if (buttonID == 2)
			{
				m_From.SendGump(new CustomCoiffureGump(m_From, 0, !m_Barbe));
			}
			else if(buttonID >= 1000)
			{
				Coiffure co = Coiffure.coiffure[buttonID - 1000];



				m_From.SendGump(new CustomCoiffureConfirmationGump(m_From, co));
					


				


			}

						
	
        }		
	}	
}
