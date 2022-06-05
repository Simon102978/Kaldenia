using System;
using Server.Items;

namespace Server.Items
{
    [DynamicFliping]
    [Flipable(0xE41, 0xE40)]
    public class GMGoldChest : LockableContainer
    {
        public override int DefaultGumpID { get { return 0x42; } }
        public override int DefaultDropSound { get { return 0x42; } }
        public override int DefaultMaxWeight { get { return 0; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(18, 105, 144, 73); }
        }

        [Constructable]
        public GMGoldChest() : base(0xE41)
        {
            Weight = 25.0; // TODO: Real weight
            RequiredSkill = 120;
        }

        public GMGoldChest(Serial serial) : base(serial)
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

            int version = reader.ReadInt();
        }
    }

    [DynamicFliping]
    [Flipable(0x9AB, 0xE7C)]
    public class GMMetalChest : LockableContainer
    {
        public override int DefaultGumpID { get { return 0x4A; } }
        public override int DefaultDropSound { get { return 0x42; } }
        public override int DefaultMaxWeight { get { return 0; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(18, 105, 144, 73); }
        }

        [Constructable]
        public GMMetalChest() : base(0xE41)
        {
            Weight = 25.0; // TODO: Real weight
            RequiredSkill = 120;
        }

        public GMMetalChest(Serial serial) : base(serial)
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

            int version = reader.ReadInt();
        }
    }

    [DynamicFliping]
    [Flipable(0xe43, 0xe42)]
    public class GMWoodChest : LockableContainer
    {
        public override int DefaultGumpID { get { return 0x49; } }
        public override int DefaultDropSound { get { return 0x42; } }
        public override int DefaultMaxWeight { get { return 0; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(18, 105, 144, 73); }
        }

        [Constructable]
        public GMWoodChest() : base(0xE41)
        {
            Weight = 25.0; // TODO: Real weight
            RequiredSkill = 120;
        }

        public GMWoodChest(Serial serial) : base(serial)
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

            int version = reader.ReadInt();
        }
    }
}