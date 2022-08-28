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
		Name = "Robe provocante";
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
		Name = "Robe sans manche";
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
		Name = "Robe manches courtes";
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
		Name = "Robe ornée";
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

	public class RobeMoulante : BaseOuterTorso

	{
		[Constructable]
		public RobeMoulante()
				: this(0)

		{
		}

		[Constructable]
		public RobeMoulante(int hue)
				: base(41700, hue)

		{
			Weight = 2.0;
			Name = "Robe Moulante";
		}

		public RobeMoulante(Serial serial)
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
		Name ="Robe Sombre";
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
		Name = "Robe artisane";
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
		Name = "Robe à volants";
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
		Name = "Robe Simple";
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
		Name = "Robe lacéé large";
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
		Name = "Robe d'érudit";
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
		Name = "Robe manches amples";
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
		Name = "Robe Délicate sombre";
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
		Name = "Robe délicate";
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
		Name = "Robe Ouverte";
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
		Name = "Robe Provocante délicate";
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
		Name = "Robe légère";
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
		Name = "Robe provocante Sombre";
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
		Name = "Robe Provocante ornée";
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
		Name = "Robe dorée sombre";
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
		Name = "Robe décoltée";
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
		Name = "Robe provocante légère";
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
		Name = "Robe dorée";
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
		Name = "Robe Ceinture dorée";
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
		Name = "Robe à Col";
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

	public class RobeCourteLacet : BaseOuterTorso

	{
		[Constructable]
		public RobeCourteLacet()
				: this(0)

		{
		}

		[Constructable]
		public RobeCourteLacet(int hue)
				: base(0xA3CB, hue)

		{
			Weight = 2.0;
			Name = "Robe Courte Lacet";
		}

		public RobeCourteLacet(Serial serial)
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

	public class RobeBleudecolte : BaseOuterTorso

	{
		[Constructable]
		public RobeBleudecolte()
				: this(0)

		{
		}

		[Constructable]
		public RobeBleudecolte(int hue)
				: base(0xA3CC, hue)

		{
			Weight = 2.0;
			Name = "Robe Bleue decoltee";
		}

		public RobeBleudecolte(Serial serial)
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
	public class RobeLacetCuir : BaseOuterTorso

	{
		[Constructable]
		public RobeLacetCuir()
				: this(0)

		{
		}

		[Constructable]
		public RobeLacetCuir(int hue)
				: base(0xA3CD, hue)

		{
			Weight = 2.0;
			Name = "Robe Lacet Cuir";
		}

		public RobeLacetCuir(Serial serial)
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
	public class RobeDessin : BaseOuterTorso

	{
		[Constructable]
		public RobeDessin()
				: this(0)

		{
		}

		[Constructable]
		public RobeDessin(int hue)
				: base(0xA3CE, hue)

		{
			Weight = 2.0;
			Name = "Robe Dessin";
		}

		public RobeDessin(Serial serial)
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

	public class RobeCorset : BaseOuterTorso

	{
		[Constructable]
		public RobeCorset()
				: this(0)

		{
		}

		[Constructable]
		public RobeCorset(int hue)
				: base(0xA3CF, hue)

		{
			Weight = 2.0;
			Name = "Robe Corset";
		}

		public RobeCorset(Serial serial)
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

	public class RobeNobleDecolte : BaseOuterTorso

	{
		[Constructable]
		public RobeNobleDecolte()
				: this(0)

		{
		}

		[Constructable]
		public RobeNobleDecolte(int hue)
				: base(0xA3D0, hue)

		{
			Weight = 2.0;
			Name = "Robe Noble Decoltee";
		}

		public RobeNobleDecolte(Serial serial)
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

	public class RobeDoree : BaseOuterTorso

	{
		[Constructable]
		public RobeDoree()
				: this(0)

		{
		}

		[Constructable]
		public RobeDoree(int hue)
				: base(0xA3D6, hue)

		{
			Weight = 2.0;
			Name = "Robe Doree";
		}

		public RobeDoree(Serial serial)
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

	public class RobeBal1 : BaseOuterTorso

	{
		[Constructable]
		public RobeBal1()
				: this(0)

		{
		}

		[Constructable]
		public RobeBal1(int hue)
				: base(0xA402, hue)

		{
			Weight = 2.0;
			Name = "Robe de Bal Style 1";
		}

		public RobeBal1(Serial serial)
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

	public class RobeBal2 : BaseOuterTorso

	{
		[Constructable]
		public RobeBal2()
				: this(0)

		{
		}

		[Constructable]
		public RobeBal2(int hue)
				: base(0xA404, hue)

		{
			Weight = 2.0;
			Name = "Robe de Bal style 2 ";
		}

		public RobeBal2(Serial serial)
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

	public class RobeBal3 : BaseOuterTorso

	{
		[Constructable]
		public RobeBal3()
				: this(0)

		{
		}

		[Constructable]
		public RobeBal3(int hue)
				: base(0xA405, hue)

		{
			Weight = 2.0;
			Name = "Robe de Bal style 3 ";
		}

		public RobeBal3(Serial serial)
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






