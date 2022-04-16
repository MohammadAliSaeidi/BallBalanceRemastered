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
		}

		internal static Account GetAccount()
		{
			OpenDatabase();

			var account = _connection.Table<Account>().First();

			CloseDatabase();

			return account;
		}

		internal static void InsertOrReplace(Account account)
		{
			OpenDatabase();

			_connection.InsertOrReplace(account);

			CloseDatabase();
		}

		static void OpenDatabase()
		{
			_connection = new SQLiteConnection(FileRootPath + "ball_balance.db", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		}

		static void CloseDatabase()
		{
			_connection.Close();
		}
    }
}
