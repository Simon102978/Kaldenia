#region References
using System;
using Server.Mobiles;
using System.Reflection;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
#endregion

namespace Server
{
    [Parsable]
    public class Deguisement
    {
      
        private BaseRace m_Race;
        private int m_Hue;
        private bool m_female;
		private string m_Name;
		private string m_Title;
		private Dictionary<int, string> m_Paperdoll = new Dictionary<int, string>();


		private CustomPlayerMobile m_Player;
		private AppearanceEnum m_Appearance = (AppearanceEnum)(-1);
		private GrandeurEnum m_Grandeur = (GrandeurEnum)(-1);
		private GrosseurEnum m_Grosseur = (GrosseurEnum)(-1);
		private StatutSocialEnum m_StatutSocial = StatutSocialEnum.Aucun;

		public BaseRace Race
        {
            get => m_Race;
            set
            {
                if (m_Race != value)
                {
                    ChangeRace();
                }
                m_Race = value;
            }
             
        }

		public string Name { get => m_Name; set => m_Name = value; }

		public string Title { get => m_Title; set => m_Title = value; }

		public int Hue { get => m_Hue; set => m_Hue = value; }

		public AppearanceEnum Appearance { get => m_Appearance; set => m_Appearance = value; }

		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }

		public GrosseurEnum Grosseur { get => m_Grosseur; set => m_Grosseur = value; }

		public StatutSocialEnum StatutSocial { get => m_StatutSocial; set => m_StatutSocial = value; }

		public Dictionary<int, string> Paperdoll { get => m_Paperdoll; set => m_Paperdoll = value; }

		public bool Female
        {
            get => m_female;
            set
            {
                if (m_female != value)
                {
                    ChangeSexe();
                }


                m_female = value;
            }
       }
 
		public Deguisement(CustomPlayerMobile player)
        {
			m_female = player.Female;
			m_Name = player.Name;
			m_Player = player;
			m_Hue = player.Hue;
			m_Appearance = player.Beaute;
			m_Grandeur = m_Player.Grandeur;
			m_Grosseur = m_Player.Grosseur;
			m_StatutSocial = m_Player.StatutSocial;
			m_Race = (BaseRace) m_Player.Race;
		}

		public Deguisement(Deguisement deg)
		{

			m_female = deg.Female;
			m_Name = deg.Name;
			m_Player = deg.m_Player;
			m_Hue = deg.Hue;
			m_Appearance = deg.Appearance;
			m_Grandeur = deg.Grandeur;
			m_Grosseur = deg.Grosseur;
			m_Race = (BaseRace)deg.Race;
			m_Title = deg.Title;
			m_Paperdoll = deg.Paperdoll;

	}

	    public Deguisement()
		{

		}

		public void ChangeRace()
        {
            m_Hue = -1;
			m_Appearance = (AppearanceEnum)(-1);
			m_Grandeur = (GrandeurEnum)(-1);
			m_Grosseur = (GrosseurEnum)(-1);


		}

        public void ChangeSexe()
        {
            
        }

		public bool InfoGeneral()
		{

			if (m_Appearance == (AppearanceEnum)(-1) || m_Grandeur == (GrandeurEnum)(-1) || m_Grosseur == (GrosseurEnum)(-1))
			{
				return false;
			}
			else if (Name.Length < 3)
			{
				return false;
			}
			else
			{
				return true;
			}			
		}

		public void AddPaperdollEntry(string entry, int page)
		{
			if (m_Paperdoll.ContainsKey(page))
			{
				m_Paperdoll[page] = entry;
			}
			else
			{
				m_Paperdoll.Add(page, entry);
			}
		}

		public string GetPaperdollEntry(int page)
		{
			if (m_Paperdoll.ContainsKey(page))
			{
				return m_Paperdoll[page];
			}
			else
			{
				return "";
			}
		}

		public string GetProfile()
		{

			string text = "";


			for (int i = 0; i < Paperdoll.Count; i++)
			{
				text = text + GetPaperdollEntry(i);
			}

			return text;

		}


		public string GetStatutSocial()
		{
			if (m_StatutSocial != (StatutSocialEnum)(-1))
			{
				var type = typeof(StatutSocialEnum);
				MemberInfo[] memberInfo = type.GetMember(m_StatutSocial.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "Aucunwe";
		}

		public string GetApparence()
		{
			if (m_Appearance != (AppearanceEnum)(-1))
			{
				var type = typeof(AppearanceEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Appearance.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "Aucune";
		}

		public string GetGrosseur()
		{
			if (Grosseur != (GrosseurEnum)(-1))
			{
				var type = typeof(GrosseurEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Grosseur.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "Aucune";
		}

		public string GetGrandeur()
		{
			if (Grandeur != (GrandeurEnum)(-1))
			{
				var type = typeof(GrandeurEnum);
				MemberInfo[] memberInfo = type.GetMember(m_Grandeur.ToString());
				Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
				return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
			}

			return "Aucune";
		}

		public void Valide()
        {
/*			m_Player.Female = m_female;
			m_Player.Race = m_Race;
			m_Player.Race.RemoveRace(m_Player);	
			Race.AddRace(m_Player, m_Hue);
			m_Player.Name = m_Name;
			m_Player.Beaute = m_Appearance;
			m_Player.Grandeur = m_Grandeur;
			m_Player.Grosseur = m_Grosseur;*/
		}


		public void Serialize(GenericWriter writer)
		{

			writer.Write((int)1);

			writer.Write((int)m_StatutSocial);
			writer.Write(m_Race.RaceID);
			writer.Write(m_Hue);
			writer.Write(m_female);

			writer.Write(m_Name);
			writer.Write(m_Title);
			writer.Write(m_Player);
			writer.Write((int)m_Appearance);
			writer.Write((int)m_Grandeur);
			writer.Write((int)m_Grosseur);


			writer.Write(m_Paperdoll.Count);

			foreach (KeyValuePair<int, string> item in m_Paperdoll)
			{
				writer.Write(item.Key);
				writer.Write(item.Value);
			}

		}


		public static Deguisement Deserialize(GenericReader reader)
		{
			Deguisement mc = new Deguisement();


			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						mc.StatutSocial = (StatutSocialEnum)reader.ReadInt();
						goto case 0;
					}
				case 0:
					{
						mc.Race = (BaseRace)BaseRace.GetRace(reader.ReadInt());
						mc.Hue = reader.ReadInt();
						mc.Female = reader.ReadBool();
						mc.Name = reader.ReadString();
						mc.Title = reader.ReadString();
						mc.m_Player = (CustomPlayerMobile)reader.ReadMobile();
						mc.Appearance = (AppearanceEnum)reader.ReadInt();
						mc.Grandeur = (GrandeurEnum)reader.ReadInt();
						mc.Grosseur = (GrosseurEnum)reader.ReadInt();

						int count = (int)reader.ReadInt();

						for (int i = 0; i < count; i++)
						{
							mc.Paperdoll.Add(reader.ReadInt(), reader.ReadString());
						}

						break;
					}
			}
			return mc;
		}


		public bool DeguisementValide()
		{
			if (m_Appearance == (AppearanceEnum)(-1))
			{
				return false;
			}
			else if (m_Grandeur == (GrandeurEnum)(-1))
			{
				return false;
			}
			else if(m_Grosseur == (GrosseurEnum)(-1))
			{
				return false;
			}
			else if (Name.Length < 3)
			{
				m_Player.SendMessage("Votre nom doit contenir plus de 3 caractères.");
				return false;
			}

			return true;
		}



		public void ApplyDeguisement()
		{
			if (DeguisementValide())
			{
				m_Player.Deguise = true;
				m_Player.Female = Female;
				m_Player.Race = Race;
				m_Player.Race.RemoveRace(m_Player);
				Race.AddRace(m_Player, m_Hue);

				m_Player.SendMessage("Vous etes maintenant déguisé.");
			}
			else
			{
				m_Player.SendMessage("Vous devez remplir correctement tout le menu.");
			}


			

		}

		public void RemoveDeguisement()
		{

			m_Player.Deguise = false;
			m_Player.Female = m_Player.BaseFemale;
			m_Player.Race = m_Player.BaseRace;
			m_Player.Race.RemoveRace(m_Player);
			Race.AddRace(m_Player, m_Player.BaseHue);


		}


	}


}
