using System;

namespace Server.Items
{
    public class BaitUnicornFish : BaseBait
	{
		[Constructable]
		public BaitUnicornFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitUnicornFish( int charge ) : base( Bait.UnicornFish, charge )
		{
		}

		public BaitUnicornFish( Serial serial ) : base( serial )
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