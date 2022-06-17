using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName("Le corps d'un Kuya")]
	public class KuyaMage : BaseCreature
	{

		[Constructable]
		public KuyaMage() : base(AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.4, 0.2)
		{
			Name = NameList.RandomName("male");
			Title = "Un Kuya Mage";
			SetStr(100, 125);

			BodyValue = 0x190;
			Hue = 1281;

			SetHits(1200);
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
			SetSkill(SkillName.Tactics, 100, 120);
			SetSkill(SkillName.Wrestling, 110, 130);
			SetSkill(SkillName.Magery, 70, 100);
			SetSkill(SkillName.EvalInt, 70, 100);

			AddItem(new ClothNinjaJacket(1156));
			AddItem(new NinjaTabi());

			SpeechHue = Utility.RandomDyedHue();
			Race = BaseRace.GetRace(Utility.Random(4));

			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
			}


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

		public override bool CanRummageCorpses => true;
		public override bool AlwaysMurderer => true;

		
		public override void GenerateLoot()
		{
			AddLoot(LootPack.Rich, 2);
	
			AddLoot(LootPack.MageryRegs, 31);

		}

		public KuyaMage(Serial serial)
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