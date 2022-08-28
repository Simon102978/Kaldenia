using Server.Engines.Craft;

namespace Server.Items
{

	public class CasqueMaille : BaseArmor
	{
		[Constructable]
		public CasqueMaille()
			: base(41637)
		{
			Weight = 1.0;
			Name = "Casque de Maille"; 
		}

		public CasqueMaille(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 60;
		public override int StrReq => 60;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
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
	public class CasqueKorain : BaseArmor
	{
		[Constructable]
		public CasqueKorain()
			: base(0xA3DB)
		{
			Weight = 1.0;
			Name = "Casque Korain";
		}

		public CasqueKorain(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 35;
		public override int InitMaxHits => 60;
		public override int StrReq => 60;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
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

	public class GantsMaille : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;
		public override int StrReq => 60;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

		[Constructable]
		public GantsMaille()
			: base(41638)
		{
			Weight = 3.0;
			Name = "Gants de Maille";
		}

		public GantsMaille(Serial serial)
			: base(serial)
		{
		}

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

	public class JambiereMaille : BaseArmor
	{
		[Constructable]
		public JambiereMaille()
			: base(41639)
		{
			Weight = 7.0;
			Name = "Jambière de Maille";
		}

		public JambiereMaille(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;
		public override int StrReq => 60;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
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

	public class PlastronMaille : BaseArmor
	{
		[Constructable]
		public PlastronMaille()
			: base(41640)
		{
			Weight = 7.0;
			Name = "Plastron de Maille";
		}

		public PlastronMaille(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;
		public override int StrReq => 60;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
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






