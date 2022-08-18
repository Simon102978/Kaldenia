using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CerveauSpectre : BaseReagent
    {
        public static void Initialize()
        {
            TileData.ItemTable[0x1CF0].Flags = TileFlag.Generic;
        }

        [Constructable]
        public CerveauSpectre() : this(1)
        {
        }

        [Constructable]
        public CerveauSpectre(int amount) : base(0x1CF0, amount)
        {
            Name = "cerveau de spectre";
			Stackable = false;
		}

        public CerveauSpectre(Serial serial) : base(serial)
        {
        }

      

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                case 0: break;
            }

            if (version < 1)
                Delete();
        }
    }
}