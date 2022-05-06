using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Spanius : BaseRace
        {

		public override string Background => "L'excentrique et insouciant peuple des Spanius constitue une race d�sopilante qui appr�cie l'alcool et les f�tes poursuivies de combats dans leur illustre ar�ne. C'est �galement l'un des peuples les plus convoit�s par les bardes puisque les Spanius sont, de toute �vidence, de tr�s grands amateurs de musique. Outre cela, ils ch�rissent immens�ment la libert� et la majorit� d'entre eux passe le plus clair de leur temps dans les tavernes � app�ter le sexe oppos�. Leur mentalit� visant la libert� quasi-absolue, il n'est pas rare de voir des brigands et des voleurs parmi ce peuple. On raconte m�me que de grands regroupement de bandits y trouvent leurs chefs. Le simple fait d'�tre Spanius aide donc beaucoup � entrer dans ces groupes.La mafia, connue presque mondialement, fait partie de leur quotidien, au m�me titre que l'alcool et la musique. Bien que d'heureux f�tards, ils sont aussi capable de manigances des plus s�rieuses ! La capacit� de faire du vin est aussi une chose pratiquement inn�e chez un Spanius, un c�l�bre proverbe Spanius le t�moigne : \" Le meilleur biberon pour un b�b� est certainement une bouteille de vin ! \".";

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

