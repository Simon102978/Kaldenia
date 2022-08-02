using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Gumps;
///using Server.Custom.Enums;
using Server.Custom;

namespace Server.Items
{

	public  class GemmeFeu : Item //BaseJet
    {
		[Constructable]
		public GemmeFeu() : base(0x1EA7)
		{
			
			Name = "Gemme de feu";
			Weight = 2.0;
			Hue = 1185;
		}

		public GemmeFeu( Serial serial ) : base( serial )
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