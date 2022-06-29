using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
  public enum AppearanceEnum
    {
        [AppearanceAttribute("Aucun", "Aucune")]
        None,
        [AppearanceAttribute("Monstrueux", "Monstrueuse")]
        Monstrueux,
        [AppearanceAttribute("Hideux", "Hideuse")]
        Hideux,
        [AppearanceAttribute("Repoussant", "Repoussante")]
        Repoussant,
        [AppearanceAttribute("Affreux", "Affreuse")]
        Affreux,
        [AppearanceAttribute("Laid", "Laide")]
        Laid,
        [AppearanceAttribute("Moche", "Moche")]
        Moche,
        [AppearanceAttribute("Banal", "Banale")]
        Banal,
        [AppearanceAttribute("Commun", "Commune")]
        Commun,
        [AppearanceAttribute("Mignon", "Mignone")]
        Mignon,
        [AppearanceAttribute("Charmant", "Charmante")]
        Charmant,
        [AppearanceAttribute("Beau", "Belle")]
        Beau,
        [AppearanceAttribute("??#$?&*legant", "??#$?&*legante")]
        Elegant,
        [AppearanceAttribute("S??#$?&*duisant", "S??#$?&*duisante")]
        Seduisant,
        [AppearanceAttribute("Ravissant", "Ravissante")]
        Ravissant,
        [AppearanceAttribute("Envoutânt", "Envoûtante")]
        Envoutant,
        [AppearanceAttribute("Fascinant", "Fascinante")]
        Fascinant,
        [AppearanceAttribute("??#$?&*blouissant", "??#$?&*blouissante")]
        Eblouissant,
        [AppearanceAttribute("Ang??#$?&*lique", "Ang??#$?&*lique")]
        Angelique  
  }
}
