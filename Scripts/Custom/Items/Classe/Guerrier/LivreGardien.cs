using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreGardien : LivreClasse
	{
        [Constructable]
        public LivreGardien() : this(Classe.GetClasse(5))
        {
        }

        [Constructable]
        public LivreGardien(Classe classe) : base(classe)
        {
            Name = "livre de gardien";
        }

        public LivreGardien(Serial serial) : base(serial)
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