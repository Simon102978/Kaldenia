namespace Server.Items
{
	public class GoatRoast : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new GoatRoastSlices(); } }
        public virtual int GetCarvedAmount { get { return 5; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new GoatRoastSlices();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
                from.SendMessage("You slice the roast.");

            return true;
        }

        [Constructable]
		public GoatRoast() : this( 1 )
		{
		}

		[Constructable]
		public GoatRoast( int amount ) : base( amount, 0x9C9 )
		{
			Weight = 1.0;
			FillFactor = 5;
			Name = "goat roast";
			Hue = 1831;
            Stackable = true;
            Amount = amount;
		}

		public GoatRoast( Serial serial ) : base( serial )
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
