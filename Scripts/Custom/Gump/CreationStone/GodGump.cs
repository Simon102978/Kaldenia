using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Accounting;

namespace Server.Gumps
{
  public class CreationGodGump : CreationBaseGump
    {

        public CreationGodGump(CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Choix du dieu",true, creationPerso.God != null)
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
    
            int space = 115;

            AddSection(x - 10, y, 300, 357, "Dieux");

			AddSection(x + 291, y, 309, 357, "Images");

            foreach (God God in God.AllGods)
            {
				string color = "#ffffff";

				if (God == creationPerso.God)
				{
					color = "#ffcc00";
					AddImage(x + 325 + God.GumpXAdjustement, y + 40, God.GumpID);
				}

				

				AddButtonHtlml(x + 20, y + scale * line + 50, God.Name, 200, 40, God.GodID + 100, color);
                line++;
            }

         
                AddBackground(x + 325, y + 20, 200, 250,2629);// -- Le noire est pas un pure noire, alors sa fait pas ... Transformer en pure noire dans les gumps ? ? 

               

            string GodName = "Aucune";
            string GodBG = "Aucune God de selectionn??#$?&*e";

            if (m_Creation.God != null)
            {
                GodName = m_Creation.God.Name;
                GodBG = m_Creation.God.BG;
            }

            AddSection(x - 10, y + 358, 610, 250, GodName, GodBG);

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {

          CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

          if (from.Deleted || !from.Alive)
            return;


			if (info.ButtonID >= 99 && info.ButtonID < 200 )
			{
				m_Creation.God = God.GetGod(info.ButtonID - 100);

				from.SendGump(new CreationGodGump(m_from, m_Creation));
			}

			else if (info.ButtonID == 1001)
			{
				Account acc = (Account)from.Account;

				if (acc.Reroll.Count > 0)
				{
					from.SendGump(new CreationRerollGump(from, m_Creation));

				}
				else
				{

					from.SendGump(new CreationValidationGump(m_from, m_Creation));
				}



				
			}
			else if (info.ButtonID == 1000 || info.ButtonID == 0)
			{
				m_from.SendGump(new CreationStatistique(m_from, m_Creation));
			}

		

		}


    }
}
