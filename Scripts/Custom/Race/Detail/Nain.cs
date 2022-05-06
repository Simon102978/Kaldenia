using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 

 		
        class Nain : BaseRace
        {

		public override AppearanceEnum AppearanceMin => AppearanceEnum.Monstrueux; // Pour NPC
		public override AppearanceEnum AppearanceMax => AppearanceEnum.Banal; // Pour NPC

		public override GrandeurEnum GrandeurMin => GrandeurEnum.tresPetit;
		public override GrandeurEnum GrandeurMax => GrandeurEnum.PlutotPetit;

		public override GrosseurEnum GrosseurMin => GrosseurEnum.Bedonnant;
		public override GrosseurEnum GrosseurMax => GrosseurEnum.Corpulent;
		public override string Background => "Les nains font partie des races les plus intelligentes et son les plus avancés technologiquement. Ils sont pour la pluparts mineurs, bûcherons, inventeurs, ouvriers et artisants. C'est le travail manuel qui les attire le plus.Ils sont pour la plupart jovials et aimables.Ils sont politiquement neutres avec presque tous les autres peuples. Souvent représentés telle une grande famille dans laquelle chacun doit effectuer sa tâche, chaque nain est un membre important dans sa communauté ; la ténacité et la persévérance qu'il ou elle prouvera lui apportera de grandes ouvertures dans son futur.";

		public override int[] SkinHues => new int[] { 1823, 1822, 1821, 1820 };

		//  public override Type Skin => typeof(CorpsNain);

		public override int GumpId => 52085;

		public override List<Type> RaceGump => new List<Type>() { typeof(CorpsNain) };

        public static void Configure()
            {
                /* Here we configure all races. Some notes:
                * 
                * 1) The first 32 races are reserved for core use.
                * 2) Race 0x7F is reserved for core use.
                * 3) Race 0xFF is reserved for core use.
                * 4) Changing or removing any predefined races may cause server instability.
                */
               RegisterRace(new Nain(5,5));
            }

        // 	protected Race(int raceID,  int raceIndex, string name,  string pluralName, int maleBody, int femaleBody, int maleGhostBody,  int femaleGhostBody)

            public Nain(int raceID, int raceIndex)
                : base(raceID, raceIndex, "Nain", "Nains", 400, 401, 402, 403)
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
    public class CorpsNain : BaseRaceGumps
    {
        [Constructable]
        public CorpsNain()
            : this(0)
        {
        }

        [Constructable]
        public CorpsNain(int hue)
            : base(41504, hue)
        {
            Name = "Nain";
        }

        public CorpsNain(Serial serial)
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
            Name = "Nain";
        }
    }
}

