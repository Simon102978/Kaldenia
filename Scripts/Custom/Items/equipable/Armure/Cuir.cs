using Server.Engines.Craft;

namespace Server.Items
{

    public class BrassardCuirSombre : BaseArmor
    {
        [Constructable]
        public BrassardCuirSombre()
            : base(41601)
        {
            Weight = 2.0;
			Name = "Brassard de Cuir Sombre";

		}

        public BrassardCuirSombre(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 1;
        public override int BaseFireResistance => 4;
        public override int BaseColdResistance => 3;
        public override int BasePoisonResistance => 3;
        public override int BaseEnergyResistance => 3;
        public override int InitMinHits => 30;
        public override int InitMaxHits => 40;
        public override int StrReq => 20;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

	public class JambiereCuirSombre : BaseArmor
	{
		[Constructable]
		public JambiereCuirSombre()
			: base(41602)
		{
			Weight = 4.0;
			Name = "Jambiere de Cuir Sombre";
		}

		public JambiereCuirSombre(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronCuirSombre : BaseArmor
	{
		[Constructable]
		public PlastronCuirSombre()
			: base(41603)
		{
			Name = "Plastron de Cuir Sombre";
			Weight = 6.0;
		}

		public PlastronCuirSombre(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class BottesBarbare : BaseArmor
	{
		[Constructable]
		public BottesBarbare()
			: base(41604)
		{
			Weight = 4.0;
			Name = "Bottes Barbare";
		}

		public BottesBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class BrassardBarbare : BaseArmor
	{
		[Constructable]
		public BrassardBarbare()
			: base(41605)
		{
			Weight = 4.0;
			Name = "Brassard Barbare";
		}

		public BrassardBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class BrassardBarbare2 : BaseArmor
	{
		[Constructable]
		public BrassardBarbare2()
			: base(41606)
		{
			Weight = 4.0;
			Name = "Brassard Barbare2";
		}

		public BrassardBarbare2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class CasqueBarbare : BaseArmor
	{
		[Constructable]
		public CasqueBarbare()
			: base(41607)
		{
			Weight = 2.0;
			Name = "Casque Barbare";
		}

		public CasqueBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class EpauliereBarbare : BaseArmor
	{
		[Constructable]
		public EpauliereBarbare()
			: base(41608)
		{
			Weight = 2.0;
			Name = "Épaulière Barbare";

		}

		public EpauliereBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class GantsBarbare : BaseArmor
	{
		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int StrReq => 20;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public GantsBarbare()
			: base(41609)
		{
			Weight = 1.0;
			Name = "Gants Barbare";
		}

		public GantsBarbare(Serial serial)
			: base(serial)
		{
		}

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

	public class GorgetBarbare : BaseArmor
	{
		[Constructable]
		public GorgetBarbare()
			: base(41610)
		{
			Weight = 1.0;
			Name = "Gorget Barbare";
		}

		public GorgetBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 20;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class JambiereBarbare : BaseArmor
	{
		[Constructable]
		public JambiereBarbare()
			: base(41611)
		{
			Name = "Jambiere Barbare";
			Weight = 6.0;
		}

		public JambiereBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class JambiereBarbare2 : BaseArmor
	{
		[Constructable]
		public JambiereBarbare2()
			: base(41612)
		{
			Name = "Jambière Barbare2";
			Weight = 6.0;
		}

		public JambiereBarbare2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class JambiereBarbare3 : BaseArmor
	{
		[Constructable]
		public JambiereBarbare3()
			: base(41613)
		{
			Name = "Jambière Barbare3";
			Weight = 6.0;
		}

		public JambiereBarbare3(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare : BaseArmor
	{
		[Constructable]
		public PlastronBarbare()
			: base(41614)
		{
			Name = "Plastron Barbare";
			Weight = 6.0;
		}

		public PlastronBarbare(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare2 : BaseArmor
	{
		[Constructable]
		public PlastronBarbare2()
			: base(41615)
		{
			Name = "Plastron Barbare2";
			Weight = 6.0;
		}

		public PlastronBarbare2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare3 : BaseArmor
	{
		[Constructable]
		public PlastronBarbare3()
			: base(41616)
		{
			Name = "Plastron Barbare3";
			Weight = 6.0;
		}

		public PlastronBarbare3(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare4 : BaseArmor
	{
		[Constructable]
		public PlastronBarbare4()
			: base(41617)
		{
			Name = "Plastron Barbare4";
			Weight = 6.0;
		}

		public PlastronBarbare4(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare5 : BaseArmor
	{
		[Constructable]
		public PlastronBarbare5()
			: base(41618)
		{
			Name = "Plastron Barbare5";
			Weight = 6.0;
		}

		public PlastronBarbare5(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare6 : BaseArmor
	{
		[Constructable]
		public PlastronBarbare6()
			: base(41619)
		{
			Name = "Plastron Barbare5";
			Weight = 6.0;
		}

		public PlastronBarbare6(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronBarbare7 : BaseArmor
	{
		[Constructable]
		public PlastronBarbare7()
			: base(41620)
		{
			Name = "Plastron Barbare7";
			Weight = 6.0;
		}

		public PlastronBarbare7(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

}
