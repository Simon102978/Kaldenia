using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Custom;


namespace Server.Gumps
{
    public class LivreClasseGump : BaseProjectMGump
	{
		CustomPlayerMobile m_From;
		Classe m_Classe;
		LivreClasse m_Livre;

        public LivreClasseGump(CustomPlayerMobile from, Classe classe, LivreClasse livre)
            : base("Livres de classes", 250, 150, true)
        {


			m_From = from;
			m_Classe = classe;
			m_Livre = livre;


			int x = XBase + 20;
			int y = YBase + 10;

			int xSecondColum = x + 60;
			int xAmountColum = x + 400;
			int line = 0;
			int scale = 30;
			int space = 80;


			AddHtml(x, y, 250, 50, String.Concat($"<h3><basefont color=\"#FFFFFF\">Veuillez choisir ou vous désirez placer la classe {classe.Name }.</basefont></h3>"), false, false);
			line++;
			line++;

			if (from.ClassePrimaire != classe)
			{

			AddButtonHtlml(x, y + line * scale, 1, "Primaire", "#FFFFFF");
			line++;
			}

			if (from.ClasseSecondaire != classe)
			{
				AddButtonHtlml(x, y + line * scale, 2, "Secondaire", "#FFFFFF");
				line++;
			}

			if (classe.IsMetier() && from.Metier != classe)
			{
				AddButtonHtlml(x, y + line * scale, 3, "Métier", "#FFFFFF");
			}
			

			
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;


			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;

				if (info.ButtonID == 1)
				{
					cp.ClassePrimaire = m_Classe;
					m_Livre.Delete();
				}
				else if (info.ButtonID == 2)
				{
					cp.ClasseSecondaire = m_Classe;
					m_Livre.Delete();
				}
				else if (info.ButtonID == 3 && m_Classe.IsMetier())
				{
					cp.Metier = m_Classe;
					m_Livre.Delete();
				}
		
			}
        }
    }
}
