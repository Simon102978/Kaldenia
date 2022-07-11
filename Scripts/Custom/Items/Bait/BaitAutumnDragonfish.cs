using System;

namespace Server.Items
{
    public class BaitAutumnDragonfish : BaseBait
	{
		[Constructable]
		public BaitAutumnDragonfish() : this( 20 )
		{
		}

		[Constructable]
		public BaitAutumnDragonfish( int charge ) : base( Bait.AutumnDragonfish, charge )
		{
		}

		public BaitAutumnDragonfish( Serial serial ) : base( serial )
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