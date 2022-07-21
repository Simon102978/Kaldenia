using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Custom;
using Server.Prompts;


namespace Server.Gumps
{
    public class FinanceGump : BaseProjectMGump
	{
   

        public FinanceGump(CustomPlayerMobile from)
            : base("Finance D'Alverton", 500, 500, true)
        {

			int x = XBase + 20;
			int y = YBase + 30;

			int xSecondColum = x + 60;
			int xAmountColum = x + 400;
			int line = 0;
			int scale = 30;
			int space = 80;


			AddHtmlTexteColored(x, y + line * scale, 120, "Revenues:", "#FFFFFF");
			line++;

			AddHtmlTexteColored(xSecondColum, y + line * scale, 120, "Taxes:", "#FFFFFF");
			int TaxesGold = CustomPersistence.TaxesMoney;
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + TaxesGold.ToString("### ### ##0") + "</p>", "#FFFFFF");
			line++;

			AddHtmlTexteColored(xSecondColum, y + line * scale, 120, "Locations:", "#FFFFFF");
			int LocationTaxes = CustomPersistence.Location;
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + LocationTaxes.ToString("### ### ##0") + "</p>", "#FFFFFF");
			line++;

			AddHtmlTexteColored(xSecondColum, y + line * scale, 120, "Esclave:", "#FFFFFF");
			int SlaveSell = CustomPersistence.SlaveSell;
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + SlaveSell.ToString("### ### ##0") + "</p>", "#FFFFFF");

			AddHorizontalLigne(xAmountColum - 20, y + line * scale + 15, 120);
			line++;

			int Revenue = TaxesGold + LocationTaxes + SlaveSell;
			AddHtmlTexteColored(xSecondColum, y + line * scale, 200, "Total des revenues :", "#FFFFFF");
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + Revenue.ToString("### ### ##0") + "</p>", "#FFFFFF");

			line++;
			line++;

			AddHtmlTexteColored(x, y + line * scale, 120, "Dépenses :", "#FFFFFF");

			line++;

			if (from.AccessLevel == AccessLevel.Owner)
			{
				AddButton(xSecondColum - 20, y + line * scale, 1, 2117);
			}		
			AddHtmlTexteColored(xSecondColum, y + line * scale, 300, $"Salaire - {CustomPersistence.ProchainePay.ToLongDateString()} - {CustomPersistence.ProchainePay.ToShortTimeString()}", "#FFFFFF");
			int SalaireGold = CustomPersistence.Salaire;
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + SalaireGold.ToString("### ### ##0") + "</p>", "#FFFFFF");
			line++;

			AddHorizontalLigne(xAmountColum - 20, y + line * scale + 15, 120);
			int Depenses = SalaireGold;
			AddHtmlTexteColored(xSecondColum, y + line * scale, 200, "Total des dépenses :", "#FFFFFF");
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + Depenses.ToString("### ### ##0") + "</p>", "#FFFFFF");

			line++;
			line++;



			int Benefice = Revenue - Depenses;
			AddHtmlTexteColored(x, y + line * scale, 300, "Bénéfice :", "#FFFFFF");
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + Benefice.ToString("### ### ##0") + "</p>", "#FFFFFF");
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;


			if (from is CustomPlayerMobile cp)
			{
				

				if (info.ButtonID == 1)
				{

					cp.Prompt = new AjustSalairePrompt(cp);
					cp.SendMessage("Veuillez écrire le nouveau montant.");
				}



			}
        }

		private class AjustSalairePrompt : Prompt
		{
			private CustomPlayerMobile m_From;


			public AjustSalairePrompt(CustomPlayerMobile from)
			{
				m_From = from;

			}

			public override void OnCancel(Mobile from)
			{
				m_From.SendGump(new FinanceGump(m_From));
			}

			public override void OnResponse(Mobile from, string text)
			{
				int Salaire = 0;

				int.TryParse(text, out Salaire);

				if (Salaire != 0)
				{
					CustomPersistence.Salaire = Salaire;

				}

				m_From.SendGump(new FinanceGump(m_From));
			}
		}





	}
}
