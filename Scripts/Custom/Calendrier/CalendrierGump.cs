using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
	public enum CalGumpPage
    {
        Page1,
        Page2,
		Page3,
		Page4,
		Page5
    }
    public class CalendrierGump : Gump
    {
		private static void SendCalGump(Mobile from, CalGumpPage page, Calendrier calendrier)
		{
			from.SendGump(new CalendrierGump(from, page, calendrier));
   		}
        
		private Mobile m_From;
        private Calendrier m_Calendrier;
		public CalGumpPage m_Page;

        public CalendrierGump(Mobile from, CalGumpPage page, Calendrier calendrier)
            : base(0, 0)
        {
            m_From = from;
            m_Calendrier = calendrier;
			m_Page = page;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
			
			switch (m_Page)
            {
                case CalGumpPage.Page1:
                {
            		AddPage(0);
			
					//Background Principal
            		AddBackground(22, 16, 700, 570, 9270);
			
					//Label pour Calendrier de Teilia
					AddBackground(55, 43, 635, 28, 3000);
					AddLabel(317, 47, 0, "Calendrier de Teilia");
			
					//Saison : Été
					AddBackground(70, 86, 605, 28, 3000);
					AddLabel(338, 90, 0, "Saison : Été");
					
					int joursx = 102;
					int joursy = 158;
					
					//Mois : Thermidor
					AddBackground(joursx, joursy-28, 540, 28, 3000);
					AddLabel(326, joursy-24, 0, "Mois : Thermidor");
						
					//Jours pour Mois Thermidor
					AddBackground(joursx, joursy, 60, 28, 3000);
					AddLabel(joursx+10, joursy+4, 0, "Primidi");
					AddBackground(joursx+60, joursy, 60, 28, 3000);
					AddLabel(joursx+74, joursy+4, 0, "Duodi");
					AddBackground(joursx+120, joursy, 60, 28, 3000);
					AddLabel(joursx+136, joursy+4, 0, "Tridi");
					AddBackground(joursx+180, joursy, 60, 28, 3000);
					AddLabel(joursx+187, joursy+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy, 60, 28, 3000);
					AddLabel(joursx+249, joursy+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy, 60, 28, 3000);
					AddLabel(joursx+310, joursy+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy, 60, 28, 3000);
					AddLabel(joursx+370, joursy+4, 0, "Septidi");
					AddBackground(joursx+420, joursy, 60, 28, 3000);
					AddLabel(joursx+433, joursy+4, 0, "Octidi");
					AddBackground(joursx+480, joursy, 60, 28, 3000);
					AddLabel(joursx+490, joursy+4, 0, "Novindi");
					
					//Dates 01 à 09 pour le mois Thermidor
					AddBackground(joursx, joursy+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy+32, 0, "01");
					AddBackground(joursx+60, joursy+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy+32, 0, "02");
					AddBackground(joursx+120, joursy+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy+32, 0, "03");
					AddBackground(joursx+180, joursy+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy+32, 0, "04");
					AddBackground(joursx+240, joursy+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy+32, 0, "05");
					AddBackground(joursx+300, joursy+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy+32, 0, "06");
					AddBackground(joursx+360, joursy+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy+32, 0, "07");
					AddBackground(joursx+420, joursy+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy+32, 0, "08");
					AddBackground(joursx+480, joursy+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy+32, 0, "09");
					
					//Dates 10 à 18 pour le mois Thermidor
					AddBackground(joursx, joursy+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy+60, 0, "10");
					AddBackground(joursx+60, joursy+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy+60, 0, "11");
					AddBackground(joursx+120, joursy+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy+60, 0, "12");
					AddBackground(joursx+180, joursy+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy+60, 0, "13");
					AddBackground(joursx+240, joursy+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy+60, 0, "14");
					AddBackground(joursx+300, joursy+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy+60, 0, "15");
					AddBackground(joursx+360, joursy+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy+60, 0, "16");
					AddBackground(joursx+420, joursy+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy+60, 0, "17");
					AddBackground(joursx+480, joursy+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy+60, 0, "18");
					
					//Dates 19 à 27 pour le mois Thermidor
					AddBackground(joursx, joursy+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy+88, 0, "19");
					AddBackground(joursx+60, joursy+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy+88, 0, "20");
					AddBackground(joursx+120, joursy+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy+88, 0, "21");
					AddBackground(joursx+180, joursy+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy+88, 0, "22");
					AddBackground(joursx+240, joursy+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy+88, 0, "23");
					AddBackground(joursx+300, joursy+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy+88, 0, "24");
					AddBackground(joursx+360, joursy+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy+88, 0, "25");
					AddBackground(joursx+420, joursy+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy+88, 0, "26");
					AddBackground(joursx+480, joursy+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy+88, 0, "27");
					
					//Dates 28 à 36 pour le mois Thermidor
					AddBackground(joursx, joursy+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy+116, 0, "28");
					AddBackground(joursx+60, joursy+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy+116, 0, "29");
					AddBackground(joursx+120, joursy+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy+116, 0, "30");
					AddBackground(joursx+180, joursy+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy+116, 0, "31");
					AddBackground(joursx+240, joursy+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy+116, 0, "32");
					AddBackground(joursx+300, joursy+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy+116, 0, "33");
					AddBackground(joursx+360, joursy+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy+116, 0, "34");
					AddBackground(joursx+420, joursy+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy+116, 0, "35");
					AddBackground(joursx+480, joursy+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy+116, 0, "36");
					
					//Date 37 pour le mois Thermidor
					AddBackground(joursx, joursy+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy+144, 0, "37");
					AddBackground(joursx+60, joursy+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy+144, 0, "");
					AddBackground(joursx+120, joursy+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy+144, 0, "");
					AddBackground(joursx+180, joursy+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy+144, 0, "");
					AddBackground(joursx+240, joursy+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy+144, 0, "");
					AddBackground(joursx+300, joursy+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy+144, 0, "");
					AddBackground(joursx+360, joursy+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy+144, 0, "");
					AddBackground(joursx+420, joursy+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy+144, 0, "");
					AddBackground(joursx+480, joursy+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy+144, 0, "");
										
					int joursy2 = 366;
					
					//Mois : Fructidor
					AddBackground(joursx, joursy2-28, 540, 28, 3000);
					AddLabel(327, joursy2-24, 0, "Mois : Fructidor");
						
					//Jours pour Mois Fructidor
					AddBackground(joursx, joursy2, 60, 28, 3000);
					AddLabel(joursx+10, joursy2+4, 0, "Primidi");
					AddBackground(joursx+60, joursy2, 60, 28, 3000);
					AddLabel(joursx+74, joursy2+4, 0, "Duodi");
					AddBackground(joursx+120, joursy2, 60, 28, 3000);
					AddLabel(joursx+136, joursy2+4, 0, "Tridi");
					AddBackground(joursx+180, joursy2, 60, 28, 3000);
					AddLabel(joursx+187, joursy2+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy2, 60, 28, 3000);
					AddLabel(joursx+249, joursy2+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy2, 60, 28, 3000);
					AddLabel(joursx+310, joursy2+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy2, 60, 28, 3000);
					AddLabel(joursx+370, joursy2+4, 0, "Septidi");
					AddBackground(joursx+420, joursy2, 60, 28, 3000);
					AddLabel(joursx+433, joursy2+4, 0, "Octidi");
					AddBackground(joursx+480, joursy2, 60, 28, 3000);
					AddLabel(joursx+490, joursy2+4, 0, "Novindi");
					
					//Dates 01 à 08 pour le mois Fructidor
					AddBackground(joursx, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+32, 0, "");
					AddBackground(joursx+60, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+32, 0, "01");
					AddBackground(joursx+120, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+32, 0, "02");
					AddBackground(joursx+180, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+32, 0, "03");
					AddBackground(joursx+240, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+32, 0, "04");
					AddBackground(joursx+300, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+32, 0, "05");
					AddBackground(joursx+360, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+32, 0, "06");
					AddBackground(joursx+420, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+32, 0, "07");
					AddBackground(joursx+480, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+32, 0, "08");
					
					//Dates 09 à 17 pour le mois Fructidor
					AddBackground(joursx, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+60, 0, "09");
					AddBackground(joursx+60, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+60, 0, "10");
					AddBackground(joursx+120, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+60, 0, "11");
					AddBackground(joursx+180, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+60, 0, "12");
					AddBackground(joursx+240, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+60, 0, "13");
					AddBackground(joursx+300, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+60, 0, "14");
					AddBackground(joursx+360, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+60, 0, "15");
					AddBackground(joursx+420, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+60, 0, "16");
					AddBackground(joursx+480, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+60, 0, "17");
					
					//Dates 18 à 26 pour le mois Fructidor
					AddBackground(joursx, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+88, 0, "18");
					AddBackground(joursx+60, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+88, 0, "19");
					AddBackground(joursx+120, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+88, 0, "20");
					AddBackground(joursx+180, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+88, 0, "21");
					AddBackground(joursx+240, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+88, 0, "22");
					AddBackground(joursx+300, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+88, 0, "23");
					AddBackground(joursx+360, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+88, 0, "24");
					AddBackground(joursx+420, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+88, 0, "25");
					AddBackground(joursx+480, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+88, 0, "26");
					
					//Dates 27 à 35 pour le mois Fructidor
					AddBackground(joursx, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+116, 0, "27");
					AddBackground(joursx+60, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+116, 0, "28");
					AddBackground(joursx+120, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+116, 0, "29");
					AddBackground(joursx+180, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+116, 0, "30");
					AddBackground(joursx+240, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+116, 0, "31");
					AddBackground(joursx+300, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+116, 0, "32");
					AddBackground(joursx+360, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+116, 0, "33");
					AddBackground(joursx+420, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+116, 0, "34");
					AddBackground(joursx+480, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+116, 0, "35");
					
					//Dates 36 à 37 pour le mois Fructidor
					AddBackground(joursx, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+144, 0, "36");
					AddBackground(joursx+60, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+144, 0, "37");
					AddBackground(joursx+120, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+144, 0, "");
					AddBackground(joursx+180, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+144, 0, "");
					AddBackground(joursx+240, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+144, 0, "");
					AddBackground(joursx+300, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+144, 0, "");
					AddBackground(joursx+360, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+144, 0, "");
					AddBackground(joursx+420, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+144, 0, "");
					AddBackground(joursx+480, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+144, 0, "");
					
					//Bouton pour aller Saison Automne
					AddLabel(560, 545, 2101, "Saison Automne");
					AddLabel(660, 545, 2101, ":");
					AddButton(675, 545, 4005, 4007, 1, GumpButtonType.Reply, 0);
					
					break;
				}
				case CalGumpPage.Page2:
                {
            		AddPage(0);
			
					//Background Principal
            		AddBackground(22, 16, 700, 570, 9270);
			
					//Label pour Calendrier de Teilia
					AddBackground(55, 43, 635, 28, 3000);
					AddLabel(317, 47, 0, "Calendrier de Teilia");
			
					//Saison : Automne
					AddBackground(70, 86, 605, 28, 3000);
					AddLabel(323, 90, 0, "Saison : Automne");
					
					int joursx = 102;
					int joursy = 158;
					
					//Mois : Brumaire
					AddBackground(joursx, joursy-28, 540, 28, 3000);
					AddLabel(327, joursy-24, 0, "Mois : Brumaire");
						
					//Jours pour Mois Brumaire
					AddBackground(joursx, joursy, 60, 28, 3000);
					AddLabel(joursx+10, joursy+4, 0, "Primidi");
					AddBackground(joursx+60, joursy, 60, 28, 3000);
					AddLabel(joursx+74, joursy+4, 0, "Duodi");
					AddBackground(joursx+120, joursy, 60, 28, 3000);
					AddLabel(joursx+136, joursy+4, 0, "Tridi");
					AddBackground(joursx+180, joursy, 60, 28, 3000);
					AddLabel(joursx+187, joursy+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy, 60, 28, 3000);
					AddLabel(joursx+249, joursy+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy, 60, 28, 3000);
					AddLabel(joursx+310, joursy+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy, 60, 28, 3000);
					AddLabel(joursx+370, joursy+4, 0, "Septidi");
					AddBackground(joursx+420, joursy, 60, 28, 3000);
					AddLabel(joursx+433, joursy+4, 0, "Octidi");
					AddBackground(joursx+480, joursy, 60, 28, 3000);
					AddLabel(joursx+490, joursy+4, 0, "Novindi");
					
					//Dates 01 à 07 pour le mois Brumaire
					AddBackground(joursx, joursy+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy+32, 0, "");
					AddBackground(joursx+60, joursy+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy+32, 0, "");
					AddBackground(joursx+120, joursy+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy+32, 0, "01");
					AddBackground(joursx+180, joursy+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy+32, 0, "02");
					AddBackground(joursx+240, joursy+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy+32, 0, "03");
					AddBackground(joursx+300, joursy+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy+32, 0, "04");
					AddBackground(joursx+360, joursy+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy+32, 0, "05");
					AddBackground(joursx+420, joursy+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy+32, 0, "06");
					AddBackground(joursx+480, joursy+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy+32, 0, "07");
					
					//Dates 08 à 16 pour le mois Brumaire
					AddBackground(joursx, joursy+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy+60, 0, "08");
					AddBackground(joursx+60, joursy+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy+60, 0, "09");
					AddBackground(joursx+120, joursy+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy+60, 0, "10");
					AddBackground(joursx+180, joursy+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy+60, 0, "11");
					AddBackground(joursx+240, joursy+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy+60, 0, "12");
					AddBackground(joursx+300, joursy+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy+60, 0, "13");
					AddBackground(joursx+360, joursy+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy+60, 0, "14");
					AddBackground(joursx+420, joursy+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy+60, 0, "15");
					AddBackground(joursx+480, joursy+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy+60, 0, "16");
					
					//Dates 17 à 25 pour le mois Brumaire
					AddBackground(joursx, joursy+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy+88, 0, "17");
					AddBackground(joursx+60, joursy+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy+88, 0, "18");
					AddBackground(joursx+120, joursy+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy+88, 0, "19");
					AddBackground(joursx+180, joursy+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy+88, 0, "20");
					AddBackground(joursx+240, joursy+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy+88, 0, "21");
					AddBackground(joursx+300, joursy+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy+88, 0, "22");
					AddBackground(joursx+360, joursy+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy+88, 0, "23");
					AddBackground(joursx+420, joursy+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy+88, 0, "24");
					AddBackground(joursx+480, joursy+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy+88, 0, "25");
					
					//Dates 26 à 34 pour le mois Brumaire
					AddBackground(joursx, joursy+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy+116, 0, "26");
					AddBackground(joursx+60, joursy+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy+116, 0, "27");
					AddBackground(joursx+120, joursy+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy+116, 0, "28");
					AddBackground(joursx+180, joursy+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy+116, 0, "29");
					AddBackground(joursx+240, joursy+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy+116, 0, "30");
					AddBackground(joursx+300, joursy+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy+116, 0, "31");
					AddBackground(joursx+360, joursy+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy+116, 0, "32");
					AddBackground(joursx+420, joursy+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy+116, 0, "33");
					AddBackground(joursx+480, joursy+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy+116, 0, "34");
					
					//Dates 35 à 36 pour le mois Brumaire
					AddBackground(joursx, joursy+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy+144, 0, "35");
					AddBackground(joursx+60, joursy+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy+144, 0, "36");
					AddBackground(joursx+120, joursy+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy+144, 0, "");
					AddBackground(joursx+180, joursy+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy+144, 0, "");
					AddBackground(joursx+240, joursy+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy+144, 0, "");
					AddBackground(joursx+300, joursy+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy+144, 0, "");
					AddBackground(joursx+360, joursy+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy+144, 0, "");
					AddBackground(joursx+420, joursy+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy+144, 0, "");
					AddBackground(joursx+480, joursy+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy+144, 0, "");
										
					int joursy2 = 366;
					
					//Mois : Frimaire
					AddBackground(joursx, joursy2-28, 540, 28, 3000);
					AddLabel(329, joursy2-24, 0, "Mois : Frimaire");
						
					//Jours pour Mois Frimaire
					AddBackground(joursx, joursy2, 60, 28, 3000);
					AddLabel(joursx+10, joursy2+4, 0, "Primidi");
					AddBackground(joursx+60, joursy2, 60, 28, 3000);
					AddLabel(joursx+74, joursy2+4, 0, "Duodi");
					AddBackground(joursx+120, joursy2, 60, 28, 3000);
					AddLabel(joursx+136, joursy2+4, 0, "Tridi");
					AddBackground(joursx+180, joursy2, 60, 28, 3000);
					AddLabel(joursx+187, joursy2+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy2, 60, 28, 3000);
					AddLabel(joursx+249, joursy2+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy2, 60, 28, 3000);
					AddLabel(joursx+310, joursy2+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy2, 60, 28, 3000);
					AddLabel(joursx+370, joursy2+4, 0, "Septidi");
					AddBackground(joursx+420, joursy2, 60, 28, 3000);
					AddLabel(joursx+433, joursy2+4, 0, "Octidi");
					AddBackground(joursx+480, joursy2, 60, 28, 3000);
					AddLabel(joursx+490, joursy2+4, 0, "Novindi");
					
					//Dates 01 à 07 pour le mois Frimaire
					AddBackground(joursx, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+32, 0, "");
					AddBackground(joursx+60, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+32, 0, "");
					AddBackground(joursx+120, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+32, 0, "01");
					AddBackground(joursx+180, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+32, 0, "02");
					AddBackground(joursx+240, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+32, 0, "03");
					AddBackground(joursx+300, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+32, 0, "04");
					AddBackground(joursx+360, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+32, 0, "05");
					AddBackground(joursx+420, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+32, 0, "06");
					AddBackground(joursx+480, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+32, 0, "07");
					
					//Dates 08 à 16 pour le mois Frimaire
					AddBackground(joursx, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+60, 0, "08");
					AddBackground(joursx+60, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+60, 0, "09");
					AddBackground(joursx+120, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+60, 0, "10");
					AddBackground(joursx+180, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+60, 0, "11");
					AddBackground(joursx+240, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+60, 0, "12");
					AddBackground(joursx+300, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+60, 0, "13");
					AddBackground(joursx+360, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+60, 0, "14");
					AddBackground(joursx+420, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+60, 0, "15");
					AddBackground(joursx+480, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+60, 0, "16");
					
					//Dates 17 à 25 pour le mois Frimaire
					AddBackground(joursx, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+88, 0, "17");
					AddBackground(joursx+60, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+88, 0, "18");
					AddBackground(joursx+120, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+88, 0, "19");
					AddBackground(joursx+180, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+88, 0, "20");
					AddBackground(joursx+240, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+88, 0, "21");
					AddBackground(joursx+300, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+88, 0, "22");
					AddBackground(joursx+360, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+88, 0, "23");
					AddBackground(joursx+420, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+88, 0, "24");
					AddBackground(joursx+480, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+88, 0, "25");
					
					//Dates 26 à 34 pour le mois Frimaire
					AddBackground(joursx, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+116, 0, "26");
					AddBackground(joursx+60, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+116, 0, "27");
					AddBackground(joursx+120, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+116, 0, "28");
					AddBackground(joursx+180, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+116, 0, "29");
					AddBackground(joursx+240, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+116, 0, "30");
					AddBackground(joursx+300, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+116, 0, "31");
					AddBackground(joursx+360, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+116, 0, "32");
					AddBackground(joursx+420, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+116, 0, "33");
					AddBackground(joursx+480, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+116, 0, "34");
					
					//Date 35 pour le mois Frimaire
					AddBackground(joursx, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+144, 0, "35");
					AddBackground(joursx+60, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+144, 0, "");
					AddBackground(joursx+120, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+144, 0, "");
					AddBackground(joursx+180, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+144, 0, "");
					AddBackground(joursx+240, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+144, 0, "");
					AddBackground(joursx+300, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+144, 0, "");
					AddBackground(joursx+360, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+144, 0, "");
					AddBackground(joursx+420, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+144, 0, "");
					AddBackground(joursx+480, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+144, 0, "");
					
					//Bouton pour aller Saison Été
					AddLabel(55, 545, 2101, "Saison Été");
					AddLabel(155, 545, 2101, ":");
					AddButton(170, 545, 4014, 4016, 2, GumpButtonType.Reply, 0);
					
					//Bouton pour aller Saison Hiver
					AddLabel(560, 545, 2101, "Saison Hiver");
					AddLabel(660, 545, 2101, ":");
					AddButton(675, 545, 4005, 4007, 3, GumpButtonType.Reply, 0);
					
					break;
				}
				case CalGumpPage.Page3:
                {
            		AddPage(0);
			
					//Background Principal
            		AddBackground(22, 16, 700, 570, 9270);
			
					//Label pour Calendrier de Teilia
					AddBackground(55, 43, 635, 28, 3000);
					AddLabel(317, 47, 0, "Calendrier de Teilia");
			
					//Saison : Hiver
					AddBackground(70, 86, 605, 28, 3000);
					AddLabel(332, 90, 0, "Saison : Hiver");
					
					int joursx = 102;
					int joursy = 158;
					
					//Mois : Pluviose
					AddBackground(joursx, joursy-28, 540, 28, 3000);
					AddLabel(330, joursy-24, 0, "Mois : Pluviose");
						
					//Jours pour Mois Pluviose
					AddBackground(joursx, joursy, 60, 28, 3000);
					AddLabel(joursx+10, joursy+4, 0, "Primidi");
					AddBackground(joursx+60, joursy, 60, 28, 3000);
					AddLabel(joursx+74, joursy+4, 0, "Duodi");
					AddBackground(joursx+120, joursy, 60, 28, 3000);
					AddLabel(joursx+136, joursy+4, 0, "Tridi");
					AddBackground(joursx+180, joursy, 60, 28, 3000);
					AddLabel(joursx+187, joursy+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy, 60, 28, 3000);
					AddLabel(joursx+249, joursy+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy, 60, 28, 3000);
					AddLabel(joursx+310, joursy+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy, 60, 28, 3000);
					AddLabel(joursx+370, joursy+4, 0, "Septidi");
					AddBackground(joursx+420, joursy, 60, 28, 3000);
					AddLabel(joursx+433, joursy+4, 0, "Octidi");
					AddBackground(joursx+480, joursy, 60, 28, 3000);
					AddLabel(joursx+490, joursy+4, 0, "Novindi");
					
					//Dates 01 à 07 pour le mois Pluviose
					AddBackground(joursx, joursy+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy+32, 0, "");
					AddBackground(joursx+60, joursy+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy+32, 0, "");
					AddBackground(joursx+120, joursy+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy+32, 0, "01");
					AddBackground(joursx+180, joursy+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy+32, 0, "02");
					AddBackground(joursx+240, joursy+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy+32, 0, "03");
					AddBackground(joursx+300, joursy+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy+32, 0, "04");
					AddBackground(joursx+360, joursy+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy+32, 0, "05");
					AddBackground(joursx+420, joursy+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy+32, 0, "06");
					AddBackground(joursx+480, joursy+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy+32, 0, "07");
					
					//Dates 08 à 16 pour le mois Pluviose
					AddBackground(joursx, joursy+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy+60, 0, "08");
					AddBackground(joursx+60, joursy+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy+60, 0, "09");
					AddBackground(joursx+120, joursy+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy+60, 0, "10");
					AddBackground(joursx+180, joursy+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy+60, 0, "11");
					AddBackground(joursx+240, joursy+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy+60, 0, "12");
					AddBackground(joursx+300, joursy+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy+60, 0, "13");
					AddBackground(joursx+360, joursy+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy+60, 0, "14");
					AddBackground(joursx+420, joursy+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy+60, 0, "15");
					AddBackground(joursx+480, joursy+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy+60, 0, "16");
					
					//Dates 17 à 25 pour le mois Pluviose
					AddBackground(joursx, joursy+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy+88, 0, "17");
					AddBackground(joursx+60, joursy+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy+88, 0, "18");
					AddBackground(joursx+120, joursy+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy+88, 0, "19");
					AddBackground(joursx+180, joursy+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy+88, 0, "20");
					AddBackground(joursx+240, joursy+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy+88, 0, "21");
					AddBackground(joursx+300, joursy+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy+88, 0, "22");
					AddBackground(joursx+360, joursy+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy+88, 0, "23");
					AddBackground(joursx+420, joursy+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy+88, 0, "24");
					AddBackground(joursx+480, joursy+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy+88, 0, "25");
					
					//Dates 26 à 34 pour le mois Pluviose
					AddBackground(joursx, joursy+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy+116, 0, "26");
					AddBackground(joursx+60, joursy+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy+116, 0, "27");
					AddBackground(joursx+120, joursy+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy+116, 0, "28");
					AddBackground(joursx+180, joursy+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy+116, 0, "29");
					AddBackground(joursx+240, joursy+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy+116, 0, "30");
					AddBackground(joursx+300, joursy+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy+116, 0, "31");
					AddBackground(joursx+360, joursy+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy+116, 0, "32");
					AddBackground(joursx+420, joursy+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy+116, 0, "33");
					AddBackground(joursx+480, joursy+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy+116, 0, "34");
					
					//Date 35 pour le mois Pluviose
					AddBackground(joursx, joursy+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy+144, 0, "35");
					AddBackground(joursx+60, joursy+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy+144, 0, "");
					AddBackground(joursx+120, joursy+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy+144, 0, "");
					AddBackground(joursx+180, joursy+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy+144, 0, "");
					AddBackground(joursx+240, joursy+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy+144, 0, "");
					AddBackground(joursx+300, joursy+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy+144, 0, "");
					AddBackground(joursx+360, joursy+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy+144, 0, "");
					AddBackground(joursx+420, joursy+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy+144, 0, "");
					AddBackground(joursx+480, joursy+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy+144, 0, "");
										
					int joursy2 = 366;
					
					//Mois : Nivose
					AddBackground(joursx, joursy2-28, 540, 28, 3000);
					AddLabel(333, joursy2-24, 0, "Mois : Nivose");
						
					//Jours pour Mois Nivose
					AddBackground(joursx, joursy2, 60, 28, 3000);
					AddLabel(joursx+10, joursy2+4, 0, "Primidi");
					AddBackground(joursx+60, joursy2, 60, 28, 3000);
					AddLabel(joursx+74, joursy2+4, 0, "Duodi");
					AddBackground(joursx+120, joursy2, 60, 28, 3000);
					AddLabel(joursx+136, joursy2+4, 0, "Tridi");
					AddBackground(joursx+180, joursy2, 60, 28, 3000);
					AddLabel(joursx+187, joursy2+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy2, 60, 28, 3000);
					AddLabel(joursx+249, joursy2+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy2, 60, 28, 3000);
					AddLabel(joursx+310, joursy2+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy2, 60, 28, 3000);
					AddLabel(joursx+370, joursy2+4, 0, "Septidi");
					AddBackground(joursx+420, joursy2, 60, 28, 3000);
					AddLabel(joursx+433, joursy2+4, 0, "Octidi");
					AddBackground(joursx+480, joursy2, 60, 28, 3000);
					AddLabel(joursx+490, joursy2+4, 0, "Novindi");
					
					//Dates 01 à 08 pour le mois Nivose
					AddBackground(joursx, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+32, 0, "");
					AddBackground(joursx+60, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+32, 0, "01");
					AddBackground(joursx+120, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+32, 0, "02");
					AddBackground(joursx+180, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+32, 0, "03");
					AddBackground(joursx+240, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+32, 0, "04");
					AddBackground(joursx+300, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+32, 0, "05");
					AddBackground(joursx+360, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+32, 0, "06");
					AddBackground(joursx+420, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+32, 0, "07");
					AddBackground(joursx+480, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+32, 0, "08");
					
					//Dates 09 à 17 pour le mois Nivose
					AddBackground(joursx, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+60, 0, "09");
					AddBackground(joursx+60, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+60, 0, "10");
					AddBackground(joursx+120, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+60, 0, "11");
					AddBackground(joursx+180, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+60, 0, "12");
					AddBackground(joursx+240, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+60, 0, "13");
					AddBackground(joursx+300, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+60, 0, "14");
					AddBackground(joursx+360, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+60, 0, "15");
					AddBackground(joursx+420, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+60, 0, "16");
					AddBackground(joursx+480, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+60, 0, "17");
					
					//Dates 18 à 26 pour le mois Nivose
					AddBackground(joursx, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+88, 0, "18");
					AddBackground(joursx+60, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+88, 0, "19");
					AddBackground(joursx+120, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+88, 0, "20");
					AddBackground(joursx+180, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+88, 0, "21");
					AddBackground(joursx+240, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+88, 0, "22");
					AddBackground(joursx+300, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+88, 0, "23");
					AddBackground(joursx+360, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+88, 0, "24");
					AddBackground(joursx+420, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+88, 0, "25");
					AddBackground(joursx+480, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+88, 0, "26");
					
					//Dates 27 à 35 pour le mois Nivose
					AddBackground(joursx, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+116, 0, "27");
					AddBackground(joursx+60, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+116, 0, "28");
					AddBackground(joursx+120, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+116, 0, "29");
					AddBackground(joursx+180, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+116, 0, "30");
					AddBackground(joursx+240, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+116, 0, "31");
					AddBackground(joursx+300, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+116, 0, "32");
					AddBackground(joursx+360, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+116, 0, "33");
					AddBackground(joursx+420, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+116, 0, "34");
					AddBackground(joursx+480, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+116, 0, "35");
					
					//Date 36 pour le mois Nivose
					AddBackground(joursx, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+144, 0, "36");
					AddBackground(joursx+60, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+144, 0, "");
					AddBackground(joursx+120, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+144, 0, "");
					AddBackground(joursx+180, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+144, 0, "");
					AddBackground(joursx+240, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+144, 0, "");
					AddBackground(joursx+300, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+144, 0, "");
					AddBackground(joursx+360, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+144, 0, "");
					AddBackground(joursx+420, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+144, 0, "");
					AddBackground(joursx+480, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+144, 0, "");
					
					//Bouton pour aller Saison Automne
					AddLabel(55, 545, 2101, "Saison Automne");
					AddLabel(155, 545, 2101, ":");
					AddButton(170, 545, 4014, 4016, 4, GumpButtonType.Reply, 0);
					
					//Bouton pour aller Saison Abysse
					AddLabel(560, 545, 2101, "Saison Abysse");
					AddLabel(660, 545, 2101, ":");
					AddButton(675, 545, 4005, 4007, 5, GumpButtonType.Reply, 0);
					
					break;
				}
				case CalGumpPage.Page4:
                {
            		AddPage(0);
			
					//Background Principal
            		AddBackground(22, 16, 700, 570, 9270);
			
					//Label pour Calendrier de Teilia
					AddBackground(55, 43, 635, 28, 3000);
					AddLabel(317, 47, 0, "Calendrier de Teilia");
			
					//Saison : Abysse
					AddBackground(70, 86, 605, 28, 3000);
					AddLabel(326, 90, 0, "Saison : Abysse");
					
					int joursx = 102;
					int joursy = 158;
					
					//Mois : Ventor
					AddBackground(joursx, joursy-28, 540, 28, 3000);
					AddLabel(332, joursy-24, 0, "Mois : Ventor");
						
					//Jours pour Mois Ventor
					AddBackground(joursx, joursy, 60, 28, 3000);
					AddLabel(joursx+10, joursy+4, 0, "Primidi");
					AddBackground(joursx+60, joursy, 60, 28, 3000);
					AddLabel(joursx+74, joursy+4, 0, "Duodi");
					AddBackground(joursx+120, joursy, 60, 28, 3000);
					AddLabel(joursx+136, joursy+4, 0, "Tridi");
					AddBackground(joursx+180, joursy, 60, 28, 3000);
					AddLabel(joursx+187, joursy+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy, 60, 28, 3000);
					AddLabel(joursx+249, joursy+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy, 60, 28, 3000);
					AddLabel(joursx+310, joursy+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy, 60, 28, 3000);
					AddLabel(joursx+370, joursy+4, 0, "Septidi");
					AddBackground(joursx+420, joursy, 60, 28, 3000);
					AddLabel(joursx+433, joursy+4, 0, "Octidi");
					AddBackground(joursx+480, joursy, 60, 28, 3000);
					AddLabel(joursx+490, joursy+4, 0, "Novindi");
					
					//Dates 01 à 08 pour le mois Ventor
					AddBackground(joursx, joursy+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy+32, 0, "");
					AddBackground(joursx+60, joursy+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy+32, 0, "01");
					AddBackground(joursx+120, joursy+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy+32, 0, "02");
					AddBackground(joursx+180, joursy+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy+32, 0, "03");
					AddBackground(joursx+240, joursy+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy+32, 0, "04");
					AddBackground(joursx+300, joursy+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy+32, 0, "05");
					AddBackground(joursx+360, joursy+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy+32, 0, "06");
					AddBackground(joursx+420, joursy+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy+32, 0, "07");
					AddBackground(joursx+480, joursy+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy+32, 0, "08");
					
					//Dates 09 à 17 pour le mois Ventor
					AddBackground(joursx, joursy+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy+60, 0, "09");
					AddBackground(joursx+60, joursy+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy+60, 0, "10");
					AddBackground(joursx+120, joursy+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy+60, 0, "11");
					AddBackground(joursx+180, joursy+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy+60, 0, "12");
					AddBackground(joursx+240, joursy+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy+60, 0, "13");
					AddBackground(joursx+300, joursy+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy+60, 0, "14");
					AddBackground(joursx+360, joursy+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy+60, 0, "15");
					AddBackground(joursx+420, joursy+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy+60, 0, "16");
					AddBackground(joursx+480, joursy+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy+60, 0, "17");
					
					//Dates 18 à 26 pour le mois Ventor
					AddBackground(joursx, joursy+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy+88, 0, "18");
					AddBackground(joursx+60, joursy+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy+88, 0, "19");
					AddBackground(joursx+120, joursy+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy+88, 0, "20");
					AddBackground(joursx+180, joursy+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy+88, 0, "21");
					AddBackground(joursx+240, joursy+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy+88, 0, "22");
					AddBackground(joursx+300, joursy+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy+88, 0, "23");
					AddBackground(joursx+360, joursy+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy+88, 0, "24");
					AddBackground(joursx+420, joursy+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy+88, 0, "25");
					AddBackground(joursx+480, joursy+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy+88, 0, "26");
					
					//Dates 27 à 35 pour le mois Ventor
					AddBackground(joursx, joursy+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy+116, 0, "27");
					AddBackground(joursx+60, joursy+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy+116, 0, "28");
					AddBackground(joursx+120, joursy+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy+116, 0, "29");
					AddBackground(joursx+180, joursy+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy+116, 0, "30");
					AddBackground(joursx+240, joursy+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy+116, 0, "31");
					AddBackground(joursx+300, joursy+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy+116, 0, "32");
					AddBackground(joursx+360, joursy+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy+116, 0, "33");
					AddBackground(joursx+420, joursy+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy+116, 0, "34");
					AddBackground(joursx+480, joursy+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy+116, 0, "35");
					
					//Aucune date pour le mois Ventor
					AddBackground(joursx, joursy+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy+144, 0, "");
					AddBackground(joursx+60, joursy+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy+144, 0, "");
					AddBackground(joursx+120, joursy+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy+144, 0, "");
					AddBackground(joursx+180, joursy+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy+144, 0, "");
					AddBackground(joursx+240, joursy+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy+144, 0, "");
					AddBackground(joursx+300, joursy+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy+144, 0, "");
					AddBackground(joursx+360, joursy+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy+144, 0, "");
					AddBackground(joursx+420, joursy+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy+144, 0, "");
					AddBackground(joursx+480, joursy+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy+144, 0, "");
										
					int joursy2 = 366;
					
					//Mois : Mortor
					AddBackground(joursx, joursy2-28, 540, 28, 3000);
					AddLabel(331, joursy2-24, 0, "Mois : Mortor");
						
					//Jours pour Mois Mortor
					AddBackground(joursx, joursy2, 60, 28, 3000);
					AddLabel(joursx+10, joursy2+4, 0, "Primidi");
					AddBackground(joursx+60, joursy2, 60, 28, 3000);
					AddLabel(joursx+74, joursy2+4, 0, "Duodi");
					AddBackground(joursx+120, joursy2, 60, 28, 3000);
					AddLabel(joursx+136, joursy2+4, 0, "Tridi");
					AddBackground(joursx+180, joursy2, 60, 28, 3000);
					AddLabel(joursx+187, joursy2+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy2, 60, 28, 3000);
					AddLabel(joursx+249, joursy2+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy2, 60, 28, 3000);
					AddLabel(joursx+310, joursy2+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy2, 60, 28, 3000);
					AddLabel(joursx+370, joursy2+4, 0, "Septidi");
					AddBackground(joursx+420, joursy2, 60, 28, 3000);
					AddLabel(joursx+433, joursy2+4, 0, "Octidi");
					AddBackground(joursx+480, joursy2, 60, 28, 3000);
					AddLabel(joursx+490, joursy2+4, 0, "Novindi");
					
					//Dates 01 à 09 pour le mois Mortor
					AddBackground(joursx, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+32, 0, "01");
					AddBackground(joursx+60, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+32, 0, "02");
					AddBackground(joursx+120, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+32, 0, "03");
					AddBackground(joursx+180, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+32, 0, "04");
					AddBackground(joursx+240, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+32, 0, "05");
					AddBackground(joursx+300, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+32, 0, "06");
					AddBackground(joursx+360, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+32, 0, "07");
					AddBackground(joursx+420, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+32, 0, "08");
					AddBackground(joursx+480, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+32, 0, "09");
					
					//Dates 10 à 18 pour le mois Mortor
					AddBackground(joursx, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+60, 0, "10");
					AddBackground(joursx+60, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+60, 0, "11");
					AddBackground(joursx+120, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+60, 0, "12");
					AddBackground(joursx+180, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+60, 0, "13");
					AddBackground(joursx+240, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+60, 0, "14");
					AddBackground(joursx+300, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+60, 0, "15");
					AddBackground(joursx+360, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+60, 0, "16");
					AddBackground(joursx+420, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+60, 0, "17");
					AddBackground(joursx+480, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+60, 0, "18");
					
					//Dates 19 à 27 pour le mois Mortor
					AddBackground(joursx, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+88, 0, "19");
					AddBackground(joursx+60, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+88, 0, "20");
					AddBackground(joursx+120, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+88, 0, "21");
					AddBackground(joursx+180, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+88, 0, "22");
					AddBackground(joursx+240, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+88, 0, "23");
					AddBackground(joursx+300, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+88, 0, "24");
					AddBackground(joursx+360, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+88, 0, "25");
					AddBackground(joursx+420, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+88, 0, "26");
					AddBackground(joursx+480, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+88, 0, "27");
					
					//Dates 28 à 35 pour le mois Mortor
					AddBackground(joursx, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+116, 0, "28");
					AddBackground(joursx+60, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+116, 0, "29");
					AddBackground(joursx+120, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+116, 0, "30");
					AddBackground(joursx+180, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+116, 0, "31");
					AddBackground(joursx+240, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+116, 0, "32");
					AddBackground(joursx+300, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+116, 0, "33");
					AddBackground(joursx+360, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+116, 0, "34");
					AddBackground(joursx+420, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+116, 0, "35");
					AddBackground(joursx+480, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+116, 0, "");
					
					//Aucune Date pour le mois Mortor
					AddBackground(joursx, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+144, 0, "");
					AddBackground(joursx+60, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+144, 0, "");
					AddBackground(joursx+120, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+144, 0, "");
					AddBackground(joursx+180, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+144, 0, "");
					AddBackground(joursx+240, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+144, 0, "");
					AddBackground(joursx+300, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+144, 0, "");
					AddBackground(joursx+360, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+144, 0, "");
					AddBackground(joursx+420, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+144, 0, "");
					AddBackground(joursx+480, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+144, 0, "");
					
					//Bouton pour aller Saison Hiver
					AddLabel(55, 545, 2101, "Saison Hiver");
					AddLabel(155, 545, 2101, ":");
					AddButton(170, 545, 4014, 4016, 6, GumpButtonType.Reply, 0);
					
					//Bouton pour aller Saison Printemps
					AddLabel(560, 545, 2101, "Saison Printemps");
					AddLabel(660, 545, 2101, ":");
					AddButton(675, 545, 4005, 4007, 7, GumpButtonType.Reply, 0);
					
					break;
				}
				case CalGumpPage.Page5:
                {
            		AddPage(0);
			
					//Background Principal
            		AddBackground(22, 16, 700, 570, 9270);
			
					//Label pour Calendrier de Teilia
					AddBackground(55, 43, 635, 28, 3000);
					AddLabel(317, 47, 0, "Calendrier de Teilia");
			
					//Saison : Printemps
					AddBackground(70, 86, 605, 28, 3000);
					AddLabel(318, 90, 0, "Saison : Printemps");
					
					int joursx = 102;
					int joursy = 158;
					
					//Mois : Germinal
					AddBackground(joursx, joursy-28, 540, 28, 3000);
					AddLabel(330, joursy-24, 0, "Mois : Germinal");
						
					//Jours pour Mois Germinal
					AddBackground(joursx, joursy, 60, 28, 3000);
					AddLabel(joursx+10, joursy+4, 0, "Primidi");
					AddBackground(joursx+60, joursy, 60, 28, 3000);
					AddLabel(joursx+74, joursy+4, 0, "Duodi");
					AddBackground(joursx+120, joursy, 60, 28, 3000);
					AddLabel(joursx+136, joursy+4, 0, "Tridi");
					AddBackground(joursx+180, joursy, 60, 28, 3000);
					AddLabel(joursx+187, joursy+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy, 60, 28, 3000);
					AddLabel(joursx+249, joursy+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy, 60, 28, 3000);
					AddLabel(joursx+310, joursy+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy, 60, 28, 3000);
					AddLabel(joursx+370, joursy+4, 0, "Septidi");
					AddBackground(joursx+420, joursy, 60, 28, 3000);
					AddLabel(joursx+433, joursy+4, 0, "Octidi");
					AddBackground(joursx+480, joursy, 60, 28, 3000);
					AddLabel(joursx+490, joursy+4, 0, "Novindi");
					
					//Date 01 pour le mois Germinal
					AddBackground(joursx, joursy+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy+32, 0, "");
					AddBackground(joursx+60, joursy+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy+32, 0, "");
					AddBackground(joursx+120, joursy+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy+32, 0, "");
					AddBackground(joursx+180, joursy+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy+32, 0, "");
					AddBackground(joursx+240, joursy+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy+32, 0, "");
					AddBackground(joursx+300, joursy+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy+32, 0, "");
					AddBackground(joursx+360, joursy+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy+32, 0, "");
					AddBackground(joursx+420, joursy+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy+32, 0, "");
					AddBackground(joursx+480, joursy+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy+32, 0, "01");
					
					//Dates 02 à 10 pour le mois Germinal
					AddBackground(joursx, joursy+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy+60, 0, "02");
					AddBackground(joursx+60, joursy+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy+60, 0, "03");
					AddBackground(joursx+120, joursy+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy+60, 0, "04");
					AddBackground(joursx+180, joursy+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy+60, 0, "05");
					AddBackground(joursx+240, joursy+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy+60, 0, "06");
					AddBackground(joursx+300, joursy+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy+60, 0, "07");
					AddBackground(joursx+360, joursy+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy+60, 0, "08");
					AddBackground(joursx+420, joursy+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy+60, 0, "09");
					AddBackground(joursx+480, joursy+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy+60, 0, "10");
					
					//Dates 11 à 19 pour le mois Germinal
					AddBackground(joursx, joursy+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy+88, 0, "11");
					AddBackground(joursx+60, joursy+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy+88, 0, "12");
					AddBackground(joursx+120, joursy+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy+88, 0, "13");
					AddBackground(joursx+180, joursy+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy+88, 0, "14");
					AddBackground(joursx+240, joursy+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy+88, 0, "15");
					AddBackground(joursx+300, joursy+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy+88, 0, "16");
					AddBackground(joursx+360, joursy+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy+88, 0, "17");
					AddBackground(joursx+420, joursy+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy+88, 0, "18");
					AddBackground(joursx+480, joursy+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy+88, 0, "19");
					
					//Dates 20 à 28 pour le mois Germinal
					AddBackground(joursx, joursy+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy+116, 0, "20");
					AddBackground(joursx+60, joursy+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy+116, 0, "21");
					AddBackground(joursx+120, joursy+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy+116, 0, "22");
					AddBackground(joursx+180, joursy+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy+116, 0, "23");
					AddBackground(joursx+240, joursy+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy+116, 0, "24");
					AddBackground(joursx+300, joursy+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy+116, 0, "25");
					AddBackground(joursx+360, joursy+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy+116, 0, "26");
					AddBackground(joursx+420, joursy+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy+116, 0, "27");
					AddBackground(joursx+480, joursy+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy+116, 0, "28");
					
					//Dates 29 à 36 pour le mois Germinal
					AddBackground(joursx, joursy+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy+144, 0, "29");
					AddBackground(joursx+60, joursy+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy+144, 0, "30");
					AddBackground(joursx+120, joursy+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy+144, 0, "31");
					AddBackground(joursx+180, joursy+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy+144, 0, "32");
					AddBackground(joursx+240, joursy+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy+144, 0, "33");
					AddBackground(joursx+300, joursy+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy+144, 0, "34");
					AddBackground(joursx+360, joursy+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy+144, 0, "35");
					AddBackground(joursx+420, joursy+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy+144, 0, "36");
					AddBackground(joursx+480, joursy+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy+144, 0, "");
										
					int joursy2 = 366;
					
					//Mois : Floréal
					AddBackground(joursx, joursy2-28, 540, 28, 3000);
					AddLabel(333, joursy2-24, 0, "Mois : Floréal");
						
					//Jours pour Mois Floréal
					AddBackground(joursx, joursy2, 60, 28, 3000);
					AddLabel(joursx+10, joursy2+4, 0, "Primidi");
					AddBackground(joursx+60, joursy2, 60, 28, 3000);
					AddLabel(joursx+74, joursy2+4, 0, "Duodi");
					AddBackground(joursx+120, joursy2, 60, 28, 3000);
					AddLabel(joursx+136, joursy2+4, 0, "Tridi");
					AddBackground(joursx+180, joursy2, 60, 28, 3000);
					AddLabel(joursx+187, joursy2+4, 0, "Quartidi");
					AddBackground(joursx+240, joursy2, 60, 28, 3000);
					AddLabel(joursx+249, joursy2+4, 0, "Quintidi");
					AddBackground(joursx+300, joursy2, 60, 28, 3000);
					AddLabel(joursx+310, joursy2+4, 0, "Sextidi");
					AddBackground(joursx+360, joursy2, 60, 28, 3000);
					AddLabel(joursx+370, joursy2+4, 0, "Septidi");
					AddBackground(joursx+420, joursy2, 60, 28, 3000);
					AddLabel(joursx+433, joursy2+4, 0, "Octidi");
					AddBackground(joursx+480, joursy2, 60, 28, 3000);
					AddLabel(joursx+490, joursy2+4, 0, "Novindi");
					
					//Date 01 pour le mois Floréal
					AddBackground(joursx, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+32, 0, "");
					AddBackground(joursx+60, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+32, 0, "");
					AddBackground(joursx+120, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+32, 0, "");
					AddBackground(joursx+180, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+32, 0, "");
					AddBackground(joursx+240, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+32, 0, "");
					AddBackground(joursx+300, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+32, 0, "");
					AddBackground(joursx+360, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+32, 0, "");
					AddBackground(joursx+420, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+32, 0, "");
					AddBackground(joursx+480, joursy2+28, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+32, 0, "01");
					
					//Dates 02 à 10 pour le mois Floréal
					AddBackground(joursx, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+60, 0, "02");
					AddBackground(joursx+60, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+60, 0, "03");
					AddBackground(joursx+120, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+60, 0, "04");
					AddBackground(joursx+180, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+60, 0, "05");
					AddBackground(joursx+240, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+60, 0, "06");
					AddBackground(joursx+300, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+60, 0, "07");
					AddBackground(joursx+360, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+60, 0, "08");
					AddBackground(joursx+420, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+60, 0, "09");
					AddBackground(joursx+480, joursy2+56, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+60, 0, "10");
					
					//Dates 11 à 19 pour le mois Floréal
					AddBackground(joursx, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+88, 0, "11");
					AddBackground(joursx+60, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+88, 0, "12");
					AddBackground(joursx+120, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+88, 0, "13");
					AddBackground(joursx+180, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+88, 0, "14");
					AddBackground(joursx+240, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+88, 0, "15");
					AddBackground(joursx+300, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+88, 0, "16");
					AddBackground(joursx+360, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+88, 0, "17");
					AddBackground(joursx+420, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+88, 0, "18");
					AddBackground(joursx+480, joursy2+84, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+88, 0, "19");
					
					//Dates 20 à 28 pour le mois Floréal
					AddBackground(joursx, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+116, 0, "20");
					AddBackground(joursx+60, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+116, 0, "21");
					AddBackground(joursx+120, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+116, 0, "22");
					AddBackground(joursx+180, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+116, 0, "23");
					AddBackground(joursx+240, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+116, 0, "24");
					AddBackground(joursx+300, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+116, 0, "25");
					AddBackground(joursx+360, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+116, 0, "26");
					AddBackground(joursx+420, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+116, 0, "27");
					AddBackground(joursx+480, joursy2+112, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+116, 0, "28");
					
					//Dates 29 à 37 pour le mois Floréal
					AddBackground(joursx, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+22, joursy2+144, 0, "29");
					AddBackground(joursx+60, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+82, joursy2+144, 0, "30");
					AddBackground(joursx+120, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+142, joursy2+144, 0, "31");
					AddBackground(joursx+180, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+202, joursy2+144, 0, "32");
					AddBackground(joursx+240, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+262, joursy2+144, 0, "33");
					AddBackground(joursx+300, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+322, joursy2+144, 0, "34");
					AddBackground(joursx+360, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+382, joursy2+144, 0, "35");
					AddBackground(joursx+420, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+442, joursy2+144, 0, "36");
					AddBackground(joursx+480, joursy2+140, 60, 28, 3000);
					AddLabel(joursx+502, joursy2+144, 0, "37");
					
					//Bouton pour aller Saison Abysse
					AddLabel(55, 545, 2101, "Saison Abysse");
					AddLabel(155, 545, 2101, ":");
					AddButton(170, 545, 4014, 4016, 8, GumpButtonType.Reply, 0);
					
					break;
				}
			}
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
			int buttonID = info.ButtonID;
			
            if (m_Calendrier.Deleted || !m_From.CheckAlive())
                return;
				
			else
			{
				if (buttonID == 1)
				{
					SendCalGump(m_From, CalGumpPage.Page2, m_Calendrier);
				}
				else if (buttonID == 2)
				{
					SendCalGump(m_From, CalGumpPage.Page1, m_Calendrier);
				}
				else if (buttonID == 3)
				{
					SendCalGump(m_From, CalGumpPage.Page3, m_Calendrier);
				}
				else if (buttonID == 4)
				{
					SendCalGump(m_From, CalGumpPage.Page2, m_Calendrier);
				}
				else if (buttonID == 5)
				{
					SendCalGump(m_From, CalGumpPage.Page4, m_Calendrier);
				}
				else if (buttonID == 6)
				{
					SendCalGump(m_From, CalGumpPage.Page3, m_Calendrier);
				}
				else if (buttonID == 7)
				{
					SendCalGump(m_From, CalGumpPage.Page5, m_Calendrier);
				}
				else if (buttonID == 8)
				{
					SendCalGump(m_From, CalGumpPage.Page4, m_Calendrier);
				}
			}
        }
    }
}