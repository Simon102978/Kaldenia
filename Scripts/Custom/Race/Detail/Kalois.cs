using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Kroise : BaseRace
        {

		public override string Background => "Ils sont reconnus comme étant de fiers marins ayant bravé moult tempêtes. C’est ainsi que les Kroises amènent contes et légendes aux gens des terres. On dit qu’ils ont vécu des histoires plus farfelues les unes que les autres! \n\nQuand on parle de personnes ayant navigué jusque dans les recoins les plus obscurs de ce monde, on pense tout de suite %%%#$%?%$#@! eux! \n\nFriands de mythes et de légendes, ils écoutent volontiers les histoires qui parlent d’or, de bête %%%#$%?%$#@! occire ou même d’aventures intimes ayant mal tourné! Par-dessus tout, ils adorent le jeu et il n’est pas rare de croiser de grands marins kroises dans les tavernes pour jouer une partie de dés ou de cartes. \n\nCôté habillement, les vêtements clairs représentent leur transparence. Le blanc et le bleu, rappelant la mer et les voiles des bateaux, sont souvent mis de l’avant. \n\nL’amour chez les Kroises n’a rien de conventionnel, libertins, ils peuvent aimer le côté militaire d’une personne et l’aspect culturel d’une autre. Cela fait d’eux un peuple très ouvert sur les relations libres. Le mariage n'est pas vraiment une option, car ils se sentiraient trop restreints. \n\nBien que tous les peuples soient polythéistes, les Kroises adhèrent principalement au culte de Seras. Malgré le chaos qu’il sème, l’anarchiste serpent est sans doute la représentation ultime de la liberté. \n\nLe “K” est très prononcé dans la langue kroise. Le “C” est rarement utilisé, quoi que certains se sont habitués au langage commun, il est souvent remplacé par le “K”; Un chien deviendra alors un Khien, une corde deviendra alors une Korde. Est-ce seulement un accent prononcé ou est-ce une nouvelle manière de dialoguer ? \n\nInspiration – Grec et Pirate Renaissance";

		public override int[] SkinHues => new int[] { 1823, 1820, 1824, 1821, 1819, 1825, 1822, 1826 };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Kroise(1,1));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

        public Kroise(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Kroise", "Kroises", 400, 401, 402, 403)
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
				case 1823:
					itemId = 41509;
					break;
				case 1820:
					itemId = 41509;
					break;
				case 1824:
					itemId = 41505;
					break;
				case 1821:
					itemId = 41505;
					break;
				case 1819:
					itemId = 41503;
					break;
				case 1825:
					itemId = 41503;
					break;
				case 1822:
					itemId = 41504; //
					break;
				case 1826:
					itemId = 41504;
					break;
				default:
					break;
			}
			return new CorpsKroise(itemId, hue);
		}

		public override int GetGump(bool female, int hue)
		{
			int gumpid = 52090;

			switch (hue)
			{
				case 1823:
					gumpid = 52090;
					break;
				case 1820:
					gumpid = 52090;
					break;
				case 1824:
					gumpid = 52086;
					break;
				case 1821:
					gumpid = 52086;
					break;
				case 1819:
					gumpid = 52084;
					break;
				case 1825:
					gumpid = 52084;
					break;
				case 1822:
					gumpid = 52085; //
					break;
				case 1826:
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
    public class CorpsKroise : BaseRaceGumps
    {
        [Constructable]
        public CorpsKroise()
            : this(0)
        {
        }

        [Constructable]
        public CorpsKroise(int Id, int hue)
            : base(Id, hue)
        {
            Name = "Kroise";
        }

        public CorpsKroise(Serial serial)
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

