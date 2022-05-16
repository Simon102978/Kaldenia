namespace Server.Items
{
	public class MuttonSteak : BaseFood
	{
		[Constructable]
		public MuttonSteak() : this( 1 )
		{
		}

		[Constructable]
		public MuttonSteak( int amount ) : base( amount, 0x9F2 )
		{
			Weight = 1.0;
			FillFactor = 5;
			Name = "mutton steak";
		}

		public MuttonSteak( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
