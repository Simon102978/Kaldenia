namespace Server.Items
{
    public class Emerald : Item, IGem
    {
        [Constructable]
        public Emerald()
            : this(1)
        {
        }

        [Constructable]
        public Emerald(int amount)
            : base(0xF10)
        {
            Stackable = true;
            Amount = amount;
			Name = "Émeraude";
        }

        public Emerald(Serial serial)
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