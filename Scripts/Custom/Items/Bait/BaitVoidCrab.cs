using System;

namespace Server.Items
{
    public class BaitVoidCrab : BaseBait
	{
		[Constructable]
		public BaitVoidCrab() : this( 20 )
		{
		}

		[Constructable]
		public BaitVoidCrab( int charge ) : base( Bait.VoidCrab, charge )
		{
		}

		public BaitVoidCrab( Serial serial ) : base( serial )
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