using BallBalance.SavingService;
using UnityEngine;

namespace BallBalance
{
	public static class SaveAndLoadManager
	{
		// What should be saved?
		// 1: The ball position
		// 2: Player lives
		// 3: Gems that has been collected
		// 4: Time

		public static void SaveGame()
		{
			var currentLevelManager = GameManager.Instance.currentLevelManager;
			if (currentLevelManager == null)
			{
				Debug.LogError("The game could not be saved because you are not in a level.");
				return;
			}

			Vector3 playerPosition = currentLevelManager.CurrentBall.transform.position;

			SaveFile fileToSave = new SaveFile(
				playerPosition,
				currentLevelManager.Heals,
				currentLevelManager.Gems,
				currentLevelManager.TimeRemainingInSeconds);

			string filePath = $"{Application.persistentDataPath}/Saves/SaveGame_{currentLevelManager.LevelId}";

			string json = JsonUtility.ToJson(fileToSave);

			AESEncryptionService.FileEncrypt(json, "1234");

			
		}

		public static void LoadGame()
		{
			// TODO: LoadGame
		}


		// check if the file has correct name
		// check if has the correct type
	}
}
