namespace Server.Items
{
    public class SausOnionMushPizza : BaseFood
    {
        [Constructable]
        public SausOnionMushPizza() : this(1) { }
        [Constructable]
        public SausOnionMushPizza(int amount)
            : base(amount, 0x1040)
        {
            Weight = 1.0;
            FillFactor = 5;
            Name = "Sausage Onion and Mushroom Pizza";
        }
        public SausOnionMushPizza(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
