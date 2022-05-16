namespace Server.Items
{
	public class CheeseWedgeSmall : BaseFood
	{
		[Constructable]
		public CheeseWedgeSmall() : this( 1 ) { }
		[Constructable]
		public CheeseWedgeSmall( int amount ) : base( amount, 0x97C )
		{
			Weight = 0.1;
			FillFactor = 3;
		}
		public CheeseWedgeSmall( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
}
