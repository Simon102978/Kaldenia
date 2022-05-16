
using System;
using Server;
using Server.Scripts;

namespace Server.Items
{
	public class BottleOfWineExp : BaseCraftWine
	{
		public override Item EmptyItem{ get { return new EmptyWineBottle(); } }

		[Constructable]
		public BottleOfWineExp() : base( 0x9C7 )
		{
			this.Weight = 0.2;
			this.FillFactor = 4;
		}

		public BottleOfWineExp( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}
