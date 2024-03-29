using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a gallusaurus corpse")]
    public class Gallusaurus : BaseCreature
    {
        public override bool AttacksFocus => !Controlled;

        [Constructable]
        public Gallusaurus()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, .2, .4)
        {
            Name = "a gallusaurus";
            Body = 1286;
            BaseSoundID = 0x275;

            SetStr(477, 511);
            SetDex(155, 168);
            SetInt(221, 274);

            SetDamage(11, 17);

            SetHits(700, 900);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 50, 60);
            SetResistance(ResistanceType.Fire, 20, 30);
            SetResistance(ResistanceType.Cold, 20, 30);
            SetResistance(ResistanceType.Poison, 60, 70);
            SetResistance(ResistanceType.Energy, 20, 30);

            SetSkill(SkillName.MagicResist, 70.0, 80.0);
            SetSkill(SkillName.Tactics, 80.0, 90.0);
            SetSkill(SkillName.Wrestling, 80.0, 91.0);
            SetSkill(SkillName.Bushido, 110.0, 120.0);
            SetSkill(SkillName.Tracking, 25.0, 35.0);

            Fame = 8100;
            Karma = -8100;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 102.0;

            SetWeaponAbility(WeaponAbility.Block);
            SetSpecialAbility(SpecialAbility.GraspingClaw);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 1);
        }

        public override int Meat => 3;
        public override MeatType MeatType => MeatType.DinoRibs;
        public override bool CanAngerOnTame => true;
        public override int TreasureMapLevel => 1;

        public Gallusaurus(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 0)
            {
                SetSpecialAbility(SpecialAbility.GraspingClaw);
                SetWeaponAbility(WeaponAbility.Block);
            }
        }
    }
}
