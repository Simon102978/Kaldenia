namespace Server.Items
{
	public class HamSlices : BaseFood
	{
		[Constructable]
		public HamSlices() : this( 1 )
		{
		}

		[Constructable]
		public HamSlices( int amount ) : base( amount, 0x1E1F )
		{
			this.Weight = 0.2;
			this.FillFactor = 1;
		}

		public HamSlices( Serial serial ) : base( serial )
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
