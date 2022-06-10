/*using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Engines.ArenaSystem
{

    public class ArenaStone : Item
    {
        public override bool ForceShowProperties => true;
        public override int LabelNumber => 1115878;

        [CommandProperty(AccessLevel.GameMaster)]
        public PVPArena Arena { get; set; }

     

        [Constructable]
        public ArenaStone(PVPArena arena)
            : base(0xEDD)
        {
            Arena = arena;

            Movable = false;
            Hue = 1194;
        }



        public ArenaStone(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

			Delete();
        }
    }
}*/