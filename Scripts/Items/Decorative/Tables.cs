namespace Server.Items
{
    [Furniture]
    public class ElegantLowTable : CraftableFurniture
    {
        [Constructable]
        public ElegantLowTable()
            : base(0x2819)
        {
            Weight = 1.0;
        }

        public ElegantLowTable(Serial serial)
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

    [Furniture]
    public class PlainLowTable : CraftableFurniture
    {
        [Constructable]
        public PlainLowTable()
            : base(0x281A)
        {
            Weight = 1.0;
        }

        public PlainLowTable(Serial serial)
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

    [Furniture]
    [Flipable(0xB90, 0xB7D)]
    public class LargeTable : CraftableFurniture
    {
        [Constructable]
        public LargeTable()
            : base(0xB90)
        {
            Weight = 1.0;
        }

        public LargeTable(Serial serial)
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

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }

    [Furniture]
    [Flipable(0xB35, 0xB34)]
    public class Nightstand : CraftableFurniture
    {
        [Constructable]
        public Nightstand()
            : base(0xB35)
        {
            Weight = 1.0;
        }

        public Nightstand(Serial serial)
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

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }

    [Furniture]
    [Flipable(0xB8F, 0xB7C)]
    public class YewWoodTable : CraftableFurniture
    {
        [Constructable]
        public YewWoodTable()
            : base(0xB8F)
        {
            Weight = 1.0;
        }

        public YewWoodTable(Serial serial)
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

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
	[Flipable(0x1910, 0x1911, 0x1912, 0x1913, 0x1918, 0x1919, 0x191A, 0x191B, 0x191C, 0x191D, 0x191E, 0x191F)]
	public class BarComptoir : CraftableFurniture
	{


		[Constructable]
		public BarComptoir()
			: base(0x1910)
		{
			Weight = 15;
			Name = "Comptoir Bar";
		}



		public BarComptoir(Serial serial)
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
			reader.ReadInt();
		}
	}
	[Flipable(0x0B3D, 0x0B3E, 0x0B3F, 0x0B40)]
	public class Comptoir : CraftableFurniture
	{


		[Constructable]
		public Comptoir()
			: base(0x0B3D)
		{
			Weight = 15;
			Name = "Comptoir";
		}



		public Comptoir(Serial serial)
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
			reader.ReadInt();
		}
	}

	[Furniture]
    public class TerMurStyleTable : Item
    {
        public override int LabelNumber => 1095321;  // Ter-Mur style table

        [Constructable]
        public TerMurStyleTable()
            : base(0x4041)
        {
            Weight = 10.0;
        }

        public TerMurStyleTable(Serial serial)
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
}