using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;
using Server.Gumps;
using Server.Accounting;

namespace Server.Scripts.Commands
{
    public class Economie
	{
        public static void Initialize()
        {
            CommandSystem.Register("Economie", AccessLevel.GameMaster, new CommandEventHandler(Economie_OnCommand));
        }

        public static void Economie_OnCommand(CommandEventArgs e)
        {
			Mobile from = e.Mobile;

			if (from is CustomPlayerMobile cp)
				from.SendGump(new EconomieGump(cp,new System.Collections.Generic.Dictionary<string, double>(), 0));



        }


    }
}
