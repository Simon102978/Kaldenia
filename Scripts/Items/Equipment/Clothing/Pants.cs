namespace Server.Items
{
    #region Reward Clothing
    public class LibraryFriendSkirt : Kilt
    {
        public override int LabelNumber => 1073352; // Friends of the Library Kilt

        [Constructable]
        public LibraryFriendSkirt()
            : this(0)
        {
        }

        [Constructable]
        public LibraryFriendSkirt(int hue)
            : base(hue)
        {
        }

        public LibraryFriendSkirt(Serial serial)
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

    public class LibraryFriendPants : LongPants
    {
        public override int LabelNumber => 1073349; // Friends of the Library Pants

        [Constructable]
        public LibraryFriendPants()
            : this(0)
        {
        }

        [Constructable]
        public LibraryFriendPants(int hue)
            : base(hue)
        {
        }

        public LibraryFriendPants(Serial serial)
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

    public class MalabellesDress : Skirt
    {
        public override int LabelNumber => 1073251; // Malabelle's Dress - Museum of Vesper Replica

        [Constructable]
        public MalabellesDress()
            : this(0)
        {
        }

        [Constructable]
        public MalabellesDress(int hue)
            : base(hue)
        {
        }

        public MalabellesDress(Serial serial)
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
    #endregion

    public abstract class BasePants : BaseClothing
    {
        public BasePants(int itemID)
            : this(itemID, 0)
        {
        }

        public BasePants(int itemID, int hue)
            : base(itemID, Layer.Pants, hue)
        {
        }

        public BasePants(Serial serial)
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

    [Flipable(0x152e, 0x152f)]
    public class ShortPants : BasePants
    {
        [Constructable]
        public ShortPants()
            : this(0)
        {
        }

        [Constructable]
        public ShortPants(int hue)
            : base(0x152E, hue)
        {
            Weight = 2.0;
			Name = "Short Taille Haute";

		}

        public ShortPants(Serial serial)
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

    [Flipable(0x1539, 0x153a)]
    public class LongPants : BasePants
    {
        [Constructable]
        public LongPants()
            : this(0)
        {
        }

        [Constructable]
        public LongPants(int hue)
            : base(0x1539, hue)
        {
            Weight = 2.0;
			Name = "Pantalon Taille Haute";

		}

        public LongPants(Serial serial)
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

    [Flipable(0x279B, 0x27E6)]
    public class TattsukeHakama : BasePants
    {
        [Constructable]
        public TattsukeHakama()
            : this(0)
        {
        }

        [Constructable]
        public TattsukeHakama(int hue)
            : base(0x279B, hue)
        {
            Weight = 2.0;
			Name = "Pantalon ample";

		}

        public TattsukeHakama(Serial serial)
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

    [Flipable(0x2FC3, 0x3179)]
    public class ElvenPants : BasePants
    {
        [Constructable]
        public ElvenPants()
            : this(0)
        {
        }

        [Constructable]
        public ElvenPants(int hue)
            : base(0x2FC3, hue)
        {
            Weight = 2.0;
			Name = "Pantalon Moulant";

		}

        public ElvenPants(Serial serial)
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

    public class ClothLegs : BaseClothing
    {
        [Constructable]
        public ClothLegs()
            : this(0)
        {
        }

        [Constructable]
        public ClothLegs(int hue)
            : base(0x040A, Layer.Pants, hue)
        {
            Weight = 2.0;
        }

        public override void OnAdded(object parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile)
            {
                if (((Mobile)parent).Female)
                    ItemID = 0x0409;
                else
                    ItemID = 0x040A;
            }
        }

        public ClothLegs(Serial serial)
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

    public class FemaleClothLegs : BaseClothing
    {
        [Constructable]
        public FemaleClothLegs()
            : this(0)
        {
        }

        [Constructable]
        public FemaleClothLegs(int hue)
            : base(0x0409, Layer.Pants, hue)
        {
            Weight = 2.0;
        }

        public FemaleClothLegs(Serial serial)
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

    public class MaleClothLegs : BaseClothing
    {
        [Constructable]
        public MaleClothLegs()
            : this(0)
        {
        }

        [Constructable]
        public MaleClothLegs(int hue)
            : base(0x040A, Layer.Pants, hue)
        {
            Weight = 2.0;
        }

        public MaleClothLegs(Serial serial)
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
