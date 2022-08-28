namespace Server.Items
{
    public class SangEnvouteFroid : Item, ICommodity
    {
        [Constructable]
        public SangEnvouteFroid()
            : this(1)
        {
        }

        [Constructable]
        public SangEnvouteFroid(int amount)
            : base(0x2DB6)
        {
            Stackable = true;
            Amount = amount;
			Name = "Sang Envouté Froid";
        }

        public SangEnvouteFroid(Serial serial)
            : base(serial)
        {
        }

        TextDefinition ICommodity.Description => LabelNumber;
        bool ICommodity.IsDeedable => true;

        public override int LabelNumber => 1031702;// Medusa Blood
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
