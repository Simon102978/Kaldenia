using System;
using Server.Network;

namespace Server.Items
{
	public class Asparagus : BaseFood
	{
		[Constructable]
		public Asparagus() : this( 1 )
		{
		}

		[Constructable]
		public Asparagus( int amount ) : base( amount, 0xC77 )
		{
			FillFactor = 2;
			Name = "Asparagus";
			Hue = 0x1D3;
		}

		public Asparagus( Serial serial ) : base( serial )
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