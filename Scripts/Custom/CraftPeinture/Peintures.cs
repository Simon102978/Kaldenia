using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using System.Collections.Generic;
using Server.Engines.Craft;

namespace Server.Items
{
	
    public abstract class Peintures : Item, ICraftable
	{
		private string m_Title;
		private Dictionary<int, string> m_Description = new Dictionary<int, string>();
		private Mobile m_Crafter;
		private string m_CrafterName;
		private bool m_Finish;

		[CommandProperty(AccessLevel.GameMaster)]
		public string CrafterName { get => m_CrafterName; set => m_CrafterName = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Finish { get => m_Finish; set => m_Finish = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public string Title { get => m_Title; set => m_Title = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Dictionary<int, string> Description { get => m_Description; set => m_Description = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Crafter { get => m_Crafter; set => m_Crafter = value; }

		public Peintures(int itemID)
            : this(itemID, 0)
        {
        }

        public Peintures(int itemID, int hue)
            : base(itemID)
        {
        }

        public Peintures(Serial serial)
            : base(serial)
        {
        }

		public override void OnDoubleClick(Mobile from)
		{
			if (from is CustomPlayerMobile )
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;

				if (Finish || from == m_Crafter || from.AccessLevel > AccessLevel.Player)
				{			
					from.SendGump(new PeinturesGump(cp, this));
				}
				else 
				{
					from.SendMessage("Seul le créateur de la toile peut la terminer.");
				}
			
			}
		}

		public string GetContenu(int Entry)
		{
			if (Description.ContainsKey(Entry))
			{
				return Description[Entry];
			}
			else
			{
				return "";
			}


		}


		public void ApplyPeinture(PeintureEnCours p)
		{
			m_Finish = true;
			m_Title = p.Title;
			m_CrafterName = p.Name;

	//		Name = m_Title;

			foreach (KeyValuePair<int,string> item in p.Description)
			{
				addContenu(item.Key, item.Value);
			}
		}

		public void addContenu(int Entry, string value)
		{
			if (m_Description.ContainsKey(Entry))
			{
				m_Description[Entry] = value;
			}
			else
			{
				m_Description.Add(Entry, value);
			}
		}

		public override void GetProperties(ObjectPropertyList list)
        {
            if (!Finish)
                list.Add("Toile %%%#$%?%$#@! complèter");
			else
			{
				list.Add(m_Title);
				list.Add("Par: " + m_CrafterName);
			}
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
			writer.Write(m_CrafterName);
			writer.Write(m_Finish);
			writer.Write(m_Crafter);
			writer.Write(Description.Count);

			foreach (KeyValuePair<int, string> item in Description)
			{
				writer.Write(item.Key);
				writer.Write(item.Value);
			}

			writer.Write((string)m_Title);
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();


			switch (version)
			{
				case 1:
					{
						m_CrafterName = reader.ReadString();
						m_Finish = reader.ReadBool();
						m_Crafter = reader.ReadMobile();

						int count = (int)reader.ReadInt();

						for (int i = 0; i < count; i++)
						{
							Description.Add(reader.ReadInt(), reader.ReadString());
						}

						goto case 0;
					}
				case 0:
					{
						m_Title = reader.ReadString();

						break;
					}
			}

		
        }

		public int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
		{
		
			

			Crafter = from;


			return quality;

		}
	}
	
	public class PortraitSud01 : Peintures
	{
		[Constructable]
		public PortraitSud01() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud01(int hue) : base( 3750, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud01( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PortraitSud02 : Peintures
	{
		[Constructable]
		public PortraitSud02() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud02(int hue) : base( 3751 , hue)
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud02( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PortraitSud03 : Peintures
	{
		[Constructable]
		public PortraitSud03() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud03(int hue) : base( 3815, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud03( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	public class PortraitSud04 : Peintures
	{
		[Constructable]
		public PortraitSud04() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud04(int hue) : base( 3743 , hue)
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud04( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PortraitSud05 : Peintures
	{
		[Constructable]
		public PortraitSud05() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud05(int hue) : base( 3747, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud05( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PortraitEst01 : Peintures
	{
        [Constructable]
        public PortraitEst01()
            : this(0)
        {
        }

        [Constructable]
        public PortraitEst01(int hue)
            : base(3749, hue)
        {
			Weight = 1.0;
            Name = "Portrait";
        }
		
		public PortraitEst01( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PortraitEst02 : Peintures
	{
		[Constructable]
		public PortraitEst02() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst02(int hue) : base( 3752, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst02( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst03 : Peintures
	{
		[Constructable]
		public PortraitEst03() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst03(int hue) : base( 3785, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst03( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst04 : Peintures
	{
		[Constructable]
		public PortraitEst04() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst04(int hue) : base( 3784, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst04( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst05 : Peintures
	{
		[Constructable]
		public PortraitEst05() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst05(int hue) : base( 3748, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst05( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitHomme : Peintures
	{
		[Constructable]
		public PortraitHomme() : this( 0 )
		{
		}

		[Constructable]
		public PortraitHomme(int hue) : base( 10905, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitHomme( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud06 : Peintures
	{
		[Constructable]
		public PortraitSud06() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud06(int hue) : base( 10845, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud06( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud07 : Peintures
	{
		[Constructable]
		public PortraitSud07() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud07(int hue) : base( 10846, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud07( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud08 : Peintures
	{
		[Constructable]
		public PortraitSud08() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud08(int hue) : base( 10847, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud08( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud09 : Peintures
	{
		[Constructable]
		public PortraitSud09() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud09(int hue) : base( 10848, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud09( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst06 : Peintures
	{
		[Constructable]
		public PortraitEst06() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst06(int hue) : base( 10849, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst06( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst07 : Peintures
	{
		[Constructable]
		public PortraitEst07() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst07(int hue) : base( 10850, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst07( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst08 : Peintures
	{
		[Constructable]
		public PortraitEst08() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst08(int hue) : base( 10851 , hue)
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst08( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst09 : Peintures
	{
		[Constructable]
		public PortraitEst09() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst09(int hue) : base( 10852, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst09( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud01 : Peintures
	{
		[Constructable]
		public PeintureSud01() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud01(int hue) : base( 11634 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud01( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst01 : Peintures
	{
		[Constructable]
		public PeintureEst01() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst01(int hue) : base( 11633, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst01( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitFemme : Peintures
	{
		[Constructable]
		public PortraitFemme() : this( 0 )
		{
		}

		[Constructable]
		public PortraitFemme(int hue) : base( 3744 , hue)
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitFemme( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud10 : Peintures
	{
		[Constructable]
		public PortraitSud10() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud10(int hue) : base( 15604, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud10( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud11 : Peintures
	{
		[Constructable]
		public PortraitSud11() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud11(int hue) : base( 10853, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud11( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud12 : Peintures
	{
		[Constructable]
		public PortraitSud12() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud12(int hue) : base( 10854, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud12( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud13 : Peintures
	{
		[Constructable]
		public PortraitSud13() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud13(int hue) : base( 10857, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud13( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud14 : Peintures
	{
		[Constructable]
		public PortraitSud14() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud14(int hue) : base( 10858 , hue)
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud14( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud15 : Peintures
	{
		[Constructable]
		public PortraitSud15() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud15(int hue) : base( 10859, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud15( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitSud16 : Peintures
	{
		[Constructable]
		public PortraitSud16() : this( 0 )
		{
		}

		[Constructable]
		public PortraitSud16(int hue) : base( 10860, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitSud16( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst10 : Peintures
	{
		[Constructable]
		public PortraitEst10() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst10(int hue) : base( 15603, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst10( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst11 : Peintures
	{
		[Constructable]
		public PortraitEst11() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst11(int hue) : base( 10855, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst11( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst12 : Peintures
	{
		[Constructable]
		public PortraitEst12() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst12(int hue) : base( 10856, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst12( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst13 : Peintures
	{
		[Constructable]
		public PortraitEst13() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst13(int hue) : base( 10861, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst13( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst14 : Peintures
	{
		[Constructable]
		public PortraitEst14() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst14(int hue) : base( 10862, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst14( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst15 : Peintures
	{
		[Constructable]
		public PortraitEst15() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst15(int hue) : base( 10863, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst15( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PortraitEst16 : Peintures
	{
		[Constructable]
		public PortraitEst16() : this( 0 )
		{
		}

		[Constructable]
		public PortraitEst16(int hue) : base( 10864, hue )
		{
			Weight = 1.0;
			
            Name = "Portrait";
		}

		public PortraitEst16( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud : Peintures
	{
		[Constructable]
		public PeintureSud() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud(int hue) : base( 15594, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud02 : Peintures
	{
		[Constructable]
		public PeintureSud02() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud02(int hue) : base( 15600, hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud02( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud03 : Peintures
	{
		[Constructable]
		public PeintureSud03() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud03(int hue) : base( 15585, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud03( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud04 : Peintures
	{
		[Constructable]
		public PeintureSud04() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud04(int hue) : base( 15591 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud04( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud05 : Peintures
	{
		[Constructable]
		public PeintureSud05() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud05(int hue) : base( 15614, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud05( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud06 : Peintures
	{
		[Constructable]
		public PeintureSud06() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud06(int hue) : base( 15616, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud06( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud07 : Peintures
	{
		[Constructable]
		public PeintureSud07() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud07(int hue) : base( 15610, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud07( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud08 : Peintures
	{
		[Constructable]
		public PeintureSud08() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud08(int hue) : base( 15598, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud08( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud09 : Peintures
	{
		[Constructable]
		public PeintureSud09() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud09(int hue) : base( 15608, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud09( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud10 : Peintures
	{
		[Constructable]
		public PeintureSud10() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud10(int hue) : base( 15624, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud10( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud11 : Peintures
	{
		[Constructable]
		public PeintureSud11() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud11(int hue) : base( 15632, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud11( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud12 : Peintures
	{
		[Constructable]
		public PeintureSud12() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud12(int hue) : base( 15618 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud12( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud13 : Peintures
	{
		[Constructable]
		public PeintureSud13() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud13(int hue) : base( 15620 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud13( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst02 : Peintures
	{
		[Constructable]
		public PeintureEst02() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst02(int hue) : base( 15599 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst02( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst03 : Peintures
	{
		[Constructable]
		public PeintureEst03() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst03(int hue) : base( 15584 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst03( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst04 : Peintures
	{
		[Constructable]
		public PeintureEst04() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst04(int hue) : base( 15590, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst04( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst05 : Peintures
	{
		[Constructable]
		public PeintureEst05() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst05(int hue) : base( 15613, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst05( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst06 : Peintures
	{
		[Constructable]
		public PeintureEst06() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst06(int hue) : base( 15615, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst06( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst07 : Peintures
	{
		[Constructable]
		public PeintureEst07() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst07(int hue) : base( 15609, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst07( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst08 : Peintures
	{
		[Constructable]
		public PeintureEst08() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst08(int hue) : base( 15597, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst08( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst09 : Peintures
	{
		[Constructable]
		public PeintureEst09() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst09(int hue) : base( 15607, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst09( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst10 : Peintures
	{
		[Constructable]
		public PeintureEst10() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst10(int hue) : base( 15623, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst10( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst11 : Peintures
	{
		[Constructable]
		public PeintureEst11() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst11(int hue) : base( 15631, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst11( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst12 : Peintures
	{
		[Constructable]
		public PeintureEst12() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst12(int hue) : base( 15617, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst12( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst13 : Peintures
	{
		[Constructable]
		public PeintureEst13() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst13(int hue) : base( 15619, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst13( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud14 : Peintures
	{
		[Constructable]
		public PeintureSud14() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud14(int hue) : base( 15583, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud14( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud15 : Peintures
	{
		[Constructable]
		public PeintureSud15() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud15(int hue) : base( 15606, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud15( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud16 : Peintures
	{
		[Constructable]
		public PeintureSud16() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud16(int hue) : base( 15593, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud16( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud17 : Peintures
	{
		[Constructable]
		public PeintureSud17() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud17(int hue) : base( 15589, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud17( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud18 : Peintures
	{
		[Constructable]
		public PeintureSud18() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud18(int hue) : base( 15622, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud18( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud19 : Peintures
	{
		[Constructable]
		public PeintureSud19() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud19(int hue) : base( 15611, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud19( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud20 : Peintures
	{
		[Constructable]
		public PeintureSud20() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud20(int hue) : base( 15633, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud20( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud21 : Peintures
	{
		[Constructable]
		public PeintureSud21() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud21(int hue) : base( 15626 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud21( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud22 : Peintures
	{
		[Constructable]
		public PeintureSud22() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud22(int hue) : base( 15630 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud22( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud23 : Peintures
	{
		[Constructable]
		public PeintureSud23() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud23(int hue) : base( 15628, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud23( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud24 : Peintures
	{
		[Constructable]
		public PeintureSud24() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud24(int hue) : base( 15602, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud24( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud25 : Peintures
	{
		[Constructable]
		public PeintureSud25() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud25(int hue) : base( 15587 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud25( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud26 : Peintures
	{
		[Constructable]
		public PeintureSud26() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud26(int hue) : base( 11632 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud26( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst14 : Peintures
	{
		[Constructable]
		public PeintureEst14() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst14(int hue) : base( 15582 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst14( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst15 : Peintures
	{
		[Constructable]
		public PeintureEst15() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst15(int hue) : base( 15605, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst15( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst16 : Peintures
	{
		[Constructable]
		public PeintureEst16() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst16(int hue) : base( 15592, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst16( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst17 : Peintures
	{
		[Constructable]
		public PeintureEst17() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst17(int hue) : base( 15588, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst17( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst18 : Peintures
	{
		[Constructable]
		public PeintureEst18() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst18(int hue) : base( 15621, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst18( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst19 : Peintures
	{
		[Constructable]
		public PeintureEst19() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst19(int hue) : base( 15596 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst19( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst20 : Peintures
	{
		[Constructable]
		public PeintureEst20() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst20(int hue) : base( 15612 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst20( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst21 : Peintures
	{
		[Constructable]
		public PeintureEst21() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst21(int hue) : base( 15625 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst21( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst22 : Peintures
	{
		[Constructable]
		public PeintureEst22() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst22(int hue) : base( 15629 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst22( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst23 : Peintures
	{
		[Constructable]
		public PeintureEst23() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst23(int hue) : base( 15627, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst23( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst24 : Peintures
	{
		[Constructable]
		public PeintureEst24() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst24(int hue) : base( 15601 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst24( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst25 : Peintures
	{
		[Constructable]
		public PeintureEst25() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst25(int hue) : base( 15586 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst25( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureEst26 : Peintures
	{
		[Constructable]
		public PeintureEst26() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst26(int hue) : base( 11631, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst26( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud27 : Peintures
	{
		[Constructable]
		public PeintureSud27() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud27(int hue) : base( 15646 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud27( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud28 : Peintures
	{
		[Constructable]
		public PeintureSud28() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud28(int hue) : base( 15648, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud28( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud29 : Peintures
	{
		[Constructable]
		public PeintureSud29() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud29(int hue) : base( 15650, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud29( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud30 : Peintures
	{
		[Constructable]
		public PeintureSud30() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud30(int hue) : base( 15652, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud30( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud31 : Peintures
	{
		[Constructable]
		public PeintureSud31() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud31(int hue) : base( 15654 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud31( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud32 : Peintures
	{
		[Constructable]
		public PeintureSud32() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud32(int hue) : base( 15656 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud32( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud33 : Peintures
	{
		[Constructable]
		public PeintureSud33() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud33(int hue) : base( 15658 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud33( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud34 : Peintures
	{
		[Constructable]
		public PeintureSud34() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud34(int hue) : base( 15660 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud34( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud35 : Peintures
	{
		[Constructable]
		public PeintureSud35() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud35(int hue) : base( 15662, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud35( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
	public class PeintureSud36 : Peintures
	{
		[Constructable]
		public PeintureSud36() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud36(int hue) : base( 15664 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud36( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud37 : Peintures
	{
		[Constructable]
		public PeintureSud37() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud37(int hue) : base( 15666 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud37( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureSud38 : Peintures
	{
		[Constructable]
		public PeintureSud38() : this( 0 )
		{
		}

		[Constructable]
		public PeintureSud38(int hue) : base( 15668 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureSud38( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst27 : Peintures
	{
		[Constructable]
		public PeintureEst27() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst27(int hue) : base( 15645 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst27( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst28 : Peintures
	{
		[Constructable]
		public PeintureEst28() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst28(int hue) : base( 15647, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst28( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst29 : Peintures
	{
		[Constructable]
		public PeintureEst29() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst29(int hue) : base( 15649, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst29( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst30 : Peintures
	{
		[Constructable]
		public PeintureEst30() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst30(int hue) : base( 15651, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst30( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst31 : Peintures
	{
		[Constructable]
		public PeintureEst31() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst31(int hue) : base( 15653, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst31( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst32 : Peintures
	{
		[Constructable]
		public PeintureEst32() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst32(int hue) : base( 15655, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst32( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst33 : Peintures
	{
		[Constructable]
		public PeintureEst33() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst33(int hue) : base( 15657, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst33( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();


		}
	}
	public class PeintureEst34 : Peintures
	{
		[Constructable]
		public PeintureEst34() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst34(int hue) : base( 15659 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst34( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst35 : Peintures
	{
		[Constructable]
		public PeintureEst35() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst35(int hue) : base( 15661 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst35( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst36 : Peintures
	{
		[Constructable]
		public PeintureEst36() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst36(int hue) : base( 15663 , hue)
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst36( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst37 : Peintures
	{
		[Constructable]
		public PeintureEst37() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst37(int hue) : base( 15665, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst37( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
	public class PeintureEst38 : Peintures
	{
		[Constructable]
		public PeintureEst38() : this( 0 )
		{
		}

		[Constructable]
		public PeintureEst38(int hue) : base( 15667, hue )
		{
			Weight = 1.0;
			
            Name = "Peinture";
		}

		public PeintureEst38( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();

		}
	}
}