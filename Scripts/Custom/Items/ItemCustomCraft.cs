using System;

namespace Server.Items
{
	[Furniture]
[Flipable(0x994D, 0x994E)]
public class MachineCoudre : CraftableFurniture
{
	[Constructable]
	public MachineCoudre()
		: base(0x994D)
	{
		Weight = 15.0;
		Name = "Machine à Coudre";
	}

	public MachineCoudre(Serial serial)
		: base(serial)
	{
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}

[Furniture]
[Flipable(0x994F, 0x994F)]
public class BancMachineCoudre : CraftableFurniture
{
	[Constructable]
	public BancMachineCoudre()
		: base(0x994F)
	{
		Weight = 5.0;
		Name = "Banc Machine à Coudre";
	}

	public BancMachineCoudre(Serial serial)
		: base(serial)
	{
	}
		public override int LabelNumber => 1015082;  // Wooden Throne
		public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}

[Furniture]
[Flipable(0x995F, 0x9960)]
public class TinkerTable : CraftableFurniture
{
	[Constructable]
	public TinkerTable()
		: base(0x995F)
	{
		Weight = 5.0;
		Name = "Bureau de travail";
	}

	public TinkerTable(Serial serial)
		: base(serial)
	{
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}
	public class Tableronde1 : CraftableFurniture
	{
		[Constructable]
		public Tableronde1()
			: base(0x99C8)
		{
			Weight = 5.0;
			Name = "Table Ronde";
		}

		public Tableronde1(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	public class TableRonde2 : CraftableFurniture
	{
		[Constructable]
		public TableRonde2()
			: base(0x99C9)
		{
			Weight = 5.0;
			Name = "Table Ronde";
		}

		public TableRonde2(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	public class TableRonde3 : CraftableFurniture
	{
		[Constructable]
		public TableRonde3()
			: base(0x99CA)
		{
			Weight = 5.0;
			Name = "Table Ronde";
		}

		public TableRonde3(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Flipable(0x99CC, 0x99CD)]
	public class TableGrise : CraftableFurniture
	{
		[Constructable]
		public TableGrise()
			: base(0x99CC)
		{
			Weight = 5.0;
			Name = "Table Grise";
		}

		public TableGrise(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
[Flipable(0x9961, 0x9962)]
public class RepairTable : CraftableFurniture
{
	[Constructable]
	public RepairTable()
		: base(0x9961)
	{
		Weight = 5.0;
		Name = "Bureau de travail";
	}

	public RepairTable(Serial serial)
		: base(serial)
	{
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}
[Furniture]
	[Flipable(0x9963, 0x9964)]
	public class FeedingThrough : CraftableFurniture
	{
		[Constructable]
		public FeedingThrough()
			: base(0x9963)
		{
			Weight = 5.0;
			Name = "Mangeoir";
		}

		public FeedingThrough(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
}
[Furniture]
[Flipable(0x9967, 0x9968)]
public class Puit : CraftableFurniture, IWaterSource
	{
	[Constructable]
	public Puit()
		: base(0x9967)
	{
		Weight = 100.0;
		Name = "Un Puit";
	}

	public Puit(Serial serial)
		: base(serial)
	{
	}
		public int Quantity
		{
			get
			{
				return 500;
			}
			set
			{
			}
		}
		public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}
	[Flipable(0x0A3C, 0x0A3D, 0x0A44, 0x0A45)]
	public class NormDresser : CraftableFurniture
	{
		[Constructable]
		public NormDresser()
			: base(0x0A3C)
		{
			Weight = 15.0;
			Name = "Coiffeuse";
		}

		public NormDresser(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Flipable(0x99C6, 0x99C7)]
	public class CommodeFoncee : CraftableFurniture
	{
		[Constructable]
		public CommodeFoncee()
			: base(0x99C6)
		{
			Weight = 15.0;
			Name = "Commode Foncee";
		}

		public CommodeFoncee(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Flipable(0x99CE, 0x99CF)]
	public class CommodeHaute : CraftableFurniture
	{
		[Constructable]
		public CommodeHaute()
			: base(0x99CE)
		{
			Weight = 15.0;
			Name = "Commode Haute";
		}

		public CommodeHaute(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Flipable(0x99D0, 0x99D2)]
	public class GardeRobeFermer  : CraftableFurniture
	{
		[Constructable]
		public GardeRobeFermer()
			: base(0x99D0)
		{
			Weight = 15.0;
			Name = "Garde Robe Fermé";
		}

		public GardeRobeFermer(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Flipable(0x99D1, 0x99D3)]
	public class GardeRobeOuvert : CraftableFurniture
	{
		[Constructable]
		public GardeRobeOuvert()
			: base(0x99D1)
		{
			Weight = 15.0;
			Name = "Garde Robe Ouvert";
		}

		public GardeRobeOuvert(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
[Flipable(0x996D, 0x996D)]
public class Ancre : CraftableFurniture
{
	[Constructable]
	public Ancre()
		: base(0x996D)
	{
		Weight = 25.0;
		Name = "Une Ancre";
	}

	public Ancre(Serial serial)
		: base(serial)
	{
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}
	[Furniture]
	[Flipable(0x99B5, 0x99B6, 0x99B7, 0x99B8)]
	public class ChaiseLuxe : CraftableFurniture
	{
		[Constructable]
		public ChaiseLuxe()
			: base(0x99B5)
		{
			Weight = 25.0;
			Name = "Chaise de Luxe";
		}

		public ChaiseLuxe(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
	[Flipable(0x99B9, 0x99BA)]
	public class BancGris : CraftableFurniture
	{
		[Constructable]
		public BancGris()
			: base(0x99B9)
		{
			Weight = 25.0;
			Name = "Banc Gris";
		}

		public BancGris(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
	[Flipable(0x99BB, 0x99BC)]
	public class BancFer : CraftableFurniture
	{
		[Constructable]
		public BancFer()
			: base(0x99BB)
		{
			Weight = 25.0;
			Name = "Banc Fer";
		}

		public BancFer(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
	[Flipable(0x99BD, 0x99BE, 0x99BF, 0x99C0)]
	public class ChaiseRembourer : CraftableFurniture
	{
		[Constructable]
		public ChaiseRembourer()
			: base(0x99BD)
		{
			Weight = 25.0;
			Name = "Chaise Rembourée";
		}

		public ChaiseRembourer(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
	[Flipable(0x99C1, 0x99C2, 0x99C3, 0x99C4)]
	public class ChaiseVerte : CraftableFurniture
	{
		[Constructable]
		public ChaiseVerte()
			: base(0x99C1)
		{
			Weight = 25.0;
			Name = "Chaise Verte";
		}

		public ChaiseVerte(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
[Flipable(0x996E, 0x996F)]
public class RackaVin : CraftableFurniture
{
	[Constructable]
	public RackaVin()
		: base(0x996E)
	{
		Weight = 25.0;
		Name = "Cellier";
	}

	public RackaVin(Serial serial)
		: base(serial)
	{
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();

	}
}
	[Furniture]
	[Flipable(0x9998, 0x9999)]
	public class PresentoireVide : CraftableFurniture
	{
		[Constructable]
		public PresentoireVide()
			: base(0x9998)
		{
			Weight = 25.0;
			Name = "Presentoir Vide";
		}

		public PresentoireVide(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
	[Flipable(0x999A, 0x999B)]
	public class PresentoirePlein1 : CraftableFurniture
	{
		[Constructable]
		public PresentoirePlein1()
			: base(0x999A)
		{
			Weight = 25.0;
			Name = "Presentoir Plein 1";
		}

		public PresentoirePlein1(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Furniture]
	[Flipable(0x999C, 0x999D)]
	public class PresentoirePlein2 : CraftableFurniture
	{
		[Constructable]
		public PresentoirePlein2()
			: base(0x999D)
		{
			Weight = 25.0;
			Name = "Presentoir Plein 2";
		}

		public PresentoirePlein2(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Furniture]
	[Flipable(0x998E, 0x998F, 0x9990, 0x9991)]
	public class TableApothicaire  : FurnitureContainer
	{
		[Constructable]
		public TableApothicaire()
			: base(0x998E)
		{
			Weight = 25.0;
			Name = "Table Apothicaire";
		}

		public TableApothicaire(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();


		}
	}
	[Furniture]
[Flipable(0x9970, 0x9971)]
public class RangementAlchimie : FurnitureContainer
	{
	[Constructable]
	public RangementAlchimie()
		: base(0x9970)
	{
		Weight = 25.0;
		Name = "Armoire Alchimiste";
	}

	public RangementAlchimie(Serial serial)
		: base(serial)
	{
	}

	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write(0);
	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();


	}
}
	[Furniture]
	[Flipable(0x9957, 0x9958, 0x9959, 0x995A, 0x995B, 0x995C)]
	public class TableBrasseur : CraftableFurniture
	{
		[Constructable]
		public TableBrasseur()
			: base(0x9957)
		{
			Weight = 10.0;
			Name = "Table de Brasseur";
		}

		public TableBrasseur(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Flipable(0x1945, 0x1946)]
	public class Paravent : CraftableFurniture
	{
		[Constructable]
		public Paravent()
			: base(0x1945)
		{
			Weight = 10.0;
			Name = "Paravent de bois";
		}

		public Paravent(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	[Flipable(0x997A, 0x997B)]
	public class ItemAlchimie : CraftableFurniture
	{
		[Constructable]
		public ItemAlchimie()
			: base(0x997B)
		{
			Weight = 10.0;
			Name = "Nécessaire d'alchimie";
		}

		public ItemAlchimie(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	public class GoldPile1 : CraftableFurniture
	{
		[Constructable]
		public GoldPile1()
			: base(0x9976)
		{
			Weight = 15.0;
			Name = "Trésor";
			Movable = false;
		}

		public GoldPile1(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}

		internal void MoveToWorld()
		{
			throw new NotImplementedException();
		}
	}
	public class GoldPile2 : CraftableFurniture
	{
		[Constructable]
		public GoldPile2()
			: base(0x9977)
		{
			Weight = 15.0;
			Name = "Trésor";
			Movable = false;
		}

		public GoldPile2(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
	public class PoteauChaine : CraftableFurniture
	{
		[Constructable]
		public PoteauChaine()
			: base(0x166D)
		{
			Weight = 15.0;
			Name = "Poteau avec chaines";
			
		}

		public PoteauChaine(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
}