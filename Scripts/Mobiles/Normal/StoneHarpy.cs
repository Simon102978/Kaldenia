using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a stone harpy corpse")]
    public class StoneHarpy : Harpy
	{
        [Constructable]
        public StoneHarpy()
            : base()
        {
            Name = "a stone harpy";
            Body = 73;
            BaseSoundID = 402;

            SetStr(296, 320);
            SetDex(86, 110);
            SetInt(51, 75);

            SetHits(178, 192);
            SetMana(0);

            SetDamage(8, 16);

            SetDamageType(ResistanceType.Physical, 75);
            SetDamageType(ResistanceType.Poison, 25);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 20, 30);
            SetResistance(ResistanceType.Cold, 10, 20);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 50.1, 65.0);
            SetSkill(SkillName.Tactics, 70.1, 100.0);
            SetSkill(SkillName.Wrestling, 70.1, 100.0);

            Fame = 4500;
            Karma = -4500;
        }

        public StoneHarpy(Serial serial)
            : base(serial)
        {
        }

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteEnergie>(), Utility.RandomMinMax(2, 4));
		}


		public override int Meat => 1;
        public override int Feathers => 50;
        public override bool CanFly => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average, 2);
			AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(SilverRing), typeof(Necklace), typeof(SilverNecklace), typeof(Collier), typeof(Collier2) }, 5.0, 1, false, true));
			AddLoot(LootPack.LootItem<PlumesHarpie>());
			AddLoot(LootPack.LootItem<OeufPierre>());
			// AddLoot(LootPack.Gems, 2);
		}

        public override int GetAttackSound()
        {
            return 916;
        }

        public override int GetAngerSound()
        {
            return 916;
        }

        public override int GetDeathSound()
        {
            return 917;
        }

        public override int GetHurtSound()
        {
            return 919;
        }

        public override int GetIdleSound()
        {
            return 918;
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