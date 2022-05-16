using System;
using System.Collections;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class RawBaconSlab : BaseFood, ICarvable
    {
        public virtual Item GetCarved { get { return new RawBacon(); } }
        public virtual int GetCarvedAmount { get { return 5; } }

        [Constructable]
		public RawBaconSlab() : this( 1 )
		{
		}

		[Constructable]
        public RawBaconSlab(int amount)
            : base(amount, 0x976)
		{
			Name = "raw slab of bacon";
			Stackable = true;
            Amount = amount;
            Weight = 1.0;
            Raw = true;
			//Hue = 41;
		}

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawBacon();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);

            return true;
        }

        public RawBaconSlab( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
