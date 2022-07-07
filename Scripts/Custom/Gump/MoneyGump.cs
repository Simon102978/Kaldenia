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
    public class MoneyGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private int m_Page;
		Dictionary<Mobile, int> Dictionnairy;

		public MoneyGump(CustomPlayerMobile from,  Dictionary<Mobile, int> dict, int page = 0)
            : base("Mobiles", 560, 622, true)
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

				Dictionary<Mobile, int> mydict = new Dictionary<Mobile, int>();

				foreach (Account acct in Accounts.GetAccounts())
				{
					for (int i = 0; i < acct.Length; i++)
					{
						if (acct[i] != null && acct.AccessLevel == AccessLevel.Player)
						{
							mydict.Add(acct[i], Banker.GetBalance(acct[i]));
						}
			
					}
				}

				Dictionnairy =  (from entry in mydict orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value); ;
			}


			int i2 = 0;


			foreach (KeyValuePair<Mobile, int> item in Dictionnairy)
			{
				if (i2 >= page * 60  )
				{


					AddHtmlTexteColored(x + 10 + colonne * 300, y + 20 + line * 20, 300, item.Key.Name + "-" + item.Value.ToString(), "#ffffff");

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
							sender.Mobile.SendGump(new MoneyGump(m_From, Dictionnairy, m_Page - 1));
							 break;
						 }
					 case 2:
						 {
							sender.Mobile.SendGump(new MoneyGump(m_From, Dictionnairy, m_Page + 1));
							break;
						 }

				 }
		}
	}
}
