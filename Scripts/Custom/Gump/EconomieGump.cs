using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Accounting;
using System.Linq;
using Server.Custom;


namespace Server.Gumps
{
    public class EconomieGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		Dictionary<string, double> Dictionnairy;

		public EconomieGump(CustomPlayerMobile from,  Dictionary<string, double> dict, int page = 0)
            : base("Économie", 560, 622, true)
        {

			m_From = from;
			m_Page = page;

			int x = XBase;
			int y = YBase;
	
			int line = 0;
			int colonne = 0;
			Dictionnairy = dict;

			if (Dictionnairy.Count == 0)
			{
				Dictionnairy =  (from entry in CustomPersistence.SellItems orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value); ;
			}


			int i2 = 0;


			foreach (KeyValuePair<string, double> item in Dictionnairy)
			{
				if (i2 >= page * 60  )
				{


					AddHtmlTexteColored(x + 10 + colonne * 250, y + 20 + line * 20, 300, item.Key, "#ffffff");

					AddHtmlTexteColored(x + 200 + colonne * 275, y + 20 + line * 20, 300,Math.Round(item.Value, 2).ToString(), "#ffffff");

					//					AddLabel(x + 10 + colonne * 300, y + 20 + line * 20, 0,  item.Key.Name + "-" + item.Value.ToString());

					line++;

					if (i2 == (page + 1 ) * 58 - 29 && colonne == 0)
					{
						line = 0;
						colonne += 1;
					}
					else if ( i2 == (page + 1) * 59)
					{
						break;
					}
				}
				i2++;
			}

			if (page != 0)
			{
				AddButton(x + 5, y + 610, 1, 4506);
			}
			if (Server.World.Mobiles.Count > (page + 1) * 58)
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
							sender.Mobile.SendGump(new EconomieGump(m_From, Dictionnairy, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
							sender.Mobile.SendGump(new EconomieGump(m_From, Dictionnairy, m_Page + 1));
							break;
						 }

				 }
		}
	}
}
