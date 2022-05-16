
using System;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute(0xC66, 0xC67)]
    public class GreenGourdExp : BaseFood
    {
        [Constructable]
        public GreenGourdExp() : this(1) { }

        [Constructable]
        public GreenGourdExp(int amount)
            : base(amount, 0xC66)
        {
            this.Weight = 1.0;
            this.FillFactor = 1;
        }

        public GreenGourdExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
