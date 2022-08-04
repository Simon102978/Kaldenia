using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CheveuxTroll : BaseReagent
    {
        [Constructable]
        public CheveuxTroll() : this(1)
        {
        }

        [Constructable]
        public CheveuxTroll(int amount) : base(0xF81, amount)
        {
            Hue = 1437;
            Name = "cheveux de troll";
        }

        public CheveuxTroll(Serial serial) : base(serial)
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