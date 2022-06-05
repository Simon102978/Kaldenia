using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
	public class SoloLute : Item
	{
		[Constructable]
		public SoloLute() : base( 0xEB3 )
		{
			Weight = 5.0;
			Hue = 2419;
			Name = "Lute solo";
            Layer = Layer.TwoHanded;
		}

		public SoloLute( Serial serial ) : base( serial )
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

			if ( Weight == 3.0 )
				Weight = 5.0;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
            from.CloseGump(typeof(LuteGump));
		    from.SendGump( new LuteGump() );
		}
	}
}