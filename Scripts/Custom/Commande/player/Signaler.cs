using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Scripts.Commands
{
    public class Signaler
    {
        public static void Initialize()
        {
			CommandSystem.Register("Signaler", AccessLevel.Player, new CommandEventHandler(Signaler_OnCommand));
		}

		private static void Signaler_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile as Mobile;

			if (!from.Hidden)
			{
				from.SendMessage("Vous devez �tre cach� pour signaler votre pr�sence %%%#$%?%$#@! quelqu'un.");
				return;
			}

			from.SendMessage("Veuillez viser le joueur %%%#$%?%$#@! qui vous d�sirez signaler votre pr�sence. (Vous devez lui �tre adjacent.)");
			from.Target = new SignalerTarget();
		}

		private class SignalerTarget : Target
		{
			public SignalerTarget()
				: base(1, false, TargetFlags.None)
			{
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				Mobile target = targeted as Mobile;
				Mobile sfrom = from as Mobile;

				if (target == null)
				{
					from.SendMessage("Vous devez viser un joueur.");
					return;
				}

				target.Reveal(sfrom);
	
				from.SendMessage("Vous signalez %%%#$%?%$#@! {0} votre pr�sence.", target.Name);
				target.SendMessage("{0} vous signale sa pr�sence.", from.Name);
			}
		}
	}
}


