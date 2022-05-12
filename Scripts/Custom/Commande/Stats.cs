using Server;
using Server.Commands;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Commands
{
    public static class StatsMobiles
	{
        public static void Initialize()
        {
			CommandSystem.Register("StatsMobiles", AccessLevel.GameMaster, new CommandEventHandler(StatsMobiles_OnCommand));
			CommandSystem.Register("StatsItems", AccessLevel.GameMaster, new CommandEventHandler(StatsItems_OnCommand));
		}

        [Usage("StatsMobiles")]
        [Description("Permet de trouver les mobiles sur la cartes.")]
		public static void StatsMobiles_OnCommand(CommandEventArgs e)
		{
			if (e.Mobile is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)e.Mobile;

				cp.SendGump(new StatsMobileGump(cp));
			}


			


		}

		[Usage("StatsItems")]
		[Description("Permet de trouver les items sur la cartes.")]
		public static void StatsItems_OnCommand(CommandEventArgs e)
		{
			if (e.Mobile is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)e.Mobile;

				cp.SendGump(new StatsItemsGump(cp));
			}





		}
	}
}