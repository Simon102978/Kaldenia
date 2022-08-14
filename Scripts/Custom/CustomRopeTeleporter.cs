using Server.Mobiles;

namespace Server.Items
{
    public class CustomTeleportRope : Item
    {

        [CommandProperty(AccessLevel.Administrator)]
        public Point3D ToLocation { get; set; }

        [CommandProperty(AccessLevel.Administrator)]
        public Map ToMap { get; set; }

        [Constructable]
        public CustomTeleportRope()
            : base(0x14FA)
        {
            ToLocation = Point3D.Zero;
            ToMap = Map.Internal;
			Movable = false;
        }

        public CustomTeleportRope(Serial serial)
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
				Item package = (Item)cp.Backpack.FindItemByType(typeof(Server.Items.Corde));

				if (package == null)
				{
					package = (Item)cp.Backpack.FindItemByType(typeof(Server.Items.Rope));
				}


				if (package != null)
				{
					CustomGate firstGate = new CustomGate(ToLocation, ToMap);
					firstGate.MoveToWorld(this.Location, this.Map);

					package.Delete();
					from.SendMessage("Vous utilisez votre corde.");

				}
				else
				{
					from.SendMessage("Vous devez avoir une corde dans votre sac.");
				}
				
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
