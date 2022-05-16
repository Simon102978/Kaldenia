namespace Server.Items
{
    public class Hotwings : BaseFood
    {
        [Constructable]
        public Hotwings() : this(1) { }
        [Constructable]
        public Hotwings(int amount) : base(amount, 0x1608)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x21A;
            FillFactor = 3;
            Name = "Hotwings";
        }
        public Hotwings(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
