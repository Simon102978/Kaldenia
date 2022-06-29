using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using System.Collections.Generic;
using Server.Commands;
using Server.Custom;

namespace Server.Scripts.Commands
{
    public class Titre
    {
        public static void Initialize()
        {
            CommandSystem.Register("Titre", AccessLevel.Player, new CommandEventHandler(Titre_OnCommand));
        }

        [Usage("Titre")]
        [Description("Permet de changer son titre.")]
        public static void Titre_OnCommand(CommandEventArgs e)
        {
            CustomPlayerMobile pm = e.Mobile as CustomPlayerMobile;

            if (pm != null)
            {
                string primaire = pm.ClassePrimaire.Name;
				string secondaire = pm.ClasseSecondaire.Name;
				string metier = pm.Metier.Name;
				string customTitle = pm.customTitle;
				string DegTitle = pm.GetDeguisement().Title;

                pm.TitleCycle += 1;

				if (pm.TitleCycle == 4 && !pm.Deguise)
				{
					pm.TitleCycle += 1;
				}

				if (pm.TitleCycle > 7)
                    pm.TitleCycle = 0;

	


                switch (pm.TitleCycle)
                {
                    case 0:
                        {
                            pm.Title = primaire;
                            pm.SendMessage("Vous affichez désormais le titre de classe: {0}", primaire );
                            break;
                        }
                    case 1:
                        {
                            pm.Title = secondaire;
                            pm.SendMessage("Vous affichez désormais le titre de classe: {0}", secondaire);
                            break;
                        }
                    case 2:
                        {
                            pm.Title = metier;
                            pm.SendMessage("Vous affichez désormais le titre de métier: {0}", metier);
                            break;
						}
					case 3:
					{
							pm.Title = pm.StatutSocialString();
							pm.SendMessage("Vous affichez désormais le titre de statut social : {0}", pm.StatutSocialString());
							break;
					}
					case 4:
                        {
                            pm.Title = customTitle;
                            pm.SendMessage("Vous affichez désormais le titre personnalisé: {0}", customTitle);
                            break;
                        }
                    case 5:
                        {
                            pm.Title = DegTitle;
                            pm.SendMessage("Vous affichez désormais le titre de votre déguisement: {0}", DegTitle);
                            break;
                        }
					
					case 6:
						{
							pm.Title = "";
							pm.SendMessage("Vous affichez désormais aucun titre.");
							break;
						}

						/*       case 5:
								   {
									   string titreGuilde = "";

									   Dictionary<Mobile, int> MemberSalaryDict = new Dictionary<Mobile, int>();

									   if (GuildRecruter.NewGuildsList != null && GuildRecruter.NewGuildsList.Count > 0)
									   {
										   foreach (GuildRecruter guild in GuildRecruter.NewGuildsList)
										   {
											   if (guild == null)
												   continue;

											   if (!guild.GetMemberList().Contains(pm))
												   continue;

											   titreGuilde = guild.GetTitleByRank(guild.GetMobileRank(pm));
										   }
									   }

									   pm.Title = titreGuilde;
									   pm.SendMessage("Vous affichez désormais le titre de guilde: {0}", titreGuilde);
									   break;
								   }*/
				}
            }
        }
    }
}