using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;
using Server.Multis;
using Server.Targeting;

namespace Server.Engines.Apiculture
{	
	public class apiBeeHiveHelpGump : Gump
	{
		public apiBeeHiveHelpGump( Mobile from, int type ) : base( 20, 20 )
		{
			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;

			AddPage(0);
			AddBackground(37, 25, 386, 353, 3600);
			AddLabel(177, 42, 92, @"Aide sur l'apiculture");

			AddItem(32, 277, 3311);
			AddItem(30, 193, 3311);
			AddItem(29, 107, 3311);
			AddItem(28, 24, 3311);
			AddItem(386, 277, 3307);
			AddItem(387, 191, 3307);
			AddItem(388, 108, 3307);
			AddItem(385, 26, 3307);

			AddHtml( 59, 67, 342, 257, HelpText(type), true, true);
			AddButton(202, 333, 247, 248, 0, GumpButtonType.Reply, 0);
		}

		public string HelpText(int type)
		{
			string text = "";

			switch( type )
			{
				case 0:
				{
			
                text += "<p>L'<b>Apiculture</b> L'<b>apiculture</b> est la science (certains diront l'art) d'??#$?&*lever des abeilles. Les abeilles vivent ensemble dans des groupes nomm??#$?&*s <b>colonies</b> et ont ??#$?&*riger leurs maisons à l'int??#$?&*rieur de <b>ruches</b>.Garder une ruche n'est pas aussi simple que ça peut laisser paraître, quoique ça peut être une exp??#$?&*rience des plus gratifiantes. Pour d??#$?&*buter dans le chemin de l'<b>apiculture</b>, il faut posseder un <b>contrat de ruche</b> ainsi qu'un endroit avec des <b>fleurs</b> et de l'<b>eau</b> en abondance.</p>";
                text += "<p>Il y a trois phases distinctes dans le d??#$?&*veloppement d'une ruche:</p>";
                text += "<p><b>Colonisation</b> - la ruche envoit des ??#$?&*claireurs pour surveiller l'endroit, trouver des fleurs et trouver de l'eau.</p>";
                text += "<p><b>Couv??#$?&*e</b> - les oeufs pondues d??#$?&*butent en pleine force comme la ruche se pr??#$?&*pare à commençer la production d'envergure.</p>";
                text += "<p><b>Production</b> - après que la ruche a atteint la maturit??#$?&*, elle d??#$?&*bute à produire en grande quantit??#$?&* du miel et de la cire.</p>";
                text += "<p>La vie d'une ruche est mesur??#$?&*e en deux ??#$?&*tats: <b>la vie de l'ensemble</b> et le <b>nombre d'abeilles</b>.</p>";
                text += "<p><b>Vie globale</b> - indique l'??#$?&*tat des abeilles en g??#$?&*n??#$?&*ral:</p>";
                text += "<p><b>Prospèration</b> - les abeilles sont en excellente sant??#$?&*. Une colonie prospère produira le miel et la cire en plus grosse quantit??#$?&*rate.</p>";
                text += "<p><b>Sain</b> - les abeilles sont en sant??#$?&* et produices le miel et la cire.</p>";
                text += "<p><b>Malade</b> - les abeilles sont maladives, elles ne produises plus de miel et de cire.</p>";
                text += "<p><b>Mourrante</b> - si quelque chose ne se fait pas rapidement, la population de la ruche va commençer à diminuer.</p>";
                text += "<p><b>Population</b> - nombre aproximatif de la population d'abeilles.  Avoir plus d'abeilles ne signifie pas toujours être le mieux car une ruche plus grosse sera plus difficile à maintenire. Elle n??#$?&*cessitera davantage d'eau et de fleurs à proximit??#$?&* (plus que la ruche est grosse, plus que les abeilles peuvent aller chercher les ressources plus loin. Si les conditions sont mauvaises, une colonie d'abeilles va <b>partir</b>, laissant une ruche vide derrière eux.</p>";
                text += "<p>Comme n'importe quelle chose vivante, les abeilles peuvent être attaqu??#$?&*es par des forçes ext??#$?&*rieures. De parasites à maladie, l'apiculturiste possède une multitude d'outils à sa disposition pour contrer cela.</p>";
                text += "<p><b>Antidote Majeure</b> - des potions peuvent être utilis??#$?&*es pour combattre les maladies telles que la disenterie. Ces potions peuvent ??#$?&*galement neutraliser le poison.</p>";
                text += "<p><b>Poison Majeur</b> - ces potions peuvent être utilis??#$?&*es pour combattre les insectes (comme les mites) et les parasites qui infeste une ruche. Mais faites attention, du poison en trop grande quantit??#$?&* risquerait d'affecter les abeilles.</p>";
                text += "<p><b>Potion de Force Majeure</b> - ces potions sont utilis??#$?&*es pour d??#$?&*velopper l'immunit??#$?&* d'une ruche aux infestations et diverses maladies</p>";
                text += "<p><b>Potion de Sant??#$?&* Majeure</b> - elles sont utilis??#$?&*es pour gu??#$?&*rrir les abeilles</p>";
                text += "<p><b>Potion d'Agilit??#$?&* Majeure</b> - ces potions peuvent donner de l'??#$?&*nergie aux abeilles pour qu'elles travaillent encore plus dûr. Cela va donc augmenter la quantit??#$?&* de miel et de cire ainsi qu'augmenter la distance que les abeilles peuvent chercher les fleurs et l'eau.</p>";
                text += "<p>On administre une ruche en choisissant le <b>gump d'apiculture.</b>. Quasiment chaques aspects de la ruche peuvent être suivis ici. Les icônes de status sont au bas du côt??#$?&* gauche du gump.:</p>";
                text += "<p><b>Production</b> - ce bouton t'emmene au <b>gump de production</b>, où le gardien de la ruche peut r??#$?&*colter les ressources qu'ont produit les abeilles.</p>";
                text += "<p><b>Infestation</b> - un trait d'union jaune ou rouge signifie que la ruche est infest??#$?&*e par des parasites ou d'autres insectes. Utilise du <b>poison</b> pour tuer la menaçe.</p>";
                text += "<p><b>Maladie</b> - un trait d'union jaune ou rouge signifie que la ruche est pr??#$?&*sentement maladive. Utilise un <b>antidote</b> pour combattre la maladie.</p>";
                text += "<p><b>Eau</b> - cette icône d??#$?&*montre la disponibilit??#$?&* d'eau dans le domaine des abeilles. Faites attention, l'eau pourrait transporter des bact??#$?&*ries. Une ruche avec trop d'eau est une ruche plus susceptible aux maladies.</p>";
                text += "<p><b>Fleurs</b> - cette icône indique la somme de fleurs disponibles à la ruche. Les abeilles utilisent les fleurs et leurs sous-produits pour presque chaqu'une des fonctions de la ruche, la construction et la nourriture ??#$?&*tant inclu. Poss??#$?&*der trop de fleurs peut mettre en contact les abeilles avec les parasites ou les insectes.</p>";
                text += "<p><b>Notes:</b> une ruche à elle seule peut contenir jusqu'à 100 mille abeilles. Une ruche en sant??#$?&* peut vivre ind??#$?&*finiment, mais une vieille ruche est plus susceptible aux infestations et aux maladies.";
                text += "<p>La<b>v??#$?&*rification de la croissance</b> d'une ruche est perform??#$?&*e une fois par jour durant une sauvegarde du shard. Le coin sup??#$?&*rieur droit du <b>gump d'apiculture</b> d??#$?&*montre le r??#$?&*sultat de la dernière v??#$?&*rificaton.:</p>";
                text += "<p><b><basefont color=#FF0000>! </basefont></b>Mauvaise sant??#$?&*</p>";
                text += "<p><b><basefont color=#FFFF00>! </basefont></b>Ressources basses</p>";
                text += "<p><b><basefont color=#FF0000>- </basefont></b>Population en baisse</p>";
                text += "<p><b><basefont color=#00FF00>+ </basefont></b>Population en accroissement</p>";
                text += "<p><b><basefont color=#0000FF>+ </basefont></b>Augmentation de phase/Production des ressources</p>";
                break;
                }
                case 1:
                {
                text +="<p>La cire d'abeille dans son ??#$?&*tat brut est remplit d'impuret??#$?&*s ce qui la rend difficile à travailler avec. La proc??#$?&*dure de purification du cire est appel??#$?&*e <b>m??#$?&*lange</b>.</p>";
                text +="<p>Une fois que la ruche a atteint la maturit??#$?&* et peut produire de la cire, l'apiculturiste peut gratter la cire de la ruche à l'aide d'un <b>outil pour ruche</b>.</p>";
                text +="<p>Cette cire à l'??#$?&*tat brut peut être placer à l'int??#$?&*rieur d'un <b>petit pot de cire</b>. Une fois appliqu??#$?&* dans une sourçe de chaleur, la cire fond pour permettre à l'apiculturiste de retirer les impuret??#$?&*s, aussi connu en tant que <b>slumgum</b>.</p>";
                text +="<p>Une fois les impuret??#$?&*s de retirer, la cire peut être form??#$?&*e en cire pure. Cette nouvelle cire est appropri??#$?&*e à beaucoup d'applications.</p>";
					break;
				}
			}

			return text;
		}
	}
}
