using System;

namespace BallBalance.SceneManagement
{
	internal static class GameLevels
	{
		internal static readonly GameLevel Splash = new GameLevel("Splash", 0);
		internal static readonly GameLevel MainMenu = new GameLevel("MainMenu", 1);
		internal static readonly GameLevel Tutorial = new GameLevel("Tutorial", 2);

		internal static string Level(int levelId)
		{
			if (levelId >= 3)
			{
				return $"level_{levelId}";
			}

			else
			{
				throw new ArgumentOutOfRangeException("levelId", "levelId must be greater than 2");
			} 
		}
	}
}
