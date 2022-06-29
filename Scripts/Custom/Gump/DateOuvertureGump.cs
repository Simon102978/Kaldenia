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
    public class DateOuvertureGump : BaseProjectMGump
	{
   

        public DateOuvertureGump(CustomPlayerMobile from)
            : base("Date Ouverture", 250, 200, true)
        {

			int x = XBase;
			int y = YBase;


			DateTime date = CustomPersistence.Ouverture;

			AddHtmlTexte(x +10, y + 20, 250, 60, "Determine la date d'ouverture du serveur pour le système d'expérience.");

			AddHtmlTexte(x + 10, y + 65, 150, "Jour");
			AddTextEntryBg(x + 100, y + 60, 150, 30, 0, 1, date.Day.ToString());

			AddHtmlTexte(x + 10, y + 105, 150, "Mois");
			AddTextEntryBg(x + 100, y + 100, 150, 30, 0, 2, date.Month.ToString());

			AddHtmlTexte(x + 10, y + 145, 150, "Année");
			AddTextEntryBg(x + 100, y + 140, 150, 30, 0, 3, date.Year.ToString());

			AddButton(x + 35, y + 180, 1, 1147);
			AddButton(x + 175, y + 180, 0, 1144);

		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;


			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;


				switch (info.ButtonID)
				{
					case 1:
						{
							int day = 1;


							if (!int.TryParse(info.GetTextEntry(1).Text, out day))
							{
								from.SendMessage("Le jours doit être un nombre de 0 %%%#$%?%$#@! 31.");
								from.SendGump(new DateOuvertureGump(cp));
								break;
							}
							else if (day < 1 || day > 31)
							{
								from.SendMessage("La cote doit être un nombre de 1 %%%#$%?%$#@! 31.");
								from.SendGump(new DateOuvertureGump(cp));
								break;
							}


							int Month = 1;


							if (!int.TryParse(info.GetTextEntry(2).Text, out Month))
							{
								from.SendMessage("Le mois doit être un mois de 1 %%%#$%?%$#@! 12.");
								from.SendGump(new DateOuvertureGump(cp));
								break;
							}
							else if (Month < 1 || Month > 12)
							{
								from.SendMessage("Le mois doit être un nombre de 1 %%%#$%?%$#@! 12.");
								from.SendGump(new DateOuvertureGump(cp));
								break;
							}

							int Year = 2022;

							if (!int.TryParse(info.GetTextEntry(3).Text, out Year))
							{
								from.SendMessage("L'année doit être une année après 2022.");
								from.SendGump(new DateOuvertureGump(cp));
								break;
							}
							else if (Year < 2022)
							{
								from.SendMessage("L'année doit être une année après 2022.");
								from.SendGump(new DateOuvertureGump(cp));
								break;
							}

							DateTime newdate;

							try
							{
								newdate = new DateTime(Year, Month, day);
							}
							catch (Exception)
							{

								from.SendMessage("Date invalide.");
								break;
							}


							CustomPersistence.Ouverture = newdate;


							break;
						}
				}
			}
        }
    }
}
