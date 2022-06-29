using Server.Engines.Craft;

namespace Server.Items
{

	public class Tabar :  BaseMiddleTorso
    {
        [Constructable]
	public Tabar()
			: this(0)
	{
	}

	[Constructable]
	public Tabar(int hue)
		: base(41736, hue)
	{
		Weight = 2.0;
		Name = "Tabar simple";
	}

	public Tabar(Serial serial)
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

public class Tabar1 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar1()
            : this(0)

		{
	}

	[Constructable]
	public Tabar1(int hue)
            : base(41737, hue)

		{
		Weight = 2.0;
		Name = "Tabar orn??#$?&*";
	}

	public Tabar1(Serial serial)
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
public class Tabar2 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar2()
            : this(0)

		{
	}

	[Constructable]
	public Tabar2(int hue)
            : base(41738, hue)

		{
		Weight = 2.0;
		Name ="Tabar2";
	}

	public Tabar2(Serial serial)
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
public class Tabar3 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar3()
            : this(0)

		{
	}

	[Constructable]
	public Tabar3(int hue)
            : base(41739, hue)

		{
		Weight = 2.0;
		Name = "Tabar à cape";
	}

	public Tabar3(Serial serial)
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
public class Tabar4 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar4()
            : this(0)

		{
	}

	[Constructable]
	public Tabar4(int hue)
            : base(41740, hue)

		{
		Weight = 2.0;
		Name = "Tabar sombre";
	}

	public Tabar4(Serial serial)
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
public class Tabar5 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar5()
            : this(0)

		{
	}

	[Constructable]
	public Tabar5(int hue)
            : base(41741, hue)

		{
		Weight = 2.0;
		Name = "Tabar sombre à griffon";
	}

	public Tabar5(Serial serial)
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
public class Tabar6 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar6()
            : this(0)

		{
	}

	[Constructable]
	public Tabar6(int hue)
            : base(41742, hue)

		{
		Weight = 2.0;
		Name = "Tabar à arbre";
	}

	public Tabar6(Serial serial)
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
public class Tabar7 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar7()
            : this(0)

		{
	}

	[Constructable]
	public Tabar7(int hue)
            : base(41743, hue)

		{
		Weight = 2.0;
		Name = "Tabar dor??#$?&*";
	}

	public Tabar7(Serial serial)
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
public class Tabar8 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar8()
            : this(0)

		{
	}

	[Constructable]
	public Tabar8(int hue)
            : base(41744, hue)

		{
		Weight = 2.0;
		Name = "Tabar dor??#$?&* capiton??#$?&*";
	}

	public Tabar8(Serial serial)
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
public class Tabar9 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar9()
            : this(0)

		{
	}

	[Constructable]
	public Tabar9(int hue)
            : base(41745, hue)

		{
		Weight = 2.0;
		Name = "Grand tabar ouvert";
	}

	public Tabar9(Serial serial)
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
public class Tabar10 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar10()
            : this(0)

		{
	}

	[Constructable]
	public Tabar10(int hue)
            : base(41746, hue)

		{
		Weight = 2.0;
		Name = "Grand tabar de toile";
	}

	public Tabar10(Serial serial)
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
public class Tabar11 :  BaseMiddleTorso

	{
	[Constructable]
	public Tabar11()
            : this(0)

		{
	}

	[Constructable]
	public Tabar11(int hue)
            : base(41747, hue)

		{
		Weight = 2.0;
		Name = "Grand tabar simple";
	}

	public Tabar11(Serial serial)
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






