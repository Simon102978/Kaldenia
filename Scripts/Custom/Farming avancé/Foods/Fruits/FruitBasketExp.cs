namespace Server.Items
{
	public class FruitBasketExp : BaseFood
	{
		[Constructable]
		public FruitBasketExp() : this( 1 ) { }
		[Constructable]
		public FruitBasketExp( int amount ) : base( amount, 0x993 )
		{
			this.Weight = 2.0;
			this.FillFactor = 3;
			this.Name = "basket of fruit";
		}
		public FruitBasketExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
}
