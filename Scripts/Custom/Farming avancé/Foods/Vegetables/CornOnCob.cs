namespace Server.Items
{
    [FlipableAttribute(0xC7F, 0xC81)]
    public class CornOnCob : BaseFood
    {
        [Constructable]
        public CornOnCob() : this(1) { }
        [Constructable]
        public CornOnCob(int amount) : base(amount, 0xC81)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x0;
            FillFactor = 3;
            Name = "Cooked Corn on the Cob";
        }
        public CornOnCob(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
