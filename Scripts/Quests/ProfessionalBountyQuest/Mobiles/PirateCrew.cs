using Server.Items;
using Server.Misc;
using System;

namespace Server.Mobiles
{
    [CorpseName("Le corps d'un Pirate")]
	public class PirateCrew : BaseCreature
	{
		[Constructable]
		public PirateCrew()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "Pirate";
			Race = BaseRace.GetRace(Utility.Random(4));
			

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

			SetStr(100, 125);
			SetDex(90, 100);
			SetInt(61, 75);
			SetHits(250);
			SetDamage(10, 23);

			SetSkill(SkillName.Fencing, 66.0, 97.5);
			SetSkill(SkillName.Macing, 65.0, 87.5);
			SetSkill(SkillName.MagicResist, 25.0, 47.5);
			SetSkill(SkillName.Swords, 65.0, 87.5);
			SetSkill(SkillName.Tactics, 65.0, 87.5);
			SetSkill(SkillName.Wrestling, 15.0, 37.5);

			Fame = 1000;
			Karma = -1000;

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new FancyShirt());
			AddItem(new Bandana());

			switch (Utility.Random(7))
			{
				case 0:
					AddItem(new Longsword());
					break;
				case 1:
					AddItem(new Cutlass());
					break;
				case 2:
					AddItem(new Broadsword());
					break;
				case 3:
					AddItem(new Axe());
					break;
				case 4:
					AddItem(new Club());
					break;
				case 5:
					AddItem(new Dagger());
					break;
				case 6:
					AddItem(new Spear());
					break;
			}

			Utility.AssignRandomHair(this);
		}

		public PirateCrew(Serial serial)
			: base(serial)
		{
		}

		public override bool ClickTitle => false;
		public override bool AlwaysMurderer => true;

		public override bool ShowFameTitle => false;

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Average);
			  
	}
		public override int TreasureMapLevel => 3;
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


   