using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Orchilions : BaseRace
        {

		public override string Background => "Les Orchilions sont pourvus d'une force et d'une endurance sans borne. En revanche, leur savoir militaire leur donne bien des avantages, et ce, face à tous les autres peuples. Ils sont disciplinés et organisés, ce qui les rend redoutables. Leur peau blanche et saturée de cicatrices de toutes sortes les distinguent des autres races assez facilement. Ils ne sont pas fiers de leur peau, résultat d'un compromis avec le dieu Ashtérios qui leur donna leur force. Leur attirance vers le domaine militaire aura eu vite fait de transformer leur ville(Ragnarok) en véritable forteresse.On dit même qu'il y aurait eu la construction d'une prison d'où nul homme y étant enfermé pour l'éternité n'en sortit. Généralement, lorsque l'on se voit assigner à cette prison, il est hors de pensée de s'en évader. Même si la chance tournait et qu'un homme en sortirait, il serait malsain de sa part de s'en venter, car les Orchillions ne sont pas du genre à laisser un travail inachevé. Par contre, tout ceci aura eu vite fait de leur donner mauvaise réputation. Tout ceci leur apporte tout simplement ce qu'ils aiment le plus, la guerre.Alors, à quoi bon s'en priver ?";

		public override int[] SkinHues => new int[] { 0x835, 970, 0x3E8, 0x76B };

      //  public override Type Skin => typeof(CorpsOrchilions);

        public override List<Type> RaceGump => new List<Type>() { typeof(CorpsOrchilions) };

		public override int GumpId => 52084;

		public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Orchilions(4, 4));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Orchilions(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Orchilions", "Orchilionss", 400, 401, 402, 403)
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
    public class CorpsOrchilions : BaseRaceGumps
    {
        [Constructable]
        public CorpsOrchilions()
            : this(0)
        {
        }

        [Constructable]
        public CorpsOrchilions(int hue)
            : base(41503, hue)
        {
            Name = "Orchilions";
        }

        public CorpsOrchilions(Serial serial)
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
            Name = "Orchilions";
        }
    }
}

