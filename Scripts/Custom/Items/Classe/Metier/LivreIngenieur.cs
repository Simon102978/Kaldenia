using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreIngenieur : LivreClasse
	{
        [Constructable]
        public LivreIngenieur() : this(Classe.GetClasse(13))
        {
        }

        [Constructable]
        public LivreIngenieur(Classe classe) : base(classe)
        {
            Name = "livre d'Ingénieur";
        }

        public LivreIngenieur(Serial serial) : base(serial)
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