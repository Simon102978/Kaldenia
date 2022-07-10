namespace Server.Items
{
	public class Pineapple : BaseFood
	{
		[Constructable]
		public Pineapple() : this( 1 )
		{
		}

		[Constructable]
		public Pineapple( int amount ) : base( amount, 0xFC4 )
		{
			FillFactor = 2;
			Hue = 0x46E;
			this.Stackable = true;
			Name = "Ananas";
		}

		public Pineapple( Serial serial ) : base( serial )
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
