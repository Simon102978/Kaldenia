using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Spells;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Sort
    {
        public static void Initialize()
        {
            CommandSystem.Register("sort", AccessLevel.Player, new CommandEventHandler(Sort_OnCommand));
        }

        public static void Sort_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)from;

                if (pm.ChosenSpellbook != null && pm.ChosenSpellbook is NewSpellbook)
                {
                    NewSpellbook m_Book = (NewSpellbook)pm.ChosenSpellbook;
                    int id = e.GetInt32(0);

                    if (e.Length != 1)
                    {
                        e.Mobile.SendMessage("Utilisation : sort <ID>");
                    }
                    else if (id >= 750 && id <= 856)
                    {
                        if (!m_Book.HasSpell(id))
                        {
                            pm.SendMessage("Le grimoire que vous ciblez doit posséder le sort en question !");
                        }
                        else if (m_Book != null && (m_Book.Parent == from || (from.Backpack != null && m_Book.Parent == from.Backpack)))
                        {
                            Spell spell = SpellRegistry.NewSpell(id, from, null);

                            if (spell != null)
                                spell.Cast();
							else
							{
								SpecialMove sm = SpellRegistry.GetSpecialMove(id);

								if (sm != null)
								{
									sm.OnUse(from);
								}

							}
						}
                    }
                    else
                        pm.SendMessage("Le numéro du sort est invalide !");
                }
                else
                    pm.SendMessage("Vous devez choisir le grimoire à utiliser avec la commande .choisirgrimoire !");
            }
        }
    }
}