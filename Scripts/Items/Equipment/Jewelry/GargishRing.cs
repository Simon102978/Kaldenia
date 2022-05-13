namespace Server.Items
{
    public class Ring : BaseRing
    {
        [Constructable]
        public Ring()
            : base(0x4212)
        {
            //Weight = 0.1;
        }

        public Ring(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
