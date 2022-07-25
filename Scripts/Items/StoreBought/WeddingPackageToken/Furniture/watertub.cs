namespace Server.Items
{
	[Flipable(0x0E7B, 0x154D)]
	public class Watertub : Item, IWaterSource
	{
        
        [Constructable]
        public Watertub()
            : base(0x0E7B)
        {
            Weight = 15;
			Name = "Barril d'eau";
        }

       

        public Watertub(Serial serial)
            : base(serial)
        {
        }
		public int Quantity
		{
			get
			{
				return 500;
			}
			set
			{
			}
		}
		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
