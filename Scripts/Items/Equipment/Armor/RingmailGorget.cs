using Server.Engines.Craft;

namespace Server.Items
{
 
   
    public class RingmailGorget : BaseArmor
    {
        [Constructable]
        public RingmailGorget()
            : base(0x2FC7)
        {
            Weight = 2.0;
        }

        public RingmailGorget(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 4;
        public override int BaseFireResistance => 3;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 3;
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
