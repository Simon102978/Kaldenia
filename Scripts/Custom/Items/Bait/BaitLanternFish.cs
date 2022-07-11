using System;

namespace Server.Items
{
    public class BaitLanternFish : BaseBait
	{
		[Constructable]
		public BaitLanternFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitLanternFish( int charge ) : base( Bait.LanternFish, charge )
		{
		}

		public BaitLanternFish( Serial serial ) : base( serial )
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