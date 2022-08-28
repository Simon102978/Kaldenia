namespace Server.Items
{
	public class StrawberryCake : BaseFood
	{
		[Constructable]
		public StrawberryCake() : base( 0x9E9 )
		{
			Name = "Un Gâteau à la Fraise";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 0x85;
		}

		public StrawberryCake( Serial serial ) : base( serial )
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
