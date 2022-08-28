using Server.Engines.Craft;

namespace Server.Items
{

	public class Capuche :  BaseHat
    {
        [Constructable]
	public Capuche()
			: this(0)
	{
	}

	[Constructable]
	public Capuche(int hue)
		: base(41803, hue)
	{
		Weight = 2.0;
		Name ="Capuche";
	}

	public Capuche(Serial serial)
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

public class Capuche2 :  BaseHat

	{
	[Constructable]
	public Capuche2()
            : this(0)

		{
	}

	[Constructable]
	public Capuche2(int hue)
            : base(41804, hue)

		{
		Weight = 2.0;
		Name = "Grande Capuche";
	}

	public Capuche2(Serial serial)
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
public class TeteCoyote :  BaseHat

	{
	[Constructable]
	public TeteCoyote()
            : this(0)

		{
	}

	[Constructable]
	public TeteCoyote(int hue)
            : base(41805, hue)

		{
		Weight = 2.0;
		Name ="Tete de Coyote";
	}

	public TeteCoyote(Serial serial)
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
public class TeteTaureau :  BaseHat

	{
	[Constructable]
	public TeteTaureau()
            : this(0)

		{
	}

	[Constructable]
	public TeteTaureau(int hue)
            : base(41806, hue)

		{
		Weight = 2.0;
		Name ="Tete de Taureau";
	}

	public TeteTaureau(Serial serial)
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
public class Toque :  BaseHat

	{
	[Constructable]
	public Toque()
            : this(0)

		{
	}

	[Constructable]
	public Toque(int hue)
            : base(41807, hue)

		{
		Weight = 2.0;
		Name ="Toque";
	}

	public Toque(Serial serial)
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
public class Turban :  BaseHat

	{
	[Constructable]
	public Turban()
            : this(0)

		{
	}

	[Constructable]
	public Turban(int hue)
            : base(41808, hue)

		{
		Weight = 2.0;
		Name ="Turban";
	}

	public Turban(Serial serial)
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
public class VoileTete :  BaseHat

	{
	[Constructable]
	public VoileTete()
            : this(0)

		{
	}

	[Constructable]
	public VoileTete(int hue)
            : base(41809, hue)

		{
		Weight = 2.0;
		Name ="Voile";
	}

	public VoileTete(Serial serial)
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
public class VoileTeteLong :  BaseHat

	{
	[Constructable]
	public VoileTeteLong()
            : this(0)

		{
	}

	[Constructable]
	public VoileTeteLong(int hue)
            : base(41810, hue)

		{
		Weight = 2.0;
		Name ="Long Voile";
	}

	public VoileTeteLong(Serial serial)
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
	public class VoileDos : BaseHat

	{
		[Constructable]
		public VoileDos()
				: this(0)

		{
		}

		[Constructable]
		public VoileDos(int hue)
				: base(0xA3FB, hue)

		{
			Weight = 2.0;
			Name = "Voile de Dos";
		}

		public VoileDos(Serial serial)
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

	public class ChapeauPirate : BaseHat

	{
		[Constructable]
		public ChapeauPirate()
				: this(0)

		{
		}

		[Constructable]
		public ChapeauPirate(int hue)
				: base(41844, hue)

		{
			Weight = 2.0;
			Name = "Chapeau de Pirate";
		}

		public ChapeauPirate(Serial serial)
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
	public class ChapeauPiratePlume : BaseHat

	{
		[Constructable]
		public ChapeauPiratePlume()
				: this(0)

		{
		}

		[Constructable]
		public ChapeauPiratePlume(int hue)
				: base(0xA3EE, hue)

		{
			Weight = 2.0;
			Name = "Chapeau de Pirate à Plume";
		}

		public ChapeauPiratePlume(Serial serial)
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

	public class CapucheToile : BaseHat

	{
		[Constructable]
		public CapucheToile()
				: this(0)

		{
		}

		[Constructable]
		public CapucheToile(int hue)
				: base(0xA3BE, hue)

		{
			Weight = 2.0;
			Name = "Capuche de Toile";
		}

		public CapucheToile(Serial serial)
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

	public class ChapeauFoulard : BaseHat

	{
		[Constructable]
		public ChapeauFoulard()
				: this(0)

		{
		}

		[Constructable]
		public ChapeauFoulard(int hue)
				: base(0xA3BF, hue)

		{
			Weight = 2.0;
			Name = "Chapeau Foulard";
		}

		public ChapeauFoulard(Serial serial)
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
	public class ChapeauMousquetaire : BaseHat

	{
		[Constructable]
		public ChapeauMousquetaire()
				: this(0)

		{
		}

		[Constructable]
		public ChapeauMousquetaire(int hue)
				: base(0xA3C0, hue)

		{
			Weight = 2.0;
			Name = "Chapeau Mousquetaire";
		}

		public ChapeauMousquetaire(Serial serial)
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
	public class CoiffeSanglier : BaseHat

	{
		[Constructable]
		public CoiffeSanglier()
				: this(0)

		{
		}

		[Constructable]
		public CoiffeSanglier(int hue)
				: base(0xA3C1, hue)

		{
			Weight = 2.0;
			Name = "Coiffe Sanglier";
		}

		public CoiffeSanglier(Serial serial)
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
	public class CoiffeLion : BaseHat

	{
		[Constructable]
		public CoiffeLion()
				: this(0)

		{
		}

		[Constructable]
		public CoiffeLion(int hue)
				: base(0xA3C2, hue)

		{
			Weight = 2.0;
			Name = "Coiffe Lion";
		}

		public CoiffeLion(Serial serial)
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

	public class CoiffeLoupBlanc : BaseHat

	{
		[Constructable]
		public CoiffeLoupBlanc()
				: this(0)

		{
		}

		[Constructable]
		public CoiffeLoupBlanc(int hue)
				: base(0xA3C3, hue)

		{
			Weight = 2.0;
			Name = "Coiffe Loup Blanc";
		}

		public CoiffeLoupBlanc(Serial serial)
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

	public class CoiffeEgypte : BaseHat

	{
		[Constructable]
		public CoiffeEgypte()
				: this(0)

		{
		}

		[Constructable]
		public CoiffeEgypte(int hue)
				: base(0xA3C4, hue)

		{
			Weight = 2.0;
			Name = "Coiffe Egypte";
		}

		public CoiffeEgypte(Serial serial)
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
	public class CoiffeColore : BaseHat

	{
		[Constructable]
		public CoiffeColore()
				: this(0)

		{
		}

		[Constructable]
		public CoiffeColore(int hue)
				: base(0xA3C5, hue)

		{
			Weight = 2.0;
			Name = "Coiffe Coloree";
		}

		public CoiffeColore(Serial serial)
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

	public class ToqueBouffon : BaseHat

	{
		[Constructable]
		public ToqueBouffon()
				: this(0)

		{
		}

		[Constructable]
		public ToqueBouffon(int hue)
				: base(0xA3C6, hue)

		{
			Weight = 2.0;
			Name = "Toque Bouffon";
		}

		public ToqueBouffon(Serial serial)
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
	public class CoiffeGuepard : BaseHat

	{
		[Constructable]
		public CoiffeGuepard()
				: this(0)

		{
		}

		[Constructable]
		public CoiffeGuepard(int hue)
				: base(0xA3D4, hue)

		{
			Weight = 2.0;
			Name = "Coiffe Guepard";
		}

		public CoiffeGuepard(Serial serial)
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
	public class MasqueEpouvantail : BaseHat

	{
		[Constructable]
		public MasqueEpouvantail()
				: this(0)

		{
		}

		[Constructable]
		public MasqueEpouvantail(int hue)
				: base(0xA3D7, hue)

		{
			Weight = 2.0;
			Name = "Masque Epouvantail";
		}

		public MasqueEpouvantail(Serial serial)
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






