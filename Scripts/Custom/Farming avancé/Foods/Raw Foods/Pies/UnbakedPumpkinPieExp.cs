
using System;
using Server.Network;

namespace Server.Items
{
    public class UnbakedPumpkinPieExp : BaseFood
    {
        public override int LabelNumber { get { return 1041342; } }

        [Constructable]
        public UnbakedPumpkinPieExp()
            : base(0x1042)
        {
        }

        public UnbakedPumpkinPieExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
