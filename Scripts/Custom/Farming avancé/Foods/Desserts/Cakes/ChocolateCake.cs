namespace Server.Items
{
    public class ChocolateCake : BaseFood
    {
        [Constructable]
        public ChocolateCake() : this(1) { }
        [Constructable]
        public ChocolateCake(int amount)
            : base(amount, 0x9E9)
        {
            Weight = 2.0;
            FillFactor = 3;
            Hue = 0x45D;
            Name = "Chocolate Cake";
        }
        public ChocolateCake(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
