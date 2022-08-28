﻿using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x0EFA, 0x0EFA)]
	public class WitchsBookofFoodCrafts : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefWitchcraft.CraftSystem; } }

		[Constructable]
		public WitchsBookofFoodCrafts() : base(9120)
		{
			Weight = 3.0;
			Layer = Layer.OneHanded;
			Hue = 0x3CC;
            Name = "Livre de Recettes Enchantées";
		}

		[Constructable]
		public WitchsBookofFoodCrafts( int uses ) : base( uses, 9120)
		{
			Weight = 3.0;
			Layer = Layer.OneHanded;
			Hue = 0x3CC;
            Name = "Livre de Recettes Enchantées";
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
