namespace Server.Items
{
    public class SliceOfWeddingCake : BaseFood
    {
        [Constructable]
        public SliceOfWeddingCake() : this(1) { }

        [Constructable]
        public SliceOfWeddingCake(int amount)
            : base(amount, 0x3BCB)
        {
            Name = "Slice of Wedding Cake";
            Weight = 1.0;
            FillFactor = 1;
        }

        public SliceOfWeddingCake(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
