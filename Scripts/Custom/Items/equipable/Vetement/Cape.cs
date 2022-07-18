using Server.Engines.Craft;

namespace Server.Items
{
	public class Cape :  BaseCloak
    {
        [Constructable]
	public Cape()
			: this(0)
	{
	}

	[Constructable]
	public Cape(int hue)
		: base(41831, hue)
	{
		Weight = 2.0;
		Name = "Cape à Vollets";
	}

	public Cape(Serial serial)
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

public class Cape2 :  BaseCloak

	{
	[Constructable]
	public Cape2()
            : this(0)

		{
	}

	[Constructable]
	public Cape2(int hue)
            : base(41832, hue)

		{
		Weight = 2.0;
		Name = "Cape à plumes";
	}

	public Cape2(Serial serial)
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
public class Cape3 :  BaseCloak

	{
	[Constructable]
	public Cape3()
            : this(0)

		{
	}

	[Constructable]
	public Cape3(int hue)
            : base(41833, hue)

		{
		Weight = 2.0;
		Name = "Cape à voiles";
	}

	public Cape3(Serial serial)
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
public class Cape4 :  BaseCloak

	{
	[Constructable]
	public Cape4()
            : this(0)

		{
	}

	[Constructable]
	public Cape4(int hue)
            : base(41834, hue)

		{
		Weight = 2.0;
		Name = "Cape à épaulière";
	}

	public Cape4(Serial serial)
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
public class Cape5 :  BaseCloak

	{
	[Constructable]
	public Cape5()
            : this(0)

		{
	}

	[Constructable]
	public Cape5(int hue)
            : base(41835, hue)

		{
		Weight = 2.0;
		Name = "Cape à rabat";
	}

	public Cape5(Serial serial)
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
public class Cape6 :  BaseCloak

	{
	[Constructable]
	public Cape6()
            : this(0)

		{
	}

	[Constructable]
	public Cape6(int hue)
            : base(41836, hue)

		{
		Weight = 2.0;
		Name = "Cape en fourrure";
	}

	public Cape6(Serial serial)
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
public class Cape7 :  BaseCloak

	{
	[Constructable]
	public Cape7()
            : this(0)

		{
	}

	[Constructable]
	public Cape7(int hue)
            : base(41837, hue)

		{
		Weight = 2.0;
		Name = "Cape à bande doré";
	}

	public Cape7(Serial serial)
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
public class Cape8 :  BaseCloak

	{
	[Constructable]
	public Cape8()
            : this(0)

		{
	}

	[Constructable]
	public Cape8(int hue)
            : base(41838, hue)

		{
		Weight = 2.0;
		Name = "Demi cape avec cuir";
	}

	public Cape8(Serial serial)
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
public class Cape9 :  BaseCloak

	{
	[Constructable]
	public Cape9()
            : this(0)

		{
	}

	[Constructable]
	public Cape9(int hue)
            : base(41839, hue)

		{
		Weight = 2.0;
		Name = "Demi cape Distinguée";
	}

	public Cape9(Serial serial)
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
public class Cape10 :  BaseCloak

	{
	[Constructable]
	public Cape10()
            : this(0)

		{
	}

	[Constructable]
	public Cape10(int hue)
            : base(41840, hue)

		{
		Weight = 2.0;
		Name = "Demi cape en cuir";
	}

	public Cape10(Serial serial)
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
public class Cape11 :  BaseCloak

	{
	[Constructable]
	public Cape11()
            : this(0)

		{
	}

	[Constructable]
	public Cape11(int hue)
            : base(41841, hue)

		{
		Weight = 2.0;
		Name = "Demi cape élégante";
	}

	public Cape11(Serial serial)
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
	public class CapeBleu : BaseCloak

	{
		[Constructable]
		public CapeBleu()
				: this(0)

		{
		}

		[Constructable]
		public CapeBleu(int hue)
				: base(0xA3C8, hue)

		{
			Weight = 2.0;
			Name = "Cape Bleue";
		}

		public CapeBleu(Serial serial)
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
	public class Drapee : BaseCloak

	{
		[Constructable]
		public Drapee()
				: this(0)

		{
		}

		[Constructable]
		public Drapee(int hue)
				: base(0xA3D9, hue)

		{
			Weight = 2.0;
			Name = "Drapee";
		}

		public Drapee(Serial serial)
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






