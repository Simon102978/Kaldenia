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
	[CorpseName("Corp de Miamus")]
	public class Miamus : BasePeerless
	{
		public static List<string> ParoleListe = new List<string>()
		{
			"Je suis Miaaaam !",
			"Miaamus va te manger !",
			"Tu devrais engraissé, tu as juste la peau sur les os !",
			"Miaam ! Miaaamm !",
			"Miamus Miam ! Miiiaamuuus Miaam !",
			"Rajoutez vous à ma collection de graisse ! Mou ha ha !"
		};

		public DateTime m_GlobalTimer;
		public DateTime m_NextSpawn;

		public DateTime DelaySaut;
		public DateTime DelayCoupVentre;

		public virtual int StrikingRange => 12;
		public override bool AutoDispel => true;
		public override double AutoDispelChance => 1.0;
		public override bool BardImmune => true;
		public override bool Unprovokable => true;
		public override bool Uncalmable => true;
		public override Poison PoisonImmune => Poison.Lethal;

		public bool BlockReflect { get; set; }

		public override bool CanBeParagon => false;

		public DateTime m_LastParole = DateTime.MinValue;

		public DateTime m_LastBlockParole = DateTime.MinValue;

		[Constructable]
		public Miamus()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Miamus";
			Title = "Titan Enrobé";
			Body = 76;
			BaseSoundID = 609;
			Hue = 1154;

			SetStr(600, 700);
			SetDex(76, 82);
			SetInt(76, 85);


			SetHits(7500);
			SetStam(507, 669);
			SetMana(1200, 1300);

			SetDamage(23, 27);

			//		SetDamage(2, 3);

			SetDamageType(ResistanceType.Physical, 80);
			SetDamageType(ResistanceType.Energy, 20);

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

			SetWeaponAbility(WeaponAbility.MortalStrike);
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(1050045, "Le titan Enrobe"); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
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
							CoupVentre();
							break;
						case 1:
							Saut();
							break;
						case 2:
							Spawn();
							break;
						default:
							break;
					}				
							
				m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 5));
			}
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
			Parole();

		}

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			base.OnDamage(amount, from, willKill);
			
		 if (from is BaseCreature)
			{
				BaseCreature creature = (BaseCreature)from;

				if (creature.Controlled || creature.Summoned)
				{

					Say($"Miaam !! {creature.Name} est Miamm ! *Tout en l'avalant*");

					if (Hits < HitsMax)
						Hits = HitsMax;

					creature.Kill();

					Effects.PlaySound(Location, Map, 0x574);
				}
			}
			
			Parole();
		}

		public override int Damage(int amount, Mobile from, bool informMount, bool checkDisrupt)
        {
            int dam = base.Damage(amount, from, informMount, checkDisrupt);

            if (!BlockReflect && from != null && dam > 0)
            {
                BlockReflect = true;
                AOS.Damage(from, this, dam, 0, 0, 0, 0, 0, 0, 100);
                BlockReflect = false;

                from.PlaySound(0x1F1);
            }

            return dam;
        }

		public void Parole()
		{
			if (m_LastParole < DateTime.Now && Combatant != null)
			{	
				Say(ParoleListe[Utility.Random(ParoleListe.Count)]);
			
				m_LastParole = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 90));
			}
		}

		public override void AlterMeleeDamageTo(Mobile to, ref int damage)
		{

			Parole();


			 if (Utility.Random(3) == 0)
            {

				Say("Miaam!");

                int toHeal = Utility.RandomMinMax(0, (int)(AOS.Scale(damage, 50) * 0.3));

                if (to is BaseCreature && ((BaseCreature)to).TaintedLifeAura)
                {
                    AOS.Damage(this, to, toHeal, false, 0, 0, 0, 0, 0, 0, 100, false, false, false);
                    SendLocalizedMessage(1116778); //The tainted life force energy damages you as your body tries to absorb it.
                }
                else
                {
                    Hits += toHeal;
                }

                Effects.SendPacket(to.Location, to.Map, new ParticleEffect(EffectType.FixedFrom, to.Serial, Serial.Zero, 0x377A, to.Location, to.Location, 1, 15, false, false, 1926, 0, 0, 9502, 1, to.Serial, 16, 0));
                Effects.SendPacket(to.Location, to.Map, new ParticleEffect(EffectType.FixedFrom, to.Serial, Serial.Zero, 0x3728, to.Location, to.Location, 1, 12, false, false, 1963, 0, 0, 9042, 1, to.Serial, 16, 0));
            }


		/*		if (DelayOnHit1 < DateTime.UtcNow)
				{
					Cleave();
				}			*/	


			base.AlterMeleeDamageTo(to, ref damage);
		}

		public override void Attack(IDamageable e)
		{
			Parole();
			base.Attack(e);
		}
		public Miamus(Serial serial)
			: base(serial)
		{
		}
		public override int Meat => 4;
		public override int TreasureMapLevel => 5;
		public override int Hides => 8;
		public override HideType HideType => HideType.Ancien;
		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Ancien;

		public void Saut()
		{
			if (DelaySaut < DateTime.UtcNow)
			{
					int Range = 10;
					List<Mobile> targets = new List<Mobile>();

					IPooledEnumerable eable = this.GetMobilesInRange(Range);

					foreach (Mobile m in eable)
					{
						if (this != m  && !m.IsStaff())
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

					Emote(" Miaaamm ! *Saute et retombe : BOOOOOOMMM !*");

					if (targets.Count > 0)
					{
						for (int i = 0; i < targets.Count; ++i)
						{
							Mobile m = targets[i];

							int dmg = 25;

							AOS.Damage(Combatant, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

							DoHarmful(m);

							KnockBack(this.Location, m, 5);

							m.Freeze(TimeSpan.FromSeconds(5));
						}
					}

				DelaySaut = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 70));

			}
		}

		public void CoupVentre()
		{

			if (DelayCoupVentre < DateTime.UtcNow && Combatant != null && Combatant is Mobile m && m.InRange(this,3)) 
			{
				int dmg = 45;

				Combatant.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);

				AOS.Damage(Combatant, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

				Emote($"*Donne un bon coup de ventre à {Combatant.Name}*");

				KnockBack(this.Location, Combatant as Mobile, 5);

				DelayCoupVentre = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 60));
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



		public void Spawn()
		{
			if (m_NextSpawn < DateTime.UtcNow)
			{

				Emote("*Sa sueur rebondie partout, et une fois au sol, celle-ci se met a bouger.*");

				for (int i = 0; i < Utility.Random(1, 3); i++)
				{

						SpawnHelper( new GraisseMiamus(), Location);					
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
