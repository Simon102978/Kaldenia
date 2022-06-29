using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Mobiles;
using Server.Engines.Craft;

namespace Server.Items
{

	public class GrandeHacheDouble : BaseAxe // battleAxe
	{
		[Constructable]
		public GrandeHacheDouble()
			: base(41581)
		{
			Weight = 4.0;
			Name = "Grande Hache Double";
		}

		public GrandeHacheDouble(Serial serial)
			: base(serial)
		{
		}
		public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleStrike;
		public override int StrengthReq => 35;
		public override int MinDamage => 16;
		public override int MaxDamage => 19;
		public override float Speed => 3.50f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

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

	public class GrandeHache : BaseAxe //axe
	{
		[Constructable]
		public GrandeHache()
			: base(41582)
		{
			Weight = 4.0;
			Name = "Grande Hache";
		}

		public GrandeHache(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ForceOfNature;

		public override int StrengthReq => 35;
		public override int MinDamage => 12;
		public override int MaxDamage => 16;
		public override float Speed => 3.00f;

		public override int DefHitSound => 0x233;
		public override int DefMissSound => 0x239;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

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

	public class HacheDoublePiques : BaseAxe // battle axe
	{
		[Constructable]
		public HacheDoublePiques()
			: base(41583)
		{
			Weight = 4.0;
			Name = "Hache %%%#$%?%$#@! Double Piques";
		}

		public HacheDoublePiques(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
		public override int StrengthReq => 35;
		public override int MinDamage => 16;
		public override int MaxDamage => 19;
		public override float Speed => 3.50f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;
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

	public class HAchePique : BaseAxe // double axe
	{
		[Constructable]
		public HAchePique()
			: base(41584)
		{
			Weight = 4.0;
			Name = "Hache %%%#$%?%$#@! Pique";
		}

		public HAchePique(Serial serial)
			: base(serial)
		{
		}


		public override WeaponAbility PrimaryAbility => WeaponAbility.NerveStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;
		public override int StrengthReq => 35;
		public override int MinDamage => 12;
		public override int MaxDamage => 16;
		public override float Speed => 3.00f;

		public override int DefHitSound => 0x233;
		public override int DefMissSound => 0x239;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;
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


	public class HacheDouble : BaseAxe // DoubleAxes
	{
		[Constructable]
		public HacheDouble()
			: base(41585)
		{
			Weight = 4.0;
			Name = "Hache Double";
		}

		public HacheDouble(Serial serial)
			: base(serial)
		{
		}


		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Block;
		public override int StrengthReq => 45;
		public override int MinDamage => 15;
		public override int MaxDamage => 18;
		public override float Speed => 3.25f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

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

	public class HacheDoubleNaine : BaseAxe // Axe
	{
		[Constructable]
		public HacheDoubleNaine()
			: base(41586)
		{
			Weight = 4.0;
			Name = "Hache Double Naine";
		}

		public HacheDoubleNaine(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
		public override int StrengthReq => 35;
		public override int MinDamage => 12;
		public override int MaxDamage => 16;
		public override float Speed => 3.00f;

		public override int DefHitSound => 0x233;
		public override int DefMissSound => 0x239;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

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
