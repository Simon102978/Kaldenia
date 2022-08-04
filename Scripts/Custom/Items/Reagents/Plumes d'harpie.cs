using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PlumesHarpie : BaseReagent
    {
        [Constructable]
        public PlumesHarpie() : this(1)
        {
        }

        [Constructable]
        public PlumesHarpie(int amount) : base(0x1021, amount)
        {
            Hue = 1721;
            Name = "plumes d'harpie";
        }

        public PlumesHarpie(Serial serial) : base(serial)
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