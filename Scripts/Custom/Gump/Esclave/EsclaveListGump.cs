using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Targeting;


namespace Server.Gumps
{
    public class EsclaveListGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;

        public EsclaveListGump(CustomPlayerMobile from, int page = 0)
            : base("Liste d'esclave", 260, 322, true)
        {

			m_From = from;
			m_Page = page;

			int x = XBase;
			int y = YBase;

			
			int line = 0;
			int colonne = 0;


			for (int i = page * 12; i < from.Esclaves.Count && line < 12; i++)
			{

				Mobile item = from.Esclaves[i];

				AddButtonHtlml(x + 10, y + 20 + line * 25, 100 + i, item.Name, "#ffffff");

				string Description = "";

				if (item is CustomPlayerMobile)
				{
					Description = "Joueur";
				}
				else
				{
					Description = "NPC";
				}

				AddHtmlTexteColored(x + 230, y + 20 + line * 25, 50, Description, "#ffffff");

				line++;
			}


			if (from.RoomForSlave())
			{
				AddButton(x + 115, y + 327, 3 , 2460,2461);
			}


			if (page != 0)
			{
				AddButton(x + 5, y + 310, 1, 4506);
			}
			if (from.Esclaves.Count > (page + 1) * 12)
			{
				AddButton(x + 235, y + 310, 2, 4502);
			}



		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {

			if (info.ButtonID == 1)
			{
				sender.Mobile.SendGump(new EsclaveListGump(m_From, m_Page - 1));
			}
			else if (info.ButtonID == 2)
			{
				sender.Mobile.SendGump(new EsclaveListGump(m_From, m_Page + 1));
			}
			else if (info.ButtonID == 3)
			{
				if (sender.Mobile is CustomPlayerMobile cp)
				{
					if (cp.RoomForSlave())
					{
						sender.Mobile.Target = new AddEsclave(cp);
					}
					sender.Mobile.SendGump(new EsclaveListGump(m_From, m_Page));
				}
				
			}
			else if (info.ButtonID >= 100)
			{
				Mobile esclave = m_From.Esclaves[info.ButtonID - 100];

				if (esclave is BaseHire es)
				{
					m_From.SendGump(new NPCEsclaveGump(m_From, es));
				}
				else if (esclave is CustomPlayerMobile cp)
				{
					m_From.SendGump(new JoueurEsclaveGump(m_From, cp));
				}
			}
		}


		private class AddEsclave : Target
		{
			private CustomPlayerMobile m_Master;

			public AddEsclave(CustomPlayerMobile master) : base(12, false, TargetFlags.None)
			{
				m_Master = master;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is CustomPlayerMobile cp)
				{
					if (cp.StatutSocial < StatutSocialEnum.Peregrin)
					{
						cp.SendGump(new EsclaveConfirmationGump(m_Master, cp));
					}
					else
					{
						from.SendMessage("Vous devez choisir un joueur qui à le statut d'esclave déchet.");

					}
				}			
				else
				{
					from.SendMessage("Vous devez choisir un joueur.");
				}
			}
		}

















	}
}
