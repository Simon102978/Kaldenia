using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
    public class RawFlukeSteak : BaseFood
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawFlukeSteak() : this(1) { }

        [Constructable]
        public RawFlukeSteak(int amount)
            : base(amount, 0x097A)
        {
            this.Stackable = true;
            this.Amount = amount;
            this.Name = "Raw Fluke Steak";
            this.Raw = true;
        }

        public RawFlukeSteak(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}