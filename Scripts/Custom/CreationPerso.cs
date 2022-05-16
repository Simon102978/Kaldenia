#region References
using System;
using Server.Mobiles;
using System.Reflection;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
#endregion

namespace Server
{
    [Parsable]
    public class CreationPerso
    {
      
        private BaseRace m_Race;
        private int m_Hue;
        private bool m_female;
		private string m_Name;

		private int m_Str = 25;
		private int m_Dex = 25;
		private int m_Int = 25;

		private CustomPlayerMobile m_Player;

		//        private Reroll m_Reroll;


		private AppearanceEnum m_Appearance = (AppearanceEnum)(-1);
		private GrandeurEnum m_Grandeur = (GrandeurEnum)(-1);
		private GrosseurEnum m_Grosseur = (GrosseurEnum)(-1);
		private int m_ClassePrimaire = -1;
		private int m_ClasseSecondaire = -1;
		private int m_Metier = -1;

		private God m_God = null;

		public BaseRace Race
        {
            get => m_Race;
            set
            {
                if (m_Race != value)
                {
                    ChangeRace();
                }
                m_Race = value;
            }
             
        }

		public int ClassePrimaire
		{
			get => m_ClassePrimaire;
			set
			{
				if (m_ClassePrimaire != value)
				{
					ChangeClassePrimaire();
				}
				m_ClassePrimaire = value;
			}

		}

		public int ClasseSecondaire
		{
			get => m_ClasseSecondaire;
			set
			{
				if (m_ClasseSecondaire != value)
				{
					ChangeClasseSecondaire();
				}
				m_ClasseSecondaire = value;
			}

		}

		public int Metier
		{
			get => m_Metier;
			set
			{
				if (Classe.GetClasse(value).ClasseType == ClasseType.Metier)  // Juste pour s'assurer que personne le fasse... Genre utiliser razor pour choisir une classe combat au lieux de metier.
				{
					if (m_Metier != value)
					{
						ChangeMetier();
					}
					m_Metier = value;
				}
			
			}

		}

		public int Str
		{
			get => m_Str;
			set
			{
				if (value + m_Dex + m_Int > 225)
				{
					
				}
				else if (value < 25)
				{

				}
				else if (value > 100)
				{

				}
				else
				{
					m_Str = value;
				}
			}
		}

		public int Dex
		{
			get => m_Dex;
			set
			{
				if (m_Str + value + m_Int > 225)
				{

				}
				else if (value < 25)
				{

				}
				else if (value > 100)
				{

				}
				else
				{
					m_Dex = value;
				}
			}
		}

		public int Int
		{
			get => m_Int;
			set
			{
				if (m_Str + m_Dex + value > 225)
				{

				}
				else if (value < 25)
				{

				}
				else if (value > 100)
				{

				}
				else
				{
					m_Int = value;
				}
			}
		}

		public string Name { get => m_Name; set => m_Name = value; }

		public int Hue { get => m_Hue; set => m_Hue = value; }

		public God God { get => m_God; set => m_God = value; }

		public AppearanceEnum Appearance { get => m_Appearance; set => m_Appearance = value; }

		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }

		public GrosseurEnum Grosseur { get => m_Grosseur; set => m_Grosseur = value; }

		public bool Female
        {
            get => m_female;
            set
            {
                if (m_female != value)
                {
                    ChangeSexe();
                }


                m_female = value;
            }
       }
 
		public CreationPerso(CustomPlayerMobile player)
        {
			m_female = player.Female;
			m_Name = player.Name;
			m_Player = player;
        }
    
        public void ChangeRace()
        {
            m_Hue = -1;
			m_Appearance = (AppearanceEnum)(-1);
			m_Grandeur = (GrandeurEnum)(-1);
			m_Grosseur = (GrosseurEnum)(-1);


		}

        public void ChangeSexe()
        {
            
        }

		public void ChangeClassePrimaire()
		{		
				m_ClasseSecondaire = -1;			
				m_Metier = -1;
		}

		public void ChangeClasseSecondaire()
		{
			m_Metier = -1;
		}

		public void ChangeMetier()
		{
		
		}

		public bool InfoGeneral()
		{

			if (m_Appearance == (AppearanceEnum)(-1) || m_Grandeur == (GrandeurEnum)(-1) || m_Grosseur == (GrosseurEnum)(-1))
			{
				return false;
			}
			else if (Name.Length < 3)
			{
				return false;
			}
			else
			{
				return true;
			}			
		}

		public bool Statistique()
		{

			if (m_Int + m_Dex + m_Str == 225)
			{
				return true;
			}

			return false;


		}

		public bool ClasseSelection( int Stade)
		{
			if (Stade == 0 && ClassePrimaire != -1)
			{
				return true;
			}
			else if (Stade == 1 && ClasseSecondaire != -1)
			{
				return true;
			}
			else if (Stade == 2 && Metier != -1)
			{
				return true;
			}


			return false;
			
		}

		public string Title(int stade)
		{
			switch (stade)
			{
				case 0:
					{
						return "Classe Primaire";
					}
				case 1:
					{
						return "Classe Secondaire";
					}
				case 2:
					{
						return "Metier";
					}
				default:
					return "Classe Primaire";
			}



		}

		public string GetApparence()
		{
			if (m_Appearance != (AppearanceEnum)(-1))
			{
				var type = typeof(AppearanceEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Appearance.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "";
		}

		public string GetGrosseur()
		{
			if (Grosseur != (GrosseurEnum)(-1))
			{
				var type = typeof(GrosseurEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Grosseur.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "";
		}

		public string GetGrandeur()
		{
			if (Grandeur != (GrandeurEnum)(-1))
			{
				var type = typeof(GrandeurEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Grandeur.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "";
		}

		public int PointRestant()
		{
			return (225 - m_Str - m_Dex - m_Int);
		}

		public void Valide()
        {
			m_Player.BaseFemale = m_female;
			m_Player.BaseRace = m_Race;
			m_Player.Race.RemoveRace(m_Player);	
			Race.AddRace(m_Player, m_Hue);
			m_Player.Name = m_Name;
			m_Player.Beaute = m_Appearance;
			m_Player.Grandeur = m_Grandeur;
			m_Player.Grosseur = m_Grosseur;
			m_Player.BaseHue = m_Hue;



			m_Player.InitStats(m_Str, m_Dex, m_Int);

			m_Player.ClassePrimaire = Classe.GetClasse(m_ClassePrimaire);
			m_Player.ClasseSecondaire = Classe.GetClasse(m_ClasseSecondaire);
			m_Player.Metier = Classe.GetClasse(Metier);

			m_Player.God = God;

	//		Dictionary<SkillName, int> m_skills = new Dictionary<SkillName, int>();




			foreach (SkillName item in m_Player.ClasseSecondaire.Skill)
			{
				m_Player.Skills[item].Base = 30;

	//			m_skills.Add(item, 30);
			}

			foreach (SkillName item in m_Player.Metier.Skill)
			{
				m_Player.Skills[item].Base = 50;

/*				if (m_skills.ContainsKey(item))
				{
					m_skills[item] = 50;
				}
				else
				{
					m_skills.Add(item, 50);
				}*/
			}

			foreach (SkillName item in m_Player.ClassePrimaire.Skill)
			{
				m_Player.Skills[item].Base = 50;

/*				if (m_skills.ContainsKey(item))
				{
					m_skills[item] = 50;
				}
				else
				{
					m_skills.Add(item, 50);
				}*/
			}


			m_Player.Skills[SkillName.Mining].Base = 30;
			m_Player.Skills[SkillName.Lumberjacking].Base = 30;
			m_Player.Skills[SkillName.Fishing].Base = 30;
			m_Player.Skills[SkillName.MagicResist].Base = 30;



			/*			m_skills.Add(SkillName.Mining, 0);
						m_skills.Add(SkillName.Lumberjacking, 0);
						m_skills.Add(SkillName.Fishing, 0);
						m_skills.Add(SkillName.MagicResist, 0);*/

			int GoldNumber = 5000;
			

			m_Player.AddToBackpack(new Gold(GoldNumber));



			/*           if (Reroll != null)
					   {
						   Reroll.Valider(sp);
					   }

					 */

			

			m_Player.MoveToWorld(new Point3D(1183, 3725, 37), Map.Felucca);

			Robe robe = new Robe();


			m_Player.AddItem(robe);



			
		//	m_Player.EquipItem(robe);


		}

    }


}
