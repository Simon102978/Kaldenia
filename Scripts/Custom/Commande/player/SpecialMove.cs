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
			CommandSystem.Register("wa", AccessLevel.Player, new CommandEventHandler(AttaqueSpecial_OnCommand));
			CommandSystem.Register("wap", AccessLevel.Player, new CommandEventHandler(AttaqueSpecialPrimaire_OnCommand));
			CommandSystem.Register("was", AccessLevel.Player, new CommandEventHandler(AttaqueSpecialSecondaire_OnCommand));
		}


		[Usage("wa")]
		[Description("Permet d'utiliser les attaques sp??#$?&*ciales.")]
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

		[Usage("wap")]
		[Description("Permet d'utiliser l'attaque sp??#$?&*ciale primaire de l'arme.")]
		public static void AttaqueSpecialPrimaire_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (!from.Alive)
				return;

				WeaponAbility primaire = WeaponAbility.Disarm;

				IWeapon wep = from.Weapon;

				if (wep is BaseWeapon)
				{
					BaseWeapon bw = (BaseWeapon)wep;

					primaire = bw.PrimaryAbility;
			
				}

				if (primaire.Validate(from))
				{
					from.SendMessage("Vous activez l'attaque special : " + primaire.Name);
					WeaponAbility.SetCurrentAbility(from, primaire);

				}		

			}

		[Usage("was")]
		[Description("Permet d'utiliser l'attaque sp??#$?&*ciale secondaire de l'arme.")]
		public static void AttaqueSpecialSecondaire_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (!from.Alive)
				return;

			WeaponAbility primaire = WeaponAbility.ParalyzingBlow;

			IWeapon wep = from.Weapon;

			if (wep is BaseWeapon)
			{
				BaseWeapon bw = (BaseWeapon)wep;

				primaire = bw.SecondaryAbility;

			}

			if (primaire.Validate(from))
			{
				from.SendMessage("Vous activez l'attaque special : " + primaire.Name);
				WeaponAbility.SetCurrentAbility(from, primaire);
			}
		}
	}	
}