namespace Server.Items
{
    public class RiceKrispTreat : BaseFood
    {
        [Constructable]
        public RiceKrispTreat() : this(1) { }
        [Constructable]
        public RiceKrispTreat(int amount)
            : base(amount, 0x1044)
        {
            Weight = 1.0;
            FillFactor = 2;
            Hue = 0x9B;
            Name = "Rice Krisp Treat";
        }
        public RiceKrispTreat(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
