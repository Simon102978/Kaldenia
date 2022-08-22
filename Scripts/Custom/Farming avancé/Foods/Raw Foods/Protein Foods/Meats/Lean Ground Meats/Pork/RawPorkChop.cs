using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawPorkChop : BaseCookableFood, ICarvable
	{
        public virtual Item GetCarved { get { return new RawPorkSlice(); } }
        public virtual int GetCarvedAmount { get { return 5; } }
        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawPorkSlice();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
            from.SendMessage("You slice the pork chop into thin strips.");

            return true;
        }
		
		[Constructable]
		public RawPorkChop() : this( 1 )
		{
		}

		[Constructable]
        public RawPorkChop(int amount)
            : base(amount, 0x09F1)
		{
			Weight = 1.0;
			Stackable = true;
			Amount = amount;
			Name = "raw pork chop";
		}

		public RawPorkChop( Serial serial ) : base( serial )
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
		
		public override BaseFood Cook()
		{
			return new PorkChop();
		}
	}
}
