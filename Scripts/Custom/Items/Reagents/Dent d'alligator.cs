using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DentAlligator : BaseReagent
    {
        [Constructable]
        public DentAlligator() : this(1)
        {
        }

        [Constructable]
        public DentAlligator(int amount) : base(0xF89, amount)
        {
            Hue = 2042;
            Name = "dent d'alligator";
        }

        public DentAlligator(Serial serial) : base(serial)
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