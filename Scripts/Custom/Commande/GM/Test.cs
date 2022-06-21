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
    public class TestCommand
    {
        public static void Initialize()
        {
			CommandSystem.Register("Crash", AccessLevel.GameMaster, new CommandEventHandler(Crash_OnCommand));
			CommandSystem.Register("Globalization", AccessLevel.GameMaster, new CommandEventHandler(Globalization_OnCommand));

		}


		[Usage("Crash")]
		[Description("Permet de faire crasher le serveur.")]
		public static void Crash_OnCommand(CommandEventArgs e)
		{
			int blop = int.Parse("Blop");


		}


		[Usage("Globalization")]
		[Description("Permet savoir la globalization.")]
		public static void Globalization_OnCommand(CommandEventArgs e)
		{

			e.Mobile.SendMessage(System.Globalization.CultureInfo.CurrentCulture.ToString());


		}





	}	
}