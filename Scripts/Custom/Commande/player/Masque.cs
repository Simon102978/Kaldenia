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
    public class IdentiteCache
    {
        public static void Initialize()
        {
			CommandSystem.Register("masque", AccessLevel.Player, new CommandEventHandler(masque_OnCommand));
		}

		[Usage("masque")]
		[Description("Permet de masquer son identite.")]
		public static void masque_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (!from.Alive)
				return;

			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cm = (CustomPlayerMobile)from;

				if (cm.Masque)
				{
	//				from.SendMessage("Vous r??#$?&*velez votre identit??#$?&*.");
					cm.Masque = false;
				}
				else if (cm.NameMod != null)
				{
					from.SendMessage("Vous ne pouvez pas cacher votre identit??#$?&* pour le moment.");
				}
				else if (cm.CacheIdentite())
				{
					from.SendMessage("Vous cachez votre identit??#$?&*.");
					cm.Masque = true;
				}
				else
				{
					from.SendMessage("Vous devez avoir un foulard ou un casque qui permet de cacher votre identit??#$?&*.");
				}
			}
		}
    }
}