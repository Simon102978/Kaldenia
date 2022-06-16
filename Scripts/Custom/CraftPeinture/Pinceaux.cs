using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable( 4033, 4033 )]
	public class Pinceaux : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefPeinture.CraftSystem; } }

		[Constructable]
		public Pinceaux() : base( 4033 )
		{
            Name = "Pinceaux";
			Weight = 2.0;
		}

		[Constructable]
		public Pinceaux( int uses ) : base( uses, 4033 )
        {
            Name = "Pinceaux";
			Weight = 2.0;
		}

		public Pinceaux( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
                Weight = 2.0;

            Name = "Pinceaux";
            ItemID = 4033;
		}
	}
}