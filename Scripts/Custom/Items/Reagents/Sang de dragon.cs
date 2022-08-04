using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SangDragon : BaseReagent
    {
        [Constructable]
        public SangDragon() : this(1)
        {
        }

        [Constructable]
        public SangDragon(int amount) : base(0xF82, amount)
        {
            Name = "sang de dragon";
        }

        public SangDragon(Serial serial) : base(serial)
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