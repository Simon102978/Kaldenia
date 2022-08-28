using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class EcaillesSerpentGeant : BaseReagent
    {
        [Constructable]
        public EcaillesSerpentGeant() : this(1)
        {
        }

        [Constructable]
        public EcaillesSerpentGeant(int amount) : base(0x26B4, amount)
        {
            Name = "Écailles de serpent géant";
        }

        public EcaillesSerpentGeant(Serial serial) : base(serial)
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