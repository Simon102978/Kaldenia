using System;

namespace Server.Items
{
    public class BaitSeekerFish : BaseBait
	{
		[Constructable]
		public BaitSeekerFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitSeekerFish( int charge ) : base( Bait.SeekerFish, charge )
		{
		}

		public BaitSeekerFish( Serial serial ) : base( serial )
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