using Server.Engines.Craft;

namespace Server.Items
{
    public class FlourSifterExp : BaseTool
    {
        [Constructable]
        public FlourSifterExp()
            : base(0x103E)
        {
            Weight = 1.0;
        }

        [Constructable]
        public FlourSifterExp(int uses)
            : base(uses, 0x103E)
        {
            Weight = 1.0;
        }

        public FlourSifterExp(Serial serial)
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
