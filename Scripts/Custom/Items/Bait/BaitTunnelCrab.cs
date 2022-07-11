using System;

namespace Server.Items
{
    public class BaitTunnelCrab : BaseBait
	{
		[Constructable]
		public BaitTunnelCrab() : this( 20 )
		{
		}

		[Constructable]
		public BaitTunnelCrab( int charge ) : base( Bait.TunnelCrab, charge )
		{
		}

		public BaitTunnelCrab( Serial serial ) : base( serial )
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