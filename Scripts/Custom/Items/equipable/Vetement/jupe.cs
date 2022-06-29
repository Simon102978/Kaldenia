using Server.Engines.Craft;

namespace Server.Items
{

	public class Jupe :  BaseOuterLegs
    {
        [Constructable]
	public Jupe()
			: this(0)
	{
	}

	[Constructable]
	public Jupe(int hue)
		: base(41666, hue)
	{
		Weight = 2.0;
		Name = "Jupe à Bande";
	}

	public Jupe(Serial serial)
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

public class Jupe2 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe2()
            : this(0)

		{
	}

	[Constructable]
	public Jupe2(int hue)
            : base(41667, hue)

		{
		Weight = 2.0;
		Name = "Jupe D??#$?&*licate";
	}

	public Jupe2(Serial serial)
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
public class Jupe3 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe3()
            : this(0)

		{
	}

	[Constructable]
	public Jupe3(int hue)
            : base(41668, hue)

		{
		Weight = 2.0;
		Name = "Jupe Droite";
	}

	public Jupe3(Serial serial)
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
public class Jupe4 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe4()
            : this(0)

		{
	}

	[Constructable]
	public Jupe4(int hue)
            : base(41669, hue)

		{
		Weight = 2.0;
		Name = "Jupe Artisane";
	}

	public Jupe4(Serial serial)
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
public class Jupe5 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe5()
            : this(0)

		{
	}

	[Constructable]
	public Jupe5(int hue)
            : base(41670, hue)

		{
		Weight = 2.0;
		Name = "Jupe à Motifs";
	}

	public Jupe5(Serial serial)
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
public class Jupe6 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe6()
            : this(0)

		{
	}

	[Constructable]
	public Jupe6(int hue)
            : base(41671, hue)

		{
		Weight = 2.0;
		Name = "Jupe à Plis";
	}

	public Jupe6(Serial serial)
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
public class JupeVoiles :  BaseOuterLegs

	{
	[Constructable]
	public JupeVoiles()
            : this(0)

		{
	}

	[Constructable]
	public JupeVoiles(int hue)
            : base(41672, hue)

		{
		Weight = 2.0;
		Name = "Jupe à Banquet";
	}

	public JupeVoiles(Serial serial)
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
public class JupeVoiles2 :  BaseOuterLegs

	{
	[Constructable]
	public JupeVoiles2()
            : this(0)

		{
	}

	[Constructable]
	public JupeVoiles2(int hue)
            : base(41673, hue)

		{
		Weight = 2.0;
		Name = "Jupe à Volant";
	}

	public JupeVoiles2(Serial serial)
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
public class JupeCourte :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte(int hue)
            : base(41674, hue)

		{
		Weight = 2.0;
		Name = "Jupe Courte Lac??#$?&*e";
	}

	public JupeCourte(Serial serial)
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
public class JupeCourte2 :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte2()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte2(int hue)
            : base(41675, hue)

		{
		Weight = 2.0;
		Name = "Jupe Quadrill??#$?&*e";
	}

	public JupeCourte2(Serial serial)
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
public class Jupe7 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe7()
            : this(0)

		{
	}

	[Constructable]
	public Jupe7(int hue)
            : base(41676, hue)

		{
		Weight = 2.0;
		Name = "Jupe Provocante";
	}

	public Jupe7(Serial serial)
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
public class JupeCourte3 :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte3()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte3(int hue)
            : base(41677, hue)

		{
		Weight = 2.0;
		Name = "Mini jupe à Ceinture";
	}

	public JupeCourte3(Serial serial)
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
public class JupeCourte4 :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte4()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte4(int hue)
            : base(41678, hue)

		{
		Weight = 2.0;
		Name = "Jupe Barbare";
	}

	public JupeCourte4(Serial serial)
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
public class JupeCourte5 :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte5()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte5(int hue)
            : base(41679, hue)

		{
		Weight = 2.0;
		Name = "Jupe courte à Vollant";
	}

	public JupeCourte5(Serial serial)
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
public class JupeCourte6 :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte6()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte6(int hue)
            : base(41680, hue)

		{
		Weight = 2.0;
		Name = "Jupe courte à Vollant Unie";
	}

	public JupeCourte6(Serial serial)
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
public class JupeCourte7 :  BaseOuterLegs

	{
	[Constructable]
	public JupeCourte7()
            : this(0)

		{
	}

	[Constructable]
	public JupeCourte7(int hue)
            : base(41681, hue)

		{
		Weight = 2.0;
		Name = "Jupe Courte Droite";
	}

	public JupeCourte7(Serial serial)
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
public class JupeLacee :  BaseOuterLegs

	{
	[Constructable]
	public JupeLacee()
            : this(0)

		{
	}

	[Constructable]
	public JupeLacee(int hue)
            : base(41682, hue)

		{
		Weight = 2.0;
		Name ="Jupe Lac??#$?&*e";
	}

	public JupeLacee(Serial serial)
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
public class JupeLacee2 :  BaseOuterLegs

	{
	[Constructable]
	public JupeLacee2()
            : this(0)

		{
	}

	[Constructable]
	public JupeLacee2(int hue)
            : base(41683, hue)

		{
		Weight = 2.0;
		Name = "Jupe Lac??#$?&*e Sombre";
	}

	public JupeLacee2(Serial serial)
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
public class JupeLacee3 :  BaseOuterLegs

	{
	[Constructable]
	public JupeLacee3()
            : this(0)

		{
	}

	[Constructable]
	public JupeLacee3(int hue)
            : base(41684, hue)

		{
		Weight = 2.0;
		Name = "Jupe Lac??#$?&*e Droite";
	}

	public JupeLacee3(Serial serial)
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
public class Kilt3 :  BaseOuterLegs

	{
	[Constructable]
	public Kilt3()
            : this(0)

		{
	}

	[Constructable]
	public Kilt3(int hue)
            : base(41685, hue)

		{
		Weight = 2.0;
		Name = "Grand Kilt";
	}

	public Kilt3(Serial serial)
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
public class Kilt2 :  BaseOuterLegs

	{
	[Constructable]
	public Kilt2()
            : this(0)

		{
	}

	[Constructable]
	public Kilt2(int hue)
            : base(41686, hue)

		{
		Weight = 2.0;
		Name = "Kilt à Bandouillère";
	}

	public Kilt2(Serial serial)
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
public class Pareo :  BaseOuterLegs

	{
	[Constructable]
	public Pareo()
            : this(0)

		{
	}

	[Constructable]
	public Pareo(int hue)
            : base(41687, hue)

		{
		Weight = 2.0;
		Name = "Jupe Ouverte";
	}

	public Pareo(Serial serial)
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
public class PareoCourt :  BaseOuterLegs

	{
	[Constructable]
	public PareoCourt()
            : this(0)

		{
	}

	[Constructable]
	public PareoCourt(int hue)
            : base(41688, hue)

		{
		Weight = 2.0;
		Name ="Par??#$?&*o";
	}

	public PareoCourt(Serial serial)
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
public class Jupe11 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe11()
            : this(0)

		{
	}

	[Constructable]
	public Jupe11(int hue)
            : base(41701, hue)

		{
		Weight = 2.0;
		Name = "Jupe Sombre";
	}

	public Jupe11(Serial serial)
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
public class Jupe8 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe8()
            : this(0)

		{
	}

	[Constructable]
	public Jupe8(int hue)
            : base(41706, hue)

		{
		Weight = 2.0;
		Name = "Jupe Provocante à Volants";
	}

	public Jupe8(Serial serial)
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
public class Jupe9 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe9()
            : this(0)

		{
	}

	[Constructable]
	public Jupe9(int hue)
            : base(41707, hue)

		{
		Weight = 2.0;
		Name = "Jupe à Saccoche";
	}

	public Jupe9(Serial serial)
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
public class Jupe10 :  BaseOuterLegs

	{
	[Constructable]
	public Jupe10()
            : this(0)

		{
	}

	[Constructable]
	public Jupe10(int hue)
            : base(41708, hue)

		{
		Weight = 2.0;
		Name = "Jupe à Jartelles";
	}

	public Jupe10(Serial serial)
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






