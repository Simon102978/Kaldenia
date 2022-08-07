using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Kuya : BaseRace
        {

		public override string Background => "";
		 
		public override int[] SkinHues => new int[] { 1118, 1122, 1119, 1123, 1120, 1124, 1121, 1125 };

		//2102
		
        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Kuya(5,5));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

        public Kuya(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Kuya", "Kuyas", 400, 401, 402, 403)
            {
            }


        public override bool ValidateEquipment(Item item)
            {
            return true;
            }

		public override BaseRaceGumps GetCorps(int hue)
		{
			int itemId = 41509;

			switch (hue)
			{
				case 1118:
					itemId = 41509;
					break;
				case 1122:
					itemId = 41509;
					break;
				case 1119:
					itemId = 41505;
					break;
				case 1123:
					itemId = 41505;
					break;
				case 1120:
					itemId = 41503;
					break;
				case 1124:
					itemId = 41503;
					break;
				case 1121:
					itemId = 41504; //
					break;
				case 1125:
					itemId = 41504;
					break;
				default:
					break;
			}
			return new CorpsKuya(itemId, hue);
		}

		public override int GetGump(bool female, int hue)
		{
			int gumpid = 52090;

			switch (hue)
			{
				case 1118:
					gumpid = 52090;
					break;
				case 1122:
					gumpid = 52090;
					break;
				case 1119:
					gumpid = 52086;
					break;
				case 1123:
					gumpid = 52086;
					break;
				case 1120:
					gumpid = 52084;
					break;
				case 1124:
					gumpid = 52084;
					break;
				case 1121:
					gumpid = 52085; //
					break;
				case 1125:
					gumpid = 52085;
					break;
				default:
					break;
			}

			if (female)
			{
				gumpid += 10000;
			}

			return gumpid;
		}



	}

    
    
}

namespace Server.Items
{
    public class CorpsKuya : BaseRaceGumps
    {
        [Constructable]
        public CorpsKuya()
            : this(0)
        {
        }

        [Constructable]
        public CorpsKuya(int Id, int hue)
            : base(Id, hue)
        {
            Name = "Kuya";
        }

        public CorpsKuya(Serial serial)
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
           
        }
    }
}

