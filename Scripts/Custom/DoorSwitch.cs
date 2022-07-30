using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace Server.Items
{

	public class DoorSwitch : Item
	{

		private ArrayList m_doors;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Lock { get; set; }


		[CommandProperty(AccessLevel.GameMaster)]
		public string Emote { get; set; }

		[Constructable]
		public DoorSwitch() : base(0x1095)
		{
			LootType = LootType.Blessed;
			Movable = true;
			Name = "Levier";
			m_doors = new ArrayList();
		}

		public DoorSwitch(Serial serial) : base(serial)
		{
		}

		/*	public override void GetProperties( ObjectPropertyList list )
			{

				base.GetProperties( list );
				int count = m_doors.Count;
				list.Add("Doors controlled: {0}", count);

			}

		   */

		public override void OnDoubleClick(Mobile m)
		{
			if (AccessLevel.Player < m.AccessLevel)
			{
				InvalidateProperties();
				m.SendMessage("Please target a door to add/remove or this item to open/close the doors.");
				m.Target = new AddDoor(m_doors);
				InvalidateProperties();
			}
			else if (Lock)
			{
				m.SendMessage("Le levier semble cadenassé");

			}
			else if (CanOpen(m))
			{
				switchit();

			}
		}

		public bool CanOpen(Mobile m)
		{
			if (m.IsStaff())
			{
				m.SendMessage("Du a vos pouvoirs divins, vous ouvrez la porte.");
				return true;
			}
			else if (!m.InLOS(this))
			{
				m.SendMessage("Vous devez avoir la vision du levier pour pouvoir l'activer.");
				return false;
			}
			else if (!m.InRange(this.Location,2))
			{
				m.SendMessage("Vous devez être à moin de deux cases pour activer un levier.");
				return false;
			}
			return true;
		}

		public void switchit()
		{

			if (Emote != null)
			{
				PublicOverheadMessage(MessageType.Regular, 0, false, $"*{Emote}*");
			}


            BaseDoor oc;
            foreach(Item i in m_doors){
                oc = i as BaseDoor;
                if (oc.Open)
                {
                    oc.Open = false;
                }
                else
                {
                    oc.Open = true;
                }
            }
        }

		public class AddDoor : Target
		{
            private ArrayList door;
            public AddDoor(ArrayList m_doors) : base(15, false, TargetFlags.None)
			{
                door = m_doors;
			}

            public void switchit()
            {
                BaseDoor oc;
                foreach (Item i in door)
                {
                    oc = i as BaseDoor;
                    if (oc.Open)
                    {
                        oc.Open = false;
                    }
                    else
                    {
                        oc.Open = true;
                    }
                }
            }

			protected override void OnTarget( Mobile from, object targ)
           {

                    if (targ is DoorSwitch)
                    {
                        switchit();
                        return;
                    }
                    if (!(targ is BaseDoor))
                    {
                        from.SendMessage("That is not a door");
                        return;
                    }
                    BaseDoor d = targ as BaseDoor;
                    Item targ1 = targ as Item;
                    if (!door.Contains(targ1))
                    {
                        door.Add(targ1);
                        from.SendMessage("Door added!");
                    }
                    else
                    {
                        door.Remove(targ1);
                        from.SendMessage("Door removed!");
                    }

			}
		}


		
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write(Emote);

            writer.WriteItemList(m_doors);


		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();


			switch (version)
			{
				case 1:
					Emote = reader.ReadString();
					goto case 0;
				case 0:
					m_doors = reader.ReadItemList();
					break;
				default:
					break;
			}





			

		}

	}


}