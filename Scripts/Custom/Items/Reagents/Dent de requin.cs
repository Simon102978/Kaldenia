using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DentRequin : BaseReagent
    {
        [Constructable]
        public DentRequin() : this(1)
        {
        }

        [Constructable]
        public DentRequin(int amount) : base(0xF89, amount)
        {
            Hue = 2061;
            Name = "dent de requin";
        }

        public DentRequin(Serial serial) : base(serial)
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