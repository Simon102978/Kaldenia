using Server.Commands;
using Server.Network;
using Server.Targeting;
using System;
using System.Collections.Generic;

namespace Server.Items
{
	public abstract class CustomDoor : BaseDoor, ILockpickable
	{

		private Mobile m_Picker;
		private int m_LockLevel, m_MaxLockLevel, m_RequiredSkill;
		private DateTime m_LastPick;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Picker
		{
			get
			{
				return m_Picker;
			}
			set
			{
				m_Picker = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxLockLevel
		{
			get
			{
				return m_MaxLockLevel;
			}
			set
			{
				m_MaxLockLevel = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int LockLevel
		{
			get
			{
				return m_LockLevel;
			}
			set
			{
				m_LockLevel = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int RequiredSkill
		{
			get
			{
				return m_RequiredSkill;
			}
			set
			{
				m_RequiredSkill = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastPick
		{
			get
			{
				return m_LastPick;
			}
			set
			{
				m_LastPick = value;
			}
		}


		[Constructable]
		public CustomDoor(int closedID, int openedID, int openedSound, int closedSound, Point3D offset)
			: base(closedID, openedID, openedSound, closedSound, offset)
		{
		}

		public CustomDoor(Serial serial)
			: base(serial)
		{
		}


		public override void Use(Mobile from)
		{

			if (!Locked && LastPick.AddHours(1) < DateTime.Now)
			{
				Locked = true;
				Picker = null;

			}

			base.Use(from);
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(1); // version

			writer.Write(m_RequiredSkill);
			writer.Write(m_MaxLockLevel);
			writer.Write(m_LockLevel);
			writer.Write(m_Picker);
			writer.Write(m_LastPick);
	}


	public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_RequiredSkill = reader.ReadInt();
						m_MaxLockLevel = reader.ReadInt();
						m_LockLevel = reader.ReadInt();
						m_Picker = reader.ReadMobile();
						m_LastPick = reader.ReadDateTime();
						break;
					}
			}
		}

		public void LockPick(Mobile from)
		{
			Locked = false;
			Picker = from;
			LastPick = DateTime.Now;
		}
	}

	public class CustomMetalDoor : CustomDoor
	{
		[Constructable]
		public CustomMetalDoor(DoorFacing facing)
			: base(0x675 + (2 * (int)facing), 0x676 + (2 * (int)facing), 0xEC, 0xF3, GetOffset(facing))
		{
		}

		public CustomMetalDoor(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class CustomDarkWoodDoor : CustomDoor
	{
		[Constructable]
		public CustomDarkWoodDoor(DoorFacing facing)
			: base(0x6A5 + (2 * (int)facing), 0x6A6 + (2 * (int)facing), 0xEA, 0xF1, GetOffset(facing))
		{
		}

		public CustomDarkWoodDoor(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class CustomLightWoodDoor : CustomDoor
	{
		[Constructable]
		public CustomLightWoodDoor(DoorFacing facing)
			: base(0x6D5 + (2 * (int)facing), 0x6D6 + (2 * (int)facing), 0xEA, 0xF1, GetOffset(facing))
		{
		}

		public CustomLightWoodDoor(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class CustomStrongWoodDoor : CustomDoor
	{
		[Constructable]
		public CustomStrongWoodDoor(DoorFacing facing)
			: base(0x6E5 + (2 * (int)facing), 0x6E6 + (2 * (int)facing), 0xEA, 0xF1, GetOffset(facing))
		{
		}

		public CustomStrongWoodDoor(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class CustomBarredMetalDoor2 : CustomDoor
	{
		[Constructable]
		public CustomBarredMetalDoor2(DoorFacing facing)
			: base(0x1FED + (2 * (int)facing), 0x1FEE + (2 * (int)facing), 0xEC, 0xF3, GetOffset(facing))
		{
		}

		public CustomBarredMetalDoor2(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}



}
