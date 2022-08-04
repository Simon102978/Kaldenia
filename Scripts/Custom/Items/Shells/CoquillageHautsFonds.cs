using System;
using Server;

namespace Server.Items
{
	public class CoquillageHautsFonds : BaseShell
	{
		[Constructable]
		public CoquillageHautsFonds() : base(4043)
		{
            Name = "coquillage";
		}

        public CoquillageHautsFonds(Serial serial) : base(serial)
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