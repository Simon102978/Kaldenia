namespace Server.Items
{
    public class HagCauldron : BaseAddon
    {
        [Constructable]
        public HagCauldron()
        {
            AddonComponent pot;
            pot = new AddonComponent(2420);
            AddComponent(pot, 0, 0, 0);      //pot w/ support

            AddonComponent fire;
            fire = new AddonComponent(4012)
            {
                Light = LightType.Circle150
            };      //fire pit
            AddComponent(fire, 0, 0, 0);
        }

        public HagCauldron(Serial serial)
            : base(serial)
        {
        }

		public override BaseAddonDeed Deed => new HagCauldronDeed();
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	public class HagCauldronDeed : BaseAddonDeed
	{
		[Constructable]
		public HagCauldronDeed()
		{
		}

		public HagCauldronDeed(Serial serial)
			: base(serial)
		{
		}

		public override BaseAddon Addon => new HagCauldron();
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}

