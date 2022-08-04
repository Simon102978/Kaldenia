using System;
using Server;

namespace Server.Items
{
	public class CoquilleDoree : BaseShell
	{
		[Constructable]
		public CoquilleDoree() : base(4037)
		{
            Name = "coquillage";
		}

        public CoquilleDoree(Serial serial) : base(serial)
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