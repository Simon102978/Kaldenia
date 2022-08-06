using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PlumesSaliva : BaseReagent
    {
        [Constructable]
        public PlumesSaliva() : this(1)
        {
        }

        [Constructable]
        public PlumesSaliva(int amount) : base(0x1021, amount)
        {
            Hue = 0x11E;
            Name = "plumes de Saliva";
        }

        public PlumesSaliva(Serial serial) : base(serial)
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