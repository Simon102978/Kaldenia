using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class EcaillesWyrm : BaseReagent
    {
        [Constructable]
        public EcaillesWyrm() : this(1)
        {
        }

        [Constructable]
        public EcaillesWyrm(int amount) : base(0x26B3, amount)
        {
            Name = "écailles de wyrm";
        }

        public EcaillesWyrm(Serial serial) : base(serial)
        {
        }

      

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}