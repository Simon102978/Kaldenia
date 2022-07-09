using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;
using Server.Gumps;
using Server.Accounting;

namespace Server.Scripts.Commands
{
    public class HallOfShame
	{
        public static void Initialize()
        {
            CommandSystem.Register("HallOfShame", AccessLevel.GameMaster, new CommandEventHandler(HallOfShame_OnCommand));
        }

        public static void HallOfShame_OnCommand(CommandEventArgs e)
        {
			Mobile from = e.Mobile;

			if (from is CustomPlayerMobile cp)
				from.SendGump(new HallOfShameGump(cp,new System.Collections.Generic.Dictionary<Account, double>(), 0));



        }


    }
}
