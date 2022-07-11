using System;

namespace Server.Items
{
    public class BaitBullFish : BaseBait
	{
		[Constructable]
		public BaitBullFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitBullFish( int charge ) : base( Bait.BullFish, charge )
		{
		}

		public BaitBullFish( Serial serial ) : base( serial )
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