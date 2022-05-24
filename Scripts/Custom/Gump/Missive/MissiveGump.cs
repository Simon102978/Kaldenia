using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    public class MissiveGump : Gump
    {
        private Mobile m_From;
        private Missive m_Missive;

        public MissiveGump(Mobile from, Missive missive)
            : base(0, 0)
        {
            m_From = from;
            m_Missive = missive;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(22, 16, 334, 414, 9380);

            AddImageTiled(135, 349, 166, 29, 93);

            AddImage(83, 349, 92);
            AddImage(301, 349, 94);

            if (m_Missive.Vierge)
            {
                for (int i = 0; i < m_Missive.Lignes.Length; ++i)
                    AddTextEntry(52, 54 + (i * 20), 274, 20, 0, i, "");

                AddButton(311, 406, 4005, 4007, 1, GumpButtonType.Reply, 0);
                AddLabel(261, 406, 0, "Valider");

                AddTextEntry(135, 353, 185, 20, 0, m_Missive.Lignes.Length, m_From.Name);
            }
            else
            {
                for (int i = 0; i < m_Missive.Lignes.Length; ++i)
                    AddLabelCropped(52, 54 + (i * 20), 274, 20, 0, m_Missive.Lignes[i]);

                AddLabel(135, 353, 0, m_Missive.DestinateurName);
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (m_Missive.Deleted || !m_From.CheckAlive())
                return;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        TextRelay entry;

                        for (int i = 0; i < m_Missive.Lignes.Length; ++i)
                        {
                            entry = info.GetTextEntry(i);
                            m_Missive.Lignes[i] = entry == null ? "" : entry.Text.Trim();
                        }

                        entry = info.GetTextEntry(m_Missive.Lignes.Length);

                        m_Missive.Destinateur = m_From;
                        m_Missive.DestinateurName = entry == null ? "" : entry.Text.Trim();

                        m_Missive.Vierge = false;
                        break;
                    }
            }
        }
    }
}