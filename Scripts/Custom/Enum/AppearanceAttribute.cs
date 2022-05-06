using System;

namespace Server
{
  public class AppearanceAttribute : Attribute
  {
    private string m_maleAdjective;
    private string m_femaleAdjective;

    public string MaleAdjective { get { return m_maleAdjective; } private set { m_maleAdjective = value; } }
    public string FemaleAdjective { get { return m_femaleAdjective; } private set { m_femaleAdjective = value; } }

    public AppearanceAttribute(string maleAdjective, string femaleAdjective)
    {
      m_maleAdjective = maleAdjective;
      m_femaleAdjective = femaleAdjective;
    }
  }
}
