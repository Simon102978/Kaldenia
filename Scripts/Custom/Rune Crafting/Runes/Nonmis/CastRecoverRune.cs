/*using System;
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
	public class BonusDexRune : BaseRune
	{

		[Constructable]
		public BonusDexRune() : base()
		{
			Weight = 0.2;  // ?
			Name = "Dexterité";
			Hue = 2584;
		}

		public override bool CanEnchant(Item item)
		{
			if (item is BaseWeapon)
			{
				return true;
			}
			else if (item is BaseArmor)
			{
				return true;
			}
			else if(item is BaseShield)
			{
				return true;
			}
			else if (item is BaseJewel)
			{
				return true;
			}

			return base.CanEnchant(item);
		}

		public override void Enchant(Item item, Mobile from)
		{

			int augmentper = Utility.Random(7) + 1;

			if (item is BaseWeapon Weapon)
			{				
				Weapon.Attributes.BonusDex += augmentper;								
			}

			else if (item is BaseArmor Armor)
			{			
				Armor.Attributes.BonusDex += augmentper;				
			}

			else if (item is BaseShield Shield)
			{			
						Shield.Attributes.BonusDex += augmentper;					
			}

			else if (item is BaseJewel Jewel)
			{
						Jewel.Attributes.BonusDex += augmentper;								
			}

			base.Enchant(item, from);
		}


		public BonusDexRune( Serial serial ) : base( serial )
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
}*/