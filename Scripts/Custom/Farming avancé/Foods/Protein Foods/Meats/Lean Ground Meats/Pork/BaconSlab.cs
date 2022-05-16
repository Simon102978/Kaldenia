namespace Server.Items
{
	public class BaconSlab : BaseFood, ICarvable
	{
		[Constructable]
		public BaconSlab() : this( 1 )
		{
		}

		[Constructable]
		public BaconSlab( int amount ) : base( amount, 0x976 )
		{
			Weight = 1.0;
			FillFactor = 3;
            Stackable = true;
            Amount = amount;
		}

        public bool Carve(Mobile from, Item item)
        {
            var baconslice = new BaconExp();

            if (HasSocket<Caddellite>())
            {
                baconslice.AttachSocket(new Caddellite());
            }

            base.ScissorHelper(from, baconslice, 4);

            from.SendMessage("You cut the slab into slices.");

            return true;
        }

        public BaconSlab( Serial serial ) : base( serial )
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
