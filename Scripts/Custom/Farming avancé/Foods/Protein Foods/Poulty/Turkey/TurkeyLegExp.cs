
using System;
using Server.Network;

namespace Server.Items
{
    public class TurkeyLegExp : BaseFood
    {
        [Constructable]
        public TurkeyLegExp() : this(1) { }

        [Constructable]
        public TurkeyLegExp(int amount)
            : base(amount, 0x1608)
        {
            Weight = 1.0;
            FillFactor = 4;
        }

        public TurkeyLegExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
