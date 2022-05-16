namespace Server.Items
{
	public class GrapeCake : BaseFood
	{
		[Constructable]
		public GrapeCake() : base( 0x9E9 )
		{
			Name = "a grape cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 21;
		}

		public GrapeCake( Serial serial ) : base( serial )
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
