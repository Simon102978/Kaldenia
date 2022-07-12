namespace Server.Mobiles
{
    [CorpseName("Tentacule de Kraken")]
    public class KakrenTentacle : BaseCreature
    {




        [Constructable]
        public KakrenTentacle()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Tentacule de Kraken";
            Body = 66;
            BaseSoundID = 352;
			Hue = 139;
		

			SetStr(196, 250);
			SetDex(76, 95);
			SetInt(36, 60);

			SetHits(118, 150);

			SetDamage(8, 18);

			SetDamageType(ResistanceType.Physical, 40);
            SetDamageType(ResistanceType.Poison, 60);

            SetResistance(ResistanceType.Physical, 25, 35);
            SetResistance(ResistanceType.Fire, 10, 20);
            SetResistance(ResistanceType.Cold, 10, 20);
            SetResistance(ResistanceType.Poison, 60, 80);
            SetResistance(ResistanceType.Energy, 10, 20);

			SetSkill(SkillName.MagicResist, 65.1, 80.0);
			SetSkill(SkillName.Tactics, 85.1, 100.0);
			SetSkill(SkillName.Wrestling, 85.1, 95.0);

			Fame = 3000;
            Karma = -3000;
        }

        public KakrenTentacle(Serial serial)
            : base(serial)
        {
        }

		public override bool OnBeforeDeath()
		{



			Delete();
			return true;
		}

		public override bool DeleteCorpseOnDeath => true;


		public override Poison PoisonImmune => Poison.Greater;


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
