using Server.Commands;
using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using System.Reflection;
using Server.Misc;
using System.Diagnostics;

namespace Server.Commands
{
    public class ViewHueCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("ViewHue", AccessLevel.Owner, new CommandEventHandler(ViewHue_OnCommand));
            CommandSystem.Register("ViewHues", AccessLevel.GameMaster, new CommandEventHandler(ViewHues_OnCommand));
        }

        [Usage("ViewHue")]
        [Description("View Hues in a Gump List")]
        private static void ViewHue_OnCommand( CommandEventArgs e )
        {
            e.Mobile.SendGump(new ViewHueGump(e.Mobile, 0));
        }

        [Usage("ViewHues")]
        [Description("View Hues Gump")]
        public static void ViewHues_OnCommand( CommandEventArgs e )
        {
            e.Mobile.SendGump(new ViewHuesGump(e.Mobile, 1, 4011));
        }
    }
}
