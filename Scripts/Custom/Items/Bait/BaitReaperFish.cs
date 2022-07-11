using System;

namespace Server.Items
{
    public class BaitReaperFish : BaseBait
	{
		[Constructable]
		public BaitReaperFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitReaperFish( int charge ) : base( Bait.ReaperFish, charge )
		{
		}

		public BaitReaperFish( Serial serial ) : base( serial )
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