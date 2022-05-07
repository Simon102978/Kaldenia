using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;

namespace Server.CustomScripts.Commands
{
    class GMCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("GM", AccessLevel.Player, new CommandEventHandler(GM_OnCommand));
        }

        [Usage("GM")]
        [Description("Toggle Player and GameMaster access")]
        public static void GM_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            if (from.AccessLevel >= AccessLevel.Counselor)
                from.AccessLevel = AccessLevel.Player;
            else if (from.Account.AccessLevel >= AccessLevel.Counselor)
                from.AccessLevel = from.Account.AccessLevel;
            else
                from.SendMessage("Vous devez être Maître de jeu pour utiliser cette commande");
        }
    }
}
