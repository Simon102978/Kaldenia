namespace Server.Items
{
	public class LambLegExp : BaseFood
	{
		[Constructable]
		public LambLegExp() : this( 1 )
		{
		}

		[Constructable]
		public LambLegExp( int amount ) : base( amount, 0x160a )
		{
			Weight = 2.0;
			FillFactor = 5;
		}

		public LambLegExp( Serial serial ) : base( serial )
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
