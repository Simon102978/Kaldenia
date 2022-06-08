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
			Name ="fourreau";
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
			Name ="fourreau2";
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
			Name ="fourreau3";
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

	public abstract class BaseFoulards : BaseClothing
	{
		public override bool Disguise { get { return false; } }

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
					Name ="Foulard2";
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
				Name ="Foulard4";
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
			Name ="Ceinture";
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
				Name ="Ceinture2";
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
				Name ="Ceinture3";
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
				Name ="Ceinture4";
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
				Name ="Ceinture5";
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
				Name ="Ceinture6";
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
				Name ="Ceinture7";
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
				Name ="Ceinture8";
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
				Name ="Ceinture9";
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
}






