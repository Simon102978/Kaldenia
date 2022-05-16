namespace Server.Items
{
	public class PennyCandy : BaseFood
	{
		[Constructable]
		public PennyCandy() : this( 1 ){}

		[Constructable]
		public PennyCandy( int amount ) : base( amount, 0x3BC7 )
		{
			Name = "Candy";
			Weight = 1.0;
			FillFactor = 1;
		}

		public PennyCandy( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
}
