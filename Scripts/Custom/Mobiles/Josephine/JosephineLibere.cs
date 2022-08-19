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
	public class JosephineLibere : BasePeerless
	{
		public static List<string> ParoleList = new List<string>()
		{
			"Vous allez tous mourrir !",
			"MOURRREEZ !",
			"Connard !",
			"Vous m'enleverez pas la perfection que je viens d'atteindre !"
		};




		public DateTime DelayHurlement;
		public DateTime TuerSummoneur;
		public DateTime m_GlobalTimer;
		public DateTime m_NextSpawn;
		public DateTime m_NextDiscordTime
;





		public virtual int StrikingRange => 12;

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
		public JosephineLibere()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Josephine";
			Title = "Travestie liberée";
			Body = 310;
			BaseSoundID = 0x482;
			Hue = 1198;

			SetStr(600, 700);
			SetDex(76, 82);
			SetInt(76, 85);


			SetHits(2500);
			SetStam(507, 669);
			SetMana(1200, 1300);

			SetDamage(25, 30);

			//		SetDamage(2, 3);

			SetDamageType(ResistanceType.Cold, 80);
			SetDamageType(ResistanceType.Energy, 20);

			SetResistance(ResistanceType.Physical, 90, 95);
			SetResistance(ResistanceType.Fire, 20, 40);
			SetResistance(ResistanceType.Cold, 30, 40);
			SetResistance(ResistanceType.Poison, 30, 50);
			SetResistance(ResistanceType.Energy, 30, 40);

			SetSkill(SkillName.Wrestling, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Musicianship, 120.0);
			SetSkill(SkillName.Peacemaking, 120.0);
			SetSkill(SkillName.Provocation, 120.0);
			SetSkill(SkillName.Discordance, 120.0);

			SetWeaponAbility(WeaponAbility.MortalStrike);
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
						Hurlement();
						break;
					case 1:
						Spawn();
						break;
					case 2:
						if (Combatant is Mobile m)
						{
							Discord(m);
						}				
						break;
					default:
						break;
				}

			
			}
		}

		public void Spawn()
		{
			if (m_NextSpawn < DateTime.UtcNow)
			{

				if (Combatant is Mobile m)
				{
					for (int i = 0; i < Utility.Random(1, 2); i++)
					{
						SpawnHelper(new KhaldunRevenant(m), Location);
					}
				}
			
				m_NextSpawn = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(120, 200));
				m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 5));
			}
		}

		#region Unholy Touch
		private static readonly Dictionary<Mobile, Timer> m_UnholyTouched = new Dictionary<Mobile, Timer>();

		public void Discord(Mobile target)
		{
			if (Utility.RandomDouble() < 0.9 && !m_UnholyTouched.ContainsKey(target))
			{
				double scalar = -((20 - (target.Skills[SkillName.MagicResist].Value / 10)) / 100);

				ArrayList mods = new ArrayList();

				if (target.PhysicalResistance > 0)
				{
					mods.Add(new ResistanceMod(ResistanceType.Physical, (int)(target.PhysicalResistance * scalar)));
				}

				if (target.FireResistance > 0)
				{
					mods.Add(new ResistanceMod(ResistanceType.Fire, (int)(target.FireResistance * scalar)));
				}

				if (target.ColdResistance > 0)
				{
					mods.Add(new ResistanceMod(ResistanceType.Cold, (int)(target.ColdResistance * scalar)));
				}

				if (target.PoisonResistance > 0)
				{
					mods.Add(new ResistanceMod(ResistanceType.Poison, (int)(target.PoisonResistance * scalar)));
				}

				if (target.EnergyResistance > 0)
				{
					mods.Add(new ResistanceMod(ResistanceType.Energy, (int)(target.EnergyResistance * scalar)));
				}

				for (int i = 0; i < target.Skills.Length; ++i)
				{
					if (target.Skills[i].Value > 0)
					{
						mods.Add(new DefaultSkillMod((SkillName)i, true, target.Skills[i].Value * scalar));
					}
				}

				target.PlaySound(0x458);

				ApplyMods(target, mods);

				Emote($"*Utilise son touché glaciale contre {target.Name}*");

				m_UnholyTouched[target] = Timer.DelayCall(TimeSpan.FromSeconds(30), delegate
				{
					ClearMods(target, mods);

					m_UnholyTouched.Remove(target);
				});
			}

			m_NextDiscordTime = DateTime.UtcNow + TimeSpan.FromSeconds(5 + Utility.RandomDouble() * 22);
			m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 5));
		}

		private static void ApplyMods(Mobile from, ArrayList mods)
		{
			for (int i = 0; i < mods.Count; ++i)
			{
				object mod = mods[i];

				if (mod is ResistanceMod)
					from.AddResistanceMod((ResistanceMod)mod);
				else if (mod is StatMod)
					from.AddStatMod((StatMod)mod);
				else if (mod is SkillMod)
					from.AddSkillMod((SkillMod)mod);
			}
		}

		private static void ClearMods(Mobile from, ArrayList mods)
		{
			for (int i = 0; i < mods.Count; ++i)
			{
				object mod = mods[i];

				if (mod is ResistanceMod)
					from.RemoveResistanceMod((ResistanceMod)mod);
				else if (mod is StatMod)
					from.RemoveStatMod(((StatMod)mod).Name);
				else if (mod is SkillMod)
					from.RemoveSkillMod((SkillMod)mod);
			}
		}
		#endregion


		public void Hurlement()
		{


			if (DelayHurlement < DateTime.UtcNow)
			{
				int Range = 10;
				List<Mobile> targets = new List<Mobile>();

				IPooledEnumerable eable = this.GetMobilesInRange(Range);

				foreach (Mobile m in eable)
				{
					if (this != m && !(m is Harpy) && !(m is StoneHarpy) && !m.IsStaff())
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

				Emote("*Lance un hurlement effroyable*");

				if (targets.Count > 0)
				{





					for (int i = 0; i < targets.Count; ++i)
					{
						Mobile m = targets[i];


						DoHarmful(m);

						m.Paralyze(TimeSpan.FromSeconds(10));

					}
				}

				DelayHurlement = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 50));

				m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 5));

			}
		}

		public void AntiSummon()
		{
			if (TuerSummoneur < DateTime.UtcNow)
			{
				if (Combatant is BaseCreature bc)
				{
					if (bc.Summoned)
					{
						if (bc.ControlMaster is CustomPlayerMobile cp)
						{
							Combatant = cp;

							Emote($"*réapparait sur {cp.Name}*");

							cp.Damage(10);

							cp.Freeze(TimeSpan.FromSeconds(3));

							this.Location = cp.Location;

						}
					}
				}
				TuerSummoneur = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 50));
			}
		}





		public override void GenerateLoot()
		{
			AddLoot(LootPack.SuperBoss, 8);
			AddLoot(LootPack.MedScrolls);
			AddLoot(LootPack.PeculiarSeed1);
			AddLoot(LootPack.LootItem<Items.RoastPig>(10.0));
			AddLoot(LootPack.LootItem<Items.Gold>(15000, 20000));
		}






		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
			Parole();

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
				
					
				Say(ParoleList[Utility.Random(ParoleList.Count)]);
					




				m_LastParole = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 90));
			}





		}


		public override void Attack(IDamageable e)
		{
			Parole();
			AntiSummon();
			base.Attack(e);
		}







		public JosephineLibere(Serial serial)
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
