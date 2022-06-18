using System;
using Server;

namespace Server.Items
{
    public class ToileVierge : Item
    {
		[Constructable]
        public ToileVierge() : this(1)
		{
		}

        [Constructable]
        public ToileVierge(int amount) : base(0x0F77)
        {
			

			Name = "toile vierge";
            Weight = 2.0;
        }

        public ToileVierge(Serial serial) : base(serial)
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