namespace Server.Items
{
	public class HamExp : BaseFood, ICarvable
	{
		[Constructable]
		public HamExp() : this( 1 )
		{
		}

		[Constructable]
		public HamExp( int amount ) : base( amount, 0x9C9 )
		{
			Weight = 1.0;
			FillFactor = 5;
            Stackable = true;
            Amount = amount;
		}

        public bool Carve(Mobile from, Item item)
        {
            var Slice = new HamSlices();

            if (HasSocket<Caddellite>())
            {
                Slice.AttachSocket(new Caddellite());
            }

            base.ScissorHelper(from, Slice, 4);

            from.SendMessage("You slice the ham.");

            return true;
        }

        public HamExp( Serial serial ) : base( serial )
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
