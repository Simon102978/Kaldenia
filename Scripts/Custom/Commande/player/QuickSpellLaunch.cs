using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Spells;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class QuickSpellLaunchCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("qsl", AccessLevel.Player, new CommandEventHandler(QSL_OnCommand));
        }

        [Aliases("QuickSpellLaunch", "LancementRapide")]
        [Usage("QSL")]
        [Description("Permet d'ouvrir le menu de lancement de sorts rapide")]
        public static void QSL_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.SendMessage("Ciblez le livre de sorts à utiliser");
            from.BeginTarget(12, false, TargetFlags.None, new TargetCallback(QSL_OnTarget));
        }

        public static void QSL_OnTarget(Mobile from, object targ)
        {
            if (from is CustomPlayerMobile && targ is NewSpellbook && from.Backpack != null && ((Item)targ).Parent == from.Backpack)
                from.SendGump(new QuickSpellLaunchGump((CustomPlayerMobile)from, (NewSpellbook)targ, null));
        }
    }
}