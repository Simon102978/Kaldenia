using System;

namespace Server.Items
{
    public class BaitSummerDragonfish : BaseBait
	{
		[Constructable]
		public BaitSummerDragonfish() : this( 20 )
		{
		}

		[Constructable]
		public BaitSummerDragonfish( int charge ) : base( Bait.SummerDragonfish, charge )
		{
		}

		public BaitSummerDragonfish( Serial serial ) : base( serial )
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