using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class ChoisirGrimoire
    {
        public static void Initialize()
        {
            CommandSystem.Register("ChoisirGrimoire", AccessLevel.Player, new CommandEventHandler(ChoisirGrimoire_OnCommand));
        }

        public static void ChoisirGrimoire_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.BeginTarget(12, false, TargetFlags.None, new TargetCallback(ChoisirGrimoire_OnTarget));
        }

        public static void ChoisirGrimoire_OnTarget(Mobile from, object targ)
        {
            if (targ is NewSpellbook && from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)from;
                pm.ChosenSpellbook = (NewSpellbook)targ;
            }
            else
                from.SendMessage("Vous devez cibler un livre de sort (nouvelle version) !");
        }
    }
}