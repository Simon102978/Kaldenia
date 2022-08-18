using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CerveauLiche : BaseReagent
    {
        [Constructable]
        public CerveauLiche() : this(1)
        {
        }

        [Constructable]
        public CerveauLiche(int amount) : base(0x1CF0, amount)
        {
            Hue = 1648;
            Name = "cerveau de liche";
			Stackable = false;
        }

        public CerveauLiche(Serial serial) : base(serial)
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