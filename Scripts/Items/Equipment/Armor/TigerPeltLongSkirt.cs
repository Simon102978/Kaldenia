namespace Server.Items
{
    public class TigerPeltLongSkirt : BaseArmor
    {
        public override int BasePhysicalResistance => 1;
        public override int BaseFireResistance => 4;
        public override int BaseColdResistance => 3;
        public override int BasePoisonResistance => 3;
        public override int BaseEnergyResistance => 3;

        public override int InitMinHits => 30;
        public override int InitMaxHits => 40;

        public override int StrReq => 25;

        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;

        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

        public override bool AllowMaleWearer => true;

        public override int LabelNumber => 1109630;  // Tiger Pelt Long Skirt

        [Constructable]
        public TigerPeltLongSkirt()
            : base(0x7826)
        {
            Weight = 1.0;
        }

        public TigerPeltLongSkirt(Serial serial)
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
