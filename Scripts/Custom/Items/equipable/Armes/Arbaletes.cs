using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{


    public class Percemurs : BaseRanged
	{
		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();
		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
		public override int StrengthReq => 35;
		public override int MinDamage => 18;
		public override int MaxDamage => 22;
		public override float Speed => 4.50f;

		public override int DefMaxRange => 8;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;


		[Constructable]
        public Percemurs()
            : base(41551) 
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Percemurs";
        }

        public Percemurs(Serial serial)
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

	public class Arbavive : BaseRanged
	{

		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();
		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
		public override int StrengthReq => 35;
		public override int MinDamage => 18;
		public override int MaxDamage => 22;
		public override float Speed => 4.50f;

		public override int DefMaxRange => 8;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;
		[Constructable]
		public Arbavive()
			: base(41552) 
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Name = "Arbavive";
		}

		public Arbavive(Serial serial)
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

	public class Lumitrait : BaseRanged
	{
		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();
		public override WeaponAbility PrimaryAbility => WeaponAbility.MovingShot;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;
		public override int StrengthReq => 80;
		public override int MinDamage => 20;
		public override int MaxDamage => 24;
		public override float Speed => 5.00f;

		public override int DefMaxRange => 8;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public Lumitrait()
			: base(41550) 
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Name = "Lumitrait";
		}

		public Lumitrait(Serial serial)
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

	public class ArbaletteChasse : BaseRanged
	{
		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();
		public override WeaponAbility PrimaryAbility => WeaponAbility.MovingShot;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;
		public override int StrengthReq => 80;
		public override int MinDamage => 20;
		public override int MaxDamage => 24;
		public override float Speed => 5.00f;

		public override int DefMaxRange => 8;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public ArbaletteChasse()
			: base(41553) 
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Name = "Arbaletes de chasse";
		}

		public ArbaletteChasse(Serial serial)
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
