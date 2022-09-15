using BallBalance.SavingService;
using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
	public class SaveFileModel : ISavableFile
	{
		public Vector3 playerPosition;
		public int lives;
		public List<Gem> gemsCollected;
		public int remainingTimeInSec;

		public SaveFileModel(Vector3 playerPosition, int lives, List<Gem> gemsCollected, int remainingTimeInSec)
		{
			this.playerPosition = playerPosition;
			this.lives = lives;
			this.gemsCollected = gemsCollected;
			this.remainingTimeInSec = remainingTimeInSec;
		}
	}
}
