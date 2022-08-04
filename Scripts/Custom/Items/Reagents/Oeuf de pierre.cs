using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class OeufPierre : BaseReagent
    {
        [Constructable]
        public OeufPierre() : this(1)
        {
        }

        [Constructable]
        public OeufPierre(int amount) : base(0xF8B, amount)
        {
            Name = "oeuf de pierre";
        }

        public OeufPierre(Serial serial) : base(serial)
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