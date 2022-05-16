namespace Server.Items
{
    public class Meatballs : BaseFood
    {
        [Constructable]
        public Meatballs() : this(1) { }
        [Constructable]
        public Meatballs(int amount) : base(amount, 0xE74)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x475;
            FillFactor = 4;
            Name = "Meatballs";
        }
        public Meatballs(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
