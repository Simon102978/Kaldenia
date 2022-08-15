using System;

namespace Server.StartUp
{
	public class ServerStartUp
	{
		public static void Initialize()
		{
			#region Seasons
			/* 
                *   Spring      = 0
                *   Summer      = 1
                *   Autumn/Fall = 2
                *   Winter      = 3
                *   Desolation  = 4
            */
			Map.Felucca.Season = 1;
			Map.Trammel.Season = 1;
			Map.Ilshenar.Season = 1;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("La Saison a été changée pour l'été");
			Console.ResetColor();
			#endregion
		}
	}
}