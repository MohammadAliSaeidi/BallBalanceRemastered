using BallBalance;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class save_game
{
	private const string accountName = "Test_AccountName";

	[Test]
	public void save_and_load_game_as_encrypted_json_format()
	{
		var gems = new List<Gem>()
		{
		   new GameObject("gem_01", typeof(Gem)).GetComponent<Gem>(),
		   new GameObject("gem_02", typeof(Gem)).GetComponent<Gem>(),
		   new GameObject("gem_03", typeof(Gem)).GetComponent<Gem>(),
		   new GameObject("gem_04", typeof(Gem)).GetComponent<Gem>(),
		};

		AccountSaveModel accountSave = new AccountSaveModel();
		accountSave.GemsCount = 20;
		accountSave.lastPlayedLevelSave = new LevelSaveModel(
									levelId: 7,
									playerPosition: new Vector3(24.2f, 15.2f, 61.2f),
									lives: 2,
									gemsCollected: gems,
									remainingTimeInSec: 25
									);

		SaveAndLoadManager.SaveGame(accountName: accountName, accountSave);
		var loadedSave = SaveAndLoadManager.LoadSaves(accountName);

		Assert.AreEqual(2, loadedSave.lastPlayedLevelSave.lives);
	}
}
