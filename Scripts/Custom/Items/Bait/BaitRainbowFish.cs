using System;

namespace Server.Items
{
    public class BaitRainbowFish : BaseBait
	{
		[Constructable]
		public BaitRainbowFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitRainbowFish( int charge ) : base( Bait.RainbowFish, charge )
		{
		}

		public BaitRainbowFish( Serial serial ) : base( serial )
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