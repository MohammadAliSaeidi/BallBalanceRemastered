using BallBalance.Database;
using BallBalance.SceneManagement;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace BallBalance.SplashScreen
{
	internal class SplashManager : MonoBehaviour
	{
		internal IEnumerator Init(SplashScreenUIController uIController)
		{
			Task getAccount = Task.Run(async () =>
			{
				GameManager.Instance.account = await DatabaseManager.Instance.GetAccount();
			});

			yield return new WaitUntil(() => getAccount.IsCompleted);

			if (GameManager.Instance.account != null)
			{
				SceneManager.Instance.Load(GameLevels.MainMenu);
			}

			else
			{
				Debug.Log("no any account");
				// TODO: Create user account
				uIController.ShowSignup();
			}
		}
	}
}
