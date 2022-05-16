namespace Server.Items
{
	public class PumpkinCake : BaseFood
	{
		[Constructable]
		public PumpkinCake() : base( 0x9E9 )
		{
			Name = "a pumpkin cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 243;
		}

		public PumpkinCake( Serial serial ) : base( serial )
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
