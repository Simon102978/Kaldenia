using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class VeninAraigneeGeante : BaseReagent
    {
        [Constructable]
        public VeninAraigneeGeante() : this(1)
        {
        }

        [Constructable]
        public VeninAraigneeGeante(int amount) : base(0xF82, amount)
        {
            Hue = 1412;
            Name = "venin d'araignée géante";
        }

        public VeninAraigneeGeante(Serial serial) : base(serial)
        {
        }

        

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                case 0: break;
            }

            if (version < 1)
                Delete();
        }
    }
}