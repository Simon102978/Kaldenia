using System;

namespace Server.Items
{
    public class BaitSpiderCrab : BaseBait
	{
		[Constructable]
		public BaitSpiderCrab() : this( 20 )
		{
		}

		[Constructable]
		public BaitSpiderCrab( int charge ) : base( Bait.SpiderCrab, charge )
		{
		}

		public BaitSpiderCrab( Serial serial ) : base( serial )
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