using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Mobiles;

namespace Server.Items
{

	public class DoubleEpee : BaseSword
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




}
