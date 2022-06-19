using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreMassier : LivreClasse
	{
        [Constructable]
        public LivreMassier() : this(Classe.GetClasse(1))
        {
        }

        [Constructable]
        public LivreMassier(Classe classe) : base(classe)
        {
            Name = "livre de Massier";
        }

        public LivreMassier(Serial serial) : base(serial)
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