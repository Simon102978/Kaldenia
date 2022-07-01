namespace Server.Mobiles
{
    [CorpseName("Corp de Matriache")]
    public class MatriacheOgre : BaseCeosSpawn
	{
		public override Poison pet => Poison.Greater;

		[Constructable]
        public MatriacheOgre()
            : base(AIType.AI_Spellbinder, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Matriache";
            Body = 83;
            BaseSoundID = 427;


			SetStr(350, 550);

			SetHits(3500);
			SetMana(600, 800);
			SetDamage(17, 22);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 60, 80);
			SetResistance(ResistanceType.Fire, 50, 60);
			SetResistance(ResistanceType.Cold, 50, 60);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 50, 60);

			SetSkill(SkillName.MagicResist, 125, 140);
			SetSkill(SkillName.Tactics, 100, 120);
			SetSkill(SkillName.Wrestling, 140);
			SetSkill(SkillName.Anatomy, 100, 120);
			SetSkill(SkillName.Magery, 100, 110);
			SetSkill(SkillName.EvalInt, 100, 110);
		}

        public MatriacheOgre(Serial serial)
            : base(serial)
        {
        }

		public override int Hides => 6;
		public override HideType HideType => HideType.Geant;


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Geant;

		public override bool CanRummageCorpses => true;
        public override Poison PoisonImmune => Poison.Regular;
        public override int TreasureMapLevel => 3;
        public override int Meat => 2;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 2);
			AddLoot(LootPack.Potions, 2);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
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