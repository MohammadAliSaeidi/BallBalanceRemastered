using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
	public class LevelSaveModel
	{
		public int levelId;
		public Vector3 playerPosition;
		public int lives;
		public List<Gem> gemsCollected;
		public int remainingTimeInSec;

		public LevelSaveModel(int levelId, Vector3 playerPosition, int lives, List<Gem> gemsCollected, int remainingTimeInSec)
		{
			this.levelId = levelId;
			this.playerPosition = playerPosition;
			this.lives = lives;
			this.gemsCollected = gemsCollected;
			this.remainingTimeInSec = remainingTimeInSec;
		}
	}
}
