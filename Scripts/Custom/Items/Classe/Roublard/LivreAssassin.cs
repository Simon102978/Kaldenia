using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreAssassin : LivreClasse
	{
        [Constructable]
        public LivreAssassin() : this(Classe.GetClasse(9))
        {
        }

        [Constructable]
        public LivreAssassin(Classe classe) : base(classe)
        {
            Name = "livre d'assassin";
        }

        public LivreAssassin(Serial serial) : base(serial)
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