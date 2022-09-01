using Server.Items;

namespace Server.Mobiles
{
    public class KuyaBard : KuyaBase
	{
        [Constructable]
        public KuyaBard()
			: base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.05, 0.2)
		{
			SpeechHue = Utility.RandomDyedHue();
			
			Race = Race.GetRace(5);

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("tokuno female");
				AddItem(new Skirt(Utility.RandomNeutralHue()));
				Title = "Kuya Envoutante";
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("tokuno male");
				AddItem(new ShortPants(Utility.RandomNeutralHue()));
				Title = "Kuya Envoutant";
			}
			
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
            SetSkill(SkillName.Archery, 36, 67);
            SetSkill(SkillName.Parry, 45, 60);
            SetSkill(SkillName.Musicianship, 66.0, 97.5);
            SetSkill(SkillName.Peacemaking, 65.0, 87.5);
			SetSkill(SkillName.Provocation, 65.0, 87.5);

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

		public override bool CanPeace => true;
		public override bool CanProvoke => true;

		public override void GenerateLoot()
        {
            AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(Harp), typeof(Lute), typeof(Drums), typeof(Tambourine) }));
            AddLoot(LootPack.LootItem<Longsword>(true));
            AddLoot(LootPack.LootItem<Bow>(true));
            AddLoot(LootPack.LootItem<Arrow>(100, true));
			AddLoot(LootPack.Average);
			//            AddLoot(LootPack.LootGold(10, 50));
		}

        public KuyaBard(Serial serial)
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
