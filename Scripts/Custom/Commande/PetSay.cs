using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class PetSay
	{
		public static void Initialize()
		{
            CommandSystem.Register("petsay", AccessLevel.Player, new CommandEventHandler(PetSay_OnCommand));
		}

        [Usage("PetSay")] 
	    [Description( "Permet de faire dire quelque chose à son animal de compagnie.")]
        public static void PetSay_OnCommand(CommandEventArgs e)
		{
			if ( e.Length != 1 )
			{
				e.Mobile.SendMessage( "Utilisation : petsay <message>" );
			}
			else
			{
                e.Mobile.Target = new PetSayTarget((string)e.GetString(0));
			}
		}
	}

	public class PetSayTarget : Target
	{
		private string m_Message;

        public PetSayTarget(string mess)
            : base(-1, false, TargetFlags.None)
		{
			m_Message = mess;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
            if (targeted is BaseCreature)
            {
                BaseCreature targ = (BaseCreature)targeted;

                if (from.AccessLevel >= AccessLevel.Counselor)
                {
                    targ.Say(m_Message);
                }
                else if (targ.Summoned && (from == targ.SummonMaster || from == targ.ControlMaster))
                {
                    targ.Say(m_Message);
                }
                else if (from == targ.ControlMaster && targ.Controlled && from.Skills[SkillName.AnimalTaming].Base >= targ.MinTameSkill)
                {
                    targ.Say(m_Message);
                }
                else
                    from.SendMessage("Vous n'êtes pas le maître de cette créature ou vous ne possèdez pas le niveau nécessaire en Animal Taming pour faire agir cette créature.");
                
            }
            else
                from.SendMessage(256, "Il faut cliquer sur une créature.");
		}
	}
}