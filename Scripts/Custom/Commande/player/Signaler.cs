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
				from.SendMessage("Vous devez être caché pour signaler votre prèsence à quelqu'un.");
				return;
			}

			from.SendMessage("Veuillez viser le joueur à qui vous désirez signaler votre présence. (Vous devez lui être adjacent.)");
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
	
				from.SendMessage("Vous signalez à {0} votre présence.", target.Name);
				target.SendMessage("{0} vous signale sa présence.", from.Name);
			}
		}
	}
}


