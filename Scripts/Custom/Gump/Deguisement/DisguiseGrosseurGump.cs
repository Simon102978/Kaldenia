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
    public class DegGrosseurGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		private Deguisement m_Deg;

		public DegGrosseurGump(CustomPlayerMobile from, Deguisement deg,    int page = 0)
            : base("Grosseur", 200, 200, true)
        {

			m_From = from;
			m_Page = page;
			m_Deg = deg;

			int x = XBase;
			int y = YBase;

			int line = 0;

			if (m_Deg.Race != null)
			{
				int n = (int)m_Deg.Race.GrandeurMin;

				if (n < page * 9)
				{
					n = page * 9 + 1;
				}

				while (n <= (int)m_Deg.Race.GrosseurMax)
				{				
						GrosseurEnum gros = (GrosseurEnum)n;

						var type = typeof(GrosseurEnum);
						MemberInfo[] memberInfo = type.GetMember(gros.ToString());
						Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
						string apparence = (m_Deg.Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);

						AddButtonHtlml(x + 10, y + 20 + line * 20, apparence, 200, 40, n + 100, "#ffffff");

						n++;
						line++;

						if (line ==  9)
						{
								break;
						}
				}

				if (page != 0)
				{
					AddButton(x + 5, y + 188, 1, 4506);
				}
				if (((int)m_Deg.Race.GrosseurMax - (int)m_Deg.Race.GrosseurMin) > (page + 1) * 9)
				{
					AddButton(x + 175, y + 188, 2, 4502);
				}
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
							m_From.SendGump(new DegGrosseurGump(m_From,m_Deg, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
						m_From.SendGump(new DegGrosseurGump(m_From, m_Deg, m_Page + 1));
							break;
						 }

				 }

			if (info.ButtonID >= 100)
			{
				m_Deg.Grosseur = (GrosseurEnum)(info.ButtonID - 100);
				m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));
			}
		}
	}
}
