using System;

namespace Server.Items
{
    public class BaitDreadLobster : BaseBait
	{
		[Constructable]
		public BaitDreadLobster() : this( 20 )
		{
		}

		[Constructable]
		public BaitDreadLobster( int charge ) : base( Bait.DreadLobster, charge )
		{
		}

		public BaitDreadLobster( Serial serial ) : base( serial )
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