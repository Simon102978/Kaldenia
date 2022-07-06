using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;
using Server.Gumps;

namespace Server.Scripts.Commands
{
    public class Money
    {
        public static void Initialize()
        {
            CommandSystem.Register("Money", AccessLevel.GameMaster, new CommandEventHandler(Money_OnCommand));
        }

        public static void Money_OnCommand(CommandEventArgs e)
        {
			Mobile from = e.Mobile;

			if (from is CustomPlayerMobile cp)
				from.SendGump(new MoneyGump(cp,new System.Collections.Generic.Dictionary<Mobile, int>(), 0));



        }


    }
}
