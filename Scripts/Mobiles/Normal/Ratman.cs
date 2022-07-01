using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a ratman's corpse")]
    public class Ratman : BaseCreature
    {
        [Constructable]
        public Ratman()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = NameList.RandomName("ratman");
            Body = 42;
            BaseSoundID = 437;

            SetStr(96, 120);
            SetDex(81, 100);
            SetInt(36, 60);

            SetHits(58, 72);

            SetDamage(4, 5);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 25, 30);
            SetResistance(ResistanceType.Fire, 10, 20);
            SetResistance(ResistanceType.Cold, 10, 20);
            SetResistance(ResistanceType.Poison, 10, 20);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.MagicResist, 35.1, 60.0);
            SetSkill(SkillName.Tactics, 50.1, 75.0);
            SetSkill(SkillName.Wrestling, 50.1, 75.0);

            Fame = 1500;
            Karma = -1500;
        }

        public Ratman(Serial serial)
            : base(serial)
        {
        }

        public override InhumanSpeech SpeechType => InhumanSpeech.Ratman;
        public override bool CanRummageCorpses => true;
		public override int Hides => 8;
		public override HideType HideType => HideType.Regular;

		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Regular;
		public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
			AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(CheeseWedge), typeof(CheeseSlice), typeof(CheeseWheel) }, 25.0, 2, false, true));
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
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