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
    public class AddFE
    {
        public static void Initialize()
        {
			CommandSystem.Register("AddFE", AccessLevel.GameMaster, new CommandEventHandler(AddFe_OnCommand));

		}


		[Usage("AddFE")]
		[Description("Permet de donner une FE.")]
		public static void AddFe_OnCommand(CommandEventArgs e)
		{
            Mobile from = e.Mobile;

            if (!from.Alive)
                return;

				if (from is CustomPlayerMobile pm)
				{

					from.Target = new SetTarget();
				}

			
		}
		private class SetTarget : Target
		{
			public SetTarget()
				: base(15, true, TargetFlags.None)
			{

			}

			protected override void OnTarget(Mobile from, object targeted)
			{

					if (targeted is CustomPlayerMobile cp )
					{
						if ((DateTime.Now - cp.LastFERP).TotalHours > 1)
						{
							Fe fe = new Fe(cp);
							cp.AddToBackpack(fe);
							cp.LastFERP = DateTime.Now;
							cp.SendMessage("Félicitation ! Vous venez de recevoir une FE pour bon rp !");
					    	CommandLogging.WriteLine(from, "{0} {1} a donné une FE rp à {2}.", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(cp));
					}
						else
						{
							from.SendMessage("Ce joueur a reçu une fe rp il y a moins d'une heure.");
						}
					}
					else
					{
						from.SendMessage("Vous devez viser un personnage !");
					}
				
			}
		}
	}	
}