#region References
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Server
{
	[Parsable]
	public class God
	{
		private static readonly List<God> m_AllGods = new List<God>();
		public static List<God> AllGods => m_AllGods;
		private int m_GodID;
		private string m_Name;
		private Dictionary<MagieType, int> m_Magie = new Dictionary<MagieType, int>();
		private int m_GumpId = 0;
		private int m_GumpXAdjustement = 0;
		private string m_BG = "";
	
		public static God GetGod(int Id)
		{
			foreach (God item in m_AllGods)
			{
				if (item.GodID == Id)
				{
					return item;
				}
			}

			return null;
		}

		public override string ToString()
		{
			return m_Name;
		}

		public God(
			int GodID,
			string name,
			Dictionary<MagieType, int> magie,
			int gumpId,
			int gumpXAdjustement,
			string bg
			)
		{
			m_GodID = GodID;
			m_Name = name;
			m_Magie = magie;
			m_GumpId = gumpId;
			m_BG = bg;
			m_GumpXAdjustement = gumpXAdjustement;
		}

		public static void RegisterGod(God God)
		{
			God.AllGods.Add(God);
		}



	    public virtual bool CheckMagie(MagieType magie, int value)
		{
			if (m_Magie[magie] >= value)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public virtual bool CheckAffinity(MagieType magie)
		{
			if (!m_Magie.ContainsKey(magie))
			{
				return false;
			}
			else if (m_Magie[magie] == 0)
			{
				return false;
			}

			return true;

			
		
		}



		public virtual void RemoveGod(Mobile m)
		{

		}
		public virtual void CheckGump(Mobile m)
		{

		}

		public static string[] GetGodsNames()
		{

			List<string> GodName = new List<string>();

			foreach (God item in AllGods)
			{
				GodName.Add(item.Name);
			}

			return GodName.ToArray();
		}

		public int GodID => m_GodID;

		public string Name { get => m_Name; set => m_Name = value; }

		public Dictionary<MagieType, int> Magie { get => m_Magie; set => m_Magie = value; }

		public string BG => m_BG;

		public int GumpID => m_GumpId;

		public int GumpXAdjustement => m_GumpXAdjustement;



	}
}
