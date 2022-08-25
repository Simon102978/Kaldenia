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
	public class SpellChannelRune : BaseRune
	{

		[Constructable]
		public SpellChannelRune() : base()
		{
			Weight = 0.2;  // ?
			Name = "Canalisation Magique";
			Hue = 1266;
		}

		public override bool CanEnchant(Item item, Mobile from)
		{
			if (item is BaseWeapon)
			{
				return true;
			}
			else if(item is BaseShield)
			{
				return true;
			}


			from.SendMessage("Vous pouvez enchanter que les armes et les boucliers avec cette rune.");

			return base.CanEnchant(item, from);
		}

		public override void Enchant(Item item, Mobile from)
		{
			if (item is BaseWeapon Weapon)
			{
				Weapon.Attributes.SpellChanneling = 1;
			}
			else if (item is BaseShield Shield)
			{
				Shield.Attributes.SpellChanneling = 1;
			}


			base.Enchant(item, from);
		}


		public SpellChannelRune( Serial serial ) : base( serial )
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