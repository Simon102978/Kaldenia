namespace Server.Items
{
	[Flipable(0x0980, 0x0981, 0x0982, 0x0983, 0x0984, 0x0985, 0x0986, 0x0987, 0x0988, 0x0989, 0x098A, 0x098B)]
	public class RideauRouge : Item
	{
		[Constructable]
		public RideauRouge()
			: base(0x0980)
		{
			Name = "Rideau Rouge";
			Weight = 0.5;
		}

		public RideauRouge(Serial serial)
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

	[Flipable(0x12DA, 0x12DB, 0x12DC, 0x12DD, 0x12DE, 0x12DF, 0x12E0, 0x12E1, 0x12E2, 0x12E3, 0x12E4, 0x12E5, 0x12E6, 0x12E7, 0x12E8, 0x12E9, 0x12EA, 0x12EB, 0x12EC, 0x12ED)]
	public class RideauBlanc : Item
	{
		[Constructable]
		public RideauBlanc()
			: base(0x12DA)
		{
			Name = "Rideau Blanc";
			Weight = 0.5;
		}

		public RideauBlanc(Serial serial)
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

	[Flipable(0x159E, 0x159F, 0x15F6, 0x15F7)]
	public class Voilage : Item
	{
		[Constructable]
		public Voilage()
			: base(0x159E)
		{
			Name = "Voilage";
			Weight = 0.5;
		}

		public Voilage(Serial serial)
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