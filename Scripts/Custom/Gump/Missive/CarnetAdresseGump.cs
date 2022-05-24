using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
    public class CarnetAdresseGump : Gump
    {
        private Mobile m_From;
        private CarnetAdresse m_Carnet;

        public CarnetAdresseGump(Mobile from, CarnetAdresse carnet) : base(0, 0)
        {
            m_From = from;
            m_Carnet = carnet;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddImage(15, 35, 2220);

            for (int i = 0; i < 2; ++i)
            {
                AddImage(69 + (i * 168), 66, 57);
                AddImage(171 + (i * 168), 66, 59);
                AddImageTiled(91 + (i * 168), 66, 84, 14, 58);
                AddLabel(98 + (i * 168), 53, 0, "Contact");
            }

            for (int i = 0; i < m_Carnet.Adresses.Count; ++i)
            {
                if ((i % 14) == 0)
                {
                    if (i != 0)
                    {
                        AddButton(336, 43, 2206, 2206, 0, GumpButtonType.Page, (i / 14) + 1);
                    }

                    AddPage((i / 14) + 1);

                    if (i != 0)
                    {
                        AddButton(64, 43, 2205, 2205, 0, GumpButtonType.Page, (i / 14));
                    }
                }

                AddButton(71 + ((i / 7) * 168) - ((i / 14) * 336), 79 + (i * 22) - ((i / 7) * 154), 2103, 2104, i + 1, GumpButtonType.Reply, 0);
                AddLabel(86 + ((i / 7) * 168) - ((i / 14) * 336), 74 + (i * 22) - ((i / 7) * 154), 0, ((Adresse)m_Carnet.Adresses[i]).Name);
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Carnet.Deleted || !m_From.CheckAlive())
                return;

            if (info.ButtonID > 0)
            {
                m_From.SendMessage("Choississez une missive.");
                m_From.BeginTarget(1, false, TargetFlags.None, new TargetStateCallback(OnTarget), info.ButtonID - 1);

                /*if (m_Carnet.RemoveAt(info.ButtonID - 1))
                    m_From.SendMessage(String.Format("Vous supprimez {0} de votre carnet d'adresse.", (Adresse)m_Carnet.Adresses[i - 1]));

                m_From.SendGump(new CarnetAdresseGump(m_From, m_Carnet));*/
            }
        }

        private void OnTarget(Mobile from, object t, object state)
        {
            if (m_Carnet.Deleted || !m_From.CheckAlive())
                return;

            if (t is Missive)
            {
                Missive missive = (Missive)t;
                int index = (int)state;

                Adresse adresse = m_Carnet.GetAt(index);

                if (adresse == null)
                    return;

                missive.Destinataire = adresse.Mobile;
                missive.DestinataireName = adresse.Name;
            }
            else
            {
                m_From.SendMessage("Vous devez choisir une missive.");
            }
        }
    }
}