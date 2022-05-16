namespace Server.Items
{
	public class MuttonRoast : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new MuttonRoastSlices(); } }
        public virtual int GetCarvedAmount { get { return 5; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new MuttonRoastSlices();
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
		public MuttonRoast() : this( 1 )
		{
		}

		[Constructable]
		public MuttonRoast( int amount ) : base( amount, 0x9C9 )
		{
			this.Weight = 1.0;
			this.FillFactor = 5;
			Name = "mutton roast";
			Hue = 1831;
		}

		public MuttonRoast( Serial serial ) : base( serial )
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
