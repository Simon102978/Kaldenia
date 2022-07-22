using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{

	public class TitusRouxMage : TitusFanatiqueBase
	{
		[Constructable]
		public TitusRouxMage()
			: base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.05, 0.2)
		{

			SpeechHue = Utility.RandomDyedHue();
			Title = Utility.RandomBool() ? "Roux - Mage" : "Mage de Titus";
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

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new FancyShirt());
			AddItem(new Bandana());

	
			Utility.AssignRandomHair(this, RouxCouleur());
		}

		public TitusRouxMage(Serial serial)
			: base(serial)
		{
		}

		public override TribeType Tribe => TribeType.Titusien;

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
			AddLoot(LootPack.FilthyRich);
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
			AddLoot(LootPack.MedScrolls);
			AddLoot(LootPack.MageryRegs, 15);
			AddLoot(LootPack.Potions, Utility.RandomMinMax(1, 2));
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