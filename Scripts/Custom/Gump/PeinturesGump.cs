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
  public class PeinturesGump : BaseProjectMGump
  {
        Peintures m_Peinture;
        CustomPlayerMobile m_from;
        int m_Page;
		PeintureEnCours PeintureCours;




  public PeinturesGump(CustomPlayerMobile from, Peintures peinture, int Page = 0, PeintureEnCours pEc = null )
        : base("Peinture", 350, peinture.Finish ? 375 : 475)
    {	 
		  m_Peinture = peinture;
		  m_from = from;
		  int x = XBase;
		  int y = YBase;
		  int line = 0;
		  int scale = 30;
		  m_Page = Page;


		  if(pEc == null && !peinture.Finish)
		  {
			 PeintureCours = new PeintureEnCours(peinture.Title, peinture.CrafterName, peinture.Description);
		  }
		  else
		  {
				PeintureCours = pEc;

		  }
	  
	 	  AddSection(x , y , 380, 115, "En-tête");

		  AddHtmlTexteColored(x + 15, y + 45 + line * scale, 90, "Titre: ", "#ffffff");		

		  if (!peinture.Finish)
		  {
			AddTextEntryBg(x + 73, y + 40 + line * scale , 290, 25, 0, 100, PeintureCours.Title);
	      }
		  else
		  {	
			AddHtmlTexteColored(x + 73, y + 45 + line * scale, 300, peinture.Title, "#ffffff");
		  }

		  line++;

		  AddHtmlTexteColored(x + 15, y + 45 + line * scale, 90, "Par: ", "#ffffff");

		  if (!peinture.Finish)
		  {
				AddTextEntryBg(x + 73, y + 40 + line * scale, 290, 25, 0, 200, PeintureCours.Name);
				line++;
		  }
		  else
		  {
				AddHtmlTexteColored(x + 73, y + 45 + line * scale, 300, peinture.CrafterName, "#ffffff");
				line++;
		  }

		  line++;

		  if (!peinture.Finish)
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
				AddTextEntry(x + 25, y + line * scale, 280, 15, 0, i, PeintureCours.GetContenu(i));
				line++;
			}
		  }
		  else
		  {
				AddSection(x, y + 116, 380, 300, "Description", string.Join("\n", peinture.Description.Values.ToArray()));
		  }

		  if(!peinture.Finish)
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

	  if(!m_Peinture.Finish)
	  {

				if (info.GetTextEntry(100) != null)
				{
					PeintureCours.Title = info.GetTextEntry(100).Text;
				}

				if (info.GetTextEntry(200) != null)
				{
					PeintureCours.Name = info.GetTextEntry(200).Text;
				}

				TextRelay entry;

				for (int i = 0 + 10 * m_Page; i < (m_Page + 1) * 10; ++i)
				{

					entry = info.GetTextEntry(i);

					PeintureCours.addContenu(i, entry.Text.Trim());
				}


			

				switch (info.ButtonID)
				{
					case 1:
						{
							m_Peinture.ApplyPeinture(PeintureCours);
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

							m_from.SendGump(new PeinturesGump(m_from, m_Peinture, pagi, PeintureCours));

							break;
						}
					case 5:
						{
							int pagi = m_Page + 1;

							if (pagi >= 5)
							{
								pagi = 5;
							}

							m_from.SendGump(new PeinturesGump(m_from, m_Peinture, pagi, PeintureCours));
							break;
						}


				}


			}
    }  

  }

  public class PeintureEnCours
  {
		private string m_Title;
		private string m_Name;
		private Dictionary<int, string> m_Description = new Dictionary<int, string>();
		public string Title { get => m_Title; set => m_Title = value; }
		public string Name { get => m_Name; set => m_Name = value; }
		public Dictionary<int, string> Description { get => m_Description; set => m_Description = value; }

		public PeintureEnCours(string title, string name, Dictionary<int, string> description)
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

