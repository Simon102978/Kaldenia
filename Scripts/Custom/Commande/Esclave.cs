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
    public class EsclaveCommande
	{
        public static void Initialize()
        {
			CommandSystem.Register("Esclave", AccessLevel.Player, new CommandEventHandler(Esclave_OnCommand));
		}

		[Usage("Esclave")]
		[Description("Permet d'acceder au menu d'esclave.")]
		public static void Esclave_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (!from.Alive)
				return;

			if (from is CustomPlayerMobile cm)
			{
				if (cm.StatutSocial >= StatutSocialEnum.Civenien || cm.AccessLevel > AccessLevel.Player)
				{
					cm.SendGump(new EsclaveListGump(cm, 0));
				}
				else
				{
					cm.SendMessage("Seul les Civenien et classe supérieur peuvent accèder à ce menu.");
				}


			}
		}
    }
}