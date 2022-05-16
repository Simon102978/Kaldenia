using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public abstract class BaseCraftCider : Item, ICraftable
	{
		private Mobile m_Poisoner;
		private Poison m_Poison;
		private int m_FillFactor;
		private Mobile m_Crafter;
		private CiderQuality m_Quality;
		private HopsVariety m_Variety;

		public virtual Item EmptyItem{ get { return null; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Poisoner { get { return m_Poisoner; } set { m_Poisoner = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Poison Poison { get { return m_Poison; } set { m_Poison = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int FillFactor { get { return m_FillFactor; } set { m_FillFactor = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public HopsVariety Variety { get { return m_Variety; } set { if (m_Variety != value) { m_Variety = value; InvalidateProperties(); } } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Crafter { get { return m_Crafter; } set { m_Crafter = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public CiderQuality Quality { get { return m_Quality; } set { m_Quality = value; InvalidateProperties(); } }

        public BaseCraftCider( Serial serial ) : base( serial )
        {
        }

		private static void SetSaveFlag( ref SaveFlag flags, SaveFlag toSet, bool setIf )
		{
			if ( setIf ) flags |= toSet;
		}

		private static bool GetSaveFlag( SaveFlag flags, SaveFlag toGet )
		{
			return ( (flags & toGet) != 0 );
		}

		[Flags]
		private enum SaveFlag
		{
			None				= 0x00000000,
			Crafter				= 0x00000001,
			Quality				= 0x00000002,
			Variety				= 0x00000004
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			SaveFlag flags = SaveFlag.None;
			SetSaveFlag( ref flags, SaveFlag.Crafter, m_Crafter != null );
			SetSaveFlag( ref flags, SaveFlag.Quality, m_Quality != CiderQuality.Regular );
			SetSaveFlag( ref flags, SaveFlag.Variety,	 m_Variety != DefaultVariety );
			writer.WriteEncodedInt( (int) flags );
			if ( GetSaveFlag( flags, SaveFlag.Crafter ) ) writer.Write( (Mobile) m_Crafter );
			if ( GetSaveFlag( flags, SaveFlag.Quality ) ) writer.WriteEncodedInt( (int) m_Quality );
			if ( GetSaveFlag( flags, SaveFlag.Variety ) ) writer.WriteEncodedInt( (int) m_Variety );
			writer.Write( m_Poisoner );
			Poison.Serialize( m_Poison, writer );
			writer.Write( m_FillFactor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			SaveFlag flags = (SaveFlag)reader.ReadEncodedInt();
			if ( GetSaveFlag( flags, SaveFlag.Crafter ) ) m_Crafter = reader.ReadMobile();
			if ( GetSaveFlag( flags, SaveFlag.Quality ) ) m_Quality = (CiderQuality)reader.ReadEncodedInt();
			else m_Quality = CiderQuality.Regular;
			if ( m_Quality == CiderQuality.Low ) m_Quality = CiderQuality.Regular;
			if ( GetSaveFlag( flags, SaveFlag.Variety ) ) m_Variety = (HopsVariety)reader.ReadEncodedInt();
			else m_Variety = DefaultVariety;
			if ( m_Variety == HopsVariety.None ) m_Variety = DefaultVariety;
			m_Poisoner = reader.ReadMobile();
			m_Poison = Poison.Deserialize( reader );
			m_FillFactor = reader.ReadInt();
		}

		public virtual HopsVariety DefaultVariety{ get{ return HopsVariety.BitterHops; } }

		public BaseCraftCider( int itemID ) :  base( itemID )
		{
			m_Quality = CiderQuality.Regular;
			m_Crafter = null;
			m_Variety = DefaultVariety;
			FillFactor = 4;
		}

        public void Drink(Mobile from)
        {
            if (Thirsty(from, m_FillFactor))
            {
                from.PlaySound(Utility.Random(0x30, 2));
                if (from.Body.IsHuman && !from.Mounted)
                {
                    from.Animate(34, 5, 1, true, false, 0);
                }

                if (m_Poison != null)
                {
                    from.ApplyPoison(m_Poisoner, m_Poison);
                }

                int bac = 5;
                from.BAC += bac;

                if (from.BAC > 60)
                {
                    from.BAC = 60;
                }

                BaseBeverage.CheckHeaveTimer(from);
                Consume();
                Item item = EmptyItem;
                if (item != null)
                {
                    from.AddToBackpack(item);
                }
            }
        }

        static public bool Thirsty(Mobile from, int fillFactor)
        {
            int iThirst = from.Thirst + fillFactor;
            if (iThirst >= 20)
            {
                from.Thirst = 20;
                from.SendMessage(BrewMsgs.defualtfull);
            }
            else
            {
                from.Thirst = iThirst;
                if (iThirst < 5)
                {
                    from.SendMessage(BrewMsgs.extremely);
                }
                else if (iThirst < 10)
                {
                    from.SendMessage(BrewMsgs.satiated);
                }
                else if (iThirst < 15)
                {
                    from.SendMessage(BrewMsgs.less);
                }
                else
                {
                    from.SendMessage(BrewMsgs.full);
                }
            }
            return true;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!Movable)
            {
                return;
            }

            if (from.InRange(GetWorldLocation(), 1))
            {
                Drink(from);
            }
        }

        public override void AddNameProperty( ObjectPropertyList list )
		{
            if (Name == null)
            {
                if (m_Crafter != null)
                {
                    list.Add(m_Crafter.Name + " Brewery");
                }
                else
                {
                    list.Add("Keg of Cider");
                }
            }
            else
            {
                list.Add(Name);
            }
		}

		public override void AddNameProperties( ObjectPropertyList list )
 		{
 			base.AddNameProperties( list );
            if (m_Quality == CiderQuality.Exceptional)
            {
                list.Add("Reserve Dark Cider");
            }
            else
            {
                list.Add("Hard Cider");
            }
 		}

		public override void OnAosSingleClick( Mobile from )
		{
            if (Name == null)
            {
                if (m_Crafter != null)
                {
                    LabelTo(from, "{0} Brewery", m_Crafter.Name);
                }
                else
                {
                    LabelTo(from, "Hard Cider");
                }
            }
            else
            {
                LabelTo(from, "{0}", this.Name);
            }
            if (m_Quality == CiderQuality.Exceptional)
            {
                LabelTo(from, "Reserve Dark Cider");
            }
            else
            {
                LabelTo(from, "Hard Cider");
            }
		}

        #region ICraftable Members
        public virtual int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
        {
            Quality = (CiderQuality)quality;
			if ( Quality == CiderQuality.Exceptional ) Crafter = from;
			Item[] items = from.Backpack.FindItemsByType( typeof( BreweryLabelMaker ) );
			if ( items.Length != 0 )
			{
				foreach( BreweryLabelMaker lm in items )
				{
					if (lm.BreweryName != null)
					{
						Name = lm.BreweryName;
						break;
					}
				}
			}

			Type resourceType = typeRes;
			if ( resourceType == null ) resourceType = craftItem.Resources.GetAt( 0 ).ItemType;
			Variety = BrewingResources.GetFromType( resourceType );
			CraftContext context = craftSystem.GetContext( from );
			Hue = 0;
			return quality;
		}
		#endregion
	}
}
