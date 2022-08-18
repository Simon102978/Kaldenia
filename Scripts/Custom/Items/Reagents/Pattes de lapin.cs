using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PattesLapin : BaseReagent
    {
        public static void Initialize()
        {
            TileData.ItemTable[0x1E8C].Flags = TileFlag.Generic;
            TileData.ItemTable[0x1E8D].Flags = TileFlag.Generic;
        }

        [Constructable]
        public PattesLapin() : this(1)
        {
        }

        [Constructable]
        public PattesLapin(int amount) : base(0x1E8C, amount)
        {
            Name = "pattes de lapin";
			Stackable = false;
		}

        public PattesLapin(Serial serial) : base(serial)
        {
        }

       

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}