using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Prompts;

namespace Server.Gumps
{
    public class SpellBookEntry
    {
        private int m_ConnaissanceLevel;
        private string m_Nom;
        private Type[] m_Reagents;
        private int m_ImageID;
        private int m_Cercle;
        private MagieType m_Affinity;
        private int m_SpellID;

        public int ConnaissanceLevel { get { return m_ConnaissanceLevel; } }
        public string Nom { get { return m_Nom; } }
        public Type[] Reagents { get { return m_Reagents; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public MagieType Affinity { get { return m_Affinity; } }
        public int SpellID { get { return m_SpellID; } }

        public SpellBookEntry(int conn, MagieType connaissance, string nom, Type[] regs, int imageid, int cercle, int spellid)
        {
            m_ConnaissanceLevel = conn;
            m_Nom = nom;
            m_Reagents = regs;
            m_ImageID = imageid;
            m_Cercle = cercle;
			m_Affinity = connaissance;
            m_SpellID = spellid;
        }
    }

    public class NewSpellbookGump : Gump
    {
        public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
        {
			new SpellBookEntry( 1, MagieType.Anarchique,"Pourriture", new Type[] {typeof(BatWing), typeof(PigIron), typeof(DaemonBlood) },0x5007, 3,752),
			new SpellBookEntry( 2, MagieType.Anarchique,"Spectre", new Type[] {typeof(NoxCrystal), typeof(PigIron) },0x500F, 2,753),
			new SpellBookEntry( 3, MagieType.Anarchique,"Image miroir", new Type[] { },21287, 2,754),
			new SpellBookEntry( 4, MagieType.Anarchique,"Arme d'immolation", new Type[] { },23002, 1,750),
			new SpellBookEntry( 5, MagieType.Anarchique,"Dormir", new Type[] {typeof(Nightshade), typeof(SpidersSilk), typeof(BlackPearl) },24004, 3,755),
			new SpellBookEntry( 6, MagieType.Anarchique,"Malédiction", new Type[] {typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) },0x8da, 4,756),
			new SpellBookEntry( 7, MagieType.Anarchique,"Poison", new Type[] {typeof(Nightshade) },0x8d3, 3,757),
			new SpellBookEntry( 8, MagieType.Anarchique,"Incognito", new Type[] {typeof(Bloodmoss), typeof(Garlic), typeof(Nightshade) },2274, 5,758),
			new SpellBookEntry( 9, MagieType.Anarchique,"Invisibilité", new Type[] {typeof(Bloodmoss), typeof(Nightshade) },0x8eb, 6,759),
			new SpellBookEntry( 10, MagieType.Anarchique,"Drain vampirique", new Type[] {typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot)},0x8f4, 7,760),
			new SpellBookEntry( 11, MagieType.Anarchique,"Forme animale", new Type[] { },21282, 1,761),
			new SpellBookEntry( 12, MagieType.Anarchique,"Saut d'ombre", new Type[] { },21286, 5,762),
			new SpellBookEntry( 13, MagieType.Anarchique,"Voyage éthéré", new Type[] { },23012, 2,751),
			new SpellBookEntry( 14, MagieType.Anarchique,"Jet de feu", new Type[] {typeof(SpidersSilk), typeof(SulfurousAsh) },0x8f2, 7,763),
			new SpellBookEntry( 15, MagieType.Anarchique,"Esprit Vengeur", new Type[] {typeof(BatWing), typeof(GraveDust), typeof(PigIron) },0x500D, 8,764),
			new SpellBookEntry( 16, MagieType.Anarchique,"Vortex d'energie", new Type[] {typeof(Bloodmoss), typeof(BlackPearl), typeof(MandrakeRoot) },2297, 8,765),
			
			new SpellBookEntry( 0, MagieType.Arcane,"Armure réactive", new Type[] {typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) },0x8c6, 1,766),
			new SpellBookEntry( 0, MagieType.Arcane,"Nourriture", new Type[] {typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) },0x8c1, 1,767),
			new SpellBookEntry( 0, MagieType.Arcane,"Vision de nuit", new Type[] {typeof(SulfurousAsh), typeof(SpidersSilk) },0x8c5, 1,768),
			new SpellBookEntry( 0, MagieType.Arcane,"Guérison", new Type[] {typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) },0x8c3, 1,769),
			new SpellBookEntry( 0, MagieType.Arcane,"Flèche magique", new Type[] {typeof(SulfurousAsh) },0x8c4, 1,770),
			new SpellBookEntry( 0, MagieType.Arcane,"Maladresse", new Type[] {typeof(Bloodmoss), typeof(Nightshade) },0x8C0, 1,771),
			new SpellBookEntry( 0, MagieType.Arcane,"Abrutissement", new Type[] {typeof(Ginseng), typeof(Nightshade) },0x8C2, 1,772),
			new SpellBookEntry( 0, MagieType.Arcane,"Faiblesse", new Type[] {typeof(Garlic), typeof(Nightshade) },0x8C7, 1,773),
			new SpellBookEntry( 0, MagieType.Arcane,"Agilité", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot) },0x8C8, 2,774),
			new SpellBookEntry( 0, MagieType.Arcane,"Astuce", new Type[] {typeof(MandrakeRoot), typeof(Nightshade) },0x8D9, 2,775),
			new SpellBookEntry( 0, MagieType.Arcane,"Force", new Type[] {typeof(MandrakeRoot), typeof(Nightshade) },0x8CF, 2,776),
			new SpellBookEntry( 0, MagieType.Arcane,"Protection", new Type[] {typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) },0x8ce, 2,777),
			new SpellBookEntry( 0, MagieType.Arcane,"Antidote", new Type[] {typeof(Garlic), typeof(Ginseng) },0x8ca, 2,778),
			new SpellBookEntry( 0, MagieType.Arcane,"Malaise", new Type[] {typeof(Nightshade), typeof(SpidersSilk) },0x08e5, 2,779),
			new SpellBookEntry( 0, MagieType.Arcane,"Piège Magique", new Type[] {typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) },0x8cC, 2,780),
			new SpellBookEntry( 0, MagieType.Arcane,"Sup. De Piège", new Type[] {typeof(Bloodmoss), typeof(SulfurousAsh) },0x8cD, 2,781),
			new SpellBookEntry( 0, MagieType.Arcane,"Fermeture Mag.", new Type[] {typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) },0x8D2, 3,782),
			new SpellBookEntry( 0, MagieType.Arcane,"Crochetage", new Type[] {typeof(Bloodmoss), typeof(SulfurousAsh) },0x8d6, 3,783),
			new SpellBookEntry( 0, MagieType.Arcane,"Télékinésie", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot) },0x8d4, 3,784),
			new SpellBookEntry( 0, MagieType.Arcane,"Téléportation", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot) },0x8d5, 3,785),
			new SpellBookEntry( 0, MagieType.Arcane,"Rappel", new Type[] {typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) },0x8df, 4,786),
			new SpellBookEntry( 0, MagieType.Arcane,"Souffle d'esprit", new Type[] {typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade)},0x8e4, 5,787),
			new SpellBookEntry( 0, MagieType.Arcane,"Boule de feu", new Type[] {typeof(BlackPearl) },0x8d1, 3,788),
			new SpellBookEntry( 0, MagieType.Arcane,"élém. : Feu", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk)},0x8fe, 8,789),
			new SpellBookEntry( 0, MagieType.Arcane,"élém. : Terre", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8fd, 8,790),
			new SpellBookEntry( 0, MagieType.Arcane,"élém. : Air", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8fb, 8,791),
			new SpellBookEntry( 16, MagieType.Arcane,"élém. : Eau", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8ff, 8,840),

			new SpellBookEntry( 1, MagieType.Cycle,"Familier", new Type[] {typeof(BatWing), typeof(GraveDust), typeof(DaemonBlood) },20491, 3,794),
			new SpellBookEntry( 2, MagieType.Cycle,"Peau de mort", new Type[] {typeof(BatWing), typeof(GraveDust) },20482, 2,795),
			new SpellBookEntry( 3, MagieType.Cycle,"Fureur naturelle", new Type[] { },23005, 2,792),
			new SpellBookEntry( 4, MagieType.Cycle,"Créatures", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8e7, 5,801),		
			new SpellBookEntry( 5, MagieType.Cycle,"Flétrissement", new Type[] {typeof(NoxCrystal), typeof(GraveDust), typeof(PigIron) },20494, 6,797),
			new SpellBookEntry( 6, MagieType.Cycle,"Mur de feu", new Type[] {typeof(BlackPearl), typeof(SpidersSilk), typeof(SulfurousAsh) },2267, 4,798),
			new SpellBookEntry( 7, MagieType.Cycle,"Transformation", new Type[] {typeof(Bloodmoss), typeof(SpidersSilk), typeof(MandrakeRoot) },0x8D2, 7,799),
			new SpellBookEntry( 8, MagieType.Cycle,"Réanimation", new Type[] {typeof(GraveDust), typeof(DaemonBlood) },20480, 4,800),
			new SpellBookEntry( 9, MagieType.Cycle,"Faucheuse", new Type[] { },23008, 2,793),
			new SpellBookEntry( 10, MagieType.Cycle,"Enchanter", new Type[] {typeof(SpidersSilk), typeof(MandrakeRoot), typeof(SulfurousAsh) },24003, 2,796),
			new SpellBookEntry( 11, MagieType.Cycle,"Marquage", new Type[] {typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) },0x8ec, 6,802),
			new SpellBookEntry( 12, MagieType.Cycle,"Explosion", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot) },0x8ea, 6,803),
			new SpellBookEntry( 13, MagieType.Cycle,"Orage de grêle", new Type[] {typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) },24013, 7,804),
			new SpellBookEntry( 14, MagieType.Cycle,"Cyclone du Néant", new Type[] {typeof(MandrakeRoot), typeof(Nightshade), typeof(SulfurousAsh) },24014, 8,805),
			new SpellBookEntry( 15, MagieType.Cycle,"Trou de ver", new Type[] {typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) },0x8f3, 7,806),
			new SpellBookEntry( 16, MagieType.Cycle,"Séisme", new Type[] {typeof(Bloodmoss), typeof(Ginseng), typeof(MandrakeRoot) },2296, 8,807),
			
			new SpellBookEntry( 1, MagieType.Mort,"Calamite", new Type[] {typeof(PigIron) },0x5003, 1,809),
			new SpellBookEntry( 2, MagieType.Mort,"Mauvais présage", new Type[] {typeof(BatWing), typeof(NoxCrystal) },20484, 2,810),
			new SpellBookEntry( 3, MagieType.Mort,"Bête Horrifique", new Type[] {typeof(BatWing), typeof(DaemonBlood) },0x5005, 4,811),
			new SpellBookEntry( 4, MagieType.Mort,"Don du renouveau", new Type[] { },23001, 1,808),
			new SpellBookEntry( 5, MagieType.Mort,"Arme Animée", new Type[] {typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) },24006, 4,812),
			new SpellBookEntry( 6, MagieType.Mort,"Drain de mana", new Type[] {typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8DE, 4,813),
			new SpellBookEntry( 7, MagieType.Mort,"Malédiction de gr.", new Type[] {typeof(Garlic), typeof(Nightshade), typeof(MandrakeRoot) },2285, 6,814),
			new SpellBookEntry( 8, MagieType.Mort,"Dissipation de mur", new Type[] {typeof(BlackPearl), typeof(SpidersSilk), typeof(SulfurousAsh) },0x8e1, 5,815),
			new SpellBookEntry( 9, MagieType.Mort,"Mur de poison", new Type[] {typeof(BlackPearl), typeof(Nightshade), typeof(SpidersSilk) },0x8e6, 5,816),
			new SpellBookEntry( 10, MagieType.Mort,"Serment de sang", new Type[] {typeof(DaemonBlood) },0x5001, 2,817),
			new SpellBookEntry( 11, MagieType.Mort,"Frappe mortelle", new Type[] { },21281, 8,818),
			new SpellBookEntry( 12, MagieType.Mort,"Jet de poison", new Type[] {typeof(NoxCrystal) },20489, 5,819),
			new SpellBookEntry( 13, MagieType.Mort,"étranglement", new Type[] {typeof(DaemonBlood), typeof(NoxCrystal) },0x8e5, 6,820),
			new SpellBookEntry( 14, MagieType.Mort,"Liche", new Type[] {typeof(GraveDust), typeof(DaemonBlood), typeof(NoxCrystal) },0x5006, 7,821),
			new SpellBookEntry( 15, MagieType.Mort,"Vampirisme", new Type[] {typeof(BatWing), typeof(NoxCrystal), typeof(PigIron) },0x500C, 8,822),
			new SpellBookEntry( 16, MagieType.Mort,"Démon", new Type[] {typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8fc, 8,823),
			
			new SpellBookEntry( 1, MagieType.Obeissance,"Supprimer le mal", new Type[] { },20744, 1,824),
			new SpellBookEntry( 2, MagieType.Obeissance,"Mur de pierre", new Type[] {typeof(Bloodmoss), typeof(Garlic) },2263, 3,825),
			new SpellBookEntry( 3, MagieType.Obeissance,"Ennemi d'un", new Type[] { },20741, 4,826),
			new SpellBookEntry( 4, MagieType.Obeissance,"Esprit de Lame", new Type[] {typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) },0x8E0, 5,827),
			new SpellBookEntry( 5, MagieType.Obeissance,"éclair", new Type[] {typeof(MandrakeRoot), typeof(SulfurousAsh) },0x8dd, 4,828),
			new SpellBookEntry( 6, MagieType.Obeissance,"Purification", new Type[] { },20736, 1,829),
			new SpellBookEntry( 7, MagieType.Obeissance,"Consacrer l'arme", new Type[] { },20738, 1,830),
			new SpellBookEntry( 8, MagieType.Obeissance,"Protection de gr", new Type[] {typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) },2243, 4,831),
			new SpellBookEntry( 9, MagieType.Obeissance,"Armure magique", new Type[] {typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) },2275, 5,832),
			new SpellBookEntry( 10, MagieType.Obeissance,"Dissipation", new Type[] {typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) },0x8e8, 6,833),
			new SpellBookEntry( 11, MagieType.Obeissance,"Attaque Ki", new Type[] { },21283, 8,834),
			new SpellBookEntry( 12, MagieType.Obeissance,"Mur de paralysie", new Type[] {typeof(BlackPearl), typeof(Ginseng), typeof(SpidersSilk) },2286, 6,835),
			new SpellBookEntry( 13, MagieType.Obeissance,"Fureur divine", new Type[] { },20740, 2,836),
			new SpellBookEntry( 14, MagieType.Obeissance,"évasion", new Type[] { },21538, 6,837),
			new SpellBookEntry( 15, MagieType.Obeissance,"Dissipation massive", new Type[] {typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) },0x8f5, 7,838),
			new SpellBookEntry( 16, MagieType.Obeissance,"Résurrection", new Type[] {typeof(Bloodmoss), typeof(Garlic), typeof(Ginseng) },0x8fa, 8,839),
		
			new SpellBookEntry( 1, MagieType.Vie,"Révélation", new Type[] {typeof(Bloodmoss), typeof(SulfurousAsh) },0x8ef, 6,843),
			new SpellBookEntry( 2, MagieType.Vie,"Harmonisation", new Type[] { },23003, 2,841),
			new SpellBookEntry( 3, MagieType.Vie,"Fermer les plaies", new Type[] { },20737, 0,844),
			new SpellBookEntry( 4, MagieType.Vie,"Bénédiction", new Type[] {typeof(Garlic), typeof(MandrakeRoot) },0x8da, 3,845),
			new SpellBookEntry( 5, MagieType.Vie,"Dissiper le mal", new Type[] { },20739, 3,846),
			new SpellBookEntry( 6, MagieType.Vie,"Antidote de masse", new Type[] {typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) },0x8d8, 4,847),
			new SpellBookEntry( 7, MagieType.Vie,"Guérison majeure", new Type[] {typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) },0x8dc, 4,848),
			new SpellBookEntry( 8, MagieType.Vie,"Paralysie", new Type[] {typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) },0x8E5, 5,849),
			new SpellBookEntry( 9, MagieType.Vie,"Lumière sacrée", new Type[] { },20742, 5,850),
			new SpellBookEntry( 10, MagieType.Vie,"Nobles sacrifices", new Type[] { },20743, 6,851),
			new SpellBookEntry( 11, MagieType.Vie,"Contre-attaque", new Type[] { },21539, 4,852),
			new SpellBookEntry( 12, MagieType.Vie,"Confiance", new Type[] { },21537, 2,853),
			new SpellBookEntry( 13, MagieType.Vie,"Don de vie", new Type[] { },23014, 4,842),
			new SpellBookEntry( 14, MagieType.Vie,"Boule d'énergie", new Type[] { },0x8e9, 6,854),
			new SpellBookEntry( 15, MagieType.Vie,"Mur d'energie", new Type[] { },2289, 7,855),
			new SpellBookEntry( 16, MagieType.Vie,"Colosse montant", new Type[] {typeof(DaemonBone), typeof(DragonBlood), typeof(FertileDirt) },24015, 8,856),		 
        };

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }
        
        #region tableaux

        public Hashtable m_NameColors = new Hashtable();
        public Hashtable m_Names = new Hashtable();

        public void InitializeHashtable()
        {
            m_NameColors[MagieType.Arcane] = 498;
			m_NameColors[MagieType.Anarchique] = 37;
			m_NameColors[MagieType.Cycle] = 72;   
			m_NameColors[MagieType.Mort] = 2052;
			m_NameColors[MagieType.Obeissance] = 140;
			m_NameColors[MagieType.Vie] = 182;


			m_Names[MagieType.Arcane] = "Arcane";
			m_Names[MagieType.Anarchique] = "Anarchique";
			m_Names[MagieType.Cycle] = "Cycle";
            m_Names[MagieType.Mort] = "Mort";
			m_Names[MagieType.Obeissance] = "Obéissance";
			m_Names[MagieType.Vie] = "Vie";
        }
        #endregion

        private NewSpellbook m_Book;

        public NewSpellbookGump(Mobile from, NewSpellbook book) : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (!(from is CustomPlayerMobile))
                return;

            CustomPlayerMobile m = (CustomPlayerMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldconnaissance = -1;
            int newconnaissance = -1;

            int value = 0;

			//Pour tous les sorts
			for (int i = 0; i < m_SpellBookEntry.Length; i++)
			{
				SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

				//on assigne la nouvelle connaissance
				newconnaissance = (int)info.Affinity;

				//on fait la comparaison des Aptitude pour savoir si on a changé de connaissance
				if ((newconnaissance != -1 && newconnaissance != oldconnaissance) || hindex == 2)
				{
					totpage++;
					AddPage(totpage);
					hindex = 0;

					//On ajoute le nom de la connaissance
					AddLabel(160 + hindex * 145, 25, (int)m_NameColors[info.Affinity], (string)m_Names[info.Affinity]);

					// Séparateurs
					AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

					//On remet %%%#$%?%$#@! 0 pour la nouvelle page
					vindex = 0;
					

					//On ajoute les boutons de changement de page
					AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
					AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
				}

				//Si le livre possède le sort

				bool one = HasSpell(from, info.SpellID);
				bool two = ArrayContains((MagieType[])Enum.GetValues(typeof(MagieType)), info.Affinity);

				if ( one && two)
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 1000, GumpButtonType.Reply, 0);
                    vindex++;

                    if (vindex >= 9)
                    {
                        vindex = 0;
                        hindex += 1;
                    }
                }



                oldconnaissance = (int)info.Affinity;
             }

            value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID) && ArrayContains((MagieType[])Enum.GetValues(typeof(MagieType)), info.Affinity))
                {
                    //Si le # du sort est pair...
                    if (value % 2 == 0)
                    {
                        //On fait une page
                        totpage++;
                        AddPage(totpage);
                        hindex = 0;

                        //On ajoute les boutons de pages
                        AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                        AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    }
                    else
                        hindex = 1;

                    int namecolor = 0;
                    string name = "...";

                    if (m_NameColors.Contains(info.Affinity))
                        namecolor = (int)m_NameColors[info.Affinity];

                    if (m_Names.Contains(info.Affinity))
                        name = (string)m_Names[info.Affinity];

                    //On ajoute le nom
                    AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);

                    //On ajoute les séparateurs
                    AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);

                    //On ajoute l'icone en tant que bouton pour lancer le sort
                    AddButton(140 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                    AddLabel(190 + hindex * 165, 78, namecolor, "Sort : " + info.SpellID.ToString());

                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute les boutons pour le lancement rapide
                    AddLabel(210 + hindex * 165, 98, 0, "Rapide");
                    AddButton(190 + hindex * 165, 101, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

                    //On ajoute les infos diverses
                    AddLabel(130 + hindex * 165, 120, 567, "Reagents:");
                    for (int j = 0; j < info.Reagents.Length; j++)
                    {
                        Type type = (Type)info.Reagents[j];
                        AddLabel(130 + hindex * 165, 138 + j * 18, 0, type.Name);
                    }

                    AddLabel(130 + hindex * 165, 192, namecolor, name + " " + info.ConnaissanceLevel);

                    //On augmente le nombre de sort de 1 pour le prochain sort.
                    value++;
                }
            }
            totpage++;
            AddPage(totpage);
            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
        }

        public bool ArrayContains(MagieType[] conn, MagieType wanted)
        {
            for (int i = 0; i < conn.Length; i++)
            {
                if (wanted == (MagieType)conn[i])
                    return true;
            }

            return false;
        }

        public static SpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                if (info.SpellID == spellID)
                    return info;
            }

            return null;
        }

        public class CompareSpellID : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                SpellBookEntry a = (SpellBookEntry)obj1;
                SpellBookEntry b = (SpellBookEntry)obj2;

                return ((int)a.SpellID).CompareTo(((int)b.SpellID));
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile m = (CustomPlayerMobile)from;

                if (info.ButtonID >= 600 && info.ButtonID < 1000)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();
					else 
					{
						SpecialMove sm = SpellRegistry.GetSpecialMove(info.ButtonID);

						if (sm != null)
						{
							sm.OnUse(m);
						}

					}

                    m.SendGump(new NewSpellbookGump(m, m_Book));
                }
                else if (info.ButtonID >= 1000 && info.ButtonID < 2000)
                {
                    if (m.QuickSpells == null)
                        return;

                    if (m.QuickSpells.Contains((int)(info.ButtonID - 1000)))
                    {
                        m.SendMessage("Le sort a été retiré de votre liste de lancement rapide.");
                        m.QuickSpells.Remove((int)(info.ButtonID - 1000));
                    }
                    else
                    {
                        m.SendMessage("Le sort a été ajouté %%%#$%?%$#@! votre liste de lancement rapide.");
                        m.QuickSpells.Add((int)(info.ButtonID - 1000));
                    }

                    m.SendGump(new NewSpellbookGump(m, m_Book));
                }
            }
        }
    }
}