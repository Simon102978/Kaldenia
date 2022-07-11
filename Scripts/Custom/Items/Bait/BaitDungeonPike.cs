using System;

namespace Server.Items
{
    public class BaitDungeonPike : BaseBait
	{
		[Constructable]
		public BaitDungeonPike() : this( 20 )
		{
		}

		[Constructable]
		public BaitDungeonPike( int charge ) : base( Bait.DungeonPike, charge )
		{
		}

		public BaitDungeonPike( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}