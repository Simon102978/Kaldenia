using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using System.Collections.Generic;
using Server.Gumps;
using Server.Commands;
using Server.Mobiles;
using Server.SkillHandlers;
using Server.CustomScripts;

namespace Server.Commands
{
    class FrapperCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Frapper", AccessLevel.Player, new CommandEventHandler(Frapper_OnCommand));
        }

        [Usage("Frapper")]
        [Description("Frapper à une porte")]
        public static void Frapper_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            from.SendMessage("Sélectionner la porte sur laquelle vous voulez frapper.");
            from.Target = new FrapperTarget(); // Call our target
        }
    }

    public class FrapperTarget : Target
    {
        public FrapperTarget()
            : base(10, false, TargetFlags.None)
        {
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target is BaseDoor targ && from is CustomPlayerMobile cp)
            {
				bool canKnock = true;

				if (from.IsStaff())
				{
					from.SendMessage("Du a vos pouvoirs divins, vous cogner à la porte.");
					canKnock = true;
				}
				else if (!from.InLOS(targ))
				{
					from.SendMessage("Vous devez avoir la vision de la porte pour pouvoir cogner.");
					canKnock = false;
				}
				else if (!from.InRange(targ, 2))
				{
					from.SendMessage("Vous devez être à moin de deux cases pour cogner à la porte.");
					canKnock = false;
				}
				else if (cp.NextFrapper > DateTime.Now)
				{
					from.SendMessage("Vous devez attendre avant de cogner à nouveau.");
					canKnock = false;
				}

				if (canKnock)
				{
					targ.PublicOverheadMessage(MessageType.Emote, 0, false, String.Format("*On frappe à la porte.*"));
					cp.NextFrapper = DateTime.Now.AddSeconds(30);


				}

			}
            else
                from.SendMessage("Cible non valide");
        }

























    }
}