using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using Server.Misc;

namespace Server.CustomScripts.Commands
{
    class DateCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("date", AccessLevel.Counselor, new CommandEventHandler(Date_OnCommand));
        }

        [Usage("Date")]
        [Description("Retourne la date")]
        public static void Date_OnCommand(CommandEventArgs e)
        {
			int year, month, day;

			Server.Misc.Time.GetDate(out  year, out  month, out  day);
         
            e.Mobile.SendMessage("Nous sommes le " + day.ToString() + " " + ((Server.Misc.Month)month) + " de l'ann??#$?&*e " + year.ToString() + ".");


			Server.Items.Calendrier.GetDate(out year, out month, out day);

			e.Mobile.SendMessage("Nous sommes le " + day.ToString() + " " + ((Month)month) + " de l'ann??#$?&*e " + year.ToString() + ".");

		}
    }
}
