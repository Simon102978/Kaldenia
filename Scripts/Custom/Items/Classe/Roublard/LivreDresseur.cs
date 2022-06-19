using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreDresseur : LivreClasse
	{
        [Constructable]
        public LivreDresseur() : this(Classe.GetClasse(11))
        {
        }

        [Constructable]
        public LivreDresseur(Classe classe) : base(classe)
        {
            Name = "livre de dresseur";
        }

        public LivreDresseur(Serial serial) : base(serial)
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