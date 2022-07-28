using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName("Le corps d'un Kuya")]
	public class KuyaArchiMage : KuyaBase
	{

		[Constructable]
		public KuyaArchiMage() : base(AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.4, 0.2)
		{
		
			SpeechHue = Utility.RandomDyedHue();
			Title = "Un Kuya Archimage";
			Race = Race.GetRace(Utility.Random(4));

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
				AddItem(new Skirt(Utility.RandomNeutralHue()));
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
				AddItem(new ShortPants(Utility.RandomNeutralHue()));
			}

			//BodyValue = 0x190;
			//Hue = 1281;

			SetStr(171, 200);
			SetDex(126, 145);
			SetInt(200, 265);

			SetHits(103, 120);

			//	SetHits(1200);
			SetMana(600, 800);
			SetDamage(10, 15);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Fire, 50);

			SetResistance(ResistanceType.Physical, 50, 60);
			SetResistance(ResistanceType.Fire, 50, 60);
			SetResistance(ResistanceType.Cold, 50, 60);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 50, 60);

			SetSkill(SkillName.MagicResist, 125, 140);
			SetSkill(SkillName.Tactics, 50, 120);
			SetSkill(SkillName.Wrestling, 80, 130);
			SetSkill(SkillName.Magery, 70, 100);
			SetSkill(SkillName.EvalInt, 70, 100);

		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Rich);
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
			AddLoot(LootPack.MedScrolls);
			AddLoot(LootPack.MageryRegs, 15);
			AddLoot(LootPack.Potions, Utility.RandomMinMax(1, 2));

		}

		public KuyaArchiMage(Serial serial)
			: base(serial)
		{
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