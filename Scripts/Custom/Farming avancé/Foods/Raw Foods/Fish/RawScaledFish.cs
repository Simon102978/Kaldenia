using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class RawScaledFish : Item, ICarvable
	{

        public virtual Item GetCarved { get { return new RawHeadlessFish(); } }
        public virtual int GetCarvedAmount { get { return 1; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawHeadlessFish();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
                from.AddToBackpack(new FishHeads(item.Amount));
                 from.SendMessage("You slice the sirloin into thin strips.");

            return true;
        }

        [Constructable]
		public RawScaledFish() : this( 1 )
		{
		}

		[Constructable]
        public RawScaledFish(int amount)
            : base(Utility.Random( 7701, 2))
		{
			this.Stackable = true;
			this.Weight = 0.8;
			this.Amount = amount;
		}

		public RawScaledFish( Serial serial ) : base( serial )
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
