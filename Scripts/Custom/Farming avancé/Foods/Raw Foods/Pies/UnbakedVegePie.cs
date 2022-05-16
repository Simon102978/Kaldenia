using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class UnbakedVegePie : BaseFood
	{
		[Constructable]
		public UnbakedVegePie() : this( null, 0 )
		{
		}

		[Constructable]
		public UnbakedVegePie( string Desc ) : this( Desc, 0 )
		{
		}

		[Constructable]
		public UnbakedVegePie( int Color ) : this( null, Color )
		{
		}

		[Constructable]
        public UnbakedVegePie(string Desc, int Color)
            : base(0x1042)
		{

			if ( Desc != "" && Desc != null )
				Name = "unbaked " + Desc + " vegetable pie";
			else
				Name = "unbaked vegetable pie";

			this.Hue = Color;
		}

		public UnbakedVegePie( Serial serial ) : base( serial )
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