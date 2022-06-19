namespace Server.Custom.Packaging.Packages
{
	public class MediumPackage : CustomPackaging
	{
		public override double Conversion => 0.80;

		[Constructable]
		public MediumPackage() : base(0x0E3E)
		{
			Name = "Moyenne caisse";
			Weight = 225.0;
		}

		public MediumPackage(Serial serial)
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
