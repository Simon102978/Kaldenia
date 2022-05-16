
using System;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute(0x4988, 0x498F)]
    public class TurkeyPlatterExp : BaseFood
    {
        [Constructable]
        public TurkeyPlatterExp() : this(1) { }

        [Constructable]
        public TurkeyPlatterExp(int amount)
            : base(amount, 0x4988)
        {
            Name = "Turkey Platter";
            Weight = 1.0;
            FillFactor = 10;
        }

        public TurkeyPlatterExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
