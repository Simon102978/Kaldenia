using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Insectoide : BaseRace
        {

		public override string Background => "À venir.";

		public override int[] SkinHues => new int[] { 776, 771, 769, 766 };

		//  public override Type Skin => typeof(CorpsInsectoides);

		public override int GumpId => 52087;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsInsectoides) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Insectoide(7, 7));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Insectoide(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Insectoide", "Insectoides", 400, 401, 402, 403)
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
    public class CorpsInsectoides : BaseRaceGumps
    {
        [Constructable]
        public CorpsInsectoides()
            : this(0)
        {
        }

        [Constructable]
        public CorpsInsectoides(int hue)
            : base(41506, hue)
        {
            Name = "Insectoide";
        }

        public CorpsInsectoides(Serial serial)
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
            Name = "Insectoide";
        }
    }
}

