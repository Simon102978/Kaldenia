﻿using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items.Crops
{
	public class GinsengPlant : BaseCrop 
	{ 
		private double mageValue;
		private DateTime lastpicked;

		[Constructable] 
		public GinsengPlant() : base( Utility.RandomList( 0x18E9, 0x18EA ) ) 
		{ 
			Movable = false; 
			Name = "A Ginseng Plant"; 
			lastpicked = DateTime.UtcNow;
		} 

		public override void OnDoubleClick(Mobile from) 
		{ 
			if ( from == null || !from.Alive ) return;

			// lumbervalue = 100; will give 100% sucsess in picking
			mageValue = from.Skills[SkillName.Magery].Value + 20; 

			if ( DateTime.UtcNow > lastpicked.AddSeconds(3) ) // 3 seconds between picking
			{
				lastpicked = DateTime.UtcNow;
				if ( from.InRange( this.GetWorldLocation(), 1 ) ) 
				{ 
					if ( mageValue > Utility.Random( 100 ) )
					{
						from.Direction = from.GetDirectionTo( this );
						from.Animate( 32, 5, 1, true, false, 0 ); // Bow

						from.SendMessage("You pull the plant up by the root."); 
						this.Delete(); 

						from.AddToBackpack( new GinsengUprooted() );
					}
					else from.SendMessage("The plant is hard to pull up."); 
				} 
				else 
				{ 
					from.SendMessage( "Vous êtes trop loin pour récolter quelque chose." ); 
				} 
			}
		} 

		public GinsengPlant( Serial serial ) : base( serial ) 
		{ 
			lastpicked = DateTime.UtcNow;
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
	
	[FlipableAttribute( 0x18E7, 0x18E8 )]
	public class GinsengUprooted : Item, ICarvable
	{

        public virtual Item GetCarved { get { return new Ginseng(); } }
        public virtual int GetCarvedAmount { get { return Utility.Random(4); } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
            {
                return false;
            }

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new Ginseng();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            int count = Utility.Random(4);
            if (newItem != null)
            {
                if (count == 0)
                {
                    from.SendMessage("You find no useable sprigs.");
                    this.Consume();
                }
                else
                {
                    base.ScissorHelper(from, newItem, GetCarvedAmount);
                    from.SendMessage("You cut {0} sprig{1}.", count, (count == 1 ? "" : "s"));
                }
            }

            return true;
        }

		[Constructable]
		public GinsengUprooted() : this( 1 )
		{
		}

		[Constructable]
		public GinsengUprooted( int amount ) : base( Utility.RandomList( 0x18EB, 0x18EC ) )
		{
			Stackable = false;
			Weight = 1.0;
			
			Movable = true; 
			Amount = amount;

			Name = "Uprooted Ginseng Plant";
		}
		public GinsengUprooted( Serial serial ) : base( serial )
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
