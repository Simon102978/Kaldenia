using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class xFiche
    {
        public static void Initialize()
        {
            CommandSystem.Register("xFiche", AccessLevel.GameMaster, new CommandEventHandler(xFiche_OnCommand));
        }

        public static void xFiche_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.BeginTarget(12, false, TargetFlags.None, new TargetCallback(xFiche_OnTarget));
        }

        public static void xFiche_OnTarget(Mobile from, object targ)
        {
            if (targ is CustomPlayerMobile && from is CustomPlayerMobile)
            {
                //from.CloseGump(typeof(FicheGump));
                //from.CloseGump(typeof(FicheBeauteGump));
                //from.CloseGump(typeof(FicheAptitudesGump));

                from.SendGump(new FicheGump((CustomPlayerMobile)targ, (CustomPlayerMobile)from));
            }
        }
    }
}