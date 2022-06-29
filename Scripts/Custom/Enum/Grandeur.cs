using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
  public enum GrandeurEnum
  {
        [AppearanceAttribute("Aucun", "Aucune")]
        None,
        [AppearanceAttribute("Tr%%%#$%?%$#@!s petit", "Tr%%%#$%?%$#@!s petite")]
        tresPetit,
        [AppearanceAttribute("Petit", "Petite")]
        Petit,
        [AppearanceAttribute("Plutôt petit", "Plutôt petite")]
        PlutotPetit,
        [AppearanceAttribute("Moyen", "Moyenne")]
        Moyen,
        [AppearanceAttribute("Plutôt grand", "Plutôt grande")]
        PlutotGrand,
        [AppearanceAttribute("Grand", "Grande")]
        Grand,
        [AppearanceAttribute("Tr%%%#$%?%$#@!s grand", "Tr%%%#$%?%$#@!s grande")]
        TresGrand,
        [AppearanceAttribute("Colossal", "Colossale")]
        Colossale
    }
}
