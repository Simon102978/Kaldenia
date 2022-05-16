namespace Server.Items
{
	public class MuttonRoastSlices : BaseFood
	{
		[Constructable]
		public MuttonRoastSlices() : this( 1 )
		{
		}

		[Constructable]
		public MuttonRoastSlices( int amount ) : base( amount, 0x1E1F )
		{
			this.Weight = 0.2;
			this.FillFactor = 1;
			Name = "mutton roast slices";
			Hue = 1831;
		}

		public MuttonRoastSlices( Serial serial ) : base( serial )
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
