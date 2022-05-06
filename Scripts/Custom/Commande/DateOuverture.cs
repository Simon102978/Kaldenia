using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Custom;
using Server.Gumps;

namespace Server.Scripts.Commands
{
    public class DateOuverture
    {
        public static void Initialize()
        {
            CommandSystem.Register("dateouverture", AccessLevel.Administrator, new CommandEventHandler(DateOuverture_OnCommand));
        }

        [Usage("DateOuverture")]
        [Description("Permet de savoir la date d'ouverture")]
        public static void DateOuverture_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is CustomPlayerMobile)
            {


				from.SendGump(new DateOuvertureGump((CustomPlayerMobile)from));

			//	from.SendMessage(CustomPersistence.Ouverture.ToString());
					
            }
        }
    }
}