using System;
using Server;

namespace Server.Items
{
	public class Nautile : BaseShell
	{
		[Constructable]
		public Nautile() : base(4039)
		{
            Name = "coquillage";
		}

        public Nautile(Serial serial) : base(serial)
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