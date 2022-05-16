namespace Server.Items
{
    public class EmptyWoodenBowlExp : Item
	{
        [Constructable]
        public EmptyWoodenBowlExp() : base(0x15F8)
        {
            Weight = 1.0;
        }

		public EmptyWoodenBowlExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

    public class EmptyPewterBowlExp : Item
	{
        [Constructable]
		public EmptyPewterBowlExp() : base( 0x15FD )
        {
            Weight = 1.0;
        }

		public EmptyPewterBowlExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
    public class EmptyWoodenTubExp : Item
    {
        [Constructable]
        public EmptyWoodenTubExp() : base(0x1605)
        {
            Weight = 2.0;
        }

        public EmptyWoodenTubExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
    public class EmptyPewterTubExp : Item
    {
        [Constructable]
        public EmptyPewterTubExp() : base(0x1603)
        {
            Weight = 2.0;
        }

        public EmptyPewterTubExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }

    public class WoodenBowlExp : Item
    {
        [Constructable]
        public WoodenBowlExp() : base(0x15F8)
        {
            Weight = 1.0;
        }

        public WoodenBowlExp(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
