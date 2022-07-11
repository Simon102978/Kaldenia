using System;

namespace Server.Items
{
    public class BaitHolyMackerel : BaseBait
	{
		[Constructable]
		public BaitHolyMackerel() : this( 20 )
		{
		}

		[Constructable]
		public BaitHolyMackerel( int charge ) : base( Bait.HolyMackerel, charge )
		{
		}

		public BaitHolyMackerel( Serial serial ) : base( serial )
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