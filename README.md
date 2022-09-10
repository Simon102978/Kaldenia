# A fixer - Kaldenia


-PlayerVendor et maison fonctionne avec l'account, donc possibilité d'accèder au information de son alt.
-les baits sont en jeu, les baits ne donne pas + de chance de capturer le poisson relié au bait
-Protection en arcane retire entierement le MR et 13 physical resist.
-Les guildes bug vs le nom // Deguisement ?
-Fixer le healing, qui ramene le fantome a son corps, lorsque healer avec bandage
-Quand on est deguise, notre nom sur la pierre de guilde et sur la plancarte (old) de maison change pour le nom de notre deguisement.
-Si tu delog deguise, ca brise les infos de ton bodyvalue (tu te ramasse avec le mauvais skins et mauvaise teinte de peau.)
-Valider que les aoe touche pas les invocations pour les sortilèges.
-Fixer les crafts de nourritures de skills (a rescripter, les bouffe se stacks a l'infini (peu atteindre 200 dans un skills) mais ne dure que 2 minutes après la création)
-Faire en sorte que les cadeaux puisse etre pièger.
-les crops plantées dans une maison se suppriment apres un certain temps
-on peu pas nourirre les triton avec de la meat... meme si ses supposer etre meat 
-? ta machine espresso etait defectueuse ! y avait un delais de plusieurs jour que mon café soit pret !! et imposible de le sortir du baril ensuite 
-Esclave (Qui fait planter, y'a un bug a quek part)
-Cisseau de barbier, joueur et esclave ne marche pas
-Esclave delog avec personnage
-Josephine liberé fait planter le serveur lors de sa mort.


# A faire ?

-Possibilité de pouvoir drag un joueur assomer avec une commande?
-Renom vs item id
-Spell d'animation qui créer des mobs sinon j'avais rien d'autre lol
-Enlever l'or prelever directement dans la banque, pour les achats (?)
-Les statues ne semblent plus prendre la teinte du granit utilisé, même une fois 'complétée'.
-dans le .deco il y a le .flip de commenté aussi
-Crash Log n'apparait pas lorsqu'utiliser avec Linux...











# [ServUO]

[![Build Status](https://travis-ci.com/ServUO/ServUO.svg?branch=master)](https://travis-ci.com/ServUO/ServUO)
[![GitHub issues](https://img.shields.io/github/issues/servuo/servuo.svg)](https://github.com/ServUO/ServUO/issues)
[![GitHub release](https://img.shields.io/github/release/servuo/servuo.svg)](https://github.com/ServUO/ServUO/releases)
[![GitHub repo size](https://img.shields.io/github/repo-size/servuo/servuo.svg)](https://github.com/ServUO/ServUO/)
[![Discord](https://img.shields.io/discord/110970849628000256.svg)](https://discord.gg/0cQjvnFUN26nRt7y)
[![GitHub contributors](https://img.shields.io/github/contributors/servuo/servuo.svg)](https://github.com/ServUO/ServUO/graphs/contributors)
[![GitHub](https://img.shields.io/github/license/servuo/servuo.svg?color=a)](https://github.com/ServUO/ServUO/blob/master/LICENSE)


[ServUO] is a community driven Ultima Online Server Emulator written in C#.


#### Requirements

[.NET 5.0] Runtime and SDK


#### Windows

Run `Compile.WIN - Debug.bat` for development environments.
Run `Compile.WIN - Release.bat` for production environments.


#### OSX
```
brew install mono
brew install dotnet
dotnet build
```
To run `mono ServUO.exe`


#### Ubuntu / Debian
```
apt-get install zlib1g-dev mono-complete dotnet-sdk-5.0 
dotnet build
```
To run `mono ServUO.exe`


#### Summary

1. Starting with the `/Config` directory, find and edit `Server.cfg` to set up the essentials.
2. Go through the remaining `*.cfg` files to ensure they suit your needs.
3. For Windows, run `Compile.WIN - Debug.bat` to produce `ServUO.exe`, Linux users may run `Makefile`.
4. Run `ServUO.exe` to make sure everything boots up, if everything went well, you should see your IP adress being listened on the port you specified.
5. Load up UO and login! - If you require instructions on setting up your particular client, visit the Discord and ask!

   [ServUO]: <https://www.servuo.com>
   [.NET 5.0]: <https://dotnet.microsoft.com/download>
