using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 		
        class GodInit 
        {
				public static void Configure()
					{
							God.RegisterGod(new God(-1, "Aucun", new Dictionary<MagieType, int>(), 302,40, "Hérétique !"));

							God.RegisterGod(new God(0, "Greald", new Dictionary<MagieType, int>() { { MagieType.Obeissance, 8}, }, 303,0, "Hérétique !"));
							God.RegisterGod(new God(1, "Quirel", new Dictionary<MagieType, int>() { { MagieType.Vie, 8 }, }, 304,8, "Hérétique !"));
							God.RegisterGod(new God(2, "Seras", new Dictionary<MagieType, int>() { { MagieType.Anarchique, 8 }, }, 305,5, "Hérétique !"));
							God.RegisterGod(new God(3, "Zox", new Dictionary<MagieType, int>() { { MagieType.Mort, 8 }, }, 306,0, "Hérétique !"));
							God.RegisterGod(new God(4, "Celus", new Dictionary<MagieType, int>() { { MagieType.Cycle, 8 }, }, 307,13, "Hérétique !"));

		
					}
		}
}
