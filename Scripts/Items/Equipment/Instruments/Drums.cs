namespace Server.Items
{
    public class Drums : BaseInstrument
    {
        [Constructable]
        public Drums()
            : base(0xE9C, 0x38, 0x39)
        {
            Weight = 4.0;
        }

        public Drums(Serial serial)
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
	public class Guitare : BaseInstrument
	{
		[Constructable]
		public Guitare()
			: base(0xA3F3)
		{
			Weight = 4.0;
			Name = "Une Guitare";
			Layer = Layer.TwoHanded;
		}

		public Guitare(Serial serial)
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

	public class HarpeLongue : BaseInstrument
	{
		[Constructable]
		public HarpeLongue()
			: base(0xA3F4)
		{
			Weight = 4.0;
			Name = "Une Harpe Longue";
			Layer = Layer.TwoHanded;
		}

		public HarpeLongue(Serial serial)
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