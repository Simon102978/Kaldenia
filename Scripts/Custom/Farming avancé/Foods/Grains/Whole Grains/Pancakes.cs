namespace Server.Items
{
    public class Pancakes : BaseFood
    {
        [Constructable]
        public Pancakes() : this(1) { }
        [Constructable]
        public Pancakes(int amount) : base(amount, 0x1E1F)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x15F;
            FillFactor = 5;
            Name = "Pancakes";
        }
        public Pancakes(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
