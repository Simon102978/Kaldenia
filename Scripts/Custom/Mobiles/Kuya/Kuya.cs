using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{

	public class Kuya : KuyaBase
	{
		[Constructable]
		public Kuya()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.05, 0.2)
		{
			SpeechHue = Utility.RandomDyedHue();
			
			Race = Race.GetRace(Utility.Random(4));

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("tokuno female");
				Title = "Kuya Guerriere";
				AddItem(new Skirt(Utility.RandomNeutralHue()));
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("tokuno male");
				Title = "Kuya Guerrier";
				AddItem(new ShortPants(Utility.RandomNeutralHue()));
			}

			SetStr(86, 100);
			SetDex(200, 500);
			SetInt(61, 75);

			SetDamage(10, 23);

			SetSkill(SkillName.Fencing, 66.0, 97.5);
			SetSkill(SkillName.Macing, 65.0, 87.5);
			SetSkill(SkillName.MagicResist, 25.0, 47.5);
			SetSkill(SkillName.Swords, 65.0, 87.5);
			SetSkill(SkillName.Tactics, 65.0, 87.5);
			SetSkill(SkillName.Wrestling, 15.0, 37.5);

			Fame = 1000;
			Karma = -1000;
			switch (Utility.Random(3))
			{
				case 0:
					AddItem(new Lajatang());
					break;
				case 1:
					AddItem(new Wakizashi());
					break;
				case 2:
					AddItem(new NoDachi());
					break;
			}

			switch (Utility.Random(3))
			{
				case 0:
					AddItem(new LeatherSuneate());
					break;
				case 1:
					AddItem(new PlateSuneate());
					break;
				case 2:
					AddItem(new StuddedHaidate());
					break;
			}

			switch (Utility.Random(4))
			{
				case 0:
					AddItem(new LeatherJingasa());
					break;
				case 1:
					AddItem(new ChainHatsuburi());
					break;
				case 2:
					AddItem(new HeavyPlateJingasa());
					break;
				case 3:
					AddItem(new DecorativePlateKabuto());
					break;
			}

			AddItem(new LeatherDo());
			AddItem(new LeatherHiroSode());
			AddItem(new SamuraiTabi(Utility.RandomNondyedHue())); // TODO: Hue

			int hairHue = Utility.RandomNondyedHue();

			Utility.AssignRandomHair(this, hairHue);

			if (Utility.Random(7) != 0)
				Utility.AssignRandomFacialHair(this, hairHue);

		}

		public Kuya(Serial serial)
			: base(serial)
		{
		}

	

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