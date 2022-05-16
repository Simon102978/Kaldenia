namespace Server.Items
{
	public class BeefHock : BaseFood
	{
		[Constructable]
		public BeefHock() : this( 1 ) { }
		[Constructable]
		public BeefHock( int amount ) : base( amount, 0x9D3 )
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
			Name = "Beef Hock";
			Hue = 0x459;
		}
		public BeefHock( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
}
