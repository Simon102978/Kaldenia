namespace Server.Mobiles
{
    [CorpseName("Le corps d'un Lion")]
    public class Lion : BaseCreature
    {
        public override double HealChance => .167;

        [Constructable]
        public Lion()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Un Lion";
            Body = 786;
            Female = true;
            BaseSoundID = 0x3EF;

			SetStr(94, 170);
			SetDex(96, 115);
			SetInt(6, 10);

			SetHits(71, 110);
			SetMana(0);

			SetDamage(11, 17);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 25, 30);
			SetResistance(ResistanceType.Fire, 10, 15);
			SetResistance(ResistanceType.Poison, 20, 25);
			SetResistance(ResistanceType.Energy, 20, 25);

			SetSkill(SkillName.MagicResist, 75.1, 80.0);
			SetSkill(SkillName.Tactics, 79.3, 94.0);
			SetSkill(SkillName.Wrestling, 79.3, 94.0);

			Fame = 11000;
            Karma = -11000;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 60.1;

            SetMagicalAbility(MagicalAbility.Piercing);
        }

        public override int GetIdleSound() { return 0x673; }
        public override int GetAngerSound() { return 0x670; }
        public override int GetHurtSound() { return 0x672; }
        public override int GetDeathSound() { return 0x671; }

        public override double WeaponAbilityChance => 0.5;

        public override int Hides => 11;
        public override HideType HideType => HideType.Regular;
        public override int Meat => 5;
        public override FoodType FavoriteFood => FoodType.Meat;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 1);
        }

        public override bool CanAngerOnTame => true;
        public override bool StatLossAfterTame => true;

        public Lion(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}