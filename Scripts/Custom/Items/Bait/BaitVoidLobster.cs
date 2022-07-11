using System;

namespace Server.Items
{
    public class BaitVoidLobster : BaseBait
	{
		[Constructable]
		public BaitVoidLobster() : this( 20 )
		{
		}

		[Constructable]
		public BaitVoidLobster( int charge ) : base( Bait.VoidLobster, charge )
		{
		}

		public BaitVoidLobster( Serial serial ) : base( serial )
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