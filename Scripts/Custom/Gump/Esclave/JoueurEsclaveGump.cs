using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.HuePickers;
using Server.Prompts;
using Server.Targeting;


namespace Server.Gumps
{
    public class JoueurEsclaveGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private CustomPlayerMobile m_Esclave;

        public JoueurEsclaveGump(CustomPlayerMobile from, CustomPlayerMobile esclave)
            : base(esclave.Name, 560, 410, false)
        {

			m_From = from;
			m_Esclave = esclave;

			int x = XBase;
			int y = YBase;

			int i = 1;
			int line = 0;
			int colonne = 0;



			AddSection(x - 10, y, 320, 452, "Options");



			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 7, $"Changer le titre - {m_Esclave.customTitle}", "#FFFFFF");

	/*		if (m_From.IsStaff())
			{
				AddButtonHtlml(x + 5, y + 40 + line++ * 25, 3, "Accèder à la banque", "#FFFFFF");
			}
	*/
			


			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 2, "Affranchir (Pérégrin)", "#FFFFFF");
			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 1, "Désavouer (Déchet)", "#FFFFFF");


			AddSection(x + 311, y, 289, 452, "Talents");

			 line = 0;

			foreach (Skill item in m_Esclave.Skills)
			{
				if (item.Value > 0)
				{
					AddHtmlTexte(x + 325, y + 40 + line * 25, 150, item.Name);
					//	AddHtmlTexte(x + 525, y + 40 + line * 25, 150, m_From.Skills[item].Base.ToString("##0"));
					AddLabel(x + 550, y + 40 + line * 25, 150, item.Value.ToString());
					line++;
				}		
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			if (info.ButtonID == 0)
			{
				m_From.SendGump(new EsclaveListGump(m_From, 0));
			}
			if (info.ButtonID == 1)
			{
				m_From.RemoveEsclave(m_Esclave);
				m_From.SendGump(new EsclaveListGump(m_From, 0));
			}
			if (info.ButtonID == 2)
			{
				m_From.RemoveEsclave(m_Esclave, true);
				m_From.SendGump(new EsclaveListGump(m_From, 0));
			}
			if (info.ButtonID == 3)
			{
				//	m_From.Target = new BankerTarget(m_From,m_Esclave);

				BankBox bank = m_Esclave.BankBox;

				bank.DisplayTo(m_From);
				m_From.SendGump(new JoueurEsclaveGump(m_From, m_Esclave));

			}
			else if (info.ButtonID == 7)
			{
				m_From.Prompt = new AddTitlePrompt(m_From, m_Esclave);
				m_From.SendMessage("Veuillez écrire le nouveau titre.");
			}


		}
		private class AddTitlePrompt : Prompt
		{
			private CustomPlayerMobile m_From;
			private CustomPlayerMobile m_Esclave;

			public AddTitlePrompt(CustomPlayerMobile from, CustomPlayerMobile baseHire)
			{
				m_From = from;
				m_Esclave = baseHire;
			}

			public override void OnCancel(Mobile from)
			{
				m_From.SendGump(new JoueurEsclaveGump(m_From, m_Esclave));
			}

			public override void OnResponse(Mobile from, string text)
			{
				m_Esclave.customTitle = text;
				m_From.SendGump(new JoueurEsclaveGump(m_From, m_Esclave));
			}
		}

		private class BankerTarget : Target
		{
			private CustomPlayerMobile m_Maitre;
			private CustomPlayerMobile m_Esclave;

			public BankerTarget(CustomPlayerMobile Maitre, CustomPlayerMobile Esclave) : base(12, false, TargetFlags.None)
			{
				m_Maitre = Maitre;
				m_Esclave = Esclave;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is Banker banker)
				{
					if (banker.InRange(from.Location, 12))
					{
						BankBox bank = m_Esclave.BankBox;

						bank.DisplayTo(m_Maitre);
						m_Maitre.SendGump(new JoueurEsclaveGump(m_Maitre, m_Esclave));
					}
					else
					{
						m_Maitre.SendMessage("Vous devez être plus proche");
						m_Maitre.SendGump(new JoueurEsclaveGump(m_Maitre, m_Esclave));
					}
					

				}
				else
				{
					m_Maitre.SendMessage("Vous devez choisir un banquier.");
				}
			}
		}

	}
}
