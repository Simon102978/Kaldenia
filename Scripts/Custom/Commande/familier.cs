using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Commands
{
	public class Familiers
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Familier", AccessLevel.Player, new CommandEventHandler( Familier ) );
			
		}

		[Usage( "Familier" )]
		[Description( "Pour avoir accès au commande des familiers." )]
        private static void Familier ( CommandEventArgs arg )
		{
            arg.Mobile.Target = new FamiTarget();           
        }

		
	}
    public class FamiTarget : Target
    {
        
        public FamiTarget () : base(-1, true, TargetFlags.None)
        {
           
        }

        protected override void OnTarget(Mobile from, object o)
        {
            


            if (o is BaseCreature)
            {

                BaseCreature m = (BaseCreature)o;

                if (from == m.ControlMaster || from.AccessLevel >= AccessLevel.GameMaster)
                {



                    ((PlayerMobile)from).SendGump(new FamilierGump(from, m));
                }
                else
                {
                    from.SendMessage("Vous devez avoir le contrôle de la créature ciblée.");
                }             
            }
            else
            {
                from.SendMessage("Vous devez cibler une créature.");
            }
             
        }
    }
   
}