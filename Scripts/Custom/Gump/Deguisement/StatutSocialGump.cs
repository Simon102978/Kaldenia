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
    public class DegStatutSocialGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		private Deguisement m_Deg;

		public DegStatutSocialGump(CustomPlayerMobile from, Deguisement deg,    int page = 0)
            : base("Statut Social", 200, 200, true)
        {

			m_From = from;
			m_Page = page;
			m_Deg = deg;

			int x = XBase;
			int y = YBase;

			int line = 0;

			
				int n = 0;

				if (n < page * 9)
				{
					n = page * 9 + 1;
				}

				while (n <= Enum.GetNames(typeof(StatutSocialEnum)).Length)
				{
						StatutSocialEnum gros = (StatutSocialEnum)n;

						var type = typeof(StatutSocialEnum);
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
				if ((int)Enum.GetNames(typeof(StatutSocialEnum)).Length  > (page + 1) * 9)
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
							m_From.SendGump(new DegStatutSocialGump(m_From,m_Deg, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
						m_From.SendGump(new DegStatutSocialGump(m_From, m_Deg, m_Page + 1));
							break;
						 }

				 }

			if (info.ButtonID >= 100)
			{
				m_Deg.StatutSocial = (StatutSocialEnum)(info.ButtonID - 100);
				m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));
			}
		}
	}
}
