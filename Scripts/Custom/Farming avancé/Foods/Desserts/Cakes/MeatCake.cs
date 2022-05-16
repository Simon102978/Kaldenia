namespace Server.Items
{
	public class MeatCake : BaseFood
	{
		[Constructable]
		public MeatCake() : this( 0 )
		{
		}

		[Constructable]
		public MeatCake( int Color ) : base( 0x9E9 )
		{
			Name = "a meat cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = Color;
		}

		public MeatCake( Serial serial ) : base( serial )
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
