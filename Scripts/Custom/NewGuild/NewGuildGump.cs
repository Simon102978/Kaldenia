using System;
using System.Collections;
using System.Collections.Generic;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Commands;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Custom.System
{
    abstract class NewGuildBaseGump : BaseProjectMGump
    {
        protected CustomPlayerMobile m_From;
        protected GuildRecruter m_Guild;

        private const int White = 0xFFFFFF;

        public NewGuildBaseGump(CustomPlayerMobile from, GuildRecruter handler)
            : base(handler.NewGuildTitle, 490, 480)
        {
            m_From = from;
            m_Guild = handler;
        }

        public void AddButtonLabeled(int x, int y, int buttonID, string text)
        {
            AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 35, y, 240, 20, text, false, false);
        }

        protected void RemoveMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is CustomPlayerMobile)
            {
                m_Guild.RemoveGuildMember((CustomPlayerMobile)targeted);
                from.SendMessage("Le joueur a ??#$?&*t??#$?&* retir??#$?&* de la guilde.");
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RemoveMobile_OnTarget));
            }
        }

        protected void RankUpMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is CustomPlayerMobile)
            {
                m_Guild.RankUp((CustomPlayerMobile)targeted);
                from.SendMessage("Son rang est maintenant : " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank((CustomPlayerMobile)targeted)));
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RankUpMobile_OnTarget));
            }
        }

        protected void RankDownMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is CustomPlayerMobile)
            {
                m_Guild.RankDown((CustomPlayerMobile)targeted);
                from.SendMessage("Son rang est maintenant : " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank((CustomPlayerMobile)targeted)));
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RankDownMobile_OnTarget));
            }
        }

        protected void AjouterMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Guild.AddGuildMember((Mobile)targeted);
                from.SendMessage("Le joueur a ??#$?&*t??#$?&* rajout??#$?&* à la guilde.");
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AjouterMobile_OnTarget));
            }
        }

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * 4);
        }
    }

    class NewGuildGump : NewGuildBaseGump
    {
        int line = 0;
        int space = 20;

        public NewGuildGump(CustomPlayerMobile from, GuildRecruter guild)
            : base(from, guild)
        {

			int x = XBase + 20;
			int y = YBase ;

			m_From = from;
            m_Guild = guild;

            from.CloseGump(typeof(NewGuildGump));

            if (m_Guild != null)
            {
                AddPage(0);

                if (m_From.AccessLevel >= AccessLevel.GameMaster || m_Guild.GetMobileRank(m_From) >= (GuildRecruter._RANKMAX - 1))
                {
					//     AddBackground(0, 0, 500, 520, 5054);
					//      AddAlphaRegion(10, 10, 480, 500);

					AddSection(x - 20 , y, 520, 90, "Nom");

					line += 2;

					AddTextEntryBg(x, y + (space * line++), 480, 30, 0, GetButtonID(9, 0), m_Guild.NewGuildTitle);
					line += 2;

					AddSection(x - 20, y + (space * line) -9, 520, 130, "Description");
					line += 2;

					//	AddTextEntry(x, y + (space * line++), 465, 160, 43, GetButtonID(9, 1), m_Guild.NewGuildDescription);

					AddTextEntryBg(x, y + (space * line) - 9, 480, 70, 0, GetButtonID(9, 1), m_Guild.NewGuildDescription);
                    line += 4;

					/* 
					 line++;*/

					AddSection(x - 20, y + (space * line) +2 , 259, 300, "Informations");
					line += 2;
					int line2 = line;

					AddHtmlTexteColored(x, y + (space * line++), 300, "Nombre de membres: " + m_Guild.Members.Count, "#FFFFFF");
			//		AddHtmlTexteColored(x, y + (space * line++), 100, "Nombre de membres: " + m_Guild.Getsal, "#FFFFFF");

					AddSection(x + 241, y + (space * (line2 - 2)) +2, 260, 300, "Actions");
					
					AddButtonHtlml(x + 260, y + (space * line2++), GetButtonID(2, 2), "Liste des membres","#FFFFFF");
					AddButtonHtlml(x + 260, y + (space * line2++), GetButtonID(2, 3), "Rangs, titres et salaires", "#FFFFFF");
					AddButtonHtlml(x + 260, y + (space * line2++), GetButtonID(2, 0), "Ajouter un membre", "#FFFFFF");
					AddButtonHtlml(x + 260, y + (space * line2++), GetButtonID(2, 1), "Retirer un membre", "#FFFFFF");
					AddButtonHtlml(x + 260, y + (space * line2++), GetButtonID(1, 0), "Augmenter le rang", "#FFFFFF");
					AddButtonHtlml(x + 260, y + (space * line2++), GetButtonID(1, 1), "Diminuer le rang", "#FFFFFF");
				}
                else
                {
					AddBackground(x - 20 , y , 520, 520, 9270);

					line++;

                    AddHtml(x, y + (space * line++), 450, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>" + m_Guild.NewGuildTitle, false, false);

                    AddHtml(x, y + (space * line++), 450, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Description<BASEFONT></CENTER>", false, false);

                    AddHtml(x, y + (space * line), 450, 80, m_Guild.NewGuildDescription, true, true);
                    line += 5;

                    if (m_Guild.GetMobileRank(m_From) == -1)
                    {
                        AddButtonLabeled(x, y + (space * line++), GetButtonID(3, 0), "<BASEFONT COLOR=#FFFFFF>Je veux devenir membre de la guilde</BASEFONT>");
                    }
                    else
                    {
                        AddButtonLabeled(x, y + (space * line++), GetButtonID(3, 1), "<BASEFONT COLOR=#FFFFFF>Je veux quitter la guilde</BASEFONT>");
                        line++;
                        AddHtml(x, y + (space * line++), 450, 20, "<BASEFONT COLOR=#FFFFFF>Votre titre est " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank(m_From)) + " (" + "Rang " + m_Guild.GetMobileRank(m_From) + ")</BASEFONT>", false, false);
                        AddHtml(x, y + (space * line++), 450, 20, "<BASEFONT COLOR=#FFFFFF>Votre rente est de " + m_Guild.GetSalaryByRank(m_Guild.GetMobileRank(m_From)) + " pièces d'or par semaine.</BASEFONT>", false, false);
                        AddHtml(x, y + (space * line++), 450, 45, $"<BASEFONT COLOR=#FFFFFF>Votre rente sera d??#$?&*pos??#$?&*e dans votre coffre de banque le {CustomPersistence.ProchainePay.ToLongDateString()}.</BASEFONT>", false, false);
                    }
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % 4;
            int index = buttonID / 4;
			bool retourGump = true;

            if (m_From.AccessLevel >= AccessLevel.GameMaster || m_Guild.GetMobileRank(m_From) >= (GuildRecruter._RANKMAX - 1))
            {
                TextRelay relay = info.GetTextEntry(GetButtonID(9, 0));
                if (relay != null)
                {
                    if (relay.Text != null && relay.Text != "")
                    {
                        m_Guild.NewGuildTitle = relay.Text;
                    }
                }

                relay = info.GetTextEntry(GetButtonID(9, 1));
                if (relay != null)
                {
                    if (relay.Text != null && relay.Text != "")
                    {
                        m_Guild.NewGuildDescription = relay.Text;
                    }
                }

            }

            if (info.ButtonID <= 0)
                return; // Canceled

            switch (type)
            {
                case 0:
                    {
                        m_From.SendGump(new NewGuildGump((CustomPlayerMobile)m_From, m_Guild));
                        break;
                    }

                case 1: // Misc. buttons
                    {
                        switch (index)
                        {
                            case 0: // Augmenter le rang d’un joueur
                                {
                                    m_From.SendMessage("Augmenter le rang d’un joueur");
                                    m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RankUpMobile_OnTarget));
                                    break;
                                }
                            case 1: // Diminuer le rang d’un joueur
                                {
                                    m_From.SendMessage("Diminuer le rang d’un joueur");
                                    m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RankDownMobile_OnTarget));
                                    break;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        switch (index)
                        {
                            case 0:
                                {
                                    m_From.SendMessage("Ajouter un membre à la liste des joueurs dans la guilde.");
                                    m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AjouterMobile_OnTarget));
                                    break;
                                }
                            case 1:
                                {
                                    m_From.SendMessage("Retirer un joueur de la liste des joueurs dans la guilde");
                                    m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RemoveMobile_OnTarget));
                                    break;
                                }
                            case 2:
                                {
                                    m_From.CloseGump(typeof(NewGuildBaseGump));
                                    m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, 0));
									retourGump = false;
                                    break;
                                }
							case 3:
								{
									m_From.CloseGump(typeof(NewGuildBaseGump));
									m_From.SendGump(new NewGuildTitleGump(m_From, m_Guild));
									retourGump = false;
									break;
								}
						}
                        break;
                    }
                case 3:
                    {
                        switch (index)
                        {
                            case 0: // Je veux joindre la guilde
                                {
                                    m_From.SendMessage("Vous joignez la guilde.");
                                    m_Guild.AddGuildMember((Mobile)m_From);
                                    break;
                                }
                            case 1: // Je veux quitter la guilde
                                {
                                    m_From.SendMessage("Vous quittez la guilde.");
                                    m_Guild.RemoveGuildMember((Mobile)m_From);
                                    break;
                                }
                        }
                        break;
                    }
            }

            if (type != 0 && retourGump)
                m_From.SendGump(new NewGuildGump((CustomPlayerMobile)m_From, m_Guild));
        }
    }

	class NewGuildTitleGump : NewGuildBaseGump
	{
	//	private List<CustomGuildMember> list;

		//    int x = 20;
		//    int y = 20;

		int line = 0;
		int space = 30;

		public static int GetButtonID2(int type, int index)
		{
			return 1 + type + (index * 10);
		}

		public NewGuildTitleGump(CustomPlayerMobile from, GuildRecruter handler)
			: base(from, handler)
		{
			int x = XBase + 20;
			int y = YBase + 40;

//			this.list = handler.Members;

			AddPage(0);

			AddSection(x - 20, YBase, 520, 520, "Titres et salaires");

			if (m_Guild != null)
			{		
				int j = 0;

				for (int i = 1; i <= m_Guild.newGuildRankList.Count - 1; i++)
				{
					AddHtml(x, y + (space * line), 60, 20, "<BASEFONT COLOR=#FFFFFF>Rang " + m_Guild.newGuildRankList[i].Rank + ": ", false, false);

					AddTextEntryBg(x, y + (space * line), 340, 25, 0, GetButtonID(10, i), m_Guild.newGuildRankList[i].Title);

					if (m_From.AccessLevel >= AccessLevel.GameMaster)
					{
						AddTextEntryBg(x + 375, y + (space * line), 65, 25, 0, GetButtonID(11, i), m_Guild.newGuildRankList[i].Salary.ToString());
					//	AddTextEntry(x + 410, y + (space * line), 30, 20, 43, GetButtonID(11, i), m_Guild.newGuildRankList[i].Salary.ToString());
						AddHtml(x + 445, y + (space * line), 20, 20, "<BASEFONT COLOR=#FFFFFF>po", false, false);
					}
					//AddTextEntry(x + 53, y + (space * line++), 340, 20, 43, GetButtonID(10, i), m_Guild.newGuildRankList[i].Title);

					line++;
				}
				AddButton(x + 200, y + 425, 1, 1147);		
			}

		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			int buttonID = info.ButtonID - 1;
			int type1 = buttonID % 10;
			int index = buttonID / 10;

			if (info.ButtonID <= 0)
			{
				m_From.SendGump(new NewGuildGump(m_From, m_Guild));
				return;
			}

			if (m_From.AccessLevel >= AccessLevel.GameMaster)
			{
				int count = m_Guild.newGuildRankList.Count - 1;
				for (int i = 1; i <= count; i++)
				{
					TextRelay relay2 = info.GetTextEntry(GetButtonID(10, i));

					if (relay2 != null)
						m_Guild.newGuildRankList[i].Title = relay2.Text;

					try
					{
						TextRelay relay3 = info.GetTextEntry(GetButtonID(11, i));

						int value = Convert.ToInt32(relay3.Text);

						if (value > 50000)
						{
							m_From.SendMessage("Un rang ne peut d??#$?&*passer 50000 pièces par semaine.");
							value = 50000;
						}

						if (relay3 != null)
						{
							m_Guild.UpdateSalaryRank(i, value);

						}
							
					}
					catch
					{
						m_From.SendMessage("Vous avez entr??#$?&* un mauvais chiffre pour le salaire du rang " + i + ". N'utilisez que des nombres.");
					}
				}
			}
		}
	}

	class NewGuildMembersList : NewGuildBaseGump
    {
        private int currentPage;
        private CustomGuildMember currentMember;
        private List<CustomGuildMember> list;

    //    int x = 20;
    //    int y = 20;

        int line = 0;
        int space = 20;

        public static int GetButtonID2(int type, int index)
        {
            return 1 + type + (index * 10);
        }

        public NewGuildMembersList(CustomPlayerMobile from, GuildRecruter handler, int page)
            : base(from, handler)
        {
			int x = XBase + 20;
			int y = YBase + 40;

			this.currentPage = page;
            this.list = handler.Members;

            AddPage(0);

			AddSection(x - 20, YBase, 520, 520, "Liste des membres");

			//          AddBackground(0, 0, 385, 380, 5054);
			//          AddAlphaRegion(10, 10, 365, 365);

			//    AddHtml(x, y + (space * line++), 345, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Liste des membres de " + m_Guild.NewGuildTitle, false, false);

			for (int i = 0; i < list.Count; i++)
            {
                if (i >= ((page + 1) * 20))
                    break;
                if (i < (page * 20))
                    continue;
				CustomGuildMember m_Mobile = list[i];

				AddButtonHtlml(x, y + (space * line) - 1, GetButtonID2(6, i), m_Mobile.GetName(), "#FFFFFF");

				if (m_Mobile.CustomRank != -2)
				{
					AddHtmlTexteColored(x + 300, y + (space * line++), 200, m_Guild.GetTitleByRank(m_Mobile.CustomRank), "#FFFFFF");
				}
			}
		
			AddButton(x, y + 428, GetButtonID2(2, 0), 4506);

			AddHtmlTexteColored(x + 235, y + 445, 50, "-" + currentPage.ToString() + "-", "#FFFFFF");

			AddButton(x + 430, y + 428, GetButtonID2(1, 0), 4502); // ou 470

        }

        public NewGuildMembersList(CustomPlayerMobile from, GuildRecruter handler, CustomGuildMember member)
            : base(from, handler)
        {
            from.CloseGump(typeof(NewGuildMembersList));
            this.currentMember = member;

			int x = XBase + 20;
			int y = YBase + 40;
			space = 25;

			AddPage(0);

			AddSection(x - 20, YBase, 520, 520, member.GetName());

			//		AddLabel(x + 120, y + (space * line++), 43, "Menu pour " + member.Name);



			if (member.CustomRank != -2)
			{
				AddHtmlTexteColored(x, y + (space * line++) - 1, 300, $"Salaire: {currentMember.Salaire}", "#FFFFFF");
				AddHtmlTexteColored(x, y + (space * line++) - 1, 300, "Titre: " + currentMember.Titre, "#FFFFFF");
				line++;
				AddButtonHtlml(x, y + (space * line++) - 1, GetButtonID2(3, 0), "Augmenter au rang: " + m_Guild.GetTitleByRank(member.CustomRank + 1), "#FFFFFF");
				AddButtonHtlml(x, y + (space * line++) - 1, GetButtonID2(4, 0), "Diminuer au rang: " + m_Guild.GetTitleByRank(member.CustomRank - 1), "#FFFFFF");
				AddButtonHtlml(x, y + (space * line++) - 1, GetButtonID2(8, 0), "Rang personnalis??#$?&*", "#FFFFFF");
			}
			else
			{
				AddHtmlTexteColored(x, y + (space * line) - 1, 75, $"Salaire:", "#FFFFFF");
				AddTextEntryBg(x + 100, y + (space * line++), 65, 25, 0, 1, currentMember.Salaire.ToString());


				AddHtmlTexteColored(x, y + (space * line) - 1, 75, "Titre: ", "#FFFFFF");
				AddTextEntryBg(x + 100, y + (space * line++), 200, 25, 0, 2, currentMember.Titre);
				AddButtonHtlml(x, y + (space * line++) - 1, GetButtonID2(8, 0), "Rang standard", "#FFFFFF");


			}
		
		
			AddButtonHtlml(x, y + (space * line++) - 1, GetButtonID2(5, 0), "Retirer de la guilde", "#FFFFFF");
			AddButtonHtlml(x, y + (space * line++) - 1, GetButtonID2(7, 0), "Retour", "#FFFFFF");
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type1 = buttonID % 10;
            int index = buttonID / 10;

			if (info.ButtonID <= 0 && currentMember == null)
			{
				m_From.SendGump(new NewGuildGump(m_From, m_Guild));
				return;
			}
			else if (info.ButtonID <= 0)
			{
				m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage));
				return;
			}

			try
			{
				TextRelay relay1 = info.GetTextEntry(1);
				if (relay1 != null)
				{
					int value = Convert.ToInt32(relay1.Text);

					if (value > 50000)
					{
						m_From.SendMessage("Un rang ne peut d??#$?&*passer 50000 pièces par semaine.");
						value = 50000;
					}

				
					currentMember.Salaire = value;

				}

			}
			catch
			{ }


			TextRelay relay2 = info.GetTextEntry(2);

			if (relay2 != null)
				currentMember.Titre = relay2.Text;

			switch (type1)
            {
                case 1:
                    {
						int pageIn = currentPage + 1;

						if (m_Guild.Members.Count < pageIn * 20)
						{
							pageIn--;
						}

                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, pageIn));
                        break;
                    }
                case 2:
                    {
                        if (currentPage > 0)
						{
							m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage - 1));
						}                          
                        else
						{
							m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, 0));
						}
                          
                        break;
                    }
                case 3:
                    {
                        if (currentMember != null)
						{
							currentMember.IncreaseRank(m_Guild);
							//RankUpMobile_OnTarget(m_From, currentMember);
						}       
						
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentMember));

                        break;
                    }
                case 4:
                    {
                        if (currentMember != null)
						{
							currentMember.DecreaseRank(m_Guild);
						//	RankDownMobile_OnTarget(m_From, currentMember);
						}
                            
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentMember));

                        break;
                    }
                case 5:
                    {
                        if (currentMember != null)
						{
							m_Guild.Members.Remove(currentMember);
						}                    
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage));

                        break;
                    }
                case 6:
                    {
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, list[index]));
                        break;
                    }
                case 7:
                    {
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage));
                        break;
                    }
				case 8:
					{
						if (currentMember.CustomRank == -2)
						{
							currentMember.CustomRank = 0;
						}
						else
						{
							currentMember.CustomRank = -2;
						}

						
						m_From.SendGump(new NewGuildMembersList(m_From, m_Guild,currentMember));
						break;
					}
			}
		}
    }
}
