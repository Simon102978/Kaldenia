using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreCambrioleur : LivreClasse
	{
        [Constructable]
        public LivreCambrioleur() : this(Classe.GetClasse(8))
        {
        }

        [Constructable]
        public LivreCambrioleur(Classe classe) : base(classe)
        {
            Name = "livre de Cambrioleur";
        }

        public LivreCambrioleur(Serial serial) : base(serial)
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