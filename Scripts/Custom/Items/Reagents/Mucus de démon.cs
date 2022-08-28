using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class MucusDemon : BaseReagent
    {
        [Constructable]
        public MucusDemon() : this(1)
        {
        }

        [Constructable]
        public MucusDemon(int amount) : base(0xF82, amount)
        {
            Hue = 1631;
            Name = "mucus de démon";
        }

        public MucusDemon(Serial serial) : base(serial)
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