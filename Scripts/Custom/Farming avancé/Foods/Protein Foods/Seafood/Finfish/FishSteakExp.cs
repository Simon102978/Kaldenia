
using System;
using Server.Network;

namespace Server.Items
{
    public class FishSteakExp : BaseFood
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public FishSteakExp() : this(1) { }

        [Constructable]
        public FishSteakExp(int amount)
            : base(amount, 0x97B)
        {
            this.FillFactor = 3;
        }

        public FishSteakExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
