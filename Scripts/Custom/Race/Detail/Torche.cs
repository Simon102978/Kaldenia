using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Torche : BaseRace
        {

		public override string Background => "À venir.";

		public override int[] SkinHues => new int[] { 1632, 1635, 1773, 1775 };

		public override int GumpId => 52089;

		//    public override Type Skin => typeof(CorpsTorches);

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsTorches) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Torche(9, 9));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Torche(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Torche", "Torches", 400, 401, 402, 403)
            {
            }


            public override bool ValidateEquipment(Item item)
            {
            return true;
            }

  
    }

    
    
}

namespace Server.Items
{
    public class CorpsTorches : BaseRaceGumps
    {
        [Constructable]
        public CorpsTorches()
            : this(0)
        {
        }

        [Constructable]
        public CorpsTorches(int hue)
            : base(41508, hue)
        {
            Name = "Torche";
        }

        public CorpsTorches(Serial serial)
            : base(serial)
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
            Name = "Torche";
        }
    }
}

