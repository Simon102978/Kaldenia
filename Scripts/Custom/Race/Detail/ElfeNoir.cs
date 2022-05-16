using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Noctarius : BaseRace
        {

		public override string Background => "Les Noctarius demeurent dans les catacombes et les secteurs obscurs de la planète. C'est d'ailleurs très exceptionnel de les surprendre à converser en compagnie d'un membre d'une autre race que la leur. Ils favorisent l'entrain parmi leur propre dynastie et préfèrent considérablement la magie noire et la nécromancie plutôt que tout autre forme de combat. Néanmoins, on peut également trouver de nombreux assassins parmi les Noctarius. Étant de nature vile et méchante, ces créatures sombres et malveillantes se sont établi le plus loin que l'on puisse en avoir le souvenir. Étant à l'époque à même le continent principal, le monde les détesta bien assez vite et leur parcelle de terre eu vite fait de prendre le large, formant ainsi une île, distincte. Ne sortant que très rarement de ces terres, les Noctarius ont eu tout le loisir nécessaire pour connaître et maîtriser la magie noire.";

		public override int[] SkinHues => new int[] { 971, 970, 967, 962 };

		//  public override Type Skin => typeof(CorpsElfeNoir);

		public override int GumpId => 52086;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsNoctarius) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Noctarius(6,6));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Noctarius(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Noctarius", "Noctariuss", 400, 401, 402, 403)
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
    public class CorpsNoctarius : BaseRaceGumps
    {
        [Constructable]
        public CorpsNoctarius()
            : this(0)
        {
        }

        [Constructable]
        public CorpsNoctarius(int hue)
            : base(41505, hue)
        {
            Name = "Noctarius";
        }

        public CorpsNoctarius(Serial serial)
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
            Name = "Noctarius";
        }
    }
}

