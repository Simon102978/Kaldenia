using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PlumesAigle : BaseReagent
    {
        [Constructable]
        public PlumesAigle() : this(1)
        {
        }

        [Constructable]
        public PlumesAigle(int amount) : base(0x1021, amount)
        {
            Name = "plumes d'aigle";
        }

        public PlumesAigle(Serial serial) : base(serial)
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