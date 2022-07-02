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
    public class StatutSocialeCommande
	{
        public static void Initialize()
        {
			CommandSystem.Register("StatutSociale", AccessLevel.GameMaster, new CommandEventHandler(StatutSociale_OnCommand));
		}

		[Usage("StatutSociale")]
		[Description("Permet d'acceder au menu d'esclave.")]
		public static void StatutSociale_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (!from.Alive)
				return;

			if (from is CustomPlayerMobile cm)
			{
				from.SendGump(new StatutGump(cm, 0));

			}
		}
    }
}