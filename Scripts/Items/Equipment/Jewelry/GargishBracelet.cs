namespace Server.Items
{
    public class Bracelet : BaseBracelet
    {
        [Constructable]
        public Bracelet()
            : base(0x4211)
        {
            //Weight = 0.1;
        }

        public Bracelet(Serial serial)
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
