using System;

namespace Server.Items
{
    public class BaitBloodLobster : BaseBait
	{
		[Constructable]
		public BaitBloodLobster() : this( 20 )
		{
		}

		[Constructable]
		public BaitBloodLobster( int charge ) : base( Bait.BloodLobster, charge )
		{
		}

		public BaitBloodLobster( Serial serial ) : base( serial )
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