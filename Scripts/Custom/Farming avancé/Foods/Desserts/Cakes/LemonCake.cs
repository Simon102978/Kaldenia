namespace Server.Items
{
	public class LemonCake : BaseFood
	{
		[Constructable]
		public LemonCake() : base( 0x9E9 )
		{
			Name = "a lemon cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 53;
		}

		public LemonCake( Serial serial ) : base( serial )
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
