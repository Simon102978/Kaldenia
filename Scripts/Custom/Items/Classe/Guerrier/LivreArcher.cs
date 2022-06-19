using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreArcher : LivreClasse
	{
        [Constructable]
        public LivreArcher() : this(Classe.GetClasse(4))
        {
        }

        [Constructable]
        public LivreArcher(Classe classe) : base(classe)
        {
            Name = "livre d'archer";
        }

        public LivreArcher(Serial serial) : base(serial)
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