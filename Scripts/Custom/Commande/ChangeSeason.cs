using Server;
using Server.Commands;
using Server.Network;

namespace Nucca.Commands
{
    public static class ChangerSaison
    {
        public static void Initialize()
        {
			CommandSystem.Register("ChangerSaison", AccessLevel.Administrator, new CommandEventHandler(ChangerSaison_OnCommand));
		}

        [Usage("ChangerSaison [Printemps|Ete|Automne|Hiver|Desolation]")]
        [Description("Change la saison sur la carte.")]
		public static void ChangerSaison_OnCommand(CommandEventArgs e)
		{
            Mobile m = e.Mobile;
            
            if (e.Length != 1)
            {
                m.SendMessage("Usage: .ChangerSaison [Printemps|Ete|Automne|Hiver|Desolation]");
                return;
            }

            int season;

            switch (e.GetString(0).ToLower())
            {
                case "printemps":
                    season = 0;
                    break;
                case "ete":
                    season = 1;
                    break;
                case "automne":
                    season = 2;
                    break;
                case "hiver":
                    season = 3;
                    break;
                case "desolation":
                    season = 4;
                    break;
                default:
                    m.SendMessage("Usage: .ChangerSaison [Printemps|Ete|Automne|Hiver|Desolation]");
                    return;
            }

            Map map = m.Map;
            map.Season = season;

            foreach (NetState ns in NetState.Instances)
            {
                if (ns.Mobile == null || ns.Mobile.Map != map)
                    continue;

				ns.Send(SeasonChange.Instantiate(ns.Mobile.GetSeason(), true));
				ns.Mobile.SendEverything();
            }

            m.SendMessage("{0} La saison a ??#$?&*t??#$?&* chang??#$?&*e pour {1}.", map.Name, e.GetString(0));
        }
    }
}