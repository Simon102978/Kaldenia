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


namespace Server.Gumps
{
    public class FeControlGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		Dictionary<CustomPlayerMobile, int> Dictionnairy;

		public FeControlGump(CustomPlayerMobile from,  Dictionary<CustomPlayerMobile, int> dict, int page = 0)
            : base("Fe", 560, 622, true)
        {

			m_From = from;
			m_Page = page;

			int x = XBase;
			int y = YBase;

	
			int line = 0;
			
			Dictionnairy = dict;



			if (Dictionnairy.Count == 0)
			{

				Dictionary<CustomPlayerMobile, int> mydict = new Dictionary<CustomPlayerMobile, int>();

				foreach (Account acct in Accounts.GetAccounts())
				{
					for (int i = 0; i < acct.Length; i++)
					{
						if (acct[i] != null && acct.AccessLevel == AccessLevel.Player)
						{
							if (acct[i] is CustomPlayerMobile cp)
							{
								mydict.Add(cp, cp.FETotal);
							}

							
						}
			
					}
				}

				Dictionnairy =  (from entry in mydict orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value); ;
			}


			int i2 = 0;

			AddHtmlTexteColored(x + 10, y + 20 + line * 20, 300, "Personnage", "#ffffff");
			AddHtmlTexteColored(x + 300, y + 20 + line * 20, 300, "Total FE", "#ffffff");
			AddHtmlTexteColored(x + 400, y + 20 + line * 20, 300, "FE Normal", "#ffffff");
			AddHtmlTexteColored(x + 500, y + 20 + line * 20, 300, "FE RP", "#ffffff");


			foreach (KeyValuePair<CustomPlayerMobile, int> item in Dictionnairy)
			{
				if (i2 >= page * 28 && line < 28)
				{
					AddHtmlTexteColored(x + 10 , y + 40 + line * 20, 300, item.Key.GetBaseName(), "#ffffff");
					AddHtmlTexteColored(x + 300, y + 40 + line * 20, 300, item.Value.ToString(), "#ffffff");
					AddHtmlTexteColored(x + 400, y + 40 + line * 20, 300, item.Key.FENormalTotal.ToString(), "#ffffff");
					AddHtmlTexteColored(x + 500, y + 40 + line * 20, 300, item.Key.FERPTotal.ToString(), "#ffffff");
					line++;
				}
				i2++;
			}

			if (page != 0)
			{
				AddButton(x + 5, y + 610, 1, 4506);
			}
			if (Server.World.Mobiles.Count > (page + 1) * 28)
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
							sender.Mobile.SendGump(new FeControlGump(m_From, Dictionnairy, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
							sender.Mobile.SendGump(new FeControlGump(m_From, Dictionnairy, m_Page + 1));
							break;
						 }

				 }
		}
	}
}
