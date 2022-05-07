using Server.Mobiles;
using System;
using System.Collections.Generic;


namespace Server
{
  [PropertyObject]
  public class AffinityDictionary : Dictionary<MagieType, int>
  {
    private CustomPlayerMobile m_owner = null;

    public AffinityDictionary(CustomPlayerMobile owner)
    {
      m_owner = owner;
    }

    public AffinityDictionary(CustomPlayerMobile owner, GenericReader reader)
    {
      m_owner = owner;

      int version = reader.ReadInt();
      int count = reader.ReadInt();

      for (int i = 0; i < count; ++i)
      {
        Add((MagieType)reader.ReadInt(), reader.ReadInt());
      }
    }

    public void Serialize(GenericWriter writer)
    {
      writer.Write((int)0); // version;

      writer.Write((int)this.Count);

      foreach (KeyValuePair<MagieType, int> pair in this)
      {
        writer.Write((int)pair.Key);
        writer.Write((int)pair.Value);
      }
    }

    public int GetValue(MagieType Affinity)
    {
      return this.ContainsKey(Affinity) ? this[Affinity] : 0;
    }

	public void ChangeGod(God newGod)
	{
			if (m_owner.God != null)
			{
				foreach (KeyValuePair<MagieType, int> item in m_owner.God.Magie)
				{
					if (ContainsKey(item.Key))
					{
						this[item.Key] -= item.Value;
					}
					else
					{
						Add(item.Key, -item.Value);
					}

				}
			}

			if (newGod != null)
			{
				foreach (KeyValuePair<MagieType, int> item in newGod.Magie)
				{
					if (ContainsKey(item.Key))
					{
						this[item.Key] += item.Value;
					}
					else
					{
						Add(item.Key, item.Value);
					}

				}
			}
		}

	public void SetValue(MagieType Affinity, int value)
	{

	  if (m_owner.God.CheckAffinity(Affinity))
	  { 
		if(m_owner.God.Magie[Affinity] > value)
		{
		  return;
		}
	  }

	  if (this.ContainsKey(Affinity))
      {
        this[Affinity] = value;
      }
      else
      {
        Add(Affinity, value);
      }
    }

     #region Magie

    [CommandProperty(AccessLevel.GameMaster)]
    public int Anarchique
		{
      get { return GetValue(MagieType.Anarchique); }
      set { SetValue(MagieType.Anarchique, value); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Obeissance
		{
      get { return GetValue(MagieType.Obeissance); }
      set { SetValue(MagieType.Obeissance, value); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Cycle
		{
      get { return GetValue(MagieType.Cycle); }
      set { SetValue(MagieType.Cycle, value); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Vie
		{
      get { return GetValue(MagieType.Vie); }
      set { SetValue(MagieType.Vie, value); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Mort
		{
      get { return GetValue(MagieType.Mort); }
      set { SetValue(MagieType.Mort, value); }
    }

	[CommandProperty(AccessLevel.GameMaster)]
	public int Arcane
	{
		get { return GetValue(MagieType.Arcane); }
		set { SetValue(MagieType.Arcane, value); }
	}


	#endregion


	}
}
