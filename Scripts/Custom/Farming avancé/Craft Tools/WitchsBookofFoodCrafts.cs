using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x0EFA, 0x0EFA)]
	public class WitchsBookofFoodCrafts : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefWitchcraft.CraftSystem; } }

		[Constructable]
		public WitchsBookofFoodCrafts() : base(0x0EFA)
		{
            Weight = 1.0;
            Hue = 0x3CC;
            Name = "Livre de Recettes Enchant??#$?&*es";
		}

		[Constructable]
		public WitchsBookofFoodCrafts( int uses ) : base( uses, 0x9981 )
		{
            Weight = 1.0;
            Hue = 0x3CC;
            Name = "Livre de Recettes Enchant??#$?&*es";
		}

        public WitchsBookofFoodCrafts(Serial serial)
            : base(serial)
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
