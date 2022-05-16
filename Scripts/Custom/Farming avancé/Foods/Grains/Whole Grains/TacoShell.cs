namespace Server.Items
{
    public class TacoShell : BaseFood
    {
        [Constructable]
        public TacoShell() : this(1) { }
        [Constructable]
        public TacoShell(int amount) : base(amount, 0x1370)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x465;
            FillFactor = 1;
            Name = "Taco Shell";
        }
        public TacoShell(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
