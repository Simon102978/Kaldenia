using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivrePisteur : LivreClasse
	{
        [Constructable]
        public LivrePisteur() : this(Classe.GetClasse(10))
        {
        }

        [Constructable]
        public LivrePisteur(Classe classe) : base(classe)
        {
            Name = "livre de pisteur";
        }

        public LivrePisteur(Serial serial) : base(serial)
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