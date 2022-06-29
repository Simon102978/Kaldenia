using Server.Engines.Craft;

namespace Server.Items
{

	public class BrassardCloute : BaseArmor
	{
		[Constructable]
		public BrassardCloute()
			: base(41621)
		{
			Weight = 4.0;
			Name = "Brassard Clouté";
		}

		public BrassardCloute(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;
		public override int StrReq => 25;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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

	public class JupeCloute : BaseArmor
	{
		[Constructable]
		public JupeCloute()
			: base(41622)
		{
			Weight = 5.0;
			Name = "Jupe Clouté";
		}

		public JupeCloute(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;
		public override int StrReq => 30;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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

	public class PlastronCloute : BaseArmor
	{
		[Constructable]
		public PlastronCloute()
			: base(41623)
		{
			Weight = 8.0;
			Name = "Plastron Clouté";
		}

		public PlastronCloute(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;
		public override int StrReq => 35;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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

	public class PlastronCloute2 : BaseArmor
	{
		[Constructable]
		public PlastronCloute2()
			: base(41624)
		{
			Weight = 8.0;
			Name = "Plastron Clouté2";
		}

		public PlastronCloute2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;
		public override int StrReq => 35;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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

	public class PlastronCloute3 : BaseArmor
	{
		[Constructable]
		public PlastronCloute3()
			: base(41625)
		{
			Weight = 8.0;
			Name = "Plastron Clouté3";
		}

		public PlastronCloute3(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;
		public override int StrReq => 35;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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

	public class PlastronCloute4 : BaseArmor
	{
		[Constructable]
		public PlastronCloute4()
			: base(41626)
		{
			Weight = 8.0;
			Name = "Plastron Clouté4";
		}

		public PlastronCloute4(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;
		public override int StrReq => 35;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;
		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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






