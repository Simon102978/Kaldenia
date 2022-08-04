using System;

namespace Server.Items
{
	public class BaseShell : Item
    {
        public bool IsGathered { get { return Movable; } }

		[Constructable]
        public BaseShell(int itemID) : base(itemID)
		{
            Weight = 0.5;
            Movable = false;
		}

		public BaseShell( Serial serial ) : base( serial )
		{
        }

        public static Type GetRandomShell()
        {
            switch (Utility.Random(9))
            {
                case 0: return typeof(Conque);
                case 1: return typeof(ConqueEcarlate);
                case 2: return typeof(CoquillageArcEnCiel);
                case 3: return typeof(CoquillageHautsFonds);
                case 4: return typeof(CoquilleDoree);
                case 5: return typeof(CoquilleEcarlate);
                case 6: return typeof(CoquillePlate);
                case 7: return typeof(CoquilleTachetee);
                default: return typeof(Nautile);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsGathered)
            {
                if (!from.InRange(Location, 2))
                {
                    from.SendLocalizedMessage(500446); // That is too far away.
                }
                else
                {
                    Movable = true;

                    from.PlaySound(85);
                    from.AddToBackpack(this);
					from.AddToBackpack(new BlackPearl(Utility.Random(1, 5)));
                }
            }
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