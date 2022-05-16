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
    public class DegPaperdollGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		private Deguisement m_Deg;

		public DegPaperdollGump(CustomPlayerMobile from, Deguisement deg, int page = 0)
            : base("Paperdoll", 200, 210, true)
        {

			m_From = from;
			m_Page = page;
			m_Deg = deg;

			int x = XBase;
			int y = YBase + 10;


			int line = 0;


			AddHtmlTexteColored(x + 10, y , 75, "Page " + (page + 1), "#ffffff");

			AddTextEntryBg(x + 10, y + 20, 210, 165, 0, 1, m_Deg.GetPaperdollEntry(page));
			

			

			if (page != 0)
			{
				AddButton(x + 5, y + 180, 1, 4506);
			}
			if (deg.Paperdoll.Count + 1 > page)
			{
				AddButton(x + 175, y + 180, 2, 4502);
			}

			AddButton(x + 80, y + 188, 3, 1147, 1148);

		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
				m_Deg.AddPaperdollEntry(info.GetTextEntry(1).Text, m_Page);



				 switch (info.ButtonID)
				 {
					case 0:
						 {
							m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));
							break;
						 }
					case 1:
						 {
							m_From.SendGump(new DegPaperdollGump(m_From,m_Deg, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
						m_From.SendGump(new DegPaperdollGump(m_From, m_Deg, m_Page + 1));
							break;
						 }
					case 3:
						{
							m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));
							break;
						}

			}

                               
		}
	}
}
