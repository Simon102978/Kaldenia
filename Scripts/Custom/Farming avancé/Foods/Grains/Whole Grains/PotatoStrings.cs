namespace Server.Items
{
    public class PotatoStrings : BaseFood
    {
        [Constructable]
        public PotatoStrings() : this(1) { }
        [Constructable]
        public PotatoStrings(int amount) : base(amount, 0x1B8D)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x225;
            FillFactor = 3;
            Name = "Potato Strings";
        }
        public PotatoStrings(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
