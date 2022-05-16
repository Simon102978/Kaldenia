
using System;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute(0xC7F, 0xC81)]
    public class EarOfCornExp : BaseFood
    {
        [Constructable]
        public EarOfCornExp() : this(1) { }

        [Constructable]
        public EarOfCornExp(int amount)
            : base(amount, 0xC81)
        {
            this.Weight = 1.0;
            this.FillFactor = 1;
        }

        public EarOfCornExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
