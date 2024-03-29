using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreStyliste : LivreClasse
	{
        [Constructable]
        public LivreStyliste() : this(Classe.GetClasse(14))
        {
        }

        [Constructable]
        public LivreStyliste(Classe classe) : base(classe)
        {
            Name = "livre de styliste";
        }

        public LivreStyliste(Serial serial) : base(serial)
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