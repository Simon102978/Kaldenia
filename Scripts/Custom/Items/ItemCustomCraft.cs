namespace Server.Items
{
	[Furniture]
[Flipable(0x994D, 0x994E)]
public class MachineCoudre : CraftableFurniture
{
	[Constructable]
	public MachineCoudre()
		: base(0x994D)
	{
		Weight = 15.0;
		Name = "Machine à Coudre";
	}

	public MachineCoudre(Serial serial)
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
[Flipable(0x994F, 0x994F)]
public class BancMachineCoudre : CraftableFurniture
{
	[Constructable]
	public BancMachineCoudre()
		: base(0x994F)
	{
		Weight = 5.0;
		Name = "Banc Machine à Coudre";
	}

	public BancMachineCoudre(Serial serial)
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
[Flipable(0x995F, 0x9960)]
public class TinkerTable : CraftableFurniture
{
	[Constructable]
	public TinkerTable()
		: base(0x995F)
	{
		Weight = 5.0;
		Name = "Bureau de travail";
	}

	public TinkerTable(Serial serial)
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
[Flipable(0x9961, 0x9962)]
public class RepairTable : CraftableFurniture
{
	[Constructable]
	public RepairTable()
		: base(0x9961)
	{
		Weight = 5.0;
		Name = "Bureau de travail";
	}

	public RepairTable(Serial serial)
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
	[Flipable(0x9963, 0x9964)]
	public class FeedingThrough : CraftableFurniture
	{
		[Constructable]
		public FeedingThrough()
			: base(0x9963)
		{
			Weight = 5.0;
			Name = "Mangeoir";
		}

		public FeedingThrough(Serial serial)
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
[Flipable(0x9967, 0x9968)]
public class Puit : CraftableFurniture
{
	[Constructable]
	public Puit()
		: base(0x9967)
	{
		Weight = 100.0;
		Name = "Un Puit";
	}

	public Puit(Serial serial)
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
[Flipable(0x996D, 0x996D)]
public class Ancre : CraftableFurniture
{
	[Constructable]
	public Ancre()
		: base(0x996D)
	{
		Weight = 25.0;
		Name = "Une Ancre";
	}

	public Ancre(Serial serial)
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
[Flipable(0x996E, 0x996F)]
public class RackaVin : CraftableFurniture
{
	[Constructable]
	public RackaVin()
		: base(0x996E)
	{
		Weight = 25.0;
		Name = "Cellier";
	}

	public RackaVin(Serial serial)
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
[Flipable(0x9970, 0x9971)]
public class RangementAlchimie : CraftableFurniture
{
	[Constructable]
	public RangementAlchimie()
		: base(0x9970)
	{
		Weight = 25.0;
		Name = "Armoire Alchimiste";
	}

	public RangementAlchimie(Serial serial)
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