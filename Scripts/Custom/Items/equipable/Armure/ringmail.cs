using Server.Engines.Craft;

namespace Server.Items
{

	public class BrassardMaille : BaseArmor
	{
		[Constructable]
		public BrassardMaille()
			: base(41660)
		{
			Weight = 15.0;
			Name = "Brassard de Maille";
		}

		public BrassardMaille(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 1;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;
		public override int StrReq => 40;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;
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

	public class PlastronMaille2 : BaseArmor
	{
		[Constructable]
		public PlastronMaille2()
			: base(41662)
		{
			Weight = 15.0;
			Name = "Plastron de Maille2";
		}

		public PlastronMaille2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 1;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;
		public override int StrReq => 40;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;
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

	public class JambiereMaille2 : BaseArmor
	{
		[Constructable]
		public JambiereMaille2()
			: base(41661)
		{
			Weight = 15.0;
			Name = "Jambi%%%#$%?%$#@!re de Maille2";
		}

		public JambiereMaille2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 1;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;
		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;
		public override int StrReq => 40;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;
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
