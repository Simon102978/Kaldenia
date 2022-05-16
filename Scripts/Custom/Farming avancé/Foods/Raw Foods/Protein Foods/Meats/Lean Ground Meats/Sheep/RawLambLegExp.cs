using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class RawLambLegExp : BaseFood
	{
		[Constructable]
		public RawLambLegExp() : this( 1 )
		{
		}

		[Constructable]
        public RawLambLegExp(int amount)
            : base(amount, 0x1609)
		{
			Weight = 1.0;
			Stackable = true;
			Amount = amount;
            Raw = true;
		}

		public RawLambLegExp( Serial serial ) : base( serial )
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
