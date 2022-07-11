using System;

namespace Server.Items
{
    public class BaitGiantKoi : BaseBait
	{
		[Constructable]
		public BaitGiantKoi() : this( 20 )
		{
		}

		[Constructable]
		public BaitGiantKoi( int charge ) : base( Bait.GiantKoi, charge )
		{
		}

		public BaitGiantKoi( Serial serial ) : base( serial )
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