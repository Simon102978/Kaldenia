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
	public class DefenceChanceRune : BaseRune
	{

		[Constructable]
		public DefenceChanceRune() : base()
		{
			Weight = 0.2;  // ?
			Name = "Defense";
			Hue = 2584;
		}

		public override bool CanEnchant(Item item, Mobile from)
		{
			 if (item is BaseArmor)
			{
				return true;
			}
			else if(item is BaseShield)
			{
				return true;
			}

			from.SendMessage("Vous pouvez enchanter que les armures et les boucliers avec cette rune.");

			return base.CanEnchant(item, from);
		}

		public override void Enchant(Item item, Mobile from)
		{

			int augmentper = Utility.Random(5) + 1;

			 if (item is BaseArmor Armor)
			{			
				Armor.Attributes.DefendChance += augmentper;				
			}

			else if (item is BaseShield Shield)
			{			
				Shield.Attributes.DefendChance += augmentper;					
			}


			base.Enchant(item, from);
		}


		public DefenceChanceRune( Serial serial ) : base( serial )
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