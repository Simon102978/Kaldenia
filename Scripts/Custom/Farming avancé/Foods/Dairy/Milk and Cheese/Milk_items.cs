using System;

namespace Server.Items
{
	public abstract class MilkBottle : Item
	{
		private Mobile m_Poisoner;
		private Poison m_Poison;
		private int m_FillFactor;

		public virtual Item EmptyItem{ get { return null; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Poisoner
		{
			get { return m_Poisoner; }
			set { m_Poisoner = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Poison Poison
		{
			get { return m_Poison; }
			set { m_Poison = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int FillFactor
		{
			get { return m_FillFactor; }
			set { m_FillFactor = value; }
		}

		public MilkBottle( int itemID ) : base( itemID )
		{
			FillFactor = 4;
		}

		public MilkBottle( Serial serial ) : base( serial ) { }

		public void ToDrink( Mobile from )
		{
			if (Thirst( from, m_FillFactor ) )
			{
				from.PlaySound( Utility.Random( 0x30, 2 ) );

				if ( from.Body.IsHuman && !from.Mounted )
					from.Animate( 34, 5, 1, true, false, 0 );

				if ( m_Poison != null )
					from.ApplyPoison( m_Poisoner, m_Poison );

				this.Consume();

				Item item = EmptyItem;

				if ( item != null )
					from.AddToBackpack( item );
			}
		}

		static public bool Thirst( Mobile from, int fillFactor )
		{
			if ( from.Thirst >= 20 )
			{
				from.SendMessage( "You are simply too full to drink any more!" );
				return false;
			}

			int iThirst = from.Thirst + fillFactor;
			if ( iThirst >= 20 )
			{
				from.Thirst = 20;
				from.SendMessage( "You manage to drink the beverage, but you are full!" );
			}
			else
			{
				from.Thirst = iThirst;

				if ( iThirst < 5 )
					from.SendMessage( "You drink the beverage, but are still extremely thirsty." );
				else if ( iThirst < 10 )
					from.SendMessage( "You drink the beverage, and begin to feel more satiated." );
				else if ( iThirst < 15 )
					from.SendMessage( "After drinking the beverage, you feel much less thirsty." );
				else
					from.SendMessage( "You feel quite full after consuming the beverage." );
			}

			return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			if ( from.InRange( this.GetWorldLocation(), 1 ) )
                ToDrink( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( m_Poisoner );

			Poison.Serialize( m_Poison, writer );
			writer.Write( m_FillFactor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Poisoner = reader.ReadMobile();

					goto case 0;
				}
				case 0:
				{
					m_Poison = Poison.Deserialize( reader );
					m_FillFactor = reader.ReadInt();
					break;
				}
			}
		}
	}
	public class BottleCowMilk : MilkBottle
	{
		public override Item EmptyItem{ get { return new Bottle(); } }

		[Constructable]
		public BottleCowMilk() : base( 0x0f09 )
		{
			Weight = 0.2;
		    FillFactor = 4;
			Name ="bottle of cow milk";
		}

		public BottleCowMilk( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
	public class BottleGoatMilk : MilkBottle
	{
		public override Item EmptyItem{ get { return new Bottle(); } }

		[Constructable]
		public BottleGoatMilk() : base( 0x0f09 )
		{
			Weight = 0.2;
			FillFactor = 4;
			Name ="bottle of goat milk";
		}

		public BottleGoatMilk( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
	public class BottleSheepMilk : MilkBottle
	{
		public override Item EmptyItem{ get { return new Bottle(); } }

		[Constructable]
		public BottleSheepMilk() : base( 0x0f09 )
		{
			Weight = 0.2;
			FillFactor = 4;
			Name ="bottle of sheep milk";
		}

		public BottleSheepMilk( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class CowCheese : BaseFood, ICarvable
	{
        public virtual Item GetCarved { get { return new CowCheeseWedge(); } }
        public virtual int GetCarvedAmount { get { return 1; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new CowCheeseWedge();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
            from.AddToBackpack(new CowCheeseWedgeSmall());
            from.SendMessage("You cut a wedge out of the wheel.");

            return true;
        }

		[Constructable]
		public CowCheese() : this( 1 ){}

		[Constructable]
		public CowCheese( int amount ) : base( amount, 0x97E )
		{
			Weight = 0.4;
			FillFactor = 12;
			Name = "cow cheese";
			Hue = 0x481;
		}

		public CowCheese( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class CowCheeseWedge : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new CowCheeseWedgeSmall(); } }
        public virtual int GetCarvedAmount { get { return 3; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new CowCheeseWedgeSmall();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
            from.SendMessage("You cut the wheel into 3 wedges.");

            return true;
        }

        [Constructable]
		public CowCheeseWedge() : this( 1 ){}

		[Constructable]
		public CowCheeseWedge( int amount ) : base( amount, 0x97D )
		{
		    Weight = 0.3;
			FillFactor = 9;
			Name = "cow cheese wedge";
			Hue = 0x481;
		}

		public CowCheeseWedge( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class CowCheeseWedgeSmall : BaseFood
	{
		[Constructable]
		public CowCheeseWedgeSmall() : this( 1 ){}

		[Constructable]
		public CowCheeseWedgeSmall( int amount ) : base( amount, 0x97C )
		{
			Weight = 0.1;
			FillFactor = 3;
			Name = "small cow cheese wedge";
			Hue = 0x481;
		}

		public CowCheeseWedgeSmall( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class SheepCheese : BaseFood, ICarvable
	{
        public virtual Item GetCarved { get { return new SheepCheeseWedge(); } }
        public virtual int GetCarvedAmount { get { return 1; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new SheepCheeseWedge();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
            {
                if (this.Amount > 1)
                {
                    from.SendMessage("You can only cut up one wheel at a time.");
                    return true;
                }
                else
                {
                    base.ScissorHelper(from, newItem, GetCarvedAmount);
                    from.AddToBackpack(new SheepCheeseWedgeSmall());

                    from.SendMessage("You cut a wedge out of the wheel.");
                }
            }

            return true;
        }

		[Constructable]
		public SheepCheese() : this( 1 ){}

		[Constructable]
		public SheepCheese( int amount ) : base( amount, 0x97E )
		{
			Weight = 0.4;
			FillFactor = 12;
			Name = "sheep cheese";
			Hue = 0x481;
		}

		public SheepCheese( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class SheepCheeseWedge : BaseFood, ICarvable
	{
        public virtual Item GetCarved { get { return new SheepCheeseWedgeSmall(); } }
        public virtual int GetCarvedAmount { get { return 3; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new SheepCheeseWedgeSmall();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                  base.ScissorHelper(from, newItem, GetCarvedAmount);
                  from.SendMessage("You cut the wheel into 3 wedges.");

            return true;
        }

		[Constructable]
		public SheepCheeseWedge() : this( 1 ){}

		[Constructable]
		public SheepCheeseWedge( int amount ) : base( amount, 0x97D )
		{
			Weight = 0.3;
			FillFactor = 9;
			Name = "sheep cheese wedge";
			Hue = 0x481;
		}

		public SheepCheeseWedge( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class SheepCheeseWedgeSmall : BaseFood
	{
		[Constructable]
		public SheepCheeseWedgeSmall() : this( 1 ){}

		[Constructable]
		public SheepCheeseWedgeSmall( int amount ) : base( amount, 0x97C )
		{
			Weight = 0.1;
			FillFactor = 3;
			Name = "small sheep cheese wedge";
			Hue = 0x481;
		}

		public SheepCheeseWedgeSmall( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class GoatCheese : BaseFood, ICarvable
	{
        public virtual Item GetCarved { get { return new GoatCheeseWedge(); } }
        public virtual int GetCarvedAmount { get { return 1; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new GoatCheeseWedge();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
            {
                if (this.Amount > 1)
                {
                    from.SendMessage("You can only cut up one wheel at a time.");
                    return true;
                }
                else
                {
                    base.ScissorHelper(from, newItem, GetCarvedAmount);
                    from.AddToBackpack(new GoatCheeseWedgeSmall());
                    from.SendMessage("You cut a wedge out of the wheel.");
                }
            }

            return true;
        }

		[Constructable]
		public GoatCheese() : this( 1 ){}

		[Constructable]
		public GoatCheese( int amount ) : base( amount, 0x97E )
		{
			Weight = 0.4;
			FillFactor = 12;
			Name = "goat cheese";
			Hue = 0x481;
		}

		public GoatCheese( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class GoatCheeseWedge : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new GoatCheeseWedgeSmall(); } }
        public virtual int GetCarvedAmount { get { return 3; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new GoatCheeseWedgeSmall();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
            {
                    base.ScissorHelper(from, newItem, GetCarvedAmount);
                from.SendMessage("You cut the wheel into 3 wedges.");
            }

            return true;
        }

		[Constructable]
        public GoatCheeseWedge() : this( 1 ){}

		[Constructable]
		public GoatCheeseWedge( int amount ) : base( amount, 0x97D )
		{
			Weight = 0.3;
		    FillFactor = 9;
			Name = "goat cheese wedge";
			Hue = 0x481;
		}

		public GoatCheeseWedge( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class GoatCheeseWedgeSmall : BaseFood
	{
		[Constructable]
		public GoatCheeseWedgeSmall() : this( 1 ){}

		[Constructable]
		public GoatCheeseWedgeSmall( int amount ) : base( amount, 0x97C )
		{
			Weight = 0.1;
			FillFactor = 3;
			Name = "small goat cheese wedge";
			Hue = 0x481;
		}

		public GoatCheeseWedgeSmall( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

}
