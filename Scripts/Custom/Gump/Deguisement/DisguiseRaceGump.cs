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
    public class DegRaceGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		private Deguisement m_Deg;

		public DegRaceGump(CustomPlayerMobile from, Deguisement deg,    int page = 0)
            : base("Races", 200, 200, true)
        {

			m_From = from;
			m_Page = page;
			m_Deg = deg;

			int x = XBase;
			int y = YBase;

			int i = 0;
			int line = 0;
			int colonne = 0;

			foreach (Race item in Race.AllRaces)
			{
				if (i >= page * 8  )
				{

					AddButtonHtlml(x + 10, y + 20 + line * 20, item.Name, 200, 40, 100 + item.RaceID, "#ffffff");			
					line++;

					if ( i == (page + 1) * 7)
					{
						break;
					}
				}
				i++;
			}

			if (page != 0)
			{
				AddButton(x + 5, y + 188, 1, 4506);
			}
			if (Race.AllRaces.Count > (page + 1) * 6)
			{
				AddButton(x + 175, y + 188, 2, 4502);
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			     switch (info.ButtonID)
				 {
					case 0:
						{
							m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));
							break;
						 }
					case 1:
						 {
							m_From.SendGump(new DegRaceGump(m_From,m_Deg, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
						m_From.SendGump(new DegRaceGump(m_From, m_Deg, m_Page + 1));
							break;
						 }

				 }

			if (info.ButtonID >= 100)
			{
				m_Deg.Race = (BaseRace)Race.GetRace(info.ButtonID - 100);

				m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));

			}
		}
	}
}
