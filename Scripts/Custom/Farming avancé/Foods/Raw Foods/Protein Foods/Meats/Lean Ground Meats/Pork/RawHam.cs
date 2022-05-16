using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawHam : BaseFood, ICarvable
	{
        public virtual Item GetCarved { get { return new RawHamSlices(); } }
        public virtual int GetCarvedAmount { get { return 5; } }
        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawHamSlices();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
            from.SendMessage("You slice the ham.");

            return true;
        }

        [Constructable]
		public RawHam() : this( 1 )
		{
		}

		[Constructable]
        public RawHam(int amount)
            : base(amount, 0x9C9)
		{
			Name = "raw ham";
			Stackable = true;
			Weight = 1.0;
			Hue = 41;
			Amount = amount;
            Raw = true;
		}

		public RawHam( Serial serial ) : base( serial )
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
