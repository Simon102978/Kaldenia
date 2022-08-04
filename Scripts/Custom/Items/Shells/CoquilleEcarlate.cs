using System;
using Server;

namespace Server.Items
{
	public class CoquilleEcarlate : BaseShell
	{
		[Constructable]
		public CoquilleEcarlate() : base(4038)
		{
            Name = "coquillage";
		}

        public CoquilleEcarlate(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
		}
	}
}