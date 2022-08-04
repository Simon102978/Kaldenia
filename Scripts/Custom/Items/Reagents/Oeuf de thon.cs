using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class OeufThon : BaseReagent
    {
        [Constructable]
        public OeufThon() : this(1)
        {
        }

        [Constructable]
        public OeufThon(int amount) : base(0xF87, amount)
        {
            Hue = 2101;
            Name = "oeuf de thon";
        }

        public OeufThon(Serial serial) : base(serial)
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