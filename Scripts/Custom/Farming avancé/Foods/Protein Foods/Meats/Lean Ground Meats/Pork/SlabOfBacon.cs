namespace Server.Items
{
    public class SlabOfBaconExp : BaseFood
    {
        [Constructable]
        public SlabOfBaconExp() : this(1) { }

        [Constructable]
        public SlabOfBaconExp(int amount)
            : base(amount, 0x976)
        {
            Weight = 1.0;
            FillFactor = 1;
        }

        public SlabOfBaconExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
