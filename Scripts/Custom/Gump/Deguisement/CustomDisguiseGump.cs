using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using System.Linq;


namespace Server.Gumps
{
    public class CustomDisguiseGump : BaseProjectMGump
	{
   
        private CustomPlayerMobile m_From;
		private Deguisement m_Deg;

        public CustomDisguiseGump(CustomPlayerMobile from, Deguisement deg)
            : base("D�guisement", 560, 622, false)
        {

			m_Deg = deg;
			m_From = from;
			int x = XBase;
			int y = YBase;

			int i = 0;
			int line = 0;
			int colonne = 0;
			int scale = 25;

			AddSection(x - 10, y , 610, 115, "G�n�ral");

			AddHtmlTexteColored(x + 10, y + 45, 75, "Nom: ", "#ffffff");

			if (from.DeguisementAction(DeguisementAction.Nom))
			{
				AddTextEntryBg(x + 73, y + 40, 500, 25, 0, 1, deg.Name);
			}
			else
			{
				AddHtmlTexteColored(x + 73, y + 45, 500, deg.Name, "#ffffff");
			}

			AddHtmlTexteColored(x + 10, y + 75, 75, "Titre: ", "#ffffff");

			if (from.DeguisementAction(DeguisementAction.Nom))
			{
				AddTextEntryBg(x + 73, y + 70, 500, 25, 0, 2, deg.Title);
			}
			else
			{
				AddHtmlTexteColored(x + 73, y + 75, 500, deg.Title, "#ffffff");
			}
		

			AddSection(x - 10, y + 116, 300, 270, "Sp�cifique");

			AddSection(x + 291, y + 116, 309, 270, "Apparence");

			AddSection(x - 10, y + 387, 610, 220, "Paperdoll", m_Deg.Paperdoll.Values.ToArray());

			AddBackground(x - 10, y + 608, 610, 55, 9270);

			if (from.DeguisementAction(DeguisementAction.Sexe))
			{

				AddButtonHtlml(x + 10, y + 151 + line * scale, 2, 2117, 2118, deg.Female ? "Femme" : "Homme", "#ffffff");

			}
			else
			{
				AddHtmlTexteColored(x + 28, y + 151 + line * scale, 500, deg.Female ? "Femme" : "Homme", "#ffffff");
			}


			line++;

			string raceName = "Aucune";

			if (m_Deg.Race != null)
			{
				raceName = deg.Race.Name;
			}

			if (from.DeguisementAction(DeguisementAction.Race))
			{
				AddButtonHtlml(x + 10, y + 151 + line * scale, 3, 2117, 2118, "Race: " + raceName, "#ffffff");
			}
			else
			{
				AddHtmlTexteColored(x + 28, y + 151 + line * scale, 500, "Race: " + raceName, "#ffffff");
			}

			line++;
			if (m_Deg.Race != null)
			{
				AddBackground(x + 325, y + 96, 200, 250, 2629);// -- Le noire est pas un pure noire, alors sa fait pas ... Transformer en pure noire dans les gumps ? ? 

				m_Deg.Hue = m_Deg.Hue == -1 ? m_Deg.Race.RandomSkinHue() : m_Deg.Hue;


				AddImage(x + 355, y + 106, m_Deg.Race.GetGump(m_Deg.Female, m_Deg.Hue), m_Deg.Hue);
				

				if (from.DeguisementAction(DeguisementAction.Racehue))
				{
					AddColorChoice(x + 435 - m_Deg.Race.SkinHues.Length * 9, y + 331, 100, m_Deg.Race.SkinHues);
				}

				
			}
			else
			{
				AddImage(x + 375, y + 80, 495); // Mettre en else du if suivant..
			}

			if (from.DeguisementAction(DeguisementAction.StatutSocial))
			{
				AddButtonHtlml(x + 10, y + 151 + line * scale, 10, 2117, 2118, "Statut Social: " + m_Deg.GetStatutSocial(), "#ffffff");
			}
			else
			{
				AddHtmlTexteColored(x + 28, y + 151 + line * scale, 500, "Apparence: " + m_Deg.GetStatutSocial(), "#ffffff");
			}
			line++;


			if (from.DeguisementAction(DeguisementAction.Apparence))
			{
				AddButtonHtlml(x + 10, y + 151 + line * scale, 4, 2117, 2118,"Apparence: " + m_Deg.GetApparence(), "#ffffff");
			}
			else
			{
				AddHtmlTexteColored(x + 28, y + 151 + line * scale, 500, "Apparence: " + m_Deg.GetApparence(), "#ffffff");
			}
			line++;

			
			if (from.DeguisementAction(DeguisementAction.Grandeur))
			{
			AddButtonHtlml(x + 10, y + 151 + line * scale, 5, 2117, 2118, "Grandeur: " + m_Deg.GetGrandeur(), "#ffffff");
			}
			else
			{
				AddHtmlTexteColored(x + 28, y + 151 + line * scale, 500, "Grandeur: " + m_Deg.GetGrandeur(), "#ffffff");
			}
			line++;
					
			if (from.DeguisementAction(DeguisementAction.Grosseur))
			{
			AddButtonHtlml(x + 10, y + 151 + line * scale, 6, 2117, 2118, "Grosseur: " + m_Deg.GetGrosseur(), "#ffffff");
			}
			else
			{
				AddHtmlTexteColored(x + 28, y + 151 + line * scale, 500, "Grosseur: " + m_Deg.GetGrosseur(), "#ffffff");
			}
			line++;
						
			if (from.DeguisementAction(DeguisementAction.Paperdoll))
			{
			AddButtonHtlml(x + 10, y + 151 + line * scale, 7, 2117, 2118, "Changer le paperdoll", "#ffffff");
			line++;
			}

			if(from.DeguisementAction(DeguisementAction.Identite))
			{

			AddButtonHtlml(x + 10, y + 151 + line * scale, 11, 2117, 2118, "Identités: " + from.IdentiteID, "#ffffff");
			line++;

			}



			line++;

			AddButton(x + 170, y + 617, 8, 1147, 1148);
			AddButton(x + 371, y + 617, 9, 1144, 1145);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			if (sender.Mobile is CustomPlayerMobile)
			{
				CustomPlayerMobile cm = (CustomPlayerMobile)sender.Mobile;

				if (cm.DeguisementAction(DeguisementAction.Nom))
				{
					if (info.GetTextEntry(1) != null)
					{
						m_Deg.Name = info.GetTextEntry(1).Text;
					}
				}
				if (cm.DeguisementAction(DeguisementAction.Titre))
				{
					if (info.GetTextEntry(2) != null)
					{
						m_Deg.Title = info.GetTextEntry(2).Text;
					}
				}
				switch (info.ButtonID)
				{
					case 1:
						{
							break;
						}
					case 2:
						{
							if (cm.DeguisementAction(DeguisementAction.Sexe))
							{
								m_Deg.Female = !m_Deg.Female;
							}
							m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));

							break;
						}
					case 3:
						{
							if (cm.DeguisementAction(DeguisementAction.Race))
							{
								m_From.SendGump(new DegRaceGump(m_From, m_Deg));
							}
							break;
						}
					case 4:
						{
							if (cm.DeguisementAction(DeguisementAction.Apparence))
							{
								m_From.SendGump(new DegApparenceGump(m_From, m_Deg));
							}
							break;
						}
					case 5:
						{
							if (cm.DeguisementAction(DeguisementAction.Grandeur))
							{
								m_From.SendGump(new DegGrandeurGump(m_From, m_Deg));
							}
							break;
						}
					case 6:
						{
							if (cm.DeguisementAction(DeguisementAction.Grosseur))
							{
								m_From.SendGump(new DegGrosseurGump(m_From, m_Deg));
							}
							break;
						}
					case 7:
						{
							if (cm.DeguisementAction(DeguisementAction.Paperdoll))
							{
								m_From.SendGump(new DegPaperdollGump(m_From, m_Deg));
							}
							break;
						}
					case 8:
						{
							if (cm.DeguisementAction(DeguisementAction.Titre))
							{
						        cm.SetDeguisement(m_Deg);

								m_Deg.ApplyDeguisement();
							}
							break;
						}
					case 9:
						{
							if (cm.Deguise)
							{
								Deguisement.RemoveDeguisement(cm);
							}

							break;
						}
					case 10:
						{
							if (cm.DeguisementAction(DeguisementAction.StatutSocial))
							{
								m_From.SendGump(new DegStatutSocialGump(m_From, m_Deg));
							}
							break;
						}
					case 11:
					{
							if (cm.DeguisementAction(DeguisementAction.Identite))
							{
								m_From.SendGump(new DegIdentiteGump(m_From));
							}


						break;
					}

				}

				if (info.ButtonID >= 100 && info.ButtonID < 200)
				{
					if (m_From.DeguisementAction(DeguisementAction.Racehue))
					{
						m_Deg.Hue = m_Deg.Race.SkinHues[info.ButtonID - 100];
						m_From.SendGump(new CustomDisguiseGump(m_From, m_Deg));
					}			
				}


			}



		
		}
	}
}
