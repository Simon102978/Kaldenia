using Server.Engines.Craft;

namespace Server.Items
{

	 public class Chandail :  BaseMiddleTorso
    {
        [Constructable]
	public Chandail()
			: this(0)
	{
	}

	[Constructable]
	public Chandail(int hue)
		: base(41689, hue)
	{
		Weight = 2.0;
		Name = "Chandail distingu??#$?&*";
	}

	public Chandail(Serial serial)
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
 
 public class Camisole :  BaseMiddleTorso

	{
	[Constructable]
	public Camisole()
            : this(0)

		{
	}

	[Constructable]
	public Camisole(int hue)
            : base(41690, hue)

		{
		Weight = 2.0;
		Name = "Chandail de travail";
	}

	public Camisole(Serial serial)
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
 public class Chandail2 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail2()
            : this(0)

		{
	}

	[Constructable]
	public Chandail2(int hue)
            : base(41691, hue)

		{
		Weight = 2.0;
		Name = "Tunique orn??#$?&*e";
	}

	public Chandail2(Serial serial)
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
 public class Tunique :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique()
            : this(0)

		{
	}

	[Constructable]
	public Tunique(int hue)
            : base(41692, hue)

		{
		Weight = 2.0;
		Name = "Tunique en peaux";
	}

	public Tunique(Serial serial)
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
 public class Chemise :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise()
            : this(0)

		{
	}

	[Constructable]
	public Chemise(int hue)
            : base(41693, hue)

		{
		Weight = 2.0;
		Name = "Chemise propre";
	}

	public Chemise(Serial serial)
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
 public class Tunique2 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique2()
            : this(0)

		{
	}

	[Constructable]
	public Tunique2(int hue)
            : base(41695, hue)

		{
		Weight = 2.0;
		Name = "Tunique bouffante";
	}

	public Tunique2(Serial serial)
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
 public class Uniforme :  BaseMiddleTorso

	{
	[Constructable]
	public Uniforme()
            : this(0)

		{
	}

	[Constructable]
	public Uniforme(int hue)
            : base(41696, hue)

		{
		Weight = 2.0;
		Name = "Manteau d'uniforme";
	}

	public Uniforme(Serial serial)
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
 public class Bustier :  BaseShirt

	{
	[Constructable]
	public Bustier()
            : this(0)

		{
	}

	[Constructable]
	public Bustier(int hue)
            : base(41703, hue)

		{
		Weight = 2.0;
		Name = "Bustier ail??#$?&*";
	}

	public Bustier(Serial serial)
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
 public class Bustier2 :  BaseShirt

	{
	[Constructable]
	public Bustier2()
            : this(0)

		{
	}

	[Constructable]
	public Bustier2(int hue)
            : base(41704, hue)

		{
		Weight = 2.0;
		Name = "Bustier provocant";
	}

	public Bustier2(Serial serial)
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
 public class Bustier3 :  BaseShirt

	{
	[Constructable]
	public Bustier3()
            : this(0)

		{
	}

	[Constructable]
	public Bustier3(int hue)
            : base(41705, hue)

		{
		Weight = 2.0;
		Name = "Bustier demi-manche";
	}

	public Bustier3(Serial serial)
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
 public class Chandail3 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail3()
            : this(0)

		{
	}

	[Constructable]
	public Chandail3(int hue)
            : base(41748, hue)

		{
		Weight = 2.0;
		Name = "Corset Bouffant";
	}

	public Chandail3(Serial serial)
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
 public class Chandail4 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail4()
            : this(0)

		{
	}

	[Constructable]
	public Chandail4(int hue)
            : base(41749, hue)

		{
		Weight = 2.0;
		Name = "Chandail ample";
	}

	public Chandail4(Serial serial)
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
 public class Chandail5 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail5()
            : this(0)

		{
	}

	[Constructable]
	public Chandail5(int hue)
            : base(41750, hue)

		{
		Weight = 2.0;
		Name = "Chandail propre";
	}

	public Chandail5(Serial serial)
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
 public class Chandail6 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail6()
            : this(0)

		{
	}

	[Constructable]
	public Chandail6(int hue)
            : base(41751, hue)

		{
		Weight = 2.0;
		Name = "Doublet demi-manche";
	}

	public Chandail6(Serial serial)
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
 public class Chandail7 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail7()
            : this(0)

		{
	}

	[Constructable]
	public Chandail7(int hue)
            : base(41752, hue)

		{
		Weight = 2.0;
		Name = "Grand chandail";
	}

	public Chandail7(Serial serial)
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
 public class Chandail8 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail8()
            : this(0)

		{
	}

	[Constructable]
	public Chandail8(int hue)
            : base(41753, hue)

		{
		Weight = 2.0;
		Name = "Chandail Manche Longue";
	}

	public Chandail8(Serial serial)
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
 public class Chandail9 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail9()
            : this(0)

		{
	}

	[Constructable]
	public Chandail9(int hue)
            : base(41754, hue)

		{
		Weight = 2.0;
		Name = "Chandail bouffant";
	}

	public Chandail9(Serial serial)
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
 public class Chandail10 :  BaseMiddleTorso

	{
	[Constructable]
	public Chandail10()
            : this(0)

		{
	}

	[Constructable]
	public Chandail10(int hue)
            : base(41755, hue)

		{
		Weight = 2.0;
		Name = "Chandail manche ample";
	}

	public Chandail10(Serial serial)
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
 public class Chemise2 :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise2()
            : this(0)

		{
	}

	[Constructable]
	public Chemise2(int hue)
            : base(41756, hue)

		{
		Weight = 2.0;
		Name = "Chemise noble";
	}

	public Chemise2(Serial serial)
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
 public class Chemise3 :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise3()
            : this(0)

		{
	}

	[Constructable]
	public Chemise3(int hue)
            : base(41757, hue)

		{
		Weight = 2.0;
		Name = "Chemise longue lac??#$?&*e";
	}

	public Chemise3(Serial serial)
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
 public class Chemise4 :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise4()
            : this(0)

		{
	}

	[Constructable]
	public Chemise4(int hue)
            : base(41758, hue)

		{
		Weight = 2.0;
		Name = "Chemise simple";
	}

	public Chemise4(Serial serial)
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
 public class Chemise5 :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise5()
            : this(0)

		{
	}

	[Constructable]
	public Chemise5(int hue)
            : base(41759, hue)

		{
		Weight = 2.0;
		Name = "Cehmise ajust??#$?&*e";
	}

	public Chemise5(Serial serial)
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
 public class Chemise6 :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise6()
            : this(0)

		{
	}

	[Constructable]
	public Chemise6(int hue)
            : base(41760, hue)

		{
		Weight = 2.0;
		Name = "Chemise lac??#$?&*e";
	}

	public Chemise6(Serial serial)
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
 public class Chemise7 :  BaseMiddleTorso

	{
	[Constructable]
	public Chemise7()
            : this(0)

		{
	}

	[Constructable]
	public Chemise7(int hue)
            : base(41761, hue)

		{
		Weight = 2.0;
		Name = "Manteau ??#$?&*l??#$?&*gant";
	}

	public Chemise7(Serial serial)
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
 public class Doublet7 :  BaseMiddleTorso

	{
	[Constructable]
	public Doublet7()
            : this(0)

		{
	}

	[Constructable]
	public Doublet7(int hue)
            : base(41762, hue)

		{
		Weight = 2.0;
		Name ="Doublet7";
	}

	public Doublet7(Serial serial)
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
 public class Doublet2 :  BaseMiddleTorso

	{
	[Constructable]
	public Doublet2()
            : this(0)

		{
	}

	[Constructable]
	public Doublet2(int hue)
            : base(41763, hue)

		{
		Weight = 2.0;
		Name = "Doublet à ??#$?&*paulette";
	}

	public Doublet2(Serial serial)
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
 public class Doublet3 :  BaseMiddleTorso

	{
	[Constructable]
	public Doublet3()
            : this(0)

		{
	}

	[Constructable]
	public Doublet3(int hue)
            : base(41764, hue)

		{
		Weight = 2.0;
		Name = "Doublet lac??#$?&*";
	}

	public Doublet3(Serial serial)
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
 public class Doublet4 :  BaseMiddleTorso

	{
	[Constructable]
	public Doublet4()
            : this(0)

		{
	}

	[Constructable]
	public Doublet4(int hue)
            : base(41765, hue)

		{
		Weight = 2.0;
		Name = "Doublet lac??#$?&* crois??#$?&*";
	}

	public Doublet4(Serial serial)
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
 public class Doublet5 :  BaseMiddleTorso

	{
	[Constructable]
	public Doublet5()
            : this(0)

		{
	}

	[Constructable]
	public Doublet5(int hue)
            : base(41766, hue)

		{
		Weight = 2.0;
		Name = "Doublet ajust??#$?&*";
	}

	public Doublet5(Serial serial)
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
 public class Doublet6 :  BaseMiddleTorso

	{
	[Constructable]
	public Doublet6()
            : this(0)

		{
	}

	[Constructable]
	public Doublet6(int hue)
            : base(41767, hue)

		{
		Weight = 2.0;
		Name = "Doublet à bouton";
	}

	public Doublet6(Serial serial)
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
 public class Tunique3 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique3()
            : this(0)

		{
	}

	[Constructable]
	public Tunique3(int hue)
            : base(41768, hue)

		{
		Weight = 2.0;
		Name = "Tunique à plis";
	}

	public Tunique3(Serial serial)
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
 public class Tunique4 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique4()
            : this(0)

		{
	}

	[Constructable]
	public Tunique4(int hue)
            : base(41769, hue)

		{
		Weight = 2.0;
		Name = "Tunique à cordon";
	}

	public Tunique4(Serial serial)
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
 public class Tunique5 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique5()
            : this(0)

		{
	}

	[Constructable]
	public Tunique5(int hue)
            : base(41770, hue)

		{
		Weight = 2.0;
		Name = "Tunique sans manche";
	}

	public Tunique5(Serial serial)
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
 public class Tunique6 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique6()
            : this(0)

		{
	}

	[Constructable]
	public Tunique6(int hue)
            : base(41771, hue)

		{
		Weight = 2.0;
		Name = "Tunique à voilant";
	}

	public Tunique6(Serial serial)
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
 public class Tunique7 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique7()
            : this(0)

		{
	}

	[Constructable]
	public Tunique7(int hue)
            : base(41772, hue)

		{
		Weight = 2.0;
		Name = "Tunique propre";
	}

	public Tunique7(Serial serial)
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
 public class Tunique8 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique8()
            : this(0)

		{
	}

	[Constructable]
	public Tunique8(int hue)
            : base(41773, hue)

		{
		Weight = 2.0;
		Name = "Tunique ??#$?&*l??#$?&*gante";
	}

	public Tunique8(Serial serial)
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
 public class Tunique9 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique9()
            : this(0)

		{
	}

	[Constructable]
	public Tunique9(int hue)
            : base(41774, hue)

		{
		Weight = 2.0;
		Name = "Tunique sombre";
	}

	public Tunique9(Serial serial)
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
 public class Tunique10 :  BaseMiddleTorso

	{
	[Constructable]
	public Tunique10()
            : this(0)

		{
	}

	[Constructable]
	public Tunique10(int hue)
            : base(41775, hue)

		{
		Weight = 2.0;
		Name = "Tunique à ceinture";
	}

	public Tunique10(Serial serial)
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
 public class Manteau :  BaseMiddleTorso

	{
	[Constructable]
	public Manteau()
            : this(0)

		{
	}

	[Constructable]
	public Manteau(int hue)
            : base(41789, hue)

		{
		Weight = 2.0;
		Name = "Manteau orn??#$?&*";
	}

	public Manteau(Serial serial)
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
 public class Manteau2 :  BaseMiddleTorso

	{
	[Constructable]
	public Manteau2()
            : this(0)

		{
	}

	[Constructable]
	public Manteau2(int hue)
            : base(41790, hue)

		{
		Weight = 2.0;
		Name = "Manteau ample";
	}

	public Manteau2(Serial serial)
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
 public class Veste :  BaseMiddleTorso

	{
	[Constructable]
	public Veste()
            : this(0)

		{
	}

	[Constructable]
	public Veste(int hue)
            : base(41791, hue)

		{
		Weight = 2.0;
		Name ="Veste";
	}

	public Veste(Serial serial)
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
 public class Veste2 :  BaseMiddleTorso

	{
	[Constructable]
	public Veste2()
            : this(0)

		{
	}

	[Constructable]
	public Veste2(int hue)
            : base(41792, hue)

		{
		Weight = 2.0;
		Name = "Veste manche courte";
	}

	public Veste2(Serial serial)
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
 public class Veste3 :  BaseMiddleTorso

	{
	[Constructable]
	public Veste3()
            : this(0)

		{
	}

	[Constructable]
	public Veste3(int hue)
            : base(41793, hue)

		{
		Weight = 2.0;
		Name = "Manteau Propre";
	}

	public Veste3(Serial serial)
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






