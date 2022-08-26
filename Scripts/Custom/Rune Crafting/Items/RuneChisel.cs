using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x13E4, 0x13E3 )]
	public class RuneChisel : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefRuneCrafting.CraftSystem; } }

		[Constructable]
		public RuneChisel() : base( 0x10E7 )
		{
			Name = "Ciseau runique";
			Hue = 2962;
			Weight = 4.0;
		}

		[Constructable]
		public RuneChisel( int uses ) : base( uses, 0x10E7 )
		{
			Name = "Ciseau runique";
			Hue = 2962;
			Weight = 4.0;
			Layer = Layer.OneHanded;
		}

		public RuneChisel( Serial serial ) : base( serial )
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