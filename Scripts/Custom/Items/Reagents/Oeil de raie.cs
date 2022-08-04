using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class OeilRaie : BaseReagent
    {
        [Constructable]
        public OeilRaie() : this(1)
        {
        }

        [Constructable]
        public OeilRaie(int amount) : base(0xF87, amount)
        {
            Hue = 2009;
            Name = "oeil de raie";
        }

        public OeilRaie(Serial serial) : base(serial)
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