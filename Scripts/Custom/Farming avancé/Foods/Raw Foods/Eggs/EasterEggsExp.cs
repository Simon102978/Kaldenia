using System;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class EasterEggsExp : BaseFood
    {
        public override int LabelNumber { get { return 1016105; } }

        [Constructable]
        public EasterEggsExp() : this(1) { }

        [Constructable]
        public EasterEggsExp(int amount)
            : base(amount, 0x9B5)
        {
            Stackable = true;
            Amount = amount;
            Weight = 0.5;
            Hue = 3 + (Utility.Random(20) * 5);
        }

        public EasterEggsExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
