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


namespace Server.Gumps
{
    public class NPCEsclaveGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private BaseHire m_Bh;

        public NPCEsclaveGump(CustomPlayerMobile from, BaseHire bh)
            : base(bh.Name, 560, 410, false)
        {

			m_From = from;
			m_Bh = bh;

			int x = XBase;
			int y = YBase;

			int i = 1;
			int line = 0;
			int colonne = 0;



			AddSection(x - 10, y, 320, 452, "Options");

			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 1, "Changer le profile","#FFFFFF");

			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 7, $"Changer le titre - {bh.customTitle}", "#FFFFFF");

			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 8, bh.Title == bh.customTitle ? "Cacher le titre" : "Afficher le titre", "#FFFFFF");

			AddButtonHtlml(x + 5, y + 40 + line * 25, 3, "Changer l'écriture", "#FFFFFF");
			AddLabel(x + 200, y + 40 + line++ * 25, bh.SpeechHue, "*******");

			AddButtonHtlml(x + 5, y + 40 + line * 25, 4, "Changer les actions", "#FFFFFF");
			AddLabel(x + 200, y + 40 + line++ * 25, bh.EmoteHue, "*******");


			AddButtonHtlml(x + 5, y + 40 + line * 25, 5, "Changer les murmures", "#FFFFFF");
			AddLabel(x + 200, y + 40 + line++ * 25, bh.WhisperHue, "*******");

			AddButtonHtlml(x + 5, y + 40 + line * 25, 6, "Changer les cries", "#FFFFFF");
			AddLabel(x + 200, y + 40 + line++ * 25, bh.YellHue, "*******");

			AddButtonHtlml(x + 5, y + 40 + line++ * 25, 2, "Relacher", "#FFFFFF");



			AddSection(x + 311, y, 289, 452, "Talents");

			 line = 0;

			foreach (Skill item in bh.Skills)
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
			else if (info.ButtonID == 1)
			{
				m_From.SendGump(new EsclavePaperdollGump(m_From, m_Bh, 0));
			}
			else if (info.ButtonID == 2)
			{
				m_Bh.AIObject.DoOrderRelease();
			}
			else if (info.ButtonID == 3)
			{
				m_From.SendHuePicker(new InternalPicker(m_From, m_Bh,1));
			}
			else if (info.ButtonID == 4)
			{
				m_From.SendHuePicker(new InternalPicker(m_From, m_Bh, 2));
			}
			else if (info.ButtonID == 5)
			{
				m_From.SendHuePicker(new InternalPicker(m_From, m_Bh, 3));
			}
			else if (info.ButtonID == 6)
			{
				m_From.SendHuePicker(new InternalPicker(m_From, m_Bh, 4));
			}
			else if (info.ButtonID == 7)
			{
				m_From.Prompt = new AddTitlePrompt(m_From, m_Bh);
				m_From.SendMessage("Veuillez écrire le nouveau titre.");
			}
			else if (info.ButtonID == 8)
			{

				if (m_Bh.Title == m_Bh.customTitle)
				{
					m_Bh.Title = "";
				}
				else
				{
					m_Bh.Title = m_Bh.customTitle;
				}
				
				m_From.SendGump(new NPCEsclaveGump(m_From, m_Bh));
			}

		}

		private class InternalPicker : HuePicker
		{
			//  private readonly DyeTub m_Tub;
			private CustomPlayerMobile m_From;
			private BaseHire m_Bh;
			private int m_Modification;
			public InternalPicker(CustomPlayerMobile from, BaseHire baseHire, int modif)
				: base(0)
			{
				m_From = from;
				m_Bh = baseHire;
				m_Modification = modif;
			}

			public override void OnResponse(int hue)
			{




				if (m_Modification == 1)				
					m_Bh.SpeechHue = hue;			
				else if (m_Modification == 2)
					m_Bh.EmoteHue = hue;
				else if (m_Modification == 3)
					m_Bh.WhisperHue = hue;
				else if (m_Modification == 4)
					m_Bh.YellHue = hue;



				m_From.SendGump(new NPCEsclaveGump(m_From, m_Bh));

				


				
			}
		}

		private class AddTitlePrompt : Prompt
		{
			private CustomPlayerMobile m_From;
			private BaseHire m_Bh;

			public AddTitlePrompt(CustomPlayerMobile from, BaseHire baseHire)
			{
				m_From = from;
				m_Bh = baseHire;
			}

			public override void OnCancel(Mobile from)
			{
				m_From.SendGump(new NPCEsclaveGump(m_From, m_Bh));
			}

			public override void OnResponse(Mobile from, string text)
			{
				m_Bh.customTitle = text;
				m_From.SendGump(new NPCEsclaveGump(m_From, m_Bh));
			}
		}

	}
}
