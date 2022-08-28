using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using System.Reflection;


namespace Server.Gumps
{
    public class EsclavePaperdollGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private Dictionary<int, string> m_Paperdoll;
		private int m_Page;
		private BaseHire m_Bh;

		public EsclavePaperdollGump(CustomPlayerMobile from, BaseHire bh, int page = 0)
			: this(from,bh, new Dictionary<int, string>(),page)
		{

		}


		public EsclavePaperdollGump(CustomPlayerMobile from, BaseHire bh,Dictionary<int, string> Paperdoll, int page = 0)
            : base("Paperdoll", 200, 210, true)
        {

			m_From = from;
			m_Page = page;
			m_Bh = bh;
			m_Paperdoll = Paperdoll;

			int x = XBase;
			int y = YBase + 10;


			int line = 0;

			if (m_Paperdoll.Count == 0)
			{
				int i = 0;

				if (bh.Profile == null)
				{
					m_Paperdoll.Add(0, "");
				}
				else
				{
					foreach (string item in bh.Profile.Split('\n'))
					{

						m_Paperdoll.Add(i, item);

						i++;
					}
				}

				

			}
			else
			{
				m_Paperdoll = Paperdoll;
			}


			

			AddHtmlTexteColored(x + 10, y , 75, "Page " + (page + 1), "#ffffff");

			AddTextEntryBg(x + 10, y + 20, 210, 165, 0, 1, GetPaperdoll(page));
			

			

			if (page != 0)
			{
				AddButton(x + 5, y + 180, 1, 4506);
			}
			if (m_Paperdoll.Count + 1 > page)
			{
				AddButton(x + 175, y + 180, 2, 4502);
			}

			AddButton(x + 80, y + 188, 3, 1147, 1148);

		}

		public string GetPaperdoll(int page)
		{
			if (m_Paperdoll.ContainsKey(page))
			{
				return m_Paperdoll[page].Replace('\n', ' ');
			}
			else
			{
				return "";
			}

		}

		public void AddPaperdollEntry(string entry)
		{
			if (m_Paperdoll.ContainsKey(m_Page))
			{
				m_Paperdoll[m_Page] = entry;
			}
			else
			{
				m_Paperdoll.Add(m_Page, entry);
			}

		}


		public override void OnResponse(NetState sender, RelayInfo info)
        {
			    AddPaperdollEntry(info.GetTextEntry(1).Text + "\n");



				 switch (info.ButtonID)
				 {
					case 0:
						 {
							m_From.SendGump(new NPCEsclaveGump(m_From,m_Bh));
							break;
						 }
					case 1:
						 {
							m_From.SendGump(new EsclavePaperdollGump(m_From,m_Bh,m_Paperdoll, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
						m_From.SendGump(new EsclavePaperdollGump(m_From, m_Bh, m_Paperdoll, m_Page + 1));
							break;
						 }
					case 3:
						{
						string profile = "";

						foreach (KeyValuePair<int, string> item in m_Paperdoll)
						{
							profile = profile + item.Value;
						}

							m_Bh.Profile = profile;

							m_From.SendGump(new NPCEsclaveGump(m_From, m_Bh));
							break;
						}

			}

                               
		}
	}
}
