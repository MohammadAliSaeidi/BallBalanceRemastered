using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BallBalance.Database
{
	public class DatabaseManager : MonoBehaviour
	{
		#region Singletone

		private static DatabaseManager _instance;
		public static DatabaseManager Instance { get { return _instance; } }

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

		void Awake()
		{
			Singleton();
			Database.Init();
		}

		internal async Task InsertOrReplace(Account account)
		{
			await Task.Run(() =>
				{
					Database.InsertOrReplace(account);
				});
		}

		internal async Task<Account> GetAccount()
		{
			Account account = null;

			await Task.Run(() =>
				{
					account = Database.GetAccount();
				});

			return account;
		}

		internal async Task<bool> AddUserAccount(Account account)
		{
			bool result = false;

			try
			{
				await Task.Run(() =>
				{
					Database.SetAccount(account);
					result = true;
				});
			}
			catch
			{
				result = false;
			}

			return result;
		}

		[ContextMenu("Close Database")]
		void CloseDatabase()
		{
			Database.DisposeDatabase();
		}
	}
}
