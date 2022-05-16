using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CookedHeadlessFish : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new FishSteakExp(); } }
        public virtual int GetCarvedAmount { get { return 5; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new FishSteakExp();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
            from.SendMessage("You slice the sirloin into thin strips.");

            return true;
        }

        [Constructable]
		public CookedHeadlessFish() : this( 1 )
		{
		}

		[Constructable]
		public CookedHeadlessFish( int amount ) : base( Utility.Random( 7708, 2 ) )
		{
			Stackable = true;
			Weight = 0.4;
			Amount = amount;
			this.FillFactor = 12;
		}

		public CookedHeadlessFish( Serial serial ) : base( serial )
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
