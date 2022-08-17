using Server.Mobiles;


namespace Server.Items
{
    public class CustomMarchTeleport : Item
    {

		

		[CommandProperty(AccessLevel.Seer)]
        public Point3D ToLocation { get; set; }

        [CommandProperty(AccessLevel.Seer)]
        public Map ToMap { get; set; }

		

		[Constructable]
        public CustomMarchTeleport()
            : base(0x14F9)
        {
            ToLocation = Point3D.Zero;
            ToMap = Map.Internal;
			Movable = false;
        }

        public CustomMarchTeleport(Serial serial)
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
				Item marchandise = (Item)cp.Backpack.FindItemByType(typeof(Server.Custom.Packaging.Packages.Marchandise));
				

				if (marchandise != null )
				{
					CustomGate firstGate = new CustomGate(ToLocation, ToMap);
					firstGate.MoveToWorld(this.Location, this.Map);

				if (marchandise.Amount > 50)
					{

						marchandise.Amount -= 50;
						

					}
					else
					


						marchandise.Delete();
					
					from.SendMessage("Vous déposer vos marchandises près de l'ancre.");



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
