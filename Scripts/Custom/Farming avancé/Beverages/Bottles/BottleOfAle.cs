namespace Server.Items
{
    public class BottleOfAle : BaseCraftAle
    {
        public override Item EmptyItem { get { return new EmptyAleBottle(); } }

        [Constructable]
        public BottleOfAle() : base(0x99F)
        {
            Weight = 0.2;
            FillFactor = 3;
        }

        public BottleOfAle(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}