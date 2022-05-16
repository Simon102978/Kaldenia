namespace Server.Items
{
    public class CookieMixExp : BaseFood
    {
        [Constructable]
        public CookieMixExp()
            : base(0x103F)
        {
        }

        public CookieMixExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
