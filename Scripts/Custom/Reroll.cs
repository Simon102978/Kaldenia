#region References
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
#endregion

namespace Server
{
    [Parsable]
    public class Reroll
    {
		private int m_Id;
        private string m_Name;
        private double m_ExperienceNormal;
		private double m_ExperienceRP;

		public int Id { get => m_Id; set => m_Id = value; }

		public string Name { get => m_Name; set => m_Name = value; }
        public double ExperienceNormal { get => m_ExperienceNormal; set => m_ExperienceNormal = value; }
		public double ExperienceRP { get => m_ExperienceRP; set => m_ExperienceRP = value; }

		public Reroll()
        {

        }

        public Reroll(CustomPlayerMobile sp)
        {

			
            Name = sp.Name;
			ExperienceNormal = sp.FENormalTotal;
			ExperienceRP = sp.FERPTotal;
        }
    }


}
