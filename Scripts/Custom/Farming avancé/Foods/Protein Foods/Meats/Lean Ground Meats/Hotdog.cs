namespace Server.Items
{
    public class Hotdog : BaseFood
    {
        [Constructable]
        public Hotdog() : this(1) { }
        [Constructable]
        public Hotdog(int amount) : base(amount, 0xC7F)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x457;
            FillFactor = 3;
            Name = "Hotdog";
        }
        public Hotdog(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
