namespace Server.Custom.Packaging.Packages
{
	public class SmallPackage : Item
	{
		[Constructable]
		public SmallPackage() : base(0x0E7E)
		{
			Name = "Petite caisse";
			Weight = 150.0;
		}

		public SmallPackage(Serial serial)
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
