namespace Server.Items
{
    [Flipable(0xE76, 0xE76)]
    public class BagOfGems : Bag
    {
        public override int LabelNumber => 1048032;  // a bag

        [Constructable]
        public BagOfGems()
        {
            ItemID = 0xE76;
        }

        public BagOfGems(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }

    [Flipable(0xE76, 0xE76)]
    public class BagOfGold : Bag
    {
        public override int LabelNumber => 1048032;  // a bag

        [Constructable]
        public BagOfGold()
        {
            ItemID = 0xE76;
        }

        public BagOfGold(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }

    [Flipable(0xE76, 0xE76)]
    public class BagOfRegs : Bag
    {
        public override int LabelNumber => 1048032;  // a bag

        [Constructable]
        public BagOfRegs()
        {
            ItemID = 0xE76;
        }

        public BagOfRegs(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
