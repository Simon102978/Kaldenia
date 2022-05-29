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
		Name ="Toge";
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
		Name ="Toge2";
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
		Name ="Toge3";
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
		Name ="Toge4";
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
		Name ="Toge5";
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
		Name ="Toge6";
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
		Name ="Toge7";
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
		Name ="Toge8";
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


	



}






