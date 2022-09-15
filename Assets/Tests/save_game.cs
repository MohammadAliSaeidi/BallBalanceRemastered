using System.Collections;
using System.Collections.Generic;
using BallBalance;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class save_game
{
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

        SaveAndLoadManager.SaveGame(
                                    levelId: 7,
									playerPosition: new Vector3(24.2f, 15.2f, 61.2f),
									lives: 2,
									gems: gems,
									timeRemainingInSeconds: 25
                                    );
        var loadedGame = SaveAndLoadManager.LoadGame(7);

        Assert.AreEqual(2, loadedGame.lives);
    }
}
