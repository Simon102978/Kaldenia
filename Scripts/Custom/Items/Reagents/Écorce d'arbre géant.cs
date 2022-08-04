using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class EcorceArbreGeant : BaseReagent
    {
        [Constructable]
        public EcorceArbreGeant() : this(1)
        {
        }

        [Constructable]
        public EcorceArbreGeant(int amount) : base(0xF7C, amount)
        {
            Hue = 1802;
            Name = "�corce d'arbre g�ant";
        }

        public EcorceArbreGeant(Serial serial) : base(serial)
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