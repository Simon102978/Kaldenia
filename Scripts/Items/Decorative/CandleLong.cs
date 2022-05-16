using System;

namespace Server.Items
{
    public class CandleLong1 : BaseLight
    {
        [Constructable]
        public CandleLong1()
            : base(0x1433)
        {
            if (Burnout)
                Duration = TimeSpan.FromMinutes(30);
            else
                Duration = TimeSpan.Zero;

            Burning = false;
            Light = LightType.Circle150;
            Weight = 1.0;
        }

        public CandleLong1(Serial serial)
            : base(serial)
        {
        }

        public override int LitItemID => 0x1430;
        public override int UnlitItemID => 0x1433;
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