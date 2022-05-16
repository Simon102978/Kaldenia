namespace Server.Items
{
	public class Pizza : BaseFood
	{
		private string m_Desc;

		[CommandProperty( AccessLevel.Counselor )]    
        public string Desc 
        {
            get 
            { 
                return m_Desc; 
            }         
            set 
            {
				m_Desc = value;
				Name = "cooked " + m_Desc + " pizza";
				InvalidateProperties();
			}    
        }

		[Constructable]
		public Pizza() : this( "cheese", 0 )
		{
		}

		[Constructable]
		public Pizza( int color ) : this( "cheese", color )
		{
		}

		[Constructable]
		public Pizza( string desc ) : this( desc, 0 )
		{
		}

		[Constructable]
		public Pizza( string desc, int color ) : base( 0x1040 )
		{
			this.Weight = 1.0;
			this.FillFactor = 6;

			if ( desc != "" && desc != null )
			{
				Desc = desc;
			}
			else
			{
				Desc = "cheese";
			}

			Hue = color;
		}

		public Pizza( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (string) m_Desc );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				m_Desc = reader.ReadString();
				break;
			}
		}
	}

	public class CheesePizzaExp : BaseFood
	{
		public override int LabelNumber{ get{ return 1044516; } }

		[Constructable]
		public CheesePizzaExp() : base( 0x1040 )
		{
			this.Weight = 1.0;
			this.FillFactor = 6;
		}

		public CheesePizzaExp( Serial serial ) : base( serial )
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

	public class SausagePizzaExp : BaseFood
	{
		public override int LabelNumber{ get{ return 1044517; } }

		[Constructable]
		public SausagePizzaExp() : base( 0x1040 )
		{
			this.Weight = 1.0;
			this.FillFactor = 6;
		}

		public SausagePizzaExp( Serial serial ) : base( serial )
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
