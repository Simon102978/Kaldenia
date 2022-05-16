namespace Server.Items
{
    public class TurkeyPie : BaseFood
    {
        [Constructable]
        public TurkeyPie() : this(1) { }

        [Constructable]
        public TurkeyPie(int amount)
            : base(amount, 0x1042)
        {
            Weight = 1.0;
            FillFactor = 3;
            Name = "Turkey Pie";
        }

        public TurkeyPie(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
