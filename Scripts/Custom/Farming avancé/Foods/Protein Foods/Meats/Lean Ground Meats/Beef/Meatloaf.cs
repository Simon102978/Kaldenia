namespace Server.Items
{
    public class Meatloaf : BaseFood
    {
        [Constructable]
        public Meatloaf() : this(1) { }
        [Constructable]
        public Meatloaf(int amount) : base(amount, 0xE79)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x475;
            FillFactor = 5;
            Name = "Meatloaf";
        }
        public Meatloaf(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
