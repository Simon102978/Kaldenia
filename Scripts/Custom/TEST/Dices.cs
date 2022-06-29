using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class Dices : Item
	{
		[Constructable]
		public Dices() : base( 0xFA7 )
		{
            Name = "2 des %%%#$%?%$#@! jouer 6 faces";
			Weight = 1.0;
		}

		public Dices( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this.GetWorldLocation(), 2 ) )
				return;

			this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}*", from.Name, Utility.Random( 1, 6 ), Utility.Random( 1, 6 ) ) );
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

            Name = "2 des a jouer 6 faces";
		}
	}
	public class ElevenFaceDice : Item
	{
		[Constructable]
		public ElevenFaceDice() : base( 0xFA7 )
		{
            Name = "des a jouer 11 faces";
			Weight = 1.0;
		}

		public ElevenFaceDice( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this.GetWorldLocation(), 2 ) )
				return;

			this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}*", from.Name, Utility.Random( 1, 11 ) ) );
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

            Name = "1 de a jouer 11 faces";
		}
	}
	public class RandomDice : Item
	{
		private int m_AMinNumber;
		private int m_BMaxNumber;
		private int m_NbreDices;
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int AMinNumber
        {
            get { return m_AMinNumber; }
            set { m_AMinNumber = value; }
        }
		[CommandProperty(AccessLevel.GameMaster)]
        public int BMaxNumber
        {
            get { return m_BMaxNumber; }
            set { m_BMaxNumber = value; }
        }
		[CommandProperty(AccessLevel.GameMaster)]
        public int NbreDices
        {
            get { return m_NbreDices; }
            set 
			{ 
				m_NbreDices = value; 
				
				if (m_NbreDices <= 1)
				m_NbreDices = 1;
			
				if (m_NbreDices >= 7)
				m_NbreDices = 7;	
			}
        }
		[Constructable]
		public RandomDice() : base( 0xFA7 )
		{
            Name = "Des a jouer";
			Weight = 1.0;
		}

		public RandomDice( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			int minNumber = (int)m_AMinNumber;
			int maxNumber = (int)m_BMaxNumber;
			int NbreDices = (int)m_NbreDices;
			
			if ( !from.InRange( this.GetWorldLocation(), 2 ) )
				return;
			
			if (NbreDices == 1)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
			
			else if (NbreDices == 2)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
			
			else if (NbreDices == 3)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}, {3}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
				
			else if (NbreDices == 4)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}, {3}, {4}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
				
			else if (NbreDices == 5)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}, {3}, {4}, {5}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
				
			else if (NbreDices == 6)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}, {3}, {4}, {5}, {6}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
				
			else if (NbreDices == 7)	
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format( "*{0} joue {1}, {2}, {3}, {4}, {5}, {6}, {7}*", from.Name, Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ), Utility.Random( minNumber, (maxNumber-minNumber)+1 ) ) );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( m_AMinNumber );
			writer.Write( m_BMaxNumber );
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();

			m_AMinNumber = reader.ReadInt();
            m_BMaxNumber = reader.ReadInt();
			m_NbreDices = reader.ReadInt();
			
            Name = "Des a jouer";
		}
	}
}