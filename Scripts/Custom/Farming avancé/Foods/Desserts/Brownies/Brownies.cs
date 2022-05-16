namespace Server.Items
{
    public class Brownies : BaseFood
    {
        [Constructable]
        public Brownies() : this(1) { }
        [Constructable]
        public Brownies(int amount)
            : base(amount, 0x160B)
        {
            Weight = 1.0;
            FillFactor = 2;
            Hue = 0x47D;
            Name = "Brownies";
        }
        public Brownies(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
