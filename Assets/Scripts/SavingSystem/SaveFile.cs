using BallBalance.SavingService;
using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
	public class SaveFile : ISavableFile
	{
		public readonly Vector3 playerPosition;
		public readonly int lives;
		public readonly List<Gem> gemsCollected;
		public readonly int remainingTimeInSec;

		public SaveFile(Vector3 playerPosition, int lives, List<Gem> gemsCollected, int remainingTimeInSec)
		{
			this.playerPosition = playerPosition;
			this.lives = lives;
			this.gemsCollected = gemsCollected;
			this.remainingTimeInSec = remainingTimeInSec;
		}
	}
}
