using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CheveuxGeant : BaseReagent
    {
        [Constructable]
        public CheveuxGeant() : this(1)
        {
        }

        [Constructable]
        public CheveuxGeant(int amount) : base(0xF81, amount)
        {
            Name = "cheveux de géant";
        }

        public CheveuxGeant(Serial serial) : base(serial)
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