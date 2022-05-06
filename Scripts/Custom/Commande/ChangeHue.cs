using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Commands
{
	public class ChangeHue
    {
		public static void Initialize()
		{
			CommandSystem.Register( "ChangeHue", AccessLevel.GameMaster, new CommandEventHandler(CH) );
			
		}

		[Usage( "CH" )]
		[Description( "Pour se promener sur les hues raciaux." )]
        private static void CH( CommandEventArgs arg )
		{
            arg.Mobile.Race.ChangeHue(arg.Mobile);       
		}

		
	}
   
   
}
