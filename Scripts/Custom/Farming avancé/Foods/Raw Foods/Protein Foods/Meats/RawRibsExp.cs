namespace Server.Items
{
    public class RawRibsExp : BaseFood
    {
        [Constructable]
        public RawRibsExp() : this(1) { }

        [Constructable]
        public RawRibsExp(int amount)
            : base(amount, 0x9F1)
        {
            Stackable = true;
            Amount = amount;
            Raw = true;
        }

        public RawRibsExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
