namespace Server.Items
{
    public class RoastPigExp : BaseFood
    {
        [Constructable]
        public RoastPigExp() : this(1) { }

        [Constructable]
        public RoastPigExp(int amount)
            : base(amount, 0x9BB)
        {
            Weight = 45.0;
            FillFactor = 20;
        }

        public RoastPigExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
