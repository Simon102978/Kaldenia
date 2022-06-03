using Server.Engines.Craft;

namespace Server.Items
{

	public class Sourcils1 : Beard
    {
        public Sourcils1(Serial serial)
			: base(serial)
	{
	}

	private Sourcils1()
		: this(0)
	{
	}

	private Sourcils1(int hue)
		: base(0xA3A7, hue)
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

public class Sourcils2 : Beard

	{
	public Sourcils2(Serial serial)
            : base(serial)

		{
	}

	private Sourcils2()
            : this(0)

		{
	}

	private Sourcils2(int hue)
            : base(0xA3A8, hue)

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
public class Barbe1 : Beard

	{
	public Barbe1(Serial serial)
            : base(serial)

		{
	}

	private Barbe1()
            : this(0)

		{
	}

	private Barbe1(int hue)
            : base(0xA3A9, hue)

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
public class Barbe2 : Beard

	{
	public Barbe2(Serial serial)
            : base(serial)

		{
	}

	private Barbe2()
            : this(0)

		{
	}

	private Barbe2(int hue)
            : base(0xA3AA, hue)

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
public class Barbe3 : Beard

	{
	public Barbe3(Serial serial)
            : base(serial)

		{
	}

	private Barbe3()
            : this(0)

		{
	}

	private Barbe3(int hue)
            : base(0xA3AB, hue)

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
public class LongueBarbe1 : Beard

	{
	public LongueBarbe1(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe1()
            : this(0)

		{
	}

	private LongueBarbe1(int hue)
            : base(0xA3AC, hue)

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
public class LongueBarbe2 : Beard

	{
	public LongueBarbe2(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe2()
            : this(0)

		{
	}

	private LongueBarbe2(int hue)
            : base(0xA3AD, hue)

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
public class Goat1 : Beard

	{
	public Goat1(Serial serial)
            : base(serial)

		{
	}

	private Goat1()
            : this(0)

		{
	}

	private Goat1(int hue)
            : base(0xA3AE, hue)

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
public class Goat2 : Beard

	{
	public Goat2(Serial serial)
            : base(serial)

		{
	}

	private Goat2()
            : this(0)

		{
	}

	private Goat2(int hue)
            : base(0xA3AF, hue)

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
public class LongueBarbe3 : Beard

	{
	public LongueBarbe3(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe3()
            : this(0)

		{
	}

	private LongueBarbe3(int hue)
            : base(0xA3B0, hue)

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
public class Goat3 : Beard

	{
	public Goat3(Serial serial)
            : base(serial)

		{
	}

	private Goat3()
            : this(0)

		{
	}

	private Goat3(int hue)
            : base(0xA3B1, hue)

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
public class LongueBarbe8 : Beard

	{
	public LongueBarbe8(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe8()
            : this(0)

		{
	}

	private LongueBarbe8(int hue)
            : base(0xA3B2, hue)

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
public class LongueBarbe4 : Beard

	{
	public LongueBarbe4(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe4()
            : this(0)

		{
	}

	private LongueBarbe4(int hue)
            : base(0xA3B3, hue)

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
public class LongueBarbe5 : Beard

	{
	public LongueBarbe5(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe5()
            : this(0)

		{
	}

	private LongueBarbe5(int hue)
            : base(0xA3B4, hue)

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
public class Barbe4 : Beard

	{
	public Barbe4(Serial serial)
            : base(serial)

		{
	}

	private Barbe4()
            : this(0)

		{
	}

	private Barbe4(int hue)
            : base(0xA3B5, hue)

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
public class Barbe5 : Beard

	{
	public Barbe5(Serial serial)
            : base(serial)

		{
	}

	private Barbe5()
            : this(0)

		{
	}

	private Barbe5(int hue)
            : base(0xA3B6, hue)

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
public class Moustache : Beard

	{
	public Moustache(Serial serial)
            : base(serial)

		{
	}

	private Moustache()
            : this(0)

		{
	}

	private Moustache(int hue)
            : base(0xA3B7, hue)

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
public class Moustache1 : Beard

	{
	public Moustache1(Serial serial)
            : base(serial)

		{
	}

	private Moustache1()
            : this(0)

		{
	}

	private Moustache1(int hue)
            : base(0xA3B8, hue)

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
public class Barbe6 : Beard

	{
	public Barbe6(Serial serial)
            : base(serial)

		{
	}

	private Barbe6()
            : this(0)

		{
	}

	private Barbe6(int hue)
            : base(0xA3B9, hue)

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
public class Barbe7 : Beard

	{
	public Barbe7(Serial serial)
            : base(serial)

		{
	}

	private Barbe7()
            : this(0)

		{
	}

	private Barbe7(int hue)
            : base(0xA3BA, hue)

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
public class LongueBarbe6 : Beard

	{
	public LongueBarbe6(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe6()
            : this(0)

		{
	}

	private LongueBarbe6(int hue)
            : base(0xA3BB, hue)

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
public class Barbe8 : Beard

	{
	public Barbe8(Serial serial)
            : base(serial)

		{
	}

	private Barbe8()
            : this(0)

		{
	}

	private Barbe8(int hue)
            : base(0xA3BC, hue)

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
public class LongueBarbe7 : Beard

	{
	public LongueBarbe7(Serial serial)
            : base(serial)

		{
	}

	private LongueBarbe7()
            : this(0)

		{
	}

	private LongueBarbe7(int hue)
            : base(0xA3BD, hue)

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






