using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
  public enum StatutSocialEnum
  {
        [AppearanceAttribute("Aucun", "Aucune")]
        Aucun,
        [AppearanceAttribute("Dechet", "Dechet")]
        Dechet,
        [AppearanceAttribute("Possession", "Possession")]
		Possession,
        [AppearanceAttribute("Peregrin", "Peregrine")]
		Peregrin,
        [AppearanceAttribute("Civenien", "Civeniene")]
		Civenien,
        [AppearanceAttribute("Equite", "Equite")]
		Equite,
        [AppearanceAttribute("Patre", "Matre")]
		Patre,
        [AppearanceAttribute("Magistrat", "Magistrate")]
		Magistrat,
        [AppearanceAttribute("Empereur", "Imperatrice")]
		Empereur
	}
}
