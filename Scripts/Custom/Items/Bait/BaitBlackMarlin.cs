using System;

namespace Server.Items
{
    public class BaitBlackMarlin : BaseBait
	{
		[Constructable]
		public BaitBlackMarlin() : this( 20 )
		{
		}

		[Constructable]
		public BaitBlackMarlin( int charge ) : base( Bait.BlackMarlin, charge )
		{
		}

		public BaitBlackMarlin( Serial serial ) : base( serial )
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