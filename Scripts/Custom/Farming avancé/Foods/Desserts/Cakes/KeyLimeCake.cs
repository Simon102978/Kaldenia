namespace Server.Items
{
	public class KeyLimeCake : BaseFood
	{
		[Constructable]
		public KeyLimeCake() : base( 0x9E9 )
		{
			Name = "a key lime cake";
			Weight = 1.0;
			FillFactor = 15;
			Hue = 71;
		}

		public KeyLimeCake( Serial serial ) : base( serial )
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
