namespace Server.Items
{
    public class TacoPizza : BaseFood
    {
        [Constructable]
        public TacoPizza() : this(1) { }

        [Constructable]
        public TacoPizza(int amount)
            : base(amount, 0x1040)
        {
            Weight = 1.0;
            FillFactor = 3;
            Name = "Taco Pizza";
        }
        public TacoPizza(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
