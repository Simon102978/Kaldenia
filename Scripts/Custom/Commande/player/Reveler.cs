using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Scripts.Commands
{
    public class Reveler
    {
        public static void Initialize()
        {
            CommandSystem.Register("Reveler", AccessLevel.Player, new CommandEventHandler(Reveler_OnCommand));
        }

        [Usage("Reveler")]
        [Description("R??#$?&*v??#$?&*ler la cible cach??#$?&*e.")]
        public static void Reveler_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is PlayerMobile)
            {
                PlayerMobile pm = (PlayerMobile)e.Mobile;

                from.Target = new RevelerTarget();
            }
        }

        private class RevelerTarget : Target
        {

            public RevelerTarget()
                : base(15, true, TargetFlags.None)
            {
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (from is PlayerMobile)
                {
                    if (targeted is Mobile && targeted != from)
                    {
                        Mobile PersoVise = (Mobile)targeted;
                        if (PersoVise.Hidden) // Si le target est cach??#$?&*.
                        {
                            PersoVise.NextSkillTime = 5; // Empêche le joueur vis??#$?&* d'utiliser un skill pour les 5 prochaines secondes.
                            PersoVise.RevealingAction();
                            PersoVise.SendMessage("Quelqu'un a r??#$?&*v??#$?&*l??#$?&* votre pr??#$?&*sence.");
                        }
                        else
                        {
                            from.SendMessage("Le personnage cibl??#$?&* doit être cach??#$?&* !");
                        }
                    }
                    else
                    {
                        from.SendMessage("Vous devez viser un personnage !");
                    }
                }
            }
        }
    }
}
