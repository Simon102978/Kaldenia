
using System;
using Server.Network;

namespace Server.Items
{
    public class RoastDuckExp : BaseFood
    {
        [Constructable]
        public RoastDuckExp() : this(1) { }

        [Constructable]
        public RoastDuckExp(int amount)
            : base(amount, 0x9B7)
        {
            Weight = 1.0;
            FillFactor = 5;
        }

        public RoastDuckExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
