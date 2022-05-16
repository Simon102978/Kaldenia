namespace Server.Items
{
    public class RawSteakExp : BaseFood
    {
        [Constructable]
        public RawSteakExp()
            : this(1)
        {
        }

        [Constructable]
        public RawSteakExp(int amount)
            : base(amount, 0x9F1)
        {
            Name = "Raw Steak";
            Stackable = true;
            Amount = amount;
            Raw = true;
        }

        public RawSteakExp(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
