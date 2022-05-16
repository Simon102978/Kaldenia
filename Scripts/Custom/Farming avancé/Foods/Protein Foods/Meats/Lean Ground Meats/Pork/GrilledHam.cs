namespace Server.Items
{
    public class GrilledHam : BaseFood
    {
        [Constructable]
        public GrilledHam() : this(1) { }
        [Constructable]
        public GrilledHam(int amount) : base(amount, 0x1E1F)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x33D;
            FillFactor = 4;
            Name = "Grilled Ham";
        }
        public GrilledHam(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
