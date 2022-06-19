using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreDueliste : LivreClasse
	{
        [Constructable]
        public LivreDueliste() : this(Classe.GetClasse(2))
        {
        }

        [Constructable]
        public LivreDueliste(Classe classe) : base(classe)
        {
            Name = "livre de Dueliste";
        }

        public LivreDueliste(Serial serial) : base(serial)
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