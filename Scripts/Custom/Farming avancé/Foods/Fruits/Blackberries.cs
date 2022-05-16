namespace Server.Items
{
	public class Blackberry : BaseFood
	{
		[Constructable]
		public Blackberry() : this( 1 )
		{
		}

		[Constructable]
		public Blackberry( int amount ) : base( amount, 0x9D1 )
		{
			FillFactor = 1;
			Hue = 0x25A;
			Name = "Blackberry";
		}

		public Blackberry( Serial serial ) : base( serial )
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
