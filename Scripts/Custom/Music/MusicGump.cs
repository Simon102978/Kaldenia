/*
 * Created by SharpDevelop.
 * User: gideon
 * Date: 2005/04/21
 * Time: 04:38 PM
 * 
 */

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
	public class MusicGump : Gump
	{	
		public int[] Notes;
		public int Size;
        private MusicTimer PlayList;
        private RuneLute LuteLinked;
        private int _MAX_SIZE = 120;

        public MusicGump(int[] notes, int size, RuneLute _Lute) : base(50, 50)
		{
            Notes = notes;
			Size = size;

            if (_Lute != null)
            {
                LuteLinked = _Lute;
                LuteLinked.Size = size;
                //LuteLinked.Notes = notes;
            }

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(50, 10, 455, 200, 5120);
			AddAlphaRegion(57, 17, 437, 287);
			AddBackground(50, 220, 455, 140, 5120);
			AddAlphaRegion(57, 227, 437, 127);
			AddBackground(50, 370, 455, 60, 5120);
			AddAlphaRegion(57, 377, 437, 47);
            AddImage(45, 5, 10460);
            AddImage(480, 5, 10460);
			AddImage(480, 185, 10460);
			AddImage( 45, 185, 10460);
			AddImage( 45, 215, 10460);
            AddImage(480, 215, 10460);
			AddImage( 45, 335, 10460);
			AddImage(480, 335, 10460);
			AddImage( 45, 365, 10460);
			AddImage(480, 365, 10460);
			AddImage( 45, 405, 10460);
			AddImage(480, 405, 10460);

            int scaleX = 23;

            int x = 110;
            int column = 0;
            int y = 50;

            AddLabel(60, y + 70, 1152, @"Jouer");
            AddLabel(60, y + 100, 1152, @"Ajouter");

            for (int i = 0; i < 15; ++i)
            {
                AddImageTiled(x + column * scaleX, y, 22, 98, 3004); //Touches blanches
                AddButton(3 + x + column * scaleX, y + 70, 2117, 2118, (i + 1), GumpButtonType.Reply, 0); //Jouer les touches blanches
                AddButton(3 + x + column * scaleX, y + 102, 2117, 2118, (i + 26), GumpButtonType.Reply, 0); //Ajouter les touches blanches
                column++;
            }

            column = 0;
            x = 125;
            y = 30;

            AddLabel(60, y + 40, 1152, @"Jouer");
            AddLabel(60, y, 1152, @"Ajouter");

            AddButton(220, y + 145, 2117, 2118, 54, GumpButtonType.Reply, 0);
            AddLabel(240, y + 145, 1152, @"Ajouter un silence");

            for (int i = 0; i < 13; ++i)
            {
                if (column != 2 && column != 6 && column != 9)
                {
                    AddImageTiled(x + column * scaleX, y + 20, 14, 52, 3604); //Touches noires
                    AddButton(x + column * scaleX, y + 40, 2117, 2118, 16 + i, GumpButtonType.Reply, 0); //Jouer les touches noires
                    AddButton(x + column * scaleX, y + 2, 2117, 2118, 41 + i, GumpButtonType.Reply, 0); //Ajouter les touches noires
                }
                column++;
            }

			AddButton( 95, 382, 2117, 2118, 51, GumpButtonType.Reply, 0);
            AddLabel(120, 380, 1152, @"Effacer tous les notes");
            AddButton(95, 402, 2117, 2118, 52, GumpButtonType.Reply, 0);
            AddLabel(120, 400, 1152, @"Effacer la derni%%%#$%?%$#@!re note");
			AddButton(320, 382, 2117, 2118, 53, GumpButtonType.Reply, 0);
            AddLabel(340, 380, 1152, @"Jouer la mélodie");
			
			for (int i = 0; i < size; ++i)
			{
				if (Notes[i] != 0)
				{
                    int ybase = 230;
                    int yscale = 20;

					int level = 78 + ((i % 20) * yscale);
                    y = i / 20;
					
					switch (Notes[i])
					{
                        case 1000: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"-"); } break;
                        case 1028: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"C"); } break;
                        case 1033: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"D"); } break;
                        case 1038: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"E"); } break;
                        case 1040: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"F"); } break;
                        case 1044: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"G"); } break;
                        case 1021: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"A"); } break;
                        case 1025: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"B"); } break;
                        case 1029: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"C"); } break;
                        case 1034: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"D"); } break;
                        case 1039: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"E"); } break;
                        case 1041: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"F"); } break;
                        case 1045: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"G"); } break;
                        case 1022: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"A"); } break;
                        case 1026: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"B"); } break;
                        case 1030: { AddLabel(level + 5, ybase + (y * yscale), 1152, @"C"); } break;
                        case 1031: { AddLabel(level, ybase + (y * yscale), 1152, @"D#"); } break;
                        case 1036: { AddLabel(level, ybase + (y * yscale), 1152, @"C#"); } break;
                        case 1042: { AddLabel(level, ybase + (y * yscale), 1152, @"E#"); } break;
                        case 1046: { AddLabel(level, ybase + (y * yscale), 1152, @"F#"); } break;
                        case 1023: { AddLabel(level, ybase + (y * yscale), 1152, @"G#"); } break;
                        case 1032: { AddLabel(level, ybase + (y * yscale), 1152, @"C#"); } break;
                        case 1037: { AddLabel(level, ybase + (y * yscale), 1152, @"D#"); } break;
                        case 1043: { AddLabel(level, ybase + (y * yscale), 1152, @"E#"); } break;
                        case 1047: { AddLabel(level, ybase + (y * yscale), 1152, @"F#"); } break;
                        case 1024: { AddLabel(level, ybase + (y * yscale), 1152, @"G#"); } break;
					}
				}
			}
		}
		
		public int notetoplay = 0;
		public Mobile player;
		
		public virtual void PlaySound()
		{
			player.PlaySound( Notes[notetoplay] );
			++notetoplay;
			if (notetoplay != Size)
				Timer.DelayCall( TimeSpan.FromSeconds( 1.5 ), new TimerCallback(PlaySound));
		}

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            try
            {
                Mobile m = sender.Mobile;
                player = m;

                if (m == null)
                    return;

                switch (info.ButtonID)
                {
                    case 1: { m.PlaySound(1028); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 2: { m.PlaySound(1033); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 3: { m.PlaySound(1038); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 4: { m.PlaySound(1040); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 5: { m.PlaySound(1044); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 6: { m.PlaySound(1021); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 7: { m.PlaySound(1025); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 8: { m.PlaySound(1029); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 9: { m.PlaySound(1034); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 10: { m.PlaySound(1039); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 11: { m.PlaySound(1041); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 12: { m.PlaySound(1045); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 13: { m.PlaySound(1022); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 14: { m.PlaySound(1026); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 15: { m.PlaySound(1030); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 16: { m.PlaySound(1031); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 17: { m.PlaySound(1036); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 18: { m.PlaySound(1042); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 19: { m.PlaySound(1046); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 20: { m.PlaySound(1023); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 21: { m.PlaySound(1032); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 22: { m.PlaySound(1037); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 23: { m.PlaySound(1043); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 24: { m.PlaySound(1047); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 25: { m.PlaySound(1024); m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 26: { if (Size < _MAX_SIZE) { Notes[Size] = 1028; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 27: { if (Size < _MAX_SIZE) { Notes[Size] = 1033; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 28: { if (Size < _MAX_SIZE) { Notes[Size] = 1038; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 29: { if (Size < _MAX_SIZE) { Notes[Size] = 1040; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 30: { if (Size < _MAX_SIZE) { Notes[Size] = 1044; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 31: { if (Size < _MAX_SIZE) { Notes[Size] = 1021; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 32: { if (Size < _MAX_SIZE) { Notes[Size] = 1025; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 33: { if (Size < _MAX_SIZE) { Notes[Size] = 1029; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 34: { if (Size < _MAX_SIZE) { Notes[Size] = 1034; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 35: { if (Size < _MAX_SIZE) { Notes[Size] = 1039; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 36: { if (Size < _MAX_SIZE) { Notes[Size] = 1041; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 37: { if (Size < _MAX_SIZE) { Notes[Size] = 1045; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 38: { if (Size < _MAX_SIZE) { Notes[Size] = 1022; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 39: { if (Size < _MAX_SIZE) { Notes[Size] = 1026; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 40: { if (Size < _MAX_SIZE) { Notes[Size] = 1030; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 41: { if (Size < _MAX_SIZE) { Notes[Size] = 1031; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 42: { if (Size < _MAX_SIZE) { Notes[Size] = 1036; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 43: { if (Size < _MAX_SIZE) { Notes[Size] = 1042; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 44: { if (Size < _MAX_SIZE) { Notes[Size] = 1046; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 45: { if (Size < _MAX_SIZE) { Notes[Size] = 1023; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 46: { if (Size < _MAX_SIZE) { Notes[Size] = 1032; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 47: { if (Size < _MAX_SIZE) { Notes[Size] = 1037; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 48: { if (Size < _MAX_SIZE) { Notes[Size] = 1043; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 49: { if (Size < _MAX_SIZE) { Notes[Size] = 1047; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 50: { if (Size < _MAX_SIZE) { Notes[Size] = 1024; LuteLinked.Notes[Size] = Notes[Size]; m.PlaySound(Notes[Size]); ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 54: { if (Size < _MAX_SIZE) { Notes[Size] = 1000; LuteLinked.Notes[Size] = Notes[Size];                           ++Size; } m.SendGump(new MusicGump(Notes, Size, LuteLinked)); } break;
                    case 51: { m.SendGump(new MusicGump(Notes, 0, LuteLinked)); } break;
                    case 52: { m.SendGump(new MusicGump(Notes, (Size - 1), LuteLinked)); } break;
                    case 53:
                        {
                            if (Size > 0)
                            {
                                PlayList = new MusicTimer(Notes, Size, m);
                                PlayList.Start();
                                m.SendGump(new MusicGump(Notes, Size, LuteLinked));
                                //Timer.DelayCall(TimeSpan.FromSeconds(0.0), new TimerCallback(PlaySound));
                            }
                        } break;
                }
            }
            catch { }
        }

        class MusicTimer : Timer
        {
            public int[] Notes;
		    public int Size;
            private int current = 0;
            Mobile From;

            public MusicTimer(int[] notes, int size, Mobile from)
                : base(TimeSpan.FromSeconds(0.1), TimeSpan.FromSeconds(0.2))
            {
                Notes = notes;
			    Size = size;
                From = from;
            }

            protected override void OnTick()
            {
                if (Notes[current] != 1000)
                    From.PlaySound(Notes[current]);
                if (current < Size - 1)
                    current++;
                else
                    this.Stop();
            }
        }
	}
}
