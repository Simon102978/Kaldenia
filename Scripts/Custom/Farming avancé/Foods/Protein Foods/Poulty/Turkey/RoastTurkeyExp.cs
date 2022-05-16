
using System;
using Server.Network;

namespace Server.Items
{
    public class RoastTurkeyExp : BaseFood
    {
        [Constructable]
        public RoastTurkeyExp() : this(1) { }

        [Constructable]
        public RoastTurkeyExp(int amount)
            : base(amount, 0x9B7)
        {
            Name = "Roast Turkey";
            Weight = 1.0;
            FillFactor = 8;
        }

        public RoastTurkeyExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
