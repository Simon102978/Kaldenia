using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Mobiles;

namespace Server.Items
{
	public class Epieu : BaseSpear
	{
		[Constructable]
		public Epieu()
			: base(41588)
		{
			Weight = 7.0;
			Name = "Épieu";
		}

		public Epieu(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Feint;
		public override int StrengthReq => 50;
		public override int MinDamage => 9;
		public override int MaxDamage => 11;
		public override float Speed => 2.75f;

		public override int DefMaxRange => 2;

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

	public class GrandeFourche : BaseSpear
	{
		[Constructable]
		public GrandeFourche()
			: base(41589)
		{
			Weight = 7.0;
			Name = "Grande Fourche";
		}

		public GrandeFourche(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Block;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 50;
		public override int MinDamage => 9;
		public override int MaxDamage => 11;
		public override float Speed => 2.75f;

		public override int DefMaxRange => 2;

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

	public class Hellebarde : BaseSpear
	{
		[Constructable]
		public Hellebarde()
			: base(41590)
		{
			Weight = 7.0;
			Name = "Hellebarde";
		}

		public Hellebarde(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;
		public override int StrengthReq => 50;
		public override int MinDamage => 9;
		public override int MaxDamage => 11;
		public override float Speed => 2.75f;

		public override int DefMaxRange => 2;

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

	public class JavelotLuxe : BaseSpear
	{
		[Constructable]
		public JavelotLuxe()
			: base(41591)
		{
			Weight = 7.0;
			Name = "Javelot de Guerre";
		}

		public JavelotLuxe(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.MortalStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 50;
		public override int MinDamage => 6;
		public override int MaxDamage => 8;
		public override float Speed => 2.75f;

		public override int DefMaxRange => 2;

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

	public class Trident : BaseSpear
	{
		[Constructable]
		public Trident()
			: base(41592)
		{
			Weight = 7.0;
			Name = "Trident";
		}

		public Trident(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ForceOfNature;
		public override int StrengthReq => 50;
		public override int MinDamage => 9;
		public override int MaxDamage => 11;
		public override float Speed => 2.75f;

		public override int DefMaxRange => 2;

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
