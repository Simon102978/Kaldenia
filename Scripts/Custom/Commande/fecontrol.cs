using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;
using Server.Gumps;

namespace Server.Scripts.Commands
{
    public class fecontrol
    {
        public static void Initialize()
        {
            CommandSystem.Register("fecontrol", AccessLevel.GameMaster, new CommandEventHandler(fecontrol_OnCommand));
        }

        public static void fecontrol_OnCommand(CommandEventArgs e)
        {
			Mobile from = e.Mobile;

			if (from is CustomPlayerMobile cp)
				from.SendGump(new FeControlGump(cp,new System.Collections.Generic.Dictionary<CustomPlayerMobile, int>(), 0));



        }


    }
}
