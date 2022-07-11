using System;

namespace Server.Items
{
    public class BaitWinterDragonfish : BaseBait
	{
		[Constructable]
		public BaitWinterDragonfish() : this( 20 )
		{
		}

		[Constructable]
		public BaitWinterDragonfish( int charge ) : base( Bait.WinterDragonfish, charge )
		{
		}

		public BaitWinterDragonfish( Serial serial ) : base( serial )
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