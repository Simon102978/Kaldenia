using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using System.Linq;

namespace Server.Gumps
{
  public class StatueGump : BaseProjectMGump
  {
        Statue m_Statue;
        CustomPlayerMobile m_from;
        int m_Page;
		StatueEnCours StatueCours;




  public StatueGump(CustomPlayerMobile from, Statue Statue, int Page = 0, StatueEnCours pEc = null )
        : base("Statue", 350, Statue.Finish ? 375 : 475)
    {	 
		  m_Statue = Statue;
		  m_from = from;
		  int x = XBase;
		  int y = YBase;
		  int line = 0;
		  int scale = 30;
		  m_Page = Page;


		  if(pEc == null && !Statue.Finish)
		  {
			 StatueCours = new StatueEnCours(Statue.Title, Statue.CrafterName, Statue.Description);
		  }
		  else
		  {
				StatueCours = pEc;

		  }
	  
	 	  AddSection(x , y , 380, 115, "En-tête");

		  AddHtmlTexteColored(x + 15, y + 45 + line * scale, 90, "Titre: ", "#ffffff");		

		  if (!Statue.Finish)
		  {
			AddTextEntryBg(x + 73, y + 40 + line * scale , 290, 25, 0, 100, StatueCours.Title);
	      }
		  else
		  {	
			AddHtmlTexteColored(x + 73, y + 45 + line * scale, 300, Statue.Title, "#ffffff");
		  }

		  line++;

		  AddHtmlTexteColored(x + 15, y + 45 + line * scale, 90, "Par: ", "#ffffff");

		  if (!Statue.Finish)
		  {
				AddTextEntryBg(x + 73, y + 40 + line * scale, 290, 25, 0, 200, StatueCours.Name);
				line++;
		  }
		  else
		  {
				AddHtmlTexteColored(x + 73, y + 45 + line * scale, 300, Statue.CrafterName, "#ffffff");
				line++;
		  }

		  line++;

		  if (!Statue.Finish)
		  {
			AddSection(x, y + 116, 380, 300, "Description", string.Empty);
			AddButton(x + 351, y + line * scale + 69, 4, 251, 250);
			AddButton(x + 351, y + line * scale + 69 + 219, 5, 253, 252);

			line += 3;

			y += line * scale - 15;

			scale = 23;
			line = 0;

			for (int i = 0 + 10 * m_Page; i < 10 * (m_Page + 1); ++i)
			{
				AddTextEntry(x + 25, y + line * scale, 280, 15, 0, i, StatueCours.GetContenu(i));
				line++;
			}
		  }
		  else
		  {
				AddSection(x, y + 116, 380, 300, "Description", string.Join("\n", Statue.Description.Values.ToArray()));
		  }

		  if(!Statue.Finish)
		  {
				AddSection(x, YBase + 417, 380, 100, "Validation");

				AddButton(x + 80, YBase + 462, 1, 1147, 1148);
				AddButton(x + 230, YBase + 462, 0, 1144, 1145);

			}
	}

	public override void OnResponse(NetState sender, RelayInfo info)
    {
      CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

      if (from.Deleted || !from.Alive)
        return;

	  if(!m_Statue.Finish)
	  {

				if (info.GetTextEntry(100) != null)
				{
					StatueCours.Title = info.GetTextEntry(100).Text;
				}

				if (info.GetTextEntry(200) != null)
				{
					StatueCours.Name = info.GetTextEntry(200).Text;
				}

				TextRelay entry;

				for (int i = 0 + 10 * m_Page; i < (m_Page + 1) * 10; ++i)
				{

					entry = info.GetTextEntry(i);

					StatueCours.addContenu(i, entry.Text.Trim());
				}


			

				switch (info.ButtonID)
				{
					case 1:
						{
							m_Statue.ApplyStatue(StatueCours);
							break;
						}
					case 2:
						{
							// ?
							break;
						}
					case 3:
						{
							// ?
							break;
						}
					case 4:
						{
							int pagi = m_Page;

							if (pagi > 0)
							{
								pagi -= 1;
							}					

							m_from.SendGump(new StatueGump(m_from, m_Statue, pagi, StatueCours));

							break;
						}
					case 5:
						{
							int pagi = m_Page + 1;

							if (pagi >= 5)
							{
								pagi = 5;
							}

							m_from.SendGump(new StatueGump(m_from, m_Statue, pagi, StatueCours));
							break;
						}


				}


			}
    }  

  }

  public class StatueEnCours
  {
		private string m_Title;
		private string m_Name;
		private Dictionary<int, string> m_Description = new Dictionary<int, string>();
		public string Title { get => m_Title; set => m_Title = value; }
		public string Name { get => m_Name; set => m_Name = value; }
		public Dictionary<int, string> Description { get => m_Description; set => m_Description = value; }

		public StatueEnCours(string title, string name, Dictionary<int, string> description)
		{
			m_Title = title;
			m_Name = name;

			foreach (KeyValuePair<int, string> item in description)
			{
				m_Description.Add(item.Key,item.Value);
			}
		}

		public string GetContenu(int Entry)
		{
			if (Description.ContainsKey(Entry))
			{
				return Description[Entry];
			}
			else
			{
				return "";
			}


		}

		public void addContenu(int Entry, string value)
		{
			if (m_Description.ContainsKey(Entry))
			{
				m_Description[Entry] = value;
			}
			else
			{
				m_Description.Add(Entry, value);
			}


		}


	}






}

