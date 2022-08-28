using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreEpeiste : LivreClasse
	{
        [Constructable]
        public LivreEpeiste() : this(Classe.GetClasse(0))
        {
        }

        [Constructable]
        public LivreEpeiste(Classe classe) : base(classe)
        {
            Name = "livre d'Épéiste";
        }

        public LivreEpeiste(Serial serial) : base(serial)
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