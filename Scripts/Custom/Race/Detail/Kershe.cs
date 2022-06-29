using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 
        class Kershe : BaseRace
        {

		public override string Background => "L��ternel d�sert au sud de Kaldenia, dot� de myst%%%#$%?%$#@!res et d�une immense histoire, fait souvent r�f�rence au peuple des Kershes. \n\nUne nation reconnue pour son sens des affaires et sa grande vari�t� de d�lices exotiques. \n\nQuand on parle de marchands, de gitans et d�artistes, on fait souvent r�f�rence � ces gens qui ont de la facilit� � nous hypnotiser gr�ce � leurs belles paroles. Rarement vus comme de grands guerriers, ils cachent parfois des perles rares au combat. \n\nLes Kershes ont des armes insoup�onn�es� Leur influence, leurs armes perforantes, leurs connaissances de sortil%%%#$%?%$#@!ges ou m�me leur dialecte peut faire d�eux une ethnie redoutable � avoir comme adversaire. \n\nLes Kershes sont port�s sur le patriarcat et le respect des a�n�s. Si une famille s��l%%%#$%?%$#@!ve gr�ce � l�influence et le prestige de l�ain� masculin, cela voudra dire qu�il a r�ussi son devoir patriarcal. \n\nAyant travaill� tr%%%#$%?%$#@!s fort sur leur image et ayant connu un succ%%%#$%?%$#@!s subs�quent, il est hors de question pour les Kershe de retourner bas de l��chelle. Il vaut mieux mourir avec honneur et avec du c�ur au ventre que de retrouver la mis%%%#$%?%$#@!re� \n\nArnaquer ou manquer de respect � un Kershe est une des pires insultes que vous pouvez lui faire... Il se sentira diminu� au niveau d�esclave. \n\nHabitu�s � voyager en caravane sur de longues distances, les Kershes pr�f%%%#$%?%$#@!rent arborer des tenues aux couleurs du soleil ou de la lune; Le noir et le beige �tant des couleurs contrastantes souvent port�es par ces marchands du sud. \n\nLes Kershes sont le seul peuple orient� vers l�union monogame. Lorsque le mariage �choue, l�image publique se retrouve ruin�e et le d�shonneur vient entacher la famille. \n\nL��ternel conflit des Kershes: Vaut-il mieux �tre dans les gr�ces de Quirel, ou �viter les malheurs de Zox? Difficile de dire si ce qu�ils font est totalement bon ou mauvais. Apr%%%#$%?%$#@!s tout, qui voudrait confronter les dieux? \n\nLe langage Kershe fait d�eux une race tr%%%#$%?%$#@!s exotique. Dans les bazars, on entend souvent rouler les R comme un lointain accent sudiste. Alors que le commun des mortels dira ��cadre�� le Kershe dira plut�t cadrrre. \n\nInspiration � Arabe - Gitan";

		public override int[] SkinHues => new int[] { 1011, 1014, 1037, 1041, 1038, 1042, 1036, 1043 };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Kershe(3,3));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

        public Kershe(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Kershe", "Kershes", 400, 401, 402, 403)
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
				case 1011:
					itemId = 41509;
					break;
				case 1014:
					itemId = 41509;
					break;
				case 1037:
					itemId = 41505;
					break;
				case 1041:
					itemId = 41505;
					break;
				case 1038:
					itemId = 41503;
					break;
				case 1042:
					itemId = 41503;
					break;
				case 1036:
					itemId = 41504; //
					break;
				case 1043:
					itemId = 41504;
					break;
				default:
					break;
			}
			return new CorpsKershe(itemId, hue);
		}

		public override int GetGump(bool female, int hue)
		{
			int gumpid = 52090;

			switch (hue)
			{
				case 1011:
					gumpid = 52090;
					break;
				case 1014:
					gumpid = 52090;
					break;
				case 1037:
					gumpid = 52086;
					break;
				case 1041:
					gumpid = 52086;
					break;
				case 1038:
					gumpid = 52084;
					break;
				case 1042:
					gumpid = 52084;
					break;
				case 1036:
					gumpid = 52085; //
					break;
				case 1043:
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
    public class CorpsKershe : BaseRaceGumps
    {
        [Constructable]
        public CorpsKershe()
            : this(0)
        {
        }

        [Constructable]
        public CorpsKershe(int Id, int hue)
            : base(Id, hue)
        {
            Name = "Kershe";
        }

        public CorpsKershe(Serial serial)
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

