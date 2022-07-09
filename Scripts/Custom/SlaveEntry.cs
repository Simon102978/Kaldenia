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

	public enum SlaveType
	{
		Aucun,
		Menestrel,
		Barde,
		Mendiant,
		Combatant,
		Paysan,
		Ranger,
		Archer,
		Marin,
		Voleur
	}

	[Parsable]
	public class SlaveEntry
	{

		private Race m_Race;
		private int m_Hue;
		private bool m_female;
		private string m_Name;
		private AppearanceEnum m_Appearance = (AppearanceEnum)(-1);
		private GrandeurEnum m_Grandeur = (GrandeurEnum)(-1);
		private GrosseurEnum m_Grosseur = (GrosseurEnum)(-1);
		private int m_Price;
		private SlaveType m_typeEsclave;


		public Race Race
		{
			get => m_Race;
			set
			{
				m_Race = value;
			}

		}

		public string Name { get => m_Name; set => m_Name = value; }

		public int Hue { get => m_Hue; set => m_Hue = value; }

		public AppearanceEnum Appearance { get => m_Appearance; set => m_Appearance = value; }

		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }

		public GrosseurEnum Grosseur { get => m_Grosseur; set => m_Grosseur = value; }

		public SlaveType TypeEsclave => m_typeEsclave;

		public int Price { get => m_Price; set => m_Price = value; }

		public bool Female
		{
			get => m_female;
			set
			{
				m_female = value;
			}
		}

		public SlaveEntry(Race race, int hue, AppearanceEnum appareance, GrandeurEnum grandeur, GrosseurEnum grosseur, string name, bool female)
		{
			m_Race = race;
			m_Hue = hue;
			m_female = female;
			m_Name = name;
			m_Appearance = appareance;
			m_Grandeur = grandeur;
			m_Grosseur = grosseur;
		}






		public SlaveEntry()
		{
			Race = BaseRace.GetRace(Utility.Random(4));
			Hue = Race.RandomSkinHue();
			m_female = Utility.RandomBool();
			m_Name = m_female ? NameList.RandomName("female") : NameList.RandomName("male");
			m_Appearance = (AppearanceEnum)Utility.Random(1, Enum.GetNames(typeof(AppearanceEnum)).Length - 1);
			m_Grandeur = (GrandeurEnum)Utility.Random(1, Enum.GetNames(typeof(GrandeurEnum)).Length - 1);
			m_Grosseur = (GrosseurEnum)Utility.Random(1, Enum.GetNames(typeof(GrosseurEnum)).Length - 1); ;
			m_typeEsclave = (SlaveType)Utility.Random(1, Enum.GetNames(typeof(SlaveType)).Length - 1);

			PriceCalculation();
		}

		public void PriceCalculation()
		{
			int Cost = 7500;

			Cost += RaceCost();

			Cost += Female ? 500 : 0;

			Cost += ApparenceCost();
			Cost += GrandeurCost();
			Cost += GrosseurCost();
			Cost += TypeCost();
			Price = Cost;

		}

		public BaseHire GenerateSlave()
		{
			BaseHire esclave;



			switch (m_typeEsclave)
			{
				case SlaveType.Aucun:
					esclave = new HirePeasant();
					break;
				case SlaveType.Menestrel:
					esclave = new HireBard();
					break;
				case SlaveType.Barde:
					esclave = new HireBardArcher();				
					break;
				case SlaveType.Mendiant:
					esclave = new HireBeggar();
					break;
				case SlaveType.Combatant:
					esclave = new HireFighter();
					break;
				case SlaveType.Paysan:
					esclave = new HirePeasant();
					break;
				case SlaveType.Ranger:
					esclave = new HireRanger();
					break;
				case SlaveType.Archer:
					esclave = new HireRangerArcher();
					break;
				case SlaveType.Marin:
					esclave = new HireSailor();
					break;
				case SlaveType.Voleur:
					esclave = new HireThief();
					break;
				default:
					esclave = new HirePeasant();
					break;
			}

			esclave.Female = m_female;
			esclave.Race = Race;
			esclave.Race.RemoveRace(esclave);
			Race.AddRace(esclave, m_Hue);
			esclave.Name = Name;
			esclave.Beaute = Appearance;
			esclave.Grandeur = Grandeur;
			esclave.Grosseur = Grosseur;

			return esclave;


		}


		public int RaceCost()
		{
			int RaceCost = 0;

			if (Race.RaceID == 0)
			{
				RaceCost += 500;
			}

			return RaceCost;
		}

		public int ApparenceCost()
		{
			int ApparenceCost = 0;

			switch (m_Appearance)
			{
				case AppearanceEnum.None:
					break;
				case AppearanceEnum.Monstrueux:
					ApparenceCost -= 1000;
					break;
				case AppearanceEnum.Hideux:
					ApparenceCost -= 875;
					break;
				case AppearanceEnum.Repoussant:
					ApparenceCost -= 750;
					break;
				case AppearanceEnum.Affreux:
					ApparenceCost -= 625;
					break;
				case AppearanceEnum.Laid:
					ApparenceCost -= 500;
					break;
				case AppearanceEnum.Moche:
					ApparenceCost -= 250;
					break;
				case AppearanceEnum.Banal:
					ApparenceCost = 0;
					break;
				case AppearanceEnum.Commun:
					ApparenceCost += 125;
					break;
				case AppearanceEnum.Mignon:
					ApparenceCost += 250;
					break;
				case AppearanceEnum.Charmant:
					ApparenceCost += 500;
					break;
				case AppearanceEnum.Beau:
					ApparenceCost += 750;
					break;
				case AppearanceEnum.Elegant:
					ApparenceCost += 1000;
					break;
				case AppearanceEnum.Seduisant:
					ApparenceCost += 1250;
					break;
				case AppearanceEnum.Ravissant:
					ApparenceCost += 1500;
					break;
				case AppearanceEnum.Envoutant:
					ApparenceCost += 1750;
					break;
				case AppearanceEnum.Fascinant:
					ApparenceCost += 2000;
					break;
				case AppearanceEnum.Eblouissant:
					ApparenceCost += 3500;
					break;
				case AppearanceEnum.Angelique:
					ApparenceCost += 5000;
					break;
				default:
					break;
			}

			return ApparenceCost;
		}


		public int GrandeurCost()
		{
			int GrandeurCost = 0;

			switch (m_Grandeur)
			{
				case GrandeurEnum.None:
					break;
				case GrandeurEnum.tresPetit:
					GrandeurCost += 1000;
					break;
				case GrandeurEnum.Petit:
					GrandeurCost += 500;
					break;
				case GrandeurEnum.PlutotPetit:
					GrandeurCost += 250;
					break;
				case GrandeurEnum.Moyen:
					GrandeurCost += 0;
					break;
				case GrandeurEnum.PlutotGrand:
					GrandeurCost += 250;
					break;
				case GrandeurEnum.Grand:
					GrandeurCost += 500;
					break;
				case GrandeurEnum.TresGrand:
					GrandeurCost += 1000;
					break;
				case GrandeurEnum.Colossale:
					GrandeurCost += 5000;
					break;
				default:
					break;
			}


			return GrandeurCost;
		}

		public int GrosseurCost()
		{
			int GrosseurCost = 0;

			switch (m_Grosseur)
			{
				case GrosseurEnum.None:
					break;
				case GrosseurEnum.Fluet:
					GrosseurCost -= 500;
					break;
				case GrosseurEnum.Maigre:
					GrosseurCost += 250;
					break;
				case GrosseurEnum.Mince:
					GrosseurCost += 1000;
					break;
				case GrosseurEnum.Elance:
					GrosseurCost += 1000;
					break;
				case GrosseurEnum.Svelte:
					GrosseurCost += 1000;
					break;
				case GrosseurEnum.Bedonnant:
					GrosseurCost -= 500;
					break;
				case GrosseurEnum.BienEnChair:
					GrosseurCost -= 750;
					break;
				case GrosseurEnum.Corpulent:
					GrosseurCost -= 1000;
					break;
				default:
					break;
			}


			return GrosseurCost;
		}


		public int TypeCost()
		{
			int typeCost = 0;

			switch (TypeEsclave)
			{
				case SlaveType.Aucun:
					break;
				case SlaveType.Menestrel:
					typeCost += 1000;
					break;
				case SlaveType.Barde:
					typeCost += 2000;
					break;
				case SlaveType.Mendiant:
					typeCost += 125;
					break;
				case SlaveType.Combatant:
					typeCost += 2500;
					break;
				case SlaveType.Paysan:
					typeCost += 0;
					break;
				case SlaveType.Ranger:
					break;
				case SlaveType.Archer:
					typeCost += 2500;
					break;
				case SlaveType.Marin:
					typeCost += 1000;
					break;
				case SlaveType.Voleur:
					typeCost += 1000;
					break;
				default:
					break;
			}


			return typeCost;


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

			return "Aucune";
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

			return "Aucune";
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

			return "Aucune";
		}

	}


}
