using SQLite4Unity3d;
using UnityEngine;

namespace BallBalance.Database
{
    public static class Database
	{
		internal static string FileRootPath { get; private set; }
		private static SQLiteConnection _connection;

		internal static void Init()
		{
			//set constant addresses
			FileRootPath = Application.persistentDataPath + "/";

			//create SQLite Connection
			OpenDatabase();

			//create tables
			_connection.CreateTable<Account>();

			DisposeDatabase();
		}

		internal static void InsertOrReplace(Account account)
		{
			OpenDatabase();

			_connection.InsertOrReplace(account);

			DisposeDatabase();
		}

		internal static Account GetAccount()
		{
			try
			{
				OpenDatabase();

				var account = _connection.Table<Account>().FirstOrDefault();

				DisposeDatabase();

				return account;
			}
			catch
			{
				throw;
			}
		}

		internal static void OpenDatabase()
		{
			_connection = new SQLiteConnection(FileRootPath + "ball_balance.db", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		}

		internal static void DisposeDatabase()
		{
			_connection.Close();
		}
    }
}
