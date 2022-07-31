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
            CommandSystem.Register("GoRandom", AccessLevel.GameMaster, new CommandEventHandler(GoRandom_OnCommand));
			CommandSystem.Register("GoR", AccessLevel.GameMaster, new CommandEventHandler(GoRandom_OnCommand));
		}

        [Usage("GoRandom")]
		[Description("Teleporte sur un joueurs au hasard")]
        public static void GoRandom_OnCommand(CommandEventArgs e)
		{
			try
			{
				int count = NetState.Instances.Count;

				for (int i = 0; i < 25; ++i)
				{
					NetState ns = (NetState)NetState.Instances[Utility.Random(NetState.Instances.Count)];
					Mobile target = ns.Mobile;

					if (target != null && target.Map != null && target.Map != Map.Internal && target.AccessLevel == AccessLevel.Player)
					{
						Mobile from = e.Mobile;

						if (i > 5 || !from.InRange(target.Location,25))
						{
						


							if (Follow.Collection.Contains(from))
							{
								Follow.Collection.Remove(from);
								from.SendMessage("Vous ne suivez plus personne.");
							}

							if (!from.Hidden)
							{
								from.Hidden = true;
							}




							from.MoveToWorld(target.Location, target.Map);

							break;
						}
						else
						{
							continue;
						}

				
						
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