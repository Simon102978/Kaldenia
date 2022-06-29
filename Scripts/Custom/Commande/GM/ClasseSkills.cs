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
    public class ClasseSkill
    {
        public static void Initialize()
        {
			CommandSystem.Register("ClasseSkill", AccessLevel.GameMaster, new CommandEventHandler(ClasseSkill_OnCommand));

		}


		[Usage("ClasseSkill")]
		[Description("Permet de set tout les skills de classes %%%#$%?%$#@! un niveau.")]
		public static void ClasseSkill_OnCommand(CommandEventArgs e)
		{
            Mobile from = e.Mobile;

            if (!from.Alive)
                return;

			int skills = -1;

			int.TryParse(e.ArgString, out skills);

			bool error = false;

			if (skills < 0 || skills > 120)
			{
				error = true;

			}
			else
			{
				if (from is PlayerMobile pm)
				{

					from.Target = new SetTarget(skills);
				}
				else
				{
					from.SendMessage("Veuillez selectionner un joueur.");
				}
			}

			if (error)
			{
				
				from.SendMessage("Vous pouvez seulement set les skills en 0 et 120."); // Placeholder
			}
		}
		private class SetTarget : Target
		{
			private double m_Skills;


			public SetTarget(double skills)
				: base(15, true, TargetFlags.None)
			{
				m_Skills = skills;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{

					if (targeted is CustomPlayerMobile cp )
					{
					cp.SetClasseSkills(m_Skills);

					}
					else
					{
						from.SendMessage("Vous devez viser un personnage !");
					}
				
			}
		}





	}	
}