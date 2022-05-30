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
			: base("Finalisation de la création", 400, 350,false)
        {
			m_from = from;
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            int space = 115;

			string context = "Le bateau continuera de voger en direction de la ville principale, et vous allez perdre tous les objets présents dans votre sac. \n\nEtes-vous certain de vouloir continuer?";

			AddSection(x - 5 , y, 445, 160, "Contexte", context);

			AddBackground(x - 5, y + 161, 445, 60, 9270);

			AddButton(x + 110,y + 172, 1, 1147);
			AddButton(x + 250, y + 172, 0, 1144);

			AddSection(x - 5, y + 222, 445, 108, "Retour", "Vous pouvez aussi retourner dans la salle de création, pour modifier votre personnage.");

			AddBackground(x - 5, y + 331, 445, 60, 9270);

			AddButton(x + 180, y + 342, 2, 1147);

		}
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID == 1)
            {

				from.Backpack.Delete();


				var holding = from.Holding;

				if (holding != null)
				{
					from.Holding.Delete();
					from.Holding = null;

				}



				CharacterCreation.AddBackpack(from);

				from.AddToBackpack(new Gold(500));

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
			if (info.ButtonID == 2)
			{
				from.Blessed = true;
				from.Backpack.Delete();

				var holding = from.Holding;

				if (holding != null)
				{
					from.Holding.Delete();
					from.Holding = null;

				}






				from.MoveToWorld(new Point3D(6135, 3200, 55), Map.Felucca);
			}

		}

	}
}
