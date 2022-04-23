using BallBalance.Database;
using BallBalance.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BallBalance.SplashScreen
{
    internal class SplashManager : MonoBehaviour
    {
		internal IEnumerator Init(SplashScreenUIController UIController)
		{
			Task getAccount = Task.Run(async () =>
			{
				GameManager.Instance.account = await DatabaseManager.Instance.GetAccount();
			});

			yield return new WaitUntil(() => getAccount.IsCompleted);

			if (GameManager.Instance.account != null)
			{
				SceneManager.Instance.Load(GameLevels.SampleScene_02);
			}

			else
			{
				Debug.Log("no any account");
				// TODO: Create user account
				UIController.ShowSignup();
			}
		}
	}
}