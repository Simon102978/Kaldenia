namespace Server.Mobiles
{
    [CorpseName("cadavre de troll")]
    public class Trollvillageois : BaseCeosSpawn
	{
        [Constructable]
        public Trollvillageois()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "troll villageois";
            Body = Utility.RandomList(53, 54);
            BaseSoundID = 461;


			SetStr(96, 120);
			SetDex(81, 105);
			SetInt(36, 60);

			SetHits(58, 72);

			SetDamage(5, 7);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 25, 30);
			SetResistance(ResistanceType.Fire, 20, 30);
			SetResistance(ResistanceType.Cold, 10, 20);
			SetResistance(ResistanceType.Poison, 10, 20);
			SetResistance(ResistanceType.Energy, 20, 30);

			SetSkill(SkillName.MagicResist, 50.1, 75.0);
			SetSkill(SkillName.Tactics, 55.1, 80.0);
			SetSkill(SkillName.Wrestling, 50.1, 70.0);

			Fame = 1500;
			Karma = -1500;
		}

        public Trollvillageois(Serial serial)
            : base(serial)
        {
        }

        public override bool CanRummageCorpses => true;
        public override int TreasureMapLevel => 1;
        public override int Meat => 2;
		public override int Hides => 5;
		public override HideType HideType => HideType.Regular;


		public override int Bones => 5;
		public override BoneType BoneType => BoneType.Regular;
		public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
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