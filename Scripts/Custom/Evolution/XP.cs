using System;
using System.IO;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using System.Collections.Generic;
using Server.Custom;

namespace Server
{
  public class XP
  {
    public static TimeSpan m_IntervaleXP = TimeSpan.FromMinutes(10);

    public static void Initialize()
    {
      new XPTimer().Start();
    }

    public class XPTimer : Timer
    {
      public XPTimer()
          : base(m_IntervaleXP, m_IntervaleXP)
      {
        Priority = TimerPriority.OneSecond;
      }

      protected override void OnTick()
      {

    	 int day = (int)(DateTime.Now - CustomPersistence.Ouverture).TotalDays + 1;

		 if(CustomPersistence.ProchainePay <= DateTime.Now)
		 {
			CustomPersistence.ProchainePay = CustomPersistence.ProchainePay.AddDays(7);
			Server.Custom.System.GuildRecruter.Pay();

		 }
      

        foreach (NetState state in NetState.Instances)
        {
          Mobile m = state.Mobile;

          if (m != null && m is CustomPlayerMobile)
          {
			CustomPlayerMobile pm = (CustomPlayerMobile)m;
			
			if(pm.FETotal >= day * 3 )
			{

			}
            else if (pm.NextFETime < TimeSpan.FromMinutes(10))
            {
             // if (pm.DailyFECount < 4)
             // {
                GainFE(pm);
                ResetFETime(pm);
            //  }
            }
            else
            {
              if (pm.LastLoginTime < DateTime.Now - TimeSpan.FromMinutes(10))
              {
                pm.NextFETime -= TimeSpan.FromMinutes(10);
              }
              else
              {
                pm.NextFETime -= DateTime.Now - pm.LastLoginTime;
              }
            }
          }
        }
      }
    }

    public static void ResetFETime(CustomPlayerMobile pm)
    {
			pm.NextFETime = TimeSpan.FromMinutes(45); /*m_CoteTimeSpan[GetCoteMoyenne(pm) - 1];*/
    }

  /*  public static void ResetEndOfDay()
    {
      ArrayList targets = new ArrayList();

      foreach (Mobile m in World.Mobiles.Values)
      {
        if (m is CustomPlayerMobile)
          targets.Add((CustomPlayerMobile)m);
      }

      if (targets.Count > 0)
      {
        for (int i = 0; i < targets.Count; i++)
        {
	     CustomPlayerMobile pm = (CustomPlayerMobile)targets[i];

          pm.DailyFECount = 0;
          if (pm.DailyFECount < 1)
          {
            ResetFETime(pm);
          }
        }
      }
    }*/

  /*  public static int GetCoteMoyenne(CustomPlayerMobile pm)
    {
      int CoteMoyenne = 0;

      foreach (Cote cotation in pm.CoteList)
      {
        CoteMoyenne += cotation.Rating;
      }

      if (pm.CoteList.Count > 0)
        return CoteMoyenne / pm.CoteList.Count;
      else
        return 4;
    }*/

    public static void GainFE(CustomPlayerMobile pm)
    {
      if (pm == null)
        return;

      pm.FE++;
	  pm.FETotal++;

	 pm.SendMessage("Vous obtenez une nouvelle FE !");

			if (pm.FEAttente > 0)
			{
				pm.FEAttente--;
				pm.FE++;
				pm.SendMessage("Vous r??#$?&*cup??#$?&*rer une FE en attente !");
			}

			if (pm.StatAttente > 0)
			{
				if (pm.StatAttente > 3)
				{
					pm.StatAttente -= 3;
				}
				else
				{
					pm.StatAttente = 0;
				}


				
			}
    
    }

  /*  public static void SetSkills(CustomPlayerMobile from, int skillcaptotal, double skillcapind)
    {
      from.SkillsCap = skillcaptotal;

      for (int i = 0; i < from.Skills.Length; ++i)
      {
        //if (!IsLoreSkill(from.Skills[i]))
        from.Skills[i].Cap = (double)skillcapind;
      }
    }
  */
 /*   public static void SetPAs(CustomPlayerMobile from)
    {
      /*from.AptitudesLibres++;

      int paEnAttente = Aptitudes.GetRemainingPA(from) - Aptitudes.GetDisponiblePA(from);

      //if (paEnAttente > 15)
      //    paEnAttente = 15;

      from.AptitudesLibres += paEnAttente;*/
    }

 /*   public static int GetNeededFE(CustomPlayerMobile pm)
    {
      if (pm == null)
        return 0;

      int neededFE = 0;

      if (pm.Niveau > 30)
      {
        neededFE = 210 + (12 * (pm.Niveau - 30));
      }
      else if (pm.Niveau > 40)
      {
        neededFE = 340 + (20 * (pm.Niveau - 40));
      }
      else
      {
        neededFE = m_FeReqTable[pm.Niveau - 1];
      }

      return neededFE;
    }*/

  /*  public static bool CanEvolve(Mobile from)
    {
      try
      {
        if (from is CustomPlayerMobile)
        {
		  CustomPlayerMobile pm = from as CustomPlayerMobile;

          int currentXP = pm.FE;
          int neededXP = GetNeededFE(pm);

          if (currentXP > neededXP)
          {
            return true;
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      return false;
    }

    public static void Evolve(Mobile from)
    {
      try
      {
        if (from is CustomPlayerMobile)
        {
	     CustomPlayerMobile pm = from as CustomPlayerMobile;

          int currentFE = pm.FE;
          int neededFE = GetNeededFE(pm);

          if (currentFE > neededFE)
          {
            pm.Niveau++;

            int SkillsCaps = 100;
            if (pm.Niveau > 0 && pm.Niveau < 31)
            {
              SkillsCaps = m_SkillCapTotalTable[pm.Niveau - 1];
            }
            else if (pm.Niveau > 30)
            {
              SkillsCaps = 800 + ((pm.Niveau - 30) * 10);
            }
            else if (pm.Niveau > 40)
            {
              SkillsCaps = 900 + ((pm.Niveau - 40) * 5);
            }

            double SkillsInd = 45;
            if (pm.Niveau > 0 && pm.Niveau < 31)
            {
              SkillsInd = m_SkillCapIndividuelTable[pm.Niveau - 1];
            }
            else if (pm.Niveau > 30)
            {
              SkillsInd = 100;
            }

            if (SkillsInd > 100)
              SkillsInd = 100;

            /*if (SkillsCaps > 800)
              SkillsCaps = 800;*/
  /*
            SetSkills(pm, SkillsCaps, SkillsInd);
            SetPAs(pm);

            pm.SendMessage("Vous gagnez un niveau !");
          }
          else
            pm.SendMessage("Il vous manque des points d'experiences pour gagner votre niveau !");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }*/
//  }
/*  public class Cote
  {
    public void Serialize(GenericWriter writer)
    {
      writer.Write((int)0); // version;

      writer.Write((Mobile)m_coteur);
      writer.Write((DateTime)m_cotetime);
      writer.Write((int)m_rating);
    }

    public Cote(CustomPlayerMobile owner, GenericReader reader)
    {
      int version = reader.ReadInt();

      m_coteur = reader.ReadMobile();
      m_cotetime = reader.ReadDateTime();
      m_rating = reader.ReadInt();
    }

    private Mobile m_coteur;
    private DateTime m_cotetime;
    private int m_rating;

    [CommandProperty(AccessLevel.GameMaster)]
    public DateTime CoteDate
    {
      get { return m_cotetime; }
      set { m_cotetime = value; }
    }
    [CommandProperty(AccessLevel.GameMaster)]
    public Mobile Coteur
    {
      get { return m_coteur; }
      set { m_coteur = value; }
    }
    [CommandProperty(AccessLevel.GameMaster)]
    public int Rating
    {
      get { return m_rating; }
      set { m_rating = value; }
    }

    public Cote()
    {
    }

    public Cote(Mobile Coteur)
    {
      m_coteur = Coteur;
    }

    public Cote(Mobile Coteur, DateTime date)
    {
      m_cotetime = date;
      m_coteur = Coteur;
    }

    public Cote(Mobile Coteur, DateTime date, int rating)
    {
      m_cotetime = CoteDate;
      m_coteur = Coteur;
      m_rating = Rating;
    }

    public int GetCoteRating()
    {
      return m_rating;
    }
  }*/
}