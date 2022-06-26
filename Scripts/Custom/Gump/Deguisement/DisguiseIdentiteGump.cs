using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using System.Reflection;


namespace Server.Gumps
{
    public class DegIdentiteGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;


		public DegIdentiteGump(CustomPlayerMobile from)
            : base("Apparence", 200, 200, true)
        {

			m_From = from;

			int x = XBase;
			int y = YBase;


			int line = 0;

			foreach(KeyValuePair<int, Deguisement> item in from.Deguisement)
		    {
				AddButtonHtlml(x + 10, y + 20 + line * 20, item.Value.Name, 200, 40, item.Key + 100, "#ffffff");
				line++;

			}

			if(from.Deguisement.Count < 3)
			{
				AddButtonHtlml(x + 10, y + 20 + line * 20, "Ajouter une nouvelle identité", 200, 40, 1, "#ffffff");
				line++;
			}


		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {



			switch (info.ButtonID)
			{
				     case 0:
						 {
							m_From.SendGump(new CustomDisguiseGump(m_From, m_From.GetDeguisement()));
							break;
						 }
					 case 1:
						 {
							 m_From.IdentiteID = m_From.Deguisement.Count + 1;
							 m_From.SetDeguisement(new Deguisement(m_From));
						//	 m_From.GetDeguisement().ApplyDeguisement();
							 m_From.SendGump(new CustomDisguiseGump(m_From, m_From.GetDeguisement()));
							 break;
						 }
				 }

			if (info.ButtonID >= 100)
			{
				m_From.IdentiteID = (info.ButtonID - 100);
				m_From.GetDeguisement().ApplyDeguisement();
				m_From.SendGump(new CustomDisguiseGump(m_From, m_From.GetDeguisement()));
			}
		}
	}
}
