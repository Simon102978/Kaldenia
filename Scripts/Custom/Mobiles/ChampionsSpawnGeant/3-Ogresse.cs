namespace Server.Mobiles
{
	[CorpseName("Corp d'Ogresse")]
	public class Ogresse : BaseCeosSpawn
	{

		public override Poison pet => Poison.Regular;

		[Constructable]
		public Ogresse()
			: base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			Name = "Ogresse";
			Body = 83;
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

			Fame = 5000;
			Karma = 0;
		}

		public Ogresse(Serial serial)
			: base(serial)
		{
		}

		public override TribeType Tribe => TribeType.Fey;

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Rich);
			AddLoot(LootPack.MedScrolls);
		}

		public override int Meat => 1;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}



}
