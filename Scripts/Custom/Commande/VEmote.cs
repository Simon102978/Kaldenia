using System;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Commands;


namespace Server.Scripts.Commands
{
    public class VEmote
    {
        public static void Initialize()
        {
            CommandSystem.Register("VEmote", AccessLevel.Player, new CommandEventHandler(VEmote_OnCommand));
        }

        [Usage("VEmote")]
        [Description("Permet de faire un emote sonore.")]
        public static void VEmote_OnCommand(CommandEventArgs e)
        {
            PlayerMobile from = e.Mobile as PlayerMobile;

            if (from == null || !from.Alive)
                return;

            if (e.Length != 0)
            {
                string emote = e.GetString(0).ToLower();

                if (emote == "clap")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*clap* *clap*", false);
                    PlaySound(from, from.Female ? 780 : 1051);
                }
                else if (emote == "burp")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*burp*", false);
                    PlaySound(from, from.Female ? 782 : 1053);
                }
                else if (emote == "hrm")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*hrm*", false);
                    PlaySound(from, from.Female ? 784 : 1055);
                }
                else if (emote == "toux")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*toux*", false);
                    PlaySound(from, from.Female ? 785 : 1056);
                }
                else if (emote == "snif")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*snif*", false);
                    PlaySound(from, from.Female ? 787 : 1058);
                }
                else if (emote == "hic")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*hïc*", false);
                    PlaySound(from, from.Female ? 798 : 1070);
                }
                else if (emote == "bisou")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*bisou*", false);
                    PlaySound(from, from.Female ? 800 : 1072);
                }
                else if (emote == "blurp")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*blurp*", false);
                    PlaySound(from, from.Female ? 813 : 1087);
                }
                else if (emote == "shut")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*shut*", false);
                    PlaySound(from, from.Female ? 815 : 1089);
                }
                else if (emote == "ronfle")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*ronfle*", false);
                    PlaySound(from, from.Female ? 819 : 1093);
                }
                else if (emote == "crache")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*crache*", false);
                    PlaySound(from, from.Female ? 820 : 1094);
                }
                else if (emote == "siffle")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*siffle*", false);
                    PlaySound(from, from.Female ? 821 : 1095);
                }
                else if (emote == "baille")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*bâille*", false);
                    PlaySound(from, from.Female ? 822 : 1096);
                }
                else if (emote == "wouahh")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*Wouahh!!!*", false);
                    PlaySound(from, from.Female ? 824 : 1098);
                }
             /*   else if ((from.NewRace == NewRace.Drakan || from.AccessLevel >= AccessLevel.GameMaster) && emote == "sss")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*sSs*", false);
                    PlaySound(from, 220);
                }
                else if ((from.NewRace == NewRace.Gorlak || from.AccessLevel >= AccessLevel.GameMaster) && emote == "marmonne")
                {
                    from.RevealingAction();
                    from.PublicOverheadMessage(MessageType.Emote, from.EmoteHue, false, "*marmonne*", false);
                    PlaySound(from, 196);
                }*/
                else
                {
                    from.SendMessage("Usage: clap, burp, hrm, toux, snif, hic, bisou, blurp, shut, ronfle, crache, siffle, baille, wouahh");
                    return;
                }
            }
            else
            {
                from.SendMessage("Usage: clap, burp, hrm, toux, snif, hic, bisou, blurp, shut, ronfle, crache, siffle, baille, wouahh");
                return;
            }
        }

        public static void PlaySound(Mobile m, int index)
        {
            try
            {
                Map map = m.Map;

                if (map == null)
                    return;

                Packet p = new PlaySound(index, m.Location);

                foreach (NetState state in m.GetClientsInRange(12))
                {
                    state.Send(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}