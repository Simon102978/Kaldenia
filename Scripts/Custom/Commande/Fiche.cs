using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Scripts.Commands
{
    public class Fiche
    {
        public static void Initialize()
        {
            CommandSystem.Register("Fiche", AccessLevel.Player, new CommandEventHandler(Fiche_OnCommand));
			CommandSystem.Register("Fe", AccessLevel.Player, new CommandEventHandler(Fe_OnCommand));
		}

        [Usage("Fiche")]
        [Description("Permet d'ouvrir le menu .Fiche")]
        public static void Fiche_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is CustomPlayerMobile)
            {
                from.CloseGump(typeof(FicheGump));


                from.SendGump(new FicheGump((CustomPlayerMobile)from, null));
            }
		}


		[Usage("Fe")]
			[Description("Permet de voir le nombre de Fioles obtenues")]
			public static void Fe_OnCommand(CommandEventArgs e)
			{
			CustomPlayerMobile from = (CustomPlayerMobile)e.Mobile;
			
				from.SendMessage("Vous avez " + from.FETotal + " Fioles d'Expériences.");

			}
    }
}


