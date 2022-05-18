
using System;

namespace Server.Items
{
	public class EmptyWineBottle : Item
	{
		[Constructable]
		public EmptyWineBottle() : this( 1 ){}

		[Constructable]
		public EmptyWineBottle( int amount ) : base(0x099B)
		{
			Stackable = true;
			Name = "Empty Wine Bottle";
			Amount = amount;
			Hue = 0;
		}

		public EmptyWineBottle( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}