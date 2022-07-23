using System;
using Server.Targeting;
using Server.Engines.Craft;

namespace Server.Items
{
    public abstract class BaseCookableFood : Item, IQuality, ICommodity
    {
        private ItemQuality _Quality;
        private int m_CookingLevel;

		[CommandProperty( AccessLevel.GameMaster )]
		public int CookingLevel { get { return m_CookingLevel; } set { m_CookingLevel = value; } }

		public BaseCookableFood( int itemID, int cookingLevel ) : base( itemID ) { m_CookingLevel = cookingLevel; }

        public bool PlayerConstructed { get { return true; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public ItemQuality Quality { get { return _Quality; } set { _Quality = value; InvalidateProperties(); } }

        public BaseCookableFood( Serial serial ) : base( serial ) { }

        TextDefinition ICommodity.Description { get { return LabelNumber; } }
        bool ICommodity.IsDeedable { get { return true; } }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (_Quality == ItemQuality.Exceptional)
            {
                list.Add(1060636); // Exceptional
            }
        }

        public virtual int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
        {
            Quality = (ItemQuality)quality;

            return quality;
        }

        public abstract BaseFood Cook();

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write((int)2); // version

            writer.Write((int)_Quality);

            // Version 1
            writer.Write((int)m_CookingLevel);
        }

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            switch (version)
            {
                case 2:
                    {
                        _Quality = (ItemQuality)reader.ReadInt();
                        goto case 1;
                    }
                case 1:
                    {
                        m_CookingLevel = reader.ReadInt();
                        break;
                    }
            }
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !this.Movable ) return;
			from.Target = new InternalTarget( this );
		}

		public static bool IsHeatSource( object targeted )
		{
			int itemID;
			if ( targeted is Item ) itemID = ((Item)targeted).ItemID & 0x3FFF;
			else if ( targeted is StaticTarget ) itemID = ((StaticTarget)targeted).ItemID & 0x3FFF;
			else return false;
			if ( itemID >= 0xDE3 && itemID <= 0xDE9 ) return true;
			else if ( itemID >= 0x461 && itemID <= 0x48E ) return true;
			else if ( itemID >= 0x92B && itemID <= 0x96C ) return true;
			else if ( itemID == 0xFAC ) return true;
			else if ( itemID == 11739 ) return true;
			else if ( itemID == 11740 ) return true;
			else if (itemID == 0x29FD) return true;
			else if ( itemID >= 0x184A && itemID <= 0x184C ) return true;
			else if ( itemID >= 0x184E && itemID <= 0x1850 ) return true;
			else if ( itemID >= 0x398C && itemID <= 0x399F ) return true;
			
			return false;
		}

		private class InternalTarget : Target
		{
			private BaseCookableFood m_Item;
			public InternalTarget( BaseCookableFood item ) : base( 1, false, TargetFlags.None )
			{
				m_Item = item;
			}
			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Item.Deleted ) return;
				if ( BaseCookableFood.IsHeatSource( targeted ) )
				{
					if ( from.BeginAction( typeof( BaseCookableFood ) ) )
					{
						from.PlaySound( 0x225 );
						m_Item.Consume();
						InternalTimer t = new InternalTimer( from, targeted as IPoint3D, from.Map, m_Item );
						t.Start();
					}
					else from.SendLocalizedMessage( 500119 );
				}
			}

			private class InternalTimer : Timer
			{
				private Mobile m_From;
				private IPoint3D m_Point;
				private Map m_Map;
				private BaseCookableFood m_CookableFood;

				public InternalTimer( Mobile from, IPoint3D p, Map map, BaseCookableFood cookableFood ) : base( TimeSpan.FromSeconds( 5.0 ) )
				{
					m_From = from;
					m_Point = p;
					m_Map = map;
					m_CookableFood = cookableFood;
				}

				protected override void OnTick()
				{
					m_From.EndAction( typeof( BaseCookableFood ) );
					if ( m_From.Map != m_Map || (m_Point != null && m_From.GetDistanceToSqrt( m_Point ) > 3) )
					{
						m_From.SendLocalizedMessage( 500686 );
						return;
					}
					if ( m_From.CheckSkill( SkillName.Cooking, m_CookableFood.CookingLevel, 100 ) )
					{
						BaseFood cookedFood = m_CookableFood.Cook();
						if ( m_From.AddToBackpack( cookedFood ) ) m_From.PlaySound( 0x57 );
					}
					else m_From.SendLocalizedMessage( 500686 );
				}
			}
		}
	}
}
