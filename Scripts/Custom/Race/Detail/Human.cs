using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Human : BaseRace
        {

		public override string Background => "Les humains sont les individus les plus égocentriques dans ce vaste univers, en plus de convoiter le pouvoir plus que quiconque. Rares sont d'ailleurs ceux qui pourraient les surpasser dans leur égoïsme sans borne.Ils disposent d'autre part du plus gros territoire du continent en plus de la plus prospère de toutes les cités. C'est une société hiérarchique, diversifiée et bien entendu dominante, elle constitue de ce fait l'empire le plus influent. La grandeur et l'immensité est le prérequis idéal dans la mentalité d'un Landolor.La titanesque taille de l'Armée Rouge (Nom donné aux forces militaires humaines) témoigne bien de ce fait, recouvrant à elle seule près de deux fois plus de superficie que leur opposant militaire ennemis (les Orchilions). Grand territoire certes, mais étant divisé en plusieurs provinces, celui-ci n'agit pas toujours en tant qu'unité et les rivalités inter-raciales sont plus que souvent rencontrées, nobles se chamaillant des terres, surtaxant leurs paysans et créant des levées de milice qui sont bien rapidement réduites à néant par la taille de leur armée plus que grandissante.";

		public override int[] SkinHues => new int[] { 1009, 1011, 1014, 1016 };

		//  public override Type Skin => typeof(CorpsElfeNoir);

		public override int GumpId => 52090;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsHuman) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Human(0,0));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Human(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Human", "Humans", 400, 401, 402, 403)
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
    public class CorpsHuman : BaseRaceGumps
    {
        [Constructable]
        public CorpsHuman()
            : this(0)
        {
        }

        [Constructable]
        public CorpsHuman(int hue)
            : base(41509, hue)
        {
            Name = "Humain";
        }

        public CorpsHuman(Serial serial)
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
            Name = "Humain";
        }
    }
}

