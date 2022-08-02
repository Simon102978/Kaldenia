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
    public class Marque
    {
        public static void Initialize()
        {
			CommandSystem.Register("Marque", AccessLevel.Player, new CommandEventHandler(Marque_OnCommand));
		}

		public static void Marque_OnCommand(CommandEventArgs e)
		{
            string name = e.ArgString.Trim();

            if (name.Length > 0)
                e.Mobile.Target = new MarqueTarget(name);
            else
                e.Mobile.SendMessage("La marque doit avoir au moins un caractère.");
        }

        private class MarqueTarget : Target
        {
            private string m_Name;

            public MarqueTarget(string name)  : base(1, false, TargetFlags.None)
            {
                m_Name = name;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Item item )
                {

					if (item.Createur != from)
					{
						from.SendMessage("Vous devez avoir créer l'objet pour mettre votre marque.");
						return;
					}
					else if (!item.IsChildOf(from.Backpack))
					{
						from.SendMessage("L'item doit être dans votre sac.");
						return;
					}
					else
					{
						item.Description = m_Name;
					}					
				}
				else
                {
                    from.SendMessage("Vous devez choisir un Item.");
                }

				
            }
        }
	}
}


