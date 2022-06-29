using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
	
        class Korain : BaseRace
        {

		public override string Background => "Tr%%%#$%?%$#@!s grands conquérants, ils ont su générer une économie florissante sur les territoires qu’ils ont capturés. Les Korains ont parfois même amené la science à des peuples primitifs.\n\nRéputés pour leur savoir militaire étendu et leur gigantesque armée, ils se démarquent aussi de par les grandes richesses qu’ils détiennent. \n\nLes Korains sont théâtraux et il est commun qu’un souper, une cérémonie ou même un combat soit agrémenté d’une pri%%%#$%?%$#@!re ou d’une offrande aux dieux. \n\nAimant recevoir de l’attention, ils ont tendance à porter des vêtements aux couleurs explosives. Le rouge et le doré leur sont souvent associés; Ces teintes faisant référence aux richesses obtenues par le sang. \n\nEst-ce que l’amour avec un grand A est possible chez les Korains ? La plupart se marient par ambitions ou pour affaires personnelles. Des carri%%%#$%?%$#@!res militaires ou politiques sont fréquemment financées en échange d’une union qui permet à l’un des partis d’élever son statut social. Attention! Cela ne veut pas dire qu’ils sont fid%%%#$%?%$#@!les pour autant. Chaque possibilité d’avancement doit être considérée, et ce sans aucune limite. Des petits secrets n’ont jamais fait de mal à personne..! \n\nBien que polythéistes, la plupart des Korains croient fermement que Greald, la divinité de la discipline sera la clé de leur succ%%%#$%?%$#@!s. Ils sont appréciateurs de dogmes stricts, un peu à l’image de leur Empire. \n\nLe langage impérial commun, imposé aux autres ethnies, est le plus souvent utilisé. Si tous peuvent s’entendre sur une même langue, l’Empire aura réussi là où une ethnie indépendante a échoué. Les Korains sont donc réguli%%%#$%?%$#@!rement outrés lorsque confrontés à un dialecte étrangé. \n\nInspiration de la race – Les Romains";

		public override int[] SkinHues => new int[] { 1009, 1016, 1010, 1017, 1008, 1018, 1015, 1019 };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Korain(0,0));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

        public Korain(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Korain", "Korains", 400, 401, 402, 403)
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
				case 1009:
					itemId = 41509;
					break;
				case 1016:
					itemId = 41509;
					break;
				case 1010:
					itemId = 41505;
					break;
				case 1017:
					itemId = 41505;
					break;
				case 1008:
					itemId = 41503;
					break;
				case 1018:
					itemId = 41503;
					break;
				case 1015:
					itemId = 41504; //
					break;
				case 1019:
					itemId = 41504;
					break;
				default:
					break;
			}
			return new CorpsKorain(itemId, hue);
		}

		public override int GetGump(bool female, int hue)
		{
			int gumpid = 52090;

			switch (hue)
			{
				case 1009:
					gumpid = 52090;
					break;
				case 1016:
					gumpid = 52090;
					break;
				case 1010:
					gumpid = 52086;
					break;
				case 1017:
					gumpid = 52086;
					break;
				case 1008:
					gumpid = 52084;
					break;
				case 1018:
					gumpid = 52084;
					break;
				case 1015:
					gumpid = 52085; //
					break;
				case 1019:
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
    public class CorpsKorain : BaseRaceGumps
    {
        [Constructable]
        public CorpsKorain()
            : this(0)
        {
        }

        [Constructable]
        public CorpsKorain(int Id, int hue)
            : base(Id, hue)
        {
            Name = "Korain";
        }

        public CorpsKorain(Serial serial)
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

