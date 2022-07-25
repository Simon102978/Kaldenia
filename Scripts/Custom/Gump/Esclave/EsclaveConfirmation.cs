using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Targeting;


namespace Server.Gumps
{
	public class EsclaveConfirmationGump : BaseProjectMGump
	{
		CustomPlayerMobile m_Master;
		CustomPlayerMobile m_Esclave;


		public EsclaveConfirmationGump(CustomPlayerMobile master, CustomPlayerMobile esclave)
		   : base("Contrat d'esclavage",400, 325, false)
		{
			m_Master = master;
			m_Esclave = esclave;

			int x = XBase + 15;
			int y = YBase + 35;


			int line = 0;


			AddSection(x - 15, y - 35, 430, 100, "Information");

			AddHtml(x, y, 375, 50,$"<h3><basefont color=#ffffff>{master.Name} vous offre de devenir son esclave, cela entrainera les cons�quences suivantes : </basefont></h3>", false, false);




			string detail = $"Avantages:\n\n-Vous allez avoir acc�s � un banque\n-Vous allez avoir acc�s au m�me vendeur qu'un p�r�grin\n-Vous serez tax� au m�me niveau qu'un p�r�grin \n\n D�savantages:\n\n-Vous devrez ob�ir � {master.Name}\n-{master.Name} peut vous remettre d�ch�t sans pr�avis\n-{master.Name} connaitra vos talents";


			AddSection(x - 15 , y + 66, 430, 200, "Cons�quences", detail);

			AddBackground(x - 15, y + 267, 430, 60, 9270);   

			AddButton(x + 100, y + 278, 1, 1147);
			AddButton(x + 240, y + 278, 0, 1144);

			/*		AddLabel(135 + x, 137 + y, 2101, "Non");
					AddLabel(245 + x, 137 + y, 2101, "Oui");
					AddButton(160 + x, 137 + y, 4014, 4016, 0, GumpButtonType.Reply, 0);
					AddButton(270 + x, 137 + y, 4014, 4016, 1, GumpButtonType.Reply, 0);*/
		}



		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 0)
			{
				m_Master.SendMessage($"{m_Esclave.Name} refuse votre offre.");
			}
			else
			{
				m_Master.SendMessage($"{m_Esclave.Name} accepte votre offre.");
				m_Esclave.SendMessage($"Vous �tes maintenant l'esclave de {m_Master.Name}.");

				m_Master.AddEsclave(m_Esclave);
			}
		}
	}
}
