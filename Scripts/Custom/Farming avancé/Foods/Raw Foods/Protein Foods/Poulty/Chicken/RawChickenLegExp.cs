using System;
using Server.Network;

namespace Server.Items
{
    public class RawChickenLegExp : BaseFood
    {
        [Constructable]
        public RawChickenLegExp() : this(1) { }

        [Constructable]
        public RawChickenLegExp(int amount)
            : base(amount, 0x1607)
        {
            this.Stackable = true;
            this.Amount = amount;
            this.Raw = true;
        }

        public RawChickenLegExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
