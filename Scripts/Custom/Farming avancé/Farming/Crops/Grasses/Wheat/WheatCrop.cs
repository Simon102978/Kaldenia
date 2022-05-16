using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;

namespace Server.Items.Crops
{
	public class WheatCrop : BaseCrop
	{
		private const int max = 2;
		private int fullGraphic;
		private int pickedGraphic;
		private DateTime lastpicked;
		private Mobile m_sower;
		private int m_yield;
		public Timer regrowTimer;
		private DateTime m_lastvisit;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime LastSowerVisit
        { 
            get
            {
                return m_lastvisit;
            }
        }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Growing
        {
            get
            {
                return regrowTimer.Running;
            }
        }

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Sower
        {
            get
            {
                return m_sower;
            }
            set
            {
                m_sower = value;
            }
        }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Yield
        {
            get
            {
                return m_yield;
            }
            set
            {
                m_yield = value;
            }
        }

		public int Capacity
        {
            get
            {
                return max;
            }
        }

		public int FullGraphic{ get{ return fullGraphic; } set{ fullGraphic = value; } }
		public int PickGraphic{ get{ return pickedGraphic; } set{ pickedGraphic = value; } }
		public DateTime LastPick{ get{ return lastpicked; } set{ lastpicked = value; } }

		[Constructable]
		public WheatCrop() : this(null)
        {
        }

		[Constructable]
		public WheatCrop( Mobile sower ) : base( Utility.RandomList ( 0xC58, 0xC5A, 0xC5B ) )
		{
            Name = "Wheat Plant";
			Movable = false;
			Hue = 0x000;
			m_sower = sower;
			m_lastvisit = DateTime.UtcNow;
			init( this, false );
		}

		public static void init ( WheatCrop plant, bool full )
		{
			plant.PickGraphic = ( Utility.RandomList ( 0xC55, 0xC56, 0xC57, 0xC59 ) );
			plant.FullGraphic = ( Utility.RandomList ( 0xC58, 0xC5A, 0xC5B ) );
			plant.LastPick = DateTime.UtcNow;
			plant.regrowTimer = new CropTimer( plant );
			if ( full )
            {
                plant.Yield = plant.Capacity;
                ((Item)plant).ItemID = plant.FullGraphic;
            }
			else
            {
                plant.Yield = 0;
                ((Item)plant).ItemID = plant.PickGraphic;
                plant.regrowTimer.Start();
            }
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_sower == null || m_sower.Deleted ) m_sower = from;

			if ( from != m_sower )
            { 
                from.SendMessage( "You do not own this plant !!!" ); 
                return; 
            }
			if ( from.Mounted && !CropHelper.CanWorkMounted ) 
            { 
                from.SendMessage( "You cannot harvest a crop while mounted." );
                return;
            }
			if ( DateTime.UtcNow > lastpicked.AddSeconds(3) )
			{
				lastpicked = DateTime.UtcNow;
				int cookValue = (int)from.Skills[SkillName.Cooking].Value / 20;
				if ( cookValue == 0 )
                {
                    from.SendMessage( "You have no idea how to harvest this crop." );
                    return; 
                }
				if ( from.InRange( this.GetWorldLocation(), 1 ) )
				{
					if ( m_yield < 1 ) 
                    { 
                        from.SendMessage( "There is nothing here to harvest." );
                    }
					else
					{
						from.Direction = from.GetDirectionTo( this );
						from.Animate( from.Mounted ? 29:32, 5, 1, true, false, 0 );
						m_lastvisit = DateTime.UtcNow;
						
                        if ( cookValue > m_yield ) cookValue = m_yield + 1;
						
                        int pick = Utility.RandomMinMax( cookValue - 4, cookValue );
						
                        if (pick < 0 ) pick = 0;
						
                        if ( pick == 0 ) 
                        { 
                            from.SendMessage( "You do not manage to harvest any crops." ); return; 
                        }
						
                        m_yield -= pick;
                        from.SendMessage( "You harvest {0} crop{1}!", pick, ( pick == 1 ? "" : "s" ) );
						
                        if (m_yield < 1) ((Item)this).ItemID = pickedGraphic;
						
                        Wheat crop = new Wheat( pick );
                        from.AddToBackpack( crop );

						if ( !regrowTimer.Running ) 
                        { 
                            regrowTimer.Start(); 
                        }
					}
				}
				else
                {
                    from.SendMessage( "You are too far away to harvest anything." );
                }
			}
		}

		private class CropTimer : Timer
		{
			private WheatCrop i_plant;
			public CropTimer( WheatCrop plant ) : base( TimeSpan.FromSeconds( 450 ), TimeSpan.FromSeconds( 15 ) )
			{
				Priority = TimerPriority.OneSecond;
				i_plant = plant;
			}
			protected override void OnTick()
			{
				if ( Utility.RandomBool() )
				{
					if ( ( i_plant != null ) && ( !i_plant.Deleted ) )
					{
						int current = i_plant.Yield;
						if ( ++current >= i_plant.Capacity )
						{
							current = i_plant.Capacity;
							((Item)i_plant).ItemID = i_plant.FullGraphic;
							Stop();
						}
						else if ( current <= 0 ) current = 1;
						i_plant.Yield = current;
					}
					else 
                        Stop();
				}
			}
		}

		public override void OnChop( Mobile from )
		{
			if ( !this.Deleted ) Chop( from );
		}

		public void Chop( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				if ( from == m_sower )
				{
					from.Direction = from.GetDirectionTo( this );
					double lumberValue = from.Skills[SkillName.Lumberjacking].Value / 100;
					if ( ( lumberValue > .5 ) && ( Utility.RandomDouble() <= lumberValue ) )
					{
						Wheat fruit = new Wheat( Utility.Random( m_yield +1 ) );
						from.AddToBackpack( fruit );
					}
						this.Delete();
						from.SendMessage( "You chop the plant up" );
				}
				else 
                    from.SendMessage( "You do not own this plant !!!" );
			}
			else 
                from.SendLocalizedMessage( 500446 );
		}

		public WheatCrop( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( m_lastvisit );
			writer.Write( m_sower );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_lastvisit = reader.ReadDateTime();
			m_sower = reader.ReadMobile();
			init( this, true );
		}
	}
}