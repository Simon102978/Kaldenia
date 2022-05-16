namespace Server.Items
{
	public class FruitCake : BaseFood
	{
		[Constructable]
		public FruitCake() : this( 0 )
		{
		}

		[Constructable]
		public FruitCake( int Color ) : base( 0x9E9 )
		{
			Name = "a fruit cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = Color;
		}

		public FruitCake( Serial serial ) : base( serial )
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
