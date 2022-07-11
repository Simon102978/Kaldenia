using System;

namespace Server.Items
{
    public class BaitYellowtailBarracuda : BaseBait
	{
		[Constructable]
		public BaitYellowtailBarracuda() : this( 20 )
		{
		}

		[Constructable]
		public BaitYellowtailBarracuda( int charge ) : base( Bait.YellowtailBarracuda, charge )
		{
		}

		public BaitYellowtailBarracuda( Serial serial ) : base( serial )
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