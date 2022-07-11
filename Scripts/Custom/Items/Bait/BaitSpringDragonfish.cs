using System;

namespace Server.Items
{
    public class BaitSpringDragonfish : BaseBait
	{
		[Constructable]
		public BaitSpringDragonfish() : this( 20 )
		{
		}

		[Constructable]
		public BaitSpringDragonfish( int charge ) : base( Bait.SpringDragonfish, charge )
		{
		}

		public BaitSpringDragonfish( Serial serial ) : base( serial )
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