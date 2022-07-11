using System;

namespace Server.Items
{
    public class BaitStoneFish : BaseBait
	{
		[Constructable]
		public BaitStoneFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitStoneFish( int charge ) : base( Bait.StoneFish, charge )
		{
		}

		public BaitStoneFish( Serial serial ) : base( serial )
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