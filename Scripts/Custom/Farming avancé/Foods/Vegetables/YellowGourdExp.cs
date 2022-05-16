
using System;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute(0xC64, 0xC65)]
    public class YellowGourdExp : BaseFood
    {
        [Constructable]
        public YellowGourdExp() : this(1) { }

        [Constructable]
        public YellowGourdExp(int amount)
            : base(amount, 0xC64)
        {
            this.Weight = 1.0;
            this.FillFactor = 1;
        }

        public YellowGourdExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
