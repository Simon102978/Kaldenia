using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{

	public class KuyaMage : KuyaBase
	{
		[Constructable]
		public KuyaMage()
			: base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.05, 0.2)
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "Kuya Mage";
			Race = Race.GetRace(Utility.Random(4));

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("tokuno female");
				AddItem(new Skirt(Utility.RandomNeutralHue()));
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("tokuno male");
				AddItem(new ShortPants(Utility.RandomNeutralHue()));
			}

			SetStr(20);
			SetDex(150);
			SetInt(125);

			SetDamage(9, 15);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 80, 90);
			SetResistance(ResistanceType.Fire, 40, 50);
			SetResistance(ResistanceType.Cold, 40, 50);
			SetResistance(ResistanceType.Poison, 40, 50);
			SetResistance(ResistanceType.Energy, 40, 50);

			SetSkill(SkillName.EvalInt, 70.1, 80.0);
			SetSkill(SkillName.Magery, 70.1, 80.0);
			SetSkill(SkillName.Meditation, 70.1, 80.0);
			SetSkill(SkillName.MagicResist, 50.5, 100.0);
			SetSkill(SkillName.Tactics, 10.1, 20.0);
			SetSkill(SkillName.Wrestling, 10.1, 12.5);



			switch (Utility.Random(6))
			{
				case 0:
					AddItem(new MaleKimono());
					break;
				case 1:
					AddItem(new FemaleKimono());
					break;
				case 2:
					AddItem(new ClothNinjaJacket());
					break;
				case 3:
					AddItem(new Hakama());
					break;
				case 4:
					AddItem(new HakamaShita());
					break;
				case 5:
					AddItem(new Obi());
					break;
			}

			switch (Utility.Random(2))
			{
				case 0:
					AddItem(new Kasa());
					break;
				case 1:
					AddItem(new Kasa());
					break;
				case 2:
					AddItem(new HeavyPlateJingasa());
					break;
				case 3:
					AddItem(new DecorativePlateKabuto());
					break;
			}

			AddItem(new MaleKimono());

			int hairHue = Utility.RandomNondyedHue();

			Utility.AssignRandomHair(this, hairHue);

			if (Utility.Random(7) != 0)
				Utility.AssignRandomFacialHair(this, hairHue);
		}

		public KuyaMage(Serial serial)
			: base(serial)
		{
		}


		public override bool CanRummageCorpses => true;

		public override bool ClickTitle => false;
		public override bool AlwaysMurderer => true;

		public override bool ShowFameTitle => false;

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);


		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Average);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}