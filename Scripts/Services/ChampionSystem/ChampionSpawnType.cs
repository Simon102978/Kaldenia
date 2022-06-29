using Server.Mobiles;
using System;
using System.Collections.Generic;

namespace Server.Engines.CannedEvil
{
    public enum ChampionSpawnType
    {
        Abyss,
        Arachnid,
        ColdBlood,
        ForestLord,
        VerminHorde,
        UnholyTerror,
        SleepingDragon,
        Glade,
        Corrupt,
        Terror,
        Infuse,
        DragonTurtle,
        Khaldun,
		Ceos
	}

    public class ChampionSpawnInfo
    {
        public string Name { get; }
        public Type Champion { get; }
        public Type[][] SpawnTypes { get; }
        public string[] LevelNames { get; }

		public Dictionary<int, string> Dialogue = new Dictionary<int, string>();

		public List<string> Taunt = new List<string>();


        public ChampionSpawnInfo(string name, Type champion, string[] levelNames, Type[][] spawnTypes, Dictionary<int,string> dialogue, List<string> taunt)
        {
            Name = name;
            Champion = champion;
            LevelNames = levelNames;
            SpawnTypes = spawnTypes;
			Dialogue = dialogue;
			Taunt = taunt;

		}

        public static ChampionSpawnInfo[] Table => m_Table;

        private static readonly ChampionSpawnInfo[] m_Table =
		{
			new ChampionSpawnInfo("Abyss", typeof(Semidar), new[] { "Foe", "Assassin", "Conqueror" }, new[] // Abyss
            {
				new[] { typeof(GreaterMongbat), typeof(Imp) }, // Level 1
                new[] { typeof(Gargoyle), typeof(Harpy) }, // Level 2
                new[] { typeof(FireGargoyle), typeof(StoneGargoyle) }, // Level 3
                new[] { typeof(Daemon), typeof(Succubus) }// Level 4
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()	
			),
            new ChampionSpawnInfo("Arachnid", typeof(Mephitis), new[] { "Bane", "Killer", "Vanquisher" }, new[] // Arachnid
            {
                new[] { typeof(Scorpion), typeof(GiantSpider) }, // Level 1
                new[] { typeof(TerathanDrone), typeof(TerathanWarrior) }, // Level 2
                new[] { typeof(DreadSpider), typeof(TerathanMatriarch) }, // Level 3
                new[] { typeof(PoisonElemental), typeof(TerathanAvenger) }// Level 4
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Cold Blood", typeof(Rikktor), new[] { "Blight", "Slayer", "Destroyer" }, new[] // Cold Blood
            {
                new[] { typeof(Lizardman), typeof(Snake) }, // Level 1
                new[] { typeof(LavaLizard), typeof(OphidianWarrior) }, // Level 2
                new[] { typeof(Drake), typeof(OphidianArchmage) }, // Level 3
                new[] { typeof(Dragon), typeof(OphidianKnight) }// Level 4
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Forest Lord", typeof(LordOaks), new[] { "Enemy", "Curse", "Slaughterer" }, new[] // Forest Lord
            {
                new[] { typeof(Pixie), typeof(ShadowWisp) }, // Level 1
                new[] { typeof(Kirin), typeof(Wisp) }, // Level 2
                new[] { typeof(Centaur), typeof(Unicorn) }, // Level 3
                new[] { typeof(EtherealWarrior), typeof(SerpentineDragon) }// Level 4
            },

				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Vermin Horde", typeof(Barracoon), new[] { "Adversary", "Subjugator", "Eradicator" }, new[] // Vermin Horde
            {
                new[] { typeof(GiantRat), typeof(Slime) }, // Level 1
                new[] { typeof(DireWolf), typeof(Ratman) }, // Level 2
                new[] { typeof(HellHound), typeof(RatmanMage) }, // Level 3
                new[] { typeof(RatmanArcher), typeof(SilverSerpent) }// Level 4
            },

				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Unholy Terror", typeof(Neira), new[] { "Scourge", "Punisher", "Nemesis" }, new[] // Unholy Terror
            {
                new[] { typeof(Bogle), typeof(Ghoul), typeof(Shade), typeof(Spectre), typeof(Wraith) }, // Level 1
                new[] { typeof(BoneMagi), typeof(Mummy), typeof(SkeletalMage) }, // Level 2
                new[] { typeof(BoneKnight), typeof(Lich), typeof(SkeletalKnight) }, // Level 3
                new[] { typeof(LichLord), typeof(RottingCorpse) }// Level 4
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Sleeping Dragon", typeof(Serado), new[] { "Rival", "Challenger", "Antagonist" }, new[] // Sleeping Dragon
            { 
                new[] { typeof(DeathwatchBeetleHatchling), typeof(Lizardman) },
                new[] { typeof(DeathwatchBeetle), typeof(Kappa) },
                new[] { typeof(LesserHiryu), typeof(RevenantLion) },
                new[] { typeof(Hiryu), typeof(Oni) }
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Glade", typeof(Twaulo), new[] { "Banisher", "Enforcer", "Eradicator" }, new[] // Glade
            { 
                new[] { typeof(Pixie), typeof(ShadowWisp) },
                new[] { typeof(Centaur), typeof(MLDryad) },
                new[] { typeof(Satyr), typeof(CuSidhe) },
                new[] { typeof(FeralTreefellow), typeof(RagingGrizzlyBear) }
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Corrupt", typeof(Ilhenir), new[] { "Cleanser", "Expunger", "Depurator" }, new[] // Corrupt
            {
                new[] { typeof(PlagueSpawn), typeof(Bogling) },
                new[] { typeof(PlagueBeast), typeof(BogThing) },
                new[] { typeof(PlagueBeastLord), typeof(InterredGrizzle) },
                new[] { typeof(FetidEssence), typeof(PestilentBandage) }
			},
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()

			),

            new ChampionSpawnInfo("Terror", typeof(AbyssalInfernal), new[] { "Banisher", "Enforcer", "Eradicator" }, new[] // Terror
            {
                new[] { typeof(HordeMinion), typeof(ChaosDaemon) }, 
                new[] { typeof(StoneHarpy), typeof(ArcaneDaemon) }, 
                new[] { typeof(PitFiend), typeof(Moloch) }, 
                new[] { typeof(ArchDaemon), typeof(AbyssalAbomination) }
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
            new ChampionSpawnInfo("Infuse", typeof(PrimevalLich), new[] { "Cleanser", "Expunger", "Depurator" }, new[] // Infused
            { 
                new[] { typeof(GoreFiend), typeof(VampireBat) },
                new[] { typeof(FleshGolem), typeof(DarkWisp) }, 
                new[] { typeof(UndeadGargoyle), typeof(Wight) },
                new[] { typeof(SkeletalDrake), typeof(DreamWraith) }
            },
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),

            new ChampionSpawnInfo( "Valley", typeof( DragonTurtle ), new[]{ "Explorer", "Huntsman", "Msafiri" } , new[] // Dragon Turtle
            {																											
				new[]{ typeof( MyrmidexDrone ), typeof( MyrmidexLarvae ) }, 
				new[]{ typeof( SilverbackGorilla ), typeof( WildTiger ) }, 
				new[]{ typeof( GreaterPhoenix  ), typeof( Infernus ) }, 
				new[]{ typeof( Dimetrosaur ), typeof( Allosaurus ) }											   
			},
				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),

            new ChampionSpawnInfo( "Khaldun", typeof( KhalAnkur ), new[]{ "Banisher", "Enforcer", "Eradicator" } , new[] // Khal Ankur
            {																					                        
				new[]{ typeof( SkelementalKnight ), typeof( KhaldunBlood ) },							
				new[]{ typeof( SkelementalMage ), typeof( Viscera ) },											   
				new[]{ typeof( CultistAmbusher  ), typeof( ShadowFiend ) },										
				new[]{ typeof( KhalAnkurWarriors ) }											                    
			},

				new Dictionary<int, string>()
				{
					   {1 , "" },
					   {2 , "" },
					   {3 , "" },
					   {4 , "" },
				},
				new List<string>()
			),
		   new ChampionSpawnInfo( "Ceos", typeof( Ceos ), new[]{ "Banisher", "Enforcer", "Eradicator" } , new[] // Ceos
            {
				new[]{ typeof(Trollvillageois), typeof(Trollvagabond)},
				new[]{ typeof(Troll),  typeof(Ogre)   },
				new[]{ typeof(OgreShaman), typeof(Ogresse)  },
				new[]{ typeof(OgreLord), typeof(MatriacheOgre)   }
			},

				new Dictionary<int, string>()
				{
					   {1 , "Ceos: On ne peut pas confier au troll un travail d'ogre !" },
					   {2 , "Ceos: C'était juste de la chair à canon, maintenant le véritable combat commence." },
					   {3 , "Ceos: Quoi ?! Impossible ! Vous allez payer pour cette affront !" },
					   {4 , "Ceos: GNAAAH ! MOURREZ !" },
				},
				new List<string>()
			    {
					 {"Ceos: Qui est-ce qui va se cacher sous les jupons de leurs m%%%#$%?%$#@!re ?" },
					 {"Ceos: Revenez, on commençait juste à s'amuser !" },
					 {"Ceos: Quoi ? Vous osez me déranger juste pour ca ?" },
					 {"Ceos: *Soupire* Moi qui croyais que vous aviez du potentiel..." },
					 {"Ceos: Si c'est comme ca, vous êtes plus mes amis !" },
				}
			),
		};

        public static ChampionSpawnInfo GetInfo(ChampionSpawnType type)
        {
            int v = (int)type;

            if (v < 0 || v >= m_Table.Length)
                v = 0;

            return m_Table[v];
        }
    }
}
