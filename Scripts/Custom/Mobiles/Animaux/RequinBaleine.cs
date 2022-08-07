using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("Le corps d'un Requin Baleine")]
    public class RequinBaleine : BaseCreature
    {
        private DateTime m_NextWaterBall;

        [Constructable]
        public RequinBaleine()
            : base(AIType.MaritimeMageAI, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            m_NextWaterBall = DateTime.UtcNow;

            Name = "Un Requin Baleine";
            Body = 224;
            BaseSoundID = 353;

            SetStr(756, 780);
            SetDex(226, 245);
			SetInt(276, 305);

			SetHits(454, 468);
            SetMana(500);

            SetDamage(19, 33);

            SetDamageType(ResistanceType.Physical, 70);
            SetDamageType(ResistanceType.Cold, 30);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 30, 40);
            SetResistance(ResistanceType.Poison, 20, 30);
            SetResistance(ResistanceType.Energy, 10, 20);


			SetSkill(SkillName.Hiding, 80, 90);
			SetSkill(SkillName.MagicResist, 15.1, 20.0);
            SetSkill(SkillName.Tactics, 45.1, 60.0);
            SetSkill(SkillName.Wrestling, 45.1, 60.0);
			SetSkill(SkillName.EvalInt, 100.0);
			SetSkill(SkillName.Magery, 90, 100.0);
			SetSkill(SkillName.Meditation, 90, 100.0);



			Fame = 11000;
            Karma = -11000;

            CanSwim = true;
            CantWalk = true;
        }

        public RequinBaleine(Serial serial)
            : base(serial)
        {
        }

        public override int TreasureMapLevel => 4;

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
			AddLoot(LootPack.LootItem<DentRequin>());

		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(2);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

			if (version == 1)
			{
				this.Delete();
			}

			m_NextWaterBall = DateTime.UtcNow;
        }
    }
}
