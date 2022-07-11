using Server.Engines.Craft;

namespace Server.Items
{

    public class MetalShield : BaseShield
    {
        [Constructable]
        public MetalShield()
            : base(0x1B7B)
        {
            Weight = 6.0;
        }

        public MetalShield(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 2;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 0;
        public override int BasePoisonResistance => 0;
        public override int BaseEnergyResistance => 0;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;
        public override int StrReq => 45;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);//version
        }
    }
}