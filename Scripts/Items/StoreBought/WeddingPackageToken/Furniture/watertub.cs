namespace Server.Items
{
    public class Watertub : Item
    {
        

        [Constructable]
        public Watertub()
            : base(0x0E7B)
        {
            Weight = 15;
			Name = "Barril d'eau";
        }

       

        public Watertub(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
