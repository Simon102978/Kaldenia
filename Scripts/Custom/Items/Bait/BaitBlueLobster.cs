using System;

namespace Server.Items
{
    public class BaitBlueLobster : BaseBait
	{
		[Constructable]
		public BaitBlueLobster() : this( 20 )
		{
		}

		[Constructable]
		public BaitBlueLobster( int charge ) : base( Bait.BlueLobster, charge )
		{
		}

		public BaitBlueLobster( Serial serial ) : base( serial )
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