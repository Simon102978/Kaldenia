namespace Server.Items
{
	public class Donuts : BaseFood
	{
		[Constructable]
		public Donuts() : this( 1 )
		{
		}

		[Constructable]
		public Donuts( int amount ) : base( amount, 6867 )
		{
			Weight = 2.0;
			FillFactor = 3;
		}

		public Donuts( Serial serial ) : base( serial )
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
