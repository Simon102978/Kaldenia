using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class FamilierGump : Gump
	{
		public static void Initialize()
		{
			
			
		}



        private Server.Mobiles.BaseCreature c;
        private Mobile m;


        public FamilierGump (Mobile Mobile, Server.Mobiles.BaseCreature Creature)
			: base( 0, 0 )
		{

            c = Creature;
            m = Mobile;

            string TextHue = "0";

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(239, 88, 291, 342, 9200);
            AddHtml(240, 95, 90, 50, String.Format("<basefont color=#{0}><h2>{1}</h2>", TextHue, Creature.Name), false, false);
            this.AddBackground(240, 115, 291, 315, 9200);
            AddHtml(246, 125, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Commandes"), false, false);


            this.AddButton(246, 145, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
            AddHtml(280, 146, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Déplacement"), false, false);

            this.AddButton(396, 145, 0xFA5, 0xFA7, 7, GumpButtonType.Reply, 0);
            AddHtml(430, 146, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Arrêter"), false, false);

            this.AddButton(246, 171, 0xFA5, 0xFA7, 2, GumpButtonType.Reply, 0);
            AddHtml(280, 172, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Revenir"), false, false);

            this.AddButton(396, 171, 0xFA5, 0xFA7, 6, GumpButtonType.Reply, 0);
            AddHtml(430, 172, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Rester"), false, false);

            this.AddButton(246, 196, 0xFA5, 0xFA7, 3, GumpButtonType.Reply, 0);
            AddHtml(280, 197, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Garde"), false, false);

            this.AddButton(396, 196, 0xFA5, 0xFA7, 5, GumpButtonType.Reply, 0);
            AddHtml(430, 197, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Tuer"), false, false);

            this.AddButton(246, 221, 0xFA5, 0xFA7, 4, GumpButtonType.Reply, 0);
            AddHtml(280, 222, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Suivre"), false, false);

            this.AddButton(396, 221, 0xFA5, 0xFA7, 8, GumpButtonType.Reply, 0);
            AddHtml(430, 222, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Relâcher"), false, false);

            AddHtml(246, 247, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Texte :"), false, false);
            this.AddBackground(240, 272, 290, 100, 9350);
            AddTextEntry(240, 272, 290, 100, 0x205, 0, null);

            this.AddButton(246, 380, 0xFA5, 0xFA7, 9, GumpButtonType.Reply, 0);
            AddHtml(280, 381, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Parler"), false, false);

            this.AddButton(396, 380, 0xFA5, 0xFA7, 11, GumpButtonType.Reply, 0);
            AddHtml(430, 381, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Crier"), false, false);

            this.AddButton(246, 405, 0xFA5, 0xFA7, 10, GumpButtonType.Reply, 0);
            AddHtml(280, 405, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Murmurer"), false, false);

            this.AddButton(396, 405, 0xFA5, 0xFA7, 12, GumpButtonType.Reply, 0);
            AddHtml(430, 405, 90, 50, String.Format("<basefont color=#{0}>{1}", TextHue, "Action"), false, false);

            //      public void AddTextEntry(int x, int y, int width, int height, int hue, int entryID, string initialText)


            //	public void AddBackground( int x, int y, int width, int height, int gumpID )







            // Emote
            // talk






        }


        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (c.Deleted)   // Mettre ici si la cible est morte.. dissiper ou autre
            {

                from.SendMessage("Votre créature n'existe plus.");
                return;
            }
                

            TextRelay te = info.GetTextEntry(0);
            string msg;

            if (te == null)
            {
                msg = "";
            }
            else
            {
                msg = te.Text;
            }


            c.ControlOrder = OrderType.Stay;            // Pour le faire arreter ce qui fesait avant...
            c.ControlTarget = null;
            c.TargetLocation = null;


            switch (info.ButtonID)
            {
                case 1:
                    {
                        from.Target = new Go(c);
                        ((PlayerMobile)from).SendGump(new FamilierGump(m,c));
                        break;
                    }
                case 2:
                    {
                        c.ControlOrder = OrderType.Follow;
                        c.ControlTarget = from;
                        ((PlayerMobile)from).SendGump(new FamilierGump(m,c));
                        break;
                    }
                case 3:
                    {
                        c.ControlOrder = OrderType.Guard;
                        c.ControlTarget = from;
                        ((PlayerMobile)from).SendGump(new FamilierGump(m,c));
                        break;
                    }
                case 4:
                    {
                        from.Target = new Ciblage(c, 1);
                        ((PlayerMobile)from).SendGump(new FamilierGump(m,c));
                        break;
                    }
                case 5:
                    {
                        from.Target = new Ciblage(c, 2);
                        ((PlayerMobile)from).SendGump(new FamilierGump(m,c));
                        break;
                    }
                case 6:
                    {
                                                                    // Reste ... N'a pas besoin de rien
                        break;
                    }
                case 7:
                    {
                        c.ControlOrder = OrderType.Stop;
                        ((PlayerMobile)from).SendGump(new FamilierGump(m,c));
                        break;
                    }
                case 8:
                    {
                        c.ControlOrder = OrderType.Release;
                        break;
                    }
                case 9:
                    {
                        if (msg != "")
                        {
                           
                             c.DoSpeech(info.GetTextEntry(0).Text, new int[] { }, MessageType.Regular, m.SpeechHue);
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }
                        else
                        {
                            from.SendMessage("Vous devez dire quelque choses.");
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }
                        
                    }
                case 10:
                    {
                        if (msg != "")
                        {
                            c.DoSpeech(info.GetTextEntry(0).Text, new int[] { }, MessageType.Whisper, m.SpeechHue);
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }
                        else
                        {
                            from.SendMessage("Vous devez dire quelque choses.");
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }
                    }
                case 11:
                    {
                        if (msg != "")
                        {

                            c.DoSpeech(info.GetTextEntry(0).Text, new int[] { }, MessageType.Yell, m.SpeechHue);
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }
                        else
                        {
                            from.SendMessage("Vous devez dire quelque choses.");
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }

                    }
                case 12:
                    {
                        if (msg != "")
                        {

                            c.DoSpeech("*" + info.GetTextEntry(0).Text + "*", new int[] { }, MessageType.Emote, m.EmoteHue);
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }
                        else
                        {
                            from.SendMessage("Vous devez dire quelque choses.");
                            ((PlayerMobile)from).SendGump(new FamilierGump(m, c));
                            break;
                        }

                    }


                default:
                        break;
            }



           
        }

        public class Go : Target
        {
            Server.Mobiles.BaseCreature cr;


            public Go(Server.Mobiles.BaseCreature creature) : base(Core.ML ? 11 : 12, true, TargetFlags.None)
            {
                cr = creature;
            }

            protected override void OnTarget(Mobile from, object targ)
            {

                if (targ is IPoint2D)
                {             
                        IPoint2D p = (IPoint2D)targ;

                        if (targ != from)
                            p = new Point2D(p.X, p.Y);

                        cr.TargetLocation = p;
                        from.SendLocalizedMessage(502479); // The animal walks where it was instructed to.

                    
                }

                
                 // ((PlayerMobile)from).SendGump(new FamilierGump(cr));
            }


        }

        public class Ciblage : Target
        {
            Server.Mobiles.BaseCreature cr;
            int ch;


            public Ciblage (Server.Mobiles.BaseCreature creature, int Choix) : base(Core.ML ? 11 : 12, true, TargetFlags.None)
            {
                cr = creature;
                ch = Choix;
            }

            protected override void OnTarget(Mobile from, object targ)
            {

                if (targ is Mobile)
                {
                    Mobile m = (Mobile)targ;

                    if (targ != cr)
                    {
                        switch (ch)
                        {
                            case 1:
                                {
                                    cr.ControlOrder = OrderType.Follow;
                                    cr.ControlTarget = m;
                                    break;
                                }
                            case 2:
                                {
                                    cr.ControlOrder = OrderType.Attack;
                                    cr.ControlTarget = m;
                                    break;
                                }
                            default:
                                break;
                        }


                    }
                       
                    

                }


                // ((PlayerMobile)from).SendGump(new FamilierGump(cr));
            }


        }












    }







}