using Server.Items;
using System;
using Server.Multis;
using System.Collections.Generic;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("Corps de Kraken")]
    public class Kraken : BaseCreature
    {
        private DateTime m_NextWaterBall;
		private DateTime m_NextStuck;
		private DateTime m_NextSpawn;
		private DateTime m_tentaHit;

		[Constructable]
        public Kraken()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            m_NextWaterBall = DateTime.UtcNow;

            Name = "Kraken";
            Body = 77;
            BaseSoundID = 353;

            SetStr(756, 780);
            SetDex(226, 245);
            SetInt(26, 40);

            SetHits(454, 468);
            SetMana(0);

            SetDamage(19, 33);

            SetDamageType(ResistanceType.Physical, 70);
            SetDamageType(ResistanceType.Cold, 30);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 30, 40);
            SetResistance(ResistanceType.Poison, 20, 30);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.MagicResist, 15.1, 20.0);
            SetSkill(SkillName.Tactics, 45.1, 60.0);
            SetSkill(SkillName.Wrestling, 45.1, 60.0);

            Fame = 11000;
            Karma = -11000;

            CanSwim = true;
            CantWalk = true;
        }

        public Kraken(Serial serial)
            : base(serial)
        {
        }

        public override int TreasureMapLevel => 4;


		public override void OnThink()
		{



			base.OnThink();






			if (Combatant != null)
			{
				if (this.InRange(Combatant.Location, 10))
				{
					switch (Utility.Random(3))
					{
						case 0:
							StuckBoat();
							break;
						case 1:
							SpawnTentacle();
							break;
						case 2:
							TentaclesHit();
							break;
						default:
							break;
					}
				}
			}

		}

	





		public void TentaclesHit()
		{



			if (m_tentaHit < DateTime.UtcNow)
			{

				Emote("Frappe le bateau de ses tentacules.");

				int Range = 10;
				List<CustomPlayerMobile> targets = new List<CustomPlayerMobile>();

				IPooledEnumerable eable = this.GetMobilesInRange(Range);

				foreach (Mobile m in eable)
				{
					if (this != m && !m.IsStaff() && m is CustomPlayerMobile cp)
					{
						targets.Add(cp);
					}
				}

				eable.Free();



				if (targets.Count > 0)
				{

					for (int i = 0; i < targets.Count; ++i)
					{
						

							
							int dmg = 30;

							AOS.Damage(targets[i], this, dmg, 100, 0, 0, 0, 0);


							if (Utility.RandomBool())
							{
								targets[i].ApplyPoison(this,Poison.Greater);
							}



						
					}
				}


				m_tentaHit = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(15, 30));

			}


		}







		public void StuckBoat()
		{
			if (m_NextStuck < DateTime.UtcNow)
			{
				Emote("Coince le navire entre ses tentacules.");


				IPooledEnumerable eable = this.GetItemsInRange(10);

				foreach (Item m in eable)
				{
					if (m is BaseBoat boat)
					{
						if (!boat.Stuck)
							boat.Stuck = true;
					}
				}

				eable.Free();

				m_NextStuck = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 120));

			}

		}


		public void SpawnTentacle()
		{
			if (m_NextSpawn < DateTime.UtcNow)
			{

				Emote("Spawn Tentacles");

				int Range = 10;

				List<CustomPlayerMobile> targets = new List<CustomPlayerMobile>();

				IPooledEnumerable eable = this.GetMobilesInRange(Range);

				foreach (Mobile m in eable)
				{
					if (this != m && !m.IsStaff() && m is CustomPlayerMobile cp)
					{
						targets.Add(cp);
					}
				}

				eable.Free();



				if (targets.Count > 0)
				{

					for (int i = 0; i < targets.Count; ++i)
					{
						if (Utility.Random(100) < 60)
						{

							targets[i].Emote("Une tentacule sort de nul part pour vous agresser.");

						

							KakrenTentacle tentacle = new KakrenTentacle();
						
							BaseCreature.Summon(tentacle, false, this, targets[i].Location, 353, TimeSpan.FromMinutes(2));			

						}
					}
				}


				m_NextSpawn = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 120));

			}


		}


		public override void OnActionCombat()
        {
            Mobile combatant = Combatant as Mobile;

            if (combatant == null || combatant.Deleted || combatant.Map != Map || !InRange(combatant, 12) || !CanBeHarmful(combatant) || !InLOS(combatant))
                return;

            if (DateTime.UtcNow >= m_NextWaterBall)
            {
                double damage = combatant.Hits * 0.3;

                if (damage < 10.0)
                    damage = 10.0;
                else if (damage > 40.0)
                    damage = 40.0;

                DoHarmful(combatant);
                MovingParticles(combatant, 0x36D4, 5, 0, false, false, 195, 0, 9502, 3006, 0, 0, 0);
                AOS.Damage(combatant, this, (int)damage, 100, 0, 0, 0, 0);

                if (combatant is PlayerMobile && combatant.Mount != null)
                {
                    (combatant as PlayerMobile).SetMountBlock(BlockMountType.DismountRecovery, TimeSpan.FromSeconds(10), true);
                }

                m_NextWaterBall = DateTime.UtcNow + TimeSpan.FromMinutes(1);
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.LootItem<Rope>(5.0));
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

            m_NextWaterBall = DateTime.UtcNow;
        }
    }
}
