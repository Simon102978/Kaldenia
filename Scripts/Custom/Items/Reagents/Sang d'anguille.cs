using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SangAnguille : BaseReagent
    {
        [Constructable]
        public SangAnguille() : this(1)
        {
        }

        [Constructable]
        public SangAnguille(int amount) : base(0xF82, amount)
        {
            Hue = 1323;
            Name = "sang d'anguille";
        }

        public SangAnguille(Serial serial) : base(serial)
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