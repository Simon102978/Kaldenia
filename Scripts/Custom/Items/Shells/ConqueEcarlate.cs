using System;
using Server;

namespace Server.Items
{
	public class ConqueEcarlate : BaseShell
	{
		[Constructable]
		public ConqueEcarlate() : base(4042)
		{
            Name = "coquillage";
		}

        public ConqueEcarlate(Serial serial) : base(serial)
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