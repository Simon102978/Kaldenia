using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using Server.Network;
using System.Collections.Generic;

namespace Server.ContextMenus
{
    public class AjouterEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private CarnetAdresse m_Carnet;

        public AjouterEntry(Mobile from, CarnetAdresse carnet) : base(175, 1)
        {
            m_From = from;
            m_Carnet = carnet;
        }

        public override void OnClick()
        {
            if (m_Carnet.Deleted || !m_From.CheckAlive())
                return;

            m_From.SendMessage("Sélectionner la personne ou la missive à ajouter dans le carnet d'adresse.");
            m_From.Target = new ChooseTarget(m_From, m_Carnet);
        }

        private class ChooseTarget : Target
        {
            private Mobile m_From;
            private CarnetAdresse m_Carnet;

            public ChooseTarget(Mobile from, CarnetAdresse carnet) : base(3, false, TargetFlags.None)
            {
                m_From = from;
                m_Carnet = carnet;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is CustomPlayerMobile)
                {
                    CustomPlayerMobile target = (CustomPlayerMobile)o;

                    if (m_Carnet.Contains(target.Name))
                    {
                        m_From.SendMessage("Vous avez déjà cette personne dans votre carnet.");
                    }
                    else
                    {
                        m_From.SendMessage("Veuillez attendre la confirmation de la personne.");
                        target.SendGump(new ConfirmGump(m_From, target, m_Carnet));
                    }
                }
                else if (o is Missive)
                {
                    Missive missive = (Missive)o;

                    if (missive.Destinateur == null || missive.Destinateur.Deleted)
                    {
                        m_From.SendMessage("La personne que vous désirez entrer dans votre carnet d'adresse est décédée et a rejoint Kalos.");
                    }
                    else if (m_Carnet.Contains(missive.DestinateurName))
                    {
                        m_From.SendMessage("Vous avez déjà cette personne dans votre carnet.");
                    }
                    else if (!(missive.Destinateur is CustomPlayerMobile))
                    {
                        m_From.SendMessage("Le destinateur de la missive n'est pas un joueur.");
                    }
                    else
                    {
                        m_Carnet.Adresses.Add(new Adresse((CustomPlayerMobile)missive.Destinateur, missive.DestinateurName));
                        m_From.SendMessage(String.Format("Vous ajoutez {0} dans votre carnet d'adresse.", missive.DestinateurName));
                    }
                }
                else
                {
                    m_From.SendMessage("Vous devez choisir un joueur ou une missive.");
                }
            }
        }
    }
}

namespace Server.Items
{
    public class Adresse
    {
        private CustomPlayerMobile m_Mobile;
        private string m_Name;

        public CustomPlayerMobile Mobile { get { return m_Mobile; } set { m_Mobile = value; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }

        public Adresse(CustomPlayerMobile mobile, string name)
        {
            m_Mobile = mobile;
            m_Name = name;
        }
    }

    public class CarnetAdresse : Item
    {
        private ArrayList m_Adresses;

        public ArrayList Adresses
        {
            get { return m_Adresses; }
            set { m_Adresses = value; }
        }

        [Constructable]
        public CarnetAdresse() : base(0xFF2)
        {
            Name = "carnet d'adresse";
            Weight = 1.0;
            Hue = 1633;

            m_Adresses = new ArrayList();
        }

        public virtual bool Contains(string name)
        {
            if (m_Adresses == null)
                return false;

            for (int i = 0; i < m_Adresses.Count; ++i)
            {
                Adresse adresse = (Adresse)m_Adresses[i];

                if (adresse.Name == name)
                    return true;
            }

            return false;
        }

        public virtual bool RemoveAt(int index)
        {
            if (m_Adresses == null)
                return false;

            try
            {
                m_Adresses.RemoveAt(index);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public virtual Adresse GetAt(int index)
        {
            if (m_Adresses == null)
                return null;

            try
            {
                return (Adresse)m_Adresses[index];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public CarnetAdresse(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write(m_Adresses.Count);

            for (int i = 0; i < m_Adresses.Count; ++i)
            {
                Adresse adresse = (Adresse)m_Adresses[i];

                writer.Write(adresse.Mobile);
                writer.Write(adresse.Name);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        int count = reader.ReadInt();

                        m_Adresses = new ArrayList(count);

                        for (int i = 0; i < count; ++i)
                        {
                            CustomPlayerMobile mob = (CustomPlayerMobile)reader.ReadMobile();
                            string name = reader.ReadString();

                            m_Adresses.Add(new Adresse(mob, name));
                        }

                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }

            if (m_Adresses == null)
                m_Adresses = new ArrayList();
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from.Alive)
                list.Add(new AjouterEntry(from, this));
        }

        public override void OnAosSingleClick(Mobile from)
        {
            base.OnAosSingleClick(from);
            LabelTo(from, String.Format("[{0} adresse{1}]", m_Adresses.Count, m_Adresses.Count <= 1 ? "" : "s"));
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
				from.CloseGump(typeof(CarnetAdresseGump));

				from.SendGump(new CarnetAdresseGump(from, this));
            }
            else
            {
                from.SendMessage("Le carnet d'adresse doit être dans votre sac.");
            }
        }
    }
}
