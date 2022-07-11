using System;

namespace Server.Items
{
    public class BaitBlueMarlin : BaseBait
	{
		[Constructable]
		public BaitBlueMarlin() : this( 20 )
		{
		}

		[Constructable]
		public BaitBlueMarlin( int charge ) : base( Bait.BlueMarlin, charge )
		{
		}

		public BaitBlueMarlin( Serial serial ) : base( serial )
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