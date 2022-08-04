using System;
using Server;

namespace Server.Items
{
	public class CoquillePlate : BaseShell
	{
		[Constructable]
		public CoquillePlate() : base(4040)
		{
            Name = "coquillage";
		}

        public CoquillePlate(Serial serial) : base(serial)
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