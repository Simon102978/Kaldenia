namespace Server.Items
{
	public class Miso1 : BaseFood
	{
		[Constructable]
		public Miso1() : base( 1, 10317 )
		{
			FillFactor = 5;
		}

		public Miso1( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
    public class Miso2 : BaseFood
	{
		[Constructable]
		public Miso2() : base( 1, 10318 )
		{
			FillFactor = 5;
		}

		public Miso2( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
	public class Miso3 : BaseFood
	{
		[Constructable]
		public Miso3() : base( 1, 10319 )
		{
			FillFactor = 5;
		}

		public Miso3( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
	public class Miso4 : BaseFood
	{
		[Constructable]
		public Miso4() : base( 1, 10320 )
		{
			FillFactor = 5;
		}

		public Miso4( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
}
