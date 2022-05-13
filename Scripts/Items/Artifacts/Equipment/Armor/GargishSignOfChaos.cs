namespace Server.Items
{
    public class SignOfChaos : ChaosShield
    {
        public override bool IsArtifact => true;
        [Constructable]
        public SignOfChaos()
            : base()
        {
            Hue = 2075;
            ArmorAttributes.SoulCharge = 20;
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 10;
            Attributes.CastSpeed = 1;
        }

        public SignOfChaos(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1113535; // Sign of Chaos

        public override int BasePhysicalResistance => 3;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;

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
