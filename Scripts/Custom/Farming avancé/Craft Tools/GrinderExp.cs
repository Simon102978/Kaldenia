using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x9950, 0x9951)]
	public class GrinderExp : BaseTool
	{
        public override CraftSystem CraftSystem { get { return DefGrinding.CraftSystem; } }

		[Constructable]
        public GrinderExp()
            : base(0x9950)
		{
			Name = "Grinder";
			Weight = 2.0;
		}

		[Constructable]
        public GrinderExp(int uses)
            : base(uses, 0x9950)
		{
            Name = "Grinder";
			Weight = 2.0;
		}

        public GrinderExp(Serial serial)
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}
