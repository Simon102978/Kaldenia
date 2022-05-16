#region References
using Server.Network;
using System.Reflection;
using System;
using System.Collections.Generic;
using Server.Items;
using Server.Custom.Misc;
using System.Collections;
using Server.Custom;
using Server.Movement;

#endregion

namespace Server.Mobiles
{


	public partial class CustomPlayerMobile : PlayerMobile
	{
		public static List<SkillName> SkillGeneral = new List<SkillName>() { SkillName.Mining, SkillName.Lumberjacking, SkillName.Fishing, SkillName.MagicResist };

		private GrandeurEnum m_Grandeur;
		private GrosseurEnum m_Grosseur;
		private AppearanceEnum m_Beaute;

		private Classe m_ClassePrimaire;
		private Classe m_ClasseSecondaire;
		private Classe m_Metier;

		private Container m_Corps;
		private int m_StatAttente;
		private int m_fe;
		private int m_feAttente;
		private int m_TotalFE;
		private DateTime m_lastLoginTime;
		private TimeSpan m_nextFETime;

		private God m_God = God.GetGod(-1);
		private AffinityDictionary m_MagicAfinity;
		private List<int> m_QuickSpells = new List<int>();
		private Deguisement m_Deguisement = null;

		private Race m_BaseRace;
		private bool m_BaseFemale;
		private int m_BaseHue;


		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastDeathTime { get; private set; }
		public double DeathDuration => 0.25; //minutes

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime EndOfVulnerabilityTime { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Vulnerability { get; set; }
		public int VulnerabilityDuration => 1; //minutes

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime PreventPvpAttackTime { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool PreventPvpAttack { get; set; }
		public int PreventPvpAttackDuration => 1; //minutes

		[CommandProperty(AccessLevel.GameMaster)]
		public GrosseurEnum Grosseur { get => m_Grosseur; set => m_Grosseur = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public AppearanceEnum Beaute { get => m_Beaute; set => m_Beaute = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Classe ClassePrimaire
		{
			get => m_ClassePrimaire;
			set
			{
				if (CheckClassePrimaire(value))
				{
					RecalculeClasse(value, 1);

					m_ClassePrimaire = value; // S'assurer que le metier, soit un metier...


				}
			}

		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Classe ClasseSecondaire {
			get => m_ClasseSecondaire;
			set
			{
				if (CheckClasseSecondaire(value))
				{
					RecalculeClasse(value, 2);

					m_ClasseSecondaire = value; // S'assurer que le metier, soit un metier...

				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Classe Metier
		{
			get => m_Metier;
			set
			{
				if (value.ClasseType == ClasseType.Metier || value.ClasseType == ClasseType.None)
				{
					if (CheckMetier(value))
					{
						RecalculeClasse(value, 3);
						m_Metier = value;  // S'assurer que le metier, soit un metier...
					}

					// S'assurer que le metier, soit un metier...
				}
			}

		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastLoginTime
		{
			get { return m_lastLoginTime; }
			set { m_lastLoginTime = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan NextFETime
		{
			get { return m_nextFETime; }
			set { m_nextFETime = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int StatAttente { get { return m_StatAttente; } set { m_StatAttente = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int FE { get { return m_fe; } set { m_fe = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int FETotal { get { return m_TotalFE; } set { m_TotalFE = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int FEAttente { get { return m_feAttente; } set { m_feAttente = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Armure { get => m_ClassePrimaire.Armor + m_ClasseSecondaire.Armor; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Container Corps { get { return m_Corps; } set { m_Corps = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public God God
		{
			get => m_God;
			set
			{

				MagicAfinity.ChangeGod(value);


				m_God = value; // S'assurer que le metier, soit un metier...


			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public AffinityDictionary MagicAfinity { get { return m_MagicAfinity; } set { m_MagicAfinity = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Item ChosenSpellbook { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Deguisement Deguisement { get { return m_Deguisement; } set { m_Deguisement = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Race BaseRace 
		{ 
			get 
			{ 
				return m_BaseRace; 
			} 
			set 
			{ 
				m_BaseRace = value;
				Race = value;
			} 
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool BaseFemale
		{
			get
			{
				return m_BaseFemale;
			}
			set
			{
				m_BaseFemale = value;
				Female = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseHue
		{
			get
			{
				return m_BaseHue;
			}
			set
			{
				m_BaseHue = value;
				Hue = value;
			}
		}


		public List<int> QuickSpells
		{
			get { return m_QuickSpells; }
			set { m_QuickSpells = value; }
		}

		public CustomPlayerMobile()
		{

			MagicAfinity = new AffinityDictionary(this);
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Vulnerability)
			{
				list.Add(1050045, "<\th3><basefont color=#FF8000>" + (Female ? "ASSOMÉE" : "ASSOMÉ") + "</basefont></h3>\t");
			}


			if (NameMod == null)
			{
				list.Add(1050045, "{0}, \t{1}\t", Race.Name, Apparence()); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
				list.Add(1050045, "{0}, \t{1}\t", GrandeurString(), GrosseurString());
			}


		}

		#region Apparence
		public string Apparence()
		{
			AppearanceEnum gros = m_Beaute;

			if (Deguise)
			{
				gros = Deguisement.Appearance;
			}

			if (gros < 0)
			{
				gros = 0;
			}
			else if ((int)gros > 19)
			{
				gros = (AppearanceEnum)19;
			}

			var type = typeof(AppearanceEnum);
			MemberInfo[] memberInfo = type.GetMember(gros.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}


		public string GrosseurString()
		{

			GrosseurEnum gros = m_Grosseur;

			if (Deguise)
			{
				gros = Deguisement.Grosseur;
			}


			if (gros < 0)
			{
				gros = 0;
			}
			else if ((int)gros > 8)
			{
				gros = (GrosseurEnum)8;
			}

			var type = typeof(GrosseurEnum);
			MemberInfo[] memberInfo = type.GetMember(gros.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}

		public string GrandeurString()
		{
			/*        Identite id = GetIdentite();

                    if (id != null && id.Grandeur != GrandeurEnum.None)
                    {
                        return id.Grandeur.ToString();
                    }*/

			GrandeurEnum gros = m_Grandeur;

			if (Deguise)
			{
				gros = Deguisement.Grandeur;
			}




			var type = typeof(GrandeurEnum);
			MemberInfo[] memberInfo = type.GetMember(gros.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);



		}
		#endregion

		#region Déguisement

		public override string DeguisementName()
		{
			if (Deguise) // Devrais pas etre autre choses
			{
				return Deguisement.Name;

			}
			return base.DeguisementName();
		}

		public override string DeguisementProfile()
		{
			if (Deguise) // Devrais pas etre autre choses
			{
				return Deguisement.GetProfile();
			}
			return base.DeguisementName();
		}

		public bool DeguisementAction(DeguisementAction action)
		{
			double skill = Skills[SkillName.Hiding].Value;

			switch (action)
			{
				case Server.DeguisementAction.Nom:
					{
						if (skill > 50)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Titre:
					{
						if (skill > 30)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Sexe:
					{
						if (skill > 75)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Race:
					{
						if (skill > 80)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Racehue:
					{
						if (skill > 80)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Apparence:
					{
						if (skill > 60)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Grandeur:
					{
						if (skill > 65)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Grosseur:
					{
						if (skill > 65)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				case Server.DeguisementAction.Paperdoll:
					{
						if (skill > 70)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				default:
					return true;
			}






		}

		#endregion

		public CustomPlayerMobile(Serial s)
			: base(s)
		{
			MagicAfinity = new AffinityDictionary(this);
		}

		public override bool OnEquip(Item item)
		{
			if (item is BaseArmor)
			{
				int req = 10;

				BaseArmor armor = (BaseArmor)item;

				switch (armor.MaterialType)
				{
					case ArmorMaterialType.Cloth:
						req = 0;
						break;
					case ArmorMaterialType.Leather:
						req = 1;
						break;
					case ArmorMaterialType.Studded:
						req = 2;
						break;
					case ArmorMaterialType.Bone:
						req = 3;
						break;
					case ArmorMaterialType.Ringmail:
						req = 4;
						break;
					case ArmorMaterialType.Chainmail:
						req = 5;
						break;
					case ArmorMaterialType.Plate:
						req = 6;
						break;
					case ArmorMaterialType.Dragon:
						req = 6;
						break;
					case ArmorMaterialType.Wood:
						req = 4;
						break;
					case ArmorMaterialType.Stone:
						req = 4;
						break;
					default:
						req = 10;
						break;
				}




				if (Armure < req)
				{
					SendMessage("Armure requise : " + req);
					return false;
				}
			}

			return base.OnEquip(item);
		}

		#region equitation
		public virtual bool CheckEquitation(EquitationType type)
		{
			return CheckEquitation(type, Location);
		}

		public int TileToDontFall { get; set; }
		// 0   1    2    3    4    5    6    7    8    9    10   11   12
		private static int[] m_RunningTable = new int[] {100, 100, 100, 050, 025, 000, 000, 000, 000, 000, 000, 000 };
		private static int[] m_BeingAttackedTable = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 075, 050, 005 };
		private static int[] m_MeleeAttackingTable = new int[] { 100, 100, 100, 100, 100, 075, 050, 025, 005, 000, 000 };
		private static int[] m_CastAttackingTable = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
		private static int[] m_RangedAttackingTable = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
		private static int[] m_DismountTable = new int[] { 100, 100, 100, 090, 080, 075, 070, 065, 060, 055, 050 };

		public virtual bool CheckEquitation(EquitationType type, Point3D oldLocation)
		{
			//true s'il ne tombe pas, false s'il tombe

			if (!Mounted)
				return true;

			if (AccessLevel >= AccessLevel.GameMaster)
				return true;

			if (Map == null)
				return true;

			int chanceToFall = 0;
			int equitation = (int)(Skills[SkillName.Equitation].Value / 10);

			if (equitation < 0)
				equitation = 0;

			if (equitation > 10)
				equitation = 10;

			switch (type)
			{
				case EquitationType.Running: chanceToFall = m_RunningTable[equitation]; break;
				case EquitationType.BeingAttacked: chanceToFall = m_BeingAttackedTable[equitation]; break;
				case EquitationType.MeleeAttacking: chanceToFall = m_MeleeAttackingTable[equitation]; break;
				case EquitationType.CastAttacking: chanceToFall = m_CastAttackingTable[equitation]; break;
				case EquitationType.RangedAttacking: chanceToFall = m_RangedAttackingTable[equitation]; break;
				case EquitationType.Dismount: chanceToFall = m_DismountTable[equitation]; break;
			}

			if (chanceToFall < 0)
				chanceToFall = 0;

			if (chanceToFall <= Utility.RandomMinMax(0, 100))
				return true;

			if (type == EquitationType.Running)
			{
				//				if (TileToDontFall > 0)
				//					return true;

				TileType tile = Deplacement.GetTileType(this);

				if (tile == TileType.Other || tile == TileType.Dirt)
					return true;
			}

			BaseMount mount = (BaseMount)Mount;

			mount.Rider = null;
			mount.Location = oldLocation;

			TileToDontFall = 3;

			Timer.DelayCall(TimeSpan.FromSeconds(0.3), new TimerStateCallback(Equitation_Callback), mount);

			BeginAction(typeof(BaseMount));
			double seconds = 12.0 - (Skills[SkillName.Equitation].Value / 10);

			SetMountBlock(BlockMountType.DismountRecovery, TimeSpan.FromSeconds(seconds), false);


			return false;
		}

		private void Equitation_Callback(object state)
		{
			BaseMount mount = (BaseMount)state;

			mount.Animate(5, 5, 1, true, false, 0);
			Animate(22, 5, 1, true, false, 0);

			Damage(Utility.RandomMinMax(10, 20));
		}

		#endregion

		public HashSet<SkillName> SkillDisponible()
		{
			HashSet<SkillName> list = new HashSet<SkillName>();


			foreach (SkillName item in ClassePrimaire.Skill)
			{
				list.Add(item);
			}

			foreach (SkillName item in ClasseSecondaire.Skill)
			{
				list.Add(item);
			}


			foreach (SkillName item in Metier.Skill)
			{
				list.Add(item);
			}

			foreach (SkillName item in SkillGeneral)
			{
				list.Add(item);
			}


			return list;

		}

		public int GetAffinityValue(MagieType affinity)
		{
			return MagicAfinity.GetValue(affinity);
		}

		#region Classe


		public bool ClassSkill(SkillName skills)
		{

			foreach (SkillName item in ClassePrimaire.Skill)
			{
				if (item == skills)
				{
					return true;
				}
			}

			foreach (SkillName item in ClasseSecondaire.Skill)
			{
				if (item == skills)
				{
					return true;
				}
			}


			foreach (SkillName item in Metier.Skill)
			{
				if (item == skills)
				{
					return true;
				}
			}

			foreach (SkillName item in SkillGeneral)
			{
				if (item == skills)
				{
					return true;
				}
			}

			return false;

		}

		public bool CheckClassePrimaire(Classe cl)
		{
			if (cl == ClasseSecondaire)
			{
				m_ClasseSecondaire = Classe.GetClasse(-1);
			}
			else if (cl == Metier)
			{
				Metier = Classe.GetClasse(-1);
			}

			return true;
		}

		public bool CheckClasseSecondaire(Classe cl)
		{
			if (cl == ClassePrimaire)
			{
				m_ClassePrimaire = Classe.GetClasse(-1);
			}
			else if (cl == Metier)
			{
				Metier = Classe.GetClasse(-1);
			}

			return true;
		}

		public bool CheckMetier(Classe cl)
		{
			if (cl == ClassePrimaire)
			{
				m_ClassePrimaire = Classe.GetClasse(-1);
			}
			else if (cl == ClasseSecondaire)
			{
				ClasseSecondaire = Classe.GetClasse(-1);
			}

			return true;
		}

		public void RecalculeClasse(Classe NewClass, int type)
		{

			switch (type)
			{
				case 1:
					{
						if (ClassePrimaire != null)
						{
							foreach (SkillName item in ClassePrimaire.Skill)
							{
								if (Metier.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (NewClass.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (ClasseSecondaire.ContainSkill(item))
								{
									// Secondaire a 30, et primaire à 50, donc perte de 20 de skills.
									Skills[item].Base -= 20;
								}
								else
								{
									int Arecuperer = (int)(Skills[item].Base - 50);
									Skills[item].Base = 0;
									m_feAttente += Arecuperer;
								}
							}

							foreach (SkillName item in NewClass.Skill)
							{
								if (Metier.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (ClassePrimaire.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (ClasseSecondaire.ContainSkill(item))
								{
									// Secondaire a 30, et primaire à 50, donc perte de 20 de skills.
									Skills[item].Base += 20;
								}
								else
								{
									Skills[item].Base = 50;
								}
							}
						}

						// classe primaire
					
						break;
					}
				case 2:
					{
						// Classe secondaire

						if (ClasseSecondaire != null)
						{
							foreach (SkillName item in ClasseSecondaire.Skill)
							{
								if (ClassePrimaire.ContainSkill(item))
								{
									// rien a faire, classe primaire est plus elevés.
								}
								else if (NewClass.ContainSkill(item))
								{
									// rien a faire, tout deux a 30...
								}
								else if (Metier.ContainSkill(item))
								{
									// rien a faire, metier à 50...
								}
								else
								{
									int Arecuperer = (int)(Skills[item].Value - 30);
									Skills[item].Base = 0;
									m_feAttente += Arecuperer;
								}
							}

							foreach (SkillName item in NewClass.Skill)
							{
								if (ClassePrimaire.ContainSkill(item))
								{
									// rien a faire, classe primaire est plus elevés.
								}
								else if (ClasseSecondaire.ContainSkill(item))
								{
									// rien a faire, tout deux a 30...
								}
								else if (Metier.ContainSkill(item))
								{
									// rien a faire, metier à 50...
								}
								else
								{
									Skills[item].Base = 30;
								}
							}
						}

						
						break;
					}
				case 3:
					{
						// Metier

						if (Metier != null)
						{
							foreach (SkillName item in Metier.Skill)
							{
								if (ClassePrimaire.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (NewClass.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (ClasseSecondaire.ContainSkill(item))
								{
									// Secondaire a 30, et primaire à 50, donc perte de 20 de skills.
									Skills[item].Base -= 20;
								}
								else
								{
									int Arecuperer = (int)(Skills[item].Base - 50);
									Skills[item].Base = 0;
									m_feAttente += Arecuperer;
								}
							}

							foreach (SkillName item in NewClass.Skill)
							{
								if (ClassePrimaire.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (Metier.ContainSkill(item))
								{
									// rien a faire, tout deux a 50...
								}
								else if (ClasseSecondaire.ContainSkill(item))
								{

									Skills[item].Base += 20;
								}
								else
								{
									Skills[item].Base = 50;
								}
							}
						}

						


						break;
					}

				default:
					break;
			}
		}

		#endregion

		#region Stats

		public bool CanDecreaseStat(StatType stats)
		{
			if (StatAttente >= 10)
			{
				return false;
			}

			switch (stats)
			{
				case StatType.Str:
					if (RawStr == 25)
					{
						return false;
					}
					else
					{
						return true;
					}				
				case StatType.Dex:
					if (RawDex == 25)
					{
						return false;
					}
					else
					{
						return true;
					}
				case StatType.Int:
					if (RawInt == 25)
					{
						return false;
					}
					else
					{
						return true;
					}
				default:
					return false;
			}
		}

		public bool CanIncreaseStat(StatType stats)
		{

			if (RawDex + RawStr + RawInt + StatAttente >= 225)
			{
				return false;
			}


			switch (stats)
			{
				case StatType.Str:
					{
						if (RawStr == 100)
						{
							return false;
						}
						else
						{
							return true;
						}				
					}					
				case StatType.Dex:
					{
						if (RawDex == 100)
						{
							return false;
						}
						else
						{
							return true;
						}
					}
				case StatType.Int:
					{
						if (RawInt == 100)
						{
							return false;
						}
						else
						{
							return true;
						}
					}
				case StatType.All:
					return false;
				default:
					return false;
					break;
			}
		}

		public void IncreaseStat(StatType stats)
		{
			if (CanIncreaseStat(stats))
			{
				switch (stats)
				{
					case StatType.Str:
						RawStr++;
						break;
					case StatType.Dex:
						RawDex++;
						break;
					case StatType.Int:
						RawInt++;
						break;
				}
			}			
		}

		public void DecreaseStat(StatType stats)
		{
			if (CanDecreaseStat(stats))
			{
				switch (stats)
				{
					case StatType.Str:
						RawStr--;
						m_StatAttente++;
						break;
					case StatType.Dex:
						RawDex--;
						m_StatAttente++;
						break;
					case StatType.Int:
						RawInt--;
						m_StatAttente++;
						break;
				}
			}
		}


		#endregion

		#region Skills
		public bool CanIncreaseSkill(SkillName skills)
		{
			if (m_fe == 0)
			{
				return false;
			}
			else if (Skills[skills].Value == 100)
			{
				return false;
			}
			if (!ClassSkill(skills))
			{
				return false;
			}
			return true;
		}

		public void IncreaseSkills(SkillName skills)
		{

			if (CanIncreaseSkill(skills))
			{
				Skills[skills].Base += 1;
				m_fe--;
			}



		}

		public void DecreaseSkills(SkillName skills)
		{
			if (CanDecreaseSkill(skills))
			{
				Skills[skills].Base -= 1;
				m_feAttente++;
			}
		}

		public bool CanDecreaseSkill(SkillName skills)
		{

			if (Skills[skills].Value > 50) // sert à rien de calculer ca..
			{
				return true;
			}
			else if (Skills[skills].Value == 0) // sert à rien de calculer ca..
			{
				return false;
			}




			foreach (SkillName item in ClassePrimaire.Skill)
			{

				if (item == skills)
				{
					return false;
				}
			}

			foreach (SkillName item in Metier.Skill)
			{

				if (item == skills)
				{
					return false;
				}
			}

			foreach (SkillName item in ClasseSecondaire.Skill)
			{

				if (item == skills && Skills[skills].Value == 30)
				{
					return false;
				}
			}

			foreach (SkillName item in SkillGeneral)
			{
				if (item == skills && Skills[skills].Value == 30)
				{
					return false;
				}
			}
			return true;
		}

		#endregion

		#region Mort

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			LastDeathTime = DateTime.Now;

			if (!Vulnerability)
			{
				Frozen = true;
				Timer.DelayCall(TimeSpan.FromMinutes(DeathDuration), new TimerStateCallback(RessuciterOverTime_Callback), this);
			}
			else
			{
				if (Deguise)
				{
					Deguisement.RemoveDeguisement();
				}
			}

			Vulnerability = true;
			EndOfVulnerabilityTime = DateTime.Now + TimeSpan.FromMinutes(DeathDuration + VulnerabilityDuration);
			Timer.DelayCall(TimeSpan.FromMinutes(DeathDuration + VulnerabilityDuration), new TimerStateCallback(RemoveVulnerability_Callback), this);

			PreventPvpAttack = true;
			PreventPvpAttackTime = DateTime.Now + TimeSpan.FromMinutes(DeathDuration + PreventPvpAttackDuration);
			Timer.DelayCall(TimeSpan.FromMinutes(DeathDuration + PreventPvpAttackDuration), new TimerStateCallback(RetourCombatPvP_Callback), this);

			Server.Spells.Fifth.IncognitoSpell.StopTimer(this);
		}


		public override void OnAfterResurrect()
		{
			base.OnAfterResurrect();

			Frozen = false;

			if (Corpse != null)
			{
				ArrayList list = new ArrayList();

				foreach (Item item in Corpse.Items)
				{
					list.Add(item);
				}

				foreach (Item item in list)
				{
					if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
						item.Delete();

					if (item is BaseRaceGumps || (Corpse is Corpse && ((Corpse)Corpse).EquipItems.Contains(item)))
					{
						if (!EquipItem(item))
							AddToBackpack(item);
					}
					else
					{
						AddToBackpack(item);
					}
				}

				Corpse.Delete();
			}


			SendMessage(HueManager.GetHue(HueManagerList.Red), "Vous vous relevez péniblement.", VulnerabilityDuration);
			SendMessage(HueManager.GetHue(HueManagerList.Red), "Vous êtes vulnérable pendant les {0} prochaines minutes.", VulnerabilityDuration);
			SendMessage(HueManager.GetHue(HueManagerList.Red), "Si vous tombez au combat, vous serez envoyé{0} dans le monde des esprits.", Female ? "e" : "");

		}

		private static void RetourCombatPvP_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)state;

				if (pm.PreventPvpAttack && pm.PreventPvpAttackTime <= DateTime.Now)
				{
					pm.PreventPvpAttack = false;
					pm.SendMessage(HueManager.GetHue(HueManagerList.Green), "Vous pouvez maintenant attaquer d'autres joueurs.");
				}
			}
		}

		private static void RessuciterOverTime_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)state;

				if (!pm.Alive)
				{

					pm.Resurrect();

				}
			}
		}

		private static void RemoveVulnerability_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)state;

				if (pm.Vulnerability && pm.EndOfVulnerabilityTime <= DateTime.Now)
				{
					pm.Vulnerability = false;
					pm.SendMessage(HueManager.GetHue(HueManagerList.Green), "Vous n'êtes plus vulnérable. La prochaine fois que vous tomberez au combat, vous serez assomé.");
				}
			}
		}

		public override bool CanBeHarmful(IDamageable damageable, bool message, bool ignoreOurBlessedness, bool ignorePeaceCheck)
		{
			if (PreventPvpAttack && damageable is CustomPlayerMobile)
			{
				SendMessage("Vous ne pouvez pas attaquer un joueur pendant encore {0} minute{1}.", (PreventPvpAttackTime - DateTime.Now).Minutes, (PreventPvpAttackTime - DateTime.Now).Minutes > 1 ? "s" : "");
				return false;
			}

			return base.CanBeHarmful(damageable, message, ignoreOurBlessedness, ignorePeaceCheck);
		}
		#endregion

		public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();


			switch (version)
			{
				case 11:
					{
						m_BaseHue = reader.ReadInt();
						goto case 10;

					}
				case 10:
					{
						m_BaseRace = Server.BaseRace.GetRace(reader.ReadInt());
						m_BaseFemale = reader.ReadBool();

						goto case 9;
					}

				case 9:
					{
						
						m_Deguisement = Deguisement.Deserialize(reader);

						goto case 8;
					}
				case 8:
					{
						ChosenSpellbook = reader.ReadItem();

						goto case 7;
					}

				case 7:
					{
						QuickSpells = new List<int>();
						int count = reader.ReadInt();
						for (int i = 0; i < count; i++)
							QuickSpells.Add(reader.ReadInt());

						goto case 6;
					}


				case 6:
					{
						God = God.GetGod(reader.ReadInt());

						MagicAfinity = new AffinityDictionary(this, reader);
					
						/*
												int count = reader.ReadInt();

												for (int i = 0; i < count; i++)
												{

													MagieType affinity = (MagieType)reader.ReadInt();

													int affinityValue = reader.ReadInt();

													if (m_MagicAfinity.ContainsKey(affinity))
													{
														m_MagicAfinity[affinity] += affinityValue;
													}
													else
													{
														m_MagicAfinity.Add(affinity, affinityValue);
													}


												}*/
						goto case 5;
					}
				case 5:
					{
						m_feAttente = reader.ReadInt();

						goto case 4;

					}
				case 4:
					{
						m_feAttente = reader.ReadInt();

						goto case 3;
					}
				case 3:
					{
						m_fe = reader.ReadInt();
						m_lastLoginTime = reader.ReadDateTime();
						m_nextFETime = reader.ReadTimeSpan();
						m_TotalFE = reader.ReadInt();


						goto case 2;
					}
				case 2:
					{
						m_ClassePrimaire = Classe.GetClasse(reader.ReadInt());
						m_ClasseSecondaire = Classe.GetClasse(reader.ReadInt());
						m_Metier = Classe.GetClasse(reader.ReadInt());
						goto case 1;
					}
				case 1:
					{
						m_Grandeur = (GrandeurEnum)reader.ReadInt();
						m_Grosseur = (GrosseurEnum)reader.ReadInt();
						m_Beaute = (AppearanceEnum)reader.ReadInt();
						goto case 0;
					}
				case 0:
                    {

                        break;
                    }
            }

        }

        public override void Serialize(GenericWriter writer)
        {        
            base.Serialize(writer);

            writer.Write(11); // version

			if (m_BaseHue == null)
			{
				m_BaseHue = Hue;
			}

			writer.Write(Hue);


			if (m_BaseRace == null)
			{
				m_BaseRace = Race;
			}

			if (m_BaseFemale == null)
			{
				m_BaseFemale = Female;
			}

			writer.Write(m_BaseRace.RaceID);
			writer.Write(m_BaseFemale);



			if (m_Deguisement == null)
			{
				m_Deguisement = new Deguisement(this);
			}

			
			m_Deguisement.Serialize(writer);
			


			

			writer.Write(ChosenSpellbook);

			writer.Write(QuickSpells.Count);
			for (int i = 0; i < QuickSpells.Count; i++)
				writer.Write((int)QuickSpells[i]);

			writer.Write(God.GodID);

			m_MagicAfinity.Serialize(writer);

			writer.Write(m_StatAttente);
			writer.Write(m_feAttente);
			writer.Write(m_fe);
			writer.Write(m_lastLoginTime);
			writer.Write(m_nextFETime);
			writer.Write(m_TotalFE);



			writer.Write((int)m_ClassePrimaire.ClasseID);
			writer.Write((int)m_ClasseSecondaire.ClasseID);
			writer.Write((int)m_Metier.ClasseID);



			writer.Write((int)m_Grandeur);
			writer.Write((int)m_Grosseur);
			writer.Write((int)m_Beaute);


		}
	}
}
