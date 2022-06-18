namespace Server.Custom.Packaging.Packages
{
	public class LargePackage : Item
	{
		[Constructable]
		public LargePackage() : base(0x0E3C)
		{
			Name = "Large caisse";
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
