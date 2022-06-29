using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;



namespace Server.Gumps
{
    public class FicheGump : BaseProjectMGump
	{
    /*    private void CreateAptitudes(CustomPlayerMobile from)
        {
            Hashtable aptitudes = FicheAptitudesGump.GetPlayerAptitudes(from);
            int index = 0;
            int count = 0;

            try
            {
                IDictionaryEnumerator en = aptitudes.GetEnumerator();

                while (en.MoveNext() && count < 14)
                {
                    if (en.Key is NAptitude)
                    {
                        AddLabel(557, 78 + (index * 18), 2101, en.Value.ToString());
                        AddLabel(675, 78 + (index * 18), 2101, String.Format(": {0}", from.GetAptitudeValue((NAptitude)en.Key)));

                        ++index;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void CreateConnaissances(CustomPlayerMobile from)
        {
            Hashtable conn = FicheConnaissancesGump.GetPlayerConnaissancesList(from);
            int index = 0;
            int count = 0;

            try
            {
                IDictionaryEnumerator en = conn.GetEnumerator();

                while (en.MoveNext() && count < 6)
                {
                    if (en.Key is NConnaissances)
                    {
                        AddLabel(362, 78 + (index * 18), 2101, en.Value.ToString());
                        AddLabel(474, 78 + (index * 18), 2101, String.Format(": {0}", from.GetConnaissancesValue((NConnaissances)en.Key)));

                        ++index;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
	*/

        private CustomPlayerMobile m_From;
        private CustomPlayerMobile m_GM;

        public FicheGump(CustomPlayerMobile from, CustomPlayerMobile gm)
            : base("Fiche de personnage", 560, 622, false)
        {
            m_From = from;
            m_GM = gm;

			int x = XBase;
			int y = YBase;

			//    m_From.Validate(ValidateType.All);
			m_From.InvalidateProperties();

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;


			AddSection(x - 10, y, 250, 180, "Informations");

			AddHtmlTexte(x +10, y + 40, 100, "Nom:");
			AddHtmlTexte(x + 125, y + 40, 150, from.Name);

			AddHtmlTexte(x + 10, y + 60, 100, "Race:");
			AddHtmlTexte(x + 125, y + 60, 150, from.Race.Name);

			AddHtmlTexte(x + 10, y + 80, 100, "Statut Social:");
			AddHtmlTexte(x + 125, y + 80, 150, from.StatutSocialString());

			AddHtmlTexte(x + 10, y + 100, 100, "Apparence:");
			AddHtmlTexte(x + 125, y + 100, 150, from.Apparence());

			AddHtmlTexte(x + 10, y + 120, 100, "Grandeur:");
			AddHtmlTexte(x + 125, y + 120, 150, from.GrandeurString());

			AddHtmlTexte(x + 10, y + 140, 100, "Grosseur:");
			AddHtmlTexte(x + 125, y + 140, 150, from.GrosseurString());



			//201

			AddSection(x - 10, y+ 181, 250, 135, "Classes");


			AddHtmlTexte(x + 10, y + 220, 150, "Primaire:");
			AddHtmlTexte(x + 10, y + 240, 150, "Secondaire: ");
			AddHtmlTexte(x + 10, y + 260, 150, "M??#$?&*tier: ");
			AddHtmlTexte(x + 10, y + 280, 150, "Armure: ");
			AddHtmlTexte(x + 125, y + 220, 100,  m_From.ClassePrimaire.Name);
			AddHtmlTexte(x + 125, y + 240, 100,  m_From.ClasseSecondaire.Name);
			AddHtmlTexte(x + 125, y + 260, 100,  m_From.Metier.Name);
			AddHtmlTexte(x + 125, y + 280, 100, m_From.Armure.ToString());

			// 402

			AddSection(x - 10, y + 317, 250, 135, "Exp??#$?&*riences");

			AddHtmlTexte(x + 10, y + 355, 150, "FE Disponible:");
			AddHtmlTexte(x + 125, y + 355, 100, m_From.FE.ToString());
			AddHtmlTexte(x + 10, y + 375, 150, "FE Attentes:");
			AddHtmlTexte(x + 125, y + 375, 100, m_From.FEAttente.ToString());
			AddHtmlTexte(x + 10, y + 395, 150, "FE Total:");
			AddHtmlTexte(x + 125, y + 395, 100, m_From.FETotal.ToString());
			AddHtmlTexte(x + 10, y + 415, 150, "Heures jou??#$?&*es:");
			AddHtmlTexte(x + 125, y + 415, 100, Math.Round(m_From.Account.TotalGameTime.TotalHours,2).ToString());


			AddSection(x - 10, y + 453, 250, 210, "Statistique");


			AddHtmlTexte(x + 10, y + 490, 150, "Force :");

			if (m_From.CanDecreaseStat(StatType.Str))
			{
				AddButton(x + 100, y + 492, 5603, 5607, 300, GumpButtonType.Reply, 0);
			}

			if (m_From.CanIncreaseStat(StatType.Str))
			{
				AddButton(x + 160, y + 492, 5601, 5605, 301, GumpButtonType.Reply, 0);
			}

			AddLabel(x + 130, y + 490, 150, m_From.Str.ToString());

			AddHtmlTexte(x + 10, y + 510, 150, "Dext??#$?&*rit??#$?&* :");

			if (m_From.CanDecreaseStat(StatType.Dex))
			{
				AddButton(x + 100, y + 512, 5603, 5607, 302, GumpButtonType.Reply, 0);
			}

			if (m_From.CanIncreaseStat(StatType.Dex))
			{
			  AddButton(x + 160, y + 512, 5601, 5605, 303, GumpButtonType.Reply, 0);
			}
			AddLabel(x + 130, y + 510, 150, m_From.Dex.ToString());

			AddHtmlTexte(x + 10, y + 530, 150, "Intelligence :");
		
			if (m_From.CanDecreaseStat(StatType.Int))
			{
			AddButton(x + 100, y + 532, 5603, 5607, 304, GumpButtonType.Reply, 0);
			}

			if (m_From.CanIncreaseStat(StatType.Int))
			{
				AddButton(x + 160, y + 532, 5601, 5605, 305, GumpButtonType.Reply, 0);
			}

			AddLabel(x + 130, y + 530, 150, m_From.Int.ToString());

			AddHtmlTexte(x + 10, y + 550, 150, "à placer :");
			AddLabel(x + 130, y + 550, 150, (225 - m_From.RawStr - m_From.RawDex - m_From.RawInt - m_From.StatAttente).ToString());

			AddHtmlTexte(x + 10, y + 570, 150, "En attente :");
			AddLabel(x + 130, y + 570, 150, m_From.StatAttente.ToString());

			AddHtmlTexte(x + 10, y + 610, 150, "Faim :");
			AddLabel(x + 130, y + 610, 150, m_From.Hunger * 5 + " / 100".ToString());

			AddHtmlTexte(x + 10, y + 630, 150, "Soif :");
			AddLabel(x + 130, y + 630, 150, m_From.Thirst * 5 + " / 100".ToString());







			AddSection(x + 241, y, 359, 452, "Talents");

			int line = 0;

			foreach (SkillName item in m_From.SkillDisponible())
			{
				AddHtmlTexte(x + 261, y + 40 + line * 25, 150, item.ToString());
				//	AddHtmlTexte(x + 525, y + 40 + line * 25, 150, m_From.Skills[item].Base.ToString("##0"));

				AddLabel(x + 525, y + 40 + line * 25, 150, m_From.Skills[item].Base.ToString());

				if (m_From.CanDecreaseSkill(item))
				{
					AddButton(x + 500, y + 40 + line * 25, 5603, 5607, 100 + (int)item, GumpButtonType.Reply, 0);
				}

				if (m_From.CanIncreaseSkill(item))
				{
					AddButton(x + 550, y + 40 + line * 25, 5601, 5605, 200 + (int)item, GumpButtonType.Reply, 0);
				}		

				line++;
			}


			line = 0;

			AddSection(x + 241, y + 453, 359, 210, "D??#$?&*votions");

			foreach (KeyValuePair<MagieType, int> item in m_From.MagicAfinity)
			{
				AddHtmlTexte(x + 261, y + 493 + line * 25, 150, item.Key.ToString() );
				AddLabel(x + 525, y + 493 + line * 25, 150, item.Value.ToString());
				line++;
			}


		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {



			if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				m_From.DecreaseSkills((SkillName)info.ButtonID - 100);

				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 200 && info.ButtonID < 300)
			{
				m_From.IncreaseSkills((SkillName)info.ButtonID - 200);

				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 300)
			{
				m_From.DecreaseStat(StatType.Str);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 301)
			{
				m_From.IncreaseStat(StatType.Str);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 302)
			{
				m_From.DecreaseStat(StatType.Dex);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 303)
			{
				m_From.IncreaseStat(StatType.Dex);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 304)
			{
				m_From.DecreaseStat(StatType.Int);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 305)
			{
				m_From.IncreaseStat(StatType.Int);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}







			/*     switch (info.ButtonID)
				 {



					 case 0:
						 {
							 if (m_GM != null)
								 m_GM.CloseGump(typeof(FicheGump));
							 else
								 m_From.CloseGump(typeof(FicheGump));

							 break;
						 }
					 case 1:
						 {
							 break;
						 }
					 case 2:
						 {
							 if (m_GM != null)
			//                     m_GM.SendGump(new FicheAptitudesGump(m_From, m_GM));
							 else
			  //                   m_From.SendGump(new FicheAptitudesGump(m_From, m_GM));

							 break;
						 }
					 case 3:
						 {
							 if (m_GM != null)
	 //                            m_GM.SendGump(new FicheBeauteGump(m_From, m_GM));
							 else
	   //                          m_From.SendGump(new FicheBeauteGump(m_From, m_GM));

							 break;
						 }
					 case 4:
						 {
							 if (m_GM != null)
	   //                          m_GM.SendGump(new FicheConnaissancesGump(m_From, m_GM));
							 else
		 //                        m_From.SendGump(new FicheConnaissancesGump(m_From, m_GM));

							 break;
						 }
					 case 9:
						 {
							 if (m_GM != null)
	  //                           m_GM.SendGump(new ChangementClasseGump(m_From, m_GM));
							 else
		//                         m_From.SendGump(new ChangementClasseGump(m_From, m_GM));

							 break;
						 }
					 case 10:
						 {
							 XP.Evolve(m_From);
							 m_From.SendGump(new FicheGump(m_From, m_GM));
							 break;
						 }
					 case 11:
						 {
							 m_From.SendGump(new ResetGump(m_From, m_GM, ResetGumpPage.Page1));
							 m_From.CloseGump(typeof(FicheGump));

							 break;
						 }
					 case 12:
						 {
							 m_From.SendGump(new ResetGump(m_From, m_GM, ResetGumpPage.Page2));
							 m_From.CloseGump(typeof(FicheGump));	

							 break;
						 }
					 case 13:
						 {
							 m_From.SendGump(new ResetGump(m_From, m_GM, ResetGumpPage.Page3));
							 m_From.CloseGump(typeof(FicheGump));

							 break;
						 }
					 case 99:
						 {
							 if (m_From.GetRace().Equals("Aucune"))
								 m_From.SendMessage("Vous ne pouvez pas changer vos statistiques");
							 else
								 m_From.SendGump(new ChoixStatGump(m_From, false));
							 break;
						 }*/
			//   }
		}
    }
}
