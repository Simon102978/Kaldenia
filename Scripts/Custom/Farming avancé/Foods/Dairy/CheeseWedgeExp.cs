namespace Server.Items
{
	public class CheeseWedgeExp : BaseFood, ICarvable
    {

        public virtual Item GetCarved { get { return new CheeseWedgeSmall(); } }
        public virtual int GetCarvedAmount { get { return 3; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new CheeseWedgeSmall();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
            {
                    base.ScissorHelper(from, newItem, GetCarvedAmount);
                    from.SendMessage("You cut the wheel into 3 wedges.");
               
            }

            return true;
        }
        [Constructable]
		public CheeseWedgeExp() : this( 1 ) { }
		[Constructable]
		public CheeseWedgeExp( int amount ) : base( amount, 0x97D )
		{
			this.Weight = 0.3;
			this.FillFactor = 9;
		}
		public CheeseWedgeExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
}
