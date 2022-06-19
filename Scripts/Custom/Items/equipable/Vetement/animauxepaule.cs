using Server.Engines.Craft;

namespace Server.Items
{

	public class ShoulderMonkey : BaseOuterTorso
	{
		[Constructable]
		public ShoulderMonkey()
			: this(0)
		{
		}

		[Constructable]
		public ShoulderMonkey(int hue)
			: base(0x3B44, hue)
		{
			Weight = 3.0;
			Name = "Un Singe";
			
		}

		public ShoulderMonkey(Serial serial)
			: base(serial)
		{
		}

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