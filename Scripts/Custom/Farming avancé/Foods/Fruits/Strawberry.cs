namespace Server.Items
{
	public class Strawberry : BaseFood
	{
		[Constructable]
		public Strawberry() : this( 1 )
		{
		}

		[Constructable]
		public Strawberry( int amount ) : base( amount, 0xF2A )
		{
			FillFactor = 1;
			Hue = 0x85;
			Name = "Strawberry";
			Weight = 0.1;
		}

		public Strawberry( Serial serial ) : base( serial )
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
