using Server.Engines.Craft;

namespace Server.Items
{
    public class SkilletExp : BaseTool
    {
        [Constructable]
        public SkilletExp()
            : base(0x97F)
        {
            Weight = 1.0;
        }

        [Constructable]
        public SkilletExp(int uses)
            : base(uses, 0x97F)
        {
            Weight = 1.0;
        }

        public SkilletExp(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1044567;
            }
        }// skillet
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
