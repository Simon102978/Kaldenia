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

            Item item = from.FindItemOnLayer(Layer.Earrings);

            if (item is Foulard2)
            {
                if (item.ItemID == 41799)
                {
                    item.ItemID = 41800;
                    from.SendMessage("Vous remontez votre foulard.");
                }
                else
                {
                    item.ItemID = 41799;
                    from.SendMessage("Vous abaissez votre foulard.");
                }
            }
            else
            {
                from.SendMessage("Vous devez avoir un foulard autour du cou.");
            }
        }
    }
}