using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Karge : BaseRace
        {

		public override string Background => "Avez-vous vu les grands marais d’Elindas ? Peu de gens ont eu la chance de les d??#$?&*couvrir à la suite de la chute de son peuple. \n\nLes Karges sont reconnus comme ??#$?&*tant de grands prodiges ayant d??#$?&*di??#$?&* leur vie à la recherche de r??#$?&*ponse aux questionnements interdits. Bien que curieux de nature, ils furent avares d'informations et les dieux d??#$?&*cidèrent de leur donner une leçon: Un volcan en ??#$?&*ruption tout près de leur village! \n\nLeurs yeux furent brûl??#$?&*s par les nuages de cendre alors que de gigantesques boules de feu tombèrent du ciel. La poussière grise s’unifia à leurs iris; ??#$?&*tait-ce la mal??#$?&*diction des dieux ou encore une b??#$?&*n??#$?&*diction? Car contre toute attente, celà leur donna des visions… \n\nPassionn??#$?&*s, les Karges ont pour but principal de poser la dernière pièce du casse-tête afin de pr??#$?&*dire l’impr??#$?&*visible… Une fameuse histoire d’Alverton raconte qu’un Karge aurait d??#$?&*jà ??#$?&*t??#$?&* vu peindre pendant plus de trois jours sans s’arrêter. Une fois termin??#$?&*e, la toile aurait annonc??#$?&* l’assassinat d’une fillette. \n\nTrès m??#$?&*ticuleux, les Karges sont capables de trouver une aiguille dans une botte de foin. Aptes à r??#$?&*soudre les ??#$?&*nigmes les plus complexes, ils sont souvent redout??#$?&*s par la populace. On dit d'ailleurs qu’ils font les meilleurs enquêteurs. \n\nExcellents arcanistes, ils ont su lever le voile sur les mystères de la magie et sont les plus dou??#$?&*s dans le domaine. Ils ont cependant dû payer le prix fort pour obtenir leurs sortilèges: Une partie de leur ‘’Kaldenisme’’. Leur reste-t-il encore un peu de sanit??#$?&* ou sont-ils complètement perdus dans le cosmos du flux magique? \n\n??#$?&*nigmatiques personnages, les Karges ont tendance à porter des vêtements qui causent une certaine controverse. Leurs principales couleurs sont le gris et le mauve. \n\nCe peuple est amoureux de tout ce qui a trait à leur divinit??#$?&*. Il faut partager les mêmes croyances afin de s’associer avec eux, sans quoi ce sera presque impossible… Puisqu’ils sont s??#$?&*duits par la folie, ils peuvent parfois faire une exception. Il n’est pas rare d’entendre les Karges se parler tout seuls. Serait-ce la d??#$?&*mence ou encore une discussion qu’ils entretiennent avec leur dieu? \n\nLe langage Karge est assez bizarre et ils ont tendance à user de m??#$?&*taphores. Leur dialecte est directement influenc??#$?&* par leur croyance religieuse. Ainsi, un Karge de Quirel aura un ton plutôt joyeux, alors qu’un Karge de Zox aura un discours plus sombre. \n\nInspiration – Thrace et Malkavian";

		public override int[] SkinHues => new int[] { 1103, 2101, 911, 1105, 976, 2102, 1000, 1102 };

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
               RegisterRace(new Karge(4,4));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

        public Karge(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Karge", "Karges", 400, 401, 402, 403)
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
				case 1103:
					itemId = 41509;
					break;
				case 2101:
					itemId = 41509;
					break;
				case 911:
					itemId = 41505;
					break;
				case 1105:
					itemId = 41505;
					break;
				case 976:
					itemId = 41503;
					break;
				case 2102:
					itemId = 41503;
					break;
				case 1000:
					itemId = 41504; //
					break;
				case 1102:
					itemId = 41504;
					break;
				default:
					break;
			}
			return new CorpsKarge(itemId, hue);
		}

		public override int GetGump(bool female, int hue)
		{
			int gumpid = 52090;

			switch (hue)
			{
				case 1103:
					gumpid = 52090;
					break;
				case 2101:
					gumpid = 52090;
					break;
				case 911:
					gumpid = 52086;
					break;
				case 1105:
					gumpid = 52086;
					break;
				case 976:
					gumpid = 52084;
					break;
				case 2102:
					gumpid = 52084;
					break;
				case 1000:
					gumpid = 52085; //
					break;
				case 1102:
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
    public class CorpsKarge : BaseRaceGumps
    {
        [Constructable]
        public CorpsKarge()
            : this(0)
        {
        }

        [Constructable]
        public CorpsKarge(int Id, int hue)
            : base(Id, hue)
        {
            Name = "Karge";
        }

        public CorpsKarge(Serial serial)
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

