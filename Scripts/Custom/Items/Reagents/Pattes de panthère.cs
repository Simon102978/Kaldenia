using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PattesPanthere : BaseReagent
    {
        [Constructable]
        public PattesPanthere() : this(1)
        {
        }

        [Constructable]
        public PattesPanthere(int amount) : base(0x1E8C, amount)
        {
            Hue = 1107;
            Name = "pattes de panthère";
			Stackable = false;
		}

        public PattesPanthere(Serial serial) : base(serial)
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