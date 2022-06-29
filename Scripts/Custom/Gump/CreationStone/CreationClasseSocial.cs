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
  public class CreationClasseSocial : CreationBaseGump
    {

        public CreationClasseSocial(CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Classe Sociale",true, true)
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 20;   
            int space = 115;

            AddSection(x - 10, y, 610, 150, "Choix");

			//	AddHtmlTexte(x + 100, y + 100, 100, "Forces");





			AddButtonHtlml(x + 200, y + 43, 1,  2117, 2118, "P??#$?&*r??#$?&*grins", creationPerso.Statut == StatutSocialEnum.Peregrin ? "#ffcc00" : "#ffffff");
			AddButtonHtlml(x + 200, y + 68, 2, 2117, 2118, "Esclave - D??#$?&*chet", creationPerso.Statut == StatutSocialEnum.Dechet ? "#ffcc00" : "#ffffff");




			string detail = "";

			switch (creationPerso.Statut)
			{
				case StatutSocialEnum.Aucun:
					break;
				case StatutSocialEnum.Dechet:
					detail = "Les esclaves de Kaldenia n’ont aucune autorit??#$?&* et aucun droit sur quiconque dans le royaume. Consid??#$?&*r??#$?&*s comme la chair à canon, leur pr??#$?&*sence dans Alverton ne sert qu’à assouvir les moindres d??#$?&*sirs des maîtres. Ils n’ont aucune valeur, mais il est possible, à force d’acharnement, de devenir un P??#$?&*r??#$?&*grin. \n\n<color><u>Ils peuvent et doivent servir absolument n’importe qui.</u> Si personne ne veut s’en occuper, ni même user de leurs services, ils vont errer ici et là jusqu’à la mort. </basefont></h3><h3><basefont color=#ff0000> \n\n-Lorsqu'un d??#$?&*chet meurt, sa mort est permanente\n-Les d??#$?&*chets ne peuvent pas acheter au npc\n-Les d??#$?&*chets ne peuvent pas vendre au npc\n-Les d??#$?&*chets n'ont pas accès à la banque</basefont></h3>\n";
					break;
				case StatutSocialEnum.Possession:
					break;
				case StatutSocialEnum.Peregrin:
					detail = "Tout droit sortis des affres de l’esclavage, les P??#$?&*r??#$?&*grins restent limit??#$?&*s dans leurs nouveaux privilèges. Ils devront faire preuve de d??#$?&*votion et de patriotisme exemplaire afin de s’??#$?&*lever au titre de Civ??#$?&*nien; L’??#$?&*tape la plus importante pour être consid??#$?&*r??#$?&* comme une personne à part entière dans la soci??#$?&*t??#$?&*. \n\nMalheureusement, ils vivent encore dans la crainte puisque l’??#$?&*tat ne leur procure aucune protection dans les rues. Certains les considèrent comme des gens venus de l’ext??#$?&*rieur pour voler leurs maisons et leurs positions. Il n’est pas rare de voir des P??#$?&*r??#$?&*grins se faire tuer par des Civ??#$?&*niens, ceux-ci profitant du fait qu’ils n’auront aucune repr??#$?&*saille. ";
					break;
				case StatutSocialEnum.Civenien:
					break;
				case StatutSocialEnum.Equite:
					break;
				case StatutSocialEnum.Patre:
					break;
				case StatutSocialEnum.Magistrat:
					break;
				case StatutSocialEnum.Empereur:
					break;
				default:
					break;
			}



			AddSection(x - 10, y + 151, 610, 458, "D??#$?&*tail", detail);





		}
		public override void OnResponse(NetState sender, RelayInfo info)
        {

          CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

          if (from.Deleted || !from.Alive)
            return;

			if (info.ButtonID == 1)
			{
				m_Creation.Statut = StatutSocialEnum.Peregrin;
				m_from.SendGump(new CreationClasseSocial(from, m_Creation));
			}
			else if (info.ButtonID == 2)
			{
				m_Creation.Statut = StatutSocialEnum.Dechet;
				m_from.SendGump(new CreationClasseSocial(from, m_Creation));
			}		
			else if (info.ButtonID == 1001)
            {
				from.SendGump(new CreationGodGump(m_from, m_Creation));
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
				from.SendGump(new CreationStatistique(m_from, m_Creation));
			}
        }
    }
}
