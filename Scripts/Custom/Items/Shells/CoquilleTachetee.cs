using System;
using Server;

namespace Server.Items
{
	public class CoquilleTachetee : BaseShell
	{
		[Constructable]
		public CoquilleTachetee() : base(4041)
		{
            Name = "coquillage";
		}

        public CoquilleTachetee(Serial serial) : base(serial)
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