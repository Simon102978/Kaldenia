using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;


namespace Server.Gumps
{
    public class StatutGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;

        public StatutGump(CustomPlayerMobile from, int page = 0)
            : base("Mobiles", 260, 322, true)
        {

			m_From = from;
			m_Page = page;

			int x = XBase;
			int y = YBase;

			int i = 0;

			int line = 0;
			int colonne = 0;
			int scale = 25;


			foreach (NetState state in NetState.Instances)
			{
				Mobile item = state.Mobile;

				if (i >= page * 12 && i <= (page + 1 ) * 12)
				{
					if (item is CustomPlayerMobile cp)
					{
						AddHtmlTexteColored(x + 10, y + 20 + line * 25, 250, cp.Name, "#ffffff");
						AddHtmlTexteColored(x + 175, y + 20 + line * 25, 100, cp.StatutSocial.ToString(), "#ffffff");
						line++;
					}
					i++;
				}
			}

			if (page != 0)
			{
				AddButton(x + 5, y + 310, 1, 4506);
			}

			AddButton(x + 235, y + 310, 2, 4502);




		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			     switch (info.ButtonID)
				 {
					 case 1:
						 {
							sender.Mobile.SendGump(new StatutGump(m_From, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
							sender.Mobile.SendGump(new StatutGump(m_From, m_Page + 1));
							break;
						 }

				 }
		}
	}
}
