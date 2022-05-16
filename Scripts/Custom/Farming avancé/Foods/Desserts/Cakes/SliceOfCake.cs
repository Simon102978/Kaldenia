namespace Server.Items
{
    [FlipableAttribute(0x3BC5, 0x3BC4)]
    public class SliceOfCake : BaseFood
    {
        [Constructable]
        public SliceOfCake() : this(1) { }

        [Constructable]
        public SliceOfCake(int amount)
            : base(amount, 0x3BC5)
        {
            Name = "Slice of Cake";
            Weight = 1.0;
            FillFactor = 1;
        }

        public SliceOfCake(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
