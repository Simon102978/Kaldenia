namespace Server.Items
{
	public class CarrotCake : BaseFood
	{
		[Constructable]
		public CarrotCake() : base( 0x9E9 )
		{
			Name = "a carrot cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 248;
		}

		public CarrotCake( Serial serial ) : base( serial )
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
