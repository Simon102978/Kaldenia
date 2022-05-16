namespace Server.Items
{
    public class HamPineapplePizza : BaseFood
    {
        [Constructable]
        public HamPineapplePizza() : this(1) { }

        [Constructable]
        public HamPineapplePizza(int amount)
            : base(amount, 0x1040)
        {
            Weight = 1.0;
            FillFactor = 3;
            Name = "Ham and Pineapple Pizza";
        }
        public HamPineapplePizza(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
