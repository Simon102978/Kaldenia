namespace Server.Items
{
    [Flipable(5353, 5354)]
    public class MouldingBoard : Item
    {
        [Constructable]
        public MouldingBoard()
            : base(5353)
        {
        }

        public MouldingBoard(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class DoughBowl : Item
    {
        [Constructable]
        public DoughBowl()
            : base(4323)
        {
        }

        public DoughBowl(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class HornedTotemPole : Item
    {
        [Constructable]
        public HornedTotemPole()
            : base(12289)
        {
        }

        public HornedTotemPole(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class LargeSquarePillow : Item, IDyable
	{
        [Constructable]
        public LargeSquarePillow()
            : base(5691)
        {
        }
		public bool Dye(Mobile from, DyeTub sender)
		{
			if (Deleted)
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public LargeSquarePillow(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class LargeDiamondPillow : Item, IDyable
	{
        [Constructable]
        public LargeDiamondPillow()
            : base(5690)
        {
        }
		public bool Dye(Mobile from, DyeTub sender)
		{
			if (Deleted)
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public LargeDiamondPillow(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

	public class SmallDiamondPillow : Item, IDyable
	{
		[Constructable]
		public SmallDiamondPillow()
			: base(0x163C)
		{
		}
		public bool Dye(Mobile from, DyeTub sender)
		{
			if (Deleted)
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public SmallDiamondPillow(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // ver
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class DustyPillow : Item
    {
        public override int LabelNumber => 1113638;  // dusty pillow

        [Constructable]
        public DustyPillow()
            : base(Utility.RandomList(5690, 5691))
        {
        }

        public DustyPillow(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class StatuePedestal : Item
    {
        [Constructable]
        public StatuePedestal()
            : base(13042)
        {
            Weight = 5;
        }

        public StatuePedestal(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // ver
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class FlouredBreadBoard : Item
    {
        public override int LabelNumber => 1113639;  // floured bread board

        [Constructable]
        public FlouredBreadBoard()
            : base(0x14E9)
        {
            Weight = 3.0;
        }

        public FlouredBreadBoard(Serial serial)
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
