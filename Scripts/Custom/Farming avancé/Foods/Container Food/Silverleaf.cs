namespace Server.Items
{
	public class Silverleaf : BaseFood
	{
		[Constructable]
		public Silverleaf() : this( 1 ) { }
		[Constructable]
		public Silverleaf( int amount ) : base( amount, 0x9B6 )
		{
			Name = "Silverleaf meal";
			Hue = 96;
			Weight = 0.5;
			FillFactor = 0;
		}
		public Silverleaf( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
}
