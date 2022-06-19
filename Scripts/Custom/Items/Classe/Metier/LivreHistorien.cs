using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreHistorien : LivreClasse
	{
        [Constructable]
        public LivreHistorien() : this(Classe.GetClasse(12))
        {
        }

        [Constructable]
        public LivreHistorien(Classe classe) : base(classe)
        {
            Name = "livre d'Historien";
        }

        public LivreHistorien(Serial serial) : base(serial)
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