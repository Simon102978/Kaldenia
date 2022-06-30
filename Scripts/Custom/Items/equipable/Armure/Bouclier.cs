using Server.Engines.Craft;

namespace Server.Items
{
	public class EcuBois : BaseShield
	{
		[Constructable]
		public EcuBois()
			: base(41627)
		{
			Weight = 5.0;
			Name = "Ecu de bois";
		}

		public EcuBois(Serial serial)
			: base(serial)
		{
		}

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 1;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 20;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class BouclierRond : BaseShield // buckler
	{
		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;
		public override int StrReq => 20;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Cloth;

		[Constructable]
		public BouclierRond()
			: base(41628)
		{
			Weight = 5.0;
			Name = "Bouclier Rond";
		}

		public BouclierRond(Serial serial)
			: base(serial)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class BouclierRond2 : BaseShield // buckler
	{
		public override int BasePhysicalResistance => 1;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;
		public override int StrReq => 20;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Cloth;

		[Constructable]
		public BouclierRond2()
			: base(41629)
		{
			Weight = 5.0;
			Name = "Bouclier Rond2";
		}

		public BouclierRond2(Serial serial)
			: base(serial)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class EcuLong : BaseShield // MetalKiteShield
	{
		[Constructable]
		public EcuLong()
			: base(41630)
		{
			Weight = 7.0;
			Name = "Écu Long";
		}

		public EcuLong(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 1;
		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;
		public override int StrReq => 45;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;


		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class Pavois : BaseShield // HeaterShield
	{
		[Constructable]
		public Pavois()
			: base(41631)
		{
			Weight = 8.0;
			Name = "Pavois";
		}

		public Pavois(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 90;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class Pavois2 : BaseShield // HeaterShield
	{
		[Constructable]
		public Pavois2()
			: base(41632)
		{
			Weight = 8.0;
			Name = "Pavois2";
		}

		public Pavois2(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 90;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class Rondache : BaseShield // BronzeShield
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 1;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;
		public override int StrReq => 35;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;

		[Constructable]
		public Rondache()
			: base(41633)
		{
			Weight = 6.0;
			Name = "Rondache";
		}

		public Rondache(Serial serial)
			: base(serial)
		{
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class Targe : BaseShield // ChaosShield
	{


		[Constructable]
		public Targe()
			: base(41634)
		{
			Weight = 5.0;
			Name = "Targe";
		}

		public Targe(Serial serial)
			: base(serial)
		{
		}
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 100;
		public override int InitMaxHits => 125;
		public override int StrReq => 95;
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class Targe2 : BaseShield  // ChaosShield
	{ 


		[Constructable]
		public Targe2()
			: base(41635)
		{
			Weight = 5.0;
			Name = "Targe2";
		}

		public Targe2(Serial serial)
			: base(serial)
		{
		}
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 100;
		public override int InitMaxHits => 125;
		public override int StrReq => 95;
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}

	public class Targe3 : BaseShield // ChaosShield
	{


		[Constructable]
		public Targe3()
			: base(41636)
		{
			Weight = 5.0;
			Name = "Targe3";
		}

		public Targe3(Serial serial)
			: base(serial)
		{
		}
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 0;
		public override int BaseColdResistance => 0;
		public override int BasePoisonResistance => 0;
		public override int BaseEnergyResistance => 0;
		public override int InitMinHits => 100;
		public override int InitMaxHits => 125;
		public override int StrReq => 95;
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);//version
		}
	}



}






