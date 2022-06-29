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
  public class CreationStatistique : CreationBaseGump
    {

        public CreationStatistique (CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Statistique",true, creationPerso.Statistique())
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 20;   
            int space = 115;

            AddSection(x - 10, y, 610, 150, "Sélection");

			//	AddHtmlTexte(x + 100, y + 100, 100, "Forces");

			AddLabel(x + 200, y + 43, 2101, "Force");
			AddLabel(x + 279, y + 44, 2101, ":");
			AddLabel(x + 308, y + 43, 2101, creationPerso.Str.ToString() );
			AddButton(x + 348, y + 45, 5603, 5607, 138, GumpButtonType.Reply, 0);
			AddButton(x + 369, y + 45, 5601, 5605, 139, GumpButtonType.Reply, 0);

			AddLabel(x + 200, y + 68, 2101, "Dextérité");
			AddLabel(x + 279, y + 69, 2101, ":");
			AddLabel(x + 308, y + 68, 2101, creationPerso.Dex.ToString());
			AddButton(x + 348, y + 70, 5603, 5607, 140, GumpButtonType.Reply, 0);
			AddButton(x + 369, y + 70, 5601, 5605, 141, GumpButtonType.Reply, 0);

			AddLabel(x + 200, y + 93, 2101, "Intelligence");
			AddLabel(x + 279, y + 94, 2101, ":");
			AddLabel(x + 308, y + 93, 2101, creationPerso.Int.ToString());
			AddButton(x + 348, y + 95, 5603, 5607, 142, GumpButtonType.Reply, 0);
			AddButton(x + 369, y + 95, 5601, 5605, 143, GumpButtonType.Reply, 0);

			AddLabel(x + 200, y + 118, 2101, "Points restant");
			AddLabel(x + 279, y + 119, 2101, ":");
			AddLabel(x + 308, y + 118, 2101, creationPerso.PointRestant().ToString());


			string detail = "Force: \n  -Détermine les points de vie\n  -Détermine la quantité que peux porter un personnage\n  -Détermine les dégats au corps %%%#$%?%$#@! corps\n  -Détermine si vous pouvez porter une armure \n\nDextérité:\n  -Aide au chance de parrer un coup\n  -Détermine le temps entre chaque bandage\n  -Détermine l'endurance\n\nIntelligence:\n  -Détermine la mana\n  -Influence la regénération de mana\n";




			AddSection(x - 10, y + 151, 610, 458, "Détail", detail);





		}
		public override void OnResponse(NetState sender, RelayInfo info)
        {

          CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

          if (from.Deleted || !from.Alive)
            return;


			if (info.ButtonID == 138)
			{
				m_Creation.Str -= 5;

				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 139)
			{
				m_Creation.Str += 5;

				from.SendGump(new CreationStatistique(from, m_Creation));
			}

			else if (info.ButtonID == 140)
			{
				m_Creation.Dex -= 5;

				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 141)
			{
				m_Creation.Dex += 5;

				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 142)
			{
				m_Creation.Int -= 5;

				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 143)
			{
				m_Creation.Int += 5;

				from.SendGump(new CreationStatistique(from, m_Creation));
			}

			else if (info.ButtonID == 1001)
            {
				from.SendGump(new CreationClasseSocial(m_from, m_Creation));
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
				from.SendGump(new ClasseGump(m_from, m_Creation, 2));
			}
        }
    }
}
