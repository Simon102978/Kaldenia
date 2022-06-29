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
	public class ClasseGump : CreationBaseGump
	{
		int m_stade;


		public ClasseGump(CustomPlayerMobile from, CreationPerso creationPerso, int stade = 0)
			: base(from, creationPerso, creationPerso.Title(stade), true, creationPerso.ClasseSelection(stade))
		{

			int x = XBase;
			int y = YBase;
			int line = 0;
			int scale = 20;
			int space = 115;
			m_stade = stade;

			// Layout
			
			AddSection(x - 10, y, 202, 300, "Guerrier");
			AddSection(x - 10, y + 301, 202, 308, "Métier");
			AddSection(x - 10 + 203, y, 203, 300, "Roublard");
			AddSection(x - 10 + 407, y, 203, 300, "Mage");
			AddSection(x - 10 + 203, y + +301, 406, 308, "Description", ClasseDescription());


			int LGuerrier = 0;
			int LMage = 0;
			int LRoublard = 0;
			int LMetier = 0;

			foreach (Classe item in Classe.AllClasse)
			{
				if (item.ClasseID == -1)
				{

				}				
				else if (stade == 1 && creationPerso.ClassePrimaire == item.ClasseID)
				{
					
				}
				else if (stade == 2 && (( creationPerso.ClassePrimaire == item.ClasseID || creationPerso.ClasseSecondaire == item.ClasseID) || item.ClasseType != ClasseType.Metier))
				{

				}
				else
				{
					string color = "#ffffff";

					if ((stade == 0 && creationPerso.ClassePrimaire == item.ClasseID ) || (stade == 1 && creationPerso.ClasseSecondaire == item.ClasseID) || (stade == 2 && creationPerso.Metier == item.ClasseID))
					{
						color = "#ffcc00";
					}

					switch (item.ClasseType)
					{
						case ClasseType.Guerrier:
							{
								AddButtonHtlml(x + 10, y + 40 + LGuerrier * scale, 100 + item.ClasseID, 2117, 2118, item.Name,color);


								LGuerrier++;
								break;
							}
						case ClasseType.Metier:
							{
								AddButtonHtlml(x + 10, y + 40 + LMetier * scale + 301, 100 + item.ClasseID, 2117, 2118, item.Name, color);
								LMetier++;
								break;
							}
						case ClasseType.Roublard:
							{
								AddButtonHtlml(x + 10 + 203, y + 40 + LRoublard * scale, 100 + item.ClasseID, 2117, 2118, item.Name, color);
								LRoublard++;
								break;
							}
						case ClasseType.Mage:
							{							
								AddButtonHtlml(x + 10 + 406, y + 40 + LMage * scale, 100 + item.ClasseID, 2117, 2118, item.Name, color);
								LMage++;
								break;
							}
						default:
							break;
					}



				}
			}
		}

		public string ClasseDescription()
		{
			string description = "";

			switch (m_stade)
			{
				case 0:
					{
						if (m_Creation.ClassePrimaire != -1)
						{

							Classe Classe = Classe.GetClasse(m_Creation.ClassePrimaire);

							description = Classe.Name + "\n\n";

							foreach (SkillName item in Classe.Skill)
							{
								description = description + "  -" + item.ToString() + ": 50 \n";
							}

							description = description + "\nArmure: " + Classe.Armor;

							return description;
						}
						else
						{
							return description;
						}
					}
				case 1:
					{
						if (m_Creation.ClasseSecondaire != -1)
						{

							Classe Classe = Classe.GetClasse(m_Creation.ClasseSecondaire);

							description = Classe.Name + "\n\n";

							foreach (SkillName item in Classe.Skill)
							{
								description = description + "  -" + item.ToString() + ": 30 \n";
							}

							description = description + "\nArmure: " + Classe.Armor;

							return description;
						}
						else
						{
							return description;
						}
					}
				case 2:
					{
						if (m_Creation.Metier != -1)
						{

							Classe Classe = Classe.GetClasse(m_Creation.Metier);

							description = Classe.Name + "\n\n";

							foreach (SkillName item in Classe.Skill)
							{
								description = description + "  -" + item.ToString() + ": 50 \n";
							}

							description = description + "\nArmure: " + Classe.Armor;

							return description;
						}
						else
						{
							return description;
						}
					}
				default:
					break;
			}




			return description;
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {

          CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

          if (from.Deleted || !from.Alive)
            return;





            if (info.ButtonID >= 100 && info.ButtonID < 200)
            {

				switch (m_stade)
				{
					case 0:
						m_Creation.ClassePrimaire = info.ButtonID - 100;
						break;
					case 1:
						m_Creation.ClasseSecondaire = info.ButtonID - 100;
						break;
					case 2:
						m_Creation.Metier = info.ButtonID - 100;
						break;

					default:
						break;
				}

				from.SendGump(new ClasseGump(m_from, m_Creation, m_stade));


			}
			else if (info.ButtonID == 1001)
            {
				if (m_stade == 2)
				{
					from.SendGump(new CreationStatistique(m_from, m_Creation));
				}
				else
				{
					m_stade++;

					from.SendGump(new ClasseGump(m_from, m_Creation, m_stade));
				}
				
				
				
            }
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {

				if (m_stade == 0)
				{
					from.SendGump(new InfoGenGump(m_from, m_Creation));
				}
				else
				{
					m_stade--;

					from.SendGump(new ClasseGump(m_from, m_Creation, m_stade));
				}

				
            }
        }
	}
}
