using Server.Engines.CannedEvil;
using Server.Items;
using Server.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName("Corp de Titus")]
	public class Titus : BasePeerless
	{
		public static List<string> RouxParole = new List<string>()
		{
			"Rejoins nous dans la ROUX-Volution !",
			"Traitre ! Cesse de vivre parmis les roux-étiques !",
			"La rousseur est la vie !",
			"Je te sauverais dans la mort !",
			"Tu pourriras avec les roux-étiques !"

		};

		public static List<string> NonRouxParole = new List<string>()
		{
			"Meurt roux-étique !",
			"ROUCISTE ! ",
			"PAUVRE CON ! Meurt ! ",

		};

		public static List<string> EnrageParole = new List<string>()
		{
			"MOURREEZZZ ! FILS DE NON ROUX !",
			"JE VAIS TE BRULER VIF ! ROUCISTE !",
			"GRRRR! TU VAS CREUVER À LA FIN ?",
			"Vous vous moquerez plus de ma rousseur !"
		};


		public DateTime DelayAoe1;
		public DateTime DelayOnHit1;
		public DateTime m_Change;
		public DateTime m_GlobalTimer;
		public DateTime m_Teleport;
		public DateTime m_NextSpawn;



		public virtual int StrikingRange => 12;


		private bool m_Enrage = false;

		public override bool AutoDispel => true;
		public override double AutoDispelChance => 1.0;
		public override bool BardImmune => true;
		public override bool Unprovokable => true;
		public override bool Uncalmable => true;
		public override Poison PoisonImmune => Poison.Lethal;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Enrage
		{
			get => m_Enrage;
			set
			{
				if (value && !m_Enrage)
				{
					m_Enrage = value;
					Enrager();
				}
				else
				{
					m_Enrage = value;
				}
			}
		}
		public override bool CanBeParagon => false;

		public DateTime m_LastParole = DateTime.MinValue;

		public override TribeType Tribe => TribeType.Ophidian;

		[Constructable]
		public Titus()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Titus";
			Title = "Bébé Titan Roux";
			Body = 76;
			BaseSoundID = 609;
			Hue = 1395;

			SetStr(600, 700);
			SetDex(76, 82);
			SetInt(76, 85);


			SetHits(5000);
			SetStam(507, 669);
			SetMana(1200, 1300);

			SetDamage(23, 27);

			//		SetDamage(2, 3);

			SetDamageType(ResistanceType.Physical, 80);
			SetDamageType(ResistanceType.Fire, 20);

			SetResistance(ResistanceType.Physical, 75, 85);
			SetResistance(ResistanceType.Fire, 60, 70);
			SetResistance(ResistanceType.Cold, 30, 40);
			SetResistance(ResistanceType.Poison, 55, 65);
			SetResistance(ResistanceType.Energy, 50, 60);

			SetSkill(SkillName.Wrestling, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Poisoning, 120.0);

			SetWeaponAbility(WeaponAbility.ParalyzingBlow);
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(1050045, "Le bebe titan roux"); // ~1_PREFIX~~2_NAME~~3_SUFFIX~

			if (Enrage)
			{
				list.Add(1050045, "<\th3><basefont color=#FF8000>Enrage</basefont></h3>\t");
			}
		}


		public override void OnThink()
		{
			base.OnThink();
			Parole();

			if (m_GlobalTimer < DateTime.UtcNow && Warmode)
			{

				if (Enrage)
				{
					switch (Utility.Random(3))
					{
						case 0:
							VagueIncendiaire();
							break;
						case 1:
							ChangeOpponent();
							break;
						case 2:
							SpawnEnrage();
							break;
						default:
							break;
					}				
				}
				else
				{
					switch (Utility.Random(3))
					{
						case 0:
							PrisonDeTerre();
							break;
						case 1:
							Teleport();
							break;
						case 2:
							SpawnNonEnrage();
							break;
						default:
							break;
					}				
				}				
				m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 5));
			}
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
			Parole();

		}


		public void Enrager()
		{
			AdjustSpeeds();
			Hue = 1197;

			Mana = ManaMax;
			Stam = StamMax;

			Say("WHAAAAAAAAAA !");

			SetWeaponAbility(WeaponAbility.MortalStrike);
			RemoveWeaponAbility(WeaponAbility.ParalyzingBlow);

		}

		public override void AdjustSpeeds()
		{
			double activeSpeed = 0.0;
			double passiveSpeed = 0.0;


			if (Enrage)
			{
				SpeedInfo.GetCustomSpeeds(this, ref activeSpeed, ref passiveSpeed);
			}
			else
			{
				SpeedInfo.GetSpeeds(this, ref activeSpeed, ref passiveSpeed);
			}

			ActiveSpeed = activeSpeed;
			PassiveSpeed = passiveSpeed;
			CurrentSpeed = passiveSpeed;
		}


		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			base.OnDamage(amount, from, willKill);

		


			if (!Enrage && (Hits  < 2500))
			{
				Enrage = true;
			}

			if (Enrage)
			{
				if (from.Weapon is BaseMeleeWeapon)
				{
					int dmg = 10; 

					AOS.Damage(from, this, dmg, 0, 100, 0, 0, 0); 

					MovingParticles(from, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
				}		
			}

			Parole();
		}

		public void Parole()
		{

			if (m_LastParole < DateTime.Now && Combatant != null)
			{
				if (Enrage)
				{
					Say(EnrageParole[Utility.Random(EnrageParole.Count)]);
				}
				else
				{
					if (Combatant is CustomPlayerMobile cp)
						if (cp.CheckRoux())
							Say(RouxParole[Utility.Random(RouxParole.Count)]);
						else
							Say(NonRouxParole[Utility.Random(NonRouxParole.Count)]);

				}


				m_LastParole = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 90));
			}





		}

		public override void AlterMeleeDamageTo(Mobile to, ref int damage)
		{

			Parole();

			if (Enrage)
			{
				if (DelayOnHit1 < DateTime.UtcNow)
				{
					HoofStomp();
				}
			}
			else
			{
				if (DelayOnHit1 < DateTime.UtcNow)
				{
					Cleave();
				}				
			}

			base.AlterMeleeDamageTo(to, ref damage);
		}


		public override void Attack(IDamageable e)
		{
			Parole();
			base.Attack(e);
		}


		public Titus(Serial serial)
			: base(serial)
		{
		}


		public override int Meat => 4;
		public override int TreasureMapLevel => 5;
		public override int Hides => 8;
		public override HideType HideType => HideType.Ancien;
		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Ancien;

		#region PrisondeTerre

		public void PrisonDeTerre()
		{


			if (Combatant != null &&  Combatant is Mobile Caster && DelayAoe1 < DateTime.UtcNow)
			{
				IPoint3D p = Caster.Location;

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Combatant.Map, 0x222);

				Point3D loc = new Point3D(p.X, p.Y, p.Z);
				int mushx;
				int mushy;
				int mushz;

				InternalItem firstFlamea = new InternalItem(Combatant.Location, Combatant.Map);
				mushx = loc.X - 2;
				mushy = loc.Y - 2;
				mushz = loc.Z;
				Point3D mushxyz = new Point3D(mushx, mushy, mushz);
				firstFlamea.MoveToWorld(mushxyz, Caster.Map);

				InternalItem firstFlamec = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X;
				mushy = loc.Y - 3;
				mushz = loc.Z;
				Point3D mushxyzb = new Point3D(mushx, mushy, mushz);
				firstFlamec.MoveToWorld(mushxyzb, Caster.Map);

				InternalItem firstFlamed = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 2;
				mushy = loc.Y - 2;
				mushz = loc.Z;
				Point3D mushxyzc = new Point3D(mushx, mushy, mushz);
				firstFlamed.MoveToWorld(mushxyzc, Caster.Map);

				InternalItem hiddenflame = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 2;
				mushy = loc.Y - 1;
				mushz = loc.Z;
				Point3D mushxyzhid = new Point3D(mushx, mushy, mushz);
				hiddenflame.MoveToWorld(mushxyzhid, Caster.Map);
				InternalItem hiddenrock = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 2;
				mushy = loc.Y + 1;
				mushz = loc.Z;
				Point3D rockaxyz = new Point3D(mushx, mushy, mushz);
				hiddenrock.MoveToWorld(rockaxyz, Caster.Map);
				InternalItem hiddenflamea = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X - 2;
				mushy = loc.Y - 1;
				mushz = loc.Z;
				Point3D mushxyzhida = new Point3D(mushx, mushy, mushz);
				hiddenflamea.MoveToWorld(mushxyzhida, Caster.Map);
				InternalItem hiddenrocks = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X - 2;
				mushy = loc.Y + 1;
				mushz = loc.Z;
				Point3D rocksaxyz = new Point3D(mushx, mushy, mushz);
				hiddenrocks.MoveToWorld(rocksaxyz, Caster.Map);
				InternalItem hiddenrocka = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 1;
				mushy = loc.Y + 2;
				mushz = loc.Z;
				Point3D rockbxyz = new Point3D(mushx, mushy, mushz);
				hiddenrocka.MoveToWorld(rockbxyz, Caster.Map);
				InternalItem hiddenrockb = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 1;
				mushy = loc.Y - 2;
				mushz = loc.Z;
				Point3D rockcxyz = new Point3D(mushx, mushy, mushz);
				hiddenrockb.MoveToWorld(rockcxyz, Caster.Map);
				InternalItem hiddenrockc = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X - 1;
				mushy = loc.Y - 2;
				mushz = loc.Z;
				Point3D rockdxyz = new Point3D(mushx, mushy, mushz);
				hiddenrockc.MoveToWorld(rockdxyz, Caster.Map);
				InternalItem hiddenrockd = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X - 1;
				mushy = loc.Y + 2;
				mushz = loc.Z;
				Point3D rockexyz = new Point3D(mushx, mushy, mushz);
				hiddenrockd.MoveToWorld(rockexyz, Caster.Map);
				InternalItem firstFlamee = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 3;
				mushy = loc.Y;
				mushz = loc.Z;
				Point3D mushxyzd = new Point3D(mushx, mushy, mushz);
				firstFlamee.MoveToWorld(mushxyzd, Caster.Map);
				InternalItem firstFlamef = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X + 2;
				mushy = loc.Y + 2;
				mushz = loc.Z;
				Point3D mushxyze = new Point3D(mushx, mushy, mushz);
				firstFlamef.MoveToWorld(mushxyze, Caster.Map);
				InternalItem firstFlameg = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X;
				mushy = loc.Y + 3;
				mushz = loc.Z;
				Point3D mushxyzf = new Point3D(mushx, mushy, mushz);
				firstFlameg.MoveToWorld(mushxyzf, Caster.Map);
				InternalItem firstFlameh = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X - 2;
				mushy = loc.Y + 2;
				mushz = loc.Z;
				Point3D mushxyzg = new Point3D(mushx, mushy, mushz);
				firstFlameh.MoveToWorld(mushxyzg, Caster.Map);
				InternalItem firstFlamei = new InternalItem(Caster.Location, Caster.Map);
				mushx = loc.X - 3;
				mushy = loc.Y;
				mushz = loc.Z;
				Point3D mushxyzh = new Point3D(mushx, mushy, mushz);
				firstFlamei.MoveToWorld(mushxyzh, Caster.Map);

				this.Location = Caster.Location;
				Emote("*Saute dans les aires et frappe le sol de toute ses forces*");

				DelayAoe1 = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(90, 180));
			}
			

			


		}


		[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private ArrayList frozen;

			public override bool CanBeLock => false;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(Point3D loc, Map map) : base(0x08E2)
			{
				Visible = true;
				Movable = false;
				ItemID = Utility.RandomList(2274, 2275, 2272, 2273, 2279, 2280);
				Name = "Pierre";
				MoveToWorld(loc, map);


				if (Deleted)
					return;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(30.0));
				m_Timer.Start();

				m_End = DateTime.Now + TimeSpan.FromSeconds(30.0);
			}

			public InternalItem(Serial serial) : base(serial)
			{
			}
			public override bool OnMoveOver(Mobile m)
			{
				m.SendMessage("La magie sur la pierre vous empêche de passé.");
				return false;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write((int)1); // version

				writer.Write(m_End - DateTime.Now);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				int version = reader.ReadInt();

				switch (version)
				{
					case 1:
						{
							TimeSpan duration = reader.ReadTimeSpan();

							m_Timer = new InternalTimer(this, duration);
							m_Timer.Start();

							m_End = DateTime.Now + duration;

							break;
						}
					case 0:
						{
							TimeSpan duration = TimeSpan.FromSeconds(10.0);

							m_Timer = new InternalTimer(this, duration);
							m_Timer.Start();

							m_End = DateTime.Now + duration;

							break;
						}
				}
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
					m_Timer.Stop();
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration) : base(duration)
				{
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		#endregion

		#region Cleave

		public void Cleave()
		{

			if (DelayOnHit1 < DateTime.UtcNow)
			{
				DelayOnHit1 = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 20)); // mis la, parce que sinon boucle infinie.

				int Range = 3;
				List<Mobile> targets = new List<Mobile>();

				IPooledEnumerable eable = this.GetMobilesInRange(Range);

				foreach (Mobile m in eable)
				{
					if (this != m  && !m.IsStaff())
					{
						if (m is BaseCreature bc && bc.Tribe == TribeType.Titusien)
						{
							continue;
						}



						targets.Add(m);
					}
				}

				eable.Free();

				Emote("*Frappes le sol*");

				if (targets.Count > 0)
				{

					int dmg = 25;



					for (int i = 0; i < targets.Count; ++i)
					{
						Mobile m = targets[i];


						DoHarmful(m);
						AOS.Damage(m, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

						m.Freeze(TimeSpan.FromSeconds(3));

					
					}
				}


			

			}





		}

		#endregion

		#region FlameWave


		public void VagueIncendiaire()
		{

			if (Combatant != null && Combatant is Mobile Caster && DelayAoe1 < DateTime.UtcNow)
			{
				new FlameWaveTimer(this).Start();

				DelayAoe1 = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(90, 180));
			}

		}


		internal class FlameWaveTimer : Timer
		{
			private Mobile m_From;
			private Point3D m_StartingLocation;
			private Map m_Map;
			private int m_Count;
			private Point3D m_Point;

			public FlameWaveTimer(Mobile from)
				: base(TimeSpan.FromMilliseconds(300.0), TimeSpan.FromMilliseconds(300.0))
			{
				m_From = from;
				m_StartingLocation = from.Location;
				m_Map = from.Map;
				m_Count = 0;
				m_Point = new Point3D();
				SetupDamage(from);
			}

			protected override void OnTick()
			{
				double dist = 0.0;

				for (int i = -m_Count; i < m_Count + 1; i++)
				{
					for (int j = -m_Count; j < m_Count + 1; j++)
					{
						m_Point.X = m_StartingLocation.X + i;
						m_Point.Y = m_StartingLocation.Y + j;
						m_Point.Z = m_Map.GetAverageZ(m_Point.X, m_Point.Y);
						dist = GetDist(m_StartingLocation, m_Point);
						if (dist < ((double)m_Count + 0.1) && dist > ((double)m_Count - 3.1))
						{
							Effects.SendLocationParticles(EffectItem.Create(m_Point, m_Map, EffectItem.DefaultDuration), 0x3709, 10, 30, 5052);
						}
					}
				}

				m_Count += 3;

				if (m_Count > 15)
					Stop();
			}

			private void SetupDamage(Mobile from)
			{
				foreach (Mobile m in from.GetMobilesInRange(10))
				{
					if (m != from && !m.IsStaff())
					{
						Timer.DelayCall(TimeSpan.FromMilliseconds(300 * (GetDist(m_StartingLocation, m.Location) / 3)), new TimerStateCallback(Hurt), m);
					}

					

				}
			}

			public void Hurt(object o)
			{
				Mobile m = o as Mobile;

				if (m_From == null || m == null || m.Deleted)
					return;


				int dmg = 50; // 5 + 20



				// It looked like it delt 67 damage, presuming 70% fire res thats about 223 damage delt before resistance.
				AOS.Damage(m, m_From, dmg, 0, 100, 0, 0, 0);

				ApplyBurn(m_From, m, dmg / 4, TimeSpan.FromMinutes(1));
				//     m.SendMessage("You are being burnt alive by the seering heat!");
			}
			private double GetDist(Point3D start, Point3D end)
			{
				int xdiff = start.X - end.X;
				int ydiff = start.Y - end.Y;
				return Math.Sqrt((xdiff * xdiff) + (ydiff * ydiff));
			}
		}

		#endregion

		#region Burn


		#region Brulures
		// Les brulures ont été mis ici, parce que plusieurs type de magie les utiliser, Feu, Froid (Engelure), TErre (Meteore). Et ca rendais plus simple de le mettre la, que faire des call croisés.
		// Ici commence les brulures :


	/*	public void ApplyBurn(Mobile attacker, Mobile defender, int pourcentage = 20)  // Ca l'a été créer pour permettre de faire un call directement à cette function, sans avoir à passer par on hit... Pour le sort saignement.
		{
			int Chance = Utility.Random(0, 100);

			int pourcent = pourcentage;

			if (Chance <= pourcent)
			{
				ApplyBurn(attacker, defender);
			}

		}*/

		public static void ApplyBurn(Mobile attacker, Mobile defender, int damage, TimeSpan duration)  // Ca l'a été créer pour permettre de faire un call directement à cette function, sans avoir à passer par on hit... Pour le sort saignement.
		{

			TransformContext context = TransformationSpellHelper.GetContext(defender);

		    if (IsBurning(defender))
			{
				return;
			}
			else if (context != null)
			{
				return;
			}


			//  attacker.SendLocalizedMessage(1060159); // Your target is bleeding!

			attacker.SendMessage(defender + " brule.");

			//defender.SendLocalizedMessage(1060160); // You are bleeding!

			defender.SendMessage("Vous êtes subissez les effets d'une brulure.");

			//      if (defender is PlayerMobile)
			{

				defender.DoSpeech("*subit les effets d'une brulure.*", new int[] { }, MessageType.Regular, defender.EmoteHue);

				//defender.LocalOverheadMessage(MessageType.Regular, 0x21, 1060757); // You are bleeding profusely
				//defender.NonlocalOverheadMessage(MessageType.Regular, 0x21, 1060758, defender.Name); // ~1_NAME~ is bleeding profusely
			}

			TimeSpan duree = duration; // Sauvegarde pour s'assurer qui ait toujours au moins 30 secondes de burn..

			if (duree.TotalSeconds < 30)
			{
				duree = TimeSpan.FromSeconds(30);
			}

			BeginBurn(defender, attacker, damage, duree);
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool IsBurning(Mobile m)
		{
			return m_Table.Contains(m);
		}

		public static void BeginBurn(Mobile m, Mobile from, int damage, TimeSpan duration)
		{
			Timer t = (Timer)m_Table[m];

			if (t != null)
				t.Stop();

			#region SA
			t = new InternalTimer(from, m, damage, duration);
			#endregion
			m_Table[m] = t;

			t.Start();
		}


		public static void DoBurn(Mobile m, Mobile from, int damage)
		{
			TransformContext context = TransformationSpellHelper.GetContext(m);

			if (!m.Alive)
			{
				EndBurn(m, false);
			}
			else
			{
				if (!m.Player)
					damage *= 4;

				AOS.Damage(m, from, damage, 0, 100, 0, 0, 0);
			}
		}

		public static void EndBurn(Mobile m, bool message)
		{
			if (IsBurning(m)) // Sanity check.
			{
				Timer t = (Timer)m_Table[m];

				if (t == null)
					return;

				t.Stop();
				m_Table.Remove(m);

				if (message)
					m.SendLocalizedMessage(1060167); // The bleeding wounds have healed, you are no longer bleeding!
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;
			private Mobile m_Mobile;
			private int damage;
			private int m_CountMax;


			private int m_Count;
			private double m_damageTotal = 0;

			#region SA
			public InternalTimer(Mobile from, Mobile m, int Damage, TimeSpan duration) : base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.0))
			{
				#endregion
				m_From = from;
				m_Mobile = m;
				damage = Damage;

				m_CountMax = (int)(duration.TotalSeconds / 2);

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{

				// Tout ce shenigan la pour gerer le fait que tu risque de faire 0 de dégats par tick ,et le serveur va l'arrondir a 0.
				double degat = (double)damage / (double)m_CountMax * 100;

				if (degat < 100)
				{
					m_damageTotal += degat;

					if (m_damageTotal >= 100)
					{
						degat = 1;
						m_damageTotal -= 100;
					}
					else
					{
						degat = 0;
					}
				}
				else
				{
					degat = degat / 100;
				}


				#region SA
				DoBurn(m_Mobile, m_From, (int)degat);
				#endregion

				if (++m_Count == m_CountMax)
					EndBurn(m_Mobile, true);
			}
		}

		#endregion




		#endregion

		public void ChangeOpponent()
		{
			if (m_Change < DateTime.UtcNow)
			{
				Mobile agro, best = null;
				double distance, random = Utility.RandomDouble();

				if (random < 0.75)
				{
					// find random target relatively close
					for (int i = 0; i < Aggressors.Count && best == null; i++)
					{
						agro = Validate(Aggressors[i].Attacker);

						if (agro == null)
							continue;

						distance = StrikingRange - GetDistanceToSqrt(agro);

						if (distance > 0 && distance < StrikingRange - 2 && InLOS(agro.Location))
						{
							distance /= StrikingRange;

							if (random < distance)
								best = agro;
						}
					}
				}
				else
				{
					int damage = 0;

					// find a player who dealt most damage
					for (int i = 0; i < DamageEntries.Count; i++)
					{
						agro = Validate(DamageEntries[i].Damager);

						if (agro == null)
							continue;

						distance = GetDistanceToSqrt(agro);

						if (distance < StrikingRange && DamageEntries[i].DamageGiven > damage && InLOS(agro.Location))
						{
							best = agro;
							damage = DamageEntries[i].DamageGiven;
						}
					}
				}

				if (best != null)
				{
					// teleport
					best.Location = GetSpawnPosition(Location, Map, 1);
					best.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
					best.PlaySound(0x1FE);

					Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
					{
						best.ApplyPoison(this, HitPoison);
						best.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
						best.PlaySound(0x474);
					});

					m_Change = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(5, 10));
				}
			}

				
		}


		private void Teleport()
		{
			if (m_Teleport < DateTime.UtcNow)
			{
				System.Collections.Generic.List<PlayerMobile> toTele = SpellHelper.AcquireIndirectTargets(this, Location, Map, StrikingRange).OfType<PlayerMobile>().ToList();

				if (toTele.Count > 0)
				{
					PlayerMobile from = toTele[Utility.Random(toTele.Count)];

					if (from != null && !from.IsStaff())
					{
						Combatant = from;

						from.MoveToWorld(GetSpawnPosition(1), Map);
						from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
						from.PlaySound(0x1FE);

						//from.ApplyPoison(this, HitPoison);
					}
				}

				ColUtility.Free(toTele);
				m_Teleport = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(40, 60));


			}
			
		}


		public void SpawnNonEnrage()
		{
			if (m_NextSpawn < DateTime.UtcNow)
			{

				for (int i = 0; i < Utility.Random(1, 3); i++)
				{
					if (Utility.RandomBool())
					{
						SpawnHelper( new RouxvolutionaireArcher(), Location);
					}
					else
					{
						SpawnHelper( new TitusRouxValier(), Location);
					}

					
				}

				m_NextSpawn = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(120, 200));

			}


		}

		public void SpawnEnrage()
		{
			if (m_NextSpawn < DateTime.UtcNow)
			{

				for (int i = 0; i < Utility.Random(1, 3); i++)
				{
					if (Utility.RandomBool())
					{
						SpawnHelper(new TitusRouxMage(), Location);
					}
					else
					{
						SpawnHelper(new TitusRouxTisane(), Location);
					}


				}

				m_NextSpawn = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(120, 200));

			}


		}



		public void SpawnHelper(BaseCreature helper, Point3D location)
		{
			if (helper == null)
				return;

			helper.Home = location;
			helper.RangeHome = 4;

			if (Combatant != null)
			{
				helper.Warmode = true;
				helper.Combatant = Combatant;
			}


			BaseCreature.Summon(helper, false, this, this.Location, -1, TimeSpan.FromMinutes(2));
			helper.MoveToWorld(location, Map);
		}












		public void HoofStomp()
		{
			if (Combatant != null && Combatant is Mobile m && DelayOnHit1 < DateTime.UtcNow)
			{
				if (m.GetStatMod("DreadHornStr") == null)
				{
					double percent = m.Skills.MagicResist.Value / 100;
					int malas = (int)(-20 + (percent * 5.2));

					m.AddStatMod(new StatMod(StatType.Str, "DreadHornStr", m.Str < Math.Abs(malas) ? m.Str / 2 : malas, TimeSpan.FromSeconds(60)));
					m.AddStatMod(new StatMod(StatType.Dex, "DreadHornDex", m.Dex < Math.Abs(malas) ? m.Dex / 2 : malas, TimeSpan.FromSeconds(60)));
					m.AddStatMod(new StatMod(StatType.Int, "DreadHornInt", m.Int < Math.Abs(malas) ? m.Int / 2 : malas, TimeSpan.FromSeconds(60)));
				}

				//	m.SendLocalizedMessage(1075081); // *Dreadhorns eyes light up, his mouth almost a grin, as he slams one hoof to the ground!*

				m.SendMessage("Le coups de Titus vous affaiblis.");


				// earthquake
				PlaySound(0x2F3);
				DelayOnHit1 = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 80));
			}
		
				
		}

		public static bool IsUnderInfluence(Mobile m)
		{
			return m.GetStatMod("DreadHornStr") != null;
		}


		public Mobile Validate(Mobile m)
		{
			Mobile agro;

			if (m is BaseCreature)
				agro = ((BaseCreature)m).ControlMaster;
			else
				agro = m;

			if (!CanBeHarmful(agro, false) || !agro.Player /*|| Combatant == agro*/ )
				return null;

			return agro;
		}


		public override void GenerateLoot()
        {
			AddLoot(LootPack.SuperBoss, 8);
            AddLoot(LootPack.MedScrolls);
            AddLoot(LootPack.PeculiarSeed1);
            AddLoot(LootPack.LootItem<Items.RoastPig>(10.0));
			AddLoot(LootPack.LootItem<Items.Gold>(15000,20000));
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);

			writer.Write(m_Enrage);


        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_Enrage = reader.ReadBool();
						break;
					}
				default:
					break;
			}

		}
    }










}
