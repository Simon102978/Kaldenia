namespace Server.Items
{
	public class VenisonSteak : BaseFood
	{
		[Constructable]
		public VenisonSteak() : this( 1 )
		{
		}

		[Constructable]
		public VenisonSteak( int amount ) : base( amount, 0x9F2 )
		{
            Name = "venison steak";
			Weight = 1.0;
			FillFactor = 5;
            Stackable = true;
            Amount = amount;
		}

		public VenisonSteak( Serial serial ) : base( serial )
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
