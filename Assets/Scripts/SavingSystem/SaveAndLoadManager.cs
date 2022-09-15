using BallBalance.SavingService;
using System.Collections.Generic;
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

		private static readonly string savePath;

		static SaveAndLoadManager()
		{
			savePath = $"{Application.persistentDataPath}/Saves/SaveGame_";
		}

		public static void SaveGame(int levelId, Vector3 playerPosition, int lives, List<Gem> gems, int timeRemainingInSeconds)
		{
			SaveFileModel fileToSave = new SaveFileModel(
				playerPosition,
				lives,
				gems,
				timeRemainingInSeconds);

			string json = JsonUtility.ToJson(fileToSave);
			var encryptedJson = Serialization.Encryption.StringCipher.Encrypt(json, "1234");
			FileSavingService.SaveTextToFile(encryptedJson, $"{savePath}{levelId}");
		}

		public static SaveFileModel LoadGame(int levelId)
		{
			var encryptedJson = FileSavingService.LoadTextFromFile($"{savePath}{levelId}");
			var decryptedJson = Serialization.Encryption.StringCipher.Decrypt(encryptedJson, "1234");
			var loadedGame = JsonUtility.FromJson<SaveFileModel>(decryptedJson);
			return loadedGame;
		}


		// check if the file has correct name
		// check if has the correct type
	}
}
