
namespace Server.Items
{
    public class SangEnvouteDrake : Item, ICommodity
    {
        [Constructable]
        public SangEnvouteDrake()
            : this(1)
        {
        }

        [Constructable]
        public SangEnvouteDrake(int amount)
            : base(0x2DB6)
        {
            Stackable = true;
            Amount = amount;
			Name = "Sang Envouté Drake";
        }

        public SangEnvouteDrake(Serial serial)
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
