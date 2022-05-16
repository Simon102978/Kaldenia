using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class RawBeefRibeye : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new RawBeefSlice(); } }
        public virtual int GetCarvedAmount { get { return 5; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawBeefSlice();
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
		public RawBeefRibeye() : this( 1 )
		{
		}

		[Constructable]
        public RawBeefRibeye(int amount)
            : base(amount, 0x9F1)
		{
			Weight = 1.0;
			Name = "raw beef ribeye";
			Stackable = true;
			Amount = amount;
            Raw = true;
		}

		public RawBeefRibeye( Serial serial ) : base( serial )
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
