﻿#region References
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Server
{
	[Parsable]
	public abstract class Race
	{
		public static Race DefaultRace => m_Races[0];

		private static readonly Race[] m_Races = new Race[0x100];

		public static Race[] Races => m_Races;



		public static Race Human => m_Races[0];
		/*		public static Race Elf => m_Races[1];
				public static Race Gargoyle => m_Races[2];*/

		private static readonly List<Race> m_AllRaces = new List<Race>();

		public static List<Race> AllRaces => m_AllRaces;

		private readonly int m_RaceID;
		private readonly int m_RaceIndex;

		private string m_Name;

		private static string[] m_RaceNames;
		private static Race[] m_RaceValues;

		public static string[] GetRaceNames()
		{
			CheckNamesAndValues();
			return m_RaceNames;
		}

		public static Race GetRace(int Id)
		{
			foreach (Race item in m_AllRaces)
			{
				if (item.RaceID == Id)
				{
					return item;
				}
			}

			return DefaultRace;
		}

		public static Race[] GetRaceValues()
		{
			CheckNamesAndValues();
			return m_RaceValues;
		}

		public static Race Parse(string value)
		{
			CheckNamesAndValues();

			for (int i = 0; i < m_RaceNames.Length; ++i)
			{
				if (Insensitive.Equals(m_RaceNames[i], value))
				{
					return m_RaceValues[i];
				}
			}

			if (int.TryParse(value, out int index))
			{
				if (index >= 0 && index < m_Races.Length && m_Races[index] != null)
				{
					return m_Races[index];
				}
			}
			return m_Races[0];
			//		throw new ArgumentException("Invalid race name");
		}

		private static void CheckNamesAndValues()
		{
			if (m_RaceNames != null && m_RaceNames.Length == m_AllRaces.Count)
			{
				return;
			}

			m_RaceNames = new string[m_AllRaces.Count];
			m_RaceValues = new Race[m_AllRaces.Count];

			for (int i = 0; i < m_AllRaces.Count; ++i)
			{
				Race race = m_AllRaces[i];

				m_RaceNames[i] = race.Name;
				m_RaceValues[i] = race;
			}
		}

		public override string ToString()
		{
			return m_Name;
		}

		private readonly int m_MaleBody;
		private readonly int m_FemaleBody;
		private readonly int m_MaleGhostBody;
		private readonly int m_FemaleGhostBody;
		/*       private  int[] m_SkinHues = new[]{ 1002 };
			   private  Type m_Skin; */



		public int MaleBody => m_MaleBody;
		public int MaleGhostBody => m_MaleGhostBody;

		public int FemaleBody => m_FemaleBody;
		public int FemaleGhostBody => m_FemaleGhostBody;

		protected Race(
			int raceID,
			int raceIndex,
			string name,
			string pluralName,
			int maleBody,
			int femaleBody,
			int maleGhostBody,
			int femaleGhostBody)
		{
			m_RaceID = raceID;
			m_RaceIndex = raceIndex;

			m_Name = name;

			m_MaleBody = maleBody;
			m_FemaleBody = femaleBody;
			m_MaleGhostBody = maleGhostBody;
			m_FemaleGhostBody = femaleGhostBody;

			PluralName = pluralName;
		}
		public static void RegisterRace(Race race)
		{
			Race.Races[race.RaceIndex] = race;
			Race.AllRaces.Add(race);
		}

		public virtual bool ValidateHair(Mobile m, int itemID)
		{
			return ValidateHair(m.Female, itemID);
		}

		public abstract bool ValidateHair(bool female, int itemID);

		public virtual int RandomHair(Mobile m)
		{
			return RandomHair(m.Female);
		}

		public abstract int RandomHair(bool female);

		public virtual bool ValidateFacialHair(Mobile m, int itemID)
		{
			return ValidateFacialHair(m.Female, itemID);
		}

		public abstract bool ValidateFacialHair(bool female, int itemID);

		public virtual int RandomFacialHair(Mobile m)
		{
			return RandomFacialHair(m.Female);
		}

		public abstract int RandomFacialHair(bool female); //For the *ahem* bearded ladies

		public virtual bool ValidateFace(Mobile m, int itemID)
		{
			return ValidateFace(m.Female, itemID);
		}

		public abstract bool ValidateFace(bool female, int itemID);

		public virtual int RandomFace(Mobile m)
		{
			return RandomFace(m.Female);
		}
		public abstract int RandomFace(bool female);

		public abstract bool ValidateEquipment(Item item);

		public virtual bool ValidateEquipment(Mobile from, Item equipment)
		{
			return ValidateEquipment(from, equipment, true);
		}
		public virtual bool ValidateEquipment(Mobile from, Item equipment, bool message)
		{
			return true;
		}

		public virtual int GetArmorRating(Mobile m)
		{
			return 0;
		}

		public virtual void ChangeHue(Mobile m)
		{
			// Sert principalement à rotater sur le hue.
		}

		public virtual int RotateHue(int Hue)
		{
			int n = 0;

			foreach (int item in SkinHues)
			{
				if (item == Hue)
				{
					break;
				}

				n++;
			}

			n++;

			if (n >= SkinHues.Length)
			{
				n = 0;
			}

			return SkinHues[n];

			// Sert principalement à rotater sur le hue.
		}



		public abstract int ClipSkinHue(int hue);
		public virtual int RandomSkinHue()
		{
			int hue = 1002;

			if (SkinHues.Length > 0)
			{
				hue = SkinHues[Utility.Random(0, SkinHues.Length)];
			}

			return hue;
		}



		public abstract int ClipHairHue(int hue);
		public abstract int RandomHairHue();

		public abstract int ClipFaceHue(int hue);
		public abstract int RandomFaceHue();

		public virtual int Body(Mobile m)
		{
			if (m.Alive)
			{
				return AliveBody(m.Female);
			}

			return GhostBody(m.Female);
		}

		public virtual int AliveBody(Mobile m)
		{
			return AliveBody(m.Female);
		}

		public virtual int AliveBody(bool female)
		{
			return (female ? m_FemaleBody : m_MaleBody);
		}

		public virtual int GhostBody(Mobile m)
		{
			return GhostBody(m.Female);
		}

		public virtual int GhostBody(bool female)
		{
			return (female ? m_FemaleGhostBody : m_MaleGhostBody);
		}


		public virtual void AddRace(Mobile m)
		{

		}

		public virtual void AddRace(Mobile m, int hue)
		{

		}

		public virtual void RemoveRace(Mobile m)
		{

		}


		public virtual void CheckGump(Mobile m)
		{

		}




		public int RaceID => m_RaceID;

		public int RaceIndex => m_RaceIndex;

		public string Name { get => m_Name; set => m_Name = value; }

		public string PluralName { get; set; }



		public virtual int[] SkinHues => new int[] { 1023 };

		//   public virtual Type Skin => null;

	//	public virtual List<Type> RaceGump => new List<Type>();

		public virtual bool StaticHue => false;

		public virtual bool FemmeBarbe => false;

		public virtual bool Barbe => true;

		public static implicit operator Race(string v)
		{
			throw new NotImplementedException();
		}
	}
}
