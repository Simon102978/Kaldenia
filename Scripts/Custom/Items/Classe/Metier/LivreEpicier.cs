using Server.Custom;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreEpicier : LivreClasse
	{
        [Constructable]
        public LivreEpicier() : this(Classe.GetClasse(16))
        {
        }

        [Constructable]
        public LivreEpicier(Classe classe) : base(classe)
        {
            Name = "livre d'??#$?&*picier";
        }

        public LivreEpicier(Serial serial) : base(serial)
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