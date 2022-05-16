using System;
using Server.Items;

namespace Server.ContextMenus
{
    public class EatEntryExp : ContextMenuEntry
    {
        private readonly Mobile m_From;
        private readonly BaseFood m_Food;

        public EatEntryExp(Mobile from, BaseFood food)
            : base(6135, 1)
        {
            m_From = from;
            m_Food = food;
        }

        public override void OnClick()
        {
            m_Food.TryEatExp(m_From);
        }
    }
}
