using Server.Engines.Craft;

namespace Server.Items
{
	public class Pantalon1 :  BasePants
    {
        [Constructable]
	public Pantalon1()
			: this(0)
	{
	}

	[Constructable]
	public Pantalon1(int hue)
		: base(41776, hue)
	{
		Weight = 2.0;
		Name = "Pantalon Ample";
	}

	public Pantalon1(Serial serial)
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

public class Pantalon2 :  BasePants

	{
	[Constructable]
	public Pantalon2()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon2(int hue)
            : base(41777, hue)

		{
		Weight = 2.0;
		Name = "Pantalon à Motifs";
	}

	public Pantalon2(Serial serial)
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
public class Pantalon3 :  BasePants

	{
	[Constructable]
	public Pantalon3()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon3(int hue)
            : base(41778, hue)

		{
		Weight = 2.0;
		Name = "Pantalon à Fourrure";
	}

	public Pantalon3(Serial serial)
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
public class Pantalon4 :  BasePants

	{
	[Constructable]
	public Pantalon4()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon4(int hue)
            : base(41779, hue)

		{
		Weight = 2.0;
		Name = "Pantalon à Poches";
	}

	public Pantalon4(Serial serial)
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
public class Pantalon5 :  BasePants

	{
	[Constructable]
	public Pantalon5()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon5(int hue)
            : base(41780, hue)

		{
		Weight = 2.0;
		Name = "Pantalon de Cuir";
	}

	public Pantalon5(Serial serial)
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
public class Pantalon6 :  BasePants

	{
	[Constructable]
	public Pantalon6()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon6(int hue)
            : base(41781, hue)

		{
		Weight = 2.0;
		Name = "Pantalon Court à Ceinture";
	}

	public Pantalon6(Serial serial)
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
public class Pantalon7 :  BasePants

	{
	[Constructable]
	public Pantalon7()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon7(int hue)
            : base(41782, hue)

		{
		Weight = 2.0;
		Name = "Short Droit";
	}

	public Pantalon7(Serial serial)
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
public class Pantalon8 :  BasePants

	{
	[Constructable]
	public Pantalon8()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon8(int hue)
            : base(41783, hue)

		{
		Weight = 2.0;
		Name = "Short Ample";
	}

	public Pantalon8(Serial serial)
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
public class Pantalon9 :  BasePants

	{
	[Constructable]
	public Pantalon9()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon9(int hue)
            : base(41784, hue)

		{
		Weight = 2.0;
		Name = "Short de Toile";
	}

	public Pantalon9(Serial serial)
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
public class Pantalon10 :  BasePants

	{
	[Constructable]
	public Pantalon10()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon10(int hue)
            : base(41785, hue)

		{
		Weight = 2.0;
		Name = "Pantalon Sombre";
	}

	public Pantalon10(Serial serial)
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
public class Pantalon11 :  BasePants

	{
	[Constructable]
	public Pantalon11()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon11(int hue)
            : base(41786, hue)

		{
		Weight = 2.0;
		Name = "Pantalon Jupe";
	}

	public Pantalon11(Serial serial)
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
public class Pantalon12 :  BasePants

	{
	[Constructable]
	public Pantalon12()
            : this(0)

		{
	}

	[Constructable]
	public Pantalon12(int hue)
            : base(41787, hue)

		{
		Weight = 2.0;
		Name = "Pantalon de Toile";
	}

	public Pantalon12(Serial serial)
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
public class Salopette :  BasePants

	{
	[Constructable]
	public Salopette()
            : this(0)

		{
	}

	[Constructable]
	public Salopette(int hue)
            : base(41788, hue)

		{
		Weight = 2.0;
		Name ="Salopette";
	}

	public Salopette(Serial serial)
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
	public class CulotteLeopard : BasePants

	{
		[Constructable]
		public CulotteLeopard()
				: this(0)

		{
		}

		[Constructable]
		public CulotteLeopard(int hue)
				: base(0xA415, hue)

		{
			Weight = 2.0;
			Name = "Culotte Leopard";
		}

		public CulotteLeopard(Serial serial)
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






