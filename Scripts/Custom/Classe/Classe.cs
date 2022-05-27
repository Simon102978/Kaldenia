using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 		
        class ClasseInit 
        {
				public static void Configure()
					{
						Classe.RegisterClasse(new Classe(-1, "Aucune",ClasseType.None,new List<SkillName>() {  },0));

			     		Classe.RegisterClasse(new Classe(0,	"Épéiste",ClasseType.Guerrier,new List<SkillName>() { SkillName.Swords,SkillName.Tactics,SkillName.Focus },3));
						Classe.RegisterClasse(new Classe(1, "Massier", ClasseType.Guerrier, new List<SkillName>() { SkillName.Macing, SkillName.Tactics, SkillName.Focus }, 3));
						Classe.RegisterClasse(new Classe(2, "Dueliste", ClasseType.Guerrier, new List<SkillName>() { SkillName.Fencing, SkillName.Tactics, SkillName.Focus }, 3));
						Classe.RegisterClasse(new Classe(3, "Bagarreur", ClasseType.Guerrier, new List<SkillName>() { SkillName.Wrestling, SkillName.Tactics, SkillName.Focus }, 3));
						Classe.RegisterClasse(new Classe(4, "Archer", ClasseType.Guerrier, new List<SkillName>() { SkillName.Archery, SkillName.Tactics, SkillName.Focus }, 3));
						Classe.RegisterClasse(new Classe(5, "Gardien", ClasseType.Guerrier, new List<SkillName>() { SkillName.Parry, SkillName.Healing, SkillName.Anatomy }, 3));

						Classe.RegisterClasse(new Classe(6, "Sorcier", ClasseType.Mage, new List<SkillName>() { SkillName.Magery, SkillName.Meditation, SkillName.EvalInt }, 1));

						Classe.RegisterClasse(new Classe(7,  "Ménéstrel", ClasseType.Roublard, new List<SkillName>() { SkillName.Musicianship, SkillName.Peacemaking, SkillName.Provocation,SkillName.Discordance }, 2));
						Classe.RegisterClasse(new Classe(8,  "Cambrioleur", ClasseType.Roublard, new List<SkillName>() { SkillName.Stealing, SkillName.Snooping, SkillName.Lockpicking }, 2));
						Classe.RegisterClasse(new Classe(9,  "Assassin", ClasseType.Roublard, new List<SkillName>() { SkillName.Hiding, SkillName.Poisoning, SkillName.Fencing }, 2));
						Classe.RegisterClasse(new Classe(10, "Pisteur", ClasseType.Roublard, new List<SkillName>() { SkillName.Tracking, SkillName.Hiding, SkillName.Archery }, 2));
						Classe.RegisterClasse(new Classe(11, "Dresseur", ClasseType.Roublard, new List<SkillName>() { SkillName.AnimalLore, SkillName.AnimalTaming, SkillName.Veterinary }, 2));

						Classe.RegisterClasse(new Classe(12, "Historien", ClasseType.Metier, new List<SkillName>() { SkillName.Inscribe, SkillName.Cartography}, 0));
						Classe.RegisterClasse(new Classe(13, "Ingénieur", ClasseType.Metier, new List<SkillName>() { SkillName.Blacksmith, SkillName.Tinkering }, 0));
						Classe.RegisterClasse(new Classe(14, "Styliste", ClasseType.Metier, new List<SkillName>() { SkillName.Carpentry, SkillName.Tailoring }, 0));
						Classe.RegisterClasse(new Classe(15, "Palefrenier", ClasseType.Metier, new List<SkillName>() { SkillName.Herding, SkillName.Equitation }, 0));
						Classe.RegisterClasse(new Classe(16, "Épicier", ClasseType.Metier, new List<SkillName>() { SkillName.Cooking, SkillName.Alchemy }, 0));
					}
		}
}
