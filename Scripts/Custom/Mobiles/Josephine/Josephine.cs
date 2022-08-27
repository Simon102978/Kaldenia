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
	[CorpseName("Corp de Josephine")]
	public class Josephine : BasePeerless
	{
		public static List<string> FemmeParole = new List<string>()
		{
			"EEEUUURRRK ! *en regard avec dégout %%!*",
			"Hors de ma vue Horreure ! *en dévisageant %%!*",
			"BEEURRK ! Tu me donne envie de vomir ! *en fesant semblant de vomir en direction de %%!*",
			"Créature de malheure ! *en pointant du doight %%!*"
		};

		public static List<string> HommeParole = new List<string>()
		{
			"Oooh ! Tu viens dans mon lit mon beau %%! ?",
			"*fait un clin d'oeil vers %%!*",
			"Mon beeaau %%! ! Allez hop, dans mon lit !",
			"*Se pogne le membre et prend un regard coquin en direction de %%! *"

		};




		public DateTime DelayAttraction;
		public DateTime m_GlobalTimer;
		public DateTime m_Switch;
		public DateTime m_AreaExplosion;
		public DateTime m_NextSpawn;

		public override bool DeleteCorpseOnDeath => true;

		public virtual int StrikingRange => 12;

		public override bool CanFlee => false;

		public override bool AutoDispel => true;
		public override double AutoDispelChance => 1.0;
		public override bool BardImmune => true;
		public override bool Unprovokable => true;
		public override bool Uncalmable => true;
		public override Poison PoisonImmune => Poison.Greater;


		public override bool CanBeParagon => false;

		public DateTime m_LastParole = DateTime.MinValue;

		public override TribeType Tribe => TribeType.Ophidian;

		[Constructable]
		public Josephine()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Josephine";
			Title = "Titan Travestie";
			Body = 76;
			BaseSoundID = 609;
			Hue = 1198;

			SetStr(600, 700);
			SetDex(76, 82);
			SetInt(76, 85);


			SetHits(3000);
			SetStam(507, 669);
			SetMana(1200, 1300);

			SetDamage(25, 30);

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
			SetSkill(SkillName.Musicianship, 120.0);
			SetSkill(SkillName.Peacemaking, 120.0);
			SetSkill(SkillName.Provocation, 120.0);
			SetSkill(SkillName.Discordance, 120.0);

			SetWeaponAbility(WeaponAbility.ParalyzingBlow);
		}


		public override bool CanPeace => true;
		public override bool CanProvoke => true;

		public override bool CanDiscord => true;



		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(1050045, Title); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
		}


		public override void OnThink()
		{
			base.OnThink();
			Parole();

			if (m_GlobalTimer < DateTime.UtcNow && Warmode)
			{


				switch (Utility.Random(3))
				{
					case 0:
						Attraction();
						break;
					case 1:
						Switch();
						break;
					case 2:
						DoAreaExplosion();
						break;
					default:
						break;
				}

				m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 5));
			}
		}

		public void DoAreaExplosion()
		{
			if (m_AreaExplosion < DateTime.UtcNow)
			{

				List<Mobile> toExplode = new List<Mobile>();

				IPooledEnumerable eable = GetMobilesInRange(8);

				foreach (Mobile mob in eable)
				{
					if (!CanBeHarmful(mob, false) || mob == this || (mob is BaseCreature && ((BaseCreature)mob).GetMaster() == this))
						continue;
					if (mob.Player)
						toExplode.Add(mob);
					if (mob is BaseCreature && (((BaseCreature)mob).Controlled || ((BaseCreature)mob).Summoned || ((BaseCreature)mob).Team != Team))
						toExplode.Add(mob);
				}
				eable.Free();

				foreach (Mobile mob in toExplode)
				{
					mob.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
					mob.PlaySound(0x307);

					int damage = Utility.RandomMinMax(50, 125);
					AOS.Damage(mob, this, damage, 0, 100, 0, 0, 0);
				}

				m_AreaExplosion = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(15, 20));
			}
		}


		public void Switch()
		{
			if (m_Switch < DateTime.UtcNow && Combatant != null && Combatant is Mobile m )
			{

				if (m.Female)
				{
					int dmg = 45;


					Combatant.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);

					AOS.Damage(Combatant, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

					Say($"BEUURRRK ! Hors de ma vu ville créature!");

					KnockBack(this.Location, Combatant as Mobile, 5);

					ChangeOpponent();
				}
				else
				{
					int dmg = 45;

					Combatant.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);

					AOS.Damage(Combatant, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

					Say($"Yummy ! Vien passé la soirée avec moi !");


					m.Paralyze(TimeSpan.FromSeconds(10));
				}
				

				m_Switch = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 60));
			}


		}












		public void ChangeOpponent()
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

			}


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


		public override void CheckReflect(Mobile caster, ref bool reflect)
		{
			if (caster.Female && !caster.IsBodyMod)
				reflect = true; // Always reflect if caster isn't female
		}



		public override bool OnBeforeDeath()
		{
			
		//	
			JosephineLibere lib = new JosephineLibere();
			lib.Location = Location;
			lib.Map = Map;
			lib.Combatant = Combatant;
			lib.Direction = this.Direction;




			lib.Say("ENFIN LIBERÉE DE MES SOUFFRANCE ! *avec une voix feminine*");
			Delete();
			return false;

		}


		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			base.OnDamage(amount, from, willKill);

			Parole();
		}

		public void Parole()
		{

			if (m_LastParole < DateTime.Now && Combatant != null)
			{
				
					if (Combatant is CustomPlayerMobile cp)
						if (cp.Female)
							Say(FemmeParole[Utility.Random(FemmeParole.Count)].Replace("%%!",cp.Name));
						else
						Say(HommeParole[Utility.Random(HommeParole.Count)].Replace("%%!", cp.Name));




				m_LastParole = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 90));
			}





		}


		public override void Attack(IDamageable e)
		{
			Parole();
			base.Attack(e);
		}


		public void Attraction()
		{
			if (DelayAttraction < DateTime.UtcNow)
			{
				int Range = 10;
				List<Mobile> targets = new List<Mobile>();

				IPooledEnumerable eable = this.GetMobilesInRange(Range);

				foreach (Mobile m in eable)
				{
					if (this != m && !(m is Revenant)  && !m.IsStaff())
					{
						if (Core.AOS && !InLOS(m))
							continue;

						targets.Add(m);
					}
				}

				eable.Free();

				Effects.PlaySound(this, this.Map, 0x1FB);
				Effects.PlaySound(this, this.Map, 0x10B);
				Effects.SendLocationParticles(EffectItem.Create(this.Location, this.Map, EffectItem.DefaultDuration), 0x37CC, 1, 15, 97, 3, 9917, 0);

				Emote("*Concentre l'energie autour de lui*");

				if (targets.Count > 0)
				{

					int dmg = 15;



					for (int i = 0; i < targets.Count; ++i)
					{
						Mobile m = targets[i];


						DoHarmful(m);
						AOS.Damage(m, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

						int Distance = 5;


						if (m.GetDistanceToSqrt(this.Location) < Distance)
						{
							Distance = (int)m.GetDistanceToSqrt(this.Location);
						}

						if (m.Female)
						{
							Distance = Distance * -1;
						}


						KnockBack(this.Location, m, Distance); // Si sur le centre de la tornade...
					}
				}


				DelayAttraction = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 120));

			}


		}

		public void KnockBack(Point3D destination, Mobile target, int Distance)
		{



			if (target.Alive)
			{

				int Distance2 = Distance;
				int Neg = 1;

				if (Distance < 0)
				{
					Distance2 = -Distance;   // Sert a faire en sorte, que si c'est négative, ca va avancer.
					Neg = -1;
				}




				for (int i = 0; i < Distance2; i++)  // Le script valide toute les tiles jusqu'a la distance maximum. Si une d'entre elle est bloquer, il revient a la précédente (ou player location du départ) et stun la target.
				{
					Point3D point = KnockBackCalculation(destination, target, i * Neg);

					if (!target.Map.CanFit(point, 16, false, false) && i != Distance2)
					{
						target.Paralyze(TimeSpan.FromSeconds((Distance2 - i + 1)));
						break;
					}
					else
					{
						target.MoveToWorld(point, target.Map);
					}
				}
			}
		}
		public Point3D KnockBackCalculation(Point3D Loc, Mobile target, int Distance)
		{

			return KnockBackCalculation(Loc, new Point3D(target.Location), Distance);



		}

		public Point3D KnockBackCalculation(Point3D Loc, Point3D point, int Distance)
		{

			Direction d = Utility.GetDirection(point, Loc);

			switch (d)
			{
				case (Direction)0x0: case (Direction)0x80: point.Y += Distance; break; //North
				case (Direction)0x1: case (Direction)0x81: { point.X -= Distance; point.Y += Distance; break; } //Right
				case (Direction)0x2: case (Direction)0x82: point.X -= Distance; break; //East
				case (Direction)0x3: case (Direction)0x83: { point.X -= Distance; point.Y -= Distance; break; } //Down
				case (Direction)0x4: case (Direction)0x84: point.Y -= Distance; break; //South
				case (Direction)0x5: case (Direction)0x85: { point.X += Distance; point.Y -= Distance; break; } //Left
				case (Direction)0x6: case (Direction)0x86: point.X += Distance; break; //West
				case (Direction)0x7: case (Direction)0x87: { point.X += Distance; point.Y += Distance; break; } //Up
				default: { break; }
			}
			return point;
		}


		public Josephine(Serial serial)
			: base(serial)
		{
		}


		public override int Meat => 4;
		public override int TreasureMapLevel => 5;
		public override int Hides => 8;
		public override HideType HideType => HideType.Ancien;
		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Ancien;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{

				default:
					break;
			}

		}

	}


}
