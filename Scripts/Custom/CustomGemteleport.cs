using Server.Mobiles;

namespace Server.Items
{
    public class CustomGemTeleport : Item
    {

        [CommandProperty(AccessLevel.Administrator)]
        public Point3D ToLocation { get; set; }

        [CommandProperty(AccessLevel.Administrator)]
        public Map ToMap { get; set; }

        [Constructable]
        public CustomGemTeleport()
            : base(0x990)
        {
            ToLocation = Point3D.Zero;
            ToMap = Map.Internal;
			Movable = false;
        }

        public CustomGemTeleport(Serial serial)
            : base(serial)
        { }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (ToLocation == Point3D.Zero ||
                ToMap == Map.Internal)
                return;

			if (from is CustomPlayerMobile cp)
			{
				Item citrine = (Item)cp.Backpack.FindItemByType(typeof(Server.Items.Citrine));
				Item amethyst = (Item)cp.Backpack.FindItemByType(typeof(Server.Items.Amethyst));

				if ((citrine != null) && (amethyst != null))
				{
					CustomGate firstGate = new CustomGate(ToLocation, ToMap);
					firstGate.MoveToWorld(this.Location, this.Map);

					if (citrine.Amount > 1)					
						citrine.Amount -= 1;				
					else
						citrine.Delete();


					if (amethyst.Amount > 1)
						amethyst.Amount -= 1;
					else
						amethyst.Delete();

					from.SendMessage("Vous déposer vos pierres précieuses dans le panier.");



				}
				else

					from.SendMessage("Rien ne se produit.");
			}

		}




		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // Version
            writer.Write(ToLocation);
            writer.Write(ToMap);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    ToLocation = reader.ReadPoint3D();
                    ToMap = reader.ReadMap();
                    break;
            }
        }
    }
}
