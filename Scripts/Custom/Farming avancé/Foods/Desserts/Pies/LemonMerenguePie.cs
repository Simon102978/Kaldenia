namespace Server.Items
{
    public class LemonMerenguePie : BaseFood
    {
        [Constructable]
        public LemonMerenguePie() : this(1) { }

        [Constructable]
        public LemonMerenguePie(int amount)
            : base(amount, 0x1042)
        {
            Weight = 1.0;
            FillFactor = 3;
            Name = "Lemon Merengue Pie";
        }
        public LemonMerenguePie(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
