using System;
using UnityEngine;
using BallBalance.Database;
using System.Threading.Tasks;

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

		void Start()
		{
			Task.Run(async () =>
			{
				await Init();
			});
		}

		async Task Init()
		{
			account = await DatabaseManager.Instance.GetAccount();

			if (account != null)
			{

			}

			else
			{
				Debug.Log("no any account");
				// TODO: Create user account
			}
		}
	}
}
