namespace Server.Custom.Misc
{
	public enum HueManagerList
	{
		Red,
		Yellow,
		Green,
		Orange,
		Blue,
		Purple,
		Cyan
	}

	public class HueManager
	{
		public static int GetHue(HueManagerList hue)
		{
			var hueNumber = 0;

			switch (hue)
			{
				case HueManagerList.Red: { hueNumber = 37; break; }
				case HueManagerList.Yellow: { hueNumber = 46; break; }
				case HueManagerList.Green: { hueNumber = 72; break; }
				case HueManagerList.Purple: { hueNumber = 117; break; }
				case HueManagerList.Orange: { hueNumber = 43; break; }
				case HueManagerList.Blue: { hueNumber = 92; break; }
				case HueManagerList.Cyan: { hueNumber = 182; break; }
			}

			return hueNumber;
		}
	}
}
