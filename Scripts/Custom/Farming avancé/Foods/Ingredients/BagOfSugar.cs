namespace Server.Items
{
	public class BagOfSugar : Item
	{
		[Constructable]
		public BagOfSugar() : base( 0x1045 )
		{
			Weight = 5.0;
			Stackable = true;
			Hue = 0x430;
			Name = "Bag of Sugar";
		}

		public BagOfSugar( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}
