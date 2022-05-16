using System;

namespace Server.Items
{
	public class MugOfCocoa : BaseCraftCocoa
	{
		public override Item EmptyItem{ get { return new PewterMug(); } }

		[Constructable]
		public MugOfCocoa() : base( 0xFFF )
		{
			Name = "Mug of Cocoa";
			Weight = 3.0;
			FillFactor = 3;
        }

		public MugOfCocoa( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}
