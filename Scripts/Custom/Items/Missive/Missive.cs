using System;
using System.Collections;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
    public class Missive : Item
    {

		private MissiveContent m_content;

		public MissiveContent Content { get => m_content; set => m_content = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Vierge
		{
			get
			{
				if (Content == null)
				{
					Content = new MissiveContent();					
				}
							
					return Content.Vierge; ;
			}
			set
			{
				if (m_content == null)
				{
					m_content = new MissiveContent();
				}

				m_content.Vierge = value;
			}

		}

		[CommandProperty(AccessLevel.GameMaster)]
        public CustomPlayerMobile Destinataire
        {
            get 
			{
				if (Content == null)
				{
					return null;
				}
				else
				{
					return Content.Destinataire; ;
				}
				
			}
			set
			{
				if (m_content == null)
				{
					m_content = new MissiveContent();
				}

				m_content.Destinataire = value;
			}

        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Destinateur
        {
            get 
			{
				if (Content == null)
				{
					return null;
				}
				else
				{
					return Content.Destinateur;
				}
			}
			set
			{
				if (m_content == null)
				{
					m_content = new MissiveContent();
				}

				m_content.Destinateur = value;
			}

		}

        [CommandProperty(AccessLevel.GameMaster)]
        public string DestinataireName
        {
            get 
			{
				if (Content == null)
				{
					return null;
				}
				else
				{
					return Content.DestinataireName;
				}
			}
			set
			{
				if (m_content == null)
				{
					m_content = new MissiveContent();
				}

				m_content.DestinataireName = value;
			}

		}

        [CommandProperty(AccessLevel.GameMaster)]
        public string DestinateurName
        {
            get 
			{
				if (Content == null)
				{
					return null;
				}
				else
				{
					return Content.DestinateurName;
				}
	
			}
			set
			{
				if (m_content == null)
				{
					m_content = new MissiveContent();
				}

				m_content.DestinateurName = value;
			}


		}

		public string[] Lignes
		{
			get 
			{
				if (Content == null)
				{
					return null;
				}
				else
				{
					return Content.Lignes;
				}
		
			}
			set
			{
				if (m_content == null)
				{
					m_content = new MissiveContent();
				}

				m_content.Lignes = value;
			}
		}

		[Constructable]
        public Missive() : base(0x14EE)
        {
            Name = "missive";
            Weight = 0.3;
			m_content = new MissiveContent();
          
        }


		public Missive(MissiveContent mc) : base(0x14EE)
		{
			Name = "missive";
			Weight = 0.3;
			m_content = mc;

		}

        public Missive(Serial serial) : base(serial)
        {
        }

        public override void OnAosSingleClick(Mobile from)
        {
            base.OnAosSingleClick(from);
            LabelTo(from, String.Format("Destinataire: {0}", Destinataire == null ? "Aucun" : DestinataireName));
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                if (!Vierge)
                {
                    CustomPlayerMobile pm = from as CustomPlayerMobile;



                    from.SendGump(new MissiveGump(from, this));
                }
                else if (from.Backpack != null)
                {
                    Item pen = (Item)from.Backpack.FindItemByType(typeof(ScribesPen));

                    if (pen == null || pen.Deleted)
                    {
                        from.SendMessage("Vous devez avoir un scribe's pen dans votre sac pour ??#$?&*crire une missive.");
                    }
                    else
                    {
                        from.SendGump(new MissiveGump(from, this));
                    }
                }
                else
                {
                    from.SendMessage("Vous devez avoir un scribe's pen dans votre sac pour ??#$?&*crire une missive.");
                }
            }
            else
            {
                from.SendMessage("La missive doit être dans votre sac.");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

			Content.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

		    m_content =  MissiveContent.Deserialize(reader);    
        }
    }
}