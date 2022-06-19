using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivrePalefrenier : LivreClasse
	{
        [Constructable]
        public LivrePalefrenier() : this(Classe.GetClasse(15))
        {
        }

        [Constructable]
        public LivrePalefrenier(Classe classe) : base(classe)
        {
            Name = "livre de palefrenier";
        }

        public LivrePalefrenier(Serial serial) : base(serial)
        {
        }

		public override void Serialize( GenericWriter writer )
		{
            base.Serialize(writer);

            writer.Write((int)0); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
        }
	}
}