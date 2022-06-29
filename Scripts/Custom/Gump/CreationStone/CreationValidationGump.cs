using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Engines.Craft;
using Server.Accounting;

namespace Server.Gumps
{
  public class CreationValidationGump : CreationBaseGump
    {

        public CreationValidationGump(CustomPlayerMobile from, CreationPerso creationPerso)
            : base(from, creationPerso, "Validation", true, false)
        {

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            int space = 115;


            string info = "<h3><basefont color=#FFFFFFF>Nom: " + m_Creation.Name + "\n\nRace: " + m_Creation.Race + "\nDivinit??#$?&*: " + m_Creation.God.Name + "\nSexe: " + (m_Creation.Female ? "Femme" : "Homme") + "\nApparence: " + m_Creation.GetApparence() + "\nGrandeur: " + m_Creation.GetGrandeur() + "\nGrosseur: " + m_Creation.GetGrosseur() + "\n\n<basefont></h3>";

			Dictionary<SkillName, int> Skill = new Dictionary<SkillName, int>();

			Classe primaire = Classe.GetClasse(m_Creation.ClassePrimaire);

			int armor = primaire.Armor;

			foreach (SkillName item in primaire.Skill)
			{
				Skill.Add(item, 50);
			}

			Classe metier = Classe.GetClasse(m_Creation.Metier);

			armor += metier.Armor;

			foreach (SkillName item in metier.Skill)
			{
				if (!Skill.ContainsKey(item))
				{
					Skill.Add(item, 50);
				}			
			}

			Classe secondaire = Classe.GetClasse(m_Creation.ClasseSecondaire);

			armor += secondaire.Armor;

			foreach (SkillName item in secondaire.Skill)
			{
				if (!Skill.ContainsKey(item))
				{
					Skill.Add(item, 30);
				}			
			}





			info = info + "Skills: \n\n";

			foreach (KeyValuePair<SkillName,int> item in Skill)
			{
				info = info +"  -" + item.Key + ": " + item.Value + "\n";
			}

			info = info + "  -Mining: 30\n  -Fishing: 30\n  -Lumberjacking: 30\n  -MagicResist: 30\n";



			info = info + "\nArmure: " + armor;

			info = info + "\n\nForce: " + creationPerso.Str;
			info = info + "\nDext??#$?&*rit??#$?&*: " + creationPerso.Dex;
			info = info + "\nIntelligence: " + creationPerso.Int;

			   if (m_Creation.Reroll != null)
			  {
				  info = info + "\n\nTransfert: " + m_Creation.Reroll.Name + "\nExp??#$?&*riences: " + Math.Round(creationPerso.Reroll.Experience * 0.75);
			  }

			AddSection(x - 10, y, 303, 508, "Information", info);

			string context = "Vous allez maintenant être envoy??#$?&* dans la cit??#$?&* de Boscula, pour une escale avant votre destination finale.\n\nDurant cette escale, profitez bien des marchands pr??#$?&*sents dans la cit??#$?&* pour regarnir votre garde-robe. \n\nMais prenez garde, le bateau est rempli, vous ne pourrez que transporter ce que vous portez.";

			AddSection(x + 294, y, 304, 508, "Contexte", context);
			AddSection(x - 10, y + 509, 610, 99, "Validation");
			AddButton(x + 265, y + 550, 1, 1147, 1148);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID == 1)
            {
                m_Creation.Valide();
            }
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
				        Account acc = (Account)from.Account;

						 if (acc.Reroll.Count > 0)
						 {
							 from.SendGump(new CreationRerollGump(from, m_Creation));

						 }
						 else
						 {

						    m_from.SendGump(new CreationGodGump(m_from, m_Creation));
				         }              
			}
        }

     

    }
}
