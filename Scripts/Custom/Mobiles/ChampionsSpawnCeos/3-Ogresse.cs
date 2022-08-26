using Server.Items;

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

			SetHits(476, 552);
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


		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvoutePhysique>(), Utility.RandomMinMax(2, 4));
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Average);
			AddLoot(LootPack.Potions, 2);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
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
