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
    public class Renom
    {
        public static void Initialize()
        {
			CommandSystem.Register("Renom", AccessLevel.Player, new CommandEventHandler(Renom_OnCommand));
		}

		public static void Renom_OnCommand(CommandEventArgs e)
		{
            string name = e.ArgString.Trim();

            if (name.Length > 0)
                e.Mobile.Target = new RenomTarget(name);
            else
                e.Mobile.SendMessage("Le nouveau nom doit avoir au moins un caractère.");
        }

        private class RenomTarget : Target
        {
            private string m_Name;

            public RenomTarget(string name)  : base(1, false, TargetFlags.None)
            {
                m_Name = name;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is BaseClothing)
                {
					BaseClothing item = (BaseClothing)targeted;

                    if (item.IsChildOf(from.Backpack)) 
                        item.Name = m_Name;
                    else
                        from.SendMessage("L'item doit être dans votre sac.");
                }
				else if (targeted is BaseArmor)
				{
					BaseArmor item = (BaseArmor)targeted;

					if (item.IsChildOf(from.Backpack))
						item.Name = m_Name;
					else
						from.SendMessage("L'item doit être dans votre sac.");
				}
				else if (targeted is BaseWeapon)
				{
					BaseWeapon item = (BaseWeapon)targeted;

					if (item.IsChildOf(from.Backpack))
						item.Name = m_Name;
					else
						from.SendMessage("L'item doit être dans votre sac.");
				}
				else if (targeted is BaseFood)
				{
					BaseFood item = (BaseFood)targeted;

					if (item.IsChildOf(from.Backpack))
						item.Name = m_Name;
					else
						from.SendMessage("L'item doit être dans votre sac.");
				}
				else if (targeted is BasePotion)
				{
					BasePotion item = (BasePotion)targeted;

					if (item.IsChildOf(from.Backpack))
						item.Name = m_Name;
					else
						from.SendMessage("L'item doit être dans votre sac.");
				}
				else if (targeted is BaseBeverage)
				{
					BaseBeverage item = (BaseBeverage)targeted;

					if (item.IsChildOf(from.Backpack))
						item.Name = m_Name;
					else
						from.SendMessage("L'item doit être dans votre sac.");
				}
				else if (targeted is CraftableFurniture)
				{
					CraftableFurniture item = (CraftableFurniture)targeted;

					if (item.IsChildOf(from.Backpack))
						item.Name = m_Name;
					else
						from.SendMessage("L'item doit être dans votre sac.");
				}
				else
                {
                    from.SendMessage("Vous devez choisir un Item.");
                }

				
            }
        }
	}
}


