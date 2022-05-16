
using System;
using Server;
using Server.Items;
using Server.Prompts;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items

{
	public class MilkBucket : Item
	{
		public int Milking;
		public int Beast;

		[CommandProperty( AccessLevel.GameMaster )]
		public int m_milking
        {
			get { return Milking; }
			set { Milking = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int m_beast
        {
			get { return Beast; }
			set { Beast = value; InvalidateProperties(); }
		}

		[Constructable]
		public MilkBucket() : base( 0x0FFA )
		{
			Weight = 10.0;
			Name = "Milk Bucket: (Empty)";
			Hue = 1001;
		}

		public override void OnAosSingleClick( Mobile from )
		{
			base.OnAosSingleClick( from );
			this.LabelTo( from, Milking.ToString());
		}

		public override void OnDoubleClick (Mobile from )
		{
			if (! from.InRange( this.GetWorldLocation(), 1 ))
			{
				from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 );
			}
			else
			{
				from.Target = new WellSeeTheCows( this );
				from.SendMessage(0x96D, "What do you want to use that with?" );
			}
		}
		public MilkBucket( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
			writer.Write( (int) Milking);
			writer.Write( (int) Beast);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
					{
                        Milking = reader.ReadInt();
						Beast = (int)reader.ReadInt();
						break;
					}
			}
		}
	}

	public class WellSeeTheCows : Target
	{
		private MilkBucket m_varjump;
		Mobile m_mobile = null;

		public WellSeeTheCows( MilkBucket m_jump) : base( 2, false, TargetFlags.None )
		{
            m_varjump = m_jump;
		}

		protected override void OnTarget( Mobile from, object o )
		{
			Container pack = from.Backpack;
			if( o is Mobile)
				m_mobile =(Mobile)o;

			if ((m_varjump.m_milking == 0) && (m_varjump.m_beast == 0) && m_mobile != null)
			{
				if (m_mobile is Sheep || m_mobile is FarmSheep)
				{
					m_varjump.m_beast = 1;

					++m_varjump.m_milking;
					m_mobile.Stam = m_mobile.Stam - 3;
					from.PlaySound(0X4D1);
					m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of sheep milk.";
					from.SendMessage(0x96D, "You obtain 1 liter of sheep milk." );
				}
                else if (m_mobile is Goat || m_mobile is FarmGoat)
				{
					m_varjump.m_beast = 2;

					++m_varjump.m_milking;
					m_mobile.Stam = m_mobile.Stam - 3;
					from.PlaySound(0X4D1);
					m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of goat milk.";
					from.SendMessage(0x96D, "You obtain 1 liter of goat milk." );
				}
                else if (m_mobile is Cow || m_mobile is Cow1 || m_mobile is FarmCow)
				{
					m_varjump.m_beast = 3;

					++m_varjump.m_milking;
					m_mobile.Stam = m_mobile.Stam - 3;
					from.PlaySound(0X4D1);
					m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of cow milk.";
					from.SendMessage(0x96D, "You obtain 1 liter of cow milk." );
				}
                else
				{
					from.SendMessage (0x96D,"You can obtain milk only from sheep, goats or cows!");
					from.CloseGump( typeof(MilkingHelpGump) );
					from.SendGump( new MilkingHelpGump( from ) );
				}
			}
			else if ( m_mobile != null && (m_varjump.m_milking <= 49))
			{
				if (m_mobile.Stam > 3)
				{
					if ((m_mobile is Cow || m_mobile is Cow1 || m_mobile is FarmCow) && (m_varjump.m_beast == 3 ))
					{
						++m_varjump.m_milking;
						m_mobile.Stam = m_mobile.Stam - 3;
						from.PlaySound(0X4D1);
						m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of cow milk.";
						from.SendMessage(0x96D, "You obtain 1 liter of cow milk." );
					}
                    else if ((m_mobile is Goat || m_mobile is FarmGoat) && (m_varjump.m_beast == 2 ))
					{
						++m_varjump.m_milking;
						m_mobile.Stam = m_mobile.Stam - 3;
						from.PlaySound(0X4D1);
						m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of goat milk.";
						from.SendMessage(0x96D, "You obtain 1 liter of goat milk." );
					}
                    else if ((m_mobile is Sheep || m_mobile is FarmSheep) && (m_varjump.m_beast == 1 ))
					{
						++m_varjump.m_milking;
						m_mobile.Stam = m_mobile.Stam - 3;
						from.PlaySound(0X4D1);
						m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of sheep milk.";
						from.SendMessage(0x96D, "You obtain 1 liter of sheep milk." );
					}
                    else
					{
						from.SendMessage(0x84B, "You can't obtain milk from that!" );
						from.CloseGump( typeof(MilkingHelpGump) );
						from.SendGump( new MilkingHelpGump( from ) );
					}
				}
				else
				{
					from.SendMessage(0x84B, "This animal is too tired to give more milk!" );
				}
			}
			else if ((o is Bottle ) && ( m_varjump.m_milking > 0 ) && pack.ConsumeTotal( typeof( Bottle ), 1 ))
			{
				if (m_varjump.m_beast == 3)
				{
					m_varjump.m_milking = m_varjump.m_milking -1;
					from.SendMessage (0x96D,"You fill a bottle with cow milk.");
					m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of cow milk.";
					from.PlaySound(0X240);
					from.AddToBackpack( new BottleCowMilk() );
				}
				else if (m_varjump.m_beast == 2 )
				{
					m_varjump.m_milking = m_varjump.m_milking -1;
					from.SendMessage (0x96D,"You fill a bottle with goat milk.");
					from.PlaySound(0X240);
					m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of goat milk.";
					from.AddToBackpack( new BottleGoatMilk() );
				}
				else if (m_varjump.m_beast == 1 )
				{
					m_varjump.m_milking = m_varjump.m_milking -1;
					from.SendMessage (0x96D,"You fill a bottle with sheep milk.");
					m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of sheep milk.";
					from.PlaySound(0X240);
					from.AddToBackpack( new BottleSheepMilk() );
				}
				else
				{
					from.SendMessage (0x84B,"This isn't a bottle or the milk bucket is empty.");
					from.CloseGump( typeof(MilkingHelpGump) );
					from.SendGump( new MilkingHelpGump( from ) );
				}

				if ( m_varjump.m_milking <= 0 )
				{
					m_varjump.m_beast = 0;
					m_varjump.Name = "Milk Bucket: (Empty)";
				}
			}
			else if ( ( o is BaseBeverage ) )
			{
				BaseBeverage p = (BaseBeverage)o;

				if  (( m_varjump.m_milking >= p.MaxQuantity ) && ( p.Quantity == 0 ) )
				{
					if (m_varjump.m_beast == 3)
					{
						p.Content = BeverageType.Milk;
						p.Quantity = p.MaxQuantity;
						m_varjump.m_milking = m_varjump.m_milking - p.MaxQuantity;
						from.SendMessage (0x96D,"You fill the container with cow milk.");
						m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of cow milk.";
						from.PlaySound(0X240);

					}
					else if (m_varjump.m_beast == 2 )
					{
						p.Content = BeverageType.Milk;
						p.Quantity = p.MaxQuantity;
						m_varjump.m_milking = m_varjump.m_milking - p.MaxQuantity;
						from.SendMessage (0x96D,"You fill the container with goat milk.");
						from.PlaySound(0X240);
						m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of goat milk.";
					}
					else if (m_varjump.m_beast == 1 )
					{
						p.Content = BeverageType.Milk;
						p.Quantity = p.MaxQuantity;
                        m_varjump.m_milking = m_varjump.m_milking - p.MaxQuantity;
						from.SendMessage (0x96D,"You fill the container with sheep milk.");
                        m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of sheep milk.";
						from.PlaySound(0X240);
					}
					else
					{
						from.SendMessage (0x84B,"This isn't a drink container, drink container has liquid in it already, or the milk bucket doesn't have enough milk left in it.");
						from.CloseGump( typeof(MilkingHelpGump) );
						from.SendGump( new MilkingHelpGump( from ) );
					}

				}

				if (m_varjump.m_milking <= 0 )
				{
                    m_varjump.m_milking = 0;
                    m_varjump.m_beast = 0;
                    m_varjump.Name = "Milk Bucket: (Empty)";
				}

			}
			else if (o is CheeseForm )
			{
				CheeseForm m_VarMold = (CheeseForm)o;

				if (m_varjump.m_milking >= 15 && m_VarMold.m_FullMold == false )
				{
                    m_varjump.m_milking = m_varjump.m_milking -15;

					if (m_varjump.m_beast == 1 )
					{
                        m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of sheep milk.";
                        m_VarMold.m_FromToDo = 1;
                        m_VarMold.Name="Cheese form: Sheep cheese";
                        m_VarMold.m_FullMold = true;
					}
					else if (m_varjump.m_beast == 2 )
					{
                        m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of goat milk.";
                        m_VarMold.m_FromToDo = 2;
                        m_VarMold.Name="Cheese form: Goat cheese";
                        m_VarMold.m_FullMold = true;
					}
					else if (m_varjump.m_beast == 3 )
					{
                        m_varjump.Name ="Milk Bucket: " + m_varjump.m_milking.ToString() + "/50 liters of cow milk.";
                        m_VarMold.m_FromToDo = 3;
                        m_VarMold.Name="Cheese form: Cow cheese";
                        m_VarMold.m_FullMold = true;
					}
					else
					{
						from.SendMessage(0x84C, "This milk bucket is bad." );
						from.CloseGump( typeof( CheeseFormHelpGump ) );
						from.SendGump( new CheeseFormHelpGump ( from ) );

					}

					if ( m_varjump.Milking <= 0 )
					{
                        m_varjump.m_beast = 0;
                        m_varjump.Name = "Milk Bucket: (Empty)";
					}
				}
				else
				{
					from.SendMessage(0x84C, "The milk bucket didn't contain enough milk." );
					from.CloseGump( typeof( CheeseFormHelpGump ) );
					from.SendGump( new CheeseFormHelpGump ( from ) );

				}
			}
			else
			{
				from.CloseGump( typeof(MilkingHelpGump) );
				from.SendGump( new MilkingHelpGump( from ) );
			}
		}
	}
}

