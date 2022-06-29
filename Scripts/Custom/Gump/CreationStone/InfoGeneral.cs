using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps
{
  public class InfoGenGump : CreationBaseGump
    {

        public InfoGenGump(CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Information Générale",true, creationPerso.InfoGeneral())
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 20;   
            int space = 115;

            AddSection(x - 10, y, 610, 125, "Information générales");

			AddHtmlTexteColored(x + 10, y + 55, 75, "Nom: ", "#ffffff");
			AddTextEntryBg(x + 73, y + 50, 500, 25, 0, 1, creationPerso.Name);

			AddButtonHtlml(x + 10, y + 85, 2, 2117, 2118, creationPerso.Female ? "Femme" : "Homme", "#ffffff");

			AddSection(x - 10, y + 126, 202, 483, "Apparence");

			int n = (int)creationPerso.Race.AppearanceMin;


			while (n <= (int)creationPerso.Race.AppearanceMax)
			{
				string color = "#ffffff";

				if (n == (int)creationPerso.Appearance)
				{
					color = "#ffcc00";
				}

				AppearanceEnum gros = (AppearanceEnum)n;

				var type = typeof(AppearanceEnum);
				MemberInfo[] memberInfo = type.GetMember(gros.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				string apparence =  (creationPerso.Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);

				AddButtonHtlml(x + 20, y + scale * line + 176, apparence, 200, 40, n + 100, color);
				n++;
				line++;
			}

			AddSection(x - 10 + 203, y + 126, 203, 483, "Grandeur");
			line = 0;

			n = (int)creationPerso.Race.GrandeurMin;

			while (n <= (int)creationPerso.Race.GrandeurMax)
			{
				string color = "#ffffff";

				if (n == (int)creationPerso.Grandeur)
				{
					color = "#ffcc00";
				}

				GrandeurEnum gros = (GrandeurEnum)n;

				var type = typeof(GrandeurEnum);
				MemberInfo[] memberInfo = type.GetMember(gros.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				string apparence = (creationPerso.Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);

				AddButtonHtlml(x + 223, y + scale * line + 176, apparence, 200, 40, n + 200, color);
				n++;
				line++;
			}

			AddSection(x - 10 + 407, y + 126, 203, 483, "Grosseur");

			line = 0;

			n = (int)creationPerso.Race.GrosseurMin;

			while (n <= (int)creationPerso.Race.GrosseurMax)
			{
				string color = "#ffffff";

				if (n == (int)creationPerso.Grosseur)
				{
					color = "#ffcc00";
				}

				GrosseurEnum gros = (GrosseurEnum)n;
				var type = typeof(GrosseurEnum);
				MemberInfo[] memberInfo = type.GetMember(gros.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				string apparence = (creationPerso.Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);

				AddButtonHtlml(x + 426, y + scale * line + 176, apparence, 200, 40, n + 300, color);
				n++;
				line++;
			}	
		}
		public override void OnResponse(NetState sender, RelayInfo info)
        {

          CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

          if (from.Deleted || !from.Alive)
            return;


		   m_Creation.Name = info.GetTextEntry(1).Text; 

			if (info.ButtonID == 2)
			{
				m_Creation.Female = !m_Creation.Female;
				from.SendGump(new InfoGenGump(from, m_Creation));
			}
            else if (info.ButtonID >= 100 && info.ButtonID < 200)
            {
				m_Creation.Appearance = (AppearanceEnum)(info.ButtonID - 100);
                from.SendGump(new InfoGenGump(from, m_Creation));
            }
			else if (info.ButtonID >= 200 && info.ButtonID < 300)
			{
				m_Creation.Grandeur = (GrandeurEnum)(info.ButtonID - 200);
				from.SendGump(new InfoGenGump(from, m_Creation));
			}
			else if (info.ButtonID >= 300 && info.ButtonID < 400)
			{
				m_Creation.Grosseur = (GrosseurEnum)(info.ButtonID - 300);
				from.SendGump(new InfoGenGump(from, m_Creation));
			}

			else if (info.ButtonID == 1001)
            {
                from.SendGump(new ClasseGump(m_from, m_Creation));
            }
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
                from.SendGump(new CreationRaceGump(m_from, m_Creation));
            }
        }
    }
}
