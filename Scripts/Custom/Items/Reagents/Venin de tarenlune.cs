using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class VeninTarenlune : BaseReagent
    {
        [Constructable]
        public VeninTarenlune() : this(1)
        {
        }

        [Constructable]
        public VeninTarenlune(int amount) : base(0xF82, amount)
        {
            Hue = 1418;
            Name = "venin de tarenlune";
        }

        public VeninTarenlune(Serial serial) : base(serial)
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