using Server.Engines.Craft;

namespace Server.Items
{

	public abstract class BasePipes : BaseClothing
	{
		public BasePipes(int itemID)
			: this(itemID, 0)
		{
		}

		public BasePipes(int itemID, int hue)
			: base(itemID, Layer.OneHanded, hue)
		{
		}

		public BasePipes(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class PipeCourbee :  BasePipes
    {
    
		[Constructable]
		public PipeCourbee()
			: this(0)
		{
		}

		[Constructable]
		public PipeCourbee(int hue)
		: base(41663, hue)
		{
			Weight = 2.0;
			Name ="Pipe Courbée";
		}

		public PipeCourbee(Serial serial)
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

	public class PipeCourte  :  BasePipes
	{
		[Constructable]
		public PipeCourte ()
				: this(0)
		{

		}

		[Constructable]
		public PipeCourte (int hue)
				: base(41664, hue)
		{
			Weight = 2.0;
			Name ="Pipe Courte";
		}

		public PipeCourte (Serial serial)
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
	public class PipeLongue :  BasePipes
	{
		[Constructable]
		public PipeLongue()
				: this(0)
		{

		}

		[Constructable]
		public PipeLongue(int hue)
				: base(41665, hue)
		{
			Weight = 2.0;
			Name ="Pipe Longue";
		}

		public PipeLongue(Serial serial)
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
	public class Carquois :  BaseQuiver
	{
			[Constructable]
			public Carquois()
					: this(0)
			{

			}

			[Constructable]
			public Carquois(int hue)
					: base(41794)
			{
				Weight = 2.0;
				Name ="Carquois";
			}

		public Carquois(Serial serial)
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
	public class fourreau :  BaseMiddleTorso
	{
		[Constructable]
		public fourreau()
			: this(0)

		{
		}

		[Constructable]
		public fourreau(int hue)
			: base(41795, hue)

		{
			Weight = 2.0;
			Name = "Fourreau Épée longue";
		}

		public fourreau(Serial serial)
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
	public class fourreau2 :  BaseMiddleTorso
	{
		[Constructable]
		public fourreau2()
			: this(0)
		{
		}

		[Constructable]
		public fourreau2(int hue)
			: base(41796, hue)

		{
			Weight = 2.0;
			Name = "Fourreau croisé";
		}

		public fourreau2(Serial serial)
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

	public class fourreau3 :  BaseMiddleTorso
	{
		[Constructable]
		public fourreau3()
				: this(0)

		{
		}

		[Constructable]
		public fourreau3(int hue)
				: base(41797, hue)

		{
			Weight = 2.0;
			Name = "Fourreau bandouillère";
		}

		public fourreau3(Serial serial)
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
	public class FourreauDore   : BaseMiddleTorso
	{
		[Constructable]
		public FourreauDore()
				: this(0)

		{
		}

		[Constructable]
		public FourreauDore(int hue)
				: base(0xA3EA, hue)

		{
			Weight = 2.0;
			Name = "Fourreau Dore";
		}

		public FourreauDore(Serial serial)
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

	public abstract class BaseFoulards : BaseClothing
	{
		public BaseFoulards(int itemID)
			: this(itemID, 0)
		{
		}

		public BaseFoulards(int itemID, int hue)
			: base(itemID, Layer.Neck, hue)
		{
		}

		public BaseFoulards(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class Foulard :  BaseFoulards
	{


		[Constructable]
		public Foulard()
				: this(0)
		{
		}

		[Constructable]
		public Foulard(int hue)
				: base(41798, hue)
		{
			Weight = 2.0;
			Name ="Foulard";
		}

		public Foulard(Serial serial)
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

	public class Foulard2 :  BaseFoulards
		{

			public override bool Disguise { get { return ItemID ==  41800 ? true : false; } }


				[Constructable]
				public Foulard2()
						: this(0)
				{
				}

				[Constructable]
				public Foulard2(int hue)
						: base(41799, hue)

				{
					Weight = 2.0;
					Name = "Foulard Épaule";
				}

				public Foulard2(Serial serial)
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
/*	public class Foulard3 :  BaseFoulards
			{
				[Constructable]
				public Foulard3()
						: this(0)
				{
				}

				[Constructable]
				public Foulard3(int hue)
						: base(41800, hue)
				{
					Weight = 2.0;
					Name ="Foulard3";
				}

				public Foulard3(Serial serial)
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
			}*/


	public class Foulard4 :  BaseFoulards
			{

				public override bool Disguise { get { return true; } }

				[Constructable]
				public Foulard4()
						: this(0)
				{
				}

			[Constructable]
			public Foulard4(int hue)
					: base(41801, hue)
			{
				Weight = 2.0;
				Name = "Cache-Visage";
			}

			public Foulard4(Serial serial)
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

	public class Cocarde :  BaseWaist
			{
			[Constructable]
			public Cocarde()
					: this(0)
			{

			}

			[Constructable]
			public Cocarde(int hue)
					: base(41802, hue)
			{
				Weight = 2.0;
				Name ="Cocarde";
			}

			public Cocarde(Serial serial)
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

	public class BandagesPieds : BaseWaist
	{
		[Constructable]
		public BandagesPieds()
				: this(0)
		{

		}

		[Constructable]
		public BandagesPieds(int hue)
				: base(0xA412, hue)
		{
			Weight = 2.0;
			Name = "Bandages Pieds";
		}

		public BandagesPieds(Serial serial)
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

	public class BandagesBras : BaseWaist
	{
		[Constructable]
		public BandagesBras()
				: this(0)
		{

		}

		[Constructable]
		public BandagesBras(int hue)
				: base(0xA413, hue)
		{
			Weight = 2.0;
			Name = "Bandages Bras";
		}

		public BandagesBras(Serial serial)
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

	public class BandagesTaille : BaseWaist
	{
		[Constructable]
		public BandagesTaille()
				: this(0)
		{

		}

		[Constructable]
		public BandagesTaille(int hue)
				: base(0xA414, hue)
		{
			Weight = 2.0;
			Name = "Bandages Taille";
		}

		public BandagesTaille(Serial serial)
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
	public class BourseCeinture :  BaseWaist
		{

		[Constructable]
		public BourseCeinture()
				: this(0)
		{
		}

		[Constructable]
		public BourseCeinture(int hue)
				: base(41811, hue)
		{
			Weight = 2.0;
			Name ="Bourse de Ceinture";
		}

		public BourseCeinture(Serial serial)
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
	public class Ceinture :  BaseWaist
		{

		[Constructable]
		public Ceinture()
				: this(0)
		{
		}

		[Constructable]
		public Ceinture(int hue)
				: base(41812, hue)
		{
			Weight = 2.0;
			Name = "Ceinture boucle ronde";
		}
		public Ceinture(Serial serial)
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
	public class Ceinture2 :  BaseWaist
		{
			[Constructable]
			public Ceinture2()
					: this(0)
			{
			}

			[Constructable]
			public Ceinture2(int hue)
					: base(41813, hue)
			{
				Weight = 2.0;
				Name = "Ceinture boucle carrée";
			}
			public Ceinture2(Serial serial)
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

		public class Ceinture3 :  BaseWaist
		{
			[Constructable]
			public Ceinture3()
					: this(0)
			{

			}

			[Constructable]
			public Ceinture3(int hue)
					: base(41814, hue)
			{
				Weight = 2.0;
				Name = "Ceinture d'artisan";
			}

			public Ceinture3(Serial serial)
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

		public class Ceinture4 :  BaseWaist
			{

			[Constructable]
			public Ceinture4()
					: this(0)
			{
			}

			[Constructable]
			public Ceinture4(int hue)
					: base(41815, hue)
			{
				Weight = 2.0;
				Name = "Ceinture à pochettes";
			}

			public Ceinture4(Serial serial)
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

		public class Ceinture5 :  BaseWaist
			{
			[Constructable]
			public Ceinture5()
					: this(0)
			{
			}

			[Constructable]
			public Ceinture5(int hue)
					: base(41816, hue)
			{
				Weight = 2.0;
				Name = "Ceinture mince";
			}

			public Ceinture5(Serial serial)
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

		public class Ceinture6 :  BaseWaist
		{
			
			[Constructable]
			public Ceinture6()
					: this(0)
			{
			}

			[Constructable]
			public Ceinture6(int hue)
					: base(41817, hue)
			{
				Weight = 2.0;
				Name = "Ceinture poche à gauche";
			}

			public Ceinture6(Serial serial)
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
		public class Ceinture7 :  BaseWaist
		{
			[Constructable]
			public Ceinture7()
					: this(0)
			{

			}

			[Constructable]
			public Ceinture7(int hue)
					: base(41818, hue)
			{
				Weight = 2.0;
				Name = "Ceinture en tissu";
			}

			public Ceinture7(Serial serial)
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
		public class Ceinture8 :  BaseWaist
		{
			[Constructable]
			public Ceinture8()
					: this(0)
			{

			}

			[Constructable]
			public Ceinture8(int hue)
					: base(41819, hue)
			{
				Weight = 2.0;
				Name = "Ceinture en bandouillère";
			}

			public Ceinture8(Serial serial)
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
		public class Ceinture9 :  BaseWaist
			{

			[Constructable]
			public Ceinture9()
					: this(0)
			{

			}

			[Constructable]
			public Ceinture9(int hue)
					: base(41820, hue)
			{
				Weight = 2.0;
				Name = "Bourse carrée";
			}

			public Ceinture9(Serial serial)
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

	public class CeintureBaril : BaseWaist
	{

		[Constructable]
		public CeintureBaril()
				: this(0)
		{

		}

		[Constructable]
		public CeintureBaril(int hue)
				: base(0xA3DA, hue)
		{
			Weight = 2.0;
			Name = "Ceinture Barril";
		}

		public CeintureBaril(Serial serial)
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
	public class CeintureMetal : BaseWaist
	{

		[Constructable]
		public CeintureMetal()
				: this(0)
		{

		}

		[Constructable]
		public CeintureMetal(int hue)
				: base(0xA3EB, hue)
		{
			Weight = 2.0;
			Name = "Ceinture Metale";
		}

		public CeintureMetal(Serial serial)
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
	public class CentureDoreeLarge : BaseWaist
	{

		[Constructable]
		public CentureDoreeLarge()
				: this(0)
		{

		}

		[Constructable]
		public CentureDoreeLarge(int hue)
				: base(0xA3EC, hue)
		{
			Weight = 2.0;
			Name = "Ceinture Doree Large";
		}

		public CentureDoreeLarge(Serial serial)
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
	public class CacheOeil1 : BaseWaist
	{

		[Constructable]
		public CacheOeil1()
				: this(0)
		{

		}

		[Constructable]
		public CacheOeil1(int hue)
				: base(0xA3DC, hue)
		{
			Weight = 2.0;
			Name = "Cache Oeil";
		}

		public CacheOeil1(Serial serial)
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
	public class CacheOeil2 : BaseWaist
	{

		[Constructable]
		public CacheOeil2()
				: this(0)
		{

		}

		[Constructable]
		public CacheOeil2(int hue)
				: base(0xA3DD, hue)
		{
			Weight = 2.0;
			Name = "Cache Oeil";
		}

		public CacheOeil2(Serial serial)
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
	public class CacheOeil3 : BaseWaist
	{

		[Constructable]
		public CacheOeil3()
				: this(0)
		{

		}

		[Constructable]
		public CacheOeil3(int hue)
				: base(0xA3DE, hue)
		{
			Weight = 2.0;
			Name = "Cache Oeil";
		}

		public CacheOeil3(Serial serial)
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






