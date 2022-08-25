using System;

namespace Server.Items
{
	public class RoughStone : Item
	{
		[Constructable]
		public RoughStone() : this( 1 )
		{
		}

		[Constructable]
		public RoughStone( int amount ) : base( 0x1726 )
		{
			Weight = 1.0;
			Stackable = true;
			Name = "Rough Stone";
			Amount = amount;
			Hue = 1000;
		}

		public RoughStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}