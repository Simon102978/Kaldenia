using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class VeninAraigneeNoire : BaseReagent
    {
        [Constructable]
        public VeninAraigneeNoire() : this(1)
        {
        }

        [Constructable]
        public VeninAraigneeNoire(int amount) : base(0xF82, amount)
        {
            Hue = 1415;
            Name = "venin d'araignée noire";
        }

        public VeninAraigneeNoire(Serial serial) : base(serial)
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