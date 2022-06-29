using Server.Accounting;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using System.Collections.Generic;
using System.Linq;

namespace Server.Items
{
	[Furniture]
	[Flipable(0x994B, 0x994C)]
	public class MaritimeChest : LockableContainer
	{
		public override int DefaultGumpID { get { return 0x44; } }
		public override int DefaultMaxItems { get { return 250; } }
		[Constructable]
		public MaritimeChest()
			: base(0x994B)
		{
			Name = "Coffre Maritime";
			Weight = 50.0;
		}

		public MaritimeChest(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	[Furniture]
	[Flipable(0x9955, 0x9956)]
	public class BarrildeVin : BaseContainer
	{
		public override int DefaultGumpID { get { return 0x3E; } }
		public override int DefaultMaxItems { get { return 250; } }

		[Constructable]
		public BarrildeVin()
			: base(0x9955)
		{
			Name = "Petit Barril";
				Weight = 20.0;
		}

		public BarrildeVin(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	[Furniture]
	[Flipable(0x995D, 0x995E)]
	public class CoffreFort : LockableContainer
	{
		public override int DefaultGumpID { get { return 0x4B; } }
		public override int DefaultMaxItems { get { return 250; } }

		[Constructable]
		public CoffreFort()
			: base(0x995D)
		{
			Name = "Coffre Fort";
			Weight = 30.0;
		}

		public CoffreFort(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	[Furniture]
	[Flipable(0x9965, 0x9966)]
	public class CoffreMetalVisqueux : LockableContainer
	{
		public override int DefaultGumpID { get { return 0x4A; } }
		public override int DefaultMaxItems { get { return 250; } }

		[Constructable]
		public CoffreMetalVisqueux()
			: base(0x9965)
		{
			Name = "Coffre Visqueux";
			Weight = 15.0;
		}

		public CoffreMetalVisqueux(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	[Furniture]
	[Flipable(0x9969, 0x996A)]
	public class CoffreMetalRouille : LockableContainer
	{
		public override int DefaultGumpID { get { return 0x4A; } }
		public override int DefaultMaxItems { get { return 250; } }

		[Constructable]
		public CoffreMetalRouille()
			: base(0x9969)
		{
			Name = "Coffre Rouill??#$?&*";
			Weight = 15.0;
		}

		public CoffreMetalRouille(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	[Furniture]
	[Flipable(0x996B, 0x996C)]
	public class CoffreMetalDore : LockableContainer
	{
		public override int DefaultGumpID { get { return 0x4A; } }
		public override int DefaultMaxItems { get { return 250; } }

		[Constructable]
		public CoffreMetalDore()
			: base(0x996B)
		{
			Name = "Coffre Dor??#$?&*";
			Weight = 15.0;
		}

		public CoffreMetalDore(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	[Furniture]
	[Flipable(0x9972, 0x9973)]
	public class CoffrePirate : LockableContainer
	{
		public override int DefaultGumpID { get { return 0x4A; } }
		public override int DefaultMaxItems { get { return 250; } }

		[Constructable]
		public CoffrePirate()
			: base(0x9972)
		{
			Name = "Coffre";
			Weight = 50.0;
		}
	
		

		public CoffrePirate(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}