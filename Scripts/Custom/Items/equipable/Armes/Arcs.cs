using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{


    public class Legarc : BaseRanged
    {

		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();
		public override WeaponAbility PrimaryAbility => WeaponAbility.MovingShot;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleShot;
		public override int StrengthReq => 30;
		public override int MinDamage => 17;
		public override int MaxDamage => 21;
		public override float Speed => 4.25f;

		public override int DefMaxRange => 10;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;
		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
		public Legarc() : base(41554) // 0x299F - 10655
        {
			Weight = 6.0;
			Layer = Layer.TwoHanded;
            Name = "Legarc";
		}

        public Legarc(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
    }
    public class Tarkarc : BaseRanged
    {
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
		public override int StrengthReq => 30;
		public override int MinDamage => 17;
		public override int MaxDamage => 21;
		public override float Speed => 4.25f;

		public override int DefMaxRange => 10;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;
		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
        public Tarkarc()
            : base(41555) // 0x299E  - 10654
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Arc court renforcit";
        }

        public Tarkarc(Serial serial)
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
    public class Souplecorde : BaseRanged
    {
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
		public override int StrengthReq => 45;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

		public override int DefMaxRange => 10;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;
		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
        public Souplecorde()
            : base(41556) //0x299D - 10653
		{
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Souplecorde";
        }

        public Souplecorde(Serial serial)
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
    public class Sombrevent : BaseRanged
    {
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();
		public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;
		public override int StrengthReq => 45;
		public override int MinDamage => 16;
		public override int MaxDamage => 20;
		public override float Speed => 4.00f;

		public override int DefMaxRange => 10;
		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;
		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
        public Sombrevent()
            : base(41557) // 0x299C - 10652
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Sombrevent";
        }

        public Sombrevent(Serial serial)
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
