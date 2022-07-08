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
			Map.Felucca.Season = 0;
			Map.Trammel.Season = 0;
			Map.Ilshenar.Season = 0;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("La Saison a �t� chang�e pour le Printemps");
			Console.ResetColor();
			#endregion
		}
	}
}