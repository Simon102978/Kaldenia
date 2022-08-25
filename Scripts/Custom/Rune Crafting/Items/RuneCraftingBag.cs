using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class RuneCraftingBag : Bag
	{
		public override string DefaultName
		{
			get { return "a Rune Crafting Kit"; }
		}

		[Constructable]
		public RuneCraftingBag() : this( 1 )
		{
			Movable = true;
			Hue = 2006;
		}

		[Constructable]
		public RuneCraftingBag( int amount )
		{
			DropItem( new RuneChisel( 200 ) );
			DropItem( new BagOfAllReagents( 600 ) );
			DropItem( new RoughStone( 100 ) );
		}

		public RuneCraftingBag( Serial serial ) : base( serial )
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