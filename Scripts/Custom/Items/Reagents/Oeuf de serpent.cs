using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class OeufSerpent : BaseReagent
    {
        [Constructable]
        public OeufSerpent() : this(1)
        {
        }

        [Constructable]
        public OeufSerpent(int amount) : base(0xF87, amount)
        {
            Name = "oeuf de serpent";
        }

        public OeufSerpent(Serial serial) : base(serial)
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