using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PoilsLoup : BaseReagent
    {
        [Constructable]
        public PoilsLoup() : this(1)
        {
        }

        [Constructable]
        public PoilsLoup(int amount) : base(0xF90, amount)
        {
            Name = "poils de loup";
        }

        public PoilsLoup(Serial serial) : base(serial)
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