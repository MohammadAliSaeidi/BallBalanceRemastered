using System;
using UnityEngine;
using BallBalance.Database;
using BallBalance.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

namespace BallBalance
{
	public class GameManager : MonoBehaviour
	{
		#region Singletone

		private static GameManager _instance;
		public static GameManager Instance { get { return _instance; } }

		void Singleton()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(this.gameObject);
			}
			else
			{
				_instance = this;
			}
			DontDestroyOnLoad(_instance);
		}

		#endregion

		public const bool isDebug = false;

		Account account;

		void Awake()
		{
			Singleton();
		}

		IEnumerator Start()
		{
			yield return Init();
		}

		IEnumerator Init()
		{
			Task getAccount = Task.Run(async () =>
			{
				account = await DatabaseManager.Instance.GetAccount();
			});

			yield return new WaitUntil(() => getAccount.IsCompleted);

			if (account != null)
			{
			}

			else
			{
				Debug.Log("no any account");
				SceneManager.Instance.Load(GameLevels.SampleScene_02);
				// TODO: Create user account
			}
		}
	}
}
