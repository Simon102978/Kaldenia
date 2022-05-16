using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class DeguisementFin
    {
        public static void Initialize()
        {
            CommandSystem.Register("DeguisementFin", AccessLevel.Player, new CommandEventHandler(DeguisementFin_OnCommand));
        }

        public static void DeguisementFin_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is CustomPlayerMobile)
            {
                CustomPlayerMobile from = e.Mobile as CustomPlayerMobile;

                if (from.Deguise)
                {
					from.Deguisement.RemoveDeguisement();

                    from.SendMessage("Vous retirez votre d�guisement.");
                }
                else
                {
                    from.SendMessage("Vous n'�tes pas d�guis�.");
                }
            }
        }
    }
}