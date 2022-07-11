using System;

namespace Server.Items
{
    public class BaitCrystalFish : BaseBait
	{
		[Constructable]
		public BaitCrystalFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitCrystalFish( int charge ) : base( Bait.CrystalFish, charge )
		{
		}

		public BaitCrystalFish( Serial serial ) : base( serial )
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