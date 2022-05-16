namespace Server.Items
{
	public class ChickenPotPie : BaseFood
	{
		[Constructable]
		public ChickenPotPie() : base( 0x1041 )
		{
			Name = "baked chicken pot pie";
			Weight = 1.0;
			FillFactor = 10;
		}

		public ChickenPotPie( Serial serial ) : base( serial )
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
