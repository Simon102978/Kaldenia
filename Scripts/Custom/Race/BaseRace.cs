#region References
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
#endregion

namespace Server
{
    [Parsable]
    public abstract class BaseRace : Race
    {
        public virtual string Background => "À venir.";

        public virtual AppearanceEnum AppearanceMin => AppearanceEnum.Monstrueux; // Pour NPC
        public virtual AppearanceEnum AppearanceMax => AppearanceEnum.Angelique; // Pour NPC

        public virtual GrandeurEnum GrandeurMin => GrandeurEnum.tresPetit;
        public virtual GrandeurEnum GrandeurMax => GrandeurEnum.Colossale;

        public virtual GrosseurEnum GrosseurMin => GrosseurEnum.Fluet;
        public virtual GrosseurEnum GrosseurMax => GrosseurEnum.Corpulent;

		public virtual int GumpId => 52081;


		public virtual List<string> NomMasculin => new List<string>() {
             "Aaron" , "Aasin" , "Abbott" , "Abdel" , "Abdiel" , "Abel" , "Abijah" , "Abner" , "Abraham" , "Abran" , "Ace" , "Achilles" , "Ackerley" , "Adair" , "Adam" , "Addison" , "Adeben" , "Adem" , "Adiran" , "Adlai" , "Adler" , "Adley" , "Admon" , "Adolph" , "Adon" , "Adonis" , "Adrian" , "Adriel" , "Aeneas" , "Agustin" , "Ahearn" , "Ahmik" , "Ahren" , "Aidan" , "Aiken" , "Aimery" , "Aitan" , "Ajayi" , "Akando" , "Akbaar" , "Akello" , "Akil" , "Akshay" , "Alan" , "Aland" , "Alano" , "Alaric" , "Alastair" , "Alben" , "Albert" , "Alcander" , "Alcott" , "Alden" , "Alder" , "Aldrick" , "Alec" , "Alek" , "Aleksy" , "Aleron" , "Aleser" , "Alex" , "Alexander" , "Alfred" , "Alger" , "Alim" , "Alistair" , "Allaard" , "Allan" , "Allard" , "Allen" , "Alonzo" , "Alphonse" , "Alphonso" , "Alston" , "Altair" , "Alton" , "Alvin" , "Amadeo" , "Amadi" , "Amado" , "Ambrose" , "Amiel" , "Ammon" , "Amos" , "Amsden" , "Anders" , "Andre" , "Andreus" , "Andrew" , "Andrey" , "Andries" , "Angelo" , "Angus" , "Anker" , "Anoki" , "Ansel" , "Anselme" , "Ansley" , "Anson" , "Anthony" , "Antonio" , "Anwar" , "Archer" , "Archibald" , "Ardon" , "Aren" , "Ares" , "Argus" , "Ari" , "Aricin" , "Arion" , "Aristo" , "Aristotle" , "Arkin" , "Arlen" , "Arley" , "Arlin" , "Arlo" , "Arman" , "Armen" , "Armon" , "Armstrong" , "Arne" , "Arnold" , "Arnon" , "Aron" , "Arpiar" , "Arsen" , "Arsenio" , "Arthur" , "Ashby" , "Asher" , "Ashford" , "Ashlin" , "Ashon" , "Ashur" , "Athan" , "Atheron" , "Atman" , "Audric" , "Audun" , "Augustin" , "Augustus" , "Aurek" , "Austin" , "Averill" , "Avery" , "Axel" , "Bae" , "Bailey" , "Baingana" , "Bakari" , "Balbo" , "Balder" , "Baldwin" , "Bale" , "Balendin" , "Bali" , "Balin" , "Balint" , "Bancroft" , "Bandele" , "Bane" , "Banning" , "Baran" , "Barclay" , "Barden" , "Bardo" , "Bardon" , "Barnabas" , "Barnaby" , "Barnett" , "Barney" , "Baron" , "Barrett" , "Barry" , "Barse" , "Bart" , "Barth" , "Bartholomew" , "Barton" , "Basil" , "Bastiaan" , "Baul" , "Bavol" , "Baxter" , "Bay" , "Bayani" , "Bayard" , "Baylor" , "Bazyli" , "Beacan" , "Beagan" , "Beaman" , "Beau" , "Beaumont" , "Beauregard" , "Beck" , "Beldon" , "Belen" , "Bem" , "Beman" , "Ben" , "Benedict" , "Benen" , "Benjamin" , "Bennett" , "Benson" , "Bent" , "Bentley" , "Benton" , "Berenger" , "Bergren" , "Berk" , "Berkeley" , "Bernard" , "Bersh" , "Bert" , "Berthold" , "Berton" , "Bertram" , "Beval" , "Bevan" , "Bialy" , "Bilal" , "Bishop" , "Bitalo" , "Bjorn" , "Blade" , "Blaine" , "Blair" , "Blaise" , "Blake" , "Blaz" , "Blorn" , "Bo" , "Boden" , "Bogart" , "Bohdan" , "Bolton" , "Bond" , "Booker" , "Boone" , "Borden" , "Boris" , "Botan" , "Bowie" , "Bowman" , "Boyce" , "Boyd" , "Boyden" , "Brad" , "Braden" , "Bradford" , "Bradney" , "Brady" , "Bram" , "Bran" , "Brand" , "Brandeis" , "Brandon" , "Brant" , "Braxton" , "Bray" , "Braz" , "Brazil" , "Bren" , "Brencis" , "Brendan" , "Brendon" , "Brennan" , "Brent" , "Brentan" , "Bret" , "Brett" , "Brewster" , "Briac" , "Brian" , "Briand" , "Brice" , "Brieg" , "Brinley" , "Brishen" , "Brock" , "Broderick" , "Brodny" , "Brody" , "Bronson" , "Bront" , "Bruce" , "Bruno" , "Brutus" , "Bryan" , "Bryant" , "Bryce" , "Bryson" , "Buck" , "Bud" , "Budo" , "Burgess" , "Burhan" , "Burian" , "Burke" , "Burl" , "Burr" , "Burton" , "Byran" , "Byron" , "Cadeo" , "Cador" , "Caedmon" , "Cailan" , "Cain" , "Caine" , "Calder" , "Caldwell" , "Caleb" , "Calvin" , "Cam" , "Camden" , "Cameron" , "Candan" , "Canton" , "Canute" , "Carden" , "Carey" , "Carl" , "Carlin" , "Carlo" , "Carlos" , "Carlton" , "Carr" , "Carrick" , "Carrocio" , "Carroll" , "Carson" , "Carson" , "Carter" , "Carver" , "Casey" , "Casper" , "Cassidy" , "Cassius" , "Castel" , "Cato" , "Caton" , "Cavan" , "Ceasar" , "Cecil" , "Cedric" , "Cemal" , "Chad" , "Chadwick" , "Chaim" , "Chal" , "Chale" , "Chalmers" , "Chander" , "Chandler" , "Chane" , "Chaney" , "Channing" , "Chapin" , "Chapman" , "Charles" , "Charlton" , "Chase" , "Chatha" , "Chauncy" , "Chayton" , "Chen" , "Cheney" , "Chester" , "Chet" , "Chevalier" , "Chike" , "Chin" , "Christian" , "Christoph" , "Christopher" , "Christos" , "Chuck" , "Ciceron" , "Ciro" , "Clarence" , "Clark" , "Claude" , "Clay" , "Clayton" , "Clement" , "Cleveland" , "Clifford" , "Clifton" , "Clint" , "Clinton" , "Clive" , "Clyde" , "Cody" , "Colby" , "Cole" , "Coleman" , "Colin" , "Collin" , "Colon" , "Colton" , "Coman" , "Condon" , "Connor" , "Conrad" , "Conway" , "Corbett" , "Corbin" , "Corcoran" , "Cordell" , "Corey" , "Cornelius" , "Cort" , "Coty" , "Courtland" , "Craig" , "Crandall" , "Creighton" , "Crispin" , "Crosby" , "Cullen" , "Cullin" , "Culver" , "Curran" , "Curtis" , "Cynric" , "Cyrano" , "Cyril" , "Cyrus" , "Dag" , "Dagan" , "Dakarai" , "Dakota" , "Dale" , "Dallin" , "Dalton" , "Daly" , "Damek" , "Damen" , "Damian" , "Damien" , "Damion" , "Damon" , "Dana" , "Dane" , "Daniel" , "Danior" , "Dannik" , "Dante" , "Daren" , "Darien" , "Dario" , "Darnell" , "Darrel" , "Darrell" , "Darren" , "Daryl" , "David" , "Davin" , "Davis" , "Deacon" , "Dean" , "Decker" , "Delaney" , "Delano" , "Delbert" , "Dellan" , "Delmore" , "Delsin" , "Deman" , "Dempsey" , "Dempster" , "Denby" , "Dennis" , "Dennys" , "Denton" , "Denver" , "Der" , "Derek" , "Derrick" , "Derry" , "Deverell" , "Devin" , "Devlin" , "Dewey" , "Diederik" , "Diego" , "Dieter" , "Dillon" , "Dimitri" , "Dirk" , "Dobry" , "Dominic" , "Dominick" , "Donald" , "Donatien" , "Donato" , "Donnelley" , "Donnelly" , "Donovan" , "Doron" , "Dougie" , "Douglas" , "Douglass" , "Dov" , "Doyle" , "Drake" , "Drew" , "Duane" , "Dugan" , "Duglas" , "Duncan" , "Dunstan" , "Durand" , "Durriken" , "Dusan" , "Dustin" , "Dutch" , "Dwayne" , "Dwight" , "Dyami" , "Dyastro" , "Dylan" , "Dymas" , "Eamon" , "Earl" , "Earle" , "Eaton" , "Edan" , "Edgan" , "Edgar" , "Edison" , "Edmund" , "Edrin" , "Edward" , "Edwin" , "Edwin" , "Egan" , "Einar" , "Elad" , "Elden" , "Eldroth" , "Elek" , "Eli" , "Elias" , "Elijah" , "Elkan" , "Ellery" , "Elliot" , "Elliott" , "Ellis" , "Ellsworth" , "Elmer" , "Elmo" , "Elston" , "Elton" , "Elwood" , "Emanuel" , "Emil" , "Emilio" , "Emmett" , "Emo" , "Enoch" , "Enrico" , "Enrique" , "Ephraim" , "Erek" , "Eric" , "Erik" , "Ernest" , "Erol" , "Errol" , "Erskine" , "Erwin" , "Eryx" , "Essien" , "Esteban" , "Ethan" , "Eugene" , "Evan" , "Evander" , "Everett" , "Evzen" , "Ezekial" , "Ezra" , "Fabio" , "Fairfax" , "Farley" , "Farrell" , "Faxon" , "Felix" , "Felix" , "Fenn" , "Fenton" , "Fergus" , "Ferran" , "Ferris" , "Fielding" , "Filbert" , "Filmore" , "Finlay" , "Finley" , "Finn" , "Finnigan" , "Fisk" , "Fitzgerald" , "Fletcher" , "Flindo" , "Flint" , "Floyd" , "Flynn" , "Forbes" , "Forrest" , "Forsythe" , "Foster" , "Foster" , "Francis" , "Franek" , "Frank" , "Franklin" , "Frasier" , "Frazer" , "Frazier" , "Fred" , "Frederick" , "Fremont" , "Fritz" , "Fuller" , "Fulton" , "Gabe" , "Gabriel" , "Gage" , "Galen" , "Galeno" , "Galvin" , "Gamble" , "Gannon" , "Gareth" , "Garfield" , "Gargan" , "Garner" , "Garrett" , "Garrick" , "Garridan" , "Garrison" , "Garritt" , "Garth" , "Garvin" , "Gary" , "Gaspar" , "Gaston" , "Gavin" , "Gavrie" , "Gaylord" , "Gaynor" , "Geoff" , "Geoffrey" , "Geoffry" , "George" , "Gerard" , "Gerik" , "Germain" , "Gerry" , "Gideon" , "Gilberto" , "Giles" , "Ginton" , "Givon" , "Glen" , "Glenn" , "Glenno" , "Godfrey" , "Gordon" , "Gordy" , "Gorman" , "Grady" , "Graham" , "Gram" , "Granger" , "Grant" , "Granville" , "Grayson" , "Greg" , "Greger" , "Gregor" , "Gregory" , "Gresham" , "Griffen" , "Griffith" , "Guilhem" , "Gunnar" , "Gunther" , "Gus" , "Gustave" , "Guthrie" , "Guy" , "Hackett" , "Hadden" , "Hadi" , "Hadley" , "Hadrian" , "Hagan" , "Hal" , "Halden" , "Hale" , "Halian" , "Halsey" , "Hamilton" , "Hamlin" , "Hank" , "Hans" , "Harden" , "Hardy" , "Harith" , "Harlan" , "Harman" , "Harold" , "Harper" , "Harrison" , "Harry" , "Hart" , "Hartley" , "Harvey" , "Hassan" , "Hastin" , "Hastings" , "Hayden" , "Hayes" , "Haynes" , "Heath" , "Hector" , "Helaku" , "Henning" , "Henry" , "Herbert" , "Herman" , "Herschel" , "Hilliard" , "Hilton" , "Hiroshi" , "Hobart" , "Hogan" , "Holden" , "Holt" , "Homes" , "Horace" , "Horton" , "Houston" , "Howard" , "Howrence" , "Hoyt" , "Hugh" , "Hugo" , "Humphrey" , "Hunter" , "Huntley" , "Hyman" , "Iain" , "Ian" , "Ilias" , "Ingmar" , "Ingram" , "Ira" , "Irvin" , "Irving" , "Irwin" , "Isaac" , "Isaiah" , "Israel" , "Itzak" , "Ivan" , "Ivar" , "Jabari" , "Jabir" , "Jack" , "Jacob" , "Jacobe" , "Jacques" , "Jacson" , "Jacy" , "Jafar" , "Jagger" , "Jake" , "Jal" , "Jaleel" , "Jamal" , "James" , "Jamison" , "Jared" , "Jarek" , "Jarman" , "Jaron" , "Jarrod" , "Jarvis" , "Jason" , "Jasper" , "Javan" , "Javier" , "Jay" , "Jebidiah" , "Jed" , "Jedidiah" , "Jedrek" , "Jeff" , "Jeffrey" , "Jelani" , "Jeremiah" , "Jeremy" , "Jerolin" , "Jerome" , "Jeromy" , "Jerzy" , "Jesse" , "Jessee" , "Jethro" , "Jibril" , "Jin" , "Jiro" , "Jivin" , "Joel" , "Johann" , "John" , "Jolon" , "Jonah" , "Jonathan" , "Jonathon" , "Jordan" , "Jordon" , "Jorgen" , "Jorvin" , "Joseph" , "Joshua" , "Judd" , "Jude" , "Julian" , "Julius" , "Juma" , "Jung" , "Justin" , "Kadin" , "Kai" , "Kaikara" , "Kaladin" , "Kalb" , "Kale" , "Kalil" , "Kalkin" , "Kalman" , "Kamal" , "Kane" , "Kaniel" , "Kardal" , "Karl" , "Karsten" , "Kasch" , "Kasen" , "Kaspar" , "Kateb" , "Kayin" , "Keane" , "Kearney" , "Kedar" , "Keefe" , "Keelan" , "Keenan" , "Kegan" , "Keir" , "Keir" , "Keith" , "Kelby" , "Keleman" , "Kell" , "Kellen" , "Kelvin" , "Ken" , "Kenan" , "Kendall" , "Kendrick" , "Kenelm" , "Kenley" , "Kennard" , "Kennedy" , "Kenneth" , "Kent" , "Kenton" , "Kenyon" , "Keona" , "Ker" , "Kerby" , "Kern" , "Kerry" , "Kers" , "Kersen" , "Kerwin" , "Kester" , "Kevin" , "Khalil" , "Khoury" , "Kiefer" , "Kieran" , "Kiernan" , "Killian" , "Kin" , "Kinnel" , "Kinsey" , "Kintan" , "Kip" , "Kirby" , "Kirk" , "Kiyoshi" , "Kliftin" , "Klog" , "Komor" , "Kontar" , "Krischan" , "Krister" , "Kurt" , "Kyle" , "Kyler" , "Laethan" , "Laird" , "Lamar" , "Lamont" , "Lance" , "Lander" , "Landon" , "Lane" , "Lang" , "Larry" , "Lars" , "Lawler" , "Lawrence" , "Lazarus" , "Lear" , "Lee" , "Leif" , "Leighton" , "Leland" , "Len" , "Lennon" , "Lennor" , "Lennox" , "Lensar" , "Leo" , "Leon" , "Leonard" , "Leron" , "Leroy" , "Lester" , "Lev" , "Levi" , "Lewis" , "Lewis" , "Li" , "Liam" , "Like" , "Lincoln" , "Lindsey" , "Lionel" , "Llewellyn" , "Lloyd" , "Logan" , "Loren" , "Lorenzo" , "Lorne" , "Louis" , "Lowell" , "Lucas" , "Lucian" , "Luis" , "Luke" , "Lukyan" , "Lunt" , "Luther" , "Lyle" , "Lyndon" , "Lysander" , "Mac" , "Macer" , "Mack" , "Mackenzie" , "Magnus" , "Malcolm" , "Malik" , "Manco" , "Mandek" , "Mander" , "Manfred" , "Manning" , "Mansur" , "Manuel" , "Marc" , "Marcos" , "Marcus" , "Marden" , "Marek" , "Mario" , "Mark" , "Markham" , "Markos" , "Marlin" , "Marlon" , "Marlon" , "Marshal" , "Marshall" , "Marsten" , "Martin" , "Martingo" , "Marvin" , "Mason" , "Matai" , "Mateo" , "Mather" , "Matthew" , "Matthias" , "Maurice" , "Max" , "Maxwell" , "Maynard" , "Mayon" , "Mead" , "Meka" , "Mercer" , "Merill" , "Merle" , "Merrick" , "Merrik" , "Meyer" , "Micael" , "Michael" , "Migon" , "Miguel" , "Mike" , "Mikkel" , "Mikos" , "Miles" , "Miles" , "Milo" , "Milton" , "Miner" , "Mitchell" , "Monroe" , "Monte" , "Morgan" , "Morley" , "Morris" , "Mortimer" , "Morton" , "Morven" , "Morz" , "Motega" , "Mukasa" , "Murdoch" , "Murdock" , "Murphy" , "Myles" , "Myron" , "Naeem" , "Nalren" , "Nantan" , "Nathan" , "Nathaniel" , "Neal" , "Neale" , "Neil" , "Nelek" , "Nelson" , "Neron" , "Nestor" , "Nevan" , "Neville" , "Nevin" , "Nevin" , "Nicanor" , "Nicholas" , "Nigel" , "Nikolos" , "Nils" , "Noah" , "Nodin" , "Noe" , "Nolan" , "Norbert" , "Norman" , "Norris" , "Norton" , "Nuri" , "Nyle" , "Oakes" , "Oakley" , "Ochen" , "Octavius" , "Odell" , "Odin" , "Odion" , "Odon" , "Ogden" , "Olaf" , "Olin" , "Oliver" , "Omar" , "Ordano" , "Oren" , "Orion" , "Orman" , "Ormand" , "Orrin" , "Orson" , "Orville" , "Oscar" , "Osgood" , "Osmond" , "Otis" , "Otto" , "Owen" , "Paco" , "Palmer" , "Paolo" , "Paris" , "Parker" , "Parnell" , "Pascal" , "Patamon" , "Patrick" , "Patterson" , "Patton" , "Paul" , "Paulin" , "Pavel" , "Paxton" , "Payton" , "Pearce" , "Peder" , "Pembroke" , "Penn" , "Percival" , "Perry" , "Peter" , "Peyton" , "Phearcy" , "Philip" , "Phillip" , "Phillippe" , "Phoenix" , "Pierce" , "Pierre" , "Pierson" , "Pilan" , "Platon" , "Porter" , "Prentice" , "Prescot" , "Prescott" , "Preston" , "Quentin" , "Quenton" , "Quillan" , "Quincy" , "Quinlan" , "Quinn" , "Rad" , "Radcliffe" , "Radman" , "Rafael" , "Rafferty" , "Ragnar" , "Raidon" , "Raleigh" , "Ralph" , "Ramiro" , "Ramon" , "Ramsay" , "Ramsey" , "Ranard" , "Rance" , "Randall" , "Randolph" , "Ranen" , "Ranger" , "Rankin" , "Raoul" , "Raphael" , "Raul" , "Ravi" , "Ravi" , "Ravid" , "Ray" , "Raymond" , "Raynor" , "Reade" , "Redford" , "Redmond" , "Reed" , "Reese" , "Reeve" , "Regan" , "Reginald" , "Regis" , "Remington" , "Renaldo" , "Rendor" , "Renfry" , "Renny" , "Reuben" , "Rex" , "Reyhan" , "Rhett" , "Rhett" , "Rhys" , "Ricardo" , "Richard" , "Richter" , "Rico" , "Rider" , "Ridgley" , "Rigby" , "Riley" , "Rimon" , "Ringo" , "Ringo" , "Riodan" , "Riordan" , "Roarke" , "Robert" , "Roberto" , "Robi" , "Rockwell" , "Rod" , "Roderick" , "Rodman" , "Rodney" , "Rodrigo" , "Roger" , "Roi" , "Roland" , "Roldan" , "Rolf" , "Ronald" , "Ronan" , "Rooney" , "Rory" , "Roscoe" , "Ross" , "Roth" , "Rowan" , "Rowland" , "Roy" , "Royce" , "Ruben" , "Rudd" , "Rudi" , "Rudyard" , "Rufus" , "Runako" , "Ruskin" , "Russ" , "Russell" , "Rusty" , "Rutherford" , "Rutledge" , "Ryan" , "Ryder" , "Rylan" , "Sahale" , "Sahen" , "Salim" , "Saloman" , "Sam" , "Samien" , "Sammon" , "Samson" , "Samuel" , "Sanders" , "Sandon" , "Sandor" , "Sanford" , "Sargent" , "Sarngin" , "Sarojin" , "Saul" , "Saunders" , "Sawyer" , "Saxon" , "Schuyler" , "Scott" , "Sean" , "Sebastian" , "Sebastien" , "Seif" , "Selby" , "Senon" , "Sergio" , "Seth" , "Seung" , "Severin" , "Sevilin" , "Seward" , "Seymour" , "Shane" , "Shawn" , "Shea" , "Sheffield" , "Sheldon" , "Shen" , "Sheridan" , "Sherman" , "Sherwin" , "Sherwood" , "Shing" , "Shunnar" , "Sidney" , "Siegfried" , "Silas" , "Simon" , "Sivan" , "Skip" , "Skyler" , "Slade" , "Slevin" , "Smith" , "Solomon" , "Sorgan" , "Soterios" , "Spalding" , "Spencer" , "Spenser" , "Standford" , "Stanley" , "Stanton" , "Stasio" , "Stefan" , "Stephan" , "Stephen" , "Sterling" , "Stevan" , "Steve" , "Steven" , "Stewart" , "Stoke" , "Stoyan" , "Strom" , "Stuart" , "Subrey" , "Sulaiman" , "Sullican" , "Sumner" , "Sutherland" , "Sutton" , "Sven" , "Sylvester" , "Tab" , "Tabari" , "Tad" , "Tadi" , "Tai" , "Tajo" , "Talbart" , "Talbot" , "Talman" , "Talos" , "Tanek" , "Tanner" , "Tano" , "Taro" , "Tate" , "Taurin" , "Taylor" , "Tem" , "Terence" , "Terrence" , "Terrill" , "Terry" , "Thaddeus" , "Thai" , "Thaman" , "Thane" , "Thanos" , "Theobald" , "Theodore" , "Theron" , "Thierry" , "Thomas" , "Thorpe" , "Thurston" , "Thurston" , "Tibalt" , "Tiernan" , "Timothy" , "Titus" , "Tobias" , "Toby" , "Tod" , "Todd" , "Tomas" , "Tong" , "Tor" , "Torin" , "Torrance" , "Townsend" , "Travers" , "Travis" , "Tremain" , "Tremaine" , "Trent" , "Trevor" , "Trey" , "Tristan" , "Troy" , "Tryon" , "Tucker" , "Tully" , "Tyee" , "Tyler" , "Tymon" , "Tyrone" , "Upton" , "Uriah" , "Urian" , "Van" , "Vance" , "Vaughn" , "Vern" , "Vernon" , "Victor" , "Vincent" , "Vinson" , "Virgil" , "Vito" , "Vlad" , "Vladimir" , "Vokes" , "Volf" , "Wade" , "Wagner" , "Walden" , "Waldo" , "Walker" , "Wallace" , "Wally" , "Walter" , "Ward" , "Warner" , "Warren" , "Watson" , "Waylan" , "Wayland" , "Waylon" , "Wayne" , "Webb" , "Webster" , "Wendell" , "Wesley" , "Weston" , "Weylin" , "Whitaker" , "Wilfen" , "Will" , "Willard" , "Willem" , "William" , "Wilson" , "Winston" , "Winthrop" , "Wlby" , "Woody" , "Wyatt" , "Xavier" , "Xenos" , "Xerxes" , "Ximen" , "Yakecan" , "Yale" , "Yancey" , "Yardley" , "Yarin" , "Yerik" , "Yero" , "Yervant" , "York" , "Yusuf" , "Yves" , "Zachariah" , "Zachary" , "Zackery" , "Zaid" , "Zaide" , "Zane" , "Zaniel" , "Zann" , "Zared" , "Zarek" , "Zeke" , "Zenon" , "Zion" , "Ziven" , "Zorn"
            };

        public virtual List<string> NomFeminin => new List<string>()
        {
            "Aba","Abby","Abella","Abey","Abigail","Abina","Abiona","Abira","Abra","Abrah","Absinthe","Acacia","Acanit","Acantha","Accalia","Acelin","Achen","Ada","Adalia","Adara","Addi","Adelaide","Adele","Adelia","Adeline","Adelle","Adena","Aderes","Adesina","Adie","Adimina","Adiva","Adoncia","Adonia","Adora","Adrienne","Aelina","Afina","Afra","Afrika","Afton","Agate","Agatha","Agnes","Ahara","Ahave","Ahimsa","Aida","Aiella","Aiko","Aila","Aileen","Ailsa","Aimee","Ain","Aina","Ainhoa","Ainsley","Aintzane","Airlia","Aisling","Aislinn","Aithne","Aiyana","Ajara","Ajay","Ajinora","Akako","Akala","Akanke","Akasma","Akela","Akilah","Akili","Akilina","Akina","Alaina","Alake","Alala","Alamanada","Alana","Alani","Alanna","Alaqua","Alavda","Alazne","Alberta","Albinka","Alcina","Aldea","Aldercy","Aleka","Alenne","Alesia","Alessa","Alethea","Alexa","Alexandra","Alexandria","Alexandrina","Alexis","Ali","Alia","Alice","Alicia","Alida","Alike","Alima","Alina","Alison","Alita","Alix","Aliz","Aliza","Allele","Alligra","Allinora","Allison","Allyn","Alma","Alodie","Aloysia","Althea","Alula","Alumit","Alvina","Alvita","Alysa","Alyssa","Alyssand","Alzena","Ama","Amabel","Amadi","Amadika","Amadis","Amaia","Amala","Amalia","Amanda","Amandine","Amara","Amarande","Amarante","Amaris","Amata","Ambar","Amber","Ambika","Ambis","Ameerah","Amelia","Amelina","Amethyst","Amie","Amiella","Amina","Aminta","Amissa","Amita","Amity","Amoke","Amy","Ananda","Anastasia","Ancelin","Andi","Andra","Andraianna","Andras","Andrea","Andromeda","Aneida","Anella","Anemone","Anezka","Angela","Angelica","Angeline","Angelique","Angeni","Ani","Anica","Anieli","Anisa","Anita","Anke","Ann","Anna","Annabel","Annabelle","Annamarie","Anne","Annette","Annikka","Annora","Anorah","Anoush","Ansreana","Anteia","Anthea","Antje","Antoinette","Antonia","Aolani","Apara","Apirka","Apolline","Apolloina","Aponi","April","Aprille","Aprille","Aqua","Aquene","Ara","Arabella","Arabelle","Araceli","Araminta","Araxie","Arcadia","Ardath","Ardelia","Arden","Ardis","Ardith","Areiela","Arella","Aretha","Aretina","Ariadne","Ariana","Aricia","Ariel","Ariene","Arista","Arlene","Arlinda","Armina","Arminda","Artemisia","Aruna","Arziki","Asaria","Asenka","Ash","Asha","Ashlan","Ashleigh","Ashley","Asia","Asisa","Aslinda","Aspasia","Asta","Aster","Astera","Astra","Astrea","Astrid","Atalanta","Atara","Atenne","Ateri","Athalia","Athena","Athla","Atifa","Atta","Aubrey","Auda","Audny","Audrey","Audrianna","Audun","Augustina","Aura","Aure","Aurelia","Aurilia","Aurina","Aurkene","Aurora","Autumn","Ava","Avana","Avasa","Avella","Avena","Avie","Avis","Aviva","Axella","Aya","Ayaluna","Ayame","Ayana","Ayasha","Aydee","Ayela","Ayiana","Ayila","Ayisha","Ayita","Ayla","Aynora","Ayuna","Azaleah","Azalia","Azarael","Azera","Azha","Azilea","Azina","Azize","Azora","Azura","Babette","Bacia","Bacia","Baka","Baka","Bakarne","Balayna","Balea","Balia","Bambi","Banan","Banella","Bara","Barbara","Barika","Basha","Basha","Basia","Basimah","Batakah","Bathsheba","Batya","Bay","Bayana","Bayo","Bayta","Bea","Beatrice","Beatrix","Beauina","Becca","Becky","Bedelia","Bel","Belana","Belina","Belinda","Belita","Bellanca","Belle","Belora","Bente","Beradine","Berilla","Berit","Bernadette","Bernice","Beryl","Bess","Bessine","Beta","Beth","Bethana","Bethany","Betony","Betty","Beulah","Beverly","Bevin","Bian","Bianca","Billie","Bina","Bindy","Binti","Birdie","Birkita","Bixenta","Blanche","Blanda","Blenda","Bliss","Bly","Blythe","Bo","Bohdana","Bonamy","Bonita","Bonnie","Bonny","Borgny","Braina","Brandi","Brandy","Bren","Brenda","Brenna","Bretta","Bridget","Bridget","Brie","Brier","Brietta","Brigit","Brigitte","Brina","Brina","Briona","Briony","Brites","Britta","Brittany","Bronwyn","Brooke","Brynn","Bucia","Cadence","Caimile","Caitlin","Caitrin","Cala","Calandia","Calandra","Calendonia","Caley","Calida","Calista","Calla","Callan","Callia","Callidora","Callie","Caltha","Calypso","Cam","Camelia","Camilia","Camille","Canace","Candace","Candida","Candide","Candra","Cantara","Caoimhe","Capri","Caprice","Cara","Caradoc","Caresse","Cari","Carina","Carine","Carissa","Carita","Carla","Carleen","Carlen","Carling","Carlota","Carly","Carma","Carmel","Carmelina","Carmen","Carna","Carnelian","Carol","Carolina","Caroline","Carolyn","Caron","Carrie","Caryn","Casey","Casilda","Cassandra","Cassia","Casta","Castalia","Catalina","Catava","Caterina","Catherine","Cathleen","Cathy","Catriona","Cayla","Ceara","Cecania","Cecilia","Celandine","Celeste","Celia","Celina","Celina","Cellia","Cerelia","Chaitra","Chanah","Chanda","Chandi","Chandra","Chane","Chanel","Channa","Chantal","Charis","Charissa","Charity","Charlotte","Charmaine","Chastity","Chava","Chaviva","Chay","Chaya","Chelsea","Chenoa","Cherica","Cherice","Cherie","Cheryl","Chesna","Chiara","Chika","Chilali","Chimlis","Chipo","Chloe","Chloris","Cho","Christa","Christable","Christina","Christine","Christy","Chyou","Cia","Ciannait","Ciar","Cicely","Cindy","Claire","Clara","Clarinda","Clarissa","Claudette","Claudia","Claudine","Clementina","Clementine","Cliantha","Clorinda","Clorinda","Clover","Cochiti","Coleene","Colette","Connie","Constance","Constanza","Consuela","Cora","Coralie","Corazon","Corbey","Cordeali","Coretta","Cori","Corinna","Coris","Corliss","Corrine","Cortney","Crescent","Cressida","Crystal","Cybele","Cybil","Cynthia","Cyprien","Cyrene","Cyrilla","Cytheria","Dabria","Dacey","Dacia","Dacie","Dacio","Dae","Dagmar","Dagna","Dai","Daily","Daisel","Daisy","Dakota","Dale","Dalila","Dalilia","Damara","Damitri","Dana","Danett","Dania","Daniella","Danyelle","Daphene","Daphne","Daphnie","Dar","Dara","Daralis","Darby","Daria","Darla","Darlene","Dasha","Dasha","Davene","Davine","Davita","Dawn","Daya","Dayna","Deana","Deana","Deandra","Deb","Debra","Dede","Dee","Deedee","Deianira","Deiene","Deirdre","Delana","Delaney","Delbin","Delia","Delicia","Delilia","Della","Delphina","Dembe","Demi","Demitria","Dena","Denby","Denice","Deva","Devaki","Deval","Devi","Devin","Devnet","Devon","Diamanta","Diane","Dianthe","Diedre","Diella","Dillian","Dilly","Dilys","Dinah","Dionne","Disa","Dita","Diti","Dixie","Dodie","Dolores","Dominique","Dona","Donata","Donielle","Donner","Dooriya","Dophina","Dora","Doreen","Dorinda","Doris","Dorithy","Dory","Drew","Drina","Drucilla","Dulcie","Dulcinea","Dusty","Dyan","Dyani","Dymphna","Dyna","Eartha","Easter","Ebony","Echo","Edana","Edie","Edith","Edlyn","Edna","Edolie","Edria","Edwina","Efia","Eileen","Eirene","Elaine","Elana","Eleora","Elianor","Elina","Elina","Elisa","Elise","Eliska","Elissa","Elita","Eliza","Elizabeeth","Elke","Ella","Elle","Ellen","Elly","Elodie","Eloise","Elsa","Elsie","Elynor","Elyse","Elysia","Ema","Emajane","Emalia","Ember","Emelie","Emelyne","Emily","Emma","Endora","Engracia","Enid","Enola","Enye","Erasma","Erianthe","Erica","Erin","Erlina","Erwand","Eskarne","Esmerelda","Esperanza","Esta","Estelle","Esther","Estu","Etain","Etaina","Etaina","Etanthe","Etta","Eudocia","Eugenia","Eulalia","Eustacia","Eva","Evacsa","Evadine","Evadne","Evangeline","Evanthe","Eve","Evelyn","Evita","Evonne","Eyota","Fabienne","Faifuza","Fainche","Faith","Faizah","Fallon","Fantine","Farha","Farima","Farrah","Fatin","Fawne","Fay","Faye","Fayina","Fayme","Felcia","Felicite","Felicity","Femi","Feridwyn","Fern","Feronia","Filinda","Fina","Finola","Fiona","Fiorenza","Flavia","Fleta","Flora","Florence","Frances","Francesca","Francine","Francisca","Freda","Frederica","Freya","Frida","Frieda","Fuscienne","Gabriella","Gabrielle","Gaia","Gail","Galatea","Gali","Galina","Galya","Gana","Ganesa","Gauri","Gaye","Gayle","Gelasia","Gemma","Genevieve","Geogia","Georgeanne","Georgetta","Georgette","Georgiana","Geradline","Geraldine","Gerda","Gerri","Gertrude","Geva","Ghislaine","Giacinta","Gianina","Gigi","Gilana","Gilda","Gilen","Gillian","Gin","Gina","Ginger","Giselle","Gitana","Githa","Gizane","Gleda","Glenna","Glennys","Golda","Goldie","Gotzone","Grace","Gracie","Grainne","Grazia","Grear","Greta","Gretchen","Grette","Gwen","Gwendolyn","Gweneth","Gwynne","Gytha","Hadara","Hadassa","Hadiya","Haidee","Hailey","Haimi","Haldis","Hale","Haley","Hali","Hali","Halima","Halle","Hallie","Hana","Hanan","Hannah","Hanne","Harmoni","Harriet","Hasna","Hava","Haya","Haylee","Hazel","Hea","Heather","Hei","Heidi","Heldegarde","Helen","Helena","Helene","Helki","Henka","Henrietta","Hesper","Hester","Hilary","Hilda","Hinda","Hisa","Holly","Hope","Hoshi","Hyacinth","Hye","Hypatia","Ianthe","Ida","Idola","Idonia","Ilene","Ilona","Iman","Imogene","India","Indira","Indra","Ines","Inez","Inga","Ingrid","Iolana","Iolanthe","Iona","Iratze","Irena","Irene","Iris","Irma","Isabeau","Isabel","Isabella","Isadora","Isaura","Isis","Isleta","Isobel","Isoke","Istas","Ivana","Ivory","Ivy","Jacelyn","Jacinda","Jacinthe","Jada","Jael","Jaen","Jaimie","Jaione","Jakinda","Jala","Jamie","Jamila","Jamilah","Jan","Jana","Jane","Janelle","Janet","Janice","Janis","Janna","Jannelle","Jardena","Jarvia","Jarvinia","Jasmine","Jaya","Jayne","Jean","Jean","Jeanette","Jeanine","Jelena","Jena","Jenay","Jendayi","Jendyose","Jenica","Jennettia","Jennifer","Jensine","Jerrilyn","Jessica","Jewel","Jezebel","Jihan","Jillian","Jin","Jina","Jinny","Jinx","Joakima","Joan","Joanne","Jobey","Jobihna","Jocasa","Jocelyn","Jodi","Jody","Joelle","Joelliane","Johanna","Joia","Jolan","Jolanta","Jolene","Jolie","Joline","Jonina","Jora","Jordane","Josephine","Josie","Jotha","Joy","Joyce","Joye","Juanita","Judith","Juditha","Julia","Juliana","Juliane","Julie","Julietta","Julinka","Jumoke","Jun","June","Justine","Kaatje","Kachine","Kaclyn","Kaede","Kaethe","Kai","Kaia","Kaie","Kaili","Kaimi","Kairos","Kaiya","Kakra","Kala","Kalama","Kalanit","Kalare","Kalea","Kali","Kalika","Kalila","Kalinda","Kalle","Kalli","Kalonice","Kalyca","Kama","Kamala","Kamali","Kamaria","Kambo","Kameko","Kamilah","Kamilia","Kanda","Kane","Kanene","Kanika","Kantha","Kanya","Kapera","Kara","Karan","Karayan","Karel","Karen","Karida","Karimah","Karisa","Karka","Karla","Karlenne","Karli","Karlyn","Karmina","Karol","Karylin","Karyn","Kasa","Kasen","Kasia","Kasinda","Kassia","Kate","Katherine","Kathleen","Katja","Katoka","Katrien","Katrina","Kaula","Kaveri","Kavindra","Kay","Kaya","Kaye","Kayla","Kaysa","Kazia","Keara","Keelin","Keely","Kefira","Kehinde","Kei","Keiko","Keisha","Kelda","Kelia","Kelley","Kelli","Kellie","Kelly","Kelsey","Kendra","Kennis","Kenyangi","Kepa","Kerani","Kerensa","Kerstan","Kesare","Kesi","Kesia","Kessie","Keturah","Ketzia","Khalida","Kichi","Kiele","Kim","Kimberly","Kimmie","Kimmy","Kineta","Kiona","Kira","Kiran","Kirby","Kirima","Kirsten","Kirti","Kisa","Kiska","Kismet","Kissa","Kita","Kohana","Kolina","Koren","Koressa","Kristen","Kyly","Kyna","Kynthia","Kyoko","Lacey","Lacie","Laila","Lailie","Lakeisha","Lala","Lalasa","Lan","Lana","Landra","Lane","Lani","Lara","Laraine","Laralee","Lari","Larissa","Lark","Latika","Latonia","Laura","Laurana","Laurel","Laurie","Laurinda","Lauryn","Laveda","Lavern","Laverne","Lavinia","Lea","Leah","Leah","Leala","Leandra","Leba","Ledah","Lee","Leigh","Leiko","Leila","Leilana","Lena","Lene","Lenor","Lenora","Lenore","Leona","Leora","Leslie","Letha","Letitia","Levana","Lexine","Lia","Liadan","Lian","Liana","Liane","Libby","Lien","Lila","Lilith","Lillian","Lillie","Lily","Limber","Lina","Linda","Lindsay","Lindsey","Linette","Linnae","Linnea","Lisa","Lisette","Litsa","Liv","Liza","Lois","Lokelani","Lola","Loni","Lora","Lore","Lorelei","Lorelle","Loretta","Lori","Lorraine","Lotus","Louise","Lucille","Lucine","Lucretia","Lucy","Ludia","Luela","Luisa","Lukene","Lukina","Lulu","Luna","Lydia","Lynda","Lynelle","Lynn","Lynnda","Lynnette","Lyris","Lysel","Lysnadra","Mabel","Macaria","Machi","Maddy","Madelaine","Madelina","Madeline","Madelon","Madelyn","Mady","Mae","Magan","Magara","Magdalen","Magdalena","Magdaline","Magena","Magenta","Maggie","Mahala","Mahalia","Mai","Maia","Maida","Maisie","Maitane","Maizah","Maj","Malaya","Malila","Malina","Malinda","Malka","Mallory","Malu","Mamie","Manda","Mandara","Mandisa","Mandy","Mangena","Manon","Mansi","Manya","Mara","Marcella","Marcia","Marcy","Maren","Margaret","Margaret","Margarita","Margo","Margot","Marguirte","Maria","Mariah","Mariam","Mariama","Marian","Mariana","Marianna","Marianne","Maribel","Marie","Mariel","Marietta","Marily","Marilyn","Marina","Maris","Marisa","Marisha","Marissa","Marjani","Marjeta","Marjorie","Marlene","Marlo","Marmara","Marnie","Marnina","Marsha","Marta","Martha","Marti","Martina","Mary","Maryann","Marybeth","Marylou","Marzia","Matana","Mathea","Matilda","Matrika","Maud","Maura","Maureen","Maurita","Mavis","Maxine","May","Maya","Meara","Meara","Meda","Medea","Meg","Megan","Megara","Meghan","Mei","Meira","Mela","Melanie","Melantha","Melba","Melia","Melian","Melina","Melinda","Melisenda","Melissa","Mellinio","Melodie","Melody","Melosa","Melva","Mercedes","Meredith","Merele","Mesha","Meta","Mia","Miakoda","Michaela","Michele","Michelle","Midori","Migina","Mignon","Mika","Millicent","Millie","Min","Mina","Minda","Mindel","Mindy","Minerva","Minka","Minna","Minnie","Mira","Miranda","Mirem","Miremba","Mireya","Miriam","Mirielle","Missy","Misty","Mitena","Mitexi","Mitzi","Moira","Mollie","Molly","Mona","Monique","Moon","Morena","Morgan","Morgana","Morgance","Moria","Moriah","Muriel","Myra","Nada","Nadia","Nadine","Nadya","Naia","Nailah","Naimah","Nalini","Namazzi","Nami","Nan","Nana","Nancy","Nanette","Nantale","Naomi","Napea","Nara","Narda","Narmada","Nasiche","Nastassia","Natalie","Natane","Natasha","Natesa","Naysa","Nazirqah","Neala","Neci","Nediva","Neely","Nekane","Nell","Neola","Neoma","Neona","Neria","Nerine","Nerissa","Netti","Neva","Nevada","Neysa","Nicia","Nicola","Nicole","Nicolette","Nika","Nikki","Nimah","Nina","Niobe","Niola","Nira","Nirvelli","Nissa","Nita","Nitara","Nixie","Noel","Noelani","Noella","Nolita","Nona","Nona","Nora","Norah","Noreen","Nori","Noriko","Norma","Nydia","Nyrna","Nyssa","Obelia","Octavia","Odelia","Odelia","Odera","Odessa","Odetta","Odette","Odile","Ohanna","Okelani","Olathe","Olayinka","Olesia","Olga","Oliana","Olinda","Olivette","Olivia","Ona","Onida","Opal","Ophelia","Oralie","Orane","Orenda","Oriana","Orianna","Oriel","Oriole","Orlantha","Ornidaa","Paige","Pakuna","Palmiera","Paloma","Pamela","Pandita","Pandora","Panthea","Pantzike","Panya","Panyin","Pascale","Patia","Patience","Patricia","Patsy","Paula","Paulette","Pauline","Pavla","Pazia","Pearl","Peg","Peggy","Pelagia","Pemba","Penda","Penelope","Peninna","Penny","Penthea","Peony","Perdita","Perouze","Persis","Petra","Phaedra","Phedra","Philomena","Phoebe","Phylis","Phyllis","Pia","Pier","Pila","Piper","Polly","Poloma","Porche","Portia","Priscilla","Prudence","Prudy","Pyrena","Pythia","Qamra","Queena","Quella","Quenby","Quintina","Quiterie","Rachel","Radella","Radinka","Rae","Rai","Raizel","Ramla","Ramona","Ramya","Randie","Rane","Ranee","Rani","Raquel","Rashida","Rasine","Ratri","Raven","Rawnie","Rayna","Raynell","Raziya","Reba","Rebecca","Regan","Regina","Reidun","Remy","Rena","Renata","Rene","Renee","Rhea","Rhiamon","Rhianne","Rhiannon","Rhoda","Rhodanthe","Rhonda","Rhonna","Rhyssa","Ria","Riane","Rica","Rihana","Rikki","Rio","Risa","Rita","Riva","Roanna","Roberta","Robin","Robyn","Rochelle","Rohanna","Rona","Rorie","Rosa","Rosalind","Rosalinda","Rosalinde","Rosaline","Rosanne","Rose","Roseanne","Rosemarie","Rosemary","Rowena","Roxana","Roxanne","Ruby","Rumer","Ruth","Ruthann","Ryann","Ryanne","Ryba","Ryssa","Saba","Sabina","Sabiny","Sabirah","Sabra","Sabrina","Sacha","Sachi","Sade","Sadira","Saffi","Safiya","Sagara","Saidah","Sakari","Sakinah","Sakti","Sakura","Salihah","Salimah","Salina","Sally","Salome","Samantha","Samara","Samirah","Sancia","Sandia","Sandra","Sandrine","Sandya","Sara","Sarah","Sarai","Saraid","Saree","Sarena","Sari","Sarisha","Sasha","Sashenka","Satinka","Savanna","Saxon","Scotia","Searlait","Season","Sebasten","Seema","Sela","Selena","Selina","Selma","Semele","Senta","Serafina","Serilda","Sesha","Shaine","Shakira","Shako","Shammara","Shana","Shanata","Shandra","Shandy","Shani","Shanley","Shanna","Shannon","Shantay","Shantha","Sharman","Sharon","Sharri","Shashi","Shawn","Shayndel","Sheba","Sheena","Sheila","Shela","Shelby","Shelley","Shelly","Sherri","Shika","Shin","Shina","Shira","Shirley","Shobi","Shoshana","Sibley","Sibongile","Sibyl","Sidonia","Sidra","Sierra","Sigourney","Siham","Sileas","Silva","Silvia","Simba","Simone","Sine","Sinead","Siobhan","Siran","Sirena","Siroun","Sitara","Sitembile","Siv","Sive","Skyler","Sofi","Solana","Solange","Soledad","Solita","Sondra","Sonia","Sonja","Sonya","Sophia","Sophie","Sophronia","Spica","Stacey","Stacia","Stacy","Stefania","Stella","Stephani","Stephanie","Ster","Stesha","Stockard","Storm","Sukatai","Suki","Sumi","Summer","Sun","Susan","Susanna","Suzanne","Svetlana","Sybil","Sydelle","Sydney","Syeira","Sylvia","Syna","Synia","Tabitha","Taci","Tacita","Tadi","Taffy","Tahirah","Tai","Taima","Tainn","Taipa","Taite","Taka","Takara","Takiyah","Takoda","Talasi","Tale","Talia","Talia","Talitha","Tallulah","Tam","Tama","Tamara","Tamary","Tamma","Tammy","Tanaka","Tani","Tansy","Tanya","Tao","Tara","Tate","Tatyana","Tawnie","Tawny","Tayce","Taylor","Teague","Tehya","Tekla","Temina","Terentia","Terese","Terrilyn","Tertia","Teryn","Tesia","Tess","Tessa","Thadea","Thais","Thalassa","Thalia","Than","Thana","Thara","Thea","Thekla","Thelma","Theodosia","Theone","Thera","Thirza","Thora","Thyra","Tia","Tiara","Tienette","Tierney","Tierra","Tiffany","Tilda","Timandra","Tina","Tiponya","Tirza","Tivona","Tobey","Tola","Tora","Tori","Tory","Tosia","Tove","Tracey","Tracy","Treasa","Tresa","Treva","Trianon","Tricia","Trilby","Trina","Trind","Trish","Trisha","Trudy","Tryne","Tryphena","Tyne","Ula","Ulani","Ultima","Uma","Una","Undine","Undine","Urania","Uriana","Ursula","Uta","Vala","Valentina","Valeria","Valerie","Valeska","Valonia","Valora","Vanda","Vanessa","Vanora","Vanya","Vashti","Veda","Velika","Velma","Venesssa","Vera","Verena","Verity","Veronica","Vesta","Vevila","Victoria","Vidonia","Violet","Violet","Violetta","Virginia","Viridis","Viveka","Vivian","Voleta","Vrinda","Wakanda","Wanda","Waneta","Wendy","Whilhelmina","Whitney","Wijdan","Willow","Wilma","Wilona","Winda","Winema","Winifred","Winna","Winona","Wynee","Wynn","Wynona","Xanthe","Xaveria","Xaviera","Xena","Xenia","Ximena","Xylia","Xylona","Yachne","Yanice","Yarmilla","Yasmeen","Yasmin","Yelinda","Yenene","Yesmina","Yetta","Yeva","Yokiko","Yolanda","Yolie","Yonina","Yovela","Yvella","Yvette","Yvonne","Zada","Zahara","Zahirah","Zahra","Zakia","Zalea","Zalika","Zaltana","Zandra","Zara","Zarah","Zaza","Zehava","Zelda","Zelenka","Zelia","Zella","Zena","Zenaide","Zenia","Zerlinda","Zeva","Zevida","Zia","Ziazan","Zigana","Zila","Zina","Zinnia","Zita","Zoe","Zola","Zona","Zora","Zorah","Zorda","Zosia","Zuleika","Zulema","Zuza","Zuzanny"
        };
   

        public BaseRace(int raceID, int raceIndex, string name, string pluralName, int maleBody, int femaleBody, int maleGhostBody, int femaleGhostBody) :
            base(raceID, raceIndex, name, pluralName, maleBody, femaleBody, maleGhostBody, femaleGhostBody)
        {
        }

        public override void AddRace(Mobile m)
        {
            AddRace(m, RandomSkinHue());
        }


        public override void AddRace(Mobile m, int hue)
        {
            m.Hue = hue;

            if (RaceGump.Count > 0)
            {
                foreach (Type item in RaceGump)
                {
                    BaseRaceGumps skin = (BaseRaceGumps)Activator.CreateInstance(item, hue);

                    Item Present = m.FindItemOnLayer(skin.Layer);

                    if (Present != null)
                    {
                        m.AddToBackpack(Present);
                    }

                    m.EquipItem(skin);
                }
            }
        }

        public override void ChangeHue(Mobile m)
        {
            // Sert principalement à rotater sur le hue. Utile pour faire des screen de toute les couleurs possibles ;)

            int hue = RotateHue(m.Hue);

            RemoveRace(m);

            AddRace(m, hue);
        }


		public override void RemoveRace(Mobile m)
        {

            if (RaceGump.Count > 0)
            {

                foreach (Type item in RaceGump)
                {

                    BaseRaceGumps baseGump = (BaseRaceGumps)Activator.CreateInstance(item, 0);

                    Item itemEquip = m.FindItemOnLayer(baseGump.Layer);

                    if (itemEquip != null)
                    {
                        if (itemEquip.GetType() == item)
                        {
                            itemEquip.Delete();
                        }

                        baseGump.Delete();
                    }
                }

            }
        }


        public virtual List<int> GetGump(bool female, int hue)
        {
            List<int> GumpID = new List<int>();

            if (RaceGump.Count != 0)
            {
                foreach (Type item in RaceGump)
                {
                    BaseRaceGumps baseGump = (BaseRaceGumps)Activator.CreateInstance(item, 0);

					GumpID.Add(female ? 10000 + GumpId : GumpId) ;

                    baseGump.Delete();
                }

            }
            else
            {
                GumpID.Add(female ? 13 : 12);
            }

            return GumpID;


        }

        public override void CheckGump(Mobile m)
        {


            if (RaceGump.Count != 0)
            {
                foreach (Type item in RaceGump)
                {
                    BaseRaceGumps baseGump = (BaseRaceGumps)Activator.CreateInstance(item, 0);

                    if (m.FindItemOnLayer(baseGump.Layer).GetType() == baseGump.GetType())
                    {

                    }
                    else
                    {
                        m.EquipItem(baseGump);
                    }

                    baseGump.Delete();
                }

            }
        }





        public override int ClipSkinHue(int hue)
        {
			return RandomSkinHue();
		//    throw new NotImplementedException();
		}




		public override bool ValidateHair(bool female, int itemID)
		{
			if (itemID == 0)
				return true;

			if ((female && itemID == 0x2048) || (!female && itemID == 0x2046))
				return false;   //Buns & Receeding Hair

			if (itemID >= 0x203B && itemID <= 0x203D)
				return true;

			if (itemID >= 0x2044 && itemID <= 0x204A)
				return true;

			return false;
		}

		public override int RandomHair(bool female) //Random hair doesn't include baldness
		{
			switch (Utility.Random(9))
			{
				case 0:
					return 0x203B;  //Short
				case 1:
					return 0x203C;  //Long
				case 2:
					return 0x203D;  //Pony Tail
				case 3:
					return 0x2044;  //Mohawk
				case 4:
					return 0x2045;  //Pageboy
				case 5:
					return 0x2047;  //Afro
				case 6:
					return 0x2049;  //Pig tails
				case 7:
					return 0x204A;  //Krisna
				default:
					return (female ? 0x2046 : 0x2048);  //Buns or Receeding Hair
			}
		}

		public override bool ValidateFacialHair(bool female, int itemID)
		{
			if (itemID == 0)
				return true;

			if (female)
				return false;

			if (itemID >= 0x203E && itemID <= 0x2041)
				return true;

			if (itemID >= 0x204B && itemID <= 0x204D)
				return true;

			return false;
		}

		public override int RandomFacialHair(bool female)
		{
			if (female)
				return 0;

			int rand = Utility.Random(7);

			return ((rand < 4) ? 0x203E : 0x2047) + rand;
		}

		public override bool ValidateFace(bool female, int itemID)
		{
			if (itemID.Equals(0))
				return false;

			if (itemID >= 0x3B44 && itemID <= 0x3B4D)
				return true;

			return false;
		}

		public override int RandomFace(bool female)
		{
			int rand = Utility.Random(9);

			return 15172 + rand;
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}


		public override int RandomSkinHue()
		{
			return SkinHues[Utility.Random(SkinHues.Length)];
		} 

		public override int ClipHairHue(int hue)
		{
			if (hue < 1102)
				return 1102;
			else if (hue > 1149)
				return 1149;
			else
				return hue;
		}

		public override int RandomHairHue()
		{
			return Utility.Random(1102, 48);
		}

		public override int ClipFaceHue(int hue)
		{
			return ClipSkinHue(hue);
		}

		public override int RandomFaceHue()
		{
			return RandomSkinHue();
		}



		public string RandomName(bool Female = false)
        {
            string nameReturn = "";

            if (Female)
            {
                nameReturn = NomFeminin[Utility.Random(NomFeminin.Count)];
            }
            else
            {
                nameReturn = NomMasculin[Utility.Random(NomMasculin.Count)];
            }
            return nameReturn;
        }
    }
}
