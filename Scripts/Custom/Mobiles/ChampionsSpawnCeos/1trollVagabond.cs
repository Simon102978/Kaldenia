using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("cadavre de troll")]
    public class Trollvagabond : BaseCeosSpawn
	{
        [Constructable]
        public Trollvagabond()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "troll vagabond";
            Body = Utility.RandomList(53, 54);
            BaseSoundID = 461;

			SetStr(146, 175);
			SetDex(101, 130);
			SetInt(120, 135);

			SetHits(120, 145);

			SetDamage(4, 10);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 23, 35);
			SetResistance(ResistanceType.Fire, 20, 30);
			SetResistance(ResistanceType.Cold, 30, 50);
			SetResistance(ResistanceType.Poison, 15, 20);
			SetResistance(ResistanceType.Energy, 10, 20);

			SetSkill(SkillName.Anatomy, 0);
			SetSkill(SkillName.Archery, 80.1, 90.0);
			SetSkill(SkillName.MagicResist, 81.1, 90.0);
			SetSkill(SkillName.Tactics, 53.8, 75.0);
			SetSkill(SkillName.Wrestling, 62.3, 75.0);

			Fame = 6500;
			Karma = -6500;

			AddItem(new Bow());
		}

        public Trollvagabond(Serial serial)
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