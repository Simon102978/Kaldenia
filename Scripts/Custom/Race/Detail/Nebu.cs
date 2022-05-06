using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Spanius : BaseRace
        {

		public override string Background => "L'excentrique et insouciant peuple des Spanius constitue une race désopilante qui apprécie l'alcool et les fêtes poursuivies de combats dans leur illustre arène. C'est également l'un des peuples les plus convoités par les bardes puisque les Spanius sont, de toute évidence, de très grands amateurs de musique. Outre cela, ils chérissent immensément la liberté et la majorité d'entre eux passe le plus clair de leur temps dans les tavernes à appâter le sexe opposé. Leur mentalité visant la liberté quasi-absolue, il n'est pas rare de voir des brigands et des voleurs parmi ce peuple. On raconte même que de grands regroupement de bandits y trouvent leurs chefs. Le simple fait d'être Spanius aide donc beaucoup à entrer dans ces groupes.La mafia, connue presque mondialement, fait partie de leur quotidien, au même titre que l'alcool et la musique. Bien que d'heureux fêtards, ils sont aussi capable de manigances des plus sérieuses ! La capacité de faire du vin est aussi une chose pratiquement innée chez un Spanius, un célèbre proverbe Spanius le témoigne : \" Le meilleur biberon pour un bébé est certainement une bouteille de vin ! \".";

		public override int[] SkinHues => new int[] { 825, 815, 819, 817 };

		//  public override Type Skin => typeof(CorpsSpanius);

		public override int GumpId => 52083;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsSpanius) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Spanius(3, 3));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Spanius(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Spanius", "Spanius", 400, 401, 402, 403)
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
    public class CorpsSpanius : BaseRaceGumps
    {
        [Constructable]
        public CorpsSpanius()
            : this(0)
        {
        }

        [Constructable]
        public CorpsSpanius(int hue)
            : base(41502, hue)
        {
            Name = "Spanius";
        }

        public CorpsSpanius(Serial serial)
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
            Name = "Spanius";
        }
    }
}

