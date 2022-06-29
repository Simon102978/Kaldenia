using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class ConfirmGump : Gump
    {
        private Mobile m_From;
        private CustomPlayerMobile m_Mobile;
        private CarnetAdresse m_Carnet;

        public ConfirmGump(Mobile from, CustomPlayerMobile mobile, CarnetAdresse carnet) : base(0, 0)
        {
            m_From = from;
            m_Mobile = mobile;
            m_Carnet = carnet;

            Closable = false;
            Disposable = false;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(12, 18, 360, 104, 9270);

            AddLabel(28, 31, 2101, String.Format("Désirez-vous que {0} vous ajoute %%%#$%?%$#@!", m_From.Name));
            AddLabel(28, 55, 2101, "son carnet d'adresse?");

            AddButton(239, 86, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(208, 88, 2101, "Oui");

            AddButton(329, 86, 4017, 4019, 0, GumpButtonType.Reply, 0);
            AddLabel(298, 88, 2101, "Non");
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Carnet.Deleted || !m_From.CheckAlive() || !m_Mobile.CheckAlive())
                return;

            if (info.ButtonID == 0)
            {
                m_From.SendMessage(String.Format("{0} a refusé d'être ajouté %%%#$%?%$#@! votre carnet d'adresse.", m_Mobile.Name));
            }
            else
            {
                if (m_Carnet.Contains(m_Mobile.Name))
                {
                    m_From.SendMessage("Vous avez déj%%%#$%?%$#@! cette personne dans votre carnet.");
                }
                else
                {
                    m_From.SendMessage(String.Format("{0} a accepté d'être ajouté %%%#$%?%$#@! votre carnet d'adresse.", m_Mobile.Name));
                    m_Carnet.Adresses.Add(new Adresse(m_Mobile, m_Mobile.Name));
                }
            }
        }
    }
}