namespace Server.Custom.Packaging.Packages
{
	public class LargePackage : CustomPackaging
	{

		public override double Conversion => 0.90;

		[Constructable]
		public LargePackage() : base(0x996B)
		{
			Name = "Coffre Doré";
			Weight = 300.0;
		}

		public LargePackage(Serial serial)
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
