using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Mobiles;

namespace Server.Items
{

	public class Runire : BaseSword // Katana
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 25;
		public override int MinDamage => 10;
		public override int MaxDamage => 14;
		public override float Speed => 2.50f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;
		[Constructable]
		public Runire()
			: base(41568) 
		{
		
			Name = "Runire";
			Weight = 8.0;
	//		Layer = Layer.TwoHanded;
		}

		public Runire(Serial serial)
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

	public class Rapiere : BaseSword // Broadsword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 30;
		public override int MinDamage => 13;
		public override int MaxDamage => 17;
		public override float Speed => 3.25f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public Rapiere()
			: base(41569)
		{

			Name = "Rapière";
			Weight = 8.0;
	//		Layer = Layer.TwoHanded;
		}

		public Rapiere(Serial serial)
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

	public class RapiereLuxe : BaseSword // Broadsword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 30;
		public override int MinDamage => 13;
		public override int MaxDamage => 17;
		public override float Speed => 3.25f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public RapiereLuxe()
			: base(41570)
		{

			Name = "Rapière de Luxe";
			Weight = 8.0;
		//	Layer = Layer.TwoHanded;
		}

		public RapiereLuxe(Serial serial)
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

	public class RapiereDecoree : BaseSword // Broadsword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 30;
		public override int MinDamage => 13;
		public override int MaxDamage => 17;
		public override float Speed => 3.25f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public RapiereDecoree()
			: base(41571)
		{

			Name = "Rapière Décorée";
			Weight = 8.0;
	//		Layer = Layer.TwoHanded;
		}

		public RapiereDecoree(Serial serial)
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

	public class EpeeBatarde : BaseSword // NoDachi
	{

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.RidingSwipe;
		public override int StrengthReq => 40;
		public override int MinDamage => 16;
		public override int MaxDamage => 19;
		public override float Speed => 3.50f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public EpeeBatarde()
			: base(41572)
		{

			Name = "Épée bâtarde";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public EpeeBatarde(Serial serial)
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

	public class EpeeBatardeLuxe : BaseSword // VikingSword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 40;
		public override int MinDamage => 15;
		public override int MaxDamage => 19;
		public override float Speed => 3.75f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public EpeeBatardeLuxe()
			: base(41573)
		{

			Name = "Épée bâtarde de luxe";
			Weight = 8.0;
		//	Layer = Layer.TwoHanded;
		}

		public EpeeBatardeLuxe(Serial serial)
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

	public class EpeeDoubleTranchant : BaseSword // Vicking sword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 40;
		public override int MinDamage => 15;
		public override int MaxDamage => 19;
		public override float Speed => 3.75f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public EpeeDoubleTranchant()
			: base(41574)
		{

			Name = "Épée à Double Tranchants";
			Weight = 8.0;
	//		Layer = Layer.TwoHanded;
		}

		public EpeeDoubleTranchant(Serial serial)
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

	public class EpeeCourte : BaseSword  // Katana
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 25;
		public override int MinDamage => 10;
		public override int MaxDamage => 14;
		public override float Speed => 2.50f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public EpeeCourte()
			: base(41575)
		{

			Name = "Épée Courte";
			Weight = 8.0;
			//Layer = Layer.TwoHanded;
		}

		public EpeeCourte(Serial serial)
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

	public class EpeeDeuxMains : BaseSword // No Dachi
	{

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.RidingSwipe;
		public override int StrengthReq => 40;
		public override int MinDamage => 16;
		public override int MaxDamage => 19;
		public override float Speed => 3.50f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public EpeeDeuxMains()
			: base(41576)
		{

			Name = "Épée Deux Mains";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public EpeeDeuxMains(Serial serial)
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

	public class EpeeLongue : BaseSword // VikingSword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 40;
		public override int MinDamage => 15;
		public override int MaxDamage => 19;
		public override float Speed => 3.75f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public EpeeLongue()
			: base(41577)
		{

			Name = "Épée Longue";
			Weight = 8.0;
	//		Layer = Layer.TwoHanded;
		}

		public EpeeLongue(Serial serial)
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

	public class Astoria : BaseSword // Scimitar
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 25;
		public override int MinDamage => 12;
		public override int MaxDamage => 16;
		public override float Speed => 3.00f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public Astoria()
			: base(41578)
		{

			Name = "Astoria";
			Weight = 8.0;
		//	Layer = Layer.TwoHanded;
		}

		public Astoria(Serial serial)
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

	public class SabreLuxe : BaseSword // Scimitar
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 25;
		public override int MinDamage => 12;
		public override int MaxDamage => 16;
		public override float Speed => 3.00f;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public SabreLuxe()
			: base(41579)
		{

			Name = "Sabre Dorée de Luxe";
			Weight = 8.0;
	//		Layer = Layer.TwoHanded;
		}

		public SabreLuxe(Serial serial)
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

	public class WakizashiLong : BaseSword // Broadsword
	{

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
		public override int StrengthReq => 30;
		public override int MinDamage => 13;
		public override int MaxDamage => 17;
		public override float Speed => 3.25f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public WakizashiLong()
			: base(41580)
		{

			Name = "Wakizashi Long";
			Weight = 8.0;
		//	Layer = Layer.TwoHanded;
		}

		public WakizashiLong(Serial serial)
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
