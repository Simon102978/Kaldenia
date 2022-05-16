namespace Server.Items
{
	public class WatermelonCake : BaseFood
	{
		[Constructable]
		public WatermelonCake() : base( 0x9E9 )
		{
			Name = "a watermelon cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 34;
		}

		public WatermelonCake( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
