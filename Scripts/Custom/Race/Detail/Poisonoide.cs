using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Histrions : BaseRace
        {

		public override string Background => "Les Histrions sont de brillants individus et sans doute également les êtres les plus attentionnés au sein des vastes landes de Profania. Ils sont de plus excessivement adroits et expérimentés dans le maniement des forces ésotériques et spirituelles, et ce sont probablement les plus aptes à user de la magie blanche à l'intérieur de ce monde. Ce sont des êtres de lumières; le mal a peine à les convertir.L'eau est leur refuge, et la terre est leur moyen de contact avec les autres peuples. Depuis l'aube de leur avènement au sein de la Terre d'Exil, les Histrions ont l'immense privilège de résider dans la plus féerique et somptueuse cité que tout voyageur digne de ce nom souhaite visiter un jour ou l'autre de son existence. Leur peau bleutée est douce comme la soie et leur silhouette élancée leur permet un déplacement agile et aisé dans l'eau.";

		public override int[] SkinHues => new int[] { 1755, 1756, 1758, 1759 };

		//  public override Type Skin => typeof(CorpsHistrions);

		public override int GumpId => 52088;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsHistrions) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Histrions(8, 8));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Histrions(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Histrions", "Histrions", 400, 401, 402, 403)
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
    public class CorpsHistrions : BaseRaceGumps
    {
        [Constructable]
        public CorpsHistrions()
            : this(0)
        {
        }

        [Constructable]
        public CorpsHistrions(int hue)
            : base(41507, hue)
        {
            Name = "Histrions";
        }

        public CorpsHistrions(Serial serial)
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
            Name = "Histrions";
        }
    }
}

