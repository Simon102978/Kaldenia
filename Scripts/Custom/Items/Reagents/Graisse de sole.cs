using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class GraisseSole : BaseReagent
    {
        [Constructable]
        public GraisseSole() : this(1)
        {
        }

        [Constructable]
        public GraisseSole(int amount) : base(0xF82, amount)
        {
            Hue = 2114;
            Name = "graisse de sole";
        }

        public GraisseSole(Serial serial) : base(serial)
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