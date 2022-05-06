﻿using Server.Gumps;
using Server.Network;
using Server.Prompts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Server.Systemes.Geopolitique
{
    public class EmployeGump : Gump
    {
        private Employe employe;
        private Tresorier tresorier;
        private bool gestion;

        public EmployeGump(Tresorier t, Employe e, bool gestion)
            : base(0, 0)
        {
            employe = e;
            tresorier = t;
            this.gestion = gestion;

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);
            AddBackground(31, 48, 416, 298, 9250);
            AddBackground(39, 56, 400, 282, 3500);
            AddLabel(176, 75, 1301, @"Fiche d'Employé");

            AddLabel(81, 110, 1301, @"Nom :");
            AddLabel(210, 110, 1301, e.Nom);
            if(gestion)
                AddButton(383, 109, 4005, 4006, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);

            AddLabel(81, 140, 1301, @"Titre :");
            AddLabel(210, 140, 1301, e.Titre);
            if(gestion)
                AddButton(383, 139, 4005, 4006, (int)Buttons.ChangerTitre, GumpButtonType.Reply, 0);

            AddLabel(81, 170, 1301, @"Paie mensuelle :");
            AddLabel(210, 170, 1301, e.Paie.ToString("N", Geopolitique.NFI));
            if(gestion)
                AddButton(383, 169, 4005, 4006, (int)Buttons.ModifierPaie, GumpButtonType.Reply, 0);

            AddLabel(82, 200, 1301, @"Dû non réclamé :");
            AddLabel(210, 200, 1301, e.Total.ToString("N", Geopolitique.NFI));
            if (gestion)
            {
                AddButton(343, 199, 4014, 4015, (int)Buttons.ReduireDu, GumpButtonType.Reply, 0);
                AddButton(383, 199, 4005, 4006, (int)Buttons.AjouterDu, GumpButtonType.Reply, 0);
            }
            else
                AddButton(383, 199, 4029, 4030, (int)Buttons.ReclamerDu, GumpButtonType.Reply, 0);

            AddLabel(82, 230, 1301, @"Dû non payé :");
            AddLabel(210, 230, 1301, e.NonPaye.ToString("N", Geopolitique.NFI));
            if(gestion)
                AddButton(383, 229, 4029, 4030, (int)Buttons.PayerDu, GumpButtonType.Reply, 0);

            AddLabel(82, 260, 1301, @"Dernière paie :");
            AddLabel(210, 260, 1301, e.LastPaie.ToString(CultureInfo.CreateSpecificCulture("fr-FR")));


            if (gestion)
            {
                AddLabel(116, 290, 1301, @"Supprimer l'employé de la liste");
                AddButton(314, 289, 4005, 4006, (int)Buttons.SupprimerEmploye, GumpButtonType.Reply, 0);
            }
        }

        public enum Buttons
        {
            SupprimerEmploye = 1,
            ChangerNom,
            ChangerTitre,
            ModifierPaie,
            AjouterDu,
            ReduireDu,
            PayerDu,
            ReclamerDu,
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (gestion)
            {
                switch (info.ButtonID)
                {
                    case 0:
                        from.SendGump(new TresorierGump(tresorier, from, 0));
                        break;

                    case (int)Buttons.SupprimerEmploye:
                        tresorier.ReponseAuGump(from, "Que désirez-vous faire avec sa fiche d'employé?");
                        from.SendGump(new SuppressionGump(tresorier, employe));
                        break;

                    case (int)Buttons.ChangerNom:
                        tresorier.ReponseAuGump(from, "Veuillez indiquer le nouveau nom à utiliser pour l'employé.");
                        from.Prompt = new ChangerNomPrompt(tresorier, employe);
                        break;

                    case (int)Buttons.ChangerTitre:
                        tresorier.ReponseAuGump(from, "Quel titre voulez-vous donner à " + employe.Nom + ".");
                        from.Prompt = new ChangerTitrePrompt(tresorier, employe);
                        break;

                    case (int)Buttons.ModifierPaie:
                        tresorier.ReponseAuGump(from, "Veuillez indiquer le montant de la nouvelle paie");
                        from.Prompt = new ModifierPaiePrompt(tresorier, employe);
                        break;

                    case (int)Buttons.AjouterDu:
                        tresorier.ReponseAuGump(from, "Quel montant désirez-vous rajouter à son dû?");
                        from.Prompt = new ModifierFondsPrompt(tresorier, employe, true);
                        break;
                    case (int)Buttons.ReduireDu:
                        tresorier.ReponseAuGump(from, "Quel montant désirez-vous reprendre de son dû?");
                        from.Prompt = new ModifierFondsPrompt(tresorier, employe, false);
                        break;

                    case (int)Buttons.PayerDu:
                        tresorier.PayerDu(employe);
                        from.SendGump(new EmployeGump(tresorier, employe, true));
                        break;
                }
            }
            else if (info.ButtonID == (int)Buttons.ReclamerDu)
            {
                tresorier.ReponseAuGump(from, "Combien désirez-vous réclamer?");
                from.Prompt = new ReclamerDuPrompt(tresorier, employe);
            }
        }

        private class ChangerNomPrompt : Prompt
        {

            private Employe employe;
            private Tresorier tresorier;

            public ChangerNomPrompt(Tresorier t, Employe e)
            {
                employe = e;
                tresorier = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                employe.Nom = text;
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }
        }

        private class ChangerTitrePrompt : Prompt
        {

            private Employe employe;
            private Tresorier tresorier;

            public ChangerTitrePrompt(Tresorier t, Employe e)
            {
                employe = e;
                tresorier = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                employe.Titre = text;
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }
        }

        private class ModifierFondsPrompt : Prompt
        {
            private Tresorier t;
            private Employe e;
            private bool ajout;

            public ModifierFondsPrompt(Tresorier t, Employe e, bool ajout)
            {
                this.t = t;
                this.e = e;
                this.ajout = ajout;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int amount;
                if (Int32.TryParse(text, out amount))
                {
                    if (ajout)
                    {
                        bool s = t.TransfererFonds(e, amount);
                        if (s)
                            t.ReponseAuGump(from, "Montant transféré.");
                        else
                            t.ReponseAuGump(from, "Nos coffres sont trop vides pour que nous puissions lui " +
                                "donner ce montant.");
                    }
                    else
                    {
                        bool s = t.ReprendreMontant(e, amount);
                        if (s)
                            t.ReponseAuGump(from, "Montant repris.");
                        else
                            t.ReponseAuGump(from, "Le total de ses paies non réclamées n'est pas suffisant " +
                                "pour que vous puissiez reprendre un tel montant.");
                    }
                    from.SendGump(new TresorierGump(t, from, 0));
                }
                else
                {
                    t.ReponseAuGump(from, String.Format("Je n'ai pas compris le montant que vous désirez {0}.",
                                                        ajout ? "ajouter" : "retirer"));
                    from.Prompt = new ModifierFondsPrompt(t, e, ajout);
                }
            }
        }


        private class ModifierPaiePrompt : Prompt
        {

            private Employe employe;
            private Tresorier tresorier;

            public ModifierPaiePrompt(Tresorier t, Employe e)
            {
                employe = e;
                tresorier = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int montant;
                if (Int32.TryParse(text, out montant))
                {
                    tresorier.PayerEmploye(employe);
                    employe.Paie = montant;
                    from.SendGump(new EmployeGump(tresorier, employe, true));
                }
                else
                {
                    from.SendMessage("Vous devez indiquer un nombre");
                    from.Prompt = new ModifierPaiePrompt(tresorier, employe);
                }
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }
        }


        private class SuppressionGump : Gump
        {
            Employe employe;
            Tresorier tresorier;

            public SuppressionGump(Tresorier t, Employe e)
                : base(0, 0)
            {
                employe = e;
                tresorier = t;

                this.Closable = true;
                this.Disposable = true;
                this.Dragable = true;
                this.Resizable = false;

                AddPage(0);
                AddBackground(31, 48, 716, 228, 9250);
                AddBackground(39, 56, 700, 212, 3500);
                AddLabel(326, 75, 1301, @"Suppression d'Employé");

                AddLabel(60, 110, 1301, @"Que voulez vous faire avec la fiche d'employé de " + employe.Nom + "?");

                AddLabel(81, 140, 1301, @"Supprimer la fiche mais laisser l'employé récupérer son dû (sans lui verser un montant additionel).");
                AddButton(683, 139, 4005, 4006, 1, GumpButtonType.Reply, 0);
                
                AddLabel(81, 170, 1301, @"Payer l'employé et le laisser récupérer son dû et supprimer sa fiche.");
                AddButton(683, 169, 4005, 4006, 2, GumpButtonType.Reply, 0);

                AddLabel(82, 200, 1301, @"Reprendre son dû dans nos coffre et supprimer sa fiche");
                AddButton(683, 199, 4005, 4006, 3, GumpButtonType.Reply, 0);

                AddLabel(82, 230, 1301, @"Ne rien faire");
                AddButton(683, 229, 4029, 4030, 0, GumpButtonType.Reply, 0);

            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                Mobile from = sender.Mobile;
                if (info.ButtonID > 3)
                    return;

                switch (info.ButtonID)
                {
                    case 0:
                        from.SendGump(new EmployeGump(tresorier, employe, true));
                        return;
                    case 2:
                        tresorier.PayerEmploye(employe);
                        break;
                    case 3:
                        tresorier.ReprendreDu(employe, employe.Total);
                        break;
                }
                tresorier.RemoveEmploye(employe.Personnage);
                from.SendGump(new TresorierGump(tresorier, from, 0));
            }
        }

        private class ReclamerDuPrompt : Prompt
        {
            private Tresorier t;
            private Employe e;

            public ReclamerDuPrompt(Tresorier t, Employe e)
            {
                this.t = t;
                this.e = e;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int amount;
                if (Int32.TryParse(text, out amount))
                {
                    bool s = e.RemettreAlEmploye(amount);
                    if (s)
                        t.ReponseAuGump(from, "Montant Réclamé.");
                    else
                        t.ReponseAuGump(from, "Nous ne vous devons pas tant!");


                    from.SendGump(new EmployeGump(t, e, false));
                }
                else
                {
                    t.ReponseAuGump(from, "Je n'ai pas compris le montant que vous désirez réclamer.");
                    from.Prompt = new ReclamerDuPrompt(t, e);
                }
            }
        }
    }
}
