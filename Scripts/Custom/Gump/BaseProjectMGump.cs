using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;
using System.Linq;

namespace Server.Gumps
{
  public abstract class BaseProjectMGump : Gump
  {
    public static int ColorTitre = 2123;
    public static int ColorText = 2100;
    public static int ColorTextGreen = 2210;
    public static int ColorTextLight = 2122;
    public static int ColorTextGray = 2403;
    public static int ColorTextYellow = 2212;
    public static int ColorTextRed = 2117;

    public static string ColorHtmlTitre = "#025a";
    public static string ColorHtmlText = "#241b0d";
    public static string ColorHtmlRed = "#990000";
    public static string ColorHtmlGreen = "#009900";
    public static string ColorHtmlBlue = "#336699";
    public static string ColorHtmlYellow = "#FFCC66";
    public static string ColorHtmlGray = "#999999";

    public static int DefaultHtmlLength = 200;

    public static int RealXBase = 50;
    public static int RealYBase = 50;

    private int m_Largeur;
    private int m_Hauteur;
    private int m_Colonne;

    public int Colone { get { return m_Colonne - 10; } }
    public bool AsColonne { get { return m_Colonne > 50; } }
    public int Largeur { get { return m_Largeur - 10; } }
    public int Hauteur { get { return m_Hauteur - 17; } }
    public static int XBase { get { return RealXBase + 25; } }
    public static int YBase { get { return RealYBase + 25; } }
    public int XCol { get { return XBase + m_Colonne + 5; } }

    public int LargeurColonne1 { get { return m_Colonne - 15; } }
    public int LargeurColonne2 { get { return (Largeur - m_Colonne) - 15; } }


    public BaseProjectMGump(string titre, int largeur, int hauteur)
        : this(titre, largeur, hauteur, false)
    {

    }

    public BaseProjectMGump(string titre, int largeur, int hauteur, bool Background)
        : base(RealXBase, RealYBase)
    {
      m_Largeur = largeur;
      m_Hauteur = hauteur;   
      int _x = RealXBase;
      int _y = RealYBase;


      AddBackground(_x, _y, m_Largeur + 80, m_Hauteur + 80, 9260);

	  if(Background)
	  {
		AddBackground(_x + 20 , _y + 23, m_Largeur + 40, m_Hauteur + 40, 9270);
      }
	  

		//Dragons
    	if (hauteur > 250)
        {
	      AddImageTiled(_x + 17, _y - 1, m_Largeur + 40, 17, 10250); //Top
          AddImage(_x - 50, _y - 13, 10440);
          AddImage(_x + m_Largeur + 48, _y - 13, 10441);
	     
    	}

       // Titre
        if (largeur > 180)
        {
          AddImage(_x + largeur / 2 - 100, _y - 5, 1141);
		
		 AddHtml(_x + largeur / 2 - 90, _y - 2, 260, 25 , String.Concat("<h3><center><basefont color=#000000>", titre, "</basefont><center></h3>"), false, false);

		}
	}
    
    public override void OnResponse(NetState sender, RelayInfo info)
    {
      Mobile f = sender.Mobile;
      CustomPlayerMobile from = f as CustomPlayerMobile;
    }

    public void AddValidButton(int x, int y, int id, bool green, string text)
    {
      if (green)
        AddButton(x, y, 0x2343, 0x2343, id, GumpButtonType.Reply, 0);
      else
        AddButton(x, y, 0x2342, 0x2342, id, GumpButtonType.Reply, 0);
      AddHtmlTexteColored(x + 20, y - 3, DefaultHtmlLength, text, green ? ColorHtmlText : ColorHtmlGray);
      //AddLabel(x + 20, y-3, (green ? ColorTextLight : ColorTextGray), text);
    }

        //AddCheck( int x, int y, int inactiveID, int activeID, bool initialState, int switchID )

    public void CheckBoxButton(int x, int y, int id, bool Check, string text)
    {
            
                AddCheck(x, y, 0x2342, 0x2343,  Check, id);
           
                AddHtmlTexte(x + 20, y - 3, DefaultHtmlLength, text);


            //AddLabel(x + 20, y-3, (green ? ColorTextLight : ColorTextGray), text);
    }



    public static int[] ButtonID = new int[] { 0x4b9, 0x4ba };
    public void AddButtonTrueFalse(int x, int y, int id, bool select, string text)
    {
      if (select)
        AddImage(x, y, ButtonID[1], 2118);
      else
        AddButton(x, y, ButtonID[0], ButtonID[1], id, GumpButtonType.Reply, 0);
      AddHtmlTexteColored(x + 20, y - 3, DefaultHtmlLength, text, select ? ColorHtmlText : ColorHtmlGray);
      //AddLabel(x + 20, y - 3, (select ? ColorTextLight : ColorTextGray), text);
    }
    public void AddSimpleButton(int x, int y, int id, string text)
    {
      AddSimpleButton(x, y, id, text, ColorHtmlText);
    }
    public void AddSimpleButton(int x, int y, int id, string text, string color)
    {
      AddButton(x, y, ButtonID[0], ButtonID[1], id, GumpButtonType.Reply, 0);
      AddHtmlTexteColored(x + 20, y - 3, 350, text, color);
      //AddLabel(x + 20, y - 3, color, text);
    }
    public void AddButtonPageSuivante(int x, int y, int id)
    {
      AddButton(x, y, 0x2622, 0x2623, id, GumpButtonType.Reply, 0);
    }
    public void AddButtonPagePrecedante(int x, int y, int id)
    {
      AddButton(x, y, 0x2626, 0x2627, id, GumpButtonType.Reply, 0);
    }
    public void AddButton(int x, int y, int id, int gumpId)
    {
      AddButton(x, y, gumpId, gumpId, id, GumpButtonType.Reply, 0);
    }
    public void AddButton(int x, int y, int id, int gumpId, int gumpIdPressed)
    {
      AddButton(x, y, gumpId, gumpIdPressed, id, GumpButtonType.Reply, 0);
    }
    public void AddHorizontalLigne(int x, int y, int largeur)
    {
      AddImage(x, y, 95);
      AddImageTiled(x + 5, y + 9, largeur - 10, 3, 96);
      /*for (int i = 0; i < largeur / 179; i++)
          AddImage((x + 5) + (i * 179), y + 9, 96);
      AddImage((x) + (largeur - 10), y + 9, 96); //Assurer qu'on a la fin*/
      AddImage((x) + (largeur - 10), y, 97);
    }
    public void AddVerticalLigne(int x, int y, int longueur)
    {
      //add horizontal section gump = 503
      AddImage(x - 4, y, 503);
      AddImageTiled(x + 5, y + 9, 3, longueur - 3, 96);
      AddImage(x - 4, y + (longueur + 5), 504);
    }
    public void AddHtmlTitre(int x, int y, int largeur, string texte)
    {
      //AddHtml(x, y, largeur, 20, String.Concat("<span color=#025a style='font-family:uni0;'>", texte, "</span>"), false, false);
      AddHtml(x, y, largeur, 20, String.Concat("<h3><basefont color=#025a>", texte, "</basefont></h3>"), false, false);
    }
    public void AddHtmlTexte(int x, int y, int largeur, string texte)
    {
      //AddHtml(x, y, largeur, 20, String.Concat("<span color=#241b0d style='font-family:uni0;'>", texte, "</span>"), false, false);
      AddHtml(x, y, largeur, 20, String.Concat("<h3><basefont color=#FFFFFF>", texte, "</basefont></h3>"), false, false);
    }

    public void AddHtmlTexte(int x, int y, int largeur, int hauteur, string texte)
    {
            //AddHtml(x, y, largeur, 20, String.Concat("<span color=#241b0d style='font-family:uni0;'>", texte, "</span>"), false, false);
            AddHtml(x, y, largeur, hauteur, String.Concat("<h3><basefont color=#FFFFFF>", texte, "</basefont></h3>"), false, false);
    }



    public void AddHtmlTexteColored(int x, int y, int largeur, string texte, string color)
    {
      //AddHtml(x, y, largeur, 20, String.Concat("<span color=", color, "style='font-family:uni0;'>", texte, "<span>"), false, false);
      AddHtml(x, y, largeur, 20, String.Concat("<h3><basefont color=", color, ">", texte, "</basefont></h3>"), false, false);
    }

	public void AddTitle(int x, int y, string titre)
	{
			AddImage(x, y, 2501);
			AddHtml(x + 10, y + 1, 125, 25, String.Concat("<h3><center><basefont color=#000000>", titre, "</basefont></center></h3>"), false, false);
	}

    public void AddSection(int x, int y, int largeur, int hauteur, string titre)
    {
	  AddBackground(x, y, largeur, hauteur, 9270);
	  AddTitle(x + largeur / 2 - 70, y + 13, titre);
    }
    public void AddSection(int x, int y, int largeur, int hauteur, string titre, string description)
    {
 /*     AddBackground(x, y, largeur, hauteur + 58, 3500);
      AddHorizontalLigne(x + 20, y + 20, largeur - 37);
      AddHtmlTitre(x + 30, y + 15, largeur - 35, titre);*/
 	  AddBackground(x, y, largeur, hauteur, 9270);
	  AddTitle(x + largeur / 2 - 70, y + 13, titre);
      AddHtml(x + 15, y + 43, largeur - 30, hauteur - 60, String.Concat("<h3><basefont color=#241b0d>", description, "<basefont></h3>"), true, true);
    }
    public void AddSection(int x, int y, int largeur, int hauteur, string titre, string description, string[] texte)
    {
      AddBackground(x, y, largeur, hauteur + 58 + (texte.Length * 20), 3500);
      AddHorizontalLigne(x + 20, y + 20, largeur - 37);
      AddHtmlTitre(x + 30, y + 15, largeur - 35, titre);
      AddHtml(x + 15, y + 43, largeur - 30, hauteur, String.Concat("<h3><basefont color=#241b0d>", description, "<basefont></h3>"), true, true);

      for (int i = 0; i < texte.Length; i++)
      {
        AddHtmlTexte(x + 15, (y + 43) + hauteur + (i * 20), largeur - 35, texte[i]);
      }
    }

	public void AddTextEntryBg(int x, int y, int width, int height, int hue, int entryID, string initialText)
    {
       AddBackground(x, y, width, height, 9350);
       AddTextEntry(x + 5, y + 5, width - 5, height, hue, entryID, initialText);
    }

    public void AddSection(int x, int y, int largeur, int hauteur, string titre, string[] texte)
    {
 	  AddBackground(x, y, largeur, hauteur, 9270);
	  AddTitle(x + largeur / 2 - 70, y + 13, titre);

	 string text = "";
	

      for (int i = 0; i < texte.Length; i++)
      {
				text = text + texte[i];

  //      AddHtmlTexte(x + 15, (y + 43) + (i * 20), largeur - 35, texte[i]);
	  }

	  AddHtml(x + 15, y + 43, largeur - 35, hauteur - 60, String.Concat("<h3><basefont color=#241b0d>", text, "<basefont></h3>"), true, true);


    }
    public void AddInvisibleSection(int x, int y, int largeur, int hauteur)
    {
      AddBackground(x, y, largeur, hauteur, 3500);
      AddAlphaRegion(x + 10, y + 10, largeur - 20, hauteur - 20);
    }
    public void AddImageWithContour(int x, int y, int largeur, int hauteur, int image)
    {
      AddBackground(x, y, largeur + 10, hauteur + 10, 2620);
      AddImage(x + 5, y + 5, image, 0);
    }
    public void AddMenuItem(int x, int y, int gumpID, int buttonID, bool isActive)
    {
      if (isActive)
        AddBackground(x, y, 80, 62, 9300);

      AddButton(x + 20, y + 10, gumpID, gumpID, buttonID, GumpButtonType.Reply, 0);
      AddButton(x + 58, y + 12, 2087, 2087, buttonID, GumpButtonType.Reply, 0);
      AddButton(x + 10, y + 12, 2097, 2097, buttonID, GumpButtonType.Reply, 0);
    }

        // Button et le texte, pour pas avoir a gosser avec a chaque fois.
    public void AddButtonHtlml(int x, int y, int buttonID,string text, string color = "#000000")
    {
            AddButtonHtlml(x, y, buttonID, 2117, 2118,  text, color);  
    }

		public void AddButtonHtlml(int x, int y, int buttonID, int NormalButton, int PressButton, string text, string color = "#000000")
       {
            AddButton(x, y + 2, NormalButton, PressButton, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y, 400, 20, "<h3><basefont color=" + color + ">" + text + "<basefont></h3>", false, false);

       }

		public void AddButtonHtlml(int x, int y, string text, int hauteur, int longeur, int buttonID, string color = "#000000")
		{
			AddButton(x, y + 3, 2117, 2118, buttonID, GumpButtonType.Reply, 0);
			AddHtml(x + 18, y, hauteur, longeur, "<h3><basefont color="+ color + ">" + text + "<basefont></h3>", false, false);

		}

		public void AddColorChoice(int x, int y, int buttonIDStart, int[] hue)
        {
            int i = 0;
            int xbase = x;

            if (hue.Length > 1)
            {
                AddImage(x, y + 3, 996, hue[i]);
                AddButton(x, y + 3, 993, 993, buttonIDStart + i, GumpButtonType.Reply, 0);

                x += 27;
                i++;
            }   
            while ( i < (hue.Length - 1 ) || i == 0)
            {
                AddImage(x , y + 3, 997, hue[i]);
                AddButton(x , y + 3, 994, 994, buttonIDStart + i, GumpButtonType.Reply, 0);

                x += 18;
                i++;
            }

            if (hue.Length > 1)
            {
                AddImage(x, y + 3, 995, hue[i]);
                AddButton(x, y + 3, 992, 992, buttonIDStart + i, GumpButtonType.Reply, 0);
                x += 19;
                i++;
            }        
        }

    }
}
