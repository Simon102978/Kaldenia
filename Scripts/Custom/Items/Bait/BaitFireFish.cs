using System;

namespace Server.Items
{
    public class BaitFireFish : BaseBait
	{
		[Constructable]
		public BaitFireFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitFireFish( int charge ) : base( Bait.FireFish, charge )
		{
		}

		public BaitFireFish( Serial serial ) : base( serial )
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