using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Custom;


namespace Server.Gumps
{
    public class VersionGump : BaseProjectMGump
	{
   

        public VersionGump(CustomPlayerMobile from)
            : base("Version Gump", 840, 560, true)
        {

			int x = XBase + 20;
			int y = YBase + 30;

			int xSecondColum = x + 60;
			int xAmountColum = x + 400;
			int line = 0;
			int scale = 30;
			int space = 80;


			AddHtmlTexteColored(x, y, 650, "Veuillez changer votre version pour 7.0.33.2 dans classicUo.","#FFFFFF");

			AddImage(x, y + 20, 2502);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;


			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;


		
			}
        }
    }
}
