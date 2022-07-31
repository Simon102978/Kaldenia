/*using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Network;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class Jail
	{	     
        public static void Initialize()
		{
            CommandSystem.Register("Jail", AccessLevel.Player, new CommandEventHandler(Jail_OnCommand));       
        }

		[Usage( "Jail" )]
		[Description("Jail a player")]
		private static void Jail_OnCommand( CommandEventArgs e )
		{
            Mobile from = e.Mobile;

            if (from != null && !from.Deleted)
            {

				if (from.AccessLevel > AccessLevel.Player)
				{
					int Minutes = 15;


					if (e.Length != 0)
					{					
						string emote = e.GetString(0);

						if (int.TryParse(emote, out int minuteParse))
						{
							Minutes = minuteParse;
						}
					}


					from.SendMessage("S�lectionner la personne � mettre en prison.");
					from.Target = new JailTarget(TimeSpan.FromMinutes(Minutes));
				}
				else
				{
					if (from is CustomPlayerMobile cp)
					{
						if (cp.Jail)
						{
							TimeSpan tempsRestant = cp.JailTime - DateTime.Now;

							if (tempsRestant.TotalDays > 2)
							{
								cp.SendMessage($"Il vous reste {tempsRestant.TotalDays} jours en dedans.");
							}
							else if (tempsRestant.TotalHours > 2)
							{
								cp.SendMessage($"Il vous reste {tempsRestant.TotalHours} heures en dedans.");
							}
							else 
							{
								cp.SendMessage($"Il vous reste {tempsRestant.TotalMinutes} minutes en dedans.");
							}
						}
						else
						{
							cp.SendMessage("Vous n'etes pas en prison MJ.");
						}

					}
				}
				

				
				
            }
		}
      
	}

    public class JailTarget : Target
    {
		TimeSpan m_Time;

        public JailTarget(TimeSpan time): base(15, false, TargetFlags.None)
        {
			m_Time = time;

		}

        protected override void OnTarget(Mobile from, object target)
        {
            if (from == null || from.Deleted)
                return;

            if ( target == null || !(target is CustomPlayerMobile))
            {
                from.SendMessage("Cette cible est inad�quate.");
                return;
            }

			CustomPlayerMobile targetted = target as CustomPlayerMobile;

            if (target != from)
            {           
                    if (from.AccessLevel >= targetted.AccessLevel)
                    {

					

						targetted.JailP(from, m_Time);
						CommandLogging.WriteLine(from, "{0} {1} a mis en prison {2} pour {3} minutes.", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targetted), CommandLogging.Format(m_Time.TotalMinutes));
						from.SendMessage($"Vous venez d'envoyer {targetted.Name} en prison pour {m_Time.TotalMinutes} minutes");
					}
                    else
                    {
                        from.SendMessage("Vous ne pouvez pas suivre un Mj avec un rang plus �lev� que vous.");
                        return;
                    }              
            }
        }
    }

}
*/