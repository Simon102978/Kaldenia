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
	public class ResistColdRune : BaseRune
	{

		[Constructable]
		public ResistColdRune() : base()
		{
			Weight = 0.2;  // ?
			Name = "Resistance au froid";
			Hue = 1416;
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

			int augmentper = Utility.Random(7) + 1;

			if (item is BaseArmor Armor)
			{			
				Armor.ColdBonus += augmentper;				
			}


			base.Enchant(item, from);
		}


		public ResistColdRune( Serial serial ) : base( serial )
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