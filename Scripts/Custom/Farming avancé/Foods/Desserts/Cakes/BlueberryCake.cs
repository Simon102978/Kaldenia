namespace Server.Items
{
	public class BlueberryCake : BaseFood
	{
		[Constructable]
		public BlueberryCake() : base( 0x9E9 )
		{
			Name = "a lemon cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 0x62;
		}

		public BlueberryCake( Serial serial ) : base( serial )
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
