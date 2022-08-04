using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PoudreCoquillages : BaseReagent
    {
        [Constructable]
        public PoudreCoquillages() : this(1)
        {
        }

        [Constructable]
        public PoudreCoquillages(int amount) : base(0xF83, amount)
        {
            Name = "poudre de coquillages";
        }

        public PoudreCoquillages(Serial serial) : base(serial)
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