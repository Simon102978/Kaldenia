namespace Server.Items
{
    public class MuffinsExp : BaseFood
    {
        [Constructable]
        public MuffinsExp()
            : base(0x9eb)
        {
            this.Weight = 1.0;
            this.FillFactor = 4;
        }

        public MuffinsExp(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
