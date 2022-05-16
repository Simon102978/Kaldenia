using System;
using Server.Network;

namespace Server.Items
{
	public class Beet : BaseFood
	{
		[Constructable]
		public Beet() : this( 1 )
		{
		}

		[Constructable]
		public Beet( int amount ) : base( amount, 0xD39 )
		{
			Weight = 0.5;
			FillFactor = 1;
			Hue = 0x1B;
			Name = "Beet";
		}

		public Beet( Serial serial ) : base( serial )
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