namespace Server.Custom.Packaging.Packages
{
	public class CoffreBoisPackage : CustomPackaging
	{

		public override double Conversion => 1.0;


		[Constructable]
		public CoffreBoisPackage() : base(0x0E42)
		{
			Name = "Coffre en bois";
			Weight = 500.0;
		}

		public CoffreBoisPackage(Serial serial)
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
}
