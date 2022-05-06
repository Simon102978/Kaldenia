using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Uruk : BaseRace
        {

		public override string Background => "Histoire : Peuple tribal du centre du monde à l'histoire lié aux guerres contre les voisins.\n\n Nations d'origines : De trop nombreux clans sont présent pour être listé. Mais ils forment en temps nécessaire la \"Horde\". \n\nGénéralité : Leur société a toujours été régit par la fUruke brute.Le plus fort dirige point final.Les rares magiciens sont quand à eux des conseillers prisés par les chefs.Ce sont eux qui ont l'intelligence chez les Uruk. \n\n Particularité : Moche, idiot, fort comme des bœufs... De vrais machines de combat.Ils sont aussi misogyne mis une femme peut arriver à se faire une place si elle met de bonnes claques.";

		public override int[] SkinHues => new int[] { 901, 884, 866, 871 };

		//  public override Type Skin => typeof(CorpsUruks);

		public override int GumpId => 52082;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsUruks) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Uruk(2, 2));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Uruk(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Uruk", "Uruks", 400, 401, 402, 403)
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
    public class CorpsUruks : BaseRaceGumps
    {
        [Constructable]
        public CorpsUruks()
            : this(0)
        {
        }

        [Constructable]
        public CorpsUruks(int hue)
            : base(41501, hue)
        {
            Name = "Uruk";
        }

        public CorpsUruks(Serial serial)
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
            Name = "Uruk";
        }
    }
}

