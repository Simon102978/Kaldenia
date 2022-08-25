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
	public class RegenHitsRune : BaseRune
	{

		[Constructable]
		public RegenHitsRune() : base()
		{
			Weight = 0.2;  // ?
			Name = "Regeneration de vie";
			Hue = 1710;
		}

		public override bool CanEnchant(Item item, Mobile from)
		{

			if (item is BaseJewel)
			{
				return true;
			}


			from.SendMessage("Vous pouvez enchanter que les bijoux avec cette rune.");

			return base.CanEnchant(item, from);
		}

		public override void Enchant(Item item, Mobile from)
		{

			int augmentper = Utility.Random(2) + 1; 

			if (item is BaseJewel Jewel)
			{
						Jewel.Attributes.RegenHits += augmentper;								
			}

			base.Enchant(item, from);
		}


		public RegenHitsRune( Serial serial ) : base( serial )
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