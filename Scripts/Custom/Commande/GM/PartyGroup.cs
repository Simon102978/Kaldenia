using System.Collections.Generic;
using Server.Engines.PartySystem;

namespace Server.Custom.Misc
{
	public class PartyGroup
	{
		public static List<Mobile> GetGroupMembers(Mobile from)
		{
			List<Mobile> targets = new List<Mobile>();

			Party party = Party.Get(from);

			if (from == null)
				return targets;

			targets.Add(from);

			if (party != null && party.Count > 0)
			{
				for (int pm = 0; pm < party.Members.Count; pm++)
				{
					PartyMemberInfo pmi = (PartyMemberInfo)party.Members[pm];
					Mobile member = pmi.Mobile;
					if (from != member)
						targets.Add(member);
				}
			}

			return targets;
		}

		public static List<Mobile> GetGroupCloseMembers(Mobile from, int distance)
		{
			List<Mobile> targets = new List<Mobile>();

			Map map = from.Map;

			Party party = Engines.PartySystem.Party.Get(from);

			if (from == null)
				return targets;

			targets.Add(from);

			if (map != null)
			{
				double tile = distance;

				foreach (Mobile m in from.GetMobilesInRange((int)tile))
				{
					if (from != m)
					{
						if (party != null && party.Count > 0)
						{
							for (int pm = 0; pm < party.Members.Count; pm++)
							{
								PartyMemberInfo pmi = (PartyMemberInfo)party.Members[pm];
								Mobile member = pmi.Mobile;
								if (member.Serial == m.Serial)
									targets.Add(m);
							}
						}
					}
				}
			}
			return targets;
		}
	}
}
