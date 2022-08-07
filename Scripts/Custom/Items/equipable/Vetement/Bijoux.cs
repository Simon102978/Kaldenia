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
		Name = "Collier massif doré";
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
		Name = "Collier croix Ânkh";
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
		Name = "Petite couronne";
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
		Name = "Collier bolo doré";
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
		Name = "Diadème";
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
		Name = "Grande chaîne dorée";
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
		Name = "Collier croix Ânkh doré";
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
		Name = "Petit collier Usekh";
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
		Name = "Petit collier doré";
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
		Name = "Lunette dorée";
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
		Name = "Grande couronne";
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
		Name = "Collier de feuilles dorées";
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
public class Ceinture10 :  BaseWaist

	{

	[Constructable]
	public Ceinture10()
            : base(41855)

		{
		Weight = 2.0;
		Name = "Ceinture de feuilles dorées";
			Layer = Layer.Waist;
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
		Name = "Collier de perle";
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
		Name = "Collier simple";
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
		Name = "Collier simple avec pendentif";
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
		Name = "Grand collier doré avec pendentif";
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
	public class DiademeFeuilleOr : BaseNecklace

	{


		[Constructable]
		public DiademeFeuilleOr()
				: base(41860)

		{
			Weight = 2.0;
			Name = "Collier doré avec pendentif";
		}

		public DiademeFeuilleOr(Serial serial)
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
	public class EpauletteDoree : BaseNecklace

	{


		[Constructable]
		public EpauletteDoree()
				: base(0xA3D8)

		{
			Weight = 2.0;
			Name = "Grand collier Usekh";
		}

		public EpauletteDoree(Serial serial)
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
	public class MenotteDoree : BaseBracelet

	{


		[Constructable]
		public MenotteDoree()
				: base(0xA3F5)

		{
			Weight = 2.0;
			Name = "Menottes Dorées";
		}

		public MenotteDoree(Serial serial)
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
	public class Lunettes1 : BaseNecklace

	{


		[Constructable]
		public Lunettes1()
				: base(0x2FB8)

		{
			Weight = 1.0;
			Name = "Lunettes";
		}

		public Lunettes1(Serial serial)
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
	public class Lunettes2 : BaseNecklace

	{


		[Constructable]
		public Lunettes2()
				: base(0x45B1)

		{
			Weight = 1.0;
			Name = "Lunettes";
		}

		public Lunettes2(Serial serial)
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
	public class Lunettes3 : BaseNecklace

	{


		[Constructable]
		public Lunettes3()
				: base(0x4644)

		{
			Weight = 1.0;
			Name = "Lunettes";
		}

		public Lunettes3(Serial serial)
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






