using System.Collections.Generic;

namespace Server.Mobiles
{
    public class Marchand : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public Marchand()
            : base("Marchand")
        {
        }

        public Marchand(Serial serial)
            : base(serial)
        {
        }

        public override VendorShoeType ShoeType => VendorShoeType.Boots;
        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBMarchand());
        }

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