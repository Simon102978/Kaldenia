using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;


namespace Server.Gumps
{
    public class StatsItemsGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;

        public StatsItemsGump(CustomPlayerMobile from, int page = 0)
            : base("Mobiles", 560, 622, true)
        {

			m_From = from;
			m_Page = page;

			int x = XBase;
			int y = YBase;

			int i = 0;
			int line = 0;
			int colonne = 0;

			foreach (KeyValuePair<Serial,Item> item in Server.World.Items)
			{
				if (i >= page * 60  )
				{
					Item m = item.Value;

	//				AddLabel(x + 10 + colonne * 300, y + 20 + line * 20, 0, m.Name + "-" + m.Map  +" - " + m.Location);

					AddLabel(x + 10 + colonne * 300, y + 20 + line * 20, 0, m.GetType().ToString() + "-" + m.Map + " - " + m.Location);

					line++;

					if (i == (page + 1 ) * 58 - 29 && colonne == 0)
					{
						line = 0;
						colonne += 1;
					}
					else if ( i == (page + 1) * 59)
					{
						break;
					}
				}
				i++;
			}

			if (page != 0)
			{
				AddButton(x + 5, y + 610, 1, 4506);
			}
			if (Server.World.Items.Count > (page + 1) * 58)
			{
				AddButton(x + 535, y + 610, 2, 4502);
			}



		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {



			     switch (info.ButtonID)
				 {
					 case 1:
						 {
							sender.Mobile.SendGump(new StatsMobileGump(m_From, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
							sender.Mobile.SendGump(new StatsMobileGump(m_From, m_Page + 1));
							break;
						 }

				 }
		}
	}
}
