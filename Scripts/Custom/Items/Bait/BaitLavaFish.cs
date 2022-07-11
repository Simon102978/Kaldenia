using System;

namespace Server.Items
{
    public class BaitLavaFish : BaseBait
	{
		[Constructable]
		public BaitLavaFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitLavaFish( int charge ) : base( Bait.LavaFish, charge )
		{
		}

		public BaitLavaFish( Serial serial ) : base( serial )
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