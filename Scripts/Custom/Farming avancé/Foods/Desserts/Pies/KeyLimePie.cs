namespace Server.Items
{
	public class KeyLimePie : BaseFood
	{
		[Constructable]
		public KeyLimePie() : base( 0x1041 )
		{
			Name = "baked key lime pie";
			Weight = 1.0;
			FillFactor = 5;
		}

		public KeyLimePie( Serial serial ) : base( serial )
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
