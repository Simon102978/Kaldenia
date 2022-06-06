using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Scripts.Commands
{
    public class Finance
	{
        public static void Initialize()
        {
            CommandSystem.Register("Finance", AccessLevel.GameMaster, new CommandEventHandler(Finance_OnCommand));
        }

        [Usage("Finance")]
        [Description("Permet d'ouvrir le menu .Finance")]
        public static void Finance_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is CustomPlayerMobile)
            {
                from.CloseGump(typeof(FinanceGump));


                from.SendGump(new FinanceGump((CustomPlayerMobile)from));
            }
        }
    }
}