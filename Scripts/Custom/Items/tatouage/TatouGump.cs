using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Scripts.Commands;
using Server.Spells;
using Server.Targeting;
using Server.Misc;
using Server.Gumps;
using Server.Engines.Craft;


namespace Server.Gumps
{
    public enum TGumpPage
    {
        Page1,
        Page2,
		Page3,
		Allow
    }
	
    public class TatouageGump : Gump
    {
        private static void SendTGump(CustomPlayerMobile from, CustomPlayerMobile m,TGumpPage page,int where,int transid,KitTatouBase itemid)
        {
			if (where == 2 && transid > 0)
			{
				m.SendGump(new TatouageGump(from,m,page,where,transid,itemid));
			}
			else
			{
				from.SendGump(new TatouageGump(from,m,page,where,transid,itemid));
			}
        }

        public CustomPlayerMobile m_From;
        public CustomPlayerMobile m_M;
        public TGumpPage m_Page;
		public int m_Where;
		public int m_Transid;
		public KitTatouBase m_Item;
		public int[,] tatou = new int[90,10];
		public string[] tatourelate = new string[90];

        public TatouageGump(CustomPlayerMobile from, CustomPlayerMobile m,TGumpPage page,int where,int transid,KitTatouBase itemid)
            : base(25, 25)
        {
            m_From = from;
            m_M = m;
			m_Page = page;
			m_Where = where;
			m_Transid = transid;
			m_Item = itemid;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
						
			int i = 0;

// PAGE 1 : START
			
			i = 1; //buttonid
			tatourelate[i] = "TatouBras"; //non sur le gump
			tatou[i,1] = 0xA3FC; //gumpid
			tatou[i,3] = 1; //required
			tatou[i,4] = 0; //nexted
			i = 2; //buttonid
			tatourelate[i] = "TatouCuisse";
			tatou[i,1] = 0xA3FD;
			tatou[i,3] = 1;
			tatou[i,4] = 0;
			i = 3; //buttonid
			tatourelate[i] = "TatouVisage";
			tatou[i,1] = 0xA3FE;
			tatou[i,3] = 1;
			tatou[i,4] = 0;
			
			i = 6; //buttonid
			tatourelate[i] = "TatouFront";
			tatou[i,1] = 0xA3FF;
			tatou[i,3] = 2;
			tatou[i,4] = 0;
			i = 7; //buttonid
			tatourelate[i] = "TatouCorps";
			tatou[i,1] = 0xA400;
			tatou[i,3] = 2;
			tatou[i,4] = 0;
			i = 8; //buttonid
			tatourelate[i] = "TatouMasque";
			tatou[i,1] = 0xA401;
			tatou[i,3] = 2;
			tatou[i,4] = 0;
			
			
			i = 15; //buttonid
			tatourelate[i] = "Suivant";
			tatou[i,1] = 0;	
			tatou[i,3] = 0;
			tatou[i,4] = 1;

// PAGE 1 : FIN


// PAGE 2 : START
/*
			i = 16; //buttonid
			tatourelate[i] = "Tatoo07";
			tatou[i,1] = 12418;
			tatou[i,3] = 3;
			tatou[i,4] = 0;
			i = 17; //buttonid
			tatourelate[i] = "Tatoo08";
			tatou[i,1] = 12412;
			tatou[i,3] = 3;
			tatou[i,4] = 0;
			i = 18; //buttonid
			tatourelate[i] = "Tatoo09";
			tatou[i,1] = 12448;
			tatou[i,3] = 3;
			tatou[i,4] = 0;	
			i = 19; //buttonid
			tatourelate[i] = "Tatoo10";
			tatou[i,1] = 12450;
			tatou[i,3] = 3;
			tatou[i,4] = 0;
			
			i = 21; //buttonid
			tatourelate[i] = "Tatoo11";
			tatou[i,1] = 12410;
			tatou[i,3] = 4;
			tatou[i,4] = 0;
			i = 22; //buttonid
			tatourelate[i] = "Tatoo12";
			tatou[i,1] = 12454;
			tatou[i,3] = 4;
			tatou[i,4] = 0;
			i = 23; //buttonid
			tatourelate[i] = "Tatoo13";
			tatou[i,1] = 12449;
			tatou[i,3] = 4;
			tatou[i,4] = 0;
			
			
			i = 29; //buttonid
			tatourelate[i] = "Précédent";
			tatou[i,1] = 0;
			tatou[i,3] = 0;
			tatou[i,4] = 1;

			i = 30; //buttonid
			tatourelate[i] = "Suivant";
			tatou[i,1] = 0;
			tatou[i,3] = 0;
			tatou[i,4] = 1;
			
// PAGE 2 : FIN

// PAGE 3 : START

			i = 31; //buttonid
			tatourelate[i] = "Tatoo14";
			tatou[i,1] = 12411;
			tatou[i,3] = 5;
			tatou[i,4] = 0;
			i = 32; //buttonid
			tatourelate[i] = "Tatoo15";
			tatou[i,1] = 12456;
			tatou[i,3] = 5;
			tatou[i,4] = 0;
			i = 33; //buttonid
			tatourelate[i] = "Tatoo16";
			tatou[i,1] = 12455;
			tatou[i,3] = 5;
			tatou[i,4] = 0;
			
			i = 36; //buttonid
			tatourelate[i] = "Tatoo17";
			tatou[i,1] = 12413;
			tatou[i,3] = 6;
			tatou[i,4] = 0;
			i = 37; //buttonid
			tatourelate[i] = "Tatoo18";
			tatou[i,1] = 12453;
			tatou[i,3] = 6;
			tatou[i,4] = 0;
			i = 38; //buttonid
			tatourelate[i] = "Tatoo19";
			tatou[i,1] = 12457;
			tatou[i,3] = 6;
			tatou[i,4] = 0;
			
			
			i = 41; //buttonid
			tatourelate[i] = "AUCUN";
			tatou[i,1] = 0;
			tatou[i,3] = 0;
			tatou[i,4] = 0;
			
			
			i = 44; //buttonid
			tatourelate[i] = "Précédent";
			tatou[i,1] = 0;
			tatou[i,3] = 0;
			tatou[i,4] = 1;

// PAGE 3 : FIN
*/
			switch (m_Page)
            {
                case TGumpPage.Page1:
                {
                    AddPage(0);

                    AddBackground(36, 25, 500, 480, 9270);
                    AddBackground(54, 43, 465, 28, 3000);

                    AddLabel(230, 47, 0, "Choix du tatouage :");
						
					int originex = 102;
					int originey = 81;
					int origine2x = 390;
					int origine2y = 81;
						
					AddBackground(54, 80, 205, 22, 3000);
                    AddBackground(314, 80, 205, 22, 3000);
						
					AddLabel(originex+29,originey, 2101, "Niveau 1");
					AddLabel(origine2x,origine2y, 2101, "Niveau 2");
		
					int loccoifx = originex - 20;
					int loccoify = originey + 45;
					int loccoif2x = originex + 225;
					int loccoif2y = originey + 45;
						
					int marge = 0;
						
					i = 1;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 6;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 2;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 7;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 3;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 8;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					marge = marge + 50;
						
					marge = marge + 50;
						
					marge = marge + 50;

					i = 15;
                    AddLabel(loccoif2x + 70 ,loccoif2y+10+marge, 2101, tatourelate[i]); // Page Suivante
                    AddLabel(loccoif2x + 115,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 130,loccoif2y+10+marge, 4005, 4007, i, GumpButtonType.Reply, 0);
					
					break;
				}
				case TGumpPage.Page2:
                {
                    AddPage(0);

                    AddBackground(36, 25, 500, 480, 9270);
                    AddBackground(54, 43, 465, 28, 3000);

                    AddLabel(230, 47, 0, "Choix du tatouage :");
						
					int originex = 102;
					int originey = 81;
					int origine2x = 390;
					int origine2y = 81;
						
					AddBackground(54, 80, 205, 22, 3000);
                    AddBackground(314, 80, 205, 22, 3000);
						
					AddLabel(originex+29,originey, 2101, "Niveau 3");
					AddLabel(origine2x,origine2y, 2101, "Niveau 4");
		
					int loccoifx = originex - 20;
					int loccoify = originey + 45;
					int loccoif2x = originex + 225;
					int loccoif2y = originey + 45;
						
					int marge = 0;
						
					i = 16;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 21;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 17;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 22;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 18;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 23;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 19;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					marge = marge + 50;
						
					marge = marge + 50;
					
					i = 29;
                    AddLabel(loccoifx + 5,loccoify+10+marge, 2101, tatourelate[i]); // Page Précédente
                    AddLabel(loccoifx + 70,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx + 85,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 30;
                    AddLabel(loccoif2x + 70 ,loccoif2y+10+marge, 2101, tatourelate[i]); // Page Suivante
                    AddLabel(loccoif2x + 115,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 130,loccoif2y+10+marge, 4005, 4007, i, GumpButtonType.Reply, 0);
					
					break;
				}
				case TGumpPage.Page3:
                {
                    AddPage(0);

                    AddBackground(36, 25, 500, 480, 9270);
                    AddBackground(54, 43, 465, 28, 3000);

                    AddLabel(230, 47, 0, "Choix du tatouage :");
						
					int originex = 102;
					int originey = 81;
					int origine2x = 390;
					int origine2y = 81;
						
					AddBackground(54, 80, 205, 22, 3000);
                    AddBackground(314, 80, 205, 22, 3000);
						
					AddLabel(originex+29,originey, 2101, "Niveau 5");
					AddLabel(origine2x,origine2y, 2101, "Niveau 6");
		
					int loccoifx = originex - 20;
					int loccoify = originey + 45;
					int loccoif2x = originex + 225;
					int loccoif2y = originey + 45;
						
					int marge = 0;
						
					i = 31;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 36;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 32;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 37;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					i = 33;
					AddItem( loccoifx-15,loccoify+marge, tatou[i,1]);
                    AddLabel(loccoifx + 50 ,loccoify+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoifx + 115,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx+ 130,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					i = 38;
					AddItem( loccoif2x,loccoif2y+marge, tatou[i,1]);
                    AddLabel(loccoif2x + 65 ,loccoif2y+10+marge, 2101, tatourelate[i]);
                    AddLabel(loccoif2x + 130,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x+ 145,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);

					marge = marge + 50;
						
					marge = marge + 50;
						
					marge = marge + 50;
					
					i = 41;
                    AddLabel(loccoif2x - 90,loccoif2y+10+marge, 2101, tatourelate[i]); // AUCUN
                    AddLabel(loccoif2x - 35,loccoif2y+10+marge, 2101, ":");
                    AddButton(loccoif2x - 20,loccoif2y+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);
						
					marge = marge + 50;

					i = 44;
                    AddLabel(loccoifx + 5,loccoify+10+marge, 2101, tatourelate[i]); // Page Précédente
                    AddLabel(loccoifx + 70,loccoify+10+marge, 2101, ":");
                    AddButton(loccoifx + 85,loccoify+10+marge, 4014, 4016, i, GumpButtonType.Reply, 0);
					
					break;
				}
                case TGumpPage.Allow:
				{
                    AddPage(0);
					int movex = 150;
					int movey = 150;
                    AddBackground(36+movex, 25+movey, 369, 170, 9270);
                    AddBackground(54+movex, 43+movey, 334, 28, 3000);
						
					i = m_Transid;					 
                    AddLabel(77+movex, 47+movey, 0, "Quelqu'un tente de vous faire ce tatouage : ");					
					AddItem(195+movex,80+movey, tatou[i,1]);
                    AddLabel(250+movex, 90+movey, 2101, tatourelate[i]);
                    AddLabel(135+movex, 137+movey, 2101, "Non");					
                    AddLabel(245+movex, 137+movey, 2101, "Oui");
                    AddButton(160+movex,137+movey, 4014, 4016, 85, GumpButtonType.Reply, 0);
					AddButton(270+movex,137+movey, 4014, 4016, 86, GumpButtonType.Reply, 0);
					
					break;
				}
			}


		}
		
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			bool Tatouage = (int)m_From.FETotal > 100;
			int buttonID = info.ButtonID;

			int draked = 0;
			int enough = 0;
			int outop=0;
						
		//	if (Tatouage < tatou[buttonID,3])
		//	{
		//		enough = 1;
		//	}

			if (m_Where == 2 && enough == 0 && tatou[buttonID,4] == 0 && buttonID > 0  && draked == 0)
			{
				outop=1;
				
				if (m_Transid == 0)
				{
					m_From.SendMessage(String.Format("En attente de l'acceptation de votre tatouage par la cible..."));
					SendTGump(m_From, m_M, TGumpPage.Allow,m_Where,buttonID,m_Item);
				}
				else
				{
					if (buttonID == 86)
					{
						m_From.SendMessage(String.Format("La personne que vous venez de cibler vient d'accepter votre tatouage"));
						outop=0;
					}
					if (outop == 1)
					{
						m_From.SendMessage(String.Format("La personne que vous venez de cibler vient de refuser votre tatouage"));
					}
				}
			}
			
			
			if (draked == 0 && tatou[buttonID,4] == 0 && enough == 0 && buttonID > 0 && outop == 0)
			{
				if (m_Transid > 0)
				{
					buttonID = m_Transid;
				}
				int hue;
				hue = 0;
				try 
				{
					Item item22;
					item22 = m_M.FindItemOnLayer(Layer.InnerTorso);
					hue = item22.Hue;
					item22.Delete();
					
				}
				catch
				{
				}
				switch (tatou[buttonID,1])
				{
					case 0xA3FC: m_M.AddItem(new TatouBras(hue));break;
					case 0xA3FD: m_M.AddItem(new TatouCuisse(hue));break;
					case 0xA3FE: m_M.AddItem(new TatouVisage(hue));break;
					case 0xA3FF: m_M.AddItem(new TatouFront(hue));break;
					case 0xA400: m_M.AddItem(new TatouCorps(hue));break;
					case 0xA401: m_M.AddItem(new TatouMasque(hue));break;
					
				}
				
		//		m_From.PlaySound(583);
				m_Item.UsesRemaining = m_Item.UsesRemaining - 1;
				if (m_Item.UsesRemaining < 1)
				{
					m_From.SendMessage("Vous avez brisé votre outil");
					m_Item.Delete();
				}
			}
			else
			{					
				if (enough == 1)
				{
					m_From.SendMessage(String.Format("Vous avez {0} en tatouage , il vous faut au moins {1} pour réaliser ce tatouage", Tatouage, tatou[buttonID,3]));
				}
				if (draked == 1)
				{
					m_From.SendMessage(String.Format("Cette race ne peut avoir de tatouage"));
				}
				if (buttonID == 15)
				{
					SendTGump(m_From, m_M, TGumpPage.Page2,m_Where,m_Transid,m_Item);
				}
				if (buttonID == 29)
				{
					SendTGump(m_From, m_M, TGumpPage.Page1,m_Where,m_Transid,m_Item);
				}
				if (buttonID == 30)
				{
					SendTGump(m_From, m_M, TGumpPage.Page3,m_Where,m_Transid,m_Item);
				}
				if (buttonID == 44)
				{
					SendTGump(m_From, m_M, TGumpPage.Page2,m_Where,m_Transid,m_Item);
				}
			}

        }
		
		
	}	
}
