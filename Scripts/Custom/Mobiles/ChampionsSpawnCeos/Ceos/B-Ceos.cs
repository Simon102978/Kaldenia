using Server.Engines.CannedEvil;
using Server.Items;
using Server.Spells;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Mobiles
{
    [CorpseName("Corp de Ceos")]
    public class Ceos : BasePeerless
	{

		[Constructable]
        public Ceos()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Ceos";
            Body = 76;
            BaseSoundID = 609;

			SetStr(1232, 1400);
			SetDex(76, 82);
			SetInt(76, 85);


			SetHits(6000);
			SetStam(507, 669);
			SetMana(1200, 1300);

			SetDamage(23, 27);

			SetDamageType(ResistanceType.Physical, 80);
			SetDamageType(ResistanceType.Poison, 20);

			SetResistance(ResistanceType.Physical, 75, 85);
			SetResistance(ResistanceType.Fire, 40, 50);
			SetResistance(ResistanceType.Cold, 50, 60);
			SetResistance(ResistanceType.Poison, 55, 65);
			SetResistance(ResistanceType.Energy, 50, 60);

			SetSkill(SkillName.Wrestling, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Poisoning, 50);

			Fame = 25000;
			Karma = -25000;

			SetAreaEffect(AreaEffect.PoisonBreath);
		}

		public override TribeType Tribe => TribeType.Titusien;
		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			base.OnDamage(amount, from, willKill);

			
			if (Utility.Random(100) <= 10)
				{
					switch (Utility.Random(3))
					{
						case 0:
							{
								Say("Oupsie!");
								break;
							}
						case 1:
							{
								Say("C'est pas moi, c'est lui ! *Pointant quelqu'un d'autre au hasard*");
								break;
							}
						case 2:
							{
								Say("Quoi ?! ");
								break;
							}
						default:
							{
								Say("*roule les yeux*");
								break;

							}
					}

					Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x36B0, 1, 14, 63, 7, 9915, 0);
					Effects.PlaySound(Location, Map, 0x229);

					List<Mobile> targets = new List<Mobile>();

					if (Map != null)
					{

						int Range = 3;

						IPooledEnumerable eable = Map.GetMobilesInRange(Location, Range);

						foreach (Mobile m in eable)
						{
							if (this != m && CanBeHarmful(m, false) && !(m is BaseCeosSpawn) && !m.IsStaff())
							{
								targets.Add(m);
							}
						}
						eable.Free();
					}


					if (targets.Count > 0)
					{
						for (int i = 0; i < targets.Count; ++i)
						{
							Mobile m = targets[i];

							DoHarmful(m);

							m.ApplyPoison(this, Poison.Greater);
						}
					}

				}
			// eats pet or summons
			else if (from is BaseCreature)
			{
				BaseCreature creature = (BaseCreature)from;

				if (creature.Controlled || creature.Summoned)
				{

					Say("Yummy !! *Tout en fesant une bouché de " + creature.Name + "*");

					if (Hits < HitsMax)
						Hits = HitsMax;

					creature.Kill();

					Effects.PlaySound(Location, Map, 0x574);
				}
			}

			// teleports player near
			if (from is PlayerMobile && !InRange(from.Location, 1))
			{
				Combatant = from;

				from.MoveToWorld(GetSpawnPosition(1), Map);
				from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
				from.PlaySound(0x1FE);
			}

		
		}


		public override bool CanSpawnHelpers => true;

		public override int MaxHelpersWaves => 1;

		public override void SpawnHelpers()
		{
			int count = 4;

			if (Altar != null)
			{
				count = Math.Min(Altar.Fighters.Count, 4);

				for (int i = 0; i < count; i++)
				{
					Mobile fighter = Altar.Fighters[i];

					if (CanBeHarmful(fighter))
					{
						Ogresse satyr = new Ogresse
						{
							FightMode = FightMode.Closest
						};
						SpawnHelper(satyr, GetSpawnPosition(fighter.Location, fighter.Map, 2));

						satyr.Combatant = fighter;

						Say("À moi !");

						//fighter.SendLocalizedMessage(1075116); // A twisted satyr scrambles onto the branch beside you and attacks!
					}
				}
			}
			else
			{
				for (int i = 0; i < count; i++)
					SpawnHelper(new Ogresse(), 4);
			}
		}










		public Ceos(Serial serial)
            : base(serial)
        {
        }


		public override int Meat => 4;
        public override Poison PoisonImmune => Poison.Greater;

		public override bool Unprovokable => true;
		public override int TreasureMapLevel => 5;
		public override int Hides => 8;
		public override HideType HideType => HideType.Geant;
		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Geant;

	
		public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Average);
            AddLoot(LootPack.MedScrolls);
            AddLoot(LootPack.PeculiarSeed1);
            AddLoot(LootPack.LootItem<Items.RoastPig>(10.0));
			AddLoot(LootPack.LootItem<Items.Gold>(15000,25000));
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
        }
    }
}
