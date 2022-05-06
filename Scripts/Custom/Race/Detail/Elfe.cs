using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Sylwish : BaseRace
        {

		public override string Background => "Histoire : Originaire des grandes forêts de l'Ouest. Ils fondèrent plusieurs petit royaumes qui s'unirent en un seul. Le royaume de Glendiel qui reste caché à qui n'y a pas été conduit par l'un des habitants. \n\n  Nations d'origines : Glendiel, Limbourg, Gododdin \n\n  Généralité : Décrit comme assez hautain, les Sylwishs sont cependant généralement bien vue de la part des autres peuples.Calme et sage, ils s'avèrent être de bons conseils. On les dit cependant assez fermés sur les autres peuples. Il est très dur de gagner leur confiance. Les Sylwishs sont très portés sur la nature, d'ou leur culte principal.\n\n  Particularité : L'art Nécromantique est très mal vu par les Sylwishs.";



		public override int[] SkinHues => new int[] { 884, 0x361, 0x375, 0x367 };

		//  public override Type Skin => typeof(CorpsSylwishs);

		public override int GumpId => 52081;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsSylwishs) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Sylwish(1, 1));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Sylwish(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Sylwish", "Sylwishs", 400, 401, 402, 403)
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
    public class CorpsSylwishs : BaseRaceGumps
    {
        [Constructable]
        public CorpsSylwishs()
            : this(0)
        {
        }

        [Constructable]
        public CorpsSylwishs(int hue)
            : base(41500, hue)
        {
            Name = "Sylwish";
        }

        public CorpsSylwishs(Serial serial)
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
            Name = "Sylwish";
        }
    }
}

