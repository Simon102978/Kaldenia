using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Mobiles;

namespace Server.Items
{
	public class GrandeMasse : BaseBashing
	{
		[Constructable]
		public GrandeMasse()
			: base(41593)
		{
			Weight = 17.0;
			Name = "Grande Masse";
		}

		public GrandeMasse(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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

	public class MarteauPointes : BaseBashing
	{
		[Constructable]
		public MarteauPointes()
			: base(41594)
		{
			Weight = 17.0;
			Name = "Marteau %%%#$%?%$#@! Pointes";
		}

		public MarteauPointes(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Block;
		public override WeaponAbility SecondaryAbility => WeaponAbility.FrenziedWhirlwind;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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


	public class Marteau : BaseBashing
	{
		[Constructable]
		public Marteau()
			: base(41595)
		{
			Weight = 17.0;
			Name = "Marteau";
			Layer = Layer.TwoHanded;
		}

		public Marteau(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
		public override int StrengthReq => 45;
		public override int MinDamage => 14;
		public override int MaxDamage => 18;
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


	public class MassueClous : BaseBashing
	{
		[Constructable]
		public MassueClous()
			: base(41596)
		{
			Weight = 17.0;
			Name = "Massue %%%#$%?%$#@! Clous";
		}

		public MassueClous(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.ForceOfNature;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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


	public class MassuePointes : BaseBashing
	{
		[Constructable]
		public MassuePointes()
			: base(41597)
		{
			Weight = 17.0;
			Name = "Massue %%%#$%?%$#@! Pointes";
		}

		public MassuePointes(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Disarm;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleStrike;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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


	public class Massue : BaseBashing
	{
		[Constructable]
		public Massue()
			: base(41598)
		{
			Weight = 17.0;
			Name = "Massue";
		}

		public Massue(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ShadowStrike;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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


	public class MorgensternBoules : BaseBashing
	{
		[Constructable]
		public MorgensternBoules()
			: base(41599)
		{
			Weight = 17.0;
			Name = "Morgenstern %%%#$%?%$#@! Boules";
		}

		public MorgensternBoules(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
		public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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


	public class MorgensternPointes : BaseBashing
	{
		[Constructable]
		public MorgensternPointes()
			: base(41600)
		{
			Weight = 17.0;
			Name = "Morgenstern %%%#$%?%$#@! Pointes";
		}

		public MorgensternPointes(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DualWield;
		public override int StrengthReq => 80;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

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

}
