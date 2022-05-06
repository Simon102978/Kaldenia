using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Scripts.Commands
{
    public class Fiche
    {
        public static void Initialize()
        {
            CommandSystem.Register("Fiche", AccessLevel.Player, new CommandEventHandler(Fiche_OnCommand));
        }

        [Usage("Fiche")]
        [Description("Permet d'ouvrir le menu .Fiche")]
        public static void Fiche_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is CustomPlayerMobile)
            {
                from.CloseGump(typeof(FicheGump));


                from.SendGump(new FicheGump((CustomPlayerMobile)from, null));
            }
        }
    }
}