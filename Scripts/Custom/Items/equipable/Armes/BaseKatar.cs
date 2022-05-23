using Server.Targets;

namespace Server.Items
{
    public abstract class BaseKatar : BaseMeleeWeapon
    {
        public BaseKatar(int itemID)
            : base(itemID)
        {
        }

        public BaseKatar(Serial serial)
            : base(serial)
        {
        }

        public override SkillName DefSkill => SkillName.Wrestling;

        public override WeaponType DefType => WeaponType.Bashing;

        public override WeaponAnimation DefAnimation => WeaponAnimation.Slash2H;

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

        public override void OnDoubleClick(Mobile from)
        {
            from.SendLocalizedMessage(1010018); // What do you want to use this item on?
            from.Target = new BladedItemTarget(this);
        }
    }
}