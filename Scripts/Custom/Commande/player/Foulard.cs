using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;


namespace Server.Scripts.Commands
{
    public class Foulard
    {
        public static void Initialize()
        {
			CommandSystem.Register("Foulard", AccessLevel.Player, new CommandEventHandler(Foulard_OnCommand));
		}

		public static void Foulard_OnCommand(CommandEventArgs e)
		{
            Mobile from = e.Mobile;

            if (!from.Alive)
                return;

			foreach (Layer Laitem in Enum.GetValues(typeof(Layer)))
			{
				Item item = from.FindItemOnLayer(Laitem);

				if (item is Foulard2)
				{
					if (item.ItemID == 41799)
					{
						item.ItemID = 41800;
						from.SendMessage("Vous remontez votre foulard.");
						return;
					}
					else
					{
						item.ItemID = 41799;
						from.SendMessage("Vous abaissez votre foulard.");
						return;
					}
				}
			}

                from.SendMessage("Vous devez avoir un foulard autour du cou.");
            
        }
    }
}