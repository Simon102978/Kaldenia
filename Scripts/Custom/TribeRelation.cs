using Server.Mobiles;
using System;
using System.Collections.Generic;


namespace Server
{
  [PropertyObject]
  public class TribeRelation : Dictionary<TribeType, int>
  {
    private CustomPlayerMobile m_owner = null;

    public TribeRelation(CustomPlayerMobile owner)
    {
      m_owner = owner;
    }

    public TribeRelation(CustomPlayerMobile owner, GenericReader reader)
    {
      m_owner = owner;

      int version = reader.ReadInt();
      int count = reader.ReadInt();

      for (int i = 0; i < count; ++i)
      {
        Add((TribeType)reader.ReadInt(), reader.ReadInt());
      }
    }

    public void Serialize(GenericWriter writer)
    {
      writer.Write((int)0); // version;

      writer.Write((int)this.Count);

      foreach (KeyValuePair<TribeType, int> pair in this)
      {
        writer.Write((int)pair.Key);
        writer.Write((int)pair.Value);
      }
    }

    public int GetValue(TribeType tribe)
    {
      return this.ContainsKey(tribe) ? this[tribe] : 0;
    }


	public void SetValue(TribeType tribe, int value)
	{
	  if (this.ContainsKey(tribe))
      {
        this[tribe] = value;
      }
      else
      {
        Add(tribe, value);
      }
    }

     #region Tribe

		[CommandProperty(AccessLevel.GameMaster)]
		public int Terathan
			{
		  get { return GetValue(TribeType.Terathan); }
		  set { SetValue(TribeType.Terathan, value); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Ophidian
			{
		  get { return GetValue(TribeType.Ophidian); }
		  set { SetValue(TribeType.Ophidian, value); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Savage
			{
		  get { return GetValue(TribeType.Savage); }
		  set { SetValue(TribeType.Savage, value); }
		}

		
		[CommandProperty(AccessLevel.GameMaster)]
		public int Orc
			{
		  get { return GetValue(TribeType.Orc); }
		  set { SetValue(TribeType.Orc, value); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Fey
			{
		  get { return GetValue(TribeType.Fey); }
		  set { SetValue(TribeType.Fey, value); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Undead
			{
		  get { return GetValue(TribeType.Undead); }
		  set { SetValue(TribeType.Undead, value); }
		}

		
		[CommandProperty(AccessLevel.GameMaster)]
		public int GrayGoblin
			{
		  get { return GetValue(TribeType.GrayGoblin); }
		  set { SetValue(TribeType.GrayGoblin, value); }
		}

				
		[CommandProperty(AccessLevel.GameMaster)]
		public int GreenGoblin
		{
		  get { return GetValue(TribeType.GreenGoblin); }
		  set { SetValue(TribeType.GreenGoblin, value); }
		}

				
		[CommandProperty(AccessLevel.GameMaster)]
		public int Kuya
		{
		  get { return GetValue(TribeType.Kuya); }
		  set { SetValue(TribeType.Kuya, value); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Brigand
		{
			get { return GetValue(TribeType.Brigand); }
			set { SetValue(TribeType.Brigand, value); }
		}
		#endregion


	}
}
