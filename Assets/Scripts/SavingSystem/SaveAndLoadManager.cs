using BallBalance.SavingService;
using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
	public static class SaveAndLoadManager
	{
		private static readonly string savePath;

		static SaveAndLoadManager()
		{
			savePath = $"{Application.persistentDataPath}/Saves/SaveGame_";
		}

		public static void SaveGame(string accountName, AccountSaveModel fileToSave)
		{

			FileSavingService.SerializeToBinary(fileToSave, savePath);

			//string json = JsonUtility.ToJson(fileToSave);
			//var encryptedJson = Serialization.Encryption.StringCipher.Encrypt(json, "1234");
			//FileSavingService.SaveTextToFile(encryptedJson, $"{savePath}{levelId}");
		}

		public static AccountSaveModel LoadSaves(string accountName)
		{
			//var encryptedJson = FileSavingService.LoadTextFromFile($"{savePath}{levelId}");
			//var decryptedJson = Serialization.Encryption.StringCipher.Decrypt(encryptedJson, "1234");
			//var loadedGame = JsonUtility.FromJson<SaveFileModel>(decryptedJson);

			var loadedGameObj = FileSavingService.DeserializeFromBinary<AccountSaveModel>(savePath);

			return loadedGameObj;
		}


		// check if the file has correct name
		// check if has the correct type
	}
}
