using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
	public class UseBestWepRune : BaseRune
	{

		[Constructable]
		public UseBestWepRune() : base()
		{
			Weight = 0.2;  // ?
			Name = "Meilleur arme";
			Hue = 999;
		}

		public override bool CanEnchant(Item item, Mobile from)
		{
			if (item is BaseWeapon Weapon)
			{
				if (Weapon.WeaponAttributes.UseBestSkill != 0)
				{
					from.SendMessage("Cette arme possède déjà cette enchantement.");
					return false;
				}




				return true;
			}

			from.SendMessage("Vous pouvez enchanter que les armes avec cette rune.");

			return base.CanEnchant(item, from);
		}

		public override void Enchant(Item item, Mobile from)
		{

			if (item is BaseWeapon Weapon)
			{
				Weapon.WeaponAttributes.UseBestSkill += 1;
			}

			base.Enchant(item, from);
		}


		public UseBestWepRune( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}