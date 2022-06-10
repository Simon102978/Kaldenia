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
    public class AttaqueSpecial
    {
        public static void Initialize()
        {
			CommandSystem.Register("as", AccessLevel.Player, new CommandEventHandler(AttaqueSpecial_OnCommand));
		}


		[Usage("AttaqueSpecial")]
		[Description("Permet d'utiliser les attaques spéciales.")]
		public static void AttaqueSpecial_OnCommand(CommandEventArgs e)
		{
            Mobile from = e.Mobile;

            if (!from.Alive)
                return;

			int attaque = -1;

			int.TryParse(e.ArgString, out attaque);

			bool error = false;

			if (attaque < 1 || attaque > 33)
			{
				error = true;

			}
			else
			{
				WeaponAbility attack = WeaponAbility.Abilities[attaque];

				if (attack.Validate(from))
				{
					from.SendMessage("Vous activez l'attaque special : " + attack.Name);
					WeaponAbility.SetCurrentAbility(from, attack);

				}
				else
				{
					error = true;
				}
			}

			if (error)
			{
				WeaponAbility primaire = WeaponAbility.Disarm;
				WeaponAbility secondaire = WeaponAbility.ParalyzingBlow;

				IWeapon wep = from.Weapon;

				if (wep is BaseWeapon)
				{
					BaseWeapon bw = (BaseWeapon)wep;

					primaire = bw.PrimaryAbility;
					secondaire = bw.SecondaryAbility;
				}

				from.SendMessage("Vous pouvez utiliser les attaques : " + primaire.Name + " (" + primaire.Id + "), " + secondaire.Name + " (" + secondaire.Id + ")"); // Placeholder
			}





		}
    }
}