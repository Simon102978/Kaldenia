using Server.Items;

namespace Server.Commands
{
    class DetatouerCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Detatouer", AccessLevel.Player, new CommandEventHandler(Detatouer_OnCommand));
        }

        [Usage("Detatouer")]
        [Description("Retire tout ce que l'on porte et met le tout dans le sac.")]
        public static void Detatouer_OnCommand(CommandEventArgs e)
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
                    if (item is Tatou)
					{

						item.Delete();
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