namespace Server.Items
{

	public class Eterfer : BaseStaff  // QuarterStaff
	{
		[Constructable]
		public Eterfer()
			: base(41561)
		{
			Weight = 4.0;
			Name = "Eterfer";
		}

		public Eterfer(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
		public override int StrengthReq => 30;
		public override int MinDamage => 11;
		public override int MaxDamage => 14;
		public override float Speed => 2.25f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;
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

	public class Crochire : BaseStaff  // GnarledStaff
	{
		[Constructable]
		public Crochire()
			: base(41562)
		{
			Weight = 3.0;
			Name = "Crochire";
		}

		public Crochire(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ForceOfNature;
		public override int StrengthReq => 20;
		public override int MinDamage => 15;
		public override int MaxDamage => 18;
		public override float Speed => 3.25f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 50;
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




	
	public class BatonNature : BaseStaff // BlackStaff
	{
        [Constructable]
        public BatonNature()
            : base(41563)
        {
            Weight = 6.0;
			Name = "Bâton de la Nature";
		}

        public BatonNature(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
        public override int StrengthReq => 35;
        public override int MinDamage => 13;
        public override int MaxDamage => 16;
        public override float Speed => 2.75f;

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

	public class BatonErmite : BaseStaff // ShepherdsCrook
	{
		[Constructable]
		public BatonErmite()
			: base(41564)
		{
			Weight = 4.0;
			Name = "Bâton de l'Ermite";
		}

		public BatonErmite(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;
		public override int StrengthReq => 20;
		public override int MinDamage => 13;
		public override int MaxDamage => 16;
		public override float Speed => 2.75f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 50;

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


	public class BatonVagabond : BaseStaff // GnarledStaff
	{
		[Constructable]
		public BatonVagabond()
			: base(41565)
		{
			Weight = 3.0;
			Name = "Bâton de vagabond";
		}

		public BatonVagabond(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ForceOfNature;
		public override int StrengthReq => 20;
		public override int MinDamage => 15;
		public override int MaxDamage => 18;
		public override float Speed => 3.25f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 50;
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

	public class BatonDragonique : BaseStaff // BlackStaff
	{
		[Constructable]
		public BatonDragonique()
			: base(41566)
		{
			Weight = 6.0;
			Name = "Bâton Dragonique";
		}

		public BatonDragonique(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
		public override int StrengthReq => 35;
		public override int MinDamage => 13;
		public override int MaxDamage => 16;
		public override float Speed => 2.75f;

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

	public class CanneSapphire : BaseStaff // QuarterStaff
	{
		[Constructable]
		public CanneSapphire()
			: base(41567)
		{
			Weight = 4.0;
			Name = "Canne Sapphire";
		}

		public CanneSapphire(Serial serial)
			: base(serial)
		{
		}

		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
		public override int StrengthReq => 30;
		public override int MinDamage => 11;
		public override int MaxDamage => 14;
		public override float Speed => 2.25f;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;
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
