using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DualPointedSpear))]
    [Flipable(0x27AD, 0x27F8)]
    public class Kama : BaseKnife
    {
        [Constructable]
        public Kama()
            : base(0x27AD)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
        }

        public Kama(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
        public override WeaponAbility SecondaryAbility => WeaponAbility.DefenseMastery;
        public override int StrengthReq => 15;
        public override int MinDamage => 10;
        public override int MaxDamage => 13;
        public override float Speed => 2.00f;

        public override int DefHitSound => 0x232;
        public override int DefMissSound => 0x238;
        public override int InitMinHits => 35;
        public override int InitMaxHits => 60;
        public override SkillName DefSkill => SkillName.Wrestling;
        public override WeaponType DefType => WeaponType.Piercing;
        public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;
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