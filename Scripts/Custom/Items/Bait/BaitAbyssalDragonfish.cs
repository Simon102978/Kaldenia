using System;

namespace Server.Items
{
    public class BaitAbyssalDragonfish : BaseBait
	{
		[Constructable]
		public BaitAbyssalDragonfish() : this( 20 )
		{
		}

		[Constructable]
		public BaitAbyssalDragonfish( int charge ) : base( Bait.AbyssalDragonfish, charge )
		{
		}

		public BaitAbyssalDragonfish( Serial serial ) : base( serial )
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