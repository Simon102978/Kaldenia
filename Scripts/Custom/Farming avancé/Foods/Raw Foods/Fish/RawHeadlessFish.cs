using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class RawHeadlessFish : BaseFood, ICarvable
	{
        public virtual Item GetCarved { get { return new RawFishSteak(); } }
        public virtual int GetCarvedAmount { get { return 4; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawFishSteak();
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
		public RawHeadlessFish() : this( 1 )
		{
		}

        [Constructable]
        public RawHeadlessFish(int amount)
            : base(Utility.Random( 7703, 2), 20)
        {
            this.Stackable = true;
            this.Weight = 0.6;
            this.Amount = amount;
            this.Raw = true;
        }

		public RawHeadlessFish( Serial serial ) : base( serial )
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
