using Server.Engines.Craft;

namespace Server.Items
{

	public abstract class BaseCouronne : BaseJewel
	{
		public BaseCouronne(int itemID)
			: base(itemID, Layer.Helm)
		{
		}

		public BaseCouronne(Serial serial)
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

	public class Collier :  BaseNecklace
    {

	[Constructable]
	public Collier()
		: base(41842)
	{
		Weight = 2.0;
		Name ="Collier";
	}

	public Collier(Serial serial)
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

public class Collier2 :  BaseNecklace

	{

	[Constructable]
	public Collier2()
            : base(41843)

		{
		Weight = 2.0;
		Name ="Collier2";
	}

	public Collier2(Serial serial)
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
public class Couronne2 :  BaseCouronne

	{


	[Constructable]
	public Couronne2()
            : base(41845)

		{
		Weight = 2.0;
		Name ="Couronne2";
	}

	public Couronne2(Serial serial)
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
public class Collier3 :  BaseNecklace

	{

	[Constructable]
	public Collier3()
            : base(41846)

		{
		Weight = 2.0;
		Name ="Collier3";
	}

	public Collier3(Serial serial)
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
public class Couronne3 :  BaseCouronne

	{


	[Constructable]
	public Couronne3()
            : base(41847)

		{
		Weight = 2.0;
		Name ="Couronne3";
	}

	public Couronne3(Serial serial)
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
public class Collier4 :  BaseNecklace

	{

	[Constructable]
	public Collier4()
            : base(41848)

		{
		Weight = 2.0;
		Name ="Collier4";
	}

	public Collier4(Serial serial)
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
public class Collier5 :  BaseNecklace

	{

	[Constructable]
	public Collier5()
            : base(41849)

		{
		Weight = 2.0;
		Name ="Collier5";
	}

	public Collier5(Serial serial)
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
public class Collier6 :  BaseNecklace

	{

	[Constructable]
	public Collier6()
            : base(41850)

		{
		Weight = 2.0;
		Name ="Collier6";
	}

	public Collier6(Serial serial)
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
public class Collier7 :  BaseNecklace

	{

	[Constructable]
	public Collier7()
            : base(41851)

		{
		Weight = 2.0;
		Name ="Collier7";
	}

	public Collier7(Serial serial)
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
public class Lunettes :  BaseNecklace

	{

	[Constructable]
	public Lunettes()
            : base(41852)

		{
		Weight = 2.0;
		Name ="Lunettes";
	}

	public Lunettes(Serial serial)
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
public class Couronne4 :  BaseCouronne

	{

	[Constructable]
	public Couronne4()
            : base(41853)

		{
		Weight = 2.0;
		Name ="Couronne4";
	}

	public Couronne4(Serial serial)
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
public class Collier8 :  BaseNecklace

	{

	[Constructable]
	public Collier8()
            : base(41854)

		{
		Weight = 2.0;
		Name ="Collier8";
	}

	public Collier8(Serial serial)
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
public class Ceinture10 :  BaseCouronne

	{

	[Constructable]
	public Ceinture10()
            : base(41855)

		{
		Weight = 2.0;
		Name ="Ceinture10";
	}

	public Ceinture10(Serial serial)
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
public class Tiare :  BaseCouronne
	{


	[Constructable]
	public Tiare()
            : base(41856)

		{
		Weight = 2.0;
		Name ="Tiare";
	}

	public Tiare(Serial serial)
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
public class Collier9 :  BaseNecklace

	{

	[Constructable]
	public Collier9()
            : base(41857)

		{
		Weight = 2.0;
		Name ="Collier9";
	}

	public Collier9(Serial serial)
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
public class Collier10 :  BaseNecklace

	{


	[Constructable]
	public Collier10()
            : base(41858)

		{
		Weight = 2.0;
		Name ="Collier10";
	}

	public Collier10(Serial serial)
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
public class Collier11 :  BaseNecklace

	{


	[Constructable]
	public Collier11()
            : base(41859)

		{
		Weight = 2.0;
		Name ="Collier11";
	}

	public Collier11(Serial serial)
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
public class Collier12 :  BaseNecklace

	{


	[Constructable]
	public Collier12()
            : base(41860)

		{
		Weight = 2.0;
		Name ="Collier12";
	}

	public Collier12(Serial serial)
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






