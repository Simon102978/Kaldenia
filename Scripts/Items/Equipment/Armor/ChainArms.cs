namespace Server.Items
{
    [Flipable(0x13ee, 0x13ef)]
    public class ChainmailArms : BaseArmor
    {
        [Constructable]
        public ChainmailArms()
            : base(0x13EE)
        {
            Weight = 15.0;
        }

        public ChainmailArms(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 5;
        public override int BaseFireResistance => 4;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 4;
        public override int InitMinHits => 40;
        public override int InitMaxHits => 50;
        public override int StrReq => 40;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
