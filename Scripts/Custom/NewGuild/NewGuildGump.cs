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
    abstract class NewGuildBaseGump : Gump
    {
        protected Mobile m_From;
        protected NewGuildRecruterStone m_Guild;

        private const int White = 0xFFFFFF;

        public NewGuildBaseGump(Mobile from, NewGuildRecruterStone handler)
            : base(0, 0)
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
            if (targeted is PlayerMobile)
            {
                m_Guild.RemoveGuildMember((Mobile)targeted);
                from.SendMessage("Le joueur a été retiré de la guilde.");
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RemoveMobile_OnTarget));
            }
        }

        protected void RankUpMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Guild.RankUp((Mobile)targeted);
                from.SendMessage("Son rang est maintenant : " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank((Mobile)targeted)));
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RankUpMobile_OnTarget));
            }
        }

        protected void RankDownMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Guild.RankDown((Mobile)targeted);
                from.SendMessage("Son rang est maintenant : " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank((Mobile)targeted)));
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
                from.SendMessage("Le joueur a été rajouté à la guilde.");
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
        int x = 20;
        int y = 20;

        int line = 0;
        int space = 20;

        public NewGuildGump(Mobile from, NewGuildRecruterStone guild)
            : base(from, guild)
        {
            m_From = from;
            m_Guild = guild;

            from.CloseGump(typeof(NewGuildGump));

            if (m_Guild != null)
            {
                AddPage(0);

                if (m_From.AccessLevel >= AccessLevel.GameMaster || m_Guild.GetMobileRank(m_From) >= (NewGuildRecruterStone._RANKMAX - 1))
                {
                    AddBackground(0, 0, 500, 520, 5054);
                    AddAlphaRegion(10, 10, 480, 500);

                    AddHtml(x, y + (space * line++), 480, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Administration de la guilde", false, false);
                    AddTextEntry(x, y + (space * line++), 465, 160, 43, GetButtonID(9, 0), m_Guild.NewGuildTitle);

                    AddHtml(x, y + (space * line++), 480, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Description de la guilde", false, false);
                    AddTextEntry(x, y + (space * line++), 465, 160, 43, GetButtonID(9, 1), m_Guild.NewGuildDescription);
                    line += 4;

                    AddHtml(x, y + (space * line++), 480, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Rangs, titres et salaires", false, false);

                    int j = 0;

                    for (int i = 1; i <= m_Guild.newGuildRankList.Count - 1; i++)
                    {
                        AddHtml(x, y + (space * line), 60, 20, "<BASEFONT COLOR=#FFFFFF>Rang " + m_Guild.newGuildRankList[i].Rank + ": ", false, false);
                        if (m_From.AccessLevel >= AccessLevel.GameMaster)
                        {
                            AddTextEntry(x + 410, y + (space * line), 30, 20, 43, GetButtonID(11, i), m_Guild.newGuildRankList[i].Salary.ToString());
                            AddHtml(x + 445, y + (space * line), 20, 20, "<BASEFONT COLOR=#FFFFFF>po", false, false);
                        }
                        AddTextEntry(x + 53, y + (space * line++), 340, 20, 43, GetButtonID(10, i), m_Guild.newGuildRankList[i].Title);
                    }

                    line++;

                    AddHtml(x, y + (space * line++), 480, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Liste des actions", false, false);
                    AddButtonLabeled(x, y + (space * line++), GetButtonID(2, 2), "Afficher la liste des membres");
                    AddButtonLabeled(x, y + (space * line++), GetButtonID(2, 0), "Ajouter un membre");
                    AddButtonLabeled(x, y + (space * line++), GetButtonID(2, 1), "Retirer un membre");
                    AddButtonLabeled(x, y + (space * line++), GetButtonID(1, 0), "Augmenter le rang d’un membre");
                    AddButtonLabeled(x, y + (space * line++), GetButtonID(1, 1), "Diminuer le rang d’un membre");
                }
                else
                {
                    AddBackground(0, 0, 500, 280, 5054);
                    AddAlphaRegion(10, 10, 480, 260);

                    AddHtml(x, y + (space * line++), 450, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Guilde", false, false);
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
                        AddHtml(x, y + (space * line++), 450, 20, "<BASEFONT COLOR=#FFFFFF>Votre rente est déposée dans votre coffre de banque à tous les dimanches matins (Heure QC).</BASEFONT>", false, false);
                    }
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % 4;
            int index = buttonID / 4;

            if (m_From.AccessLevel >= AccessLevel.GameMaster || m_Guild.GetMobileRank(m_From) >= (NewGuildRecruterStone._RANKMAX - 1))
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

                            if (value > 5000)
                            {
                                m_From.SendMessage("Un rang ne peut dépasser 5000 pièces par semaine.");
                                value = 5000;
                            }

                            if (relay3 != null)
                                m_Guild.newGuildRankList[i].Salary = value;
                        }
                        catch
                        {
                            m_From.SendMessage("Vous avez entré un mauvais chiffre pour le salaire du rang " + i + ". N'utilisez que des nombres.");
                        }
                    }
                }
            }

            if (info.ButtonID <= 0)
                return; // Canceled

            switch (type)
            {
                case 0:
                    {
                        m_From.SendGump(new NewGuildGump((Mobile)m_From, m_Guild));
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
                                    m_From.CloseGump(typeof(NewGuildGump));
                                    m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, 0));
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

            if (type != 0)
                m_From.SendGump(new NewGuildGump((Mobile)m_From, m_Guild));
        }
    }

    class NewGuildMembersList : NewGuildBaseGump
    {
        private int currentPage;
        private Mobile currentMember;
        private List<Mobile> list;

        int x = 20;
        int y = 20;

        int line = 0;
        int space = 20;

        public static int GetButtonID2(int type, int index)
        {
            return 1 + type + (index * 10);
        }

        public NewGuildMembersList(Mobile from, NewGuildRecruterStone handler, int page)
            : base(from, handler)
        {
            this.currentPage = page;
            this.list = handler.GetMemberList();

            AddPage(0);

            AddBackground(0, 0, 385, 380, 5054);
            AddAlphaRegion(10, 10, 365, 365);

            AddHtml(x, y + (space * line++), 345, 20, "<CENTER><BASEFONT COLOR=#FFFFFF>Liste des membres de " + m_Guild.NewGuildTitle, false, false);

            for (int i = 0; i < list.Count; i++)
            {
                if (i >= ((page + 1) * 10))
                    break;
                if (i < (page * 10))
                    continue;
                Mobile m_Mobile = list[i];
                AddButton(x, y + (space * line) - 1, 4005, 4006, GetButtonID2(6, i), GumpButtonType.Reply, 0);
                AddLabel(x + 40, y + (space * line), 43, m_Mobile.Name);
                AddLabel(x + 210, y + (space * line++), 43, m_Guild.GetTitleByRank(m_Guild.GetMobileRank(m_Mobile)));
            }

            line = 16;

            AddButton(x + 325, y + (space * line), 5601, 5605, GetButtonID2(1, 0), GumpButtonType.Reply, 0);
            AddLabel(x + 160, y + (space * line), 43, "-" + currentPage.ToString() + "-");
            AddButton(x, y + (space * line), 5603, 5607, GetButtonID2(2, 0), GumpButtonType.Reply, 0);
        }

        public NewGuildMembersList(Mobile from, NewGuildRecruterStone handler, Mobile member)
            : base(from, handler)
        {
            from.CloseGump(typeof(NewGuildMembersList));
            this.currentMember = member;

            AddPage(0);

            AddBackground(0, 0, 385, 135, 5054);
            AddAlphaRegion(10, 10, 365, 115);

            AddLabel(x + 120, y + (space * line++), 43, "Menu pour " + member.Name);

            AddButtonLabeled(x, y + (space * line++), GetButtonID2(3, 0), "Augmenter au rang: " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank(member) + 1));

            AddButtonLabeled(x, y + (space * line++), GetButtonID2(4, 0), "Diminuer au rang: " + m_Guild.GetTitleByRank(m_Guild.GetMobileRank(member) - 1));

            AddButtonLabeled(x, y + (space * line++), GetButtonID2(5, 0), "Retirer de la guilde");

            AddButtonLabeled(x, y + (space * line++), GetButtonID2(7, 0), "Retour");
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % 10;
            int index = buttonID / 10;

            if (info.ButtonID <= 0)
                return;

            switch (type)
            {
                case 1:
                    {
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage + 1));
                        break;
                    }
                case 2:
                    {
                        if (currentPage > 0)
                            m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage - 1));
                        else
                            m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, 0));
                        break;
                    }
                case 3:
                    {
                        if (currentMember != null)
                            RankUpMobile_OnTarget(m_From, currentMember);
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage));
                        break;
                    }
                case 4:
                    {
                        if (currentMember != null)
                            RankDownMobile_OnTarget(m_From, currentMember);
                        m_From.SendGump(new NewGuildMembersList(m_From, m_Guild, currentPage));
                        break;
                    }
                case 5:
                    {
                        if (currentMember != null)
                            RemoveMobile_OnTarget(m_From, currentMember);
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
            }
        }
    }
}
