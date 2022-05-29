using Server.Engines.Craft;

namespace Server.Items
{

	public class Bottes :  BaseShoes
    {
        [Constructable]
	public Bottes()
			: this(0)
	{
	}

	[Constructable]
	public Bottes(int hue)
		: base(41821, hue)
	{
		Weight = 2.0;
		Name ="Bottes";
	}

	public Bottes(Serial serial)
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

public class Bottes2 :  BaseShoes

	{
	[Constructable]
	public Bottes2()
            : this(0)

		{
	}

	[Constructable]
	public Bottes2(int hue)
            : base(41822, hue)

		{
		Weight = 2.0;
		Name ="Bottes2";
	}

	public Bottes2(Serial serial)
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
public class Bottes3 :  BaseShoes

	{
	[Constructable]
	public Bottes3()
            : this(0)

		{
	}

	[Constructable]
	public Bottes3(int hue)
            : base(41823, hue)

		{
		Weight = 2.0;
		Name ="Bottes3";
	}

	public Bottes3(Serial serial)
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
public class Bottes4 :  BaseShoes

	{
	[Constructable]
	public Bottes4()
            : this(0)

		{
	}

	[Constructable]
	public Bottes4(int hue)
            : base(41824, hue)

		{
		Weight = 2.0;
		Name ="Bottes4";
	}

	public Bottes4(Serial serial)
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
public class Bottes5 :  BaseShoes

	{
	[Constructable]
	public Bottes5()
            : this(0)

		{
	}

	[Constructable]
	public Bottes5(int hue)
            : base(41825, hue)

		{
		Weight = 2.0;
		Name ="Bottes5";
	}

	public Bottes5(Serial serial)
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
public class Bottes6 :  BaseShoes

	{
	[Constructable]
	public Bottes6()
            : this(0)

		{
	}

	[Constructable]
	public Bottes6(int hue)
            : base(41826, hue)

		{
		Weight = 2.0;
		Name ="Bottes6";
	}

	public Bottes6(Serial serial)
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
public class Bottes7 :  BaseShoes

	{
	[Constructable]
	public Bottes7()
            : this(0)

		{
	}

	[Constructable]
	public Bottes7(int hue)
            : base(41827, hue)

		{
		Weight = 2.0;
		Name ="Bottes7";
	}

	public Bottes7(Serial serial)
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
public class Bottes8 :  BaseShoes

	{
	[Constructable]
	public Bottes8()
            : this(0)

		{
	}

	[Constructable]
	public Bottes8(int hue)
            : base(41828, hue)

		{
		Weight = 2.0;
		Name ="Bottes8";
	}

	public Bottes8(Serial serial)
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
public class Bottes9 :  BaseShoes

	{
	[Constructable]
	public Bottes9()
            : this(0)

		{
	}

	[Constructable]
	public Bottes9(int hue)
            : base(41829, hue)

		{
		Weight = 2.0;
		Name ="Bottes9";
	}

	public Bottes9(Serial serial)
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
public class Bottes10 :  BaseShoes

	{
	[Constructable]
	public Bottes10()
            : this(0)

		{
	}

	[Constructable]
	public Bottes10(int hue)
            : base(41830, hue)

		{
		Weight = 2.0;
		Name ="Bottes10";
	}

	public Bottes10(Serial serial)
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






