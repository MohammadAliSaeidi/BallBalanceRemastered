using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
	public partial class SaveAndLoadManager : MonoBehaviour
	{
		// What should be saved?
		// 1: The ball position
		// 2: Player lives
		// 3: Gems that has been collected
		// 4: Time
		public class SaveFile
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


		public void SaveGame()
		{
			SaveFile fileToSave = new SaveFile(GameManager.Instance);
		}

		public void LoadGame()
		{

		}


		// check if the file has correct name
		// check if has the correct type
	}
}
