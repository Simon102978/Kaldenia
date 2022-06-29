using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps
{
  public class CreationRaceGump : CreationBaseGump
    {

        public CreationRaceGump(CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Choix de la race",false, creationPerso.Race != null)
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
    
            int space = 115;

            AddSection(x - 10, y, 300, 357, "Races");

			AddSection(x + 291, y, 309, 357, "Apparence");

            foreach (Race race in Race.AllRaces)
            {
				string color = "#ffffff";

				if (race == creationPerso.Race)
				{
					color = "#ffcc00";
				}


				AddButtonHtlml(x + 20, y + scale * line + 50, race.Name, 200, 40, race.RaceID + 100, color);
                line++;
            }

            if (creationPerso.Race != null)
            {
                AddBackground(x + 325, y + 20, 200, 250,2629);// -- Le noire est pas un pure noire, alors sa fait pas ... Transformer en pure noire dans les gumps ? ? 

                m_Creation.Hue = creationPerso.Hue == -1 ? creationPerso.Race.RandomSkinHue() : creationPerso.Hue;

                AddImage(x + 355, y + 30, creationPerso.Race.GetGump(creationPerso.Female, m_Creation.Hue), m_Creation.Hue);
                

                AddColorChoice(x + 435 - creationPerso.Race.SkinHues.Length * 9, y + 275, 10, creationPerso.Race.SkinHues);
            }
            else
            {
                AddImage(x + 375, y + 80, 495); // Mettre en else du if suivant..
            }

            string RaceName = "Aucune";
            string RaceBG = "Aucune race de selectionn??#$?&*e";

            if (m_Creation.Race != null)
            {
                RaceName = m_Creation.Race.Name;
                RaceBG = m_Creation.Race.Background;
            }

            AddSection(x - 10, y + 358, 610, 250, RaceName, RaceBG);

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {

          CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

          if (from.Deleted || !from.Alive)
            return;

            if (info.ButtonID >= 10 && info.ButtonID < 100)
            {
                m_Creation.Hue = m_Creation.Race.SkinHues[info.ButtonID - 10];
                from.SendGump(new CreationRaceGump(from, m_Creation));
            }
            else if (info.ButtonID >= 100 && info.ButtonID < 1000)
            {
                m_Creation.Race = (BaseRace)Race.GetRace(info.ButtonID - 100);

                from.SendGump(new CreationRaceGump(from, m_Creation));
            }
            else if (info.ButtonID == 1001)
            {
                from.SendGump(new InfoGenGump(from,m_Creation));
            }


        }


    }
}
