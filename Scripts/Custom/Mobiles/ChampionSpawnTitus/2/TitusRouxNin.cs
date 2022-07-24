using Server.Items;
using Server.Mobiles;
using System;

namespace Server.Mobiles
{

	public class TitusRouxNin : TitusFanatiqueBase
	{


		public override bool AlwaysMurderer => true;
		public override bool CanStealth => true;

		private DateTime m_NextWeaponChange;

		[Constructable]
		public TitusRouxNin()
			: base(AIType.AI_Ninja, FightMode.Closest, 10, 1, 0.05, 0.2)
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = Utility.RandomBool() ? "Roux-Nin" : "Ninja de Titus";
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

			SetHits(251, 350);

			SetStr(126, 225);
			SetDex(81, 95);
			SetInt(151, 165);

			SetDamage(12, 20);

			SetDamageType(ResistanceType.Physical, 65);
			SetDamageType(ResistanceType.Fire, 15);
			SetDamageType(ResistanceType.Poison, 15);
			SetDamageType(ResistanceType.Energy, 5);

			SetResistance(ResistanceType.Physical, 35, 65);
			SetResistance(ResistanceType.Fire, 40, 60);
			SetResistance(ResistanceType.Cold, 25, 45);
			SetResistance(ResistanceType.Poison, 40, 60);
			SetResistance(ResistanceType.Energy, 35, 55);

			SetSkill(SkillName.Anatomy, 105.0, 120.0);
			SetSkill(SkillName.MagicResist, 80.0, 100.0);
			SetSkill(SkillName.Tactics, 115.0, 130.0);
			SetSkill(SkillName.Wrestling, 95.0, 120.0);
			SetSkill(SkillName.Fencing, 95.0, 120.0);
			SetSkill(SkillName.Macing, 95.0, 120.0);
			SetSkill(SkillName.Swords, 95.0, 120.0);

			SetSkill(SkillName.Ninjitsu, 95.0, 120.0);
			SetSkill(SkillName.Hiding, 100.0);

			LeatherNinjaBelt belt = new LeatherNinjaBelt
			{
				UsesRemaining = 20,
				Poison = Poison.Greater,
				PoisonCharges = 20,
				Movable = false
			};
			AddItem(belt);

			int amount = Skills[SkillName.Ninjitsu].Value >= 100 ? 2 : 1;

			for (int i = 0; i < amount; i++)
			{
				Fukiya f = new Fukiya
				{
					UsesRemaining = 10,
					Poison = amount == 1 ? Poison.Regular : Poison.Greater,
					PoisonCharges = 10,
					Movable = false
				};
				PackItem(f);
			}

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new FancyShirt());
			AddItem(new Bandana());

			if (Utility.RandomDouble() < 0.33)
				PackItem(new SmokeBomb());

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

			Utility.AssignRandomHair(this, RouxCouleur());

			ChangeWeapon();
		}

		public TitusRouxNin(Serial serial)
			: base(serial)
		{
		}


		public override bool CanRummageCorpses => true;

		public override bool ClickTitle => false;

		public override bool ShowFameTitle => false;

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
		}


		private void ChangeWeapon()
		{
			if (Backpack == null)
				return;

			Item item = FindItemOnLayer(Layer.OneHanded);

			if (item == null)
				item = FindItemOnLayer(Layer.TwoHanded);

			System.Collections.Generic.List<BaseWeapon> weapons = new System.Collections.Generic.List<BaseWeapon>();

			foreach (Item i in Backpack.Items)
			{
				if (i is BaseWeapon && i != item)
					weapons.Add((BaseWeapon)i);
			}

			if (weapons.Count > 0)
			{
				if (item != null)
					Backpack.DropItem(item);

				AddItem(weapons[Utility.Random(weapons.Count)]);

				m_NextWeaponChange = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 60));
			}

			ColUtility.Free(weapons);
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Rich, 2);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
			AddLoot(LootPack.Potions, Utility.RandomMinMax(1, 2));
			AddLoot(LootPack.Statue, 1, 5);

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