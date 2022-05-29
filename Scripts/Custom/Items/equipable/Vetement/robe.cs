using Server.Engines.Craft;

namespace Server.Items
{

	public class Robe2 :  BaseOuterTorso
    {
        [Constructable]
	public Robe2()
			: this(0)
	{
	}

	[Constructable]
	public Robe2(int hue)
		: base(41694, hue)
	{
		Weight = 2.0;
		Name = "Robe2";
	}

	public Robe2(Serial serial)
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

public class Robe19 :  BaseOuterTorso

	{
	[Constructable]
	public Robe19()
            : this(0)

		{
	}

	[Constructable]
	public Robe19(int hue)
            : base(41697, hue)

		{
		Weight = 2.0;
		Name ="Robe19";
	}

	public Robe19(Serial serial)
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
public class RobeCourte :  BaseOuterTorso

	{
	[Constructable]
	public RobeCourte()
            : this(0)

		{
	}

	[Constructable]
	public RobeCourte(int hue)
            : base(41698, hue)

		{
		Weight = 2.0;
		Name ="Robe Courte";
	}

	public RobeCourte(Serial serial)
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
public class Robe3 :  BaseOuterTorso

	{
	[Constructable]
	public Robe3()
            : this(0)

		{
	}

	[Constructable]
	public Robe3(int hue)
            : base(41699, hue)

		{
		Weight = 2.0;
		Name ="Robe3";
	}

	public Robe3(Serial serial)
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
public class Robe4 :  BaseOuterTorso

	{
	[Constructable]
	public Robe4()
            : this(0)

		{
	}

	[Constructable]
	public Robe4(int hue)
            : base(41700, hue)

		{
		Weight = 2.0;
		Name ="Robe4";
	}

	public Robe4(Serial serial)
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
public class RobeProvocante :  BaseOuterTorso

	{
	[Constructable]
	public RobeProvocante()
            : this(0)

		{
	}

	[Constructable]
	public RobeProvocante(int hue)
            : base(41702, hue)

		{
		Weight = 2.0;
		Name ="Robe Provocante";
	}

	public RobeProvocante(Serial serial)
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
public class Robe5 :  BaseOuterTorso

	{
	[Constructable]
	public Robe5()
            : this(0)

		{
	}

	[Constructable]
	public Robe5(int hue)
            : base(41709, hue)

		{
		Weight = 2.0;
		Name ="Robe5";
	}

	public Robe5(Serial serial)
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
public class Robe6 :  BaseOuterTorso

	{
	[Constructable]
	public Robe6()
            : this(0)

		{
	}

	[Constructable]
	public Robe6(int hue)
            : base(41710, hue)

		{
		Weight = 2.0;
		Name ="Robe6";
	}

	public Robe6(Serial serial)
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
public class Robe7 :  BaseOuterTorso

	{
	[Constructable]
	public Robe7()
            : this(0)

		{
	}

	[Constructable]
	public Robe7(int hue)
            : base(41711, hue)

		{
		Weight = 2.0;
		Name ="Robe7";
	}

	public Robe7(Serial serial)
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
public class Robe8 :  BaseOuterTorso

	{
	[Constructable]
	public Robe8()
            : this(0)

		{
	}

	[Constructable]
	public Robe8(int hue)
            : base(41712, hue)

		{
		Weight = 2.0;
		Name ="Robe8";
	}

	public Robe8(Serial serial)
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
public class Robe9 :  BaseOuterTorso

	{
	[Constructable]
	public Robe9()
            : this(0)

		{
	}

	[Constructable]
	public Robe9(int hue)
            : base(41713, hue)

		{
		Weight = 2.0;
		Name ="Robe9";
	}

	public Robe9(Serial serial)
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
public class Robe10 :  BaseOuterTorso

	{
	[Constructable]
	public Robe10()
            : this(0)

		{
	}

	[Constructable]
	public Robe10(int hue)
            : base(41714, hue)

		{
		Weight = 2.0;
		Name ="Robe10";
	}

	public Robe10(Serial serial)
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
public class Robe11 :  BaseOuterTorso

	{
	[Constructable]
	public Robe11()
            : this(0)

		{
	}

	[Constructable]
	public Robe11(int hue)
            : base(41715, hue)

		{
		Weight = 2.0;
		Name ="Robe11";
	}

	public Robe11(Serial serial)
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
public class Robe12 :  BaseOuterTorso

	{
	[Constructable]
	public Robe12()
            : this(0)

		{
	}

	[Constructable]
	public Robe12(int hue)
            : base(41716, hue)

		{
		Weight = 2.0;
		Name ="Robe12";
	}

	public Robe12(Serial serial)
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
public class Robe13 :  BaseOuterTorso

	{
	[Constructable]
	public Robe13()
            : this(0)

		{
	}

	[Constructable]
	public Robe13(int hue)
            : base(41717, hue)

		{
		Weight = 2.0;
		Name ="Robe13";
	}

	public Robe13(Serial serial)
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
public class Robe14 :  BaseOuterTorso

	{
	[Constructable]
	public Robe14()
            : this(0)

		{
	}

	[Constructable]
	public Robe14(int hue)
            : base(41718, hue)

		{
		Weight = 2.0;
		Name ="Robe14";
	}

	public Robe14(Serial serial)
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
public class Robe15 :  BaseOuterTorso

	{
	[Constructable]
	public Robe15()
            : this(0)

		{
	}

	[Constructable]
	public Robe15(int hue)
            : base(41719, hue)

		{
		Weight = 2.0;
		Name ="Robe15";
	}

	public Robe15(Serial serial)
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
public class Robe16 :  BaseOuterTorso

	{
	[Constructable]
	public Robe16()
            : this(0)

		{
	}

	[Constructable]
	public Robe16(int hue)
            : base(41720, hue)

		{
		Weight = 2.0;
		Name ="Robe16";
	}

	public Robe16(Serial serial)
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
public class RobeProvocante2 :  BaseOuterTorso

	{
	[Constructable]
	public RobeProvocante2()
            : this(0)

		{
	}

	[Constructable]
	public RobeProvocante2(int hue)
            : base(41721, hue)

		{
		Weight = 2.0;
		Name ="RobeProvocante2";
	}

	public RobeProvocante2(Serial serial)
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
public class RobeProvocante3 :  BaseOuterTorso

	{
	[Constructable]
	public RobeProvocante3()
            : this(0)

		{
	}

	[Constructable]
	public RobeProvocante3(int hue)
            : base(41722, hue)

		{
		Weight = 2.0;
		Name ="RobeProvocante3";
	}

	public RobeProvocante3(Serial serial)
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
public class RobeProvocante4 :  BaseOuterTorso

	{
	[Constructable]
	public RobeProvocante4()
            : this(0)

		{
	}

	[Constructable]
	public RobeProvocante4(int hue)
            : base(41723, hue)

		{
		Weight = 2.0;
		Name ="RobeProvocante4";
	}

	public RobeProvocante4(Serial serial)
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
public class RobeProvocante5 :  BaseOuterTorso

	{
	[Constructable]
	public RobeProvocante5()
            : this(0)

		{
	}

	[Constructable]
	public RobeProvocante5(int hue)
            : base(41724, hue)

		{
		Weight = 2.0;
		Name ="RobeProvocante5";
	}

	public RobeProvocante5(Serial serial)
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
public class RobeProvocante6 :  BaseOuterTorso

	{
	[Constructable]
	public RobeProvocante6()
            : this(0)

		{
	}

	[Constructable]
	public RobeProvocante6(int hue)
            : base(41725, hue)

		{
		Weight = 2.0;
		Name ="RobeProvocante6";
	}

	public RobeProvocante6(Serial serial)
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
public class Robe17 :  BaseOuterTorso

	{
	[Constructable]
	public Robe17()
            : this(0)

		{
	}

	[Constructable]
	public Robe17(int hue)
            : base(41726, hue)

		{
		Weight = 2.0;
		Name ="Robe17";
	}

	public Robe17(Serial serial)
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
public class Robe18 :  BaseOuterTorso

	{
	[Constructable]
	public Robe18()
            : this(0)

		{
	}

	[Constructable]
	public Robe18(int hue)
            : base(41727, hue)

		{
		Weight = 2.0;
		Name ="Robe18";
	}

	public Robe18(Serial serial)
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






