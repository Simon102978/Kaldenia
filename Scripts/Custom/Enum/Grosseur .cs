using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
  public enum GrosseurEnum
  {
        [AppearanceAttribute("Aucun", "Aucune")]
        None,
        [AppearanceAttribute("Fluet", "Fluette")]
        Fluet,
        [AppearanceAttribute("Maigre", "Maigre")]
        Maigre,
        [AppearanceAttribute("Mince", "Mince")]
        Mince,
        [AppearanceAttribute("Élancé", "Élancée")]
        Elance,
        [AppearanceAttribute("Svelte", "Svelte")]
        Svelte,
        [AppearanceAttribute("Bedonnant", "Bedonnante")]
        Bedonnant,
        [AppearanceAttribute("Bien en chair", "Bien en chair")]
        BienEnChair,
        [AppearanceAttribute("Corpulent", "Corpulente")]
        Corpulent
    }
}
