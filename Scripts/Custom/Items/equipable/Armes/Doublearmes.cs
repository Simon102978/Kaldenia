using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Mobiles;

namespace Server.Items
{

	public class DoubleEpee : BaseSword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DefenseMastery;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Block;
		public override int StrengthReq => 40;
		public override int MinDamage => 13;
		public override int MaxDamage => 16;
		public override float Speed => 2.75f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public DoubleEpee()
			: base(41558) 
		{
		
			Name = "Double Épée";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public DoubleEpee(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class DoubleHachette : BaseSword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.InfectiousStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;
		public override int StrengthReq => 40;
		public override int MinDamage => 13;
		public override int MaxDamage => 16;
		public override float Speed => 2.75f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public DoubleHachette()
			: base(41559) 
		{

			Name = "Double Hachette";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public DoubleHachette(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class DoubleLames : BaseKatar
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Feint;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleStrike;
		public override int StrengthReq => 40;
		public override int MinDamage => 13;
		public override int MaxDamage => 16;
		public override float Speed => 2.75f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public DoubleLames()
			: base(41560) 
		{

			Name = "Double Lames de poing";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public DoubleLames(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class 	AnneauxCombat : BaseKatar
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.PsychicAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;
		public override int StrengthReq => 35;
		public override int MinDamage => 12;
		public override int MaxDamage => 15;
		public override float Speed => 2.50f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public AnneauxCombat()
			: base(0xA3DF)
		{

			Name = "Anneaux de Combat";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public AnneauxCombat(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class GriffesCombat  : BaseKatar
	{


		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleStrike;
		public override int StrengthReq => 10;
		public override int MinDamage => 10;
		public override int MaxDamage => 14;
		public override float Speed => 2.50f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public GriffesCombat()
			: base(0xA3E0)
		{

			Name = "Griffes de Combat";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public GriffesCombat(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class 	KamaKuya : BaseKatar
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorPierce;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;
		public override int StrengthReq => 10;
		public override int MinDamage => 10;
		public override int MaxDamage => 14;
		public override float Speed => 2.50f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public KamaKuya()
			: base(0xA3E1)
		{

			Name = "Kama Kuya";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public KamaKuya(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class 	LameCirculaire  : BaseKatar
	{

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DualWield;
		public override int StrengthReq => 40;
		public override int MinDamage => 16;
		public override int MaxDamage => 19;
		public override float Speed => 3.50f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public LameCirculaire()
			: base(0xA3E2)
		{

			Name = "Lame Circulaire";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public LameCirculaire(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class Kama1 : BaseKatar
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Bladeweave;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DefenseMastery;
		public override int StrengthReq => 10;
		public override int MinDamage => 10;
		public override int MaxDamage => 12;
		public override float Speed => 2.00f;
		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 65;

		[Constructable]
		public Kama1()
			: base(0xA3E3)
		{

			Name = "Kama";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public Kama1(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}



}
