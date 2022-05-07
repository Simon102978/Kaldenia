#region References
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Server
{
	[Parsable]
	public class Classe
	{


		private static readonly List<Classe> m_AllClasse = new List<Classe>();

		public static List<Classe> AllClasse => m_AllClasse;

		private readonly int m_ClasseID;
		private string m_Name;
		private List<SkillName> m_Skill = new List<SkillName>();
		private int m_Armor;
		private ClasseType m_ClasseType;


		public static Classe GetClasse(int Id)
		{
			foreach (Classe item in m_AllClasse)
			{
				if (item.ClasseID == Id)
				{
					return item;
				}
			}

			return null;
		}

		public override string ToString()
		{
			return m_Name;
		}


		public Classe(
			int ClasseID,
			string name,
			ClasseType type,
			List<SkillName> skill,
			int armor
			)
		{
			m_ClasseID = ClasseID;
			m_ClasseType = type;
			m_Name = name;
			m_Skill = skill;
			m_Armor = armor;
		}
		public static void RegisterClasse(Classe Classe)
		{
			Classe.AllClasse.Add(Classe);
		}
		public virtual void AddClasse(Mobile m)
		{

		}


	    public virtual bool ContainSkill(SkillName skill)
		{
			foreach (SkillName item in m_Skill)
			{
				if (item == skill)
				{
					return true;
				}
			}

			return false;

		}



		public virtual void AddClasse(Mobile m, int hue)
		{

		}

		public virtual void RemoveClasse(Mobile m)
		{

		}
		public virtual void CheckGump(Mobile m)
		{

		}

		public static string[] GetClassesNames()
		{

			List<string> ClasseName = new List<string>();

			foreach (Classe item in AllClasse)
			{
				ClasseName.Add(item.Name);
			}

			return ClasseName.ToArray();
		}

		public int ClasseID => m_ClasseID;

		public string Name { get => m_Name; set => m_Name = value; }

		public List<SkillName> Skill { get => m_Skill; set => m_Skill = value; }

		public int Armor { get => m_Armor; set => m_Armor = value; }

		public ClasseType ClasseType { get => m_ClasseType; set => m_ClasseType = value; }


	}
}
