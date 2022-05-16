using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class RawVenisonSteak : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new RawVenisonSlice(); } }
        public virtual int GetCarvedAmount { get { return 5; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawVenisonSlice();
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
		public RawVenisonSteak() : this( 1 )
		{
		}

		[Constructable]
        public RawVenisonSteak(int amount)
            : base(amount, 0x9F1)
		{
			Weight = 1.0;
			Stackable = true;
			Amount = amount;
			Name = "raw venison steak";
            Raw = true;
		}

		public RawVenisonSteak( Serial serial ) : base( serial )
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
