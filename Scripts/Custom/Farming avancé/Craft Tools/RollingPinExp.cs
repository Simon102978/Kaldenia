using Server.Engines.Craft;

namespace Server.Items
{
    public class RollingPinExp : BaseTool
    {
        [Constructable]
        public RollingPinExp()
            : base(0x1043)
        {
            this.Weight = 1.0;
        }

        [Constructable]
        public RollingPinExp(int uses)
            : base(uses, 0x1043)
        {
            this.Weight = 1.0;
        }

        public RollingPinExp(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem
        {
            get
            {
                return DefCookingExp.CraftSystem;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
