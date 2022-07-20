using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Engines.Craft;
using Server.Accounting;

namespace Server.Gumps
{
  public class CreationRerollGump : CreationBaseGump
    {

        public CreationRerollGump(CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Transfert", true, true)
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
    
            int space = 115;

            AddSection(x - 10, y, 610, 470, "Transfert");     

            int Range = 0;

            int SpaceRanger = 50;

            Account acc = (Account)from.Account;


            for (int i = 0; i < 7; i++)
            {
               

                if (acc.Reroll.Count > i)
                {

                    Reroll rero = acc.Reroll[i];

                    string hueText = "#ffffff";

                    if (rero == creationPerso.Reroll)
                    {
                        hueText = "#ffcc00";
                    }

					AddButtonHtlml(x + 5, y + 35 + SpaceRanger * Range, "Nom: " + rero.Name, 200, 25, Range + 100, hueText);
					AddHtmlTexteColored(x + 23, y + 35 + Range * SpaceRanger + 20, 200,  "Expériences: " + Math.Round(rero.ExperienceNormal * 1 + rero.ExperienceRP / 2), hueText);


					

					


					//            AddButton(x + 5, y + 35 + Range * SpaceRanger, 100 + Range, 1780);
					//      AddBackground(x + 5, y + 35 + Range * SpaceRanger, 205, 60, 9350);

					//            AddHtmlTexte(x + 15, y + 35 + Range * SpaceRanger, 200, 40, "<h3><basefont color=#"+ hueText + "> " + rero.Name + "</basefont></h3>");
					//           AddHtmlTexte(x + 15, y + 55 + Range * SpaceRanger, 200, 40, "<h3><basefont color=#" + hueText + ">Expériences: " +  Math.Round(rero.Experience * 0.75) + "</basefont></h3>");
				}
                else
                {
       //             AddBackground(x + 5, y + 35 + Range * SpaceRanger, 205, 60, 9350);
                }



                Range += 1;

            }
        

          //  y += 350;
         //   x -= 300;

            string TransfertSelect = "Aucun transfert";

            if (creationPerso.Reroll != null)
            {
                TransfertSelect = creationPerso.Reroll.Name + " \n\nExpériences: " + Math.Round(creationPerso.Reroll.ExperienceNormal + creationPerso.Reroll.ExperienceRP / 2) ;
            }

            AddSection(x - 10, y + 471, 610, 135, "Informations", TransfertSelect);

            y += 50;
            x += 15;





    

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
           CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID >= 100 && info.ButtonID < 110)
            {
                Reroll newReroll = ((Account)from.Account).Reroll[info.ButtonID - 100];

                if (m_Creation.Reroll == newReroll)
                {
                    m_Creation.Reroll = null;
                }
                else
                {
                    m_Creation.Reroll = newReroll;
                }


             
                m_from.SendGump(new CreationRerollGump(from, m_Creation));
            }


           if (info.ButtonID == 1001)
            {
                from.SendGump(new CreationValidationGump(from, m_Creation));
            }
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
                from.SendGump(new CreationGodGump(from, m_Creation));
            }



    
        }

     


    }


}
