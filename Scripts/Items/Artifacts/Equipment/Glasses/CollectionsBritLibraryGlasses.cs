using Server.Engines.Craft;

namespace Server.Items
{

    public class MaceAndShieldGlasses : Glasses
    {
        public override bool IsArtifact => true;
        [Constructable]
        public MaceAndShieldGlasses()
            : base()
        {
            Hue = 0x1DD;
            Attributes.BonusStr = 10;
            Attributes.BonusDex = 5;
            WeaponAttributes.HitLowerDefend = 30;
        }

        public MaceAndShieldGlasses(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1073381;// Mace and Shield Reading Glasses
        public override int BasePhysicalResistance => 25;
        public override int BaseFireResistance => 10;
        public override int BaseColdResistance => 10;
        public override int BasePoisonResistance => 10;
        public override int BaseEnergyResistance => 10;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
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


    public class GlassesOfTheArts : Glasses
    {
        [Constructable]
        public GlassesOfTheArts()
            : base()
        {
            Hue = 0x73;
            Attributes.BonusInt = 5;
            Attributes.BonusStr = 5;
            Attributes.BonusHits = 15;
        }

        public GlassesOfTheArts(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1073363;// Reading Glasses of the Arts
        public override int BasePhysicalResistance => 10;
        public override int BaseFireResistance => 8;
        public override int BaseColdResistance => 8;
        public override int BasePoisonResistance => 4;
        public override int BaseEnergyResistance => 10;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
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

   
    public class TradesGlasses : Glasses
    {
        [Constructable]
        public TradesGlasses()
        {
            Attributes.BonusStr = 10;
            Attributes.BonusInt = 10;
        }

        public TradesGlasses(Serial serial)
        {
        }

        public override int LabelNumber => 1073362;// Reading Glasses of the Trades
        public override int BasePhysicalResistance => 10;
        public override int BaseFireResistance => 10;
        public override int BaseColdResistance => 10;
        public override int BasePoisonResistance => 10;
        public override int BaseEnergyResistance => 10;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
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

  
    public class WizardsCrystalGlasses : Glasses
    {
        [Constructable]
        public WizardsCrystalGlasses()
        {
            Hue = 0x2B0;
            Attributes.BonusMana = 10;
            Attributes.RegenMana = 3;
            Attributes.SpellDamage = 15;
        }

        public WizardsCrystalGlasses(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1073374;// Wizard's Crystal Reading Glasses
        public override int BasePhysicalResistance => 5;
        public override int BaseFireResistance => 5;
        public override int BaseColdResistance => 5;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
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

  
    public class TreasuresAndTrinketsGlasses : Glasses
    {
        [Constructable]
        public TreasuresAndTrinketsGlasses()
        {
            Hue = 0x5A6; // TODO check		
            Attributes.BonusInt = 10;
            Attributes.BonusHits = 5;
            Attributes.SpellDamage = 10;
        }

        public TreasuresAndTrinketsGlasses(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1073373;// Treasures and Trinkets Reading Glasses
        public override int BasePhysicalResistance => 10;
        public override int BaseFireResistance => 10;
        public override int BaseColdResistance => 10;
        public override int BasePoisonResistance => 10;
        public override int BaseEnergyResistance => 10;
        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
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