namespace Server.Items
{
    public class Citrine : Item, IGem
    {
        [Constructable]
        public Citrine()
            : this(1)
        {
        }

        [Constructable]
        public Citrine(int amount)
            : base(0xF15)
        {
            Stackable = true;
            Amount = amount;
			Name = "Citrine";

		}

        public Citrine(Serial serial)
            : base(serial)
        {
        }

        public override double DefaultWeight => 1.0;
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