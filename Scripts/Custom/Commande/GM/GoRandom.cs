using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using Server.Engines.PartySystem;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class GoRandom
	{
		public static void Initialize()
		{
            CommandSystem.Register("GoRandom", AccessLevel.Counselor, new CommandEventHandler(GoRandom_OnCommand));
		}

        [Usage("GoRandom")] 
	    [Description("Teleporte sur un joueurs au hasard")]
        public static void GoRandom_OnCommand(CommandEventArgs e)
		{
			try
			{
				int count = NetState.Instances.Count;

				for (int i = 0; i < 10; ++i)
				{
					NetState ns = (NetState)NetState.Instances[Utility.Random(NetState.Instances.Count)];
					Mobile target = ns.Mobile;

					if (target != null && target.Map != null && target.Map != Map.Internal && target.AccessLevel == AccessLevel.Player)
					{
						Mobile from = e.Mobile;

						from.MoveToWorld(target.Location, target.Map);
						break;
					}
					else
					{
						continue;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}


}