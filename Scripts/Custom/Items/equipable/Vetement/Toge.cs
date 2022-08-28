using Server.Engines.Craft;

namespace Server.Items
{
	public class Toge :  BaseOuterTorso
    {
        [Constructable]
	public Toge()
			: this(0)
	{
	}

	[Constructable]
	public Toge(int hue)
		: base(41728, hue)
	{
		Weight = 2.0;
		Name = "Toge Souple";
	}

	public Toge(Serial serial)
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

public class Toge2 :  BaseOuterTorso

	{
	[Constructable]
	public Toge2()
            : this(0)

		{
	}

	[Constructable]
	public Toge2(int hue)
            : base(41729, hue)

		{
		Weight = 2.0;
		Name = "Toge Propre";
	}

	public Toge2(Serial serial)
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
public class Toge3 :  BaseOuterTorso

	{
	[Constructable]
	public Toge3()
            : this(0)

		{
	}

	[Constructable]
	public Toge3(int hue)
            : base(41730, hue)

		{
		Weight = 2.0;
		Name = "Toge à épaulettes";
	}

	public Toge3(Serial serial)
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
public class Toge4 :  BaseOuterTorso

	{
	[Constructable]
	public Toge4()
            : this(0)

		{
	}

	[Constructable]
	public Toge4(int hue)
            : base(41731, hue)

		{
		Weight = 2.0;
		Name = "Toge en toile";
	}

	public Toge4(Serial serial)
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
public class Toge5 :  BaseOuterTorso

	{
	[Constructable]
	public Toge5()
            : this(0)

		{
	}

	[Constructable]
	public Toge5(int hue)
            : base(41732, hue)

		{
		Weight = 2.0;
		Name = "Toge à ceinture large";
	}

	public Toge5(Serial serial)
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
public class Toge6 :  BaseOuterTorso

	{
	[Constructable]
	public Toge6()
            : this(0)

		{
	}

	[Constructable]
	public Toge6(int hue)
            : base(41733, hue)

		{
		Weight = 2.0;
		Name = "Toge à ceinture dorée";
	}

	public Toge6(Serial serial)
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
public class Toge7 :  BaseOuterTorso

	{
	[Constructable]
	public Toge7()
            : this(0)

		{
	}

	[Constructable]
	public Toge7(int hue)
            : base(41734, hue)

		{
		Weight = 2.0;
		Name = "Toge en voile";
	}

	public Toge7(Serial serial)
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
public class Toge8 :  BaseOuterTorso

	{

		public override bool Disguise { get { return true; } }

		[Constructable]
	public Toge8()
            : this(0)

		{
	}

	[Constructable]
	public Toge8(int hue)
            : base(41735, hue)

		{
		Weight = 2.0;
		Name = "Toge Sombre";
	}

	public Toge8(Serial serial)
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
	public class TogeSparte : BaseOuterTorso

	{
		[Constructable]
		public TogeSparte()
				: this(0)

		{
		}

		[Constructable]
		public TogeSparte(int hue)
				: base(0xA3C9, hue)

		{
			Weight = 2.0;
			Name = "Toge Sparte";
		}

		public TogeSparte(Serial serial)
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
	public class Poncho : BaseOuterTorso

	{
		[Constructable]
		public Poncho()
				: this(0)

		{
		}

		[Constructable]
		public Poncho(int hue)
				: base(0xA3ED, hue)

		{
			Weight = 2.0;
			Name = "Poncho";
		}

		public Poncho(Serial serial)
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

	public class TogePhilosophe : BaseOuterTorso

	{
		[Constructable]
		public TogePhilosophe()
				: this(0)

		{
		}

		[Constructable]
		public TogePhilosophe(int hue)
				: base(0xA3F7, hue)

		{
			Weight = 2.0;
			Name = "Toge Philosophe";
		}

		public TogePhilosophe(Serial serial)
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
	public class TogeKoraine : BaseOuterTorso

	{
		[Constructable]
		public TogeKoraine()
				: this(0)

		{
		}

		[Constructable]
		public TogeKoraine(int hue)
				: base(0xA3CA, hue)

		{
			Weight = 2.0;
			Name = "Toge Koraine";
		}

		public TogeKoraine(Serial serial)
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






