namespace Server.Items
{
    public class Waffles : BaseFood
    {
        [Constructable]
        public Waffles() : this(1) { }
        [Constructable]
        public Waffles(int amount) : base(amount, 0x1E1F)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x1C7;
            FillFactor = 4;
            Name = "Waffles";
        }
        public Waffles(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
