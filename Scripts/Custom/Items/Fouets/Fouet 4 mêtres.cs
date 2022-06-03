using System;

namespace Server.Items
{
	public class Fouet4 : Fouet
    {
		[Constructable]
        public Fouet4() : base(4)
		{
		}

        public Fouet4(Serial serial) : base(serial)
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