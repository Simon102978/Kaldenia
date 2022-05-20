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
using Server.Misc;

namespace Server.Gumps
{
  public class CreationFinalisationGump : BaseProjectMGump
	{

		CustomPlayerMobile m_from;


        public CreationFinalisationGump(CustomPlayerMobile from)
			: base("Finalisation de la création", 300, 300,false)
        {
			m_from = from;
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            int space = 115;

			string context = "Le bateau continuera de voger en direction de la ville principale, et vous allez perdre tous les objets présents dans votre sac. \n\nEtes-vous certain de vouloir continuer?";

			AddSection(x - 5 , y, 345, 280, "Contexte", context);

			AddBackground(x - 5, y + 281, 345, 60, 9270);

			AddButton(x + 60,y + 292, 1, 1147);
			AddButton(x + 200, y + 292, 0, 1144);

		}
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID == 1)
            {

				from.Backpack.Delete();

				CharacterCreation.AddBackpack(from);

				Point3D p = new Point3D();

				switch (Utility.Random(3))
				{
					case 0:
						p = new Point3D(1536, 920, 9);
						break;
					case 1:
						p = new Point3D(1536, 945, 9);
						break;
					case 2:
						p = new Point3D(1532, 931, 9);
						break;
					case 3:
						p = new Point3D(1532, 925, 9);
						break;
					default:
						p = new Point3D(1530, 945, 9);
						break;
				}

				from.MoveToWorld(p, Map.Felucca);		
			}

        }

     

    }
}
