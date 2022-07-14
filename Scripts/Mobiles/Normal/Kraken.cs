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
		private DateTime m_NextJump;
		private DateTime m_GlobalTimer;

		//	private DateTime m_tentaHit;
		//	private Point3D m_Water ;
		private bool m_OnBoat = false;

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

				if (m_GlobalTimer < DateTime.UtcNow)
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
								JumpOnBoard();
								break;
							default:
								break;
						}
					}
					m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 20));

				}

				
			}

		}

		public void TentaclesHit()
		{
	//		if (m_tentaHit < DateTime.UtcNow) // Retrait du CD, parce qu'il est inclut dans le cd des autres attaques. C'est juste une substitution si la cible est pas dans un boat.
			{

				Emote("*Frappe le bateau de ses tentacules.*");

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


							if (Utility.Random(100) < 33)
							{
								targets[i].ApplyPoison(this,Poison.Greater);
							}						
					}
				}
			//	m_tentaHit = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 50));
			}
		}

		


		public void JumpOnBoard()
		{
			if (m_NextJump < DateTime.UtcNow)
			{

				if (BaseBoat.FindBoatAt(Combatant.Location, Combatant.Map) != null && !m_OnBoat)
				{
					Emote("*Monte sur le bateau*");					
					this.Location = Combatant.Location;

					m_OnBoat = true;
					Timer.DelayCall(TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30), RetourEau);

					m_NextJump = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(75, 90));
				}
			}
		}

		public void StuckBoat()
		{
			if (m_NextStuck < DateTime.UtcNow)
			{

				bool BoatFind = false;


				IPooledEnumerable eable = this.GetItemsInRange(10);

				foreach (Item m in eable)
				{
					if (m is BaseBoat boat)
					{
						if (!boat.Stuck)
						{
							Emote("*Coince le navire entre ses tentacules.*");
							boat.Stuck = true;
							BoatFind = true;

							
						}						
					}
				}

				if (!BoatFind)
				{
					TentaclesHit();
				}

				m_NextStuck = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(45, 60));

				eable.Free();

			

			}

		}


	    public void RetourEau()
		{
				int i = 0;

				while (m_OnBoat && i < 25)
				{
					int X = Utility.Random(-10, 20);
					int Y = Utility.Random(-10, 20);

					Point3D total = this.Location;

					IPoint3D p = new Point3D(total.X + X, total.Y + Y, total.Z);

					IPoint3D orig = p;
					Map map = this.Map;

					SpellHelper.GetSurfaceTop(ref p);

					Point3D point = new Point3D(p);

					LandTile ld = Map.Tiles.GetLandTile(point.X, point.Y);

					if (ld.ID == 168 || ld.ID == 169 || ld.ID == 170 || ld.ID == 171)
					{
						if (BaseBoat.FindBoatAt(point, this.Map) == null)
						{
							Emote("*Retourne dans l'eau*");
							this.Location = point;
							m_OnBoat = false;
						}
					}
					i++;
				}	
		}


		public void SpawnTentacle()
		{
			if (m_NextSpawn < DateTime.UtcNow)
			{

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
						if (Utility.Random(100) < 33)
						{

							targets[i].Emote("*Une tentacule sort de nul part pour vous agresser.*");

						

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
            AddLoot(LootPack.LootItem<Corde>(5.0));
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
