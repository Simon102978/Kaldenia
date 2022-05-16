namespace Server.Items
{
	public class CoconutCake : BaseFood
	{
		[Constructable]
		public CoconutCake() : base( 0x9E9 )
		{
			Name = "a coconut cake";
			Weight = 1.0;
		    FillFactor = 15;
			Hue = 556;
		}

		public CoconutCake( Serial serial ) : base( serial )
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
