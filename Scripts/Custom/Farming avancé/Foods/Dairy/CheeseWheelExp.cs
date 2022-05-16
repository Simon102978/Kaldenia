namespace Server.Items
{
	public class CheeseWheelExp : BaseFood, ICarvable
	{

        public virtual Item GetCarved { get { return new CheeseWedgeExp(); } }
        public virtual int GetCarvedAmount { get { return 3; } }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new CheeseWedgeExp();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
            {
                if (this.Amount > 1)
                {
                    from.SendMessage("You can only cut up one wheel at a time.");
                    return true;
                }
                else
                {
                    base.ScissorHelper(from, newItem, GetCarvedAmount);
                    from.AddToBackpack(new CheeseWedgeSmall());
                    from.SendMessage("You cut a wedge out of the wheel.");
                }
            }

            return true;
        }
        [Constructable]
		public CheeseWheelExp() : this( 1 ) { }
		[Constructable]
		public CheeseWheelExp( int amount ) : base( amount, 0x97E )
		{
			this.Weight = 0.4;
			this.FillFactor = 12;
		}
		public CheeseWheelExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
}
