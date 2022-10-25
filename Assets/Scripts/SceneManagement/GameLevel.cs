namespace BallBalance.SceneManagement
{
	internal class GameLevel
	{
		internal readonly string Name;
		internal readonly int LevelId;

		public GameLevel(string levelName, int levelId)
		{
			Name = levelName;
			LevelId = levelId;
		}
	}
}
