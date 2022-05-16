using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
    public class RawFishSteakExp : BaseFood
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawFishSteakExp() : this(1) { }

        [Constructable]
        public RawFishSteakExp(int amount)
            : base(amount, 0x097A)
        {
            this.Stackable = true;
            this.Amount = amount;
        }

        public RawFishSteakExp(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
