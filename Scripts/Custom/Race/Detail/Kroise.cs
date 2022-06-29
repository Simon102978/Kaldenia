using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Kalois : BaseRace
        {

		public override string Background => "Les Kalois sont reconnus comme de fiers guerriers superstitieux. Il n’est pas rare qu’ils fassent entendre des rires tonitruants près d’un feu gigantesque, des chants venant du cœur ou encore des cris de guerre qui retentissent dans tout le village. \n\nPour ce peuple, le respect se gagne par la confrontation.Bien qu’ils adorent se défier sur tous les aspects, ils restent toutefois très vertueux et ont une immense considération pour la camaraderie. \n\nLes Kalois sont turbulents… Ils aiment grouiller, crier et faire bouger les choses comme s’il n’y avait pas de lendemain. Les histoires racontent que les plus jeunes Kalois prennent un malin plaisir à essayer de défier l’autorité en place espérant devenir les chefs de demain. \n\nLa défaite au combat, dans un duel de talents ou même dans une course à la séduction ne fait pas de vous un perdant. Le Kalois qui a perdu apprendra et grandira avant ses prochaines tentatives de confrontation. Perdre n’est pas vu comme un échec, mais comme une leçon de vie. \n\nHabitués à travailler dans les champs comme des fermiers, les Kalois ont tendance à porter des vêtements plus organiques et pratiques pour effectuer du travail acharné. Les couleurs favorisées sont le vert et le brun, telle la terre mère. \n\nQu’en est-il de l’amour chez les Kalois ? En fait, il se doit d’être mérité! Déclarer son amour est une chose, mais le prouver en est une autre… Il n’est pas rare de voir des Kalois adolescents profiter des avantages de la jeunesse pour impressionner un(e) partenaire potentiel(le). \n\nAlors que regarder quelqu’un se saouler à mort peut sembler séduisant pour certain(e) s, des approches plus sérieuses sont souvent privilégiées, comme par exemple: Résister au courant de la mer pendant deux heures. \n\nUne fois leur amour prouvé, les Kalois peuvent se livrer aux plus désirables fantasmes de leur existence. \n\nAthées? Jamais de la vie! Les Kalois craignent beaucoup trop que le ciel leur tombe sur la tête s’ils offensent une des cinq divinités de Kaldenia. Quand on parle de superstition! \n\nLe langage Kalois est souvent associé à des cris, des croassements et même des hurlements! Leur expérience de vie quotidienne se faisant principalement dans la forêt, se peut-il qu’ils tentent de faire ressortir ce qu’ils sont réellement? La rumeur veut que leurs ancêtres soient en fait … des bêtes nocturnes..! \n\nInspiration – Celtic / Viking";

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
               RegisterRace(new Kalois(2,2));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

        public Kalois(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Kalois", "Kaloiss", 400, 401, 402, 403)
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
			return new CorpsKalois(itemId, hue);
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
    public class CorpsKalois : BaseRaceGumps
    {
        [Constructable]
        public CorpsKalois()
            : this(0)
        {
        }

        [Constructable]
        public CorpsKalois(int Id, int hue)
            : base(Id, hue)
        {
            Name = "Kalois";
        }

        public CorpsKalois(Serial serial)
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

