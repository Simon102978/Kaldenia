using System;

namespace Server.Items
{
    public class BaitFairySalmon : BaseBait
	{
		[Constructable]
		public BaitFairySalmon() : this( 20 )
		{
		}

		[Constructable]
		public BaitFairySalmon( int charge ) : base( Bait.FairySalmon, charge )
		{
		}

		public BaitFairySalmon( Serial serial ) : base( serial )
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