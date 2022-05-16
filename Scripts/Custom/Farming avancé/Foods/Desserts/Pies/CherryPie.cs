namespace Server.Items
{
    public class CherryPie : BaseFood
    {
        [Constructable]
        public CherryPie() : this(1) { }

        [Constructable]
        public CherryPie(int amount)
            : base(amount, 0x1041)
        {
            Weight = 1.0;
            FillFactor = 3;
            Name = "Cherry Pie";
        }
        public CherryPie(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
