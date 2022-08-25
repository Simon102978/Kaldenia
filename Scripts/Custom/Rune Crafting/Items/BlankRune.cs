using System;

namespace Server.Items
{
	public class BlankRune : Item
	{
		[Constructable]
		public BlankRune() : this( 1 )
		{
		}

		[Constructable]
		public BlankRune( int amount ) : base( 0x2808 )
		{
			Weight = 0.0;
			Stackable = false;
			Name = "Blank Rune";
			//Amount = amount;
			Hue = 998;
		}

		public BlankRune( Serial serial ) : base( serial )
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