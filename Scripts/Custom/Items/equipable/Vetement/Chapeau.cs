using Server.Engines.Craft;

namespace Server.Items
{

	public class Capuche :  BaseHat
    {
        [Constructable]
	public Capuche()
			: this(0)
	{
	}

	[Constructable]
	public Capuche(int hue)
		: base(41803, hue)
	{
		Weight = 2.0;
		Name ="Capuche";
	}

	public Capuche(Serial serial)
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

public class Capuche2 :  BaseHat

	{
	[Constructable]
	public Capuche2()
            : this(0)

		{
	}

	[Constructable]
	public Capuche2(int hue)
            : base(41804, hue)

		{
		Weight = 2.0;
		Name = "Grande Capuche";
	}

	public Capuche2(Serial serial)
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
public class TeteCoyote :  BaseHat

	{
	[Constructable]
	public TeteCoyote()
            : this(0)

		{
	}

	[Constructable]
	public TeteCoyote(int hue)
            : base(41805, hue)

		{
		Weight = 2.0;
		Name ="Tete de Coyote";
	}

	public TeteCoyote(Serial serial)
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
public class TeteTaureau :  BaseHat

	{
	[Constructable]
	public TeteTaureau()
            : this(0)

		{
	}

	[Constructable]
	public TeteTaureau(int hue)
            : base(41806, hue)

		{
		Weight = 2.0;
		Name ="Tete de Taureau";
	}

	public TeteTaureau(Serial serial)
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
public class Toque :  BaseHat

	{
	[Constructable]
	public Toque()
            : this(0)

		{
	}

	[Constructable]
	public Toque(int hue)
            : base(41807, hue)

		{
		Weight = 2.0;
		Name ="Toque";
	}

	public Toque(Serial serial)
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
public class Turban :  BaseHat

	{
	[Constructable]
	public Turban()
            : this(0)

		{
	}

	[Constructable]
	public Turban(int hue)
            : base(41808, hue)

		{
		Weight = 2.0;
		Name ="Turban";
	}

	public Turban(Serial serial)
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
public class VoileTete :  BaseHat

	{
	[Constructable]
	public VoileTete()
            : this(0)

		{
	}

	[Constructable]
	public VoileTete(int hue)
            : base(41809, hue)

		{
		Weight = 2.0;
		Name ="Voile";
	}

	public VoileTete(Serial serial)
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
public class VoileTeteLong :  BaseHat

	{
	[Constructable]
	public VoileTeteLong()
            : this(0)

		{
	}

	[Constructable]
	public VoileTeteLong(int hue)
            : base(41810, hue)

		{
		Weight = 2.0;
		Name ="Long Voile";
	}

	public VoileTeteLong(Serial serial)
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


	public class ChapeauPirate : BaseHat

	{
		[Constructable]
		public ChapeauPirate()
				: this(0)

		{
		}

		[Constructable]
		public ChapeauPirate(int hue)
				: base(41844, hue)

		{
			Weight = 2.0;
			Name = "Chapeau de Pirate";
		}

		public ChapeauPirate(Serial serial)
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






