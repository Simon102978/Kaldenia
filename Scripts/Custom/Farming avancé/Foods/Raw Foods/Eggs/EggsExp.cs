using System;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class EggsExp : BaseFood
    {
        [Constructable]
        public EggsExp() : this(1) { }

        [Constructable]
        public EggsExp(int amount)
            : base(amount, 0x9B5)
        {
            this.Stackable = true;
            this.Amount = amount;
        }

        public EggsExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
