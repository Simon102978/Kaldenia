using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class EcorceArbreMaudit : BaseReagent
    {
        [Constructable]
        public EcorceArbreMaudit() : this(1)
        {
        }

        [Constructable]
        public EcorceArbreMaudit(int amount) : base(0xF7C, amount)
        {
            Name = "écorce d'arbre maudit";
        }

        public EcorceArbreMaudit(Serial serial) : base(serial)
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