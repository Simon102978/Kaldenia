
using System;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute(0xC74, 0xC75)]
    public class HoneydewMelonExp : BaseFood
    {
        [Constructable]
        public HoneydewMelonExp() : this(1) { }

        [Constructable]
        public HoneydewMelonExp(int amount)
            : base(amount, 0xC74)
        {
            this.Weight = 1.0;
            this.FillFactor = 1;
        }

        public HoneydewMelonExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
