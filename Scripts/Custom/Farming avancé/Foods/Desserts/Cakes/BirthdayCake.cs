namespace Server.Items
{
    public class BirthdayCake : BaseFood
    {
        [Constructable]
        public BirthdayCake()
            : base(0x3BBD)
        {
            Name = "Birthday Cake";
            Weight = 10.0;
            FillFactor = 10;
        }

        public BirthdayCake(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
