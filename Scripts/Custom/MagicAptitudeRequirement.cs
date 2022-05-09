using Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Spells
{
  public class MagicAptitudeRequirement
  {
    private int m_RequiredValue = 0;
    private MagieType m_RequiredAffinity;

    public int RequiredValue { get { return m_RequiredValue; } set { m_RequiredValue = value; } }
    public MagieType RequiredAffinity { get { return m_RequiredAffinity; } set { m_RequiredAffinity = value; } }

    public MagicAptitudeRequirement(MagieType Affinity, int value)
    {
	 RequiredAffinity = Affinity;
      RequiredValue = value;
    }
  }
}
