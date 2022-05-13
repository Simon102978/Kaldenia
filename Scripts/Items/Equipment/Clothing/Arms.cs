namespace Server.Items
{
    public class ClothArms : BaseClothing
    {
        [Constructable]
        public ClothArms()
            : this(0)
        {
        }

        [Constructable]
        public ClothArms(int hue)
            : base(0x0404, Layer.Arms, hue)
        {
            Weight = 2.0;
        }

        public ClothArms(Serial serial)
            : base(serial)
        {
        }

        public override void OnAdded(object parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile)
            {
                if (((Mobile)parent).Female)
                    ItemID = 0x0403;
                else
                    ItemID = 0x0404;
            }
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

    public class FemaleClothArms : BaseClothing
    {
        [Constructable]
        public FemaleClothArms()
            : this(0)
        {
        }

        [Constructable]
        public FemaleClothArms(int hue)
            : base(0x0403, Layer.Arms, hue)
        {
            Weight = 2.0;
        }

        public FemaleClothArms(Serial serial)
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

    public class MaleClothArms : BaseClothing
    {
        [Constructable]
        public MaleClothArms()
            : this(0)
        {
        }

        [Constructable]
        public MaleClothArms(int hue)
            : base(0x0404, Layer.Arms, hue)
        {
            Weight = 2.0;
        }

        public MaleClothArms(Serial serial)
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
