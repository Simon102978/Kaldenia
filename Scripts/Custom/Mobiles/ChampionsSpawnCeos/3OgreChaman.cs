using System.Collections.Generic;
using System.Collections;


namespace Server.Mobiles
{
    [CorpseName("Cadavre d'Ogre")]
    public class OgreShaman : BaseCeosSpawn
	{
		public override Poison pet => Poison.Regular;
		public static Dictionary<Mobile, Timer> Table { get; private set; }

		[Constructable]
        public OgreShaman()
            : base(AIType.AI_Spellweaving, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Ogre Chaman";
            Body = 1;
            BaseSoundID = 427;

			SetStr(225, 400);

			SetHits(3500);
			SetMana(600, 800);
			SetDamage(15, 21);

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

        public OgreShaman(Serial serial)
            : base(serial)
        {
        }

		public override bool CanRummageCorpses => true;
        public override int TreasureMapLevel => 1;
        public override int Meat => 2;

		public override int Hides => 6;
		public override HideType HideType => HideType.Geant;


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Geant;


		public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Potions,2);
			AddLoot(LootPack.MedScrolls, 2);
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