using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreBagarreur : LivreClasse
	{
        [Constructable]
        public LivreBagarreur() : this(Classe.GetClasse(3))
        {
        }

        [Constructable]
        public LivreBagarreur(Classe classe) : base(classe)
        {
            Name = "livre de Bagarreur";
        }

        public LivreBagarreur(Serial serial) : base(serial)
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