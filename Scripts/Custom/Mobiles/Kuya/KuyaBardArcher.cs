using Server.Items;

namespace Server.Mobiles
{
    public class KuyaBardArcher : KuyaBase
	{
        [Constructable]
        public KuyaBardArcher()
		   : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.05, 0.2)
		{
            SpeechHue = Utility.RandomDyedHue();
            Hue = Utility.RandomSkinHue();
            Title = "Kuya menestrel";


            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");

                switch (Utility.Random(2))
                {
                    case 0:
                        AddItem(new Skirt(Utility.RandomDyedHue()));
                        break;
                    case 1:
                        AddItem(new Kilt(Utility.RandomNeutralHue()));
                        break;
                }
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
            }
    //        Title = "the bard";
            HairItemID = Race.RandomHair(Female);
            HairHue = Race.RandomHairHue();
            Race.RandomFacialHair(this);

            SetStr(85, 100);
            SetDex(85, 100);
            SetInt(50, 75);



            SetDamage(5, 10);

            SetSkill(SkillName.Tactics, 35, 57);
            SetSkill(SkillName.Magery, 22, 22);
            SetSkill(SkillName.Swords, 45, 67);
            SetSkill(SkillName.Archery, 70, 80);
            SetSkill(SkillName.Parry, 45, 60);
            SetSkill(SkillName.Musicianship, 45.0, 70);
			SetSkill(SkillName.Musicianship, 66.0, 97.5);
			SetSkill(SkillName.Discordance, 65.0, 87.5);

            Fame = 100;
            Karma = 100;

            AddItem(new Shoes(Utility.RandomNeutralHue()));


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

			AddItem(new Bow());

			AddItem(new MaleKimono());
		}

		public override bool CanDiscord => true;


		public override void GenerateLoot()
        {
            AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(Harp), typeof(Lute), typeof(Drums), typeof(Tambourine) }));
            AddLoot(LootPack.LootItem<Longsword>(true));
            AddLoot(LootPack.LootItem<Bow>(true));
            AddLoot(LootPack.LootItem<Arrow>(100, true));
            AddLoot(LootPack.Average);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
      //      AddLoot(LootPack.LootGold(10, 50));
        }

        public KuyaBardArcher(Serial serial)
            : base(serial)
        {
        }

        public override bool ClickTitle => false;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);// version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
