
using System;
using Server.Network;

namespace Server.Items
{
    public class RawBirdExp : BaseFood
    {
        [Constructable]
        public RawBirdExp() : this(1) { }

        [Constructable]
        public RawBirdExp(int amount)
            : base(amount, 0x9B9)
        {
            Stackable = true;
            Amount = amount;
            Raw = true;
        }

        public RawBirdExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
