using Server.Items;

namespace Server.Commands
{
    class DeshabillerCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Deshabiller", AccessLevel.Player, new CommandEventHandler(Deshabiller_OnCommand));
        }

        [Usage("Deshabiller")]
        [Description("Retire tout ce que l'on porte et met le tout dans le sac.")]
        public static void Deshabiller_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            var items = from.Items;

            for (int i = from.Items.Count - 1; i >= 0; i--)
            {
                Item item = null;

                try
                {
                    item = from.Items[i];
                }
                catch
                {
                    from.SendMessage("Erreur dans la recherche de l'item #{0}", i);
                    continue;
                }

                try
                {
                    if (!(item is Backpack) & (item.Movable))
					{

						from.PlaceInBackpack(item);
					}
				}
                catch
                {
                    from.SendMessage("L'item {0} n'a pas été déplacé dans votre sac à cause d'une erreur.");
                }
            }
        }
    }
}