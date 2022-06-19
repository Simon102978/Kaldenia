using System;
using Server.Mobiles;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Custom;
using Server.Regions;

namespace Server.Items
{//TODO: arranger les skills de la classe barde et thaumaturge
    [FlipableAttribute(0xFBE, 0xFBD)]
	public abstract class LivreClasse : Item
	{
        private Classe m_Classe;
		
        [CommandProperty(AccessLevel.GameMaster)]
        public Classe Classe
        {
            get { return m_Classe; }
            set { m_Classe = value; }
        }
        
        public LivreClasse() : this(Classe.GetClasse(-1))
        {
        }

        public LivreClasse(Classe classe) : base(0xFBE)
        {
            m_Classe = classe;
            Name = "livre de classe";
            Weight = 2.0;
        }

        public LivreClasse(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is CustomPlayerMobile pm)
            {

				pm.SendGump(new LivreClasseGump(pm, Classe, this));





            }
        }



		public override void Serialize( GenericWriter writer )
		{
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Classe.ClasseID);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
				
                case 0:
                {
                  
                    m_Classe = (Classe)Classe.GetClasse(reader.ReadInt());
                    break;
                }
            }
        }


	}
}