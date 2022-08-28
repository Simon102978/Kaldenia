using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

namespace Server.Gumps
{
	public class LuteGump : Gump
	{
        private bool Record = false;
		public LuteGump()
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(6, 15, 570, 140, 5120);
			this.AddAlphaRegion( 16, 20, 550, 130 );
			this.AddImageTiled( 16, 20, 550, 20, 9354);
			this.AddLabel( 19, 20, 200, "Compositeur des mélodies");
            this.AddLabel(55, 60, 2056, @"do");
            this.AddLabel(55, 80, 2056, @"do");
            this.AddLabel(55, 100, 2056, @"do");
            this.AddLabel(95, 60, 2056, @"do#");
            this.AddLabel(95, 80, 2056, @"do#");
            this.AddLabel(145, 60, 2056, @"re");
            this.AddLabel(145, 80, 2056, @"re");
            this.AddLabel(185, 60, 2056, @"re#");
            this.AddLabel(185, 80, 2056, @"re#");
            this.AddLabel(235, 60, 2056, @"mi");
            this.AddLabel(235, 80, 2056, @"mi");
            this.AddLabel(275, 60, 2056, @"fa");
            this.AddLabel(275, 80, 2056, @"fa");
            this.AddLabel(315, 60, 2056, @"fa#");
            this.AddLabel(315, 80, 2056, @"fa#");
            this.AddLabel(365, 60, 2056, @"sol");
            this.AddLabel(365, 80, 2056, @"sol");
            this.AddLabel(405, 60, 2056, @"sol#");
            this.AddLabel(405, 80, 2056, @"sol#");
            this.AddLabel(455, 60, 2056, @"la");
            this.AddLabel(455, 80, 2056, @"la");
            this.AddLabel(495, 60, 2056, @"la#");
            this.AddLabel(495, 80, 2056, @"la#");
            this.AddLabel(545, 60, 2056, @"si");
            this.AddLabel(545, 80, 2056, @"si");
			this.AddButton(35, 62, 5601, 5605, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			this.AddButton(35, 82, 5601, 5605, (int)Buttons.Button2, GumpButtonType.Reply, 0);
			this.AddButton(35, 102, 5601, 5605, (int)Buttons.Button3, GumpButtonType.Reply, 0);
			this.AddButton(75, 62, 5601, 5605, (int)Buttons.Button4, GumpButtonType.Reply, 0);
			this.AddButton(75, 82, 5601, 5605, (int)Buttons.Button5, GumpButtonType.Reply, 0);
			this.AddButton(125, 62, 5601, 5605, (int)Buttons.Button6, GumpButtonType.Reply, 0);
			this.AddButton(125, 82, 5601, 5605, (int)Buttons.Button7, GumpButtonType.Reply, 0);
			this.AddButton(165, 62, 5601, 5605, (int)Buttons.Button8, GumpButtonType.Reply, 0);
			this.AddButton(165, 82, 5601, 5605, (int)Buttons.Button9, GumpButtonType.Reply, 0);
			this.AddButton(215, 62, 5601, 5605, (int)Buttons.Button10, GumpButtonType.Reply, 0);
			this.AddButton(215, 82, 5601, 5605, (int)Buttons.Button11, GumpButtonType.Reply, 0);
			this.AddButton(255, 62, 5601, 5605, (int)Buttons.Button12, GumpButtonType.Reply, 0);
			this.AddButton(255, 82, 5601, 5605, (int)Buttons.Button13, GumpButtonType.Reply, 0);
			this.AddButton(295, 62, 5601, 5605, (int)Buttons.Button14, GumpButtonType.Reply, 0);
			this.AddButton(295, 82, 5601, 5605, (int)Buttons.Button15, GumpButtonType.Reply, 0);
			this.AddButton(345, 62, 5601, 5605, (int)Buttons.Button16, GumpButtonType.Reply, 0);
			this.AddButton(345, 82, 5601, 5605, (int)Buttons.Button17, GumpButtonType.Reply, 0);
			this.AddButton(385, 62, 5601, 5605, (int)Buttons.Button18, GumpButtonType.Reply, 0);
			this.AddButton(385, 82, 5601, 5605, (int)Buttons.Button19, GumpButtonType.Reply, 0);
			this.AddButton(435, 62, 5601, 5605, (int)Buttons.Button20, GumpButtonType.Reply, 0);
			this.AddButton(435, 82, 5601, 5605, (int)Buttons.Button21, GumpButtonType.Reply, 0);
			this.AddButton(475, 62, 5601, 5605, (int)Buttons.Button22, GumpButtonType.Reply, 0);
			this.AddButton(475, 82, 5601, 5605, (int)Buttons.Button23, GumpButtonType.Reply, 0);
			this.AddButton(525, 62, 5601, 5605, (int)Buttons.Button24, GumpButtonType.Reply, 0);
			this.AddButton(525, 82, 5601, 5605, (int)Buttons.Button25, GumpButtonType.Reply, 0);
			this.AddButton(425, 120, 241, 242, (int)Buttons.Close2, GumpButtonType.Reply, 0);

		}
		public enum Buttons
		{
			Close,
			Button1,
			Button2,
			Button3,
			Button4,
			Button5,
			Button6,
			Button7,
			Button8,
			Button9,
			Button10,
			Button11,
			Button12,
			Button13,
			Button14,
			Button15,
			Button16,
			Button17,
			Button18,
			Button19,
			Button20,
			Button21,
			Button22,
			Button23,
			Button24,
			Button25,
			Close2
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile m = sender.Mobile;
			
			if (m == null)
				return;

			switch ( info.ButtonID )
			{
				case 0: 
				{
					m.SendMessage( 60, "Vous arretez de jouer.");
					break;
		   		}

				case 1: 
				{
					m.PlaySound( 1028 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 2: 
				{
					m.PlaySound( 1029 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 3: 
				{
					m.PlaySound( 1030 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 4: 
				{
					m.PlaySound( 1031 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 5: 
				{
					m.PlaySound( 1032 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 6: 
				{
					m.PlaySound( 1033 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 7: 
				{
					m.PlaySound( 1034 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 8: 
				{
					m.PlaySound( 1036 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 9: 
				{
					m.PlaySound( 1037 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 10: 
				{
					m.PlaySound( 1038 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 11: 
				{
					m.PlaySound( 1039 );
					m.SendGump( new LuteGump() );
					break;
				}


				case 12: 
				{
					m.PlaySound( 1040 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 13: 
				{
					m.PlaySound( 1041 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 14: 
				{
					m.PlaySound( 1042 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 15: 
				{
					m.PlaySound( 1043 );
					m.SendGump( new LuteGump() );
					break;
				}


				case 16: 
				{
					m.PlaySound( 1044 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 17: 
				{
					m.PlaySound( 1045 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 18: 
				{
					m.PlaySound( 1046 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 19: 
				{
					m.PlaySound( 1047 );
					m.SendGump( new LuteGump() );
					break;
				}


				case 20: 
				{
					m.PlaySound( 1021 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 21: 
				{
					m.PlaySound( 1022 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 22: 
				{
					m.PlaySound( 1023 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 23: 
				{
					m.PlaySound( 1024 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 24: 
				{
					m.PlaySound( 1025 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 25: 
				{
					m.PlaySound( 1026 );
					m.SendGump( new LuteGump() );
					break;
				}

				case 26: 
				{
					m.SendMessage( 60, "Vous arretez de jouer." );
					break;
				}

			}
		}
	}
    
}

/*
public class MusicPlayList
{
    private ArrayList m_Liste;
    private bool m_Record = false;
    private string m_Name = "";

    public MusicPlayList(ArrayList liste, string name)
        : this(liste, false, name)
    { }
    public MusicPlayList(ArrayList liste, bool record, string name)
    {
        Liste = liste;
        Record = record;
        Name = name;
    }

    public void Play()
    {
        for (int i = 0; i < Liste.Count; i++)
        {
            if (Liste[i] is int)
            {
                int SoundNum = (int)Liste[i];
                m.PlaySound(SoundNum);
            }
            
        }
    }

    public bool Record
    {
        get { return m_Record; }
        set { m_Record = value; }
    }

    public string Name
    {
        get { return m_Name; }
        set { m_Name = value; }
    }

    public ArrayList Liste
    {
        get { return m_Liste; }
        set { m_Liste = value; }
    }




}
*/