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


			AddHtmlTexteColored(x, y + line * scale, 120, "Revenues :", "#FFFFFF");
			line++;

			AddHtmlTexteColored(xSecondColum, y + line * scale, 120, "Taxes", "#FFFFFF");
			int TaxesGold = CustomPersistence.TaxesMoney;
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + TaxesGold.ToString("### ### ##0") + "</p>", "#FFFFFF");
			line++;

			AddHorizontalLigne(xAmountColum - 20, y + line * scale + 15, 120);
			line++;

			int Revenue = TaxesGold;
			AddHtmlTexteColored(xSecondColum, y + line * scale, 200, "Total des revenues :", "#FFFFFF");
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + Revenue.ToString("### ### ##0") + "</p>", "#FFFFFF");

			line++;
			line++;

			AddHtmlTexteColored(x, y + line * scale, 120, "D??#$?&*penses :", "#FFFFFF");
			line++;


			AddHtmlTexteColored(xSecondColum, y + line * scale, 120, "Salaire", "#FFFFFF");
			int SalaireGold = CustomPersistence.Salaire;
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + SalaireGold.ToString("### ### ##0") + "</p>", "#FFFFFF");
			line++;

			AddHorizontalLigne(xAmountColum - 20, y + line * scale + 15, 120);
			int Depenses = SalaireGold;
			AddHtmlTexteColored(xSecondColum, y + line * scale, 200, "Total des d??#$?&*penses :", "#FFFFFF");
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + Depenses.ToString("### ### ##0") + "</p>", "#FFFFFF");

			line++;
			line++;



			int Benefice = Revenue - Depenses;
			AddHtmlTexteColored(x, y + line * scale, 300, "B??#$?&*n??#$?&*fice :", "#FFFFFF");
			AddHtmlTexteColored(xAmountColum, y + line * scale, 120, "<p style = \"text-align:right> " + Benefice.ToString("### ### ##0") + "</p>", "#FFFFFF");
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;


			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;


		
			}
        }
    }
}
