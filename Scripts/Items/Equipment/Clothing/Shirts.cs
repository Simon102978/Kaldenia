﻿namespace Server.Items
{
    public abstract class BaseShirt : BaseClothing
    {
        public BaseShirt(int itemID)
            : this(itemID, 0)
        {
        }

        public BaseShirt(int itemID, int hue)
            : base(itemID, Layer.MiddleTorso, hue)
        {
        }

        public BaseShirt(Serial serial)
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

    [Flipable(0x1efd, 0x1efe)]
    public class FancyShirt : BaseShirt
    {
        [Constructable]
        public FancyShirt()
            : this(0)
        {
        }

        [Constructable]
        public FancyShirt(int hue)
            : base(0x1EFD, hue)
        {
            Weight = 2.0;
			Name = "Chandail de banquet";

		}

        public FancyShirt(Serial serial)
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

    [Flipable(0x1517, 0x1518)]
    public class Shirt : BaseShirt
    {
        [Constructable]
        public Shirt()
            : this(0)
        {
        }

        [Constructable]
        public Shirt(int hue)
            : base(0x1517, hue)
        {
            Weight = 1.0;
			Name = "Camisole";

		}

        public Shirt(Serial serial)
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

    [Flipable(0x2794, 0x27DF)]
    public class ClothNinjaJacket : BaseShirt
    {
        [Constructable]
        public ClothNinjaJacket()
            : this(0)
        {
        }

        [Constructable]
        public ClothNinjaJacket(int hue)
            : base(0x2794, hue)
        {
            Weight = 5.0;
            Layer = Layer.InnerTorso;
        }

        public ClothNinjaJacket(Serial serial)
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

    public class ElvenShirt : BaseShirt
    {
        [Constructable]
        public ElvenShirt()
            : this(0)
        {
        }

        [Constructable]
        public ElvenShirt(int hue)
            : base(0x3175, hue)
        {
            Weight = 2.0;
			Name = "Chemise ornée";

		}

        public ElvenShirt(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }

    public class ElvenDarkShirt : BaseShirt
    {
        [Constructable]
        public ElvenDarkShirt()
            : this(0)
        {
        }

        [Constructable]
        public ElvenDarkShirt(int hue)
            : base(0x3176, hue)
        {
            Weight = 2.0;
			Name = "Chemise ornée sombre";
        }

        public ElvenDarkShirt(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }

    public class ClothChest : BaseClothing
    {
        [Constructable]
        public ClothChest()
            : this(0)
        {
        }

        [Constructable]
        public ClothChest(int hue)
            : base(0x0406, Layer.InnerTorso, hue)
        {
            Weight = 2.0;
        }

        public ClothChest(Serial serial)
            : base(serial)
        {
        }

        public override void OnAdded(object parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile)
            {
                if (((Mobile)parent).Female)
                    ItemID = 0x0405;
                else
                    ItemID = 0x0406;
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

    public class FemaleClothChest : BaseClothing
    {
        [Constructable]
        public FemaleClothChest()
            : this(0)
        {
        }

        [Constructable]
        public FemaleClothChest(int hue)
            : base(0x0405, Layer.InnerTorso, hue)
        {
            Weight = 2.0;
        }

        public FemaleClothChest(Serial serial)
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

    public class MaleClothChest : BaseClothing
    {
        [Constructable]
        public MaleClothChest()
            : this(0)
        {
        }

        [Constructable]
        public MaleClothChest(int hue)
            : base(0x0406, Layer.InnerTorso, hue)
        {
            Weight = 2.0;
        }

        public MaleClothChest(Serial serial)
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
