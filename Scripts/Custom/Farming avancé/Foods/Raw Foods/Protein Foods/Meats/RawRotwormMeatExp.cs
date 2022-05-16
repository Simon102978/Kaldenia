namespace Server.Items
{
    public class RawRotwormMeatExp : BaseFood
    {
        [Constructable]
        public RawRotwormMeatExp()
            : this(1)
        {
        }

        [Constructable]
        public RawRotwormMeatExp(int amount)
            : base(0x2DB9, 10)
        {
            Stackable = true;
            Weight = 0.1;
            Amount = amount;
            Raw = true;
        }

        public RawRotwormMeatExp(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            /*int version = */
            reader.ReadInt();
        }
    }
}
