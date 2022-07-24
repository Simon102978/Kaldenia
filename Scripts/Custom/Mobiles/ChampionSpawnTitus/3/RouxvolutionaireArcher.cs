using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName("Corps de rouxvolutionnaire")]
	public class RouxvolutionaireArcher : TitusFanatiqueBase
	{
		[Constructable]
		public RouxvolutionaireArcher()
			: base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = Utility.RandomBool() ? "Roux-volutionaire" : "Adepte de Titus";
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

			SetStr(86, 100);
			SetDex(81, 95);
			SetInt(61, 75);

			SetDamage(15, 25);


			SetSkill(SkillName.MagicResist, 60, 80);
			SetSkill(SkillName.Archery, 70, 110);
			SetSkill(SkillName.Tactics, 80, 100);
			SetSkill(SkillName.Poisoning, 80, 100);
			SetSkill(SkillName.Wrestling, 15.0, 37.5);

			Fame = 1000;
			Karma = -1000;

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new FancyShirt());
			AddItem(new Bandana());

			AddItem(new Bow());

			Utility.AssignRandomHair(this, RouxCouleur());

			SetWeaponAbility(WeaponAbility.ParalyzingBlow);
		}

		public RouxvolutionaireArcher(Serial serial)
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
			AddLoot(LootPack.Rich);
			AddLoot(LootPack.LootItem<Arrow>(10, 25, true));
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