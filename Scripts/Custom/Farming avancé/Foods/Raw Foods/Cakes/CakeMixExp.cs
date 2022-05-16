using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
    public class CakeMixExp : BaseFood
    {
        public override int LabelNumber { get { return 1041002; } }

        [Constructable]
        public CakeMixExp()
            : base( 0x103F, 40)
        {
            this.Weight = 1.0;
        }

        public CakeMixExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
