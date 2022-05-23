using Server.Engines.Craft;

namespace Server.Items
{
	public class BrassardChaos : BaseArmor
	{
		[Constructable]
		public BrassardChaos()
			: base(41646)
		{
			Weight = 5.0;
			Name = "Brassard du Chaos";
		}

		public BrassardChaos(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class CasqueChaos : BaseArmor
	{
		[Constructable]
		public CasqueChaos()
			: base(41647)
		{
			Weight = 5.0;
			Name = "Casque Du Chaos";
		}

		public CasqueChaos(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class PlastronChaos : BaseArmor
	{
		[Constructable]
		public PlastronChaos()
			: base(41648)
		{
			Weight = 10.0;
			Name = "Plastron du Chaos";
		}

		public PlastronChaos(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 95;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class BrassardDecoratif : BaseArmor
	{
		[Constructable]
		public BrassardDecoratif()
			: base(41649)
		{
			Weight = 5.0;
			Name = "Brassard Décoratif";
		}

		public BrassardDecoratif(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class CasqueDecoratif : BaseArmor
	{
		[Constructable]
		public CasqueDecoratif()
			: base(41650)
		{
			Weight = 5.0;
			Name = "Casque Décoratif";
		}

		public CasqueDecoratif(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class JambiereDecoratif : BaseArmor
	{
		[Constructable]
		public JambiereDecoratif()
			: base(41651)
		{
			Weight = 7.0;
			Name = "Jambière Décoratif";
		}

		public JambiereDecoratif(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 90;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class PlastronDecoratif : BaseArmor
	{
		[Constructable]
		public PlastronDecoratif()
			: base(41652)
		{
			Weight = 10.0;
			Name = "Plastron Décoratif";
		}

		public PlastronDecoratif(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 95;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class BottesElfique : BaseArmor
	{
		[Constructable]
		public BottesElfique()
			: base(41653)
		{
			Weight = 7.0;
			Name = "Bottes Elfique";
		}

		public BottesElfique(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 90;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class CasqueElfique : BaseArmor
	{
		[Constructable]
		public CasqueElfique()
			: base(41654)
		{
			Weight = 5.0;
			Name = "Casque Elfique";
		}

		public CasqueElfique(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class GantsElfique : BaseArmor
	{
		[Constructable]
		public GantsElfique()
			: base(41655)
		{
			Weight = 2.0;
			Name = "Gants Elfique";
		}

		public GantsElfique(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 70;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

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

	public class GorgetElfique : BaseArmor
	{
		[Constructable]
		public GorgetElfique()
			: base(41656)
		{
			Weight = 2.0;
			Name = "Gorget Elfique";
		}

		public GorgetElfique(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 45;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class PlastronElfique : BaseArmor
	{
		[Constructable]
		public PlastronElfique()
			: base(41657)
		{
			Weight = 10.0;
			Name = "Plastron Elfique";
		}

		public PlastronElfique(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 95;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class PlastronPlaque : BaseArmor
	{
		[Constructable]
		public PlastronPlaque()
			: base(41658)
		{
			Weight = 10.0;
			Name = "Plastron de plaque";
		}

		public PlastronPlaque(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 95;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

	public class PlastronPlaqueDoree : BaseArmor
	{
		[Constructable]
		public PlastronPlaqueDoree()
			: base(41659)
		{
			Weight = 10.0;
			Name = "Plastron de plaque Dorée";
		}

		public PlastronPlaqueDoree(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 95;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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






