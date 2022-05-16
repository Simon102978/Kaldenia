
using System;
using Server.Network;

namespace Server.Items
{
    public class RoastChickenExp : BaseFood
    {
        [Constructable]
        public RoastChickenExp() : this(1) { }

        [Constructable]
        public RoastChickenExp(int amount)
            : base(amount, 0x9B7)
        {
            Name = "Roast Chicken";
            Weight = 1.0;
            FillFactor = 5;
        }

        public RoastChickenExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
