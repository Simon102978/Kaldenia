using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreMenestrel : LivreClasse
	{
        [Constructable]
        public LivreMenestrel() : this(Classe.GetClasse(7))
        {
        }

        [Constructable]
        public LivreMenestrel(Classe classe) : base(classe)
        {
            Name = "livre de m??#$?&*n??#$?&*strel";
        }

        public LivreMenestrel(Serial serial) : base(serial)
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