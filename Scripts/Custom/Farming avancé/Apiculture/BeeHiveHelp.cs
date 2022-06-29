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
			
                text += "<p>L'<b>Apiculture</b> L'<b>apiculture</b> est la science (certains diront l'art) d'élever des abeilles. Les abeilles vivent ensemble dans des groupes nommés <b>colonies</b> et ont ériger leurs maisons %%%#$%?%$#@! l'intérieur de <b>ruches</b>.Garder une ruche n'est pas aussi simple que ça peut laisser paraître, quoique ça peut être une expérience des plus gratifiantes. Pour débuter dans le chemin de l'<b>apiculture</b>, il faut posseder un <b>contrat de ruche</b> ainsi qu'un endroit avec des <b>fleurs</b> et de l'<b>eau</b> en abondance.</p>";
                text += "<p>Il y a trois phases distinctes dans le développement d'une ruche:</p>";
                text += "<p><b>Colonisation</b> - la ruche envoit des éclaireurs pour surveiller l'endroit, trouver des fleurs et trouver de l'eau.</p>";
                text += "<p><b>Couvée</b> - les oeufs pondues débutent en pleine force comme la ruche se prépare %%%#$%?%$#@! commençer la production d'envergure.</p>";
                text += "<p><b>Production</b> - après que la ruche a atteint la maturité, elle débute %%%#$%?%$#@! produire en grande quantité du miel et de la cire.</p>";
                text += "<p>La vie d'une ruche est mesurée en deux états: <b>la vie de l'ensemble</b> et le <b>nombre d'abeilles</b>.</p>";
                text += "<p><b>Vie globale</b> - indique l'état des abeilles en général:</p>";
                text += "<p><b>Prospèration</b> - les abeilles sont en excellente santé. Une colonie prospère produira le miel et la cire en plus grosse quantitérate.</p>";
                text += "<p><b>Sain</b> - les abeilles sont en santé et produices le miel et la cire.</p>";
                text += "<p><b>Malade</b> - les abeilles sont maladives, elles ne produises plus de miel et de cire.</p>";
                text += "<p><b>Mourrante</b> - si quelque chose ne se fait pas rapidement, la population de la ruche va commençer %%%#$%?%$#@! diminuer.</p>";
                text += "<p><b>Population</b> - nombre aproximatif de la population d'abeilles.  Avoir plus d'abeilles ne signifie pas toujours être le mieux car une ruche plus grosse sera plus difficile %%%#$%?%$#@! maintenire. Elle nécessitera davantage d'eau et de fleurs %%%#$%?%$#@! proximité (plus que la ruche est grosse, plus que les abeilles peuvent aller chercher les ressources plus loin. Si les conditions sont mauvaises, une colonie d'abeilles va <b>partir</b>, laissant une ruche vide derrière eux.</p>";
                text += "<p>Comme n'importe quelle chose vivante, les abeilles peuvent être attaquées par des forçes extérieures. De parasites %%%#$%?%$#@! maladie, l'apiculturiste possède une multitude d'outils %%%#$%?%$#@! sa disposition pour contrer cela.</p>";
                text += "<p><b>Antidote Majeure</b> - des potions peuvent être utilisées pour combattre les maladies telles que la disenterie. Ces potions peuvent également neutraliser le poison.</p>";
                text += "<p><b>Poison Majeur</b> - ces potions peuvent être utilisées pour combattre les insectes (comme les mites) et les parasites qui infeste une ruche. Mais faites attention, du poison en trop grande quantité risquerait d'affecter les abeilles.</p>";
                text += "<p><b>Potion de Force Majeure</b> - ces potions sont utilisées pour développer l'immunité d'une ruche aux infestations et diverses maladies</p>";
                text += "<p><b>Potion de Santé Majeure</b> - elles sont utilisées pour guérrir les abeilles</p>";
                text += "<p><b>Potion d'Agilité Majeure</b> - ces potions peuvent donner de l'énergie aux abeilles pour qu'elles travaillent encore plus dûr. Cela va donc augmenter la quantité de miel et de cire ainsi qu'augmenter la distance que les abeilles peuvent chercher les fleurs et l'eau.</p>";
                text += "<p>On administre une ruche en choisissant le <b>gump d'apiculture.</b>. Quasiment chaques aspects de la ruche peuvent être suivis ici. Les icônes de status sont au bas du côté gauche du gump.:</p>";
                text += "<p><b>Production</b> - ce bouton t'emmene au <b>gump de production</b>, où le gardien de la ruche peut récolter les ressources qu'ont produit les abeilles.</p>";
                text += "<p><b>Infestation</b> - un trait d'union jaune ou rouge signifie que la ruche est infestée par des parasites ou d'autres insectes. Utilise du <b>poison</b> pour tuer la menaçe.</p>";
                text += "<p><b>Maladie</b> - un trait d'union jaune ou rouge signifie que la ruche est présentement maladive. Utilise un <b>antidote</b> pour combattre la maladie.</p>";
                text += "<p><b>Eau</b> - cette icône démontre la disponibilité d'eau dans le domaine des abeilles. Faites attention, l'eau pourrait transporter des bactéries. Une ruche avec trop d'eau est une ruche plus susceptible aux maladies.</p>";
                text += "<p><b>Fleurs</b> - cette icône indique la somme de fleurs disponibles %%%#$%?%$#@! la ruche. Les abeilles utilisent les fleurs et leurs sous-produits pour presque chaqu'une des fonctions de la ruche, la construction et la nourriture étant inclu. Posséder trop de fleurs peut mettre en contact les abeilles avec les parasites ou les insectes.</p>";
                text += "<p><b>Notes:</b> une ruche %%%#$%?%$#@! elle seule peut contenir jusqu'%%%#$%?%$#@! 100 mille abeilles. Une ruche en santé peut vivre indéfiniment, mais une vieille ruche est plus susceptible aux infestations et aux maladies.";
                text += "<p>La<b>vérification de la croissance</b> d'une ruche est performée une fois par jour durant une sauvegarde du shard. Le coin supérieur droit du <b>gump d'apiculture</b> démontre le résultat de la dernière vérificaton.:</p>";
                text += "<p><b><basefont color=#FF0000>! </basefont></b>Mauvaise santé</p>";
                text += "<p><b><basefont color=#FFFF00>! </basefont></b>Ressources basses</p>";
                text += "<p><b><basefont color=#FF0000>- </basefont></b>Population en baisse</p>";
                text += "<p><b><basefont color=#00FF00>+ </basefont></b>Population en accroissement</p>";
                text += "<p><b><basefont color=#0000FF>+ </basefont></b>Augmentation de phase/Production des ressources</p>";
                break;
                }
                case 1:
                {
                text +="<p>La cire d'abeille dans son état brut est remplit d'impuretés ce qui la rend difficile %%%#$%?%$#@! travailler avec. La procédure de purification du cire est appelée <b>mélange</b>.</p>";
                text +="<p>Une fois que la ruche a atteint la maturité et peut produire de la cire, l'apiculturiste peut gratter la cire de la ruche %%%#$%?%$#@! l'aide d'un <b>outil pour ruche</b>.</p>";
                text +="<p>Cette cire %%%#$%?%$#@! l'état brut peut être placer %%%#$%?%$#@! l'intérieur d'un <b>petit pot de cire</b>. Une fois appliqué dans une sourçe de chaleur, la cire fond pour permettre %%%#$%?%$#@! l'apiculturiste de retirer les impuretés, aussi connu en tant que <b>slumgum</b>.</p>";
                text +="<p>Une fois les impuretés de retirer, la cire peut être formée en cire pure. Cette nouvelle cire est appropriée %%%#$%?%$#@! beaucoup d'applications.</p>";
					break;
				}
			}

			return text;
		}
	}
}
